using System;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class SubscriptionMember 
    {
        public string PartnerId { get; protected set; } //SubscriberId
        public int ApplicationId { get; protected set; }
        public string MemberId { get; protected set; }
        
        public string RecordStatus { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }
        public Partner Partner { get; protected set; }
        public Subscription Subscription { get; protected set; }

        public SubscriptionMember()
        {


        }

        public SubscriptionMember(string subscriberId, int applicationId, string memberId, string recordStatus, string createdBy, DateTime CreatedOn, string updatedBy, DateTime? updatedOn)
        {
            this.PartnerId = subscriberId;
            this.MemberId = memberId;
            this.ApplicationId = applicationId;
            this.RecordStatus = recordStatus;
            this.CreatedBy = createdBy;
            this.CreatedOn = CreatedOn;
            this.UpdatedBy = updatedBy;
            this.UpdatedOn = updatedOn;
            //TODO:Rest of fields to be assigned
        }
    }
}
