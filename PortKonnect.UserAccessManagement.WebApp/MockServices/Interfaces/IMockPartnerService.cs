using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.WebApp.MockServices.Interfaces
{
    public interface IMockPartnerService
    {
        List<CountryDTO> GetCountries();
        List<ApplicationDTO> GetApplication();
        List<PortDTO> GetPorts();
        List<PartnerTypeDTO> GetPartnerTypes();
        //PartnerDTO SavePartner(PartnerDTO partnerDTO);
        void AddPartner(PartnerDTO partnerDTO);
        List<PartnerDTO> GetPartnersList();
        PartnerDTO GetPartner(string partnerId);
    }
}
