using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class ApplicationEntityMapToDTO
    {
        public static List<ApplicationEntityDTO> MapToDTO(this IEnumerable<ApplicationEntity> applicationEntities)
        {
            List<ApplicationEntityDTO> applicationEntityDtos=new List<ApplicationEntityDTO>();
            if (applicationEntities!=null)
            {
                foreach (ApplicationEntity applicationEntity in applicationEntities)
                {
                    applicationEntityDtos.Add(applicationEntity.MapToDTO());
                }
            }
            return applicationEntityDtos;
        }

        public static ApplicationEntityDTO MapToDTO(this ApplicationEntity applicationEntity)
        {
            if (applicationEntity == null)
            {
                return null;
            }
            ApplicationEntityDTO applicationEntityDto = new ApplicationEntityDTO()
            {
                ApplicationEntityId = applicationEntity.ApplicationEntityId,
                EntityName = applicationEntity.EntityName,
                ApplicationId = applicationEntity.ApplicationId,
                Url = applicationEntity.Url,
                applicationEntityFunctions = applicationEntity.applicationEntityFunctions.MapToDTO(),
                RecordStatus = applicationEntity.RecordStatus,
                CreatedBy = applicationEntity.CreatedBy,
                CreatedOn = applicationEntity.CreatedOn,
                UpdatedBy = applicationEntity.UpdatedBy,
                UpdatedOn = applicationEntity.UpdatedOn
            };
            return applicationEntityDto;
        }
    }
}
