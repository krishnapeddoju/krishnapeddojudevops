using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class ApplicationMap : EntityTypeConfiguration<Application>
    {
        public ApplicationMap()
        {
            HasKey(t => t.ApplicationId);

            // Table & Column Mappings
            ToTable("APPLICATION");

            this.Property(t => t.ApplicationId).HasColumnName("APPLICATIONID");
            this.Property(t => t.ApplicationName).HasColumnName("APPLICATIONNAME");
            this.Property(t => t.ApplicationUrl).HasColumnName("APPLICATIONURL");
            this.Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
            this.Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            this.Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            this.Property(t => t.UpdatedBy).HasColumnName("UPDATEDBY");
            this.Property(t => t.UpdatedOn).HasColumnName("UPDATEDON");

        }   
    }
}
