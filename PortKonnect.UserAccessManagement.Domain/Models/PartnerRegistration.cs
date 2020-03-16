using System;
using System.Collections.Generic;
using System.Linq;
using PortKonnect.UserAccessManagement.GlobalConstants;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class PartnerRegistration
    {
        public string PartnerRegistrationId { get; protected set; }

        public string RequisitionNo { get; protected set; }

        public string PartnerName { get; protected set; }

        public string PartnerType { get; protected set; }

        public string Year { get; protected set; }

        public string Status { get; protected set; }

        public string CIN { get; protected set; }

        public string PAN { get; protected set; }

        public string TAN { get; protected set; }

        public string NatureOfBusiness { get; protected set; }

        public string RegistrationNo { get; protected set; }

        public string VAT { get; protected set; }

        public string Place { get; protected set; }

        public string BankName { get; protected set; }

        public string BankAddress { get; protected set; }

        public string AccountNo { get; protected set; }

        public string IFSCCode { get; protected set; }

        public string FinanceName { get; protected set; }

        public string FinanceEmail { get; protected set; }

        public string FinanceMobile { get; protected set; }

        public string OperationsName { get; protected set; }

        public string OperationsEmail { get; protected set; }

        public string OperationsMobile { get; protected set; }

        public string ITName { get; protected set; }

        public string ITEmail { get; protected set; }

        public string ITMobile { get; protected set; }

        public string WFStatus { get; protected set; }

        public string IsAccept { get; protected set; }

        public string Remarks { get; protected set; }

        public string RecordStatus { get; protected set; }

        public string CreatedBy { get; protected set; }

        public DateTime CreatedOn { get; protected set; }

        public string UpdatedBy { get; protected set; }

        public DateTime? UpdatedOn { get; protected set; }

        public PartnerRegistrationAddress PartnerRegistrationAddress { get; protected set; }

        public virtual ICollection<PartnerDirectorDetails> partnerDirectorDetails { get; protected set; }

        public virtual ICollection<PartnerRegistrationDocs> partnerRegistrationDocs { get; protected set; }

        public PartnerRegistration()
        {


        }

        public PartnerRegistration(string partnerId, string requisitionNo, string partnerType, string partnerName,
            PartnerRegistrationAddress address, string cin, string pan, string tan, string natureofbusiness, string year, string status, string registrationno, string place, string vat,
            string bankName, string bankAddress,
            string accountno, string ifsccode,
            string financename, string financeemail, string financemobile,
            string operationsname, string operationsemail, string operationsmobile,
            string itname, string itemail, string itmobile,
            string recordStatus, string createdBy, DateTime createdOn, string updatedBy, DateTime? updatedOn,
            string wfStatus, string isAccept)
        {
            PartnerRegistrationId = partnerId;
            RequisitionNo = requisitionNo;
            PartnerType = partnerType;
            PartnerName = partnerName.Trim();
            PartnerRegistrationAddress = address;
            CIN = cin;
            PAN = pan;
            TAN = tan;
            VAT = vat;
            NatureOfBusiness = natureofbusiness.Trim();
            Year = year;
            Status = status;
            RegistrationNo = registrationno;
            Place = place.Trim();
            BankName = bankName.Trim();
            BankAddress = bankAddress.Trim();
            AccountNo = accountno;
            IFSCCode = ifsccode;
            FinanceName = financename.Trim();
            FinanceEmail = financeemail;
            FinanceMobile = financemobile;
            OperationsName = operationsname.Trim();
            OperationsEmail = operationsemail;
            OperationsMobile = operationsmobile;
            ITName = itname.Trim();
            ITEmail = itemail;
            ITMobile = itmobile;
            WFStatus = wfStatus;
            IsAccept = isAccept;
            RecordStatus = recordStatus;
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            UpdatedBy = updatedBy;
            UpdatedOn = updatedOn;
            partnerDirectorDetails = new List<PartnerDirectorDetails>();
            partnerRegistrationDocs = new List<PartnerRegistrationDocs>();
        }


        public void UpdatePartnerRegistration(string partnerName, string cin, string pan, string tan, string natureofbusiness, string year, string status, string registrationno, string place, string vat, string bankName, string bankAddress, string accountno, string ifsccode, string financename, string financeemail, string financemobile, string operationsname, string operationsemail, string operationsmobile, string itname, string itemail, string itmobile, string recordStatus, string createdBy, DateTime createdOn, string updatedBy, DateTime? updatedOn, string isAccept)
        {
            PartnerName = partnerName.Trim();
            CIN = cin;
            PAN = pan;
            TAN = tan;
            VAT = vat;
            NatureOfBusiness = natureofbusiness.Trim();
            Year = year;
            Status = status;
            RegistrationNo = registrationno;
            Place = place.Trim();
            BankName = bankName.Trim();
            BankAddress = bankAddress.Trim();
            AccountNo = accountno;
            IFSCCode = ifsccode;
            FinanceName = financename.Trim();
            FinanceEmail = financeemail;
            FinanceMobile = financemobile;
            OperationsName = operationsname.Trim();
            OperationsEmail = operationsemail;
            OperationsMobile = operationsmobile;
            ITName = itname.Trim();
            ITEmail = itemail;
            ITMobile = itmobile;
            if (WFStatus == UAMGlobalConstants.StatusNew || WFStatus == UAMGlobalConstants.StatusRejectedVer || WFStatus == UAMGlobalConstants.StatusRejected)
                WFStatus = UAMGlobalConstants.StatusNew;
            //else if (WFStatus == UAMGlobalConstants.StatusRejected)
            //    WFStatus = UAMGlobalConstants.StatusVerified;
            IsAccept = isAccept;
            RecordStatus = recordStatus;
            UpdatedBy = updatedBy;
            UpdatedOn = updatedOn;
        }

        public void UpdatePartnerRegistrationDetails(string partnerName, string cin, string pan, string tan, string natureofbusiness, string year, string status, string registrationno, string place, string vat, string bankName, string bankAddress, string accountno, string ifsccode, string financename, string financeemail, string financemobile, string operationsname, string operationsemail, string operationsmobile, string itname, string itemail, string itmobile, string recordStatus, string createdBy, DateTime createdOn, string updatedBy, DateTime? updatedOn, string isAccept)
        {
            PartnerName = partnerName.Trim();
            CIN = cin;
            PAN = pan;
            TAN = tan;
            VAT = vat;
            NatureOfBusiness = natureofbusiness.Trim();
            Year = year;
            Status = status;
            RegistrationNo = registrationno;
            Place = place.Trim();
            BankName = bankName.Trim();
            BankAddress = bankAddress.Trim();
            AccountNo = accountno;
            IFSCCode = ifsccode;
            FinanceName = financename.Trim();
            FinanceEmail = financeemail;
            FinanceMobile = financemobile;
            OperationsName = operationsname.Trim();
            OperationsEmail = operationsemail;
            OperationsMobile = operationsmobile;
            ITName = itname.Trim();
            ITEmail = itemail;
            ITMobile = itmobile;
            IsAccept = isAccept;
            RecordStatus = recordStatus;
            UpdatedBy = updatedBy;
            UpdatedOn = updatedOn;
        }


        public void AddDirector(string pDirectorName, string pDirectorPAN, string pDirectorAddress, string pDirectorMobile, string pDirectorTele, string pDirectorEmail, string pCountryCode, string type)
        {
            partnerDirectorDetails.Add(new PartnerDirectorDetails(Guid.NewGuid().ToString(), pDirectorName, pDirectorPAN, pDirectorAddress, pDirectorMobile, pDirectorTele, pDirectorEmail, PartnerRegistrationId, pCountryCode, type));
        }

        public void UpdateDirector(string pDirectorDetailsId, string pDirectorName, string pDirectorPAN, string pDirectorAddress, string pDirectorMobile, string pDirectorTele, string pDirectorEmail, string pCountryCode, string type, string isDeleted)
        {
            PartnerDirectorDetails partnerDirectorDetailsObj = null;
            if (partnerDirectorDetails.Count > 0 && !string.IsNullOrEmpty(pDirectorDetailsId))
                partnerDirectorDetailsObj = partnerDirectorDetails.FirstOrDefault(c => c.PDirectorDetailsId.Equals(pDirectorDetailsId));

            if (partnerDirectorDetailsObj != null)
                partnerDirectorDetailsObj.UpdatePartnerDirectorDetails(pDirectorName, pDirectorPAN, pDirectorAddress, pDirectorMobile, pDirectorTele, pDirectorEmail, PartnerRegistrationId, pCountryCode, type, isDeleted);
            else
                partnerDirectorDetails.Add(new PartnerDirectorDetails(Guid.NewGuid().ToString(), pDirectorName, pDirectorPAN, pDirectorAddress, pDirectorMobile, pDirectorTele, pDirectorEmail, PartnerRegistrationId, pCountryCode, type));
        }

        public void AddDocumentType(string pFileName, string pOriginalName, string pDocumentType, DateTime? pValidDate, string isDeleted)
        {
            PartnerRegistrationDocs partnerRegistrationDoc = null;

            if (partnerRegistrationDocs.Count > 0)
            {
                //Filtering on DocumentType as of now we have one document for one Document types
                partnerRegistrationDoc = partnerRegistrationDocs.ToList().Find(q => q.PDocumentType == pDocumentType);
            }

            if (partnerRegistrationDoc == null && isDeleted == UAMGlobalConstants.IsDeletedNo)
            {
                partnerRegistrationDocs.Add(new PartnerRegistrationDocs(Guid.NewGuid().ToString(), pFileName, pOriginalName, pDocumentType, pValidDate, PartnerRegistrationId));
            }
            else if (partnerRegistrationDoc != null && isDeleted == UAMGlobalConstants.IsDeletedNo)
            {
                partnerRegistrationDoc.UpdatePartnerRegistrationDocs(pFileName, pOriginalName, pDocumentType, pValidDate, PartnerRegistrationId);
            }
            else if (partnerRegistrationDoc != null && isDeleted == UAMGlobalConstants.IsDeletedYes)
            {
                partnerRegistrationDoc.RemovePartnerRegistrationDocs();
            }
        }

        public void ApprovePartnerRegistration()
        {
            WFStatus = UAMGlobalConstants.StatusApproved;
        }

        public void VerifyPartnerRegistration()
        {
            WFStatus = UAMGlobalConstants.StatusVerified;
        }

        public void RejectPartnerVerification(string remarks)
        {
            //Reject method at verification level
            WFStatus = UAMGlobalConstants.StatusRejectedVer;
            Remarks = remarks;
        }

        public void RejectPartnerRegistration(string remarks)
        {
            WFStatus = UAMGlobalConstants.StatusRejected;
            Remarks = remarks;
        }

        public void AssignPartnerRegistrationDoc(List<PartnerRegistrationDocs> partnerRegistrationDoc)
        {
            partnerRegistrationDocs = new List<PartnerRegistrationDocs>();
            partnerRegistrationDocs = partnerRegistrationDoc;
        }
    }
}
