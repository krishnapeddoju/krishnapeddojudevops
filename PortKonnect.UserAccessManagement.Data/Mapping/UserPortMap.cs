using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class UserPortMap : EntityTypeConfiguration<UserPort>
    {
        public UserPortMap()
        {
            HasKey(t => new { t.UserId, t.PortCode });

            // Table & Column Mappings
            ToTable("USERPORT");

            this.Property(t => t.UserId).HasColumnName("USERID");
            this.Property(t => t.PortCode).HasColumnName("PORTCODE");
            this.Property(t => t.IsDeleted).HasColumnName("ISDELETED");
            this.Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
            this.Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            this.Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            this.Property(t => t.UpdatedBy).HasColumnName("UPDATEDBY");
            this.Property(t => t.UpdatedOn).HasColumnName("UPDATEDON");

        }
    }
}
