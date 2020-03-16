using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class PartnerPort 
    {
        public string PartnerId { get; protected set; }
        public string PortCode { get; protected set; }
        
        public string RecordStatus { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }

        public PartnerPort()
        {


        }

        public PartnerPort(string partnerId, string portCode, string recordStatus, string createdBy, DateTime CreatedOn, string updatedBy, DateTime? updatedOn)
        {
            this.PartnerId = partnerId;
            this.PortCode = portCode;
            this.RecordStatus = recordStatus;
            this.CreatedBy = createdBy;
            this.CreatedOn = CreatedOn;
            this.UpdatedBy = updatedBy;
            this.UpdatedOn = updatedOn;
        }

    }
}
