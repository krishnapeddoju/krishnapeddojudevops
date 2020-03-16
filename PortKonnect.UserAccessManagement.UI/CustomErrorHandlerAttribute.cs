using System;
using System.Configuration;
using System.Web.Mvc;
using log4net;
using log4net.Config;

namespace PortKonnect.UserAccessManagement.UI
{
    public class CustomErrorHandlerAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            XmlConfigurator.Configure();
            var logger = LogManager.GetLogger(filterContext.GetType());
            logger.Error("An unhandled error occurred @ " + DateTime.Now.ToString(), filterContext.Exception);

            if (ConfigurationManager.AppSettings["hostingurl"] != null)
            {
                string redirecturl = ConfigurationManager.AppSettings["hostingurl"];
				
                filterContext.Result = new RedirectResult(redirecturl + "Error", false);
            }
            //filterContext.Result = new JsonResult
            //{
            //    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
            //    ContentType = "application/json",
            //    Data = new
            //    {
            //        Error = "An Error Occured",
            //        ExceptionMsg = filterContext.Exception.ToString()
            //    }
            //};

        }
    }
}
