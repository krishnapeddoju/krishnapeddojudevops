using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer3.Core.Models;
using PortKonnect.UserAccessManagement.GlobalConstants;

namespace PortKonnect.UserAccessManagemnet.TokenService.Config
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
             {

                new Client
                {
                    Enabled=true,
                    ClientId = "KPCL.PKCargo.Export.WebApp",
                    ClientName = "Cargo",
                    Flow = Flows.Implicit,
                    AllowedScopes = new List<string> { "openid", "profile","roles", "portkonnect.cargoops.scope" },
                    RequireConsent = false,
                     AccessTokenLifetime=32400,

                    RedirectUris = new List<string>
                    {
                       UAMGlobalConstants.CargoAngular + "#/auth-callback#",
                       //"http://localhost:4300/silent-refresh.html"

                    }, PostLogoutRedirectUris = new List<string>()
                    {
                        UAMGlobalConstants.CargoAngular+"index.html"
                    }

                },
                 new Client
                {
                    Enabled=true,
                    ClientId = "KPCL.PKCargo.Gate.WebApp",
                    ClientName = "Cargo",
                    Flow = Flows.Implicit,
                    AllowedScopes = new List<string> { "openid", "profile","roles", "portkonnect.cargoops.scope" },
                    RequireConsent = false,
                     AccessTokenLifetime=32400,

                    RedirectUris = new List<string>
                    {
                       UAMGlobalConstants.GateWebAppAngular + "#/auth-callback#",
                       //"http://localhost:4411/silent-refresh.html"

                    }, PostLogoutRedirectUris = new List<string>()
                    {
                        UAMGlobalConstants.GateWebAppAngular+"index.html"
                    }

                },
                  new Client
                {
                    Enabled=true,
                    ClientId = "KPCL.PKCargo.BagManagement.WebApp",
                    ClientName = "Cargo",
                    Flow = Flows.Implicit,
                    AllowAccessToAllScopes = true,
                    AllowRememberConsent =true,
                    RequireConsent = false,
                     AccessTokenLifetime=32400,
                    RedirectUris = new List<string>
                    {
                            UAMGlobalConstants.BagManagementAngular +   "#/auth-callback#",

                     }
                    , PostLogoutRedirectUris = new List<string>()
                    {
                        UAMGlobalConstants.BagManagementAngular + "index.html"
                    }

               },
                   new Client
                {
                    Enabled=true,
                    ClientId = "KPCL.PKCargo.MasterData.WebApp",
                    ClientName = "Cargo",
                    Flow = Flows.Implicit,
                    AllowAccessToAllScopes = true,
                     AccessTokenLifetime=32400,
                    AllowRememberConsent =true,
                    RequireConsent = false,
                    RedirectUris = new List<string>
                    {
                        UAMGlobalConstants.MasterDataAngular +   "#/auth-callback#",
                    }
                    , PostLogoutRedirectUris = new List<string>()
                    {
                        UAMGlobalConstants.MasterDataAngular + "index.html"
                    }

               },
                    new Client
                {
                    Enabled=true,
                    ClientId = "KPCL.PKCargo.Billing.WebApp",
                    ClientName = "Cargo",
                    Flow = Flows.Implicit,
                    AllowAccessToAllScopes = true,
                     AccessTokenLifetime=32400,
                    AllowRememberConsent =true,
                    RequireConsent = false,
                    RedirectUris = new List<string>
                    {
                        UAMGlobalConstants.BillingAngular +   "#/auth-callback#",
                    }
                    , PostLogoutRedirectUris = new List<string>()
                    {
                        UAMGlobalConstants.BillingAngular + "index.html"
                    }

               },
                   new Client
                {
                    Enabled=true,
                    ClientId = "KPCL.PKCargo.Import.WebApp",
                    ClientName = "Cargo",
                    Flow = Flows.Implicit,
                    AllowAccessToAllScopes = true,
                    AllowRememberConsent =true,
                    RequireConsent = false,
                     AccessTokenLifetime=32400,
                    RedirectUris = new List<string>
                    {
                            UAMGlobalConstants.ImportWebAppAngular +  "#/auth-callback#",

                     }
                    , PostLogoutRedirectUris = new List<string>()
                    {
                        UAMGlobalConstants.ImportWebAppAngular + "index.html"
                    }

               },
                       new Client
                {
                    Enabled=true,
                    ClientId = "KPCL.PKCargo.Rail.WebApp",
                    ClientName = "Cargo",
                    Flow = Flows.Implicit,
                    AllowAccessToAllScopes = true,
                    AllowRememberConsent =true,
                    RequireConsent = false,
                     AccessTokenLifetime=32400,
                    RedirectUris = new List<string>
                    {
                            UAMGlobalConstants.RailWebAppAngular +  "#/auth-callback#",

                     }
                    , PostLogoutRedirectUris = new List<string>()
                    {
                        UAMGlobalConstants.RailWebAppAngular + "index.html"
                    }

               },
                     new Client
                {
                    Enabled=true,
                    ClientId = "KPCL.PKCargo.Jetty.WebApp",
                    ClientName = "Cargo",
                    Flow = Flows.Implicit,
                    AllowAccessToAllScopes = true,
                    AllowRememberConsent =true,
                    RequireConsent = false,
                     AccessTokenLifetime=32400,
                    RedirectUris = new List<string>
                    {
                            UAMGlobalConstants.JettyWebAppAngular +  "#/auth-callback#",

                     }
                    , PostLogoutRedirectUris = new List<string>()
                    {
                        UAMGlobalConstants.JettyWebAppAngular + "index.html"
                    }

               },
                     new Client
                {
                    Enabled=true,
                    ClientId = "KPCL.PKCargo.ETS.WebApp",
                    ClientName = "Cargo",
                    Flow = Flows.Implicit,
                    AllowAccessToAllScopes = true,
                    AllowRememberConsent =true,
                    RequireConsent = false,
                     AccessTokenLifetime=32400,
                    RedirectUris = new List<string>
                    {
                            UAMGlobalConstants.ETSWebAppAngular +  "#/auth-callback#",

                     }
                    , PostLogoutRedirectUris = new List<string>()
                    {
                        UAMGlobalConstants.ETSWebAppAngular + "index.html"
                    }

               }
               ,new Client
                {
                   Enabled=true,
                   ClientId = "PIPAVAV.EXPWAY.OAUTH.WebApp",
                   ClientName = "ExpresWay",
                   Flow = Flows.Hybrid,
                   AllowAccessToAllScopes = true,
                   AllowRememberConsent =true,
                   AccessTokenType=AccessTokenType.Jwt,
                   IdentityTokenLifetime=1800,
                   AccessTokenLifetime =1800,
                   AllowedScopes = new List<string> { "openid", "profile", "portkonnect.expway.resscope", "TaskServiceScope", "ContainerServiceScope"},
                   AlwaysSendClientClaims=true,
                   RequireConsent = false,
                   RedirectUris = new List<string>
                   {
                         "http://192.168.2.190:60675","http://192.168.2.190:61685","http://192.168.0.238:7767"
                   }
                   ,PostLogoutRedirectUris = new List<string>
                   {
                         "http://192.168.2.190:60675","http://192.168.2.190:61685","http://192.168.0.238:7767"
                   },
               },
                new Client
                {
                   ClientId = "EXPWAY.EXPWAY.OAUTH.ContainerService",
                   ClientName = "ExpresWay Container Service",
                   Flow = Flows.ClientCredentials,


                   ClientSecrets=new List<Secret>() {
                       new Secret(("ExpresWayContainerService").Sha256())
                   },
                   AllowAccessToAllScopes = true,
                   AllowRememberConsent =true,
                   AllowClientCredentialsOnly=true,
                   //AccessTokenType=AccessTokenType.Jwt,
                   //IdentityTokenLifetime=1800,
                   AccessTokenLifetime =18000,
                   AllowedScopes = new List<string> {"ContainerServiceScope"},
                   AlwaysSendClientClaims=true
               },
                new Client
                {
                   ClientId = "EXPWAY.EXPWAY.OAUTH.TaskService",
                   ClientName = "ExpresWay Container Service",
                   Flow = Flows.ClientCredentials,


                   ClientSecrets=new List<Secret>() {
                       new Secret(("ExpresWayTaskService").Sha256())
                   },
                   AllowAccessToAllScopes = true,
                   AllowRememberConsent =true,
                   AllowClientCredentialsOnly=true,
                   //AccessTokenType=AccessTokenType.Jwt,
                   //IdentityTokenLifetime=1800,
                   AccessTokenLifetime =18000,
                   AllowedScopes = new List<string> {"TaskServiceScope"},
                   AlwaysSendClientClaims=true
               },
                new Client
                {
                   ClientId = "EXPWAY.EXPWAY.OAUTH.NotfSCHDService",
                   ClientName = "ExpresWay Notf SCHD Service",
                   Flow = Flows.ClientCredentials,


                   ClientSecrets=new List<Secret>() {
                       new Secret(("ExpresWayNotificationSCHDService").Sha256())
                   },
                   AllowAccessToAllScopes = true,
                   AllowRememberConsent =true,
                   AllowClientCredentialsOnly=true,
                   //AccessTokenType=AccessTokenType.Jwt,
                   //IdentityTokenLifetime=1800,
                   AccessTokenLifetime =18000,
                   AllowedScopes = new List<string> {"portkonnect.expway.NotfSCHDServiceScope"},
                   AlwaysSendClientClaims=true
               },new Client
                {
                   ClientId = "EXPWAY.EXPWAY.OAUTH.NotificationService",
                   ClientName = "ExpresWay Notf SCHD Service",
                   Flow = Flows.ClientCredentials,


                   ClientSecrets=new List<Secret>() {
                       new Secret(("ExpresWayNotificationService").Sha256())
                   },
                   AllowAccessToAllScopes = true,
                   AllowRememberConsent =true,
                   AllowClientCredentialsOnly=true,
                   //AccessTokenType=AccessTokenType.Jwt,
                   //IdentityTokenLifetime=1800,
                   AccessTokenLifetime =18000,
                   AllowedScopes = new List<string> {"portkonnect.expway.resscope"},
                   AlwaysSendClientClaims=true
               },
                new Client
                {
                   ClientId = "EXPWAY.EXPWAY.OAUTH.NavisService",
                   ClientName = "ExpresWay Navis Service",
                   Flow = Flows.ClientCredentials,


                   ClientSecrets=new List<Secret>() {
                       new Secret(("ExpresWayNavisService").Sha256())
                   },
                   AllowAccessToAllScopes = true,
                   AllowRememberConsent =true,
                   AllowClientCredentialsOnly=true,
                   //AccessTokenType=AccessTokenType.Jwt,
                   //IdentityTokenLifetime=1800,
                   AccessTokenLifetime =18000,
                   AllowedScopes = new List<string> {"portkonnect.expway.resscope"},
                   AlwaysSendClientClaims=true,
                   Claims = new List<Claim>{new Claim("SubscriberId", "KPCT")}
        },
                new Client
                {
                   Enabled=true,
                   ClientId = "KPCL.PKCargo.IPMS.Web",
                   ClientName = "Marine WebApp",
                   Flow = Flows.Hybrid,
                   AllowAccessToAllScopes = true,
                   AllowRememberConsent =true,
                   AccessTokenType=AccessTokenType.Jwt,
                   IdentityTokenLifetime=1800,
                   AccessTokenLifetime =1800,
                   AllowedScopes = new List<string> { "openid", "profile"},
                   AlwaysSendClientClaims=true,
                   RequireConsent = false,
                   RedirectUris = new List<string>
                   {
                         "http://192.168.0.139:7778", "http://localhost:7778", "http://192.168.0.243:7778"
        }
                   ,PostLogoutRedirectUris = new List<string>
                   {
                         "http://192.168.0.139:7778", "http://localhost:7778", "http://192.168.0.243:7778"
                   },
               },
                 new Client
                 {
                     Enabled=true,
                     ClientId = "KPCL.PKCargo.Kwixee.WebApp",
                     ClientName = "Kwixee",
                     Flow = Flows.Implicit,
                     AllowedScopes = new List<string> { "openid", "profile","roles", "portkonnect.cargoops.scope" },
                     RequireConsent = false,
                     AccessTokenLifetime=32400,

                     RedirectUris = new List<string>
                     {
                         UAMGlobalConstants.KwixeeCFS + "#/auth-callback#",
                         //"http://localhost:4300/silent-refresh.html"

                     }, PostLogoutRedirectUris = new List<string>()
                     {
                         UAMGlobalConstants.KwixeeCFS+"index.html"
                     }

                 },
             };
        }
    }
}
