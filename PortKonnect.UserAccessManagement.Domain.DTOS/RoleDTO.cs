using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class RoleDTO
    {
        public string RoleId { get; set; }
        public string RoleCode { get; set; } 
        public int ApplicationId { get; set; }
        public string SubscriberId { get; set; }
        public string RoleName { get; set; }
        public string RecordStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public List<string> RoleFunctionCodeArray { get; set; }
        public List<string> PartnerTypeArray { get; set; }
        public List<string> PartnerTypeNameArray { get; set; }
        public List<RoleFunctionDTO> RoleFunctions { get; set; }
        public List<MenuModuleDTO> Modules { get; set; }       
        public virtual List<PartnerTypeRoleDTO> PartnerTypeRoles { get; set; }
        public string GUID { get; set; }
    }
}
