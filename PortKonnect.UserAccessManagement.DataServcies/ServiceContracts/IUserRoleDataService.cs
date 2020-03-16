using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.DataServcies.ServiceContracts
{
	public interface IUserRoleDataService
	{
		List<UserDTO> GetUsersToAssignUserRoles(int applicationId, string subscriberId, string userId,
			string memberId, string userName, string firstName, string emailId, string contactNumber);

		List<RoleDTO> GetRolesForPartnerType(string userId, int applicationId, string memberId, string subscriberId);

		List<RoleDTO> GetRoles(string PartnerType, int applicationId, string subScriberId);

        List<UserDTO> GetAllUsersToAssignUserRoles(int applicationId, string subscriberId, string userId,
            string memberId, string userName, string firstName, string emailId, string contactNumber);
    }
}
