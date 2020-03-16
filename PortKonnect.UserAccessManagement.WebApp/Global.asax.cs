using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using log4net.Config;
using System.Web.Mvc;
using System;
using PortKonnect.eGate.Web;

namespace PortKonnect.UserAccessManagement.WebApp
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleTable.EnableOptimizations = true;
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            XmlConfigurator.Configure();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // required in order to allow the NWebSec session security package to work when using OIDC and cookies for authentication.   
        }
    }

}