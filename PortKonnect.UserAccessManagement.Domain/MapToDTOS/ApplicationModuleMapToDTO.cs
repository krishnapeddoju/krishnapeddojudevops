using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class ApplicationModuleMapToDTO
    {
        public static List<ApplicationModuleDTO> MapToDTO(this IEnumerable<ApplicationModule> applicationModules)
        {
            List<ApplicationModuleDTO> applicationModuleDtos = new List<ApplicationModuleDTO>();
            if (applicationModules != null)
            {
                foreach (ApplicationModule item in applicationModules)
                {
                    applicationModuleDtos.Add(item.MapToDto());
                }
            }
            return applicationModuleDtos;
        }

        public static ApplicationModuleDTO MapToDto(this ApplicationModule applicationModule)
        {
            if (applicationModule == null) return null;

            ApplicationModuleDTO applicationModuleDto = new ApplicationModuleDTO()
            {
                ApplicationId = applicationModule.ApplicationId,
                ModuleId = applicationModule.ModuleId,
                ModuleName = applicationModule.ModuleName,
                ParentModuleId = applicationModule.ParentModuleId,
                Order = applicationModule.Order,
                Url = applicationModule.Url,
                ModuleEntities = applicationModule.ModuleEntities.MapToDTO(),
                RecordStatus = applicationModule.RecordStatus,
                CreatedBy = applicationModule.CreatedBy,
                CreatedOn = applicationModule.CreatedOn,
                UpdatedBy = applicationModule.UpdatedBy,
                UpdatedOn = applicationModule.UpdatedOn
            };
            return applicationModuleDto;

        }
    }
}
