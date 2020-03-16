using PortKonnect.UserAccessManagement.Domain.DTOS;
using System.Collections.Generic;

namespace PortKonnect.UserAccessManagement.Domain.Repositories
{
    public interface IPartnerRepository
    {
        void AddPartner(Partner partner);
        void UpdatePartner(Partner partner);
        Partner GetPartnerByPartnerId(string partnerId, string subscriberId);
        Partner GetPartnerByPartnerCode(string partnerCode);
        Partner GetPartnerByPartnerName(string partnerName);
        List<PartnerListDTO> GetPartners(string subscriberId, int applicationId, string partnerName, string partnerType, string emailId, string contactNumber);
        int GetPartnersByCodeOtherThanPartnerId(string partnerId, string partnerCode);
        int GetPartnersByNameOtherThanPartnerId(string partnerId, string partnerName);
        Partner GetPartnerByPartnerCode(List<PartnerListDTO> partnersListDtos, string partnerCode);
        void DeletePartnerTypes(Partner partner);
        Partner GetPartner(int applicationId, string partnerCode);
        Partner GetPartnerByPartnerTypeandpartnerCode(string PartnerType, string partnerCode);
    }
}
