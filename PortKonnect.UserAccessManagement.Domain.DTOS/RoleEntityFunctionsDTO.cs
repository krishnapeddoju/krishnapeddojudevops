using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class RoleEntityFunctionsDTO
    {
        public string RoleId { get; set; }
        public string AppEntityId { get; set; }
        public List<string> Rolefunctions { get; set; }
    }
}
