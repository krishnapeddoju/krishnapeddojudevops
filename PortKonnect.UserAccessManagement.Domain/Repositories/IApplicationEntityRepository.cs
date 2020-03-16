using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public interface IApplicationEntityRepository
    {
        List<ApplicationEntityDTO> GetEntities(int appId);
        ApplicationEntityDTO GetEntity(int applicationId, string applicationEntityCode);
        ApplicationEntityDTO GetEntityForApplicationEntityId(string applicationEntityId);
        List<ApplicationEntityDTO> GetEntitiesForModule(int applicationId, string moduleId);
        void AddApplicationEntity(ApplicationEntity appEntity);
        void UpdateApplicationEntity(ApplicationEntity applicationEntity);
    }
}
