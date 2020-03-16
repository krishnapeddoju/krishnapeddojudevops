using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class RoleFunction
    {
        public string RoleId { get; protected set; }
        public string ApplicationEntityId { get; protected set; }
        public string FunctionCode { get; protected set; } //EntityId + Function Code are unique
        public string RecordStatus { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }
        public string IsDeleted { get; protected set; }
		public int ApplicationId { get; protected set; }
		public string SubscriberId { get; protected set; }

        public RoleFunction()
        {
        }

		public RoleFunction(string roleId, string appEntityId, string functionCode, string isDeleted, string recordStatus, string userId, int applicationId, string subscriberId)
        {
            this.RoleId = roleId;
            this.ApplicationEntityId = appEntityId;
            this.FunctionCode = functionCode;
            this.IsDeleted = isDeleted;
            this.RecordStatus = recordStatus;
            this.CreatedBy = userId;
            this.CreatedOn = DateTime.Now;
			this.ApplicationId = applicationId;
			this.SubscriberId = subscriberId;
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
