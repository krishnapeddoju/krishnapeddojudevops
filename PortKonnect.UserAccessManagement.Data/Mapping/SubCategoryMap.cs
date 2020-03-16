using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class SubCategoryMap : EntityTypeConfiguration<SubCategory>
    {
        public SubCategoryMap()
        {
            HasKey(t => t.SubCatId);

            // Table & Column Mappings
            ToTable("SUBCATEGORY");


            this.Property(t => t.SubCatId).HasColumnName("SUBCATID");
            this.Property(t => t.SupCatId).HasColumnName("SUPCATID");
            //this.Property(t => t.SupCatCode).HasColumnName("SUPCATCODE");
            this.Property(t => t.SubCatCode).HasColumnName("SUBCATCODE");
            this.Property(t => t.SubCatName).HasColumnName("SUBCATNAME");
            this.Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
            this.Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            this.Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            this.Property(t => t.UpdatedBy).HasColumnName("UPDATEDBY");
            this.Property(t => t.UpdatedOn).HasColumnName("UPDATEDON");

        }
    }
}
