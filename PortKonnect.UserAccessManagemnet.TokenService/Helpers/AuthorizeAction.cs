using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace PortKonnect.UserAccessManagemnet.TokenService.Helpers
{
    public class AuthorizeAction
    {
        public async Task<List<string>> GetData()
        {
            string tokenServiceUrl = ConfigurationManager.AppSettings["TokenServiceURL"];
            string token = HttpContext.Current.Request.Headers["Authorization"];
            token = token.Replace("Bearer ", "");
            UserInfoClient userInfoClient = new UserInfoClient(
                      new Uri(tokenServiceUrl+"/connect/userinfo"),
                     token);
            List<string> permissions = new List<string>();

            if (token != null)
            {
                var userInfoResponse = await userInfoClient.GetAsync().ConfigureAwait(false);
                JObject userInfoObj = JObject.Parse(userInfoResponse.JsonObject.ToString());
                permissions = userInfoObj["Permissions"].ToObject<List<string>>();
                return permissions;
            }
            return permissions;

        }
    }
}