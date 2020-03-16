using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Authentication;
using log4net;
using log4net.Config;
using System.Security.Claims;
using IdentityModel.Client;
using PortKonnect.Common.Exceptions;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Filters
{
    public class AppSettingsAttribute : ActionFilterAttribute
    {
        private readonly List<string> _clientsList = ConfigurationManager.AppSettings["client_id"].Split(',').ToList();

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            HttpContext ctx = HttpContext.Current;
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult == null)
                return;

            Dictionary<string, string> appSettingKeyValues = new Dictionary<string, string>();


            var requireAppKeys = ConfigurationManager.AppSettings["requireAppKeys"];
            if (!string.IsNullOrEmpty(requireAppKeys))
            {
                string[] requireKeys = requireAppKeys.Split(',');
                foreach (var keyvalue in requireKeys)
                {
                    appSettingKeyValues.Add(keyvalue, ConfigurationManager.AppSettings[keyvalue]);
                }
                viewResult.ViewBag.AppSettings = appSettingKeyValues;
            }
            if ((filterContext.ActionDescriptor).ActionName.ToLower() != "login" &&
         (filterContext.ActionDescriptor).ActionName.ToLower() != "sessionexpired" && (filterContext.ActionDescriptor).ActionName.ToLower() != "forgotpassword" && (filterContext.ActionDescriptor).ActionName.ToLower() != "partnerregistration" && (filterContext.ActionDescriptor).ActionName.ToLower() != "partnerregistrationedit" && ((filterContext.ActionDescriptor).ActionName.ToLower() != "feedbackform" || ((ClaimsIdentity)ctx.User.Identity).FindFirst("access_token").Value != null))
            {
                if (!string.IsNullOrEmpty((string)(ctx.Items["access_token"])))
                {
                    viewResult.ViewBag.AccessToken = (string)(ctx.Items["access_token"]);
                    if (!string.IsNullOrEmpty((string)(ctx.Items["access_token"])))
                        ctx.Items.Remove("access_token");
                }
                else
                {
                    viewResult.ViewBag.AccessToken = ((ClaimsIdentity)ctx.User.Identity).FindFirst("access_token").Value;
                }
                var contextdtoPar = GetTokenFromRequest(viewResult.ViewBag.AccessToken);
                viewResult.ViewBag.SubscriberId = contextdtoPar.SubscriberId;
                viewResult.ViewBag.ApplicationId = contextdtoPar.ApplicationId;
                viewResult.ViewBag.Name = contextdtoPar.UserName;
                viewResult.ViewBag.AccessTokenCreated = contextdtoPar.MemberCode;
                //TODO: Set the expiry time from Aceess token using jwt token
                viewResult.ViewBag.AccessTokenExpiry = contextdtoPar.MemberId;
                viewResult.ViewBag.IsFirstTimeLogin = contextdtoPar.IsFirstTimeLogin;
            }
            base.OnActionExecuted(filterContext);
        }
     
        private ContextDTO GetTokenFromRequest(string accessToken)
        {
            ContextDTO userContextDto = new ContextDTO();
            try
            {
                //TODO: Review:  Do not use HttpContext within the ApplicationService/ Domain layers.  Please use a different method.
                userContextDto.Token = accessToken;


                var handler = new JwtSecurityTokenHandler();

                var jsonobjContextDto = handler.ReadToken(userContextDto.Token) as JwtSecurityToken;

                if (jsonobjContextDto == null)
                {
                    throw new AuthenticationException(BusinessExceptions.EmptyToken);
                }
                //TODO: Need to read subscriberId for calls from Services

                if (_clientsList.Contains(jsonobjContextDto.Claims.Where(c => c.Type == "client_id")
                    .Select(c => c.Value).SingleOrDefault()))
                {

                    userContextDto.SubscriberId = jsonobjContextDto.Claims.Where(c => c.Type == "SubscriberId")
                        .Select(c => c.Value).SingleOrDefault();
                    userContextDto.ApplicationId = Convert.ToInt32(jsonobjContextDto.Claims.Where(c => c.Type == "ApplicationId")
                            .Select(c => c.Value).SingleOrDefault());
                    userContextDto.UserName = jsonobjContextDto.Claims.Where(c => c.Type == "UserName").Select(c => c.Value).SingleOrDefault();
                    // using for purpose of data assigning which is used further for expiry date confirmation
                    userContextDto.MemberId = jsonobjContextDto.Claims.Where(c => c.Type == "exp").Select(c => c.Value).SingleOrDefault();
                    userContextDto.MemberCode = jsonobjContextDto.Claims.Where(c => c.Type == "iat").Select(c => c.Value).SingleOrDefault();
                    userContextDto.MemberCode = jsonobjContextDto.Claims.Where(c => c.Type == "signin").Select(c => c.Value).SingleOrDefault();
                    userContextDto.IsFirstTimeLogin = jsonobjContextDto.Claims.Where(c => c.Type == "IsFirstTimeLogin").Select(c => c.Value).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to fetch data into ContextDTO"); ;
            }

            return userContextDto;
        }
    }

}