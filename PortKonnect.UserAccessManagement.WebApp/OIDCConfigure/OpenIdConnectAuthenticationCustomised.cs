using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security.Infrastructure;
using Owin;

namespace PortKonnect.UserAccessManagement.Web.OIDCConfigure
{

    public class OpenIdConnectAuthenticationCustomised : OpenIdConnectAuthenticationMiddleware
    {
        private readonly ILogger _logger;
        
        public OpenIdConnectAuthenticationCustomised(Microsoft.Owin.OwinMiddleware next, IAppBuilder app, OpenIdConnectAuthenticationOptions options)
                : base(next, app, options)
        {
            _logger = app.CreateLogger<OpenIdConnectAuthenticationCustomised>();
        }

        protected override AuthenticationHandler<OpenIdConnectAuthenticationOptions> CreateHandler()
        {
            return new OpenIdConnectAuthenticationHandlerCustomised(_logger);
        }
    }

    public class OpenIdConnectAuthenticationHandlerCustomised : OpenIdConnectAuthenticationHandler
    {
        static readonly bool enableSSL = ConfigurationManager.AppSettings["EnableSSL"] == "true";
        public OpenIdConnectAuthenticationHandlerCustomised(ILogger logger)
            : base(logger) { }

        protected override void RememberNonce(OpenIdConnectMessage message, string nonce)
        {

            var oldNonces = Request.Cookies.Where(kvp => kvp.Key.StartsWith(OpenIdConnectAuthenticationDefaults.CookiePrefix + "nonce"));
            if (oldNonces.Any())
            {
                Microsoft.Owin.CookieOptions cookieOptions = new Microsoft.Owin.CookieOptions
                {
                    HttpOnly = !enableSSL,
                    Secure = Request.IsSecure
                };
                foreach (KeyValuePair<string, string> oldNonce in oldNonces)
                {
                    Response.Cookies.Delete(oldNonce.Key, cookieOptions);
                }
            }
            base.RememberNonce(message, nonce);
        }
    }
}