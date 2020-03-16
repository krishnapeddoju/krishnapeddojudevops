using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public interface IRoleRepository
    {
        void AddRole(Role role);
        IQueryable<Role> GetRoles(int applicationId, string subscriberId);
        List<RoleDTO> GetRolesForUser(int applicationId, string subscriberId, string userId);
        Role GetRolesForRoleId(string roleId,int applicationId,string subscriberId);
    }
}
