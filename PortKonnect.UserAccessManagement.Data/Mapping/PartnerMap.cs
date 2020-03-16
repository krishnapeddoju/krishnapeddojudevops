using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class PartnerMap : EntityTypeConfiguration<Partner>
    {
        public PartnerMap()
        {
            HasKey(t => t.PartnerId);

            // Table & Column Mappings
            ToTable("PARTNER");

            this.Property(t => t.PartnerId).HasColumnName("PARTNERID");
            this.Property(t => t.PartnerCode).HasColumnName("PARTNERCODE");
            this.Property(t => t.PartnerName).HasColumnName("PARTNERNAME");
            this.Property(t => t.PartnerType).HasColumnName("PARTNERTYPE");
            this.Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
            this.Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            this.Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            this.Property(t => t.UpdatedBy).HasColumnName("UPDATEDBY");
            this.Property(t => t.UpdatedOn).HasColumnName("UPDATEDON");

        }
    }
}
