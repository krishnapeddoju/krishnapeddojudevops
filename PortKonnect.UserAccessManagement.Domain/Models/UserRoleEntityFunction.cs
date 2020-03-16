using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class UserRoleEntityFunction
    {
        public string UserId { get; protected set; }
        public string SubscriberId { get; protected set; }
        public int ApplicationId { get; protected set; }
        public string RoleId { get; protected set; }
        public string ApplicationEntityId { get; protected set; }
        public string FunctionCode { get; protected set; }

        public string IsDeleted { get; protected set; }
    }
}
