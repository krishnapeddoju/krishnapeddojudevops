using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            HasKey(t => t.EmployeeID);

            // Table & Column Mappings
            ToTable("EMPLOYEE");
            this.Property(t => t.EmployeeID).HasColumnName("EMPLOYEEID");
            this.Property(t => t.EmployeeNo).HasColumnName("EMPLOYEENO");
            this.Property(t => t.FirstName).HasColumnName("FIRSTNAME");
            this.Property(t => t.LastName).HasColumnName("LASTNAME");
            this.Property(t => t.OfficialMobileNo).HasColumnName("OFFICIALMOBILENO");            
            this.Property(t => t.PersonalMobileNo).HasColumnName("PERSONALMOBILENO");
            this.Property(t => t.EmailID).HasColumnName("EMAILID");
            this.Property(t => t.BirthDate).HasColumnName("BIRTHDATE");
            this.Property(t => t.JoiningDate).HasColumnName("JOININGDATE");
            this.Property(t => t.Gender).HasColumnName("GENDER");
            this.Property(t => t.Department).HasColumnName("DEPARTMENT");
            this.Property(t => t.Designation).HasColumnName("DESIGNATION");
            this.Property(t => t.ApplicationId).HasColumnName("APPLICATIONID");
            this.Property(t => t.SubscriberId).HasColumnName("SUBSCRIBERID");
            this.Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
            this.Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            this.Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            this.Property(t => t.UpdatedBy).HasColumnName("UPDATEDBY");
            this.Property(t => t.UpdatedOn).HasColumnName("UPDATEDON");
            this.Property(t => t.LicenseCapability).HasColumnName("LICENSECAPABILITY");
        }
    }
}

