using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Domain.Repositories
{
    public interface IUserRoleRepository
    {
        void AddOrUpdateUserRole(User user);
    }
}
