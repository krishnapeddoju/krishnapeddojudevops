using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class PartnerTypePriorityMap : EntityTypeConfiguration<PartnerTypePriority>
    {
        public PartnerTypePriorityMap()
        {
            HasKey(t => new { t.PartnerTypeCode });

            ToTable("PARTNERTYPEPRIORITY");

            Property(t => t.PriorityNo).HasColumnName("PRIORITYNO");
            Property(t => t.PartnerTypeName).HasColumnName("PARTNERTYPENAME");
            Property(t => t.PartnerTypeCode).HasColumnName("PARTNERTYPECODE");
             Property(t => t.IsDeleted).HasColumnName("ISDELETED");

        }
    }
}
