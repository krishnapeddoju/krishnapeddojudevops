using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            HasKey(t => new { t.UserId, t.RoleId, t.ApplicationId,t.SubscriberId });

            // Table & Column Mappings
            ToTable("USERROLE");

            this.Property(t => t.UserId).HasColumnName("USERID");
            this.Property(t => t.RoleId).HasColumnName("ROLEID");
            this.Property(t => t.SubscriberId).HasColumnName("SUBSCRIBERID");
            this.Property(t => t.ApplicationId).HasColumnName("APPLICATIONID");
            this.Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
            this.Property(t => t.IsDeleted).HasColumnName("ISDELETED");
            this.Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            this.Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            this.Property(t => t.UpdatedBy).HasColumnName("UPDATEDBY");
            this.Property(t => t.UpdatedOn).HasColumnName("UPDATEDON");

        }
    }
}
