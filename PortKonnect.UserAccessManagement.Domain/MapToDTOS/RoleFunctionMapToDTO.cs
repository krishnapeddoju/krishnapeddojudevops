using PortKonnect.UserAccessManagement.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class RoleFunctionMapToDTO
    {
        public static List<RoleFunctionDTO> MapToDTO(this IEnumerable<RoleFunction> rolesFunctions)
        {
            List<RoleFunctionDTO> roleFunctionDtos = new List<RoleFunctionDTO>();
            if (rolesFunctions != null)
            {
                foreach (RoleFunction roleFunction in rolesFunctions)
                {
                    roleFunctionDtos.Add(roleFunction.MapToDTO());
                }
            }
            return roleFunctionDtos;
        }

        public static RoleFunctionDTO MapToDTO(this RoleFunction roleFunction)
        {
            if (roleFunction == null)
            {
                return null;
            }
            RoleFunctionDTO applicationEntityDto = new RoleFunctionDTO()
            {
                ApplicationEntityId = roleFunction.ApplicationEntityId,
				ApplicationId=roleFunction.ApplicationId,
				SubscriberId=roleFunction.SubscriberId,
                RoleId = roleFunction.RoleId,
                FunctionCode = roleFunction.FunctionCode,
                IsDeleted = roleFunction.IsDeleted,
                RecordStatus = roleFunction.RecordStatus,
                CreatedBy = roleFunction.CreatedBy,
                CreatedOn = roleFunction.CreatedOn,
                UpdatedBy = roleFunction.UpdatedBy,
                UpdatedOn = roleFunction.UpdatedOn
            };
            return applicationEntityDto;
        }
    }
}
