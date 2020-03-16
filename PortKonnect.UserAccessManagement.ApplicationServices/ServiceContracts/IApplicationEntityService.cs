using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public interface IApplicationEntityService
    {
        void AddApplicationEntity(ApplicationEntityDTO appEntity);
        List<ApplicationEntityDTO> GetEntities(int applicationId);
        ApplicationEntityDTO GetEntity(int applicationId, string applicationEntityCode);
        ApplicationEntityDTO GetEntityForApplicationEntityId(string applicationEntityId);
        List<ApplicationEntityDTO> GetEntitiesForModule(int applicationId, string moduleId);
        void UpdatePartner(ApplicationEntityDTO applicationEntityDto);
    }
}
