using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer3.Core;
using IdentityServer3.Core.Extensions;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.Default;
using PortKonnect.Common.Services;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.GlobalConstants;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagemnet.TokenService.Common;
using System.Web;
using System;
using PortKonnect.UserAccessManagement.DataServcies.ServiceContracts;
using PortKonnect.UserAccessManagement.DataServcies;

namespace PortConnect.UserAccessManagement.TokenService.Services
{
    public class CustomUserService : UserServiceBase
    {
        private IAccountService _accountService;
        private string signin ="";
        private  IRoleDataService _roleDataService;
        public override Task AuthenticateLocalAsync(LocalAuthenticationContext context)
        {
            ClientId client = new ClientId(context.SignInMessage.ClientId);
            // string loginURL=context.SignInMessage.ReturnUrl.ToString().GetLeftPart(System.UriPartial.Authority)
            // List<Claim> claimsList = new List<Claim>();
          
           // string url = HttpUtility.UrlDecode(context.SignInMessage.ReturnUrl);
           //  url = url.Substring(url.IndexOf("redirect_uri") + 13, url.IndexOf("post_logout_redirect_uri") - url.IndexOf("redirect_uri") - 1 - 13);

           IUserContext userContext = new UserContext();
            _accountService = new AccountService(userContext, new AccountRepository(userContext));

    
            string user = _accountService.AuthenticateUser(client.ApplicationId, context.UserName,
                PasswordDataService.Encrypt(context.Password, true), client.SubscriberId);

            List<Claim> claimsList = new List<Claim>();

            if (user == UAMGlobalConstants.Success)
            {
                var url = HttpContext.Current.Request.Url.AbsoluteUri;
                Uri myUri = new Uri(url);
                signin = HttpUtility.ParseQueryString(myUri.Query).Get("signin");           
                     
                ContextDTO userDetails = _accountService.GetUserDetails(client.ApplicationId, client.SubscriberId,
              context.UserName);

                context.AuthenticateResult = new AuthenticateResult(
                    userDetails.UserName,
                    context.UserName, claimsList);

                return Task.FromResult(0);
            }
                context.AuthenticateResult = new AuthenticateResult(user);
                return Task.FromResult(0);
        }

        public override Task GetProfileDataAsync( ProfileDataRequestContext context)
        {
            List<string> userRoles = new List<string>();
            ContextDTO contextDto = new ContextDTO();
            IUserContext userContext1 = new UserContext();
            ClientId client = new ClientId(context.Client.ClientId);

            _accountService = new AccountService(userContext1, new AccountRepository(userContext1));

            _roleDataService = new RoleDataService(userContext1, new CommonRepository(userContext1));


            ContextDTO user = _accountService.GetUserDetails(client.ApplicationId, client.SubscriberId,
                context.Subject.GetSubjectId());



            if (!string.IsNullOrEmpty(user.UserRoles) && client.ApplicationId == 6)
            {
                userRoles = user.UserRoles.Split(',').ToList<string>();               
            }

          



            contextDto.ApplicationId = user.ApplicationId;
            contextDto.SubscriberId = user.SubscriberId;
            List<RoleDTO> roles = _roleDataService.GetRoles(contextDto);


           

            var claims = new List<Claim>();
                //{
                    //new Claim(Constants.ClaimTypes.Subject, user.UserId)
                //};

            if (!string.IsNullOrEmpty(user.UserRoles) && roles.Count() >0 && client.ApplicationId == 6)
            {
                List<string> roleTypes = roles.Where(x => userRoles.Any(n => n == x.RoleId)).Select(x => x.RoleCode).ToList();
                foreach (var item in roleTypes)
                {
                    claims.Add(new Claim(Constants.ClaimTypes.Role, item));
                }
            }
            else
            {
                claims.Add(new Claim("UserRoles", user.UserRoles));
            }

            if (userRoles != null && client.ApplicationId == 6)
            {
                List<AuthorizedFunctionDTO> userfunctions =
                    _accountService.GetAuthorisedUserFunctionsByRoles(client.ApplicationId, client.SubscriberId,
                        user.UserId, user.PortCode, userRoles);
                if (userfunctions != null)
                {
                    claims.AddRange(userfunctions.Select(item => new Claim("Permissions", item.FunctionCode)));
                }
            }
           
            claims.Add(new Claim("ApplicationId", user.ApplicationId.ToString()));
            claims.Add(new Claim("SubscriberId", client.SubscriberId));
            claims.Add(new Claim("PortCode", user.PortCode));
            claims.Add(new Claim("MemberId", user.MemberId));
            claims.Add(new Claim("MemberCode", user.MemberCode));
            claims.Add(new Claim("MemberType", user.MemberType));
            claims.Add(new Claim("UserId", user.UserId));
            claims.Add(new Claim("IsFirstTimeLogin", user.IsFirstTimeLogin));
            claims.Add(new Claim("UserName", user.UserName));
            claims.Add(new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName));

            claims.Add(new Claim("UserRoles", user.UserRoles));

            claims.Add(new Claim("IsFirstTimeLogin", user.IsFirstTimeLogin));
            claims.Add(new Claim("PartnerTypes", user.PartnerTypes));
            claims.Add(new Claim("signin", signin));



            //  context.AllClaimsRequested = true;
            if (!context.AllClaimsRequested)
            {
                claims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
            }
            context.IssuedClaims = claims;
            return Task.FromResult(0);
        }

        //public override Task PreAuthenticateAsync(PreAuthenticationContext context)
        //{
        //    return base.PreAuthenticateAsync(context);
        //}

        //public override Task PostAuthenticateAsync(PostAuthenticationContext context) {

        //    return base.PostAuthenticateAsync(context);
        //}

    }
}