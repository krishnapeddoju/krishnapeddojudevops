using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;
using JWT;
using Thinktecture.IdentityModel.Tokens;

namespace PortKonnect.UserAccessManagement.Api
{
    public class PortKonnectJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private const string AudiencePropertyKey = "subscription";

        private readonly string _issuer = string.Empty;

        public PortKonnectJwtFormat(string issuer)
        {
            _issuer = issuer;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            string subscription = data.Properties.Dictionary.ContainsKey(AudiencePropertyKey) ? data.Properties.Dictionary[AudiencePropertyKey] : null;

            if (string.IsNullOrWhiteSpace(subscription))
            {
                throw new InvalidOperationException("AuthenticationTicket.Properties does not include audience");
            }

            //AudiencesStore.FindAudience(audienceId);

            //TODO:  Need to et the secret key from database or from config file. It is better we configure it based on subscription.
            string symmetricKeyAsBase64 = ConfigurationManager.AppSettings["symmetricKeyAsBase64"];// "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw";
  
            var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);

            var signingKey = new HmacSigningCredentials(keyByteArray);

            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;

            var token = new JwtSecurityToken(_issuer, subscription, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingKey);

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token);

            return jwt;
        }
        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }

    }
}