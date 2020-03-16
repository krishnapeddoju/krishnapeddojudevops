using PortKonnect.UserAccessManagement.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class UserRoleMapToDTO
    {
        public static List<UserRoleDTO> MapToDTO(this IEnumerable<UserRole> userRoles)
        {
            List<UserRoleDTO> userRoleDtos = new List<UserRoleDTO>();
            if (userRoles != null)
            {
                foreach (UserRole item in userRoles)
                {
                    userRoleDtos.Add(item.MapToDTO());
                }
            }
            return userRoleDtos;
        }

        public static UserRoleDTO MapToDTO(this UserRole userRole)
        {
            UserRoleDTO dto = new UserRoleDTO();
            if (userRole != null)
            {
                dto.SubscriberId = userRole.SubscriberId;
                dto.ApplicationId = userRole.ApplicationId;
                dto.RoleId = userRole.RoleId;
                dto.UserId = userRole.UserId;
                dto.RecordStatus = userRole.RecordStatus;
                dto.CreatedBy = userRole.CreatedBy;
                dto.CreatedOn = userRole.CreatedOn;
                dto.UpdatedBy = userRole.UpdatedBy;
                dto.UpdatedOn = userRole.UpdatedOn;
                dto.IsDeleted = userRole.IsDeleted;
            }
            return dto;
        }
    }
}
