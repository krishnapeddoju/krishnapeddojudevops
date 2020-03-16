using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class UserMenuFunctionMap : EntityTypeConfiguration<UserMenuFunction>
    {
        public UserMenuFunctionMap()
        {
            HasKey(t => new { t.FunctionCode });

            // Table & Column Mappings
            ToTable("EV_GETUSERMENUFUNCTIONS");
            Property(t => t.UserId).HasColumnName("USERID");
            Property(t => t.UserName).HasColumnName("USERNAME");
            Property(t => t.PartnerId).HasColumnName("PARTNERID");
            Property(t => t.ApplicationId).HasColumnName("APPLICATIONID");
            Property(t => t.RoleId).HasColumnName("ROLEID");
            Property(t => t.RoleName).HasColumnName("ROLENAME");
            Property(t => t.ModuleCode).HasColumnName("MODULECODE");
            Property(t => t.ModuleName).HasColumnName("MODULENAME");
            Property(t => t.ParentModuleCode).HasColumnName("PARENTMODULECODE");
            Property(t => t.ParentModuleName).HasColumnName("PARENTMODULENAME");
            Property(t => t.ApplicationEntityId).HasColumnName("APPLICATIONENTITYID");
            Property(t => t.EntityName).HasColumnName("ENTITYNAME");
            Property(t => t.FormUrl).HasColumnName("FORMURL");
            Property(t => t.FunctionCode).HasColumnName("FUNCTIONCODE");
            Property(t => t.FunctionName).HasColumnName("FUNCTIONNAME");
            Property(t => t.MenuOrder).HasColumnName("MENUORDER");
            Property(t => t.SubscriberId).HasColumnName("SUBSCRIBERID");
        }
    }
}
