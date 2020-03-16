using System.Configuration;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PortKonnect.Common.Domain.Model;
using PortKonnect.Common.Exceptions;
using PortKonnect.Common.Services;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using System;

namespace PortKonnect.UserAccessManagement.UI
{
    [Authorize]
    public class AccountController : PortKonnectBaseController
    {

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            if (!string.IsNullOrEmpty(returnUrl) && returnUrl != null)
            {
                if (returnUrl.ToLower().Contains("logout"))
                    returnUrl = null;
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(new UserDTO() { ReturnUrl = returnUrl });
        }

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("Login")]
        //public JsonResult Login(LoginDTO logindetail)
        //{
        //    string egateApiBaseAddress = ConfigurationManager.AppSettings["UAMAPIUrl"];

        //    logindetail.ReturnUrl = (string.IsNullOrEmpty(logindetail.ReturnUrl)
        //        ? ConfigurationManager.AppSettings["returnUrl"]
        //        : logindetail.ReturnUrl);

        //    string token = string.Empty;

        //    string tokenUri = ConfigurationManager.AppSettings["tokenUri"];

        //    string ldata = "grant_type=password&username=" + logindetail.UserName + "&password=" + logindetail.Password + "&client_id=" + ConfigurationManager.AppSettings["accessKey"];

        //    JWTToken response = ApiClient.RestPost<JWTToken, string>(egateApiBaseAddress + tokenUri, ldata, ApiClient.FormURLEncodedConfiguration());

        //    if (response != null)
        //    {
        //        token = response.access_token;

        //        var identity = new ClaimsIdentity(new[]
        //        {
        //            new Claim(ClaimTypes.Name, logindetail.UserName)
        //        },
        //            DefaultAuthenticationTypes.ApplicationCookie);

        //        var ctx = Request.GetOwinContext();
        //        var authManager = ctx.Authentication;

        //        authManager.SignIn(identity);

        //        //TODO: A: Need to a own Session management here.  database driven.
        //        Session["token"] = token;
        //        ContextDto = GetContextFromCookie();
        //        return Json(new { success = true, token = ContextDto.Token, redirect = logindetail.ReturnUrl, IsFirstTimeLogin = ContextDto.IsFirstTimeLogin, message = string.Empty });
        //    }
        //    else
        //    {
        //        //TODO:Need return actual error message for not generating JWTToken and return that error message
        //        string usamApiUrl = ConfigurationManager.AppSettings["UserManagementLoginURL"];
        //        int appId = Convert.ToInt16(ConfigurationManager.AppSettings["accessKey"].Split('-')[1]);

        //        var msg = ApiClient.RestGet<string>(usamApiUrl + "api/GetUnauthorizedUserMessages/" + appId + "/" + logindetail.UserName + "/" + logindetail.Password);
        //         return Json(new { success = false, token = string.Empty, redirect = logindetail.ReturnUrl, IsFirstTimeLogin = "N", message = (string.IsNullOrEmpty(msg) ? BusinessExceptions.InvalidCredentials : msg) });
        //    }
        //}

        [HttpGet]
        [Route("logout")]
        public ActionResult Logout()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Session.Abandon();
            Session.Clear();

            Request.GetOwinContext().Authentication.SignOut();
            if (HttpContext.Request.Cookies[".AspNet.ApplicationCookie"] != null)
            {
                HttpContext.Response.Cookies.Remove(".AspNet.ApplicationCookie");
            }
            return Redirect("/Account/Login");
        }

        [Route("ChangePassword")]
        public ActionResult ChangePassword()
        {
            Session["BackURL"] = string.Empty;
            ViewBag.IsFirstTimeLogin = "N";
            return View("ChangePassword");
        }

        [Route("ChangePasswordbyModule/{ModuleName?}")]
        public ActionResult ChangePasswordbyModule(string ModuleName)
        {
            // ViewBag.BackURL = BackURL;
            Session["BackURL"] = ModuleName;
            return View("ChangePassword");
        }
        [Route("ChangePasswordAccount/{isFirstTimeLogin?}")]
        public ActionResult ChangePasswordAccount()
        {
            Session["BackURL"] = string.Empty;
            ViewBag.IsFirstTimeLogin = "Y";
            return View("ChangePassword");
        }

        [Route("ChangePasswrd/{isFirstTimeLogin?}/{ModuleName?}")]
        public ActionResult ChangePasswordAccount(string ModuleName)
        {
            Session["BackURL"] = string.Empty;

            Session["BackURL"] = ModuleName;
            ViewBag.IsFirstTimeLogin = "Y";
            return View("ChangePassword");
        }

        [Route("Account/ChangePassword/{isFirstTimeLogin?}")]
        public ActionResult ChangePassword(string IsFirstTimeLogin)
        {
            Session["BackURL"] = string.Empty;
            ViewBag.IsFirstTimeLogin = IsFirstTimeLogin;
            return View("ChangePassword");
        }

        [Route("Account/ForgotPassword/{LogTransId}")]
        [AllowAnonymous]
        public ActionResult ForgotPassword(string LogTransId)
        {
            Session["BackURL"] = string.Empty;
            UserDTO user = checkUserDetails(LogTransId);
            if (user != null)
            {
                ViewBag.UserName = user.UserName;
                ViewBag.PassWord = user.Password;
                ViewBag.LogTransId = LogTransId;
                return View("ForgotPassword");
            }
            else
                return View("LinkExpired");
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

        [Route("SessionExpired")]
        [AllowAnonymous]
        public ActionResult SessionExpired()
        {
            return View("SessionExpired");
        }


        [Route("Error")]
        public ActionResult Error()
        {
            return View("Error");
        }
    }
}
