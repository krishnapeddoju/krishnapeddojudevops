using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;

namespace PortKonnect.UserAccessManagement.Web.OIDCConfigure
{
    public static class OpenIdConnectAuthenticationExtension
    {
        public static IAppBuilder UseOpenIdConnectAuthenticationCustomised(this IAppBuilder app, OpenIdConnectAuthenticationOptions openIdConnectOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }
            if (openIdConnectOptions == null)
            {
                throw new ArgumentNullException("openIdConnectOptions");
            }
            Type type = typeof(OpenIdConnectAuthenticationCustomised);
            object[] objArray = new object[] { app, openIdConnectOptions };
            return app.Use(type, objArray);
        }
    }
}