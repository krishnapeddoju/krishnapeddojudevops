using PortKonnect.UserAccessManagement.Domain.DTOS;
using System.Collections.Generic;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public interface IUserApplicationService
    {
        void AddUser(UserDTO userDTO, ContextDTO contextDto);
        UserDTO GetUserForUserId(string userId);
        UserDTO GetUserForUserName(string userName);
		List<UserDTO> GetUsers(string UserId, int applicationId, string subscriberId);
        List<UserDTO> GetUsersForPartner(string partnerId);
        List<AppMemberDTO> GetAllSubscribedPartners(ContextDTO contextDto,string PartnerType);
        bool AuthenticateUser(int applicationId, string userName, string password);
        void UpdateUser(UserDTO userDto, ContextDTO contextDto);
        void ActivateOrDeActivateUser(string userId,string recordStatus, ContextDTO contextDto);
        List<UserDTO> GetUsersForMemberId(int appId, string subscriberId, string memeberId);
        List<UserDTO> GetUsersForMemberByRole(int appId, string subscriberId, string memeberId, string roleId);
        //List<UserDTO> GetUsersTobeNotified(int appId, string subscriberId, string memeberId, string roleId);
        List<PartnerTypeDTO> GetPartnerTypesForUser(ContextDTO contextDto);
    }
}
