using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public interface IPartnerRegistrationApplicationService
    {
        List<PartnerRegistrationListDTO> GetPendingPartnerRegistrationsGridList(string estbName, string partnerType, string status);

        List<PartnerTypeDTO> GetPartnerTypes();

        List<string> GetStatuses();

        List<string> GetYears();

        List<string> GetDocumentTypes();

        List<CountryDTO> GetCountries();

        List<string> GetDocumentTypesByPartnerType(string partnerType);

        PartnerRegistrationDTO GetPartnerRegistration(string requisitionNo);

        void AddPartner(PartnerRegistrationDTO partnerRegistrationDTO);

        void AddPartnerRegistration(PartnerRegistrationDTO partnerRegistrationDTO);

        void ApprovePartnerRegistration(PartnerRegistrationListDTO partnerRegistrationDTO);

        void VerifyPartnerRegistration(PartnerRegistrationListDTO partnerRegistrationDTO);

        void VerifyPartnerRegistration(PartnerRegistrationDTO partnerRegistrationDTO);

        void RejectPartnerVerification(PartnerRegistrationListDTO partnerRegistrationDTO);

        void RejectPartnerRegistration(PartnerRegistrationListDTO partnerRegistrationDTO);

        List<PartnerRegistrationDocsDTO> GetDocumentTypesByPartnerTypeWithDoc(string partnerType);

        string CheckUniquePartnerName(string partnerName,string partnerType);

        void UpdatePartnerRegistration(PartnerRegistrationDTO partnerRegistrationDTO);

        void UpdatePartnerRegistrationOnly(PartnerRegistrationDTO partnerRegistrationDTO);

        PartnerRegistrationDTO GetPartnerRegistration(string requisitionNo, string emailId, string mobNo);

        void ApprovePartnerRegistration(PartnerRegistrationDTO partnerRegistrationDTO);

    }
}
