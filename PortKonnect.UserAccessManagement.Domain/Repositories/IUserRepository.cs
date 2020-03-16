using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUserForUserId(string userId);
        UserDTO GetUserForUserName(string userName);
		List<UserDTO> GetUsers(string UserId, int applicationId, string subscriberId);
        List<UserDTO> GetUsersForPartner(string partnerId);
        
        List<AppMemberDTO> GetAllSubscribedPartners(int applicationId, string subscriberId,string partnerType);
        int GetUsersForUserNameOtherThanUserId(string userId, string userName);
        void UpdateUser(User user);
        bool AuthenticateUser(int applicationId, string userName, string password);
        List<User> GetUsersForMemberId(int appId, string subscriberId, string memeberId);
        List<User> GetUsersForMemberByRole(int appId, string subscriberId, string memeberId,string roleId);
        //List<User> GetUsersTobeNotified(int appId, string subscriberId, string memeberId, string roleId);
        List<PartnerTypeDTO> GetPartnerTypesForUser(ContextDTO contextDto);
        User GetUserByUserName(string userName);
        User GetUserByPartnerid(string Partnerid);
    }
}
