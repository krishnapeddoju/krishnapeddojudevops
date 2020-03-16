using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class RoleFunctionMap : EntityTypeConfiguration<RoleFunction>
    {
        public RoleFunctionMap()
        {
            this.HasKey(t => new { t.RoleId, t.ApplicationId,t.FunctionCode, t.SubscriberId,t.ApplicationEntityId});
            ToTable("ROLEFUNCTION");
            this.Property(t => t.RoleId).HasColumnName("ROLEID");
            this.Property(t => t.ApplicationEntityId).HasColumnName("APPLICATIONENTITYID");
            this.Property(t => t.FunctionCode).HasColumnName("FUNCTIONCODE");
			this.Property(t => t.ApplicationId).HasColumnName("APPLICATIONID");
            this.Property(t => t.IsDeleted).HasColumnName("ISDELETED");
            this.Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
            this.Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            this.Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            this.Property(t => t.UpdatedBy).HasColumnName("MODIFIEDBY");
            this.Property(t => t.UpdatedOn).HasColumnName("MODIFIEDON");
			this.Property(t => t.SubscriberId).HasColumnName("SUBSCRIBERID");
        }
    }
}
