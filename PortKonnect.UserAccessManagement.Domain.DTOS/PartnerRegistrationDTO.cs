using System;
using System.Collections.Generic;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class PartnerRegistrationDTO
    {
        public string PartnerRegistrationId { get; set; }
        public string PartnerName { get; set; }
        public string PartnerType { get; set; }
        public PartnerRegistrationAddressDTO PartnerRegistrationAddress { get; set; }
        public string RequisitionNo { get; set; }

        public string Year { get; set; }
        public string Status { get; set; }
        public string CIN { get; set; }
        public string PAN { get; set; }
        public string TAN { get; set; }
        public string NatureOfBusiness { get; set; }
        public string RegistrationNo { get; set; }
        public string VAT { get; set; }
        public string Place { get; set; }

        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string BankAddress { get; set; }
        public string IFSCCode { get; set; }

        public string FinanceName { get; set; }
        public string FinanceEmail { get; set; }
        public string FinanceMobile { get; set; }

        public string OperationsName { get; set; }
        public string OperationsEmail { get; set; }
        public string OperationsMobile { get; set; }

        public string ITName { get; set; }
        public string ITEmail { get; set; }
        public string ITMobile { get; set; }

        public string WFStatus { get; set; }

        public string IsAccept { get; set; }

        public string Remarks { get; set; }

        public string RecordStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }


        public  List<PartnerDirectorDetailsDTO> PartnerDirectorDetailss { get; set; }

        public List<PartnerDirectorDetailsDTO> PartnerOperationsDetailss { get; set; }

        public List<PartnerDirectorDetailsDTO> PartnerITDetailss { get; set; }

        public List<PartnerDirectorDetailsDTO> PartnerFinanceDetailss { get; set; }
        
        public List<PartnerDirectorDetailsDTO> PartnerSalesDetailss { get; set; }

        public List<PartnerRegistrationDocsDTO> DocumentDTOs { get; set; }

        public ContextDTO context { get; set; }

        public PartnerRegistrationListDTO PartnerRegistrationListDTO { get; set; }
    }

    public class PartnerRegistrationListDTO
    {
        public string PartnerRegistrationId { get; set; }
        public string PartnerName { get; set; }
        public string PartnerType { get; set; }
        public string RequisitionNo { get; set; }
        public string PartnerCode { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Remarks { get; set; }
        public List<string> UserRoleArray { get; set; }
        public DateTime CreatedOn { get; set; }
        public string WFStatus { get; set; }
    }
}
