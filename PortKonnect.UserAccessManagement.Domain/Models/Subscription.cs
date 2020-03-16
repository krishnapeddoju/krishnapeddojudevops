using System;
using System.Collections.Generic;
using PortKonnect.UserAccessManagement.GlobalConstants;

namespace PortKonnect.UserAccessManagement.Domain
{
	public class Subscription
	{
		public string PartnerId { get; protected set; } //SubscriberId
		public int ApplicationId { get; protected set; }

		public string RecordStatus { get; protected set; }
		public string CreatedBy { get; protected set; }
		public DateTime CreatedOn { get; protected set; }
		public string UpdatedBy { get; protected set; }
		public DateTime? UpdatedOn { get; protected set; }
		public string FromAddress { get; protected set; }
		public string EmailPassword { get; protected set; }
		public string SMTPClientId { get; protected set; }
		public string SMSUID { get; protected set; }
		public string SMSPWD { get; protected set; }
		public string SenderId { get; protected set; }
		public string Service { get; protected set; }	
		public int SMTPPortNo { get; protected set; }
		public string WebsiteUrl { get; protected set; }
        public virtual ICollection<SubscriptionMember> members { get; protected set; }

		public Subscription()
		{


		}

		public Subscription(string subscriberId, int applicationId, string recordStatus, string createdBy, DateTime createdOn, string updatedBy, DateTime? updatedOn, int smtpPortNo, string websiteUrl)
		{
			this.PartnerId = subscriberId;
			this.ApplicationId = applicationId;
			this.RecordStatus = recordStatus;
			this.CreatedBy = createdBy;
			this.CreatedOn = createdOn;
			this.UpdatedBy = updatedBy;
			this.UpdatedOn = updatedOn;
		    SMTPPortNo = smtpPortNo;
            WebsiteUrl = websiteUrl;
            AddMember(subscriberId, createdBy);
		}
		public void AddMember(string participantId, string createdBy)
		{
			if (members == null)
			{
				members = new List<SubscriptionMember>();
			}
			members.Add(new SubscriptionMember(this.PartnerId, this.ApplicationId, participantId, UAMGlobalConstants.RecordStatus, createdBy, DateTime.Now, null, null));
		}
	}
}
