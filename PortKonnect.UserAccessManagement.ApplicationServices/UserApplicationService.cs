using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.Common.Domain.Model;
using PortKonnect.Common.Enums;
using PortKonnect.Common.Services;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.DataServcies;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.GlobalConstants;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;
using PortKonnect.UserAccessManagement.Domain.DTOS;

using PortKonnect.UserAccessManagement.Domain.Repositories;
using PortKonnect.UserAccessManagement.Domain.Enums;
using PortKonnect.UserAccessManagement.Domain.MapToDTOS;
using PortKonnect.Common.Contracts;
using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json;


namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public class UserApplicationService : ServiceBase, IUserApplicationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ICommonRepository _commonRepository;
        private readonly INotificationDataService _notificationDataService;
       private readonly IPartnerRepository _partnerRepository;

        public UserApplicationService(IUserContext userContext, 
            IUserRepository userRepository, 
            IRoleRepository roleRepository,
            ICommonRepository commonRepository, 
            INotificationDataService notificationDataService,
            IPartnerRepository partnerRepository)
        {
            UserContext = userContext;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _commonRepository = commonRepository;
            _notificationDataService = notificationDataService;
          _partnerRepository= partnerRepository;
    }

        public void AddUser(UserDTO userDTO, ContextDTO contextDto)
        {
            EncloseTransactionAndHandleException(() =>
            {

                if (ApplicationContextDTO.UserName == null || ApplicationContextDTO.UserName == "")
                {
                    ApplicationContextDTO.ApplicationId = UAMGlobalConstants.ApplicationId;
                    ApplicationContextDTO.SubscriberId = UAMGlobalConstants.SubscriberId;
                    

                }
               
                UserPreference userPreference = new UserPreference(userDTO.UserPreference.SendNotificationEmail, userDTO.UserPreference.SendNotificationSms, userDTO.UserPreference.SendSystemNotification);
                userDTO.UserId = Guid.NewGuid().ToString();
                if (string.IsNullOrEmpty(userDTO.UserId.Trim()))
                {
                    throw new ArgumentException("User Id cannot be null for a new User");
                }

                string _password = PasswordDataService.Generate();
                //userDTO.IsQuixyUser = "N";
                userDTO.InCorrectLogins = 0;
                userDTO.IsFirstTimeLogin = UAMGlobalConstants.IsFirstTimeLogin;
                userDTO.validFromDate = DateTime.Now;
                //TODO:Implement Global Constants from resource file
                userDTO.validToDate = DateTime.Now.AddDays(UAMGlobalConstants.UserCreationLifeSpan);
                userDTO.PwdExpiryDate = DateTime.Now.AddDays(UAMGlobalConstants.PwdExpiryDays);
             

                User user = new User(userDTO.UserId, userDTO.UserName, PasswordDataService.Encrypt(_password, true),
                    userDTO.FirstName, userDTO.LastName, userDTO.PartnerId, userDTO.ContactNumber, userDTO.EmailId, userPreference, contextDto.ApplicationId, UAMGlobalConstants.RecordStatus, contextDto.UserId,
                    userDTO.InCorrectLogins, UAMGlobalConstants.IsDormantNo, UAMGlobalConstants.IsDeletedNo, userDTO.IsFirstTimeLogin, userDTO.validFromDate, userDTO.validToDate, userDTO.PwdExpiryDate, userDTO.PartnerType,userDTO.IsCFSUser);
                user.SetSubscriberId(contextDto.SubscriberId);
                user.IsCFSUser = "N";
                var rolecodes = _roleRepository.GetRoles(contextDto.ApplicationId, ApplicationContextDTO.SubscriberId).Where(role => userDTO.UserRoleArray.Contains(role.RoleId)).Select(x => x.RoleCode).ToList();
                string Quixyroles = ConfigurationManager.AppSettings["CFSRoles"];
                List<string> Quixyroleslist = Quixyroles.Split(',').ToList();
                foreach (string roleid in Quixyroleslist)
                {
                    if (rolecodes.Any(x => x == roleid))
                    {
                        user.IsCFSUser = "Y";
                    }

                }

                foreach (string portCode in userDTO.UserPortArray)
                {
                    user.AssignToPort(portCode, UAMGlobalConstants.IsDeletedNo, UAMGlobalConstants.RecordStatus, contextDto.UserId);
                }

                //string roleId,int applicationId ,string isDeleted, string recordStatus, string createdBy

                foreach (string roleId in userDTO.UserRoleArray)
                {

                    user.AssignRole(roleId, contextDto.ApplicationId, UAMGlobalConstants.IsDeletedNo, UAMGlobalConstants.RecordStatus, contextDto.UserId, ApplicationContextDTO.SubscriberId);
                }

             

                _userRepository.AddUser(user);

                userDTO.Password = _password;
                userDTO.LoginLink = ConfigurationManager.AppSettings["UAMWebUrl"];
                Partner partner =  _partnerRepository.GetPartnerByPartnerId(userDTO.PartnerId, contextDto.SubscriberId);
                userDTO.PartnerName = partner.PartnerName;
                userDTO.PartnerTypeArray = partner.PartnerCode;
                SendAddOrUpdateUserNotification(userDTO);
            if (user.IsCFSUser == "Y")
            {
                var roleNames = _roleRepository.GetRoles(contextDto.ApplicationId, ApplicationContextDTO.SubscriberId).Where(role => userDTO.UserRoleArray.Contains(role.RoleId)).Select(x => x.RoleName).ToList();
                    var roleNamesCsv = string.Join(",", roleNames);
                //if (user.IsQuixyUser == "Y")
                //{
                //    Task.Run(async () => await SaveUserInKwixee(ConvertToKwixeeModel(userDTO), roleNamesCsv));
                }

                user.RaiseDomainUserNotificationEvent(user);
                SendNotification(contextDto.ApplicationId, user.SubscriberId, user.PartnerId,
                    CargoAppEntityCodes.cargoUser.ToString(), CargoAppEntityCodes.cargoUserAdd.ToString(), user.UserId,
                    null, user.UserId, userDTO);
            });
        }

        public void UpdateUser(UserDTO userDto, ContextDTO contextDto)
        {
            EncloseTransactionAndHandleException(() =>
            {
                if (ApplicationContextDTO.UserName == null || ApplicationContextDTO.UserName == "")
                {
                    ApplicationContextDTO.ApplicationId = UAMGlobalConstants.ApplicationId;
                    ApplicationContextDTO.SubscriberId = UAMGlobalConstants.SubscriberId;


                }

                string CFSuser = "N";
                var rolecodes = _roleRepository.GetRoles(contextDto.ApplicationId, ApplicationContextDTO.SubscriberId).Where(role => userDto.UserRoleArray.Contains(role.RoleId)).Select(x => x.RoleCode).ToList();
                string Quixyroles = ConfigurationManager.AppSettings["CFSRoles"];
                List<string> Quixyroleslist = Quixyroles.Split(',').ToList();
                foreach (string roleid in Quixyroleslist)
                {
                    if (rolecodes.Any(x => x == roleid))
                    {
                        CFSuser = "Y";
                    }

                }

                User user = _userRepository.GetUserForUserId(userDto.UserId);
                UserDTO userDTO = user.MapToDto();
                user.IsCFSUser = CFSuser;
                if (user == null) throw new ArgumentNullException("User does not Exists");

                int usersNosWithUserName = _userRepository.GetUsersForUserNameOtherThanUserId(userDto.UserId, userDto.UserName);

                AssertionConcern.AssertArgumentTrue(usersNosWithUserName < 1, "User Name already Exists");

                user.ChangeUserDetails(userDto.UserName, userDto.FirstName, userDto.LastName, userDto.ContactNumber, userDto.EmailId, userDto.PartnerId);
                user.ChangeUpdatedByAndOn(userDto.UserId);
                user.ChangeUserPreference(userDto.UserId, userDto.UserPreference);
                user.UpdateDormantStatus(userDto.DormantStatus, userDto.UserId, userDto.PwdExpiryDate, userDto.validToDate, userDto.LogTime, userDto.InCorrectLogins);

               

                foreach (UserPort userPort in user.UserPorts)
                {
                    if (!userDto.UserPortArray.Contains(userPort.PortCode))
                    {
                        userPort.UpdateIsDeleted(UAMGlobalConstants.IsDeletedYes);
                        userPort.ChangeUpdatedByAndOn(contextDto.UserId);
                    }
                }
                foreach (string portCode in userDto.UserPortArray)
                {
                    if (!userDTO.UserPortArray.Contains(portCode))
                    {
                        user.AssignToPort(portCode, UAMGlobalConstants.IsDeletedNo, UAMGlobalConstants.RecordStatus, contextDto.UserId);
                    }
                }


                foreach (UserRole userRole in user.UserRoles)
                {
                    if (!userDto.UserRoleArray.Contains(userRole.RoleId))
                    {
                        userRole.UpdateIsDeleted(UAMGlobalConstants.IsDeletedYes);
                        userRole.ChangeUpdatedByAndOn(contextDto.UserId);
                    }
                    else if (userRole.IsDeleted == UAMGlobalConstants.IsDeletedYes)
                    {
                        userRole.UpdateIsDeleted(UAMGlobalConstants.IsDeletedNo);
                        userRole.ChangeUpdatedByAndOn(contextDto.UserId);
                    }
                }
                foreach (string roleId in userDto.UserRoleArray)
                {
                    if (!userDTO.UserRoleArray.Contains(roleId))
                    {
                        user.AssignRole(roleId, contextDto.ApplicationId, UAMGlobalConstants.IsDeletedNo, UAMGlobalConstants.RecordStatus, contextDto.UserId, ApplicationContextDTO.SubscriberId);
                    }
                }
              
              
                _userRepository.UpdateUser(user);
                userDto = user.MapToDto();
                Partner partner = _partnerRepository.GetPartnerByPartnerId(userDto.PartnerId, contextDto.SubscriberId);
                userDto.PartnerName = partner.PartnerName;
                userDto.PartnerTypeArray = partner.PartnerCode;
                userDto.PartnerType = partner.PartnerType;
                //userDto.RecordStatus = user.RecordStatus;
               // userDto.Password = user.Password;
                //TODO:Notification template to be available when any user information is updated, then below line to be uncommented
                //SendNotification(contextDto.ApplicationId, user.SubscriberId, user.PartnerId,CargoAppEntityCodes.cargoUser.ToString(), CargoAppEntityCodes.cargoUserEdit.ToString(), user.UserId,null, user.UserId, user.MapToDto());

                //SendAddOrUpdateUserNotification(user.MapToDto());
                SendAddOrUpdateUserNotification(userDto);

            });
        }

        public void ActivateOrDeActivateUser(string userId, string isDeleted, ContextDTO contextDto)
        {
            EncloseTransactionAndHandleException(() =>
            {
                User user = _userRepository.GetUserForUserId(userId);
                UserDTO userDTO = user.MapToDto();
                user.ChangeRecordStatus(userId, isDeleted);
                _userRepository.UpdateUser(user);
            });



        }

        public List<UserDTO> GetUsersForMemberId(int appId, string subscriberId, string memeberId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                List<User> users = _userRepository.GetUsersForMemberId(appId, subscriberId, memeberId);
                List<UserDTO> usersDtos = users.MapToDTO();
                return usersDtos;
            });
        }
        public List<UserDTO> GetUsersForMemberByRole(int appId, string subscriberId, string memeberId, string roleId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                List<User> users = _userRepository.GetUsersForMemberByRole(appId, subscriberId, memeberId, roleId);
                List<UserDTO> usersDtos = users.MapToDTO();
                return usersDtos;
            });
        }

        public List<PartnerTypeDTO> GetPartnerTypesForUser(ContextDTO contextDto)
        {

            return _userRepository.GetPartnerTypesForUser(contextDto);
        }


        public UserDTO GetUserForUserId(string userId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                User user = _userRepository.GetUserForUserId(userId);
                UserDTO userDto = user.MapToDto();
                return userDto;
            });
        }

        public UserDTO GetUserForUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetUsers(string UserId, int applicationId, string subscriberId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                List<UserDTO> userDtos = new List<UserDTO>();
                List<UserDTO> userDto = _userRepository.GetUsers(UserId, applicationId, subscriberId);
                foreach (UserDTO user in userDto)
                {

                    user.LoginUserId = ApplicationContextDTO.UserId;
                    userDtos.Add(user);
                }

                return userDtos;
            });
        }

        public List<UserDTO> GetUsersForPartner(string partnerId)
        {
            return null;
        }



        public List<AppMemberDTO> GetAllSubscribedPartners(ContextDTO contextDto, string PartnerType)
        {
            return ExecuteFaultHandledOperation(() => _userRepository.GetAllSubscribedPartners(contextDto.ApplicationId, contextDto.SubscriberId, PartnerType));
        }

        public bool AuthenticateUser(int applicationId, string userName, string password)
        {
            return ExecuteFaultHandledOperation(() => _userRepository.AuthenticateUser(applicationId, userName, password));

        }

        private static async Task<string> SaveUserInKwixee(object requestModel, string userRolesCsv)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                
                string url = ConfigurationManager.AppSettings["KwixeeApiUrl"];
                string securityKey = ConfigurationManager.AppSettings["SecurityKey"];
                _httpClient.DefaultRequestHeaders.Add("SecurityKey", securityKey);
                var json = JsonConvert.SerializeObject(requestModel);
                var stringContent = new StringContent(json, System.Text.UnicodeEncoding.UTF8, "application/json");
                using (var result = await _httpClient.PostAsync($"{url}/api/User/Post?domainName=&userRoles={userRolesCsv}", stringContent))
                {
                    return await result.Content.ReadAsStringAsync();

                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        private object ConvertToKwixeeModel(UserDTO user)
        {
            return new
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                EmailId = user.EmailId,
                Password = user.Password,
                ContactNumber = user.ContactNumber,
                CompanyName = "Cochin Port Trust",
                OrganizationId = ConfigurationManager.AppSettings["OrganizationId"],
                ProfilePhoto1 = string.Empty,
                ProfilePhoto2 = string.Empty,
                UserType = "User",
                LeadId = string.Empty,
                EmployeeId = string.Empty,
                EmployeeCode = string.Empty,
                Gender = string.Empty,
                DateofBirth = string.Empty,
                Manager = string.Empty,
                EnableAppData = true,
                UserId = user.UserId
            };
        }
    }
}
