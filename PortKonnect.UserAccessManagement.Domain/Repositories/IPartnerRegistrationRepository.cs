using PortKonnect.UserAccessManagement.Domain.DTOS;
using System.Collections.Generic;

namespace PortKonnect.UserAccessManagement.Domain.Repositories
{
    public interface IPartnerRegistrationRepository
    {
        void AddOrUpdatePartnerRegistration(PartnerRegistration partnerRegistration);
        string GenerateRequisitionNo();
        List<PartnerRegistrationListDTO> GetPendingPartnerRegistrationsGridList(string estbName, string partnerType, string status);
        PartnerRegistration GetPartnerRegistrationByPartnerId(string requisitionNo);
        PartnerRegistration GetPartnerRegistration(string requisitionNo, string emailId, string mobNo);
       List<string> GetRoleIdsBasedOnPartnerType(string partnerType, int appId, string subscriberId);
        List<PartnerRegistrationListDTO> GetPartnerRegistrationsForUniqueItem();
        //void UpdatePartner(Partner partner);
        //Partner GetPartnerByPartnerId(string partnerId);
        //Partner GetPartnerByPartnerCode(string partnerCode);
        //Partner GetPartnerByPartnerName(string partnerName);
        //List<PartnerListDTO> GetPartners(string subscriberId, int applicationId, string partnerName, string partnerType, string emailId, string contactNumber);
        //int GetPartnersByCodeOtherThanPartnerId(string partnerId, string partnerCode);
        //int GetPartnersByNameOtherThanPartnerId(string partnerId, string partnerName);
        //Partner GetPartnerByPartnerCode(List<PartnerListDTO> partnersListDtos, string partnerCode);
        //void DeletePartnerTypes(Partner partner);
    }
}
