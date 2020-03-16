using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Owin;
using PortKonnect.UserAccessManagement.ApplicationServices;
using Autofac.Integration.WebApi;
using Autofac.Integration.WebApi.Owin;
using PortKonnect.Common.Exceptions;
using PortKonnect.Common.Services;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.GlobalConstants;

namespace PortKonnect.UserAccessManagement.Api
{
    public class PortKonnectAuthorizationProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            string symmetricKeyAsBase64 = string.Empty;


            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                context.SetError("invalid_clientId", "client_Id is not set");
                return Task.FromResult<object>(null);
            }

            //TODO: Need to check if ClientId exists.

            //var audience = new Audience
            //{
            //    ClientId = "099153c2625149bc8ecb3e85e03f0022",
            //    Base64Secret = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw",
            //    Name = "ResourceServer.Api 1"
            //};

            //if (audience == null)
            //{
            //    context.SetError("invalid_clientId", string.Format("Invalid client_id '{0}'", context.ClientId));
            //    return Task.FromResult<object>(null);
            //}

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //Dummy check here, you need to do your DB checks against membership system http://bit.ly/SPAAuthCode

            string clientAndAppId = context.ClientId;
            string subscriberId = context.ClientId.Split('-')[0];
            int appId = Convert.ToInt16(context.ClientId.Split('-')[1]);


            var autofacLifeTimeScope = OwinContextExtensions.GetAutofacLifetimeScope(context.OwinContext);
            var accountService = autofacLifeTimeScope.Resolve<IAccountService>();

            bool isAuthenticated = false;
            string message = string.Empty;

            try
            {
                isAuthenticated = accountService.AuthenticateUser(appId, context.UserName, PasswordDataService.Encrypt(context.Password, true), subscriberId) == UAMGlobalConstants.Success;
            }
            catch (Exception ex)
            {
                context.SetError(BusinessExceptions.InvalidCredentials, ex.Message);
                //return;
                return Task.FromResult<object>(message);
            }


            if (!isAuthenticated)
            {
                context.SetError("invalid_grant", message);
                //return;
                return Task.FromResult<object>(message);
            }

            ContextDTO payLoad = accountService.GetUserDetails(appId, subscriberId, context.UserName);

            var identity = new ClaimsIdentity("JWT");

            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));
            foreach (var role in payLoad.UserRoles.Split(',').ToArray())
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            identity.AddClaim(new Claim("ApplicationId", payLoad.ApplicationId.ToString()));
            identity.AddClaim(new Claim("SubscriberId", payLoad.SubscriberId.ToString()));
            identity.AddClaim(new Claim("MemberId", payLoad.MemberId));
            identity.AddClaim(new Claim("MemberType", payLoad.MemberType));
            identity.AddClaim(new Claim("PartnerTypes", payLoad.PartnerTypes));
            identity.AddClaim(new Claim("MemberCode", payLoad.MemberCode));
            identity.AddClaim(new Claim("UserId", payLoad.UserId));
            identity.AddClaim(new Claim("UserName", payLoad.UserName));
            identity.AddClaim(new Claim("PortCode", payLoad.PortCode));
            identity.AddClaim(new Claim("IsFirstTimeLogin", payLoad.IsFirstTimeLogin));
            identity.AddClaim(new Claim("UserRoles", payLoad.UserRoles));
            identity.AddClaim(new Claim("Tokenvalidfrom", DateTimeOffset.UtcNow.UtcDateTime.ToString(CultureInfo.CurrentUICulture)));
            identity.AddClaim(new Claim("Tokenvalidto", DateTimeOffset.UtcNow.AddMinutes(1).UtcDateTime.ToString(CultureInfo.CurrentUICulture)));
            if (!string.IsNullOrEmpty(payLoad.PartnerLogo))
            {
                identity.AddClaim(new Claim("PartnerLogo", payLoad.PartnerLogo));
            }


            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                         "subscription", (context.ClientId == null) ? string.Empty : context.ClientId
                    },
                    { 
                         "membercode", payLoad.MemberCode
                    }
                });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);


            return Task.FromResult<object>(null);
        }

        //TODO : Need to check this method how to use
        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:subscription"];
            var currentClient = context.ClientId;

            // enforce client binding of refresh token
            if (originalClient != currentClient)
            {
                context.Rejected();
                return;
            }

            // chance to change authentication ticket for refresh token requests
            var newId = new ClaimsIdentity(context.Ticket.Identity);
            newId.AddClaim(new Claim("newClaim", "refreshToken"));

            var newTicket = new AuthenticationTicket(newId, context.Ticket.Properties);
            context.Validated(newTicket);
        }
    }
}