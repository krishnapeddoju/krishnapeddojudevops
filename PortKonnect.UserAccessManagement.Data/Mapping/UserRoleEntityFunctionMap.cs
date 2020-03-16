using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class UserRoleEntityFunctionMap : EntityTypeConfiguration<UserRoleEntityFunction>
    {
        public UserRoleEntityFunctionMap()
        {
            HasKey(t => new { t.FunctionCode, t.SubscriberId });

            ToTable("EV_USERROLEENTITYFUNCTIONS");
            Property(t => t.ApplicationId).HasColumnName("APPLICATIONID");
            Property(t => t.SubscriberId).HasColumnName("SUBSCRIBERID");
            Property(t => t.UserId).HasColumnName("USERID");
            Property(t => t.RoleId).HasColumnName("ROLEID");
            Property(t => t.ApplicationEntityId).HasColumnName("APPLICATIONENTITYID");
            Property(t => t.FunctionCode).HasColumnName("FUNCTIONCODE");
            Property(t => t.IsDeleted).HasColumnName("ISDELETED");
        }
    }
}
