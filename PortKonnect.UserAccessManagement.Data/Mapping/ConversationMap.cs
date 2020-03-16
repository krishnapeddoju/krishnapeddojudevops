using PortKonnect.UserAccessManagement.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
	public class ConversationMap : EntityTypeConfiguration<Conversation>
	{
		public ConversationMap()
		{
			HasKey(t => new { t.ConversationId });
			ToTable("CONVERSATION");
			this.Property(t => t.ConversationId).HasColumnName("CONVERSATIONID");
			this.Property(t => t.FromUserId).HasColumnName("FROMUSERID");
			this.Property(t => t.ToUserId).HasColumnName("TOUSERID");
			this.Property(t => t.UserName).HasColumnName("USERNAME");
			this.Property(t => t.ApplicationId).HasColumnName("APPLICATIONID");
			this.Property(t => t.SubscriberId).HasColumnName("SUBSCRIBERID");
			this.Property(t => t.IsDeleted).HasColumnName("ISDELETED");
			this.Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
			this.Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
			this.Property(t => t.CreatedDate).HasColumnName("CREATEDDATE");
			this.Property(t => t.ModifiedBy).HasColumnName("MODIFIEDBY");
			this.Property(t => t.ModifiedDate).HasColumnName("MODIFIEDDATE");

		}
	}
}
