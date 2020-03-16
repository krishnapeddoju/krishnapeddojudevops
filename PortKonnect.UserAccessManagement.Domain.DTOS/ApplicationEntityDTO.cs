using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    //TODO:  Need to identify a good name for the entity
    public class ApplicationEntityDTO
    {
        public string ApplicationEntityId { get;  set; }
        public int ApplicationId { get;  set; } 
        public string EntityCode { get;  set; } 
        public string EntityName { get;  set; }
        public string Url { get;  set; }
        public string RecordStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ICollection<ApplicationEntityFunctionDTO> applicationEntityFunctions { get;  set; }
    }
}
