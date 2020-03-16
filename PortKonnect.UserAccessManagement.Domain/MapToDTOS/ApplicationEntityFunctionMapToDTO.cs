using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class ApplicationEntityFunctionMapToDTO
    {
        public static List<ApplicationEntityFunctionDTO> MapToDTO(this IEnumerable<ApplicationEntityFunction> applicationEntityFunctions)
        {
            List<ApplicationEntityFunctionDTO> applicationEntityFunctionDtos = new List<ApplicationEntityFunctionDTO>();
            if (applicationEntityFunctions != null)
            {
                foreach (ApplicationEntityFunction applicationEntityFunction in applicationEntityFunctions)
                {
                    applicationEntityFunctionDtos.Add(applicationEntityFunction.MapToDTO());
                }
            }
            return applicationEntityFunctionDtos;
        }

        public static ApplicationEntityFunctionDTO MapToDTO(this ApplicationEntityFunction applicationEntityFunction)
        {
            if (applicationEntityFunction == null)
            {
                return null;
            }
            ApplicationEntityFunctionDTO applicationEntityFunctionDto = new ApplicationEntityFunctionDTO()
            {
                ApplicationEntityId = applicationEntityFunction.ApplicationEntityId,
                FunctionCode = applicationEntityFunction.FunctionCode,
                FunctionName = applicationEntityFunction.FunctionName,
                FunctionUrl = applicationEntityFunction.FunctionUrl,
                ApiUrl = applicationEntityFunction.ApiUrl,
                IsMenuItem = applicationEntityFunction.IsMenuItem,
                Order = applicationEntityFunction.Order,
                RecordStatus = applicationEntityFunction.RecordStatus,
                CreatedBy = applicationEntityFunction.CreatedBy,
                CreatedOn = applicationEntityFunction.CreatedOn,
                UpdatedBy = applicationEntityFunction.UpdatedBy,
                UpdatedOn = applicationEntityFunction.UpdatedOn
            };
            return applicationEntityFunctionDto;
        }
    }
}
