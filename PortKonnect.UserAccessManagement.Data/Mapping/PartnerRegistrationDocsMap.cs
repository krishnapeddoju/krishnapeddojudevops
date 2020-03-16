using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserManagement.Data.Mapping
{
    public class PartnerRegistrationDocsMap : EntityTypeConfiguration<PartnerRegistrationDocs>
    {

        public PartnerRegistrationDocsMap()
        {
            HasKey(t => t.PDocumentId);

            // Table & Column Mappings
            ToTable("PARTNERREGISTRATIONDOCS");

            this.Property(t => t.PDocumentId).HasColumnName("PDOCUMENTID");
            this.Property(t => t.PFileName).HasColumnName("PFILENAME");
            this.Property(t => t.PDocumentType).HasColumnName("PDOCUMENTTYPE");
            this.Property(t => t.PValidDate).HasColumnName("PVALIDDATE");
            this.Property(t => t.POriginalName).HasColumnName("PORIGINALNAME");
            this.Property(t => t.PartnerRegistrationId).HasColumnName("PARTNERREGISTRATIONID");
            this.Property(t => t.IsDeleted).HasColumnName("ISDELETED");

        }
    }
}
