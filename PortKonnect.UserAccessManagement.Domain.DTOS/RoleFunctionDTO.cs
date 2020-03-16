using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class RoleFunctionDTO
    {
        public string RoleId { get;  set; }
        public string ApplicationEntityId { get;  set; }
		public int ApplicationId { get; set; }
		public string SubscriberId { get; set; }
        public string FunctionCode { get;  set; }
        public string IsDeleted { get; set; }
        public string RecordStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
