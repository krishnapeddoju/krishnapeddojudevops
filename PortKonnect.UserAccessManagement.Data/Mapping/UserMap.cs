using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(t => new { t.UserId });

            // Table & Column Mappings
            ToTable("USERS");

            this.Property(t => t.UserId).HasColumnName("USERID");
            this.Property(t => t.UserName).HasColumnName("USERNAME");
            this.Property(t => t.Password).HasColumnName("PWD");
            this.Property(t => t.FirstName).HasColumnName("FIRSTNAME");
            this.Property(t => t.LastName).HasColumnName("LASTNAME");
            //this.Property(t => t.ApplicationId).HasColumnName("APPLICATIONID");
			this.Property(t => t.PartnerType).HasColumnName("PARTNERTYPE");
            this.Property(t => t.PartnerId).HasColumnName("PARTNERID");
            this.Property(t => t.EmailId).HasColumnName("EMAILID");
            this.Property(t => t.ContactNo).HasColumnName("CONTACTNUMBER");
            this.Property(t => t.IsFirstTimeLogin).HasColumnName("ISFIRSTTIMELOGIN");
            this.Property(t => t.InCorrectLogins).HasColumnName("INCORRECTLOGINS");
            this.Property(t => t.DormantStatus).HasColumnName("DORMANTSTATUS");
            this.Property(t => t.PwdExpiryDate).HasColumnName("PWDEXPIRTYDATE");
            this.Property(t => t.LogTime).HasColumnName("LOGINTIME");
            this.Property(t => t.IsDeleted).HasColumnName("ISDELETED");
            this.Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
            this.Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            this.Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            this.Property(t => t.UpdatedBy).HasColumnName("UPDATEDBY");
            this.Property(t => t.UpdatedOn).HasColumnName("UPDATEDON");
            this.Property(t => t.ValidFromDate).HasColumnName("VALIDFROMDATE");
            this.Property(t => t.ValidToDate).HasColumnName("VALIDTODATE");
            this.Property(t => t.IsCFSUser).HasColumnName("ISCFSUSER");

        }
    }
}
