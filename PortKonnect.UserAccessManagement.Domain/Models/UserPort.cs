using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class UserPort 
    {
        public string UserId { get; protected set; }
        public string PortCode { get; protected set; }
        public string IsDeleted { get; protected set; }
        public string RecordStatus { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }
        public UserPort()
        {
        }
        public UserPort(string userId, string portCode, string isDeleted, string recordStatus, string createdBy)
        {
            UserId = userId;
            PortCode = portCode;
            IsDeleted = isDeleted;
            RecordStatus = recordStatus;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;
        }
        public void UpdateIsDeleted(string isDeleted)
        {
            IsDeleted = isDeleted;
        }

        public void ChangeUpdatedByAndOn(string userId)
        {
            this.UpdatedBy = userId;
            this.UpdatedOn = DateTime.Now;
        }
    }
}
