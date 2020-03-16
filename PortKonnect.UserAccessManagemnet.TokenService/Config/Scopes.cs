using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace PortKonnect.UserAccessManagemnet.TokenService.Config
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {

            return new List<Scope>
            {
                 StandardScopes.OpenId,
                 StandardScopes.ProfileAlwaysInclude,
                 StandardScopes.OfflineAccess,
                 new Scope
                 {
                     Name = "portkonnect.cargoops.scope",
                     DisplayName = "PortKonnect Cargo Ops Scope",
                     Description = "Allow the application to manage cargo ops.",
                     Type = ScopeType.Resource ,
                    Claims = new List<ScopeClaim>()
                     {
                        new ScopeClaim("ApplicationId",true),
                        new ScopeClaim("SubscriberId", true),
                        new ScopeClaim("PortCode", true),
                        new ScopeClaim("MemberId", true),
                        new ScopeClaim("MemberCode", true),
                        new ScopeClaim("MemberType", true),
                        new ScopeClaim("UserId",true),
                        new ScopeClaim("IsFirstTimeLogin",true),
                        new ScopeClaim("PartnerTypes",true),
                        new ScopeClaim("UserName",true)
                  
                    }
                 },
                 new Scope
                 {
                     Name = "roles",
                     DisplayName = "PortKonnect Cargo Ops Scope",
                     Description = "Allow the application to manage cargo ops.",
                     Type = ScopeType.Identity,
                     Claims = new List<ScopeClaim>()
                     {
                            new ScopeClaim("role",true),
                            new ScopeClaim("Permissions", false),
                            new ScopeClaim("PortCode", true),
                            new ScopeClaim("SubscriberId", true),
                            new ScopeClaim("UserName", true),
                            new ScopeClaim("IsFirstTimeLogin",true),
                            new ScopeClaim("UserId", true)
                     }
                 },


                 //new Scope
                 //{
                 //    Name = "roles",
                 //    DisplayName = "PortKonnect Cargo Ops Scope",
                 //    Description = "Allow the application to manage cargo ops.",
                 //    Type = ScopeType.Identity,
                 //    Claims = new List<ScopeClaim>()
                 //    {
                 //           new ScopeClaim("role",true),
                 //           new ScopeClaim("Permissions", false),
                 //           new ScopeClaim("PortCode", true),
                 //           new ScopeClaim("SubscriberId", true),
                 //           new ScopeClaim("UserName", true),
                 //       new ScopeClaim("Name",true)

                 //    }
                 //},
                 //new Scope
                 //{
                 //    Name = "portkonnect.expway.scope",
                 //    DisplayName = "PortKonnect e-Xpressway Scope",
                 //    Description = "Allow the application to manage cargo ops.",
                 //    Type = ScopeType.Identity ,
                 //    IncludeAllClaimsForUser=false,
                 //    Emphasize=true,
                 //   Claims = new List<ScopeClaim>
                 //    {
                 //        new ScopeClaim("applicationid",false),
                 //         new ScopeClaim("subscriberid", false),
                 //        new ScopeClaim("portcode", false),
                 //        new ScopeClaim("memberid", false),
                 //        new ScopeClaim("membercode", false),
                 //       new ScopeClaim("membertype", false),
                 //      new ScopeClaim("userid",false),
                 //      new ScopeClaim("isfirsttimelogin",false),
                 //      new ScopeClaim("partnertypes",false),
                 //       new ScopeClaim("username",false),
                 //       new ScopeClaim("name",false)
                 //   }
                 //},
                 new Scope
                 {
                     Name = "portkonnect.expway.resscope",
                     DisplayName = "PortKonnect e-Xpressway Scope",
                     Description = "Allow the application to manage cargo ops.",
                     Type = ScopeType.Resource ,
                     //IncludeAllClaimsForUser=true,
                     //Emphasize=true,
                    Claims = new List<ScopeClaim>
                     {
                        new ScopeClaim("applicationid"),
                        new ScopeClaim("subscriberid"),
                        new ScopeClaim("portcode"),
                        new ScopeClaim("memberid"),
                        new ScopeClaim("membercode"),
                        new ScopeClaim("membertype"),
                        new ScopeClaim("userid"),
                        new ScopeClaim("isfirsttimelogin"),
                        new ScopeClaim("partnertypes"),
                        new ScopeClaim("userroles"),
                        new ScopeClaim("username",true),
                        new ScopeClaim("name",true)
                    }
                 },
                 new Scope
                 {
                     Name = "ContainerServiceScope",
                     DisplayName = "PortKonnect e-Xpressway Scope",
                     Description = "Allow the application to manage container api.",
                     Type = ScopeType.Resource,
                    IncludeAllClaimsForUser=true,
                      Claims = new List<ScopeClaim>
                     {
                        new ScopeClaim("SubscriberId", true)
                     }
                 },
                 new Scope
                 {
                     Name = "TaskServiceScope",
                     DisplayName = "e-Xpressway Task Scope",
                     Description = "Allow the application to manage Task Api.",
                     Type = ScopeType.Resource,
                     IncludeAllClaimsForUser=true,
                      Claims = new List<ScopeClaim>
                     {
                        new ScopeClaim("SubscriberId", true)
                     } }
                 ,
                 new Scope
                 {
                     Name = "portkonnect.expway.NavisServiceScope",
                     DisplayName = "e-Xpressway Navis Scope",
                     Description = "Allow the application to manage Task Api.",
                     Type = ScopeType.Resource,
                     IncludeAllClaimsForUser=true,
                      Claims = new List<ScopeClaim>
                     {
                        new ScopeClaim("SubscriberId", true)
                     }
                 },
                 //TODO: Need to check below scope is required for notification scheduler service
                 new Scope
                 {
                     Name = "portkonnect.expway.NotfSCHDServiceScope",
                     DisplayName = "e-Xpressway Notf SCHD Scope",
                     Description = "Allow the application to manage Notification Api.",
                     Type = ScopeType.Resource,
                   IncludeAllClaimsForUser=true,
                      Claims = new List<ScopeClaim>
                     {
                        new ScopeClaim("SubscriberId", true)
                     }
                 }


            };
        }
    }
}
