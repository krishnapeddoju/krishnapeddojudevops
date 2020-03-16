using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortKonnect.Common.Services;
using PortKonnect.eGate.Web;
using PortKonnect.Notifications.Domain.DTOS;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.GlobalConstants;
using WebApi.OutputCache.V2;
//using Microsoft.Owin.Security;
//using Microsoft.Owin.Security.Cookies;

namespace PortKonnect.UserAccessManagement.Api
{
    public class AccountController : ApiControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }



        #region User Authentication Methods
        [AllowAnonymous]
        [Route("api/Account/ResetPassword")]
        [HttpPost]
        public HttpResponseMessage ResetPassword(HttpRequestMessage request, UserDTO userDTO)
        {
            return GetHttpResponse(request, () =>
            {


                string msg = _accountService.ResetPassword(userDTO.ApplicationId, userDTO.SubscriberId, userDTO.UserName);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, msg);
                return response;
            });
        }



        [AllowAnonymous]
        [HttpGet]
        [Route("api/Account/TokenServieResetPassword/{applicationId}/{subscriberId}/{userName}/{signin}/{loggedApplication}")]

        public HttpResponseMessage TokenServieResetPassword(HttpRequestMessage request, int applicationId, string subscriberId, string userName, string signin, string loggedApplication)
        {
            return GetHttpResponse(request, () =>
            {


                string msg = _accountService.TokenServieResetPassword(applicationId, subscriberId, userName, signin);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, msg);
                return response;
            });
        }


        [Route("api/Account/Changepassword")]
        [HttpPost]
        public HttpResponseMessage ChangePasswordForUser(HttpRequestMessage request, UserDTO userDTO)
        {
            return GetHttpResponse(request, () =>
            {
                userDTO.UserId = (string.IsNullOrWhiteSpace(userDTO.UserId) ? contextDto.UserId : userDTO.UserId);
                userDTO.Password = PasswordDataService.Encrypt(userDTO.Password, true);
                userDTO.NewPassword = PasswordDataService.Encrypt(userDTO.NewPassword, true);
                userDTO.UserName = (string.IsNullOrWhiteSpace(userDTO.UserName) ? contextDto.UserName : userDTO.UserName);
                string msg = _accountService.ChangePassword(userDTO.UserName, userDTO.Password, userDTO.NewPassword, userDTO.UserId);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, msg);
                return response;
            });
        }

        [AllowAnonymous]
        [Route("api/Account/ForgotPassword")]
        [HttpPost]
        public HttpResponseMessage ForgotPassword(HttpRequestMessage request, UserDTO userDTO)
        {
            return GetHttpResponse(request, () =>
            {

                userDTO.Password = PasswordDataService.Encrypt(userDTO.Password, true);
                userDTO.NewPassword = PasswordDataService.Encrypt(userDTO.NewPassword, true);
                string msg = _accountService.Forgotpassword(userDTO.UserName, userDTO.Password, userDTO.NewPassword, userDTO.LogTransId);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, msg);
                return response;
            });
        }


        [HttpGet]
        [Route("api/Account/GetMenuForUser/{applicationId}/{subscriberId}/{name}")]
        public HttpResponseMessage GetMenuForUser(HttpRequestMessage request, int applicationId, string subscriberId, string name)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                List<MenuModuleDTO> modules = new List<MenuModuleDTO>();
                modules = _accountService.GetMenuForUser(applicationId, subscriberId, contextDto.UserId);

                response = request.CreateResponse(HttpStatusCode.OK, modules);
                return response;

            });
        }
        [HttpGet]
        [Route("api/Account/GetMenuPrevilegesForUser/{applicationId}/{subscriberId}/{name}")]
        public HttpResponseMessage GetMenuPrevilegesForUser(HttpRequestMessage request, int applicationId, string subscriberId, string name)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                List<MenuModuleDTO> modules = new List<MenuModuleDTO>();
                modules = _accountService.GetMenuPrevilegesForUser(applicationId, subscriberId, contextDto.UserId);

                response = request.CreateResponse(HttpStatusCode.OK, modules);
                return response;

            });
        }
        [HttpGet]
        [Route("api/Account/GetModulesForUser/{applicationId}/{subscriberId}/{name}")]
        public HttpResponseMessage GetModulesForUser(HttpRequestMessage request, int applicationId, string subscriberId, string name)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                List<MenuModuleDTO> modules = new List<MenuModuleDTO>();
                modules = _accountService.GetModulesForUser(applicationId, subscriberId, contextDto.UserId);

                response = request.CreateResponse(HttpStatusCode.OK, modules);
                return response;

            });
        }


        [Route("api/Account/GetUserDetails/{applicationId}/{subscriberId}/{userName}")]
        [HttpGet]
        public HttpResponseMessage GetUserDetails(HttpRequestMessage request, int applicationId, string subscriberId, string userName)
        {
            return GetHttpResponse(request, () =>
            {
                ContextDTO contextDto = _accountService.GetUserDetails(applicationId, subscriberId, userName);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, contextDto);
                return response;
            });
        }

        [AllowAnonymous]
        [Route("api/User/ForgetPassword/{LogTransId}")]
        [HttpGet]
        public HttpResponseMessage GetUserDetails(HttpRequestMessage request, string LogTransId)
        {
            return GetHttpResponse(request, () =>
            {
                UserDTO userDtos = _accountService.GetUserDetailsByTransId(LogTransId);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, userDtos);
                return response;
            });
        }

        #region User Authentication Data Service API Implementation
        [Route("api/Account/AuthenticateUser/{applicationId}/{userName}/{password}/{subscriberId}")]
        [HttpGet]
        public HttpResponseMessage AuthenticateUser(HttpRequestMessage request, int applicationId, string userName, string password, string subscriberId)
        {

            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                string isAuthenticated = _accountService.AuthenticateUser(applicationId, userName, PasswordDataService.Encrypt(password, true), subscriberId);
                response = request.CreateResponse(HttpStatusCode.OK, isAuthenticated == UAMGlobalConstants.Success);
                return response;
            });
        }

        [Route("api/GetUnauthorizedUserMessages/{applicationId}/{userName}/{password}")]
        [HttpGet]
        [AllowAnonymous]
        public string GetUnauthorizedUserMessages(HttpRequestMessage request, int applicationId, string userName, string password)
        {
            //TODO: Hard-coded temporarily Not used currently
            string message = _accountService.GetUnauthorizedUserMessages(applicationId, userName,
                PasswordDataService.Encrypt(password, true), "KPCT");
            return message;
        }

        [Route("api/Functions/GetAuthorisedUserFunctions/{appId}/{subscriberId}/{userId}/{portCode}/{appEntityId}")]
        [HttpGet]
        public HttpResponseMessage GetAuthorisedUserFunctions(HttpRequestMessage request, int appId, string subscriberId, string userId, string portCode, string appEntityId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                List<AuthorizedFunctionDTO> userFunctionDtos = _accountService.GetAuthorisedUserFunctions(appId, subscriberId, userId, portCode, appEntityId);
                response = request.CreateResponse(HttpStatusCode.OK, userFunctionDtos);
                return response;
            });
        }
        [Route("api/Functions/GetAuthorisedUserFunctions/{appId}/{subscriberId}/{userId}/{portCode}/{appEntityId}/{appEntityFunctionCode}")]
        [HttpGet]
        public HttpResponseMessage GetAuthorisedUserFunctions(HttpRequestMessage request, int appId, string subscriberId, string userId, string portCode, string appEntityId, [FromUri] List<string> appEntityFunctionCode)
        {
            return GetHttpResponse(request, () =>
            {

                HttpResponseMessage response = null;
                List<string> xx = appEntityFunctionCode.ToList();

                string[] array = appEntityFunctionCode.ToList()[0].Split(',');
                List<string> list = new List<string>();
                list = array.ToList();
                List<AuthorizedFunctionDTO> userFunctionDtos = _accountService.GetAuthorisedUserFunctions(appId, subscriberId, userId, portCode, appEntityId, list);
                response = request.CreateResponse(HttpStatusCode.OK, userFunctionDtos);
                return response;

            });
        }
        #endregion

        #endregion

        #region User Notifications
        //TODO:Below methods has to move Notifications project

        [Route("api/Account/GetSystemNotificationDetails")]
        [HttpGet]
        public HttpResponseMessage GetSystemNotificationDetails(HttpRequestMessage request, string fromDate, string toDate)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                string url = ConfigurationManager.AppSettings["NotificationApiUrl"];
                if (contextDto != null)
                {
                    url += "api/Notification/GetSystemNotificationDetails/" + contextDto.ApplicationId + "/" + contextDto.MemberId + "/" + contextDto.PortCode + "/" + contextDto.UserId + "/" + fromDate + "/" + toDate;
                    List<SystemNotificationDTO> systemNotificationDto = ApiClient.RestGet<List<SystemNotificationDTO>>(url, contextDto.Token);

                    response = request.CreateResponse(HttpStatusCode.OK, systemNotificationDto);
                    return response;
                }
                return response;
            });
        }



        [Route("api/Account/GetSystemNotifications")]
        [HttpGet]
        public HttpResponseMessage GetSystemNotifications(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                string url = ConfigurationManager.AppSettings["NotificationApiUrl"];
                if (contextDto != null)
                {

                    url += "api/Notification/GetSystemNotifications";
                    List<SystemNotificationDTO> systemNotificationDto = ApiClient.RestGet<List<SystemNotificationDTO>>(url, contextDto.Token);

                    response = request.CreateResponse(HttpStatusCode.OK, systemNotificationDto);
                    return response;

                }

                return response;

            });
        }

        [Route("api/Account/GetSystemNotificationsCount")]
        [HttpGet]
        public HttpResponseMessage GetSystemNotificationsCount(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                string url = ConfigurationManager.AppSettings["NotificationApiUrl"];

                if (contextDto != null)
                {
                    url += "api/Notification/GetSystemNotificationsCount";
                    int notificationCount = ApiClient.RestGet<int>(url, contextDto.Token);

                    response = request.CreateResponse(HttpStatusCode.OK, notificationCount);
                    return response;
                }

                return response;
            });
        }

        [Route("api/Account/UpdateSystemNotification")]
        [HttpPost]
        public HttpResponseMessage IsReadNotificationsByID(HttpRequestMessage request, SystemNotificationDTO systemNotification)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                string url = ConfigurationManager.AppSettings["NotificationApiUrl"];
                url += "api/Notification/UpdateSystemNotification/" + systemNotification.NotificationId;
                SystemNotificationUserDTO systemNotificationUserDto = ApiClient.RestGet<SystemNotificationUserDTO>(url, contextDto.Token);
                response = request.CreateResponse(HttpStatusCode.OK, systemNotificationUserDto);
                return response;
            });
        }

        [Route("api/Account/UpdateAllSystemNotification")]
        [HttpPost]
        public HttpResponseMessage UpdateAllSystemNotification(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                string url = ConfigurationManager.AppSettings["NotificationApiUrl"];
                if (contextDto != null)
                {

                    url += "api/Notification/UpdateAllSystemNotification";
                    //List<SystemNotificationDTO> systemNotificationDto = ApiClient.RestGet<List<SystemNotificationDTO>>(url, contextDto.Token);
                    ApiClient.RestGetNonQuery(url, contextDto.Token);
                    response = request.CreateResponse(HttpStatusCode.OK);
                    return response;
                }

                return response;

            });
        }
        #endregion

        [Route("api/Functions/GetAuthorisedUserFunctions")]
        [HttpGet]
        public HttpResponseMessage GetAuthorisedUserFunctions(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                List<string> userFunctionDtos = _accountService.GetAuthorisedUserFunctions(contextDto.ApplicationId, contextDto.SubscriberId, contextDto.UserId, contextDto.PortCode);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, userFunctionDtos);
                return response;
            });
        }

        [AllowAnonymous]
        [Route("api/GetApplicationUrl/{applicationId}/{subscriberId}")]
        [HttpGet]
        public HttpResponseMessage GetApplicationUrl(HttpRequestMessage request, int applicationId, string subscriberId)
        {
            return GetHttpResponse(request, () =>
            {
                string applicationUrl = _accountService.GetApplicationUrl(applicationId, subscriberId);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, applicationUrl);
                return response;
            });
        }
    }
}