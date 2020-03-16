using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class ModulesEntityFunctionMap : EntityTypeConfiguration<ModulesEntityFunction>
    {
        public ModulesEntityFunctionMap()
        {
            HasKey(t => t.FunctionCode);

            ToTable("EV_MODULESENTITYFUNCTIONS");
            Property(t => t.ApplicationId).HasColumnName("APPLICATIONID");
            Property(t => t.ModuleCode).HasColumnName("MODULECODE");
            Property(t => t.ModuleName).HasColumnName("MODULENAME");
			Property(t => t.ModuleIcon).HasColumnName("MODULEICON");
            Property(t => t.ParentModuleCode).HasColumnName("PARENTMODULECODE");
            Property(t => t.ModuleOrder).HasColumnName("MODULEORDER");
            Property(t => t.ApplicationEntityId).HasColumnName("APPLICATIONENTITYID");
            Property(t => t.EntityName).HasColumnName("ENTITYNAME");
            Property(t => t.EntityOrder).HasColumnName("ENTITYORDER");
            Property(t => t.FunctionCode).HasColumnName("FUNCTIONCODE");
            Property(t => t.FunctionName).HasColumnName("FUNCTIONNAME");
            Property(t => t.IsMenuItem).HasColumnName("ISMENU");
            Property(t => t.FormUrl).HasColumnName("FORMURL");
            Property(t => t.EntityUrl).HasColumnName("ENTITYURL");
            Property(t => t.FunctionOrder).HasColumnName("FUNCTIONORDER");
            Property(t => t.ModuleUrl).HasColumnName("MODULEURL");
            Property(t => t.MENUICON).HasColumnName("MENUICON");
            Property(t => t.MENUICON1).HasColumnName("MENUICON1");
            Property(t => t.MENUICON2).HasColumnName("MENUICON2");
        }
    }
}
