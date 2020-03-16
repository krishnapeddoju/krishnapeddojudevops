using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class Role
    {
        public string RoleId { get; protected set; } //GUID
        public string RoleCode { get; protected set; }
        public int ApplicationId { get; protected set; }
        public string SubscriberId { get; protected set; }
        public string RoleName { get; protected set; }
        public string RecordStatus { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }
        public virtual List<RoleFunction> roleFunctions { get; protected set; }
        public virtual List<PartnerTypeRole> PartnerTypeRoles { get; protected set; }

        public Role()
        {
        }

        public Role(string roleId, int appId, string subscriberId, string roleName, string roleCode, string recordStatus, string createdBy)
        {
            this.RoleId = roleId;
            this.ApplicationId = appId;
            this.SubscriberId = subscriberId;
            this.RoleName = roleName;
            this.RoleCode = roleCode;
            this.RecordStatus = recordStatus;
            this.CreatedBy = createdBy;
            this.CreatedOn = DateTime.Now;
            this.roleFunctions = new List<RoleFunction>();
            this.PartnerTypeRoles=new List<PartnerTypeRole>();
        }

        public void UpdateRole(string roleName, string roleCode)
        {
            this.RoleName = roleName;
            this.RoleCode = roleCode;
        }

        public void AddRoleFunction(string applicationEntityId, string functionCode, string isDeleted, string recordStatus, string userId,int applicationId,string subscriberId)
        {
			roleFunctions.Add(new RoleFunction(this.RoleId, applicationEntityId, functionCode, isDeleted, recordStatus, userId, applicationId, subscriberId));
        }

        public void RemoveRoleFunction(RoleFunction roleFunction)
        {
            roleFunctions.Remove(roleFunction);
        }

        public void AddPartnerTypeRole(string partnerTypeId, string isDeleted,int applicationId,string subscriberId)
        {
            PartnerTypeRoles.Add(new PartnerTypeRole(this.RoleId, partnerTypeId, isDeleted,applicationId,subscriberId));
        }

        public void RemovePartnerType(PartnerTypeRole partnerTypeRole)
        {
            PartnerTypeRoles.Remove(partnerTypeRole);
        }

        public void ChangeUpdatedByAndOn(string userId)
        {
            this.UpdatedBy = userId;
            this.UpdatedOn = DateTime.Now;
        }

		
    }
}
