using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Security.Claims;
using System.Web.Http;
using log4net;
using log4net.Config;
using PortKonnect.Common.Exceptions;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Api
{
    [Authorize]
    public class ApiControllerBase : ApiController
    {
        private ILog _log;
        protected ContextDTO contextDto;
       
        public ApiControllerBase()
        {

            XmlConfigurator.Configure();
            _log = LogManager.GetLogger(typeof(ApiControllerBase));


            if (User.Identity.IsAuthenticated)
            {
                //TODO:B: Handle exceptions if a claim type is not available for some reason.
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    contextDto = new ContextDTO();
                    contextDto.UserName = identity.Claims.Where(c => c.Type == ClaimTypes.Name)
                        .Select(c => c.Value).SingleOrDefault();
                    //TODO:B: Handle the case if Application Id returned is not integer..
                    contextDto.ApplicationId = Convert.ToInt32(identity.Claims.Where(c => c.Type == "ApplicationId")
                        .Select(c => c.Value).SingleOrDefault());
                    contextDto.SubscriberId = identity.Claims.Where(c => c.Type == "SubscriberId")
                        .Select(c => c.Value).SingleOrDefault();
                    contextDto.PortCode = identity.Claims.Where(c => c.Type == "PortCode")
                        .Select(c => c.Value).SingleOrDefault();
                    contextDto.MemberId = identity.Claims.Where(c => c.Type == "MemberId")
                        .Select(c => c.Value).SingleOrDefault();
                    contextDto.MemberCode = identity.Claims.Where(c => c.Type == "MemberCode")
                        .Select(c => c.Value).SingleOrDefault();
                    contextDto.MemberType = identity.Claims.Where(c => c.Type == "MemberType")
                        .Select(c => c.Value).SingleOrDefault();
                    contextDto.UserId = identity.Claims.Where(c => c.Type == "UserId")
                        .Select(c => c.Value).SingleOrDefault();
                    contextDto.UserName = identity.Claims.Where(c => c.Type == "UserName")
                        .Select(c => c.Value).SingleOrDefault();
                    contextDto.PartnerLogo = identity.Claims.Where(c => c.Type == "PartnerLogo")
                     .Select(c => c.Value).SingleOrDefault(); contextDto.IsFirstTimeLogin =
                        identity.Claims.Where(c => c.Type == "IsFirstTimeLogin").Select(c => c.Value).SingleOrDefault();
                    contextDto.PartnerTypes =
                        identity.Claims.Where(c => c.Type == "PartnerTypes").Select(c => c.Value).SingleOrDefault();
                    contextDto.UserRoles = string.Join(",",
                        identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList());
                }
                else
                {
                    log_error("", new SecurityException(BusinessExceptions.InvalidClaims));
                }
            }

            else
            {
                log_error("", new SecurityException(BusinessExceptions.Sessionexpired));

            }

        }

protected void ValidateAuthorizedUser(string userRequested)
        {
            string userLoggedIn = User.Identity.Name.ToLower();
            if (userLoggedIn != userRequested)
                throw new SecurityException("Attempting to access data for another user.");
        }

        protected HttpResponseMessage GetHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> codeToExecute)
        {
            _log = LogManager.GetLogger(typeof(ApiControllerBase));

            _log.Info("Controller : " + this.GetType().Name + " Method : " + codeToExecute.Method.Name);

            HttpResponseMessage response = null;

            try
            {
                if (!(request.RequestUri.LocalPath == BusinessExceptions.ResetPwdUrl || request.RequestUri.LocalPath.Contains("api/User/ForgetPassword/") || request.RequestUri.LocalPath == "/api/Account/ForgotPassword" || request.RequestUri.LocalPath.Contains("/api/Account/TokenServieResetPassword/") || request.RequestUri.LocalPath.Contains("api/GetApplicationUrl")))
                {
                    if (!User.Identity.IsAuthenticated)
                    {
                        throw new SecurityException(BusinessExceptions.Sessionexpired);
                    }
                }
                if (codeToExecute != null)
                {
                    GetToken();
                    response = codeToExecute.Invoke();
                }
            }
            catch (SecurityException ex)
            {
                log_error(this.GetType().Name, ex);
                response = request.CreateResponse(HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (Exception ex)
            {
                log_error(this.GetType().Name, ex);
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        protected T ExecuteWithException<T>(Func<T> codeToExecute)
        {
            try
            {
                T response = default(T);
                if (!User.Identity.IsAuthenticated)
                {
                    throw new SecurityException(BusinessExceptions.Sessionexpired);
                }
                if (codeToExecute != null)
                {
                    response = codeToExecute.Invoke();
                }
                return response;

            }
            catch (SecurityException ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, ex.Message));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error"));
            }

        }


        private void log_error(string pretext, Exception ex)
        {
            string msg = pretext + " " + ex.Message + " " + DateTime.Now;
            if (ex.InnerException != null)
            {
                if (!string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    msg = msg + " Inner Exception:" + ex.InnerException.Message;
                }
            }
            _log.Error(msg);

        }

        private void GetToken()
        {
            if (Request.Headers.Authorization != null && Request.Headers.Authorization.Parameter != null && Request.Headers.Authorization.Parameter != "undefined")
            {
                contextDto.Token = Request.Headers.Authorization.Parameter;
            }
        }
    }
}