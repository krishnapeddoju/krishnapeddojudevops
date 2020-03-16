using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.Repositories;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        public IUserContext _userContext;

        public UserRoleRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }


        public void AddOrUpdateUserRole(User user)
        {
            _userContext.Users.AddOrUpdate(user);
            _userContext.SaveChanges();
        }
    }
}
