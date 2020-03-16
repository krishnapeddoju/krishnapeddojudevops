using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class ApplicationEntityMap : EntityTypeConfiguration<ApplicationEntity>
    {
        public ApplicationEntityMap()
        {
            HasKey(t => t.ApplicationEntityId);
            ToTable("APPLICATIONENTITY");
            Property(t => t.ApplicationEntityId).HasColumnName("APPLICATIONENTITYID");
            Property(t => t.ApplicationId).HasColumnName("APPLICATIONID");
            Property(t => t.EntityName).HasColumnName("ENTITYNAME");
            Property(t => t.Url).HasColumnName("FORMURL");
            Property(t => t.IsMenu).HasColumnName("ISMENU");
            Property(t => t.MailNotification).HasColumnName("MAILNOTIFICATION");
            Property(t => t.SysNotification).HasColumnName("SYSNOTIFICATION");
            Property(t => t.Sms).HasColumnName("SMS");
            Property(t => t.WorkFlow).HasColumnName("WORKFLOW");
            Property(t => t.ApiUrl).HasColumnName("APIURL");
            Property(t => t.MenuOrder).HasColumnName("MENUORDER");
            Property(t => t.IsDeleted).HasColumnName("ISDELETED");
            Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
            Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            Property(t => t.UpdatedBy).HasColumnName("UPDATEDBY");
            Property(t => t.UpdatedOn).HasColumnName("UPDATEDON");
            Property(t => t.MENUICON).HasColumnName("MENUICON");
            Property(t => t.MENUICON1).HasColumnName("MENUICON1");
            Property(t => t.MENUICON2).HasColumnName("MENUICON2");
        }
    }
}
