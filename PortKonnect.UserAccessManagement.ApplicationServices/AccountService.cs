using System;
using System.Collections.Generic;
using System.Configuration;
using PortKonnect.Common.Enums;
using PortKonnect.Common.Exceptions;
using PortKonnect.Common.Services;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.Repositories;
using PortKonnect.UserAccessManagement.GlobalConstants;
using PortKonnect.Common.Contracts;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    //TODO:Any User table updations should happen through UserRepository only

    public class AccountService : ServiceBase, IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService()
        {
        }
        public AccountService(IUserContext userContext, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            UserContext = userContext;
        }

        public List<MenuModuleDTO> GetMenuForUser(int applicationId, string subscriberId, string userId)
        {
            return ExecuteFaultHandledOperation(() => _accountRepository.GetMenuForUser(applicationId, subscriberId, userId));
        }

        public List<MenuModuleDTO> GetMenuPrevilegesForUser(int applicationId, string subscriberId, string userId)
        {
            return ExecuteFaultHandledOperation(() => _accountRepository.GetMenuPrevilegesForUser(applicationId, subscriberId, userId));
        }
        public List<MenuModuleDTO> GetModulesForUser(int applicationId, string subscriberId, string userId)
        {
            return ExecuteFaultHandledOperation(() => _accountRepository.GetModulesForUser(applicationId, subscriberId, userId));
        }


        public string AuthenticateUser(int applicationId, string userName, string password, string subscriberId)
        {

            return ExecuteFaultHandledOperationWithoutToken(() =>
            {
                UserDTO userDto = _accountRepository.GetUserByUserName(applicationId, userName, subscriberId);

                if (userDto != null && userDto.Password == password)
                {
                    DateTime LogTime = Convert.ToDateTime(userDto.LogTime);
                    LogTime = LogTime.AddDays(UAMGlobalConstants.DormantDays);

                    //2. Inactive or Dormant User validation
                    if (userDto.RecordStatus == UAMGlobalConstants.RecordStatusInactive ||
                        userDto.DormantStatus == UAMGlobalConstants.IsDormantYes ||
                        userDto.IsDeleted == UAMGlobalConstants.IsDeletedYes)
                    {
                        return BusinessExceptions.InactiveUser;
                    }

                    //3. Password Expiry Validation - Validfrom and ValidTodate to be Done

                    //4. Login Time Validation (Current time should be greaterthan or equal to the Login time or Login Time is null)
                    if (DateTime.Now >= userDto.PwdExpiryDate)
                    {
                        return BusinessExceptions.PassWordExpired;
                    }

                    //Review if try to log in after 3 in correct logins 
                    var numberofInCorrectLogins = Convert.ToInt32(ConfigurationManager.AppSettings["NumberofInCorrectLogins"] ?? UAMGlobalConstants.NumberofInCorrectLogins.ToString());
                    if (userDto.InCorrectLogins >= numberofInCorrectLogins)
                    {
                        var invalidAttemptswaitMinutes = -1 * (Convert.ToInt32(ConfigurationManager.AppSettings["InvalidAttemptswaitMinutes"] ?? UAMGlobalConstants.InvalidAttemptswaitMinutes.ToString()));
                        if (userDto.LogTime > DateTime.Now.AddMinutes(invalidAttemptswaitMinutes))
                        {
                            var timeDiff = Convert.ToDateTime(userDto.LogTime).Subtract(DateTime.Now.AddMinutes(invalidAttemptswaitMinutes));
                            var totalMinDiff = Convert.ToInt32(timeDiff.TotalMinutes);
                            if (totalMinDiff > 0)
                            {
                                return BusinessExceptions.LogTimeMsg + UAMGlobalConstants.SpaceConstant + totalMinDiff + UAMGlobalConstants.SpaceConstant + UAMGlobalConstants.Minutes;
                            }
                        }
                    }
                    //ValidToDate Validation
                    if (userDto.validToDate < DateTime.Now)
                    {
                        return BusinessExceptions.ValidToDateValidation;
                    }
                    //For review
                    //Making user to doramnt if try to login after 90days
                    if (userDto.LogTime != null && LogTime <= DateTime.Now)
                    {
                        userDto.DormantStatus = UAMGlobalConstants.IsDormantYes;
                        _accountRepository.UpdateUserDormant(userDto);
                        return BusinessExceptions.DormantStatus;
                    }
                    //After successfull login Update Logtime & Reset the Incorrectlogins (if any) in Application Layer
                    userDto.InCorrectLogins = 0;
                    userDto.LogTime = DateTime.Now;
                    _accountRepository.UpdateUserLogtime(userDto);
                    return UAMGlobalConstants.Success;
                }
                else
                {
                    if (userDto != null && userDto.Password != password)
                    {
                        userDto.InCorrectLogins = userDto.InCorrectLogins + 1;
                        userDto.LogTime = DateTime.Now;
                        _accountRepository.UpdateUserLogtime(userDto);
                        if (userDto.InCorrectLogins-1 > 1)
                            return BusinessExceptions.InvalidCredentials + UAMGlobalConstants.YouHaveMade + userDto.InCorrectLogins + UAMGlobalConstants.UnsuccessfulAttempts;
                    }
                    return BusinessExceptions.InvalidCredentials;
                }
            });

        }

        public string ResetPassword(int applicationId, string subscriberId, string UserName)
        {
            return EncloseTransactionAndHandleException(() =>
            {
                string msg = string.Empty;
                UserDTO user = _accountRepository.CheckUser(UserName, applicationId, subscriberId);
                if (user != null)
                {
                    user.NewPassword = PasswordDataService.Encrypt(PasswordDataService.Generate(), true);
                    _accountRepository.UpdateUserAndChangePasswordLog(user, applicationId);

                    #region Sending Email Notification
                    //string url = ConfigurationManager.AppSettings["hostingurl"];
                    string url = _accountRepository.GetApplicationUrl(applicationId, subscriberId);

                    url += "/Account/ForgotPassword/" + user.LogTransId;
                    user.ForgetPasswordLink = url;
                    _log.Debug("ResetPassword - method invoked " + subscriberId);
                    SendNotification(applicationId, subscriberId, user.PartnerId,
                        CargoAppEntityCodes.cargoUser.ToString(), CargoAppEntityCodes.cargoUserForgotPassword.ToString(), user.UserId,
                        null, user.UserId, user);
                    #endregion

                    msg = UAMGlobalConstants.Success;

                    return msg;
                }
                else
                {
                    msg = BusinessExceptions.InvalidUserName;
                    return msg;

                }
            });
        }

        public string TokenServieResetPassword(int applicationId, string subscriberId, string UserName, string signin)
        {
            return EncloseTransactionAndHandleException(() =>
            {
                string msg = string.Empty;
                string url = string.Empty;
               
                UserDTO user = _accountRepository.CheckUser(UserName, applicationId, subscriberId);
                if (user != null)
                {
                    if (user.UserName.ToUpper() != "ADMIN")
                    {
                        user.NewPassword = PasswordDataService.Encrypt(PasswordDataService.Generate(), true);
                        _accountRepository.UpdateUserAndChangePasswordLog(user, applicationId);

                        #region Sending Email Notification
                        url = ConfigurationManager.AppSettings["TokenServiceURL"];
                        if (string.IsNullOrEmpty(signin))
                        {
                            url += "UserAccount/ChangePassword?LogTransId=" + user.LogTransId;
                        }
                        else
                        {
                            url += "UserAccount/ForgotPassword?LogTransId=" + user.LogTransId + "&signin=" + signin;
                        }

                        user.ForgetPasswordLink = url;
                        SendNotification(applicationId, subscriberId, user.PartnerId,
                            CargoAppEntityCodes.cargoUser.ToString(), CargoAppEntityCodes.cargoUserForgotPassword.ToString(), user.UserId,
                            null, user.UserId, user);

                        #endregion

                        msg = UAMGlobalConstants.Success;

                        return msg;
                    }

                    msg = UAMGlobalConstants.UnauthorizedCredentials;
                    return msg;
                }
                else
                {
                    msg = BusinessExceptions.InvalidUserName;
                    return msg;

                }
            });
        }

        public string GetUnauthorizedUserMessages(int applicationId, string userName, string password, string subscriberId)
        {
            string userStatus = string.Empty;
            UserDTO userDto = _accountRepository.GetUserByUserName(applicationId, userName, subscriberId);

            if (userDto != null && userDto.Password == password)
            {
                DateTime logTime = Convert.ToDateTime(userDto.LogTime);
                logTime = logTime.AddDays(UAMGlobalConstants.DormantDays);

                //2. Inactive or Dormant User validation
                if (userDto.RecordStatus == UAMGlobalConstants.RecordStatusInactive ||
                    userDto.DormantStatus == UAMGlobalConstants.IsDormantYes ||
                    userDto.IsDeleted == UAMGlobalConstants.IsDeletedYes)
                {
                    userStatus = BusinessExceptions.InactiveUser;
                }

                //3. Password Expiry Validation - Validfrom and ValidTodate to be Done

                //4. Login Time Validation (Current time should be greaterthan or equal to the Login time or Login Time is null)
                if (DateTime.Now >= userDto.PwdExpiryDate)
                {
                    userStatus = BusinessExceptions.PassWordExpired;
                }

                //Review if try to log in after 3 in correct logins 
                var numberofInCorrectLogins = Convert.ToInt32(ConfigurationManager.AppSettings["NumberofInCorrectLogins"] ?? UAMGlobalConstants.NumberofInCorrectLogins.ToString());
                if (userDto.InCorrectLogins >= numberofInCorrectLogins)
                {
                    var invalidAttemptswaitMinutes = -1 * (Convert.ToInt32(ConfigurationManager.AppSettings["InvalidAttemptswaitMinutes"] ?? UAMGlobalConstants.InvalidAttemptswaitMinutes.ToString()));
                    if (userDto.LogTime > DateTime.Now.AddMinutes(invalidAttemptswaitMinutes))
                    {
                        var timeDiff = Convert.ToDateTime(userDto.LogTime).Subtract(DateTime.Now.AddMinutes(invalidAttemptswaitMinutes));
                        var totalMinDiff = Convert.ToInt32(timeDiff.TotalMinutes);
                        if (totalMinDiff > 0)
                        {
                            userStatus = BusinessExceptions.LogTimeMsg + UAMGlobalConstants.SpaceConstant + totalMinDiff + UAMGlobalConstants.SpaceConstant + UAMGlobalConstants.Minutes;
                        }
                    }
                }
                //ValidToDate Validation
                if (userDto.validToDate < DateTime.Now)
                {
                    userStatus = BusinessExceptions.ValidToDateValidation;
                }
                //For review
                //Making user to doramnt if try to login after 90days
                if (userDto.LogTime != null && logTime <= DateTime.Now)
                {
                    userDto.DormantStatus = UAMGlobalConstants.IsDormantYes;
                    _accountRepository.UpdateUserDormant(userDto);
                    userStatus = BusinessExceptions.DormantStatus;
                }
            }
            else
            {
                if (userDto != null && userDto.Password != password)
                {
                    if (userDto.InCorrectLogins > 1)
                        userStatus = BusinessExceptions.InvalidCredentials + UAMGlobalConstants.YouHaveMade + userDto.InCorrectLogins + UAMGlobalConstants.UnsuccessfulAttempts;
                    else
                        userStatus = BusinessExceptions.InvalidCredentials;
                }
            }
            return string.IsNullOrEmpty(userStatus) ? UAMGlobalConstants.RecordStatus : userStatus; 
        }

        public UserDTO GetUserDetailsByTransId(string TransId)
        {
            return ExecuteFaultHandledOperation(() => _accountRepository.GetUserDetailsByTransId(TransId));
        }

        public ContextDTO GetUserDetails(int applicationId, string subscriberId, string userName)
        {
            return ExecuteFaultHandledOperationWithoutToken(() => _accountRepository.GetUserDetails(applicationId, subscriberId, userName));
        }


        public string ChangePassword(string UserName, string Password, string NewPassword, string UserId)
        {
            return EncloseTransactionAndHandleException(() => _accountRepository.ChangePassword(UserName, Password, NewPassword, UserId));
        }

        public string Forgotpassword(string UserName, string Password, string NewPassword, string LogTransId)
        {
            return EncloseTransactionAndHandleException(() => _accountRepository.ForgotPassword(UserName, Password, NewPassword, LogTransId));
        }

        #region User Authentication Data Service Functions
        public List<AuthorizedFunctionDTO> GetAuthorisedUserFunctionsByRoles(int applicationId, string subscriberId, string userId, string portCode, List<string> roles)
        {
            return ExecuteFaultHandledOperationWithoutToken(() => _accountRepository.GetAuthorisedUserFunctionsByRoles(applicationId, subscriberId, userId, portCode,
                roles));
        }
        public List<AuthorizedFunctionDTO> GetAuthorisedUserFunctions(int applicationId, string subscriberId, string userId, string portCode, string applicationEntityId)
        {
            return ExecuteFaultHandledOperation(() => _accountRepository.GetAuthorisedUserFunctions(applicationId, subscriberId, userId, portCode,
                applicationEntityId));
        }
        public List<AuthorizedFunctionDTO> GetAuthorisedUserFunctions(int applicationId, string subscriberId, string userId, string portCode, string applicationEntityId, List<string> appEntityFunctionCode)
        {
            return ExecuteFaultHandledOperation(() => _accountRepository.GetAuthorisedUserFunctions(applicationId, subscriberId, userId, portCode, applicationEntityId, appEntityFunctionCode));
        }

        public List<string> GetAuthorisedUserFunctions(int applicationId, string subscriberId, string userId, string portCode)
        {
            return ExecuteFaultHandledOperation(() => _accountRepository.GetAuthorisedUserFunctions(applicationId, subscriberId, userId, portCode));
        }
        #endregion

        public string GetApplicationUrl(int applicationId, string subscriberId)
        {
            return ExecuteFaultHandledOperation(() => _accountRepository.GetApplicationUrl(applicationId, subscriberId));
        }
    }
}
