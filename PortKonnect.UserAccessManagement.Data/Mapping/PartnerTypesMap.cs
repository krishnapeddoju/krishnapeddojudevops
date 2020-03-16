using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;


namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class PartnerTypesMap : EntityTypeConfiguration<PartnerTypes>
    {
        public PartnerTypesMap()
        {
            HasKey(t => new { t.PartnerId, t.partnerTypeName, t.SubscriberId });

            ToTable("PARTNERTYPE");

            Property(t => t.PartnerId).HasColumnName("PARTNERID");
            Property(t => t.partnerTypeName).HasColumnName("PARTNERTYPE");
            Property(t => t.IsDelete).HasColumnName("ISDELETED");
            Property(t => t.SubscriberId).HasColumnName("SUBSCRIBERID");
        }
    }
}
