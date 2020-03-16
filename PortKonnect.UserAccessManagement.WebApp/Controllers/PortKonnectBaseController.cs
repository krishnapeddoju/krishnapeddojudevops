using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Authentication;
using System.Web.Mvc;
using PortKonnect.Common.Exceptions;
using PortKonnect.Common.Services;
using System.Security.Claims;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.UI
    {
        [Authorize]
        public class PortKonnectBaseController : Controller
        {
            private readonly List<string> _clientsList = ConfigurationManager.AppSettings["client_id"].Split(',').ToList();
            public PrivilegeDTO privilege;
            protected ContextDTO ContextDto = new ContextDTO();

            public string ApplicationEntityId { get; set; }

            public PortKonnectBaseController()
            {
            }

            protected bool GetPrivilegesFor(string appEntityId, string appEntityFunctionCode)
            {


                bool hasPrivilege = false;
                List<AuthorizedFunctionDTO> authorizedFunctionDtos = new List<AuthorizedFunctionDTO>();

                this.privilege = new PrivilegeDTO();

                try
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        ContextDto = GetContextFromCookie();
                        string url = ConfigurationManager.AppSettings["UAMAPIUrl"];
                        url += "api/Functions/GetAuthorisedUserFunctions/" + ContextDto.ApplicationId + "/" +
                               ContextDto.SubscriberId + "/" + ContextDto.UserName + "/" + ContextDto.PortCode + "/" +
                               appEntityId;

                        authorizedFunctionDtos = ApiClient.RestGet<List<AuthorizedFunctionDTO>>(url, ContextDto.Token);

                        if (authorizedFunctionDtos != null)
                        {
                            this.privilege.Privileges = string.Join(",", authorizedFunctionDtos.Select(p => p.FunctionCode));
                            hasPrivilege = this.privilege.Privileges.Contains(appEntityFunctionCode);
                        }
                    }
                    else
                    {
                        throw new Exception(BusinessExceptions.TokenExpired);
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
                if (String.IsNullOrEmpty(this.privilege.Privileges))
                    return hasPrivilege;
                else
                    return hasPrivilege;

            }


            public bool CheckIsFirstTimeLogin()
            {
                ContextDto = GetContextFromCookie();
                if (ContextDto.IsFirstTimeLogin == "Y")
                {
                    return false;
                }
                else
                    return true;

            }

            //TODO: Need to check the below method where to kept
            public UserDTO checkUserDetails(string LogTransId)
            {

                string url = ConfigurationManager.AppSettings["UAMAPIUrl"];
                try
                {
                    url += "api/User/ForgetPassword/" + LogTransId;
                    UserDTO user = ApiClient.RestGet<UserDTO>(url);
                    return user;


                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);


                }
            }

            //TODO: To get user details based on userId
            public UserDTO GetDetails(string userId)
            {

                string url = ConfigurationManager.AppSettings["UAMAPIUrl"];
                try
                {
                    url += "api/GetUserForUserId/" + userId;
                    UserDTO user = ApiClient.RestGet<UserDTO>(url, ContextDto.Token);
                    return user;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }


            public ContextDTO GetContextFromCookie()
            {
                try
                {
                    ContextDto.Token = !string.IsNullOrEmpty((string)HttpContext.Items["access_token"]) ? (string)HttpContext.Items["access_token"] : ((ClaimsIdentity)User.Identity).FindFirst("access_token").Value;

                    var handler = new JwtSecurityTokenHandler();

                    var jsonobjContextDto = handler.ReadToken(ContextDto.Token) as JwtSecurityToken;

                    if (jsonobjContextDto == null)
                    {
                        throw new AuthenticationException(BusinessExceptions.EmptyToken);
                    }
                    //TODO: Need to read subscriberId for calls from Services

                    if (_clientsList.Contains(jsonobjContextDto.Claims.Where(c => c.Type == "client_id")
                        .Select(c => c.Value).SingleOrDefault()))
                    {
                        //TODO:B: Handle the case if Application Id returned is not integer..
                        ContextDto.ApplicationId = Convert.ToInt32(jsonobjContextDto.Claims.Where(c => c.Type == "ApplicationId")
                            .Select(c => c.Value).SingleOrDefault());
                        ContextDto.MemberCode = jsonobjContextDto.Claims.Where(c => c.Type == "MemberCode")
                            .Select(c => c.Value).SingleOrDefault();
                        ContextDto.MemberId = jsonobjContextDto.Claims.Where(c => c.Type == "MemberId")
                            .Select(c => c.Value).SingleOrDefault();
                        ContextDto.MemberType = jsonobjContextDto.Claims.Where(c => c.Type == "MemberType")
                            .Select(c => c.Value).SingleOrDefault();
                        ContextDto.UserId = jsonobjContextDto.Claims.Where(c => c.Type == "UserId")
                            .Select(c => c.Value).SingleOrDefault();
                        ContextDto.SubscriberId = jsonobjContextDto.Claims.Where(c => c.Type == "SubscriberId")
                            .Select(c => c.Value).SingleOrDefault();
                        ContextDto.PortCode = jsonobjContextDto.Claims.Where(c => c.Type == "PortCode")
                            .Select(c => c.Value).SingleOrDefault();
                        ContextDto.IsFirstTimeLogin =
                            jsonobjContextDto.Claims.Where(c => c.Type == "IsFirstTimeLogin").Select(c => c.Value).SingleOrDefault();
                        ContextDto.PartnerTypes =
                            jsonobjContextDto.Claims.Where(c => c.Type == "PartnerTypes").Select(c => c.Value).SingleOrDefault();
                        ContextDto.UserName = jsonobjContextDto.Claims.Where(c => c.Type == "UserName")
                        .Select(c => c.Value).SingleOrDefault();
                        ContextDto.UserRoles = string.Join(",",
                            jsonobjContextDto.Claims.Where(c => c.Type == "UserRoles").Select(c => c.Value).ToList());
                    }
                    UserDTO user = GetDetails(ContextDto.UserId);
                    if (user != null)
                    {
                        ContextDto.Email = user.EmailId;
                        ContextDto.Mobile = user.ContactNumber;
                        ContextDto.UserRoleCodeArray = user.UserRoleCodeArray;
                    }
                    // }
                }
                catch (Exception ex)
                {
                    throw new AuthenticationException(BusinessExceptions.InvalidToken, ex);
                }

                return ContextDto;
            }
        }
    }

