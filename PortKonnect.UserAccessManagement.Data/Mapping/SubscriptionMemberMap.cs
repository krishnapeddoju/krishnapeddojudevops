using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class SubscriptionMemberMap : EntityTypeConfiguration<SubscriptionMember>
    {
        public SubscriptionMemberMap()
        {
            HasKey(t => new { t.PartnerId, t.ApplicationId, t.MemberId });

            // Table & Column Mappings
            ToTable("SUBSCRIPTIONMEMBER");

            this.Property(t => t.PartnerId).HasColumnName("SUBSCRIBERID");
            this.Property(t => t.ApplicationId).HasColumnName("APPLICATIONID");
            this.Property(t => t.MemberId).HasColumnName("MEMBERID");
            this.Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
            this.Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            this.Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            this.Property(t => t.UpdatedBy).HasColumnName("UPDATEDBY");
            this.Property(t => t.UpdatedOn).HasColumnName("UPDATEDON");


            HasRequired(c => c.Partner)
                .WithMany(c => c.SubscriptionMembers)
                .HasForeignKey(d=>d.MemberId);


            HasRequired(c => c.Subscription)
                .WithMany(c => c.members)
                .HasForeignKey(d => new { d.PartnerId, d.ApplicationId});
        }
    }
}
