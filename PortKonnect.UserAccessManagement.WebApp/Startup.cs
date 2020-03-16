using System;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Web.Helpers;
using Microsoft.Owin.Security.Cookies;
using System.Security.Claims;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Threading.Tasks;
using log4net;
using Microsoft.IdentityModel.Protocols;
using IdentityModel.Client;
using PortKonnect.UserAccessManagement.Web.OIDCConfigure;
using PortKonnect.UserAccessManagement.WebApp;
using PortKonnect.UserAccessManagement.ApplicationServices;

[assembly: OwinStartup(typeof(PortKonnect.UserAccessManagement.UI.CargoStartup))]
namespace PortKonnect.UserAccessManagement.UI
{
    public class CargoStartup
    {
        private ILog _log = LogManager.GetLogger(typeof(CargoStartup));

        public void Configuration(IAppBuilder app)
        {
            var container = AutofacConfig.ConfigureContainer();
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
            string issuerAuthority = ConfigurationManager.AppSettings["identityURL"];
            string sessionExpiredUrl = ConfigurationManager.AppSettings["sessionExpired"].ToString();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthenticationCustomised(new OpenIdConnectAuthenticationOptions
            {
                Authority = issuerAuthority,               
                ResponseType = "code id_token token",
                UseTokenLifetime = false,
                SignInAsAuthenticationType = "Cookies",
                ClientId= "KPCL.PKCargo.UAM.WebApp",
                //Scope = "openid profile portkonnect.cargoops.scope offline_access",
                Scope = "openid profile portkonnect.cargoops.scope",
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
                    SecurityTokenValidated = async n =>
                    {
                       // string uri = n.Request.Uri.GetLeftPart(System.UriPartial.Authority);

                       // _log.Debug("SecurityTokenValidated for url : " + uri);
                       //// string clientId = (uri == eXpresswayMvcUrl) ? "KPCT.EXPWAY.OAUTH.WebApp" : "PIPAVAV.EXPWAY.OAUTH.WebApp";

                       // _log.Debug("request a refresh token uri setup started");
                       // // request a refresh token
                       // var tokenClientForRefreshToken = new TokenClient(issuerAuthority + "/connect/token", clientId, "Expressway");
                       // _log.Debug("request a refresh token uri setup Completed");
                       // _log.Debug("request for refresh token started");
                       // var refreshResponse = await
                       //     tokenClientForRefreshToken.RequestAuthorizationCodeAsync(n.ProtocolMessage.Code, uri);
                       // _log.Debug("request for refresh token completed");
                       // if (refreshResponse.IsError)
                       //     _log.Error("Refresh token response failed with description " + refreshResponse.ErrorDescription);
                       // var expirationDateAsRoundtripString = DateTime.SpecifyKind(DateTime.UtcNow.AddSeconds(refreshResponse.ExpiresIn), DateTimeKind.Utc).ToString("o");
                       // _log.Debug("refresh token : " + refreshResponse.RefreshToken + "and Expires at : " + expirationDateAsRoundtripString);
                        n.AuthenticationTicket.Identity.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));
                        n.AuthenticationTicket.Identity.AddClaim(new Claim("access_token", n.ProtocolMessage.AccessToken));
                        //n.AuthenticationTicket.Identity.AddClaim(new Claim("refresh_token", refreshResponse.RefreshToken));
                        //  n.AuthenticationTicket.Identity.AddClaim(new Claim("expires_at", expirationDateAsRoundtripString));
                    },
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
                    RedirectToIdentityProvider = async n =>
                    {
                        var uri = n.Request.Uri.GetLeftPart(System.UriPartial.Authority); //to do to get the return uri

                        if (uri + sessionExpiredUrl == n.Request.Uri.ToString())
                        {
                            uri += "/SessionExpired";
                        }
                        if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.LogoutRequest)
                        {
                            var idTokenHint = n.OwinContext.Authentication.User.FindFirst("id_token");

                            if (idTokenHint != null)
                            {
                                n.ProtocolMessage.IdTokenHint = idTokenHint.Value;
                                n.ProtocolMessage.PostLogoutRedirectUri = ConfigurationManager.AppSettings["eGateMVCUrl"];
                            }
                        }
                        else if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.AuthenticationRequest)
                        {

                            //TODO: Need to fill client id based on url 
                            //n.ProtocolMessage.ClientId = (uri == eXpresswayMvcUrl) ? "KPCT.EXPWAY.OAUTH.WebApp" : "PIPAVAV.EXPWAY.OAUTH.WebApp";
                            n.ProtocolMessage.RedirectUri = uri;
                            _log.Debug(n.ProtocolMessage.RequestType + " with client : " + n.ProtocolMessage.ClientId + " && redirect to url : " + n.ProtocolMessage.RedirectUri);
                        }
                    },
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

                    AuthenticationFailed = n =>
                    {
                        //Suppresses the Validation of nonce is null error
                        //redirects to redirect uri without error
                        _log.Error(n.Exception.Message);
                        if (n.Exception.Message.StartsWith("OICE_20004") || n.Exception.Message.Contains("IDX10311"))
                        {
                            n.SkipToNextMiddleware();
                            return Task.FromResult(0);
                        }
                        return Task.FromResult(0);
                    }
                }
            });
        }
    }
}

