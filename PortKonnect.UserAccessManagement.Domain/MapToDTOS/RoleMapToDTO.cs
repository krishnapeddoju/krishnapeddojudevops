using PortKonnect.UserAccessManagement.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.GlobalConstants;

namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class RoleMapToDTO 
    {
        public static List<RoleDTO> MapToDTO(this IEnumerable<Role> roles)
        {
            List<RoleDTO> roleDtos = new List<RoleDTO>();
            if (roles != null)
            {
                foreach (Role role in roles)
                {
                    roleDtos.Add(role.MapToDTO());
                }
            }
            return roleDtos;
        }

        public static RoleDTO MapToDTO(this Role role)
        {
            if (role == null)
            {
                return null;
            }
            RoleDTO roleDto = new RoleDTO()
            {
                ApplicationId = role.ApplicationId,
                SubscriberId = role.SubscriberId,
                RoleId = role.RoleId,
                RoleCode = role.RoleCode,
                RoleName = role.RoleName,
                RoleFunctions = role.roleFunctions.MapToDTO(),
                PartnerTypeRoles = role.PartnerTypeRoles.MapToDTO(),
                RecordStatus = role.RecordStatus,
                CreatedBy = role.CreatedBy,
                CreatedOn = role.CreatedOn,
                UpdatedBy = role.UpdatedBy,
                UpdatedOn = role.UpdatedOn
            };
            if (roleDto.RoleFunctions.Any())
            {
                roleDto.RoleFunctionCodeArray = new List<string>();
                foreach (var roleFunc in roleDto.RoleFunctions)
                {
                    roleDto.RoleFunctionCodeArray.Add(roleFunc.FunctionCode);
                }
            }
            if (roleDto.PartnerTypeRoles.Any())
            {
                roleDto.PartnerTypeArray = new List<string>();
                foreach (var partnerType in roleDto.PartnerTypeRoles.Where(t => t.IsDeleted == UAMGlobalConstants.IsDeletedNo))
                {
                    roleDto.PartnerTypeArray.Add(partnerType.PartnerTypeId);
                }
            }
            return roleDto;
        }
    }
}
