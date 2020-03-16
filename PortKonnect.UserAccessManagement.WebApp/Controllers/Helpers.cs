using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.WebApp
{
    public static class Helpers
    {
        public static ContextDTO GetContextFromCookie()
        {
            ContextDTO _userContextDto = new ContextDTO();
            HttpCookie authCookieusercontext = System.Web.HttpContext.Current.Request.Cookies["UserContext"];
            if (authCookieusercontext != null)
            {
                FormsAuthenticationTicket authTicketusercontext = FormsAuthentication.Decrypt(authCookieusercontext.Value);
                if (authTicketusercontext != null)
                {
                    _userContextDto = new JavaScriptSerializer().Deserialize<ContextDTO>(authTicketusercontext.Name);
                }
            }
            return _userContextDto;
        }

        public static void SetUserContextCookie(ContextDTO userContextdetails, int sessionTimeout, string cookieName)
        {

            string myObjectJson = new JavaScriptSerializer().Serialize(userContextdetails);
            var ticket = new FormsAuthenticationTicket(myObjectJson, false, sessionTimeout);

            string encrypted = FormsAuthentication.Encrypt(ticket);

            HttpContext.Current.Response.Cookies.Remove(cookieName);
            var cookie = new HttpCookie(cookieName, encrypted)
            {
                Expires = DateTime.Now.AddMinutes(sessionTimeout)
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
            HttpContext.Current.Response.Cookies.Set(cookie);
        }
        public static IHtmlString ToJson(HtmlHelper html, dynamic viewBagObject)
        {
            //TODO : Need to access those setting which required instead of accessing all Appsettings section from Web.config
            var json = JsonConvert.SerializeObject(
                viewBagObject,
                Formatting.Indented,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }
            );

            return html.Raw(json);
        }

    }
}