using IdentityServer3.Core.Services;
using IdentityServer3.Core.Models;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;
using System.Linq;

namespace PortKonnect.UserAccessManagemnet.TokenService.Services
{
    public class ClientService : IClientStore
    {
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            FileStream fs = new FileStream(Path.Combine(HttpContext.Current.Server.MapPath("~/Config"), "ClientsList.json"),
                                      FileMode.Open,
                                      FileAccess.Read, FileShare.ReadWrite);
            var jsonText = (new StreamReader(fs)).ReadToEnd();
            List<Client> clientList = JsonConvert.DeserializeObject<List<Client>>(jsonText);
            return Task.FromResult(clientList.FirstOrDefault(c => c.ClientId.Equals(clientId)));
        }
    }
}