using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class PartnerPortMap : EntityTypeConfiguration<PartnerPort>
    {
        public PartnerPortMap()
        {
            HasKey(t => new { t.PartnerId, t.PortCode });


            // Table & Column Mappings
            ToTable("PARTNERPORT");

            this.Property(t => t.PartnerId).HasColumnName("PARTNERID");
            this.Property(t => t.PortCode).HasColumnName("PORTCODE");
            this.Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
            this.Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            this.Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            this.Property(t => t.UpdatedBy).HasColumnName("UPDATEDBY");
            this.Property(t => t.UpdatedOn).HasColumnName("UPDATEDON");

        }
    }
}
