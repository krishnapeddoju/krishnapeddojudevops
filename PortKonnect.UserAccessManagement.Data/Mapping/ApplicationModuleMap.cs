using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class ApplicationModuleMap : EntityTypeConfiguration<ApplicationModule>
    {
        public ApplicationModuleMap()
        {
            //HasKey(t => t.ModuleId);

            //// Table & Column Mappings
            //ToTable("PARTNER");

            //this.Property(t => t.ModuleId).HasColumnName("MODULECODE");
            //this.Property(t => t.).HasColumnName("APPLICATIONENTITYID");
            //this.Property(t => t.).HasColumnName("MENUORDER");
            //this.Property(t => t.PartnerType).HasColumnName("ISDELETED");
            //this.Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
            //this.Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            //this.Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            //this.Property(t => t.UpdatedBy).HasColumnName("UPDATEDBY");
            //this.Property(t => t.UpdatedOn).HasColumnName("UPDATEDON");
        }
    }
}
