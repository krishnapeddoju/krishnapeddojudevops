using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public interface IPartnerApplicationService
    {
        void AddPartner(PartnerDTO partnerDTO);
        void UpdatePartner(PartnerDTO partnerDTO);
        PartnerDTO GetPartner(string partnerId);
		PartnerDTO GetPartnerLogo(string partnerId);
        List<PartnerTypeDTO> GetPartnerTypes();
        List<PartnerListDTO> GetPartnersList(string partnerName, string partnerType, string emailId, string contactNumber,string subscriberId,int applicationId);
        List<ApplicationDTO> GetApplication();
        List<PortDTO> GetPorts();
        List<CountryDTO> GetCountries();
        List<PartnerDTO> GetPartnerCodes(List<string> partnerType);
        List<PartnerDTO> GetPartners(List<string> partnerCodes);
        List<PartnerDTO> GetPartnersByPartnerType(string partnerType);
    }
}
