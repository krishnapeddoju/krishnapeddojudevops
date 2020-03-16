using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
	public class SubscriptionMap : EntityTypeConfiguration<Subscription>
	{
		public SubscriptionMap()
		{
			HasKey(t => new { t.PartnerId, t.ApplicationId });

			// Table & Column Mappings
			ToTable("SUBSCRIPTION");

			this.Property(t => t.PartnerId).HasColumnName("SUBSCRIBERID");
			this.Property(t => t.ApplicationId).HasColumnName("APPLICATIONID");
			this.Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
			this.Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
			this.Property(t => t.CreatedOn).HasColumnName("CREATEDON");
			this.Property(t => t.UpdatedBy).HasColumnName("UPDATEDBY");
			this.Property(t => t.UpdatedOn).HasColumnName("UPDATEDON");
			this.Property(t => t.FromAddress).HasColumnName("FROMADDRESS");
			this.Property(t => t.EmailPassword).HasColumnName("EMAILPASSWORD");
			this.Property(t => t.SMTPClientId).HasColumnName("SMTPCLIENTID");
			this.Property(t => t.SMSUID).HasColumnName("SMSUID");
			this.Property(t => t.SMSPWD).HasColumnName("SMSPWD");
			this.Property(t => t.SenderId).HasColumnName("SENDERID");
			this.Property(t => t.Service).HasColumnName("SERVICE");
            this.Property(t => t.SMTPPortNo).HasColumnName("SMTPPORTNO");
            this.Property(t => t.WebsiteUrl).HasColumnName("WEBSITEURL");
        }
    }
}
