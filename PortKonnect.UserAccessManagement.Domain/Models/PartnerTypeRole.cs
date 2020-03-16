using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class PartnerTypeRole
    {
        public string RoleId { get; protected set; }
        public string PartnerTypeId { get; protected set; }
        public string IsDeleted { get; protected set; }
		public int ApplicationId { get; protected set; }
		public string SubscriberId { get; protected set; }

        public PartnerTypeRole()
        {

        }

        public PartnerTypeRole(string roleId, string partnerTypeId, string isDeleted,int applicationId,string subscriberId)
        {
            this.RoleId = roleId;
            this.PartnerTypeId = partnerTypeId;
            this.IsDeleted = isDeleted;
			this.ApplicationId = applicationId;
			this.SubscriberId = subscriberId;
        }

        public void UpdateIsDeleted(string isDeleted)
        {
            IsDeleted = isDeleted;
        }
    }
}
