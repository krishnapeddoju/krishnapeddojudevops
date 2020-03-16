using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class PartnerTypeRoleDTO
    {
        public string RoleId { get;  set; }
        public string PartnerTypeId { get;  set; }
        public string IsDeleted { get;  set; }
    }
}
