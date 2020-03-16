using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class Application
    {
        public int ApplicationId { get; protected set; }
        public string ApplicationName { get; protected set; }
        public string ApplicationUrl { get; protected set; }

        public string RecordStatus { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }

        public Application(int applicationId, string applicationName, string applicationUrl, string recordStatus, string createdBy, DateTime createdOn, string updatedBy, DateTime updatedOn)
        {
            this.ApplicationId = applicationId;
            this.ApplicationName = applicationName;
            this.ApplicationUrl = applicationUrl;
            this.RecordStatus = recordStatus;
            this.CreatedBy = createdBy;
            this.CreatedOn = createdOn;
            this.UpdatedBy = updatedBy;
            this.UpdatedOn = updatedOn;

        }

        public Application()
        {
            
        }
    }
}
