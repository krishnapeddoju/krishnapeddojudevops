using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class PartnerTypeRoleMap : EntityTypeConfiguration<PartnerTypeRole>
    {
        public PartnerTypeRoleMap()
        {
            HasKey(t => new { t.RoleId, t.PartnerTypeId ,t.ApplicationId,t.SubscriberId});

            ToTable("PARTNERTYPEROLE");

            Property(t => t.RoleId).HasColumnName("ROLEID");
            Property(t => t.PartnerTypeId).HasColumnName("PARTNERTYPE");
            Property(t => t.IsDeleted).HasColumnName("ISDELETED");
			Property(t => t.ApplicationId).HasColumnName("APPLICATIONID");
			Property(t => t.SubscriberId).HasColumnName("SUBSCRIBERID");
        }
    }
}
