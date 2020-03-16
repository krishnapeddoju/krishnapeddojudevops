using System.Data.Entity.ModelConfiguration;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserManagement.Data.Mapping
{
    public class PartnerRegistrationMap : EntityTypeConfiguration<PartnerRegistration>
    {
        public PartnerRegistrationMap()
        {
            HasKey(t => t.PartnerRegistrationId);

            // Table & Column Mappings
            ToTable("PARTNERREGISTRATION");

            this.Property(t => t.PartnerRegistrationId).HasColumnName("PARTNERREGISTRATIONID");
            this.Property(t => t.RequisitionNo).HasColumnName("REQUISITIONNO");
            this.Property(t => t.PartnerName).HasColumnName("PARTNERNAME");
            this.Property(t => t.PartnerType).HasColumnName("PARTNERTYPE");

            this.Property(t => t.Year).HasColumnName("YEAR");
            this.Property(t => t.Status).HasColumnName("STATUS");
            this.Property(t => t.CIN).HasColumnName("CIN");
            this.Property(t => t.PAN).HasColumnName("PAN");
            this.Property(t => t.TAN).HasColumnName("TAN");
            this.Property(t => t.NatureOfBusiness).HasColumnName("NATUREOFBUSINESS");
            this.Property(t => t.RegistrationNo).HasColumnName("REGISTRATIONNO");
            this.Property(t => t.VAT).HasColumnName("VAT");
            this.Property(t => t.Place).HasColumnName("PLACE");

            this.Property(t => t.BankName).HasColumnName("BANKNAME");
            this.Property(t => t.BankAddress).HasColumnName("BANKADDRESS");
            this.Property(t => t.AccountNo).HasColumnName("ACCOUNTNO");
            this.Property(t => t.IFSCCode).HasColumnName("IFSCCODE");

            this.Property(t => t.FinanceName).HasColumnName("FINANCENAME");
            this.Property(t => t.FinanceEmail).HasColumnName("FINANCEEMAIL");
            this.Property(t => t.FinanceMobile).HasColumnName("FINANCEMOBILE");

            this.Property(t => t.OperationsName).HasColumnName("OPERATIONSNAME");
            this.Property(t => t.OperationsEmail).HasColumnName("OPERATIONEMAIL");
            this.Property(t => t.OperationsMobile).HasColumnName("OPERATIONMOBILE");

            this.Property(t => t.ITName).HasColumnName("ITNAME");
            this.Property(t => t.ITEmail).HasColumnName("ITEMAIL");
            this.Property(t => t.ITMobile).HasColumnName("ITMOBILE");

            this.Property(t => t.WFStatus).HasColumnName("WFSTATUS");

            this.Property(t => t.IsAccept).HasColumnName("ISACCEPT");

            this.Property(t => t.Remarks).HasColumnName("REMARKS");

            this.Property(t => t.RecordStatus).HasColumnName("RECORDSTATUS");
            this.Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            this.Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            this.Property(t => t.UpdatedBy).HasColumnName("UPDATEDBY");
            this.Property(t => t.UpdatedOn).HasColumnName("UPDATEDON");

        }
    }
}
