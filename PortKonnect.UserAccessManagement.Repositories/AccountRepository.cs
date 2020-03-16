using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using PortKonnect.Common.Exceptions;
using PortKonnect.Common.Services;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.MapToDTOS;
using PortKonnect.UserAccessManagement.Domain.Repositories;
using PortKonnect.UserAccessManagement.GlobalConstants;

namespace PortKonnect.UserAccessManagement.Repositories
{
    //TODO:Any User table updations should happen through UserRepository only
    public class AccountRepository : IAccountRepository
    {
        private readonly IUserContext _userContext;
        public AccountRepository()
        {

        }
        public AccountRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }


        public List<MenuModuleDTO> GetMenuForUser(int applicationId, string subscriberId, string userId)
        {

            List<ModulesEntityFunction> modulesEntityFunctions = (from m in _userContext.ModulesEntityFunctions.Where(m => m.ApplicationId == applicationId && m.IsMenuItem == "Y") select m).Distinct().ToList();
           
            return GetMenuPrivileges(applicationId, subscriberId, userId, modulesEntityFunctions);
        }

        public List<MenuModuleDTO> GetMenuPrevilegesForUser(int applicationId, string subscriberId, string userId)
        {

            List<ModulesEntityFunction> modulesEntityFunctions = (from m in _userContext.ModulesEntityFunctions.Where(m => m.ApplicationId == applicationId) select m).Distinct().ToList();

            return GetMenuPrivileges(applicationId, subscriberId, userId, modulesEntityFunctions);
        }

        public List<MenuModuleDTO> GetModulesForUser(int applicationId, string subscriberId, string userId)
        {

            var adminUser = GetUserByUserName(applicationId, "Admin", subscriberId);
            var isCurrentUserAdmin = userId == adminUser.UserId;

            var assignedModules = isCurrentUserAdmin ? new List<string>() : (from m in _userContext.RoleFunctions.Where(m => m.ApplicationId == applicationId && m.SubscriberId == subscriberId && m.IsDeleted == "N")
                                                                             join ur in _userContext.UserRoles on m.RoleId equals ur.RoleId
                                                                             where ur.UserId == userId && ur.IsDeleted == "N"
                                                                             select m.ApplicationEntityId).Distinct().ToList();

            List<ModulesEntityFunction> modulesEntityFunctions = (from m in _userContext.ModulesEntityFunctions.Where(m => m.ApplicationId == applicationId
                                                                  && m.IsMenuItem == "Y" && (isCurrentUserAdmin ? true : assignedModules.Contains(m.ApplicationEntityId)))
                                                                  select m).Distinct().ToList();
            
            List<MenuModuleDTO> moduleCodes =
                (from m in modulesEntityFunctions
                 select new MenuModuleDTO()
                 {
                     ModuleId = m.ModuleCode,
                     ModuleName = m.ModuleName,
                     ModuleIcon = m.ModuleIcon,
                     ModuleUrl = m.ModuleUrl
                 }).ToList();

            moduleCodes = moduleCodes
                .GroupBy(m => m.ModuleId)
                .Select(m => m.FirstOrDefault())
                .ToList();
           
            return moduleCodes;
        }

        public UserDTO GetUserByUserName(int applicationId, string userName, string subscriberId)
        {
            User user = (from u in _userContext.Users.Where(u => u.UserName.ToUpper() == userName.ToUpper())
                         join p in _userContext.Partners on u.PartnerId equals p.PartnerId
                         join sm in _userContext.SubscriptionMembers on p.PartnerId equals sm.MemberId
                         where sm.ApplicationId == applicationId && u.UserRoles.Any(c=>c.SubscriberId==subscriberId)
                         select u).FirstOrDefault();


            if (user != null)
            {
                user.ApplicationId = applicationId;
            }

            return user.MapToDto();
        }

        public ContextDTO GetUserDetails(int applicationId, string subscriberId, string userName)
        {
            IQueryable<ContextDTO> user =
                (from u in _userContext.Users
                 join p in _userContext.Partners on u.PartnerId equals p.PartnerId
                 join s in _userContext.SubscriptionMembers on u.PartnerId equals s.MemberId
                 where u.UserName.ToUpper() == userName.ToUpper() && s.ApplicationId == applicationId && s.PartnerId == subscriberId &&  u.UserRoles.Any(c => c.SubscriberId == subscriberId)
                 select new ContextDTO
                 {
                     UserId = u.UserId,
                     UserName = u.UserName,
                     PortCode = u.UserPorts.FirstOrDefault().PortCode, //TODO:Present one user having one port access
                     ApplicationId = s.ApplicationId,
                     SubscriberId = s.PartnerId,
                     PartnerLogo = p.PartnerAddress.Logopath,
                     MemberId = u.PartnerId,
                     PartnerType = u.PartnerType,
                     MemberType = p.PartnerType,
                     MemberCode = p.PartnerCode,
                     IsFirstTimeLogin = u.IsFirstTimeLogin,
                     Email =u.EmailId,
                     Name =u.FirstName,                   
                 });
            var userContext = user.FirstOrDefault();
            if (userContext != null)
            {
                var partnerTypes = (from a in _userContext.PartnerTypes
                                    where a.PartnerId == userContext.MemberId
                                    select new PartnerTypeDTO
                                    {
                                        PartnerTypeName = a.partnerTypeName

                                    }).ToList();

                userContext.PartnerTypes = string.Join(",", partnerTypes.Select(a => a.PartnerTypeName).ToArray());

                var userRoles = (from a in _userContext.UserRoles
                                 where a.UserId == userContext.UserId
                                 select new UserRoleDTO()
                                 {
                                     RoleId = a.RoleId

                                 }).ToList();
                userContext.UserRoles = string.Join(",", userRoles.Select(a => a.RoleId).ToArray());

            }

            if (userContext != null)
            {
                if (userContext.PartnerType != null)
                {
                    userContext.MemberType = userContext.PartnerType;

                }

            }

            return userContext;
        }

        #region User Authentication Data Service Functions
        public List<AuthorizedFunctionDTO> GetAuthorisedUserFunctionsByRoles(int applicationId, string subscriberId, string userName, string portCode, List<string> roles)
        {
            List<AuthorizedFunctionDTO> userMenuFunctions = new List<AuthorizedFunctionDTO>();

            foreach (string role in roles)
            {
                List<AuthorizedFunctionDTO> functionalist =
                (from u in
                    _userContext.UserRoleEntityFunctions.Where(
                        u => u.ApplicationId == applicationId && u.SubscriberId == subscriberId && u.UserId == userName && u.RoleId== role)
                 select new AuthorizedFunctionDTO()
                 {
                     FunctionCode = u.FunctionCode,
                     AppEntityCode = u.ApplicationEntityId
                 }).ToList();
                
                foreach(var function in functionalist)
                {
                    userMenuFunctions.Add(function);
                }                              
            }
            userMenuFunctions.Distinct().ToList();

            //IQueryable<AuthorizedFunctionDTO> userMenuFunctions =
            //    from u in
            //        _userContext.UserMenuFunctions.Where(
            //            u => u.ApplicationId == applicationId && u.PartnerId == subscriberId && u.UserName == userName && u.RoleName == roles[0])
            //    select new AuthorizedFunctionDTO()
            //    {
            //        FunctionCode = u.FunctionCode,
            //        FunctionName = u.FunctionName,
            //        AppEntityCode = u.ApplicationEntityId

            //    };

            return userMenuFunctions;
        }

        public List<AuthorizedFunctionDTO> GetAuthorisedUserFunctions(int applicationId, string subscriberId, string userName, string portCode, string applicationEntityId)
        {
            IQueryable<AuthorizedFunctionDTO> userMenuFunctions =
                from u in
                    _userContext.UserMenuFunctions.Where(
                        u => u.ApplicationId == applicationId && u.SubscriberId == subscriberId && u.UserName == userName && u.ApplicationEntityId == applicationEntityId)
                select new AuthorizedFunctionDTO()
                {
                    FunctionCode = u.FunctionCode,
                    FunctionName = u.FunctionName,
                    AppEntityCode = u.ApplicationEntityId

                };

            return userMenuFunctions.ToList();
        }
        public List<AuthorizedFunctionDTO> GetAuthorisedUserFunctions(int applicationId, string subscriberId, string userName, string portCode, string applicationEntityId, List<string> appEntityFunctionCode)
        {
            IQueryable<AuthorizedFunctionDTO> userMenuFunctions =
                from u in
                    _userContext.UserMenuFunctions.Where(
                        u => u.ApplicationId == applicationId && 
                        u.SubscriberId == subscriberId && 
                        u.UserName == userName && 
                        (u.ApplicationEntityId == applicationEntityId || (applicationEntityId.EndsWith("-") && u.ApplicationEntityId.Contains(applicationEntityId.Replace("-", "")))) && 
                        appEntityFunctionCode.Any(l => u.FunctionCode == l))
                select new AuthorizedFunctionDTO()
                {
                    FunctionCode = u.FunctionCode,
                    FunctionName = u.FunctionName,
                    AppEntityCode = u.ApplicationEntityId

                };
            return userMenuFunctions.ToList();
        }
       
        #endregion

        //Update user dormant after trying to login 90days
        public void UpdateUserDormant(UserDTO userDto)
        {
            User user = (from u in _userContext.Users.Where(t => t.UserId == userDto.UserId) select u).FirstOrDefault();
            userDto.DormantStatus = UAMGlobalConstants.IsDeletedYes;
            user.UpdateDormantStatus(userDto.DormantStatus, user.UserId,user.PwdExpiryDate,user.ValidToDate,user.LogTime,user.InCorrectLogins);
            _userContext.Users.AddOrUpdate(user);
            _userContext.SaveChanges();


        }

        public void UpdateUserAndChangePasswordLog(UserDTO userDto, int applicationId)
        {
            //TODO: Use Username, ApplicationId, MemberId as Parameters instead of UserDTO

            User user = (from u in _userContext.Users.Where(t => t.UserName == userDto.UserName)
                         join p in _userContext.Partners on u.PartnerId equals p.PartnerId
                         join sm in _userContext.SubscriptionMembers on p.PartnerId equals sm.MemberId
                         where sm.ApplicationId == applicationId
                         select u).FirstOrDefault();
            user.SubscriberId = (from u in _userContext.SubscriptionMembers.Where(t => t.MemberId == user.PartnerId && t.RecordStatus == UAMGlobalConstants.RecordStatus) select u.PartnerId).FirstOrDefault();
            DateTime pwdexp = DateTime.Now;
            DateTime expiry = pwdexp.AddDays(UAMGlobalConstants.PasswordExpiryDays);
            userDto.Password = user.Password;
            user.UpdateChangePassword(userDto.UserId, userDto.NewPassword, expiry, UAMGlobalConstants.IsFirstTimeLogin);
            _userContext.Users.AddOrUpdate(user);
            string logTransactionId = Guid.NewGuid().ToString();
            ChangePasswordLog changepasswordLog = new ChangePasswordLog(logTransactionId, user.UserId, userDto.Password, userDto.NewPassword, DateTime.Now, UAMGlobalConstants.IsDeletedNo, DateTime.Now, user.UserId, DateTime.Now, user.UserId);
            _userContext.ChangePasswordLogs.AddOrUpdate(changepasswordLog);
            _userContext.SaveChanges();
            userDto.LogTransId = logTransactionId;
        }

        public void UpdateUserLogtime(UserDTO userDto)
        {
            User user = (from u in _userContext.Users.Where(t => t.UserName == userDto.UserName) select u).FirstOrDefault();
            //TODO:user object to be validated 
            user.UpdateLogTimeAndIncorrectLogins(userDto.UserId, userDto.LogTime, userDto.InCorrectLogins);

            _userContext.Users.AddOrUpdate(user);
            _userContext.SaveChanges();

        }

        public UserDTO CheckUser(string userName, int appId, string subscriberId)
        {
            User user = (from u in _userContext.Users.Where(t => t.UserName.ToLower() == userName.ToLower())
                         join p in _userContext.Partners on u.PartnerId equals p.PartnerId
                         join sm in _userContext.SubscriptionMembers on p.PartnerId equals sm.MemberId
                         where sm.ApplicationId == appId && sm.PartnerId == subscriberId
                         select u).FirstOrDefault();

            UserDTO userDto = user.MapToDto();
            if(userDto!=null){
            userDto.ApplicationId = appId;
            userDto.SubscriberId = subscriberId;
            }
            return userDto;
        }

        public UserDTO GetUserDetailsByTransId(string LogTranId)
        {
            string userId = (from u in _userContext.ChangePasswordLogs.Where(t => t.LogTransactionId == LogTranId && t.IsDelete == UAMGlobalConstants.IsDeletedNo) select u.UserId).FirstOrDefault();

            if (!String.IsNullOrEmpty(userId))
            {

                UserDTO userDto = (from u in _userContext.Users.Where(t => t.UserId == userId && t.IsDeleted == UAMGlobalConstants.IsDeletedNo && t.RecordStatus == UAMGlobalConstants.RecordStatus)
                                   join p in _userContext.Partners on u.PartnerId equals p.PartnerId
                                   join sm in _userContext.SubscriptionMembers on p.PartnerId equals sm.MemberId

                                   select new UserDTO
                                   {
                                       UserId = u.UserId,
                                       UserName = u.UserName,
                                       Password = u.Password,
                                       FirstName = u.FirstName,
                                       LastName = u.LastName,
                                       InCorrectLogins = u.InCorrectLogins,
                                       RecordStatus = u.RecordStatus,
                                       ApplicationId = sm.ApplicationId
                                   }).FirstOrDefault();



                if (userDto != null)
                {
                    userDto.Password = PasswordDataService.Decrypt(userDto.Password, true);
                }
                return userDto;
            }
            return null;
        }

        public void UpdateIncorrectLogins(string userName, int applicationId)
        {
            User user = (from u in _userContext.Users.Where(t => t.UserName == userName)
                         join p in _userContext.Partners on u.PartnerId equals p.PartnerId
                         join sm in _userContext.SubscriptionMembers on p.PartnerId equals sm.PartnerId
                         where sm.ApplicationId == applicationId
                         select u).FirstOrDefault();

            if (user != null)
            {
                int incorrectLogins = user.InCorrectLogins + 1;
                if (incorrectLogins == UAMGlobalConstants.NumberofInCorrectLogins)
                {
                    UserDTO userDto = user.MapToDto();
                    userDto.LogTime = DateTime.Now.AddMinutes(UAMGlobalConstants.InvalidAttemptswaitMinutes);
                    user.UpdateLogTime(user.UserId, userDto.LogTime);
                    //user.ChangeRecordStatus(user.UserId, UAMGlobalConstants.IsDeletedYes);
                }
                user.UpdateIncorrectLogin(user.UserId, incorrectLogins);
                _userContext.Users.AddOrUpdate(user);
                _userContext.SaveChanges();
            }

        }


        public string ChangePassword(string UserName, string Password, string NewPassword, string UserId)
        {
            User user = (from u in _userContext.Users.Where(t => t.UserName.ToLower() == UserName.ToLower() && t.Password == Password) select u).FirstOrDefault();
            string msg = string.Empty;
            if (user != null)
            {
                List<User> currentPasswordList = _userContext.Users.Where(t => t.UserId == UserId && t.Password == NewPassword).ToList();
                if (!currentPasswordList.Any())
                {
                    string validateMsg = checkChangedPasswords(UserId, NewPassword);
                    if (validateMsg != string.Empty)
                    {

                        return validateMsg;
                    }

                    DateTime pwdexp = DateTime.Now;
                    DateTime expiry = pwdexp.AddDays(UAMGlobalConstants.PasswordExpiryDays);
                    user.UpdateChangePassword(user.UserId, NewPassword, expiry, UAMGlobalConstants.IsFirstTimeLogedin);
                    _userContext.Users.AddOrUpdate(user);
                    string logTransactionId = Guid.NewGuid().ToString();
                    ChangePasswordLog changepasswordLog = new ChangePasswordLog(logTransactionId, UserId, Password, NewPassword, DateTime.Now, UAMGlobalConstants.IsDeletedNo, DateTime.Now, UserId, DateTime.Now, UserId);
                    _userContext.ChangePasswordLogs.AddOrUpdate(changepasswordLog);
                    _userContext.SaveChanges();
                    return msg = UAMGlobalConstants.Success;

                }
                else
                {
                    return msg = UAMGlobalConstants.CurrentNewPwdRestirction;
                }
            }
            else
            {
                return msg = UAMGlobalConstants.CurrentPwdRestirction;
            }

        }

        public string ForgotPassword(string UserName, string Password, string NewPassword, string LogTransId)
        {
            ChangePasswordLog changePasswordLog = (from c in _userContext.ChangePasswordLogs.Where(t => t.LogTransactionId == LogTransId && t.IsDelete == UAMGlobalConstants.IsDeletedNo) select c).FirstOrDefault();
            string msg = string.Empty;
            if (changePasswordLog != null)
            {
                List<User> currentPasswordList = _userContext.Users.Where(t => t.UserId == changePasswordLog.UserId && t.Password == NewPassword).ToList();
                if (!currentPasswordList.Any())
                {
                    string validateMsg = checkChangedPasswords(changePasswordLog.UserId, NewPassword);
                    if (validateMsg != string.Empty)
                    {

                        return validateMsg;
                    }

                    try
                    {
                        changePasswordLog.UpdateIsDelete(UAMGlobalConstants.IsDeletedYes, changePasswordLog.LogTransactionId);
                        _userContext.ChangePasswordLogs.AddOrUpdate(changePasswordLog);
                        User user = (from u in _userContext.Users.Where(t => t.UserId == changePasswordLog.UserId) select u).FirstOrDefault();
                        DateTime date = DateTime.Now.AddDays(UAMGlobalConstants.PasswordExpiryDays);
                        user.UpdatePasswordDetails(NewPassword, UAMGlobalConstants.InCorrectLogins, UAMGlobalConstants.RecordStatus, UAMGlobalConstants.IsDeletedNo, user.UserId, date, UAMGlobalConstants.IsFirstTimeLogedin);
                        _userContext.Users.AddOrUpdate(user);
                        _userContext.SaveChanges();
                        msg = UAMGlobalConstants.Success;
                        return msg;
                    }
                    catch (Exception ex)
                    {

                        return msg = ex.Message;
                    }
                }
                else
                {
                    msg = UAMGlobalConstants.CurrentNewPwdRestirction;

                }
            }
            else
            {

                return msg = BusinessExceptions.InternalServerErrorMessage;

            }
            return msg;


        }


        private string checkChangedPasswords(string userId, string NewPassword)
        {
            string msg = string.Empty;
            var changePasswordList = (from c in _userContext.ChangePasswordLogs.Where(t => t.UserId == userId) orderby c.CreatedOn descending select new { OldPassword = c.OldPassword }).Take(UAMGlobalConstants.PreviousPasswordCount);
            if (changePasswordList.Any())
            {
                foreach (var item in changePasswordList)
                {
                    if (item.OldPassword == NewPassword)
                    {
                        return msg = UAMGlobalConstants.PasswordCheckValidation;
                    }
                }
            }
            return msg;
        }

        public string GetApplicationUrl(int applicationid)
        {
            var url = (from ap in _userContext.Applications.Where(t => t.ApplicationId == applicationid) select ap.ApplicationUrl).FirstOrDefault();
            return url.ToString();
        }

        public string GetApplicationUrl(int applicationid, string subscriberId)
        {
            var url = (from ap in _userContext.Subscriptions.Where(t => t.ApplicationId == applicationid && t.PartnerId==subscriberId) select ap.WebsiteUrl).FirstOrDefault();
            return url.ToString();
        }

        public List<string> GetAuthorisedUserFunctions(int applicationId, string subscriberId, string userName, string portCode)
        {
            return _userContext.UserMenuFunctions.Where(u => u.ApplicationId == applicationId && u.SubscriberId == subscriberId && u.UserId == userName).Select(c=>c.FunctionCode).ToList();
        }


        private List<MenuModuleDTO> GetMenuPrivileges(int applicationId, string subscriberId, string userId, List<ModulesEntityFunction> modulesEntityFunctions)
        {
            List<MenuModuleDTO> menuModules = new List<MenuModuleDTO>();
            var adminUser = GetUserByUserName(applicationId, "Admin", subscriberId);
            var isCurrentUserAdmin = userId == adminUser.UserId;

            List<UserRoleEntityFunction> userRoleEntityFunctions =
                (from u in
                     _userContext.UserRoleEntityFunctions.Where(
                         u => u.IsDeleted == "N" && u.ApplicationId == applicationId && u.SubscriberId == subscriberId && (isCurrentUserAdmin || u.UserId == userId))
                 select u).Distinct().ToList();

            List<string> entityIds =
                (from e in
                     userRoleEntityFunctions
                 select e.ApplicationEntityId).Distinct().ToList();


            List<ApplicationEntity> appEntities = (from e in _userContext.ApplicationEntities.Where(t => entityIds.Contains(t.ApplicationEntityId)) select e).ToList();
            List<string> entityFuncIds =
                (from e in
                     userRoleEntityFunctions
                 select e.FunctionCode).ToList();
            List<MenuModuleDTO> moduleCodes =
                (from m in
                     modulesEntityFunctions.Where(m => entityIds.Contains(m.ApplicationEntityId))
                 select new MenuModuleDTO()
                 {
                     ModuleId = m.ModuleCode,
                     ModuleName = m.ModuleName,
                     ModuleIcon = m.ModuleIcon
                 }).ToList();
            moduleCodes = moduleCodes.GroupBy(m => m.ModuleId).Select(m => m.FirstOrDefault()).ToList();

            //foreach (var mod in moduleCodes)
            //{
            //    List<MenuEntityDTO> menuEntities = new List<MenuEntityDTO>();
            //    List<MenuEntityDTO> entities = (from m in modulesEntityFunctions.Where(m => entityIds.Contains(m.ApplicationEntityId) && mod.ModuleId == m.ModuleCode && m.ApplicationId == applicationId)
            //                                    select new MenuEntityDTO()
            //                                    {
            //                                        AppEntityId = m.ApplicationEntityId,
            //                                        AppEntityName = m.EntityName,
            //                                        EntityUrl = m.EntityUrl,
            //                                        MENUICON = m.MENUICON,
            //                                        MENUICON1 = m.MENUICON1,
            //                                        MENUICON2 = m.MENUICON2
            //                                    }).Distinct().ToList();
            //    entities = entities.GroupBy(m => m.AppEntityId).Select(m => m.FirstOrDefault()).ToList();
            //    foreach (var ent in entities)
            //    {
            //        List<MenuFunctionDTO> entityFunctions = (from m in modulesEntityFunctions.Where(m => entityFuncIds.Contains(m.FunctionCode) && ent.AppEntityId == m.ApplicationEntityId)
            //                                                 select new MenuFunctionDTO()
            //                                                 {
            //                                                     FunctionCode = m.FunctionCode,
            //                                                     FunctioName = m.FunctionName,
            //                                                     Url = m.FormUrl,
            //                                                     MenuOrder = m.FunctionOrder,
            //                                                     IsInRole = UAMGlobalConstants.IsInRoleYes,
            //                                                     IsMenu = m.IsMenuItem
            //                                                 }).Distinct().ToList();
            //        if (entityFunctions.Any())
            //        {
            //            menuEntities.Add(new MenuEntityDTO()
            //            {
            //                AppEntityId = ent.AppEntityId,
            //                AppEntityName = ent.AppEntityName,
            //                EntityUrl = (from m in entityFunctions orderby m.MenuOrder select m.Url).FirstOrDefault(),
            //                AppFunctions = entityFunctions,
            //                MENUICON = ent.MENUICON,
            //                MENUICON1 = ent.MENUICON1,
            //                MENUICON2 = ent.MENUICON2
            //            });
            //        }
            //    }
            //    menuModules.Add(new MenuModuleDTO()
            //    {
            //        ModuleId = mod.ModuleId,
            //        ModuleName = mod.ModuleName,
            //        ModuleIcon = mod.ModuleIcon,
            //        AppEntities = menuEntities
            //    });
            //}

            //New Code Start
            foreach (var mod in moduleCodes)
            {
                List<MenuEntityDTO> menuEntities = new List<MenuEntityDTO>();
                List<MenuEntityDTO> entities = modulesEntityFunctions.Where(m => m.ApplicationId == applicationId && mod.ModuleId == m.ModuleCode && entityIds.Contains(m.ApplicationEntityId))
                    .Select(x => new MenuEntityDTO
                    {
                        AppEntityId = x.ApplicationEntityId,
                        AppEntityName = x.EntityName,
                        EntityUrl = x.EntityUrl,
                        MENUICON = x.MENUICON,
                        MENUICON1 = x.MENUICON1,
                        MENUICON2 = x.MENUICON2
                    }).Distinct().ToList();
                entities = entities.GroupBy(m => m.AppEntityId).Select(m => m.FirstOrDefault()).ToList();
                foreach (var ent in entities)
                {
                    List<MenuFunctionDTO> entityFunctions = modulesEntityFunctions.Where(m => m.ApplicationEntityId == ent.AppEntityId && entityFuncIds.Contains(m.FunctionCode))
                                                             .Select(x => new MenuFunctionDTO
                                                             {
                                                                 FunctionCode = x.FunctionCode,
                                                                 FunctioName = x.FunctionName,
                                                                 Url = x.FormUrl,
                                                                 MenuOrder = x.FunctionOrder,
                                                                 IsInRole = UAMGlobalConstants.IsInRoleYes,
                                                                 IsMenu = x.IsMenuItem
                                                             }).Distinct().ToList();
                    if (entityFunctions.Any())
                    {
                        menuEntities.Add(new MenuEntityDTO()
                        {
                            AppEntityId = ent.AppEntityId,
                            AppEntityName = ent.AppEntityName,
                            EntityUrl = (from m in entityFunctions orderby m.MenuOrder select m.Url).FirstOrDefault(),
                            AppFunctions = entityFunctions,
                            MENUICON = ent.MENUICON,
                            MENUICON1 = ent.MENUICON1,
                            MENUICON2 = ent.MENUICON2
                        });
                    }
                }
                menuModules.Add(new MenuModuleDTO()
                {
                    ModuleId = mod.ModuleId,
                    ModuleName = mod.ModuleName,
                    ModuleIcon = mod.ModuleIcon,
                    AppEntities = menuEntities
                });
            }
            //Code End
            return menuModules;    
        }

    }
}
