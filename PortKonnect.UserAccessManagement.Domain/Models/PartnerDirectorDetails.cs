

using PortKonnect.UserAccessManagement.GlobalConstants;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class PartnerDirectorDetails
    {
        public string PDirectorDetailsId { get; protected set; }
        public string PDirectorName { get; protected set; }
        public string PDirectorPAN { get; protected set; }
        public string PDirectorAddress { get; protected set; }
        public string PDirectorMobile { get; protected set; }
        public string PDirectorTele { get; protected set; }
        public string PDirectorEmail { get; protected set; }
        public string PartnerRegistrationId { get; protected set; }
        public string PCountryCode { get; protected set; }
        public string Type { get; protected set; }
        public string IsDeleted { get; set; }

        public PartnerDirectorDetails()
        {



        }

        public PartnerDirectorDetails(string pDDirectorId, string pDirectorName, string pDirectorPAN, string pDirectorAddress, string pDirectorMobile, string pDirectorTele, string pDirectorEmail, string partnerRegistrationId, string pCountryCode, string type)
        {
            PDirectorDetailsId = pDDirectorId;
            PDirectorName = pDirectorName.Trim();
            PDirectorPAN = pDirectorPAN;
            PDirectorAddress = pDirectorAddress.Trim();
            PDirectorMobile = pDirectorMobile;
            PDirectorTele = pDirectorTele;
            PDirectorEmail = pDirectorEmail;
            PartnerRegistrationId = partnerRegistrationId;
            PCountryCode = pCountryCode;
            Type = type;
            IsDeleted = UAMGlobalConstants.IsDeletedNo;
        }
        
        public void UpdatePartnerDirectorDetails(string pDirectorName, string pDirectorPAN, string pDirectorAddress, string pDirectorMobile, string pDirectorTele, string pDirectorEmail, string partnerRegistrationId, string pCountryCode, string type, string isDeleted)
        {
            PDirectorName = pDirectorName.Trim();
            PDirectorPAN = pDirectorPAN;
            PDirectorAddress = pDirectorAddress.Trim();
            PDirectorMobile = pDirectorMobile;
            PDirectorTele = pDirectorTele;
            PDirectorEmail = pDirectorEmail;
            PartnerRegistrationId = partnerRegistrationId;
            PCountryCode = pCountryCode;
            Type = type;
            IsDeleted = isDeleted;
        }
    }


}
