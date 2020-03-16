using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortKonnect.UserAccessManagement.Api
{
    public class Audience
    {
        
        public string ClientId { get; set; }

        
        public string Base64Secret { get; set; }

        
        public string Name { get; set; }
    }
}