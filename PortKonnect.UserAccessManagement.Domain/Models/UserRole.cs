using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class UserRole 
    {
        public string UserId { get; protected set; }
        public string RoleId { get; protected set; }
        public string IsDeleted { get; protected set; }

        public string SubscriberId { get; protected set; }
        public int ApplicationId { get; protected set; }
        public string RecordStatus { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }

        public UserRole()
        {
        }

        public UserRole(string userId, string roleId, string subscriberId, int applicationId, string isDeleted, string recordStatus, string createdBy)
        {
            UserId = userId;
            RoleId = roleId;
            SubscriberId = subscriberId;
            ApplicationId = applicationId;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;
            IsDeleted = isDeleted;
            RecordStatus = recordStatus;
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
