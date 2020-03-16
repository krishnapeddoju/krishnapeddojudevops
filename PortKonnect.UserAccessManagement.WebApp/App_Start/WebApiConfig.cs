using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using log4net.Config;

namespace PortKonnect.UserAccessManagement.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            if (config != null)
            {
                // Attribute routing - Web API routes
                config.MapHttpAttributeRoutes();

                // Convention-based routing -- Web API configuration and services
                config.Routes.MapHttpRoute("DefaultApiWithstatus", "Api/{controller}/{action}/{status}", new { status = RouteParameter.Optional });
                config.Routes.MapHttpRoute("DefaultApiWithId", "Api/{controller}/{action}/{id}", new { id = RouteParameter.Optional }, new { id = @"\d+" });
                config.Routes.MapHttpRoute("DefaultApiWithAction", "Api/{controller}/{action}");
                config.Routes.MapHttpRoute("DefaultApiGet", "Api/{controller}", new { action = "Get" });
                config.Routes.MapHttpRoute("DefaultApiPut", "Api/{controller}", new { action = "Put" });
                config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}/{id}", new { id = RouteParameter.Optional });

                var json = config.Formatters.JsonFormatter;
                json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
                config.Formatters.Remove(config.Formatters.XmlFormatter);
            }
        }
    }
}