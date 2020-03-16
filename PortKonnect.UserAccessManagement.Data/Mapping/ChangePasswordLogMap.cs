using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{

    public class ChangePasswordLogMap : EntityTypeConfiguration<ChangePasswordLog>
    {
        public ChangePasswordLogMap()
        {
            HasKey(t => new { t.LogTransactionId });

            // Table & Column Mappings
            ToTable("CHANGEPASSWORDLOG");
            this.Property(t => t.LogTransactionId).HasColumnName("LOGTRANSID");
            this.Property(t => t.UserId).HasColumnName("USERID");
            this.Property(t => t.OldPassword).HasColumnName("OLDPWD");
            this.Property(t => t.NewPassword).HasColumnName("NEWPWD");
            this.Property(t => t.ChangeDateTime).HasColumnName("CHANGEDATETIME");
            this.Property(t => t.IsDelete).HasColumnName("ISDELETE");
            this.Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            this.Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            this.Property(t => t.ModifiedBy).HasColumnName("MODIFIEDBY");
            this.Property(t => t.ModifiedOn).HasColumnName("MODIFIEDON");

        }
    }
}
