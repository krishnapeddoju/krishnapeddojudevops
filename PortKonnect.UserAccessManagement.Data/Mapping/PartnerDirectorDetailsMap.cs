using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserManagement.Data.Mapping
{
    public class PartnerDirectorDetailsMap : EntityTypeConfiguration<PartnerDirectorDetails>
    {
        public PartnerDirectorDetailsMap()
        {
            HasKey(t => t.PDirectorDetailsId);

            // Table & Column Mappings
            ToTable("PARTNERDIRECTORDETAILS");

            this.Property(t => t.PDirectorDetailsId).HasColumnName("PDIRECTORDETAILSID");
            this.Property(t => t.PDirectorName).HasColumnName("PDIRECTORNAME");
            this.Property(t => t.PDirectorPAN).HasColumnName("PDIRECTORPAN");
            this.Property(t => t.PDirectorAddress).HasColumnName("PDIRECTORADDRESS");

            this.Property(t => t.PDirectorMobile).HasColumnName("PDIRECTORMOBILE");
            this.Property(t => t.PDirectorTele).HasColumnName("PDIRECTORTELE");
            this.Property(t => t.PDirectorEmail).HasColumnName("PDIRECTOREMAIL");
            this.Property(t => t.PartnerRegistrationId).HasColumnName("PARTNERREGISTRATIONID");
            this.Property(t => t.PCountryCode).HasColumnName("COUNTRYCODE");
            this.Property(t => t.Type).HasColumnName("TYPE");
            this.Property(t => t.IsDeleted).HasColumnName("ISDELETED");
        }
    }
}
