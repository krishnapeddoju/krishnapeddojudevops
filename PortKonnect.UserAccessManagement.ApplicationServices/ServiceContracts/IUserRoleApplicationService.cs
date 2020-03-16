using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.ApplicationServices.ServiceContracts
{
    public interface IUserRoleApplicationService
    {
        void AddOrUpdateUserRole(UserDTO userDto, int applicationId);
    }
}
