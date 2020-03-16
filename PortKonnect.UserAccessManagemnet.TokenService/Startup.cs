using System;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.Default;
using Owin;
using PortConnect.UserAccessManagement.TokenService.Services;
using PortKonnect.UserAccessManagemnet.TokenService.Config;
using PortKonnect.UserAccessManagemnet.TokenService.Services;
using Serilog;

namespace PortKonnect.UserAccessManagemnet.TokenService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            string tokenServerUrl = ConfigurationManager.AppSettings["TokenServiceURL"];
            string issuerUri = ConfigurationManager.AppSettings["IssuerUri"];
            string issuerSiteName = ConfigurationManager.AppSettings["IssuerSiteName"];
            bool enableSSL = ConfigurationManager.AppSettings["EnableSSL"] == "false";
            app.Map("/identity", idsrvApp =>
                 {
                     var corsPolicyService = new DefaultCorsPolicyService()
                     {
                         AllowAll = true
                     };
                     var defaultViewServiceOptions = new DefaultViewServiceOptions();
                     defaultViewServiceOptions.CacheViews = false;
                     // Mentioned physical path for custom directory as Serverpath will not be considered
                     // defaultViewServiceOptions.CustomViewDirectory = @"D:\e-Xpressway_Multi_Tenant\e-Xpressway_MultiTenant_UAMDev\PortKonnect.UserAccessManagemnet.TokenService\templates";

                     var idServerServiceFactory = new IdentityServerServiceFactory()
                          .UseInMemoryScopes(Scopes.Get());
                     idServerServiceFactory.CorsPolicyService = new
                         Registration<ICorsPolicyService>(corsPolicyService);
                     var clientservice = new ClientService();
                     idServerServiceFactory.ClientStore = new Registration<IClientStore>(resolver => clientservice);
                     idServerServiceFactory.ConfigureDefaultViewService(defaultViewServiceOptions);
                     var customuserservice = new CustomUserService();
                     idServerServiceFactory.UserService = new Registration<IUserService>(resolver => customuserservice);

                     var options = new IdentityServerOptions
                     {
                         RequireSsl = false,
                         Factory = idServerServiceFactory,
                         SiteName = issuerSiteName,
                         SigningCertificate = LoadCertificate(),
                         IssuerUri = issuerUri,
                         PublicOrigin = tokenServerUrl,


                         AuthenticationOptions = new AuthenticationOptions()
                         {
                             EnablePostSignOutAutoRedirect = true,
                             PostSignOutAutoRedirectDelay = 3,
                             EnableSignOutPrompt = false,
                             //EnableLocalLogin =true,
                             RememberLastUsername = true,
                             CookieOptions = new CookieOptions(),
                             LoginPageLinks = new LoginPageLink[] {
                             new LoginPageLink{
                                Text = "Forgot Password",
                                Href = "~/useraccount/ResetPassword",
                                Type="resetPassword"
                            }
                             // ,
                             //    new LoginPageLink{
                             //    Text = "New Partner Registration",
                             //    Href = "~/useraccount/PartnerRegistration",
                             //    Type="PartnerRegistration"
                             //},new LoginPageLink{
                             //    Text = "Update Partner Registration",
                             //    Href = "~/useraccount/UpdatePartnerRegistration",
                             //    Type="UpdatePartnerRegistration"
                             //}
                             },
                         },
                         CspOptions = new CspOptions()
                         {
                             Enabled = false

                         }
                     };

                     idsrvApp.UseIdentityServer(options);
                 });

            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Error()
                        .WriteTo.Debug(outputTemplate: "[{Level}] ({Name:l}){NewLine} {Message}{NewLine}{Exception}")
                        .CreateLogger();
        }


        X509Certificate2 LoadCertificate()
        {
            string certificateName = ConfigurationManager.AppSettings["certificateName"];
            string certificatePassword = ConfigurationManager.AppSettings["certificatePassword"];
            return new X509Certificate2(
                string.Format(@"{0}\certificates\" + certificateName,
                AppDomain.CurrentDomain.BaseDirectory), certificatePassword);
        }
    }
}
