using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public interface IAccountService
    {
        List<MenuModuleDTO> GetMenuForUser(int applicationId, string subscriberId, string userId);
        List<MenuModuleDTO> GetMenuPrevilegesForUser(int applicationId, string subscriberId, string userId);
        List<MenuModuleDTO> GetModulesForUser(int applicationId, string subscriberId, string userId);
        string AuthenticateUser(int applicationId, string userName, string password, string subscriberId);
        ContextDTO GetUserDetails(int applicationId, string subscriberId, string userName);
        string ChangePassword(string UserName, string Password, string NewPassword, string UserId);
        string ResetPassword(int applicationId, string subscriberId, string UserName);
        string TokenServieResetPassword(int applicationId, string subscriberId, string UserName, string signin);
        UserDTO GetUserDetailsByTransId(string TransId);
        string Forgotpassword(string UserName, string Password, string NewPassword, string LogTransId);

        List<AuthorizedFunctionDTO> GetAuthorisedUserFunctionsByRoles(int applicationId, string subscriberId, string userId, string portCode, List<string> roles);

        string GetUnauthorizedUserMessages(int applicationId, string userName, string password, string subscriberId);

        #region User Authentication Data Service Functions
        List<AuthorizedFunctionDTO> GetAuthorisedUserFunctions(int applicationId, string subscriberId, string userId, string portCode, string applicationEntityId);
        List<string> GetAuthorisedUserFunctions(int applicationId, string subscriberId, string userId, string portCode);
        List<AuthorizedFunctionDTO> GetAuthorisedUserFunctions(int applicationId, string subscriberId, string userId, string portCode, string applicationEntityId, List<string> appEntityFunctionCode);

        string GetApplicationUrl(int applicationId, string subscriberId);

        #endregion

    }
}
