using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security;
using System.Security.Authentication;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PortKonnect.Common.Exceptions;
using PortKonnect.Common.Services;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using System.IdentityModel.Tokens;

namespace PortKonnect.UserAccessManagement.UI
{
    [Authorize]
    [AppSettings]
    [CustomErrorHandler]
    public class PortKonnectBaseController : Controller
    {
        public PrivilegeDTO privilege;
        protected ContextDTO ContextDto = new ContextDTO();

        public string ApplicationEntityId { get; set; }
      
        protected bool GetPrivilegesFor(string appEntityId, string appEntityFunctionCode)//int appId, string subscriberId, string userName, string appEntityId, string appEntityFunctionCode)
        {
            bool hasPrivilege = false;
            List<AuthorizedFunctionDTO> authorizedFunctionDtos = new List<AuthorizedFunctionDTO>();

            this.privilege = new PrivilegeDTO();

            string url = ConfigurationManager.AppSettings["UAMAPIUrl"];

           // string username = ContextDto.UserName.ToLower();
            if (User.Identity.IsAuthenticated)
            {
                ContextDto = GetContextFromCookie();
            }
            try
            {
                url += "api/Functions/GetAuthorisedUserFunctions/" + ContextDto.ApplicationId + "/" + ContextDto.SubscriberId + "/" + ContextDto.UserName + "/" + ContextDto.PortCode + "/" + appEntityId;

                authorizedFunctionDtos = ApiClient.RestGet<List<AuthorizedFunctionDTO>>(url, ContextDto.Token);

                if (authorizedFunctionDtos != null)
                {
                    this.privilege.Privileges = string.Join(",", authorizedFunctionDtos.Select(p => p.FunctionCode));
                    hasPrivilege = this.privilege.Privileges.Contains(appEntityFunctionCode);
                }
                else
                {
                    throw new AuthenticationException(BusinessExceptions.TokenExpired);
                }

                //TODO: testing only
                this.privilege.Privileges = "VIEW,EDIT";

            }
            catch (Exception ex)
            {
                //TODO: Need to throw proper exception here
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

        public ContextDTO GetContextFromCookie()
        {
            //Checking the access token is expired and if expired new is accessed from current request items added in parent project action filter method otherqise the access token is accessed from Identity only
            ContextDto.Token = !string.IsNullOrEmpty((string)HttpContext.Items["access_token"])? (string)HttpContext.Items["access_token"] : ((ClaimsIdentity)User.Identity).FindFirst("access_token").Value;
            if (ContextDto.Token == null)
                throw new AuthenticationException(BusinessExceptions.InvalidToken);

            if (!string.IsNullOrEmpty(ContextDto.Token))
            {
                // string jsonobjContextDto = null;//JsonWebToken.Decode(token, secretkey, false);

                if (string.IsNullOrEmpty(ContextDto.Token))
                {
                    throw new AuthenticationException(BusinessExceptions.EmptyToken);
                }
                var handler = new JwtSecurityTokenHandler();
                var jsonobjContextDto = handler.ReadToken(ContextDto.Token) as JwtSecurityToken;

                if (jsonobjContextDto == null)
                {
                    throw new AuthenticationException(BusinessExceptions.EmptyToken);
                }
                //TODO: Need to read subscriberId for calls from Services


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
            else
            {
                throw new AuthenticationException(BusinessExceptions.EmptyToken);
            }

            if (ContextDto == null)
            {
                throw new AuthenticationException(BusinessExceptions.InvalidToken);
            }
            return ContextDto;

        }
    }
}