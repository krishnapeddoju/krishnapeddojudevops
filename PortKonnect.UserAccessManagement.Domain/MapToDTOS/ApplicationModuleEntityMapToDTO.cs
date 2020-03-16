using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class ApplicationModuleEntityMapToDTO
    {
        public static List<ApplicationModuleEntityDTO> MapToDTO(this IEnumerable<ApplicationModuleEntity> applicationModuleEntities)
        {
            List<ApplicationModuleEntityDTO> applicationModuleEntityDtos=new List<ApplicationModuleEntityDTO>();
            if (applicationModuleEntities!=null)
            {
                foreach (ApplicationModuleEntity applicationModuleEntity in applicationModuleEntities)
                {
                    applicationModuleEntityDtos.Add(applicationModuleEntity.MapToDTO());
                }
            }
            return applicationModuleEntityDtos;
        }

        public static ApplicationModuleEntityDTO MapToDTO(this ApplicationModuleEntity applicationModuleEntity)
        {
            if (applicationModuleEntity == null)
            {
                return null;
            }
            ApplicationModuleEntityDTO applicationModuleEntityDto = new ApplicationModuleEntityDTO()
            {
                ApplicationEntityId = applicationModuleEntity.ApplicationEntityId,
                ModuleId = applicationModuleEntity.ModuleId,
                Order = applicationModuleEntity.Order,
                RecordStatus = applicationModuleEntity.RecordStatus,
                CreatedBy = applicationModuleEntity.CreatedBy,
                CreatedOn = applicationModuleEntity.CreatedOn,
                UpdatedBy = applicationModuleEntity.UpdatedBy,
                UpdatedOn = applicationModuleEntity.UpdatedOn
            };
            return applicationModuleEntityDto;
        }
    }
}
