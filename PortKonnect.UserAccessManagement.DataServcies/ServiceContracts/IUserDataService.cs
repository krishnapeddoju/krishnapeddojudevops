using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.Common.Domain.Model;

namespace PortKonnect.UserAccessManagement.DataServcies
{
	public interface IUserDataService
	{
		List<UserDTO> GetAllSubscribedUsers(int applicationId, string subscriberId, string userId,
			string memberId, string userName, string firstName, string lastName, string partnerType, string dormantUser);

	    UserDTO GetUserForUserId(string userId, string subscriberId, int applicationId);

       // UserDTO GetUserForUserId(string userId, string memberId, string subscriberId, int applicationId);

		List<AuthorizedFunctionDTO> GetAuthorisedUserFunctions(int applicationId, string subscriberId, string userName, string portCode, string appEntityCode);

		List<AuthorizedFunctionDTO> GetAuthorisedUserFunctions(int applicationId, string subscriberId, string userName, string portCode, string appEntityCode, List<string> appEntityFunctionCode);
		
        List<UserDTO> GetUserIdAndNames();
		
        List<UserDTO> GetUsersTobeNotified(int appId, string subscriberId, string memeberId, string roleId);
		
        List<UserDTO> GetSpecialUsersTobeNotified(int appId, string subscriberId, string roleId);
		
        EmailDetailsDTO GetEmailDetails(int appId, string subscriberId);
		
        SMSDetailsDTO GetSMSDetails(int appId, string subscriberId);

        bool CheckPartnerExist(string partnerType, string userName);

        List<UserDTO> GetAllSubscribedUsersforTO(int applicationId, string subscriberId, string userId,
            string memberId, string userName, string firstName, string lastName, string partnerType, string dormantUser);

        UserDTO GetUserForUserIdByPartnerId(string userId, string memberId, string subscriberId);

    }
}
