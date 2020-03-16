using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class ApplicationDTO
    {
        public int ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationUrl { get;  set; }

        public string RecordStatus { get;  set; }
        public string CreatedBy { get;  set; }
        public DateTime CreatedOn { get;  set; }
        public string UpdatedBy { get;  set; }
        public DateTime? UpdatedOn { get;  set; }
    }
}
