using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.DataServcies.ServiceContracts
{
    public interface IRoleDataService
    {
        RoleDTO GetRoleForRoleId(int appId, string roleId, string subscriberId, string userId);
        List<RoleDTO> GetRoles(ContextDTO contextDto);
    }
}
