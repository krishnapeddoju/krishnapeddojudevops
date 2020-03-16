using System;
using System.Configuration;
using PortKonnect.Common.Services;
using System.Web;
using System.Web.Mvc;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;
using PortKonnect.UserAccessManagement.Domain.Repositories;
using PortKonnect.UserAccessManagement.DataServcies;
using IdentityServer3.Core.Extensions;
using PortKonnect.UserAccessManagemnet.TokenService.Common;
using PortKonnect.UserAccessManagement.GlobalConstants;
using System.Collections.Generic;

namespace PortKonnect.UserAccessManagemnet.TokenService.Controllers
{
    public class CustomModel
    {
        public string signin { get; set; } 
        public UserDTO userDTO { get; set; }
    }

    public class UserAccountController : Controller
    {
      
        [HttpGet]
        public ActionResult Index(string signin)
        {

            return View(new UserDTO());
        }


        [HttpPost]
        public ActionResult Index(string signin, UserDTO userDTO)
        {

            IAccountService _accountService = new AccountService();
            IUserContext userContext = new UserContext();
                   ContextDTO contextDto=new ContextDTO();

            IUserRepository userRepository = new UserRepository(userContext);
            IRoleRepository roleRepository = new RoleRepository(userContext);
            ICommonRepository commonRepository = new CommonRepository(userContext);
            INotificationDataService notificationDataService = new NotificationDataService();
            IPartnerRepository partnerRepository = new PartnerRepository(userContext);
            IUserApplicationService _userApplicationService = new UserApplicationService(userContext,userRepository,roleRepository,commonRepository, notificationDataService, partnerRepository);

            _userApplicationService.AddUser(userDTO, contextDto);
           

            return Redirect("~/identity/" + "Login?signin=" + signin);

                
            
        }
        [HttpGet]
        public ActionResult ResetPassword(string signin)
        {
            ViewBag.signin = signin;

            ViewBag.isEmailSuccess = false;
            
            return View(new UserDTO());
        }

      
        [HttpGet]
        public ActionResult BackToLogin()
        {

            return Redirect(ConfigurationManager.AppSettings["uamWebApp"]);
        }

        [HttpGet]
        public ActionResult BackToResetPassword(string signin)
        {

            return RedirectToAction("ResetPassword", new { signin = signin });
        }
        [HttpPost]
        public ActionResult ResetPassword(string signin,UserDTO userDTO)
        {
            string errorMessage = "";
            bool isEmailSuccess = false;

            IUserContext userContext = new UserContext();

            try
            {

                var signInMessage = System.Web.HttpContext.Current.Request.GetOwinContext().Environment.GetSignInMessage(signin);
                if (signInMessage.ClientId != null)
                {
                    ClientId client = new ClientId(signInMessage.ClientId);
                    
                    string url = ConfigurationManager.AppSettings["uamapiUrl"];

                    url += "api/Account/TokenServieResetPassword/" + client.ApplicationId+"/"+client.SubscriberId+"/"+userDTO.UserName+"/"+signin+"/"+client.LoggedApplication;

                    string status = ApiClient.RestGet<string>(url);
                   
                    if (status == UAMGlobalConstants.Success)
                    {
                        isEmailSuccess = true;
                    }else
                    {
                        errorMessage = status;
                        isEmailSuccess = false;
                    }
                }
                else
                {
                    errorMessage = "Client Id is  null";
                    isEmailSuccess = false;
                }

            }
            catch(Exception ex)
            {
                isEmailSuccess = false;
                ViewBag.errorMsg = ex.Message;
                errorMessage= ex.Message;
            }

            if (isEmailSuccess)
            {
                ViewBag.isEmailSuccess = true;
            }
            else
            {
                ViewBag.isEmailSuccess = false;
            }
            return RedirectToAction("EmailSent", new { signin = signin, status = isEmailSuccess, errorMessage = errorMessage });
           
        }
        [AllowAnonymous]
        public ActionResult ChangePassword(string LogTransId)
        {           

            UserDTO user = checkUserDetails(LogTransId);
            if (user != null)
            {
                ViewBag.signin = null;
                ViewBag.UserName = user.UserName;
                ViewBag.PassWord = user.Password;
                ViewBag.LogTransId = LogTransId;
                ViewBag.UAMApi = ConfigurationManager.AppSettings["uamapiUrl"];
                ViewBag.RedirectApplicationUrl = ConfigurationManager.AppSettings["MarineUri"];
                return View("ForgotPassword");
            }
            else
            {
                return RedirectToAction("LinkExpired");

            }
        }


        [AllowAnonymous]
        public ActionResult ForgotPassword(string LogTransId,string signin)
        {
            var signInMessage = System.Web.HttpContext.Current.Request.GetOwinContext().Environment.GetSignInMessage(signin);
            if (signInMessage?.ClientId != null)
            {
                ClientId client = new ClientId(signInMessage.ClientId);
                //ViewBag.RedirectApplicationUrl = ApiClient.RestGet<string>(ConfigurationManager.AppSettings["uamapiUrl"] + "api/GetApplicationUrl/" + client.ApplicationId + "/" + client.SubscriberId);
                ViewBag.RedirectApplicationUrl = ConfigurationManager.AppSettings["TokenServiceURL"] + "/identity/login?signin=" + signin;
            }
            
            UserDTO user = checkUserDetails(LogTransId);
                if (signInMessage!=null && user != null)
                {
                    ViewBag.UserName = user.UserName;
                    ViewBag.PassWord = user.Password;
                    ViewBag.LogTransId = LogTransId;
                    ViewBag.signin = signin;
                    ViewBag.UAMApi = ConfigurationManager.AppSettings["uamapiUrl"];
                    return View("ForgotPassword");
                }
            else
            {
                signin = null;
                return RedirectToAction("LinkExpired", new { signin });

            }
        }

        [AllowAnonymous]
        public ActionResult PartnerRegistration(string LogTransId, string signin, string loggedApplication)
        {
            List<string> ApplUrls = new List<string>();

            var signInMessage = System.Web.HttpContext.Current.Request.GetOwinContext().Environment.GetSignInMessage(signin);
            string url = string.Empty;
            if (signInMessage.ReturnUrl != null)
            {
                 url = HttpUtility.UrlDecode(signInMessage.ReturnUrl);
                 url = url.Substring(url.LastIndexOf("redirect_uri") + 13, url.Length - url.LastIndexOf("redirect_uri") - 13);
            }
            return Redirect(url+"/PartnerRegistration");
        }

        [AllowAnonymous]
        public ActionResult UpdatePartnerRegistration(string LogTransId, string signin, string loggedApplication)
        {
            List<string> ApplUrls = new List<string>();

            var signInMessage = System.Web.HttpContext.Current.Request.GetOwinContext().Environment.GetSignInMessage(signin);
            string url = string.Empty;
            if (signInMessage.ReturnUrl != null)
            {
                url = HttpUtility.UrlDecode(signInMessage.ReturnUrl);
                url = url.Substring(url.LastIndexOf("redirect_uri") + 13, url.Length - url.LastIndexOf("redirect_uri") - 13);
            }
            return Redirect(url + "/PartnerRegistrationEdit");
        }

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
        
        [HttpGet]
        public ActionResult SessionExpired(string signin)
        {
            ViewBag.signin = signin;

            var signInMessage = System.Web.HttpContext.Current.Request.GetOwinContext().Environment.GetSignInMessage(signin);
            if (signInMessage.ClientId != null)
            {
                ClientId client = new ClientId(signInMessage.ClientId);
                ViewBag.RedirectApplicationUrl = ApiClient.RestGet<string>(ConfigurationManager.AppSettings["uamapiUrl"] + "api/GetApplicationUrl/" + client.ApplicationId + "/" + client.SubscriberId);
            }
         
            return View("SessionExpired");
        }

        [HttpGet]
        public ActionResult LinkExpired(string signin)
        {
            ViewBag.signin = signin;
            if(signin != null)
            {
                var signInMessage = System.Web.HttpContext.Current.Request.GetOwinContext().Environment.GetSignInMessage(signin);
                if (signInMessage != null && signInMessage.ClientId != null)
                {
                    ClientId client = new ClientId(signInMessage.ClientId);
                    ViewBag.RedirectApplicationUrl = ApiClient.RestGet<string>(ConfigurationManager.AppSettings["uamapiUrl"] + "api/GetApplicationUrl/" + client.ApplicationId + "/" + client.SubscriberId);
                }
            }
           
            return View("LinkExpired");
        }

        [HttpGet]
        public ActionResult EmailSent(string signin, bool status, string errorMessage)
        {
            ViewBag.signin = signin;
            ViewBag.errorMessage = errorMessage;
            ViewBag.status = status;

            return View("EmailSent");
        }
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");                
        }
        public ActionResult LocalLogout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }
    }
}
