using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
			this.HasKey(t => new { t.RoleId, t.ApplicationId, t.SubscriberId });
            ToTable("ROLE");
            this.Property(t => t.RoleId).HasColumnName("ROLEID");
            this.Property(t => t.RoleCode).HasColumnName("ROLECODE");
            this.Property(t => t.RoleName).HasColumnName("ROLENAME");
            this.Property(t => t.ApplicationId).HasColumnName("APPLICATIONID");
            this.Property(t => t.SubscriberId).HasColumnName("SUBSCRIBERID");
            this.Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
            this.Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            this.Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            this.Property(t => t.UpdatedBy).HasColumnName("MODIFIEDBY");
            this.Property(t => t.UpdatedOn).HasColumnName("MODIFIEDON");

        }

    }
}
