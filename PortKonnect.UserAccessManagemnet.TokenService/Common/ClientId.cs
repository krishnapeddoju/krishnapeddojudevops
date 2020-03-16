using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortKonnect.UserAccessManagemnet.TokenService.Common
{
    public class ClientId
    {
        private string clientId;

        public string SubscriberId
        {
            get
            {
                return clientId.Split('.')[0];
            }
        }

        public int ApplicationId
        {
            get
            {
                var firstFragment = clientId.Split('.')[1];
                switch (firstFragment)
                {
                    case "PKCargo":
                        return 6;

                    case "Kwixee":
                        return 6;

                    default:
                        break;
                }

                // eGate
                return 2;
            }
        }
        public string LoggedApplication
        {
            get
            {
                return clientId.Split('.')[2] + clientId.Split('.')[3];
            }
        }

        public ClientId(string client_id)
        {
            this.clientId = client_id;
        }
    }
}