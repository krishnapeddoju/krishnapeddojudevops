using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Domain.Repositories
{
    public interface IAccountRepository
    {
        //TODO:To be remove DTOs instead use Entities - TBD
        List<MenuModuleDTO> GetMenuForUser(int applicationId, string subscriberId, string userId);
        List<MenuModuleDTO> GetMenuPrevilegesForUser(int applicationId, string subscriberId, string userId);
        List<MenuModuleDTO> GetModulesForUser(int applicationId, string subscriberId, string userId);
        UserDTO GetUserByUserName(int applicationId, string userName, string subscriberId);
        ContextDTO GetUserDetails(int applicationId, string subscriberId, string userName);
        string ChangePassword(string UserName, string Password, string NewPassword, string UserId);
        string ForgotPassword(string UserName, string Password, string NewPassword, string LogTransId);
        void UpdateUserLogtime(UserDTO userDto);
        void UpdateIncorrectLogins(string userName, int applicationId);
        UserDTO CheckUser(string userName, int appId, string subscriberId);
        void UpdateUserAndChangePasswordLog(UserDTO userDto, int applicationId);
        void UpdateUserDormant(UserDTO userDto);
        UserDTO GetUserDetailsByTransId(string TransId);
        string GetApplicationUrl(int applicationid);
        string GetApplicationUrl(int applicationid, string subscriberId);
        #region User Authentication Data Service Functions
        List<AuthorizedFunctionDTO> GetAuthorisedUserFunctionsByRoles(int applicationId, string subscriberId, string userName, string portCode, List<string> roles);

        List<AuthorizedFunctionDTO> GetAuthorisedUserFunctions(int applicationId, string subscriberId, string userName, string portCode, string applicationEntityId);
        List<string> GetAuthorisedUserFunctions(int applicationId, string subscriberId, string userName, string portCode);
        List<AuthorizedFunctionDTO> GetAuthorisedUserFunctions(int applicationId, string subscriberId, string userName, string portCode, string applicationEntityId, List<string> appEntityFunctionCode);
        #endregion

    }
}
