using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class ApplicationEntityFunctionMap : EntityTypeConfiguration<ApplicationEntityFunction>
    {
        public ApplicationEntityFunctionMap()
        {
            HasKey(t => new { t.ApplicationEntityId, t.FunctionCode });
            ToTable("APPLICATIONENTITYFUNCTION");
            Property(t => t.ApplicationEntityId).HasColumnName("APPLICATIONENTITYID");
            Property(t => t.FunctionCode).HasColumnName("FUNCTIONCODE");
            Property(t => t.FunctionName).HasColumnName("FUNCTIONNAME");
            Property(t => t.FunctionUrl).HasColumnName("FORMURL");
            Property(t => t.ApiUrl).HasColumnName("APIURL");
            Property(t => t.IsMenuItem).HasColumnName("ISMENU");
            Property(t => t.Order).HasColumnName("MENUORDER");
            Property(t => t.IsDeleted).HasColumnName("ISDELETED");
            Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
            Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            Property(t => t.UpdatedBy).HasColumnName("UPDATEDBY");
            Property(t => t.UpdatedOn).HasColumnName("UPDATEDON");
        }
    }
}
