using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain
{
	public class Conversation
	{
		public string ConversationId { get; protected set; }
		public string FromUserId { get; protected set; }
		public string ToUserId { get; protected set; }
		public string UserName { get; protected set; }
		public int ApplicationId { get; protected set; }
		public string SubscriberId { get; protected set; }
		public string IsDeleted { get; protected set; }
		public string RecordStatus { get; protected set; }
		public string CreatedBy { get; protected set; }
		public DateTime CreatedDate { get; protected set; }
		public string ModifiedBy { get; protected set; }
		public DateTime? ModifiedDate { get; protected set; }
	}
}
