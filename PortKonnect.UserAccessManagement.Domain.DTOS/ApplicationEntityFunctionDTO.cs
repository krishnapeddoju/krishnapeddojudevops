using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class ApplicationEntityFunctionDTO
    {
        public string ApplicationEntityId { get;  set; }
        public string FunctionCode { get;  set; } //EntityId + Function Code are unique
        public string FunctionName { get;  set; }
        public string IsMenuItem { get;  set; }
        public string FunctionUrl { get;  set; }
        public string ApiUrl { get;  set; }
        public int Order { get;  set; }
        public string RecordStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
