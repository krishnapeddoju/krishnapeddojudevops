using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public interface IRoleApplicationService
    {
        void AddRole(RoleDTO role, ContextDTO contextDto);
        List<RoleDTO> GetRoles();
        List<RoleDTO> GetRolesForUser(int applicationId, string subscriberId, string userId);
    }
}
