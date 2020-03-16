using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace PortKonnect.UserAccessManagement.UI
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
    }
}