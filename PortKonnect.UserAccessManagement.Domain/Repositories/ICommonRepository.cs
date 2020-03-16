using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Repositories.Interfaces
{
    public interface ICommonRepository
    {
        List<string> GetPartnerTypesEnum();

        List<string> GetStatusEnum();

        List<string> GetYearsEnum();

        List<string> GetDocumentTypesEnum();

        List<string> GetDocumentTypesByPartnerType(string partnerType);

        List<ApplicationDTO> GetApplicationsById(int applicationId);

        List<PortDTO> GetPorts();

        List<CountryDTO> GetCountries();

        List<PartnerTypeDTO> GetPartnerTypes();

        PortDTO GetPortByPortCode(string portCode);
        PartnerTypeDTO GetPartnerTypeName(string partnerType);

        List<PartnerDTO> GetPartnerCodes(List<string> partnerType, string subscriberId);

        string GetPartnerTypeNames(string partnerType);

        PartnerTypePriorityDTO GetPartnerTypePriority(string partnerType);

        List<PartnerDTO> GetPartners(List<string> partnerCodes);

        List<PartnerDTO> GetPartnersByPartnerType(string partnerType);

        List<PartnerTypePriorityDTO> GetPartnerTypePriorityList(List<string> partnerTypesList);
    }
}
