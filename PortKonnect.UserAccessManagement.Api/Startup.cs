using System;
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using PortKonnect.UserAccessManagement.Api;
using IdentityServer3.AccessTokenValidation;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagement.Domain.Repositories;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.DataServcies;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;

[assembly: OwinStartup(typeof(Startup))]
namespace PortKonnect.UserAccessManagement.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            var container = AutofacConfig.ConfigureContainer();
            var dependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
            config.DependencyResolver = dependencyResolver;
            
            //GlobalConfiguration.Configuration.Filters.Add(new CustomExceptionFilterAttribute());
            
            //TODO: Need to check below global filters
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);

            app.UseIdentityServerBearerTokenAuthentication(
           new IdentityServerBearerTokenAuthenticationOptions
           {
               Authority = ConfigurationManager.AppSettings["TokenServiceURL"],
               RequiredScopes = new[] { "portkonnect.cargoops.scope", "portkonnect.expway.resscope" }
           });
            //ConfigureOAuth(app);

            SwaggerConfig.Register(config);
            WebApiConfig.Register(config);
            
            app.UseWebApi(config);

            ConfigureMessageQueueListeners();
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            int sessionTimeout = 0;
            string tokenIssuer = string.Empty;
            bool allowInsecureHttp = true;
            try
            {
                Int32.TryParse(ConfigurationManager.AppSettings["sessionTimeOut"].ToString(),out sessionTimeout);
                tokenIssuer = ConfigurationManager.AppSettings["UAMAPIUrl"].ToString();
                allowInsecureHttp = Convert.ToBoolean((ConfigurationManager.AppSettings["AllowInsecureHttp"].ToString()));
            }
            catch (Exception)
            {
                throw new Exception("Configuration is missing (sessionTimeOut/UAMAPIUrl)...");
            }

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = allowInsecureHttp,
                TokenEndpointPath = new PathString("/OAuth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(sessionTimeout),
                Provider = new PortKonnectAuthorizationProvider(),
                //TODO:  Need to move Issuer to a configuration file.
                AccessTokenFormat = new PortKonnectJwtFormat(tokenIssuer)
            };
            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);

            //INCLUDE THIS CODE IN ALL RESOURCE SERVERS.  FOR USER ACCESS MANAGEMENT. RESOURCE SERVER AND AUTHENTICATION SERVER ARE SAME.
            var issuer = tokenIssuer;
            var audience = ConfigurationManager.AppSettings["audience"];
            string[] arrayaudience = audience.Split(',');
            var secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["symmetricKeyAsBase64"]);//"IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw");

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = arrayaudience,

                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                    },
                   
                    Provider = new OAuthBearerAuthenticationProvider
                    {
                        OnValidateIdentity = context =>
                        {
                            context.Ticket.Identity.AddClaim(new Claim("newCustomClaim", "newValue"));
                            return Task.FromResult<object>(null);
                        }
                    },
                    

                });
            
        }

        public void ConfigureMessageQueueListeners()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<UserContext>().As<IUserContext>().InstancePerDependency();
            builder.RegisterType<PartnerRegistrationRepository>().As<IPartnerRegistrationRepository>().InstancePerDependency();
            builder.RegisterType<SubscriptionRepository>().As<ISubscriptionRepository>().InstancePerDependency();
            builder.RegisterType<CommonRepository>().As<ICommonRepository>().InstancePerDependency();
            builder.RegisterType<PartnerApplicationService>().As<IPartnerApplicationService>().InstancePerDependency();
            builder.RegisterType<PartnerRepository>().As<IPartnerRepository>().InstancePerDependency();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerDependency();
            builder.RegisterType<UserRoleRepository>().As<IUserRoleRepository>().InstancePerDependency();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerDependency();
            builder.RegisterType<NotificationDataService>().As<INotificationDataService>().InstancePerDependency();
            builder.RegisterType<UserApplicationService>().As<IUserApplicationService>().InstancePerDependency();

            var container = builder.Build();

            var userContext = container.Resolve<IUserContext>();
            var partnerRegistrationRepository = container.Resolve<IPartnerRegistrationRepository>();
            var subscriptionRepository = container.Resolve<ISubscriptionRepository>();
            var commonRepository = container.Resolve<ICommonRepository>();
            var partnerApplicationService = container.Resolve<IPartnerApplicationService>();
            var partnerRepository = container.Resolve<IPartnerRepository>();
            var userRepository = container.Resolve<IUserRepository>();
            var userRoleRepository = container.Resolve<IUserRoleRepository>();
            var UserApplicationService = container.Resolve<IUserApplicationService>();
            QueueListener.Setup(userContext, partnerRegistrationRepository, subscriptionRepository, commonRepository, partnerApplicationService, partnerRepository, userRepository, userRoleRepository, UserApplicationService);
        }
    }
}
