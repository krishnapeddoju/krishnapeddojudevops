using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public IUserContext _userContext;

        public RoleRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }
        public void AddRole(Role role)
        {
            _userContext.Roles.AddOrUpdate(role);
            _userContext.SaveChanges();
        }

        public IQueryable<Role> GetRoles(int applicationId, string subscriberId)
        {
            var roles = (from r in _userContext.Roles
                         where r.ApplicationId.Equals(applicationId) && r.SubscriberId.Equals(subscriberId)
                         select r);
            return roles;
        }

        public List<RoleDTO> GetRolesForUser(int applicationId, string subscriberId, string userId)
        {
            throw new NotImplementedException();
        }

        public Role GetRolesForRoleId(string roleId,int applicationId,string subscriberId)
        {
			Role role = (from r in _userContext.Roles
						 //join rf in _userContext.RoleFunctions on new { r.RoleId, r.ApplicationId } equals new { rf.RoleId, rf.ApplicationId }
						 where r.RoleId.Equals(roleId) && r.ApplicationId.Equals(applicationId) && r.SubscriberId.Equals(subscriberId)
						 select r).FirstOrDefault();

			return role;
        }
    }
}
 