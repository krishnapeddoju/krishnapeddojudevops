using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortKonnect.UserAccessManagement.Api
{
    public class AppSettingsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult == null)
                return;

            viewResult.ViewBag.AppSettings = ConfigurationManager.AppSettings.AllKeys.ToDictionary(key => key, key => ConfigurationManager.AppSettings[key]);

            base.OnActionExecuted(filterContext);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["token"] == null || ctx.User.Identity.IsAuthenticated == false)
            {
                if ((filterContext.ActionDescriptor).ActionName.ToLower() != "login" &&
                    (filterContext.ActionDescriptor).ActionName.ToLower() != "logout" && (filterContext.ActionDescriptor).ActionName.ToLower() != "sessionexpired" && (filterContext.ActionDescriptor).ActionName.ToLower() != "partnerregistration")
                {
                    //filterContext.Result = new RedirectResult("SessionExpired");
                    //return;
                    filterContext.Result = new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        ContentType = "application/json",
                        Data = new
                        {
                            Error = "An Error Occured",
                            ExceptionMsg = filterContext.HttpContext.Error.Message.ToString()
                        }
                    };
                }
            }
            base.OnActionExecuting(filterContext);
        }

    }
}