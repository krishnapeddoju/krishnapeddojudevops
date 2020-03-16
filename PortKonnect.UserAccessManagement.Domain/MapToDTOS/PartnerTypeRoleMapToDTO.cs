using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class PartnerTypeRoleMapToDTO
    {
        public static List<PartnerTypeRoleDTO> MapToDTO(this IEnumerable<PartnerTypeRole> partnerTypeRoles)
        {
            List<PartnerTypeRoleDTO> partnerTypeRoleDtos = new List<PartnerTypeRoleDTO>();
            if (partnerTypeRoles != null)
            {
                foreach (PartnerTypeRole partnerTypeRole in partnerTypeRoles)
                {
                    partnerTypeRoleDtos.Add(partnerTypeRole.MapToDTO());
                }
            }
            return partnerTypeRoleDtos;
        }

        public static PartnerTypeRoleDTO MapToDTO(this PartnerTypeRole partnerTypeRole)
        {
            if (partnerTypeRole == null)
            {
                return null;
            }
            PartnerTypeRoleDTO partnerTypeRoleDto = new PartnerTypeRoleDTO()
            {
                RoleId = partnerTypeRole.RoleId,
                PartnerTypeId = partnerTypeRole.PartnerTypeId,
                IsDeleted = partnerTypeRole.IsDeleted
            };
            return partnerTypeRoleDto;
        }
    }
}
