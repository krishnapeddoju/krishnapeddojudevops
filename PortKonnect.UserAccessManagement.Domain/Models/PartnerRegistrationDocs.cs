using System;
using PortKonnect.UserAccessManagement.GlobalConstants;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class PartnerRegistrationDocs
    {

        public string PDocumentId { get; protected set; }
        public string PFileName { get; protected set; }
        public string POriginalName { get; protected set; }
        public string PDocumentType { get; protected set; }
        public DateTime? PValidDate { get; protected set; }
        public string PartnerRegistrationId { get; set; }
        public string IsDeleted { get; set; }



        public PartnerRegistrationDocs()
        {



        }

        public PartnerRegistrationDocs(string pDocumentId, string pFileName, string pOriginalName, string pDocumentType, DateTime? pValidDate, string partnerRegistrationId)
        {
            PDocumentId = pDocumentId;
            PFileName = pFileName;
            PDocumentType = pDocumentType;
            POriginalName = pOriginalName.Trim();
            PValidDate = pValidDate;
            PartnerRegistrationId = partnerRegistrationId;
            IsDeleted = UAMGlobalConstants.IsDeletedNo;
        }
        
        public void UpdatePartnerRegistrationDocs( string pFileName, string pOriginalName, string pDocumentType, DateTime? pValidDate, string partnerRegistrationId)
        {
            PFileName = pFileName;
            PDocumentType = pDocumentType;
            POriginalName = pOriginalName.Trim();
            PValidDate = pValidDate;
            PartnerRegistrationId = partnerRegistrationId;
            IsDeleted = UAMGlobalConstants.IsDeletedNo;
        }

        public void RemovePartnerRegistrationDocs()
        {
           IsDeleted = UAMGlobalConstants.IsDeletedYes;
        }
    }
}
