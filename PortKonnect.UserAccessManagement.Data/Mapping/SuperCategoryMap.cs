using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class SuperCategoryMap : EntityTypeConfiguration<SuperCategory>
    {
        public SuperCategoryMap()
        {
            HasKey(t => t.SupCatId);

            // Table & Column Mappings
            ToTable("SUPERCATEGORY");

            
            this.Property(t => t.SupCatId).HasColumnName("SUPCATID");
            this.Property(t => t.SupCatCode).HasColumnName("SUPCATCODE");
            this.Property(t => t.SupCatName).HasColumnName("SUPCATNAME");
            this.Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
            this.Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            this.Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            this.Property(t => t.UpdatedBy).HasColumnName("UPDATEDBY");
            this.Property(t => t.UpdatedOn).HasColumnName("UPDATEDON");

        }
    }
}
