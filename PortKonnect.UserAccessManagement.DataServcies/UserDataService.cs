using System;
using System.Collections.Generic;
using System.Linq;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.MapToDTOS;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;
using PortKonnect.UserAccessManagement.GlobalConstants;
using PortKonnect.Common.Domain.Model;


namespace PortKonnect.UserAccessManagement.DataServcies
{
    public class UserDataService : IUserDataService
    {
        public IUserContext _userContext;
        public ICommonRepository _commonRepository;
        public UserDataService(IUserContext userContext, ICommonRepository commonRepository)
        {
            _userContext = userContext;
            _commonRepository = commonRepository;
        }


        #region User Authentication Functions
        public List<AuthorizedFunctionDTO> GetAuthorisedUserFunctions(int applicationId, string subscriberId, string userName, string portCode, string appEntityCode)
        {
            IQueryable<AuthorizedFunctionDTO> userMenuFunctions =
                from u in
                    _userContext.UserMenuFunctions.Where(
                        u => u.ApplicationId == applicationId && u.PartnerId == subscriberId && u.UserName == userName && u.ApplicationEntityId == appEntityCode)
                select new AuthorizedFunctionDTO()
                {
                    FunctionCode = u.FunctionCode,
                    FunctionName = u.FunctionName,
                    AppEntityCode = u.ApplicationEntityId

                };

            return userMenuFunctions.ToList();
        }
        public List<AuthorizedFunctionDTO> GetAuthorisedUserFunctions(int applicationId, string subscriberId, string userName, string portCode, string appEntityCode, List<string> appEntityFunctionCode)
        {
            IQueryable<AuthorizedFunctionDTO> userMenuFunctions =
                from u in
                    _userContext.UserMenuFunctions.Where(
                        u => u.ApplicationId == applicationId && u.PartnerId == subscriberId && u.UserName == userName && u.ApplicationEntityId == appEntityCode && appEntityFunctionCode.Any(l => u.FunctionCode == l))
                select new AuthorizedFunctionDTO()
                {
                    FunctionCode = u.FunctionCode,
                    FunctionName = u.FunctionName,
                    AppEntityCode = u.ApplicationEntityId

                };
            return userMenuFunctions.ToList();
        }
        #endregion

        #region GetAllSubscribedUsers
        public List<UserDTO> GetAllSubscribedUsers(int applicationId, string subscriberId, string userId,
             string memberId, string userName, string firstName, string lastName, string partnerType, string dormantUser)
        {

            var usersList = (from u in _userContext.Users
                             join s in _userContext.SubscriptionMembers on u.PartnerId equals s.MemberId
                             join p in _userContext.Partners on u.PartnerId equals p.PartnerId
                             where s.ApplicationId == applicationId && s.PartnerId == subscriberId && s.MemberId == memberId && u.UserRoles.Any(c => c.SubscriberId == subscriberId && c.IsDeleted == UAMGlobalConstants.IsDeletedNo)
                                && (userName == "All" || (u.UserName.ToUpper().Contains(userName.ToUpper())))
                                && (firstName == "All" || (u.FirstName.ToUpper().Contains(firstName.ToUpper())))
                                && (lastName == "All" || (u.LastName.ToUpper().Contains(lastName.ToUpper())))
                                && (dormantUser == "All" || (u.DormantStatus.ToUpper().Contains(dormantUser.ToUpper())))
                             orderby u.CreatedOn descending
                             select new
                             {
                                 UserId = u.UserId,
                                 UserName = u.UserName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RecordStatus = u.RecordStatus,
                                 PartnerType = u.PartnerType,
                                 PartnerTypeName = p.PartnerType,
                                 PartnerTypes = p.partnerTypes,
                                 PartnerTypeCode = p.PartnerType,
                                 EmailId = u.EmailId,
                                 ContactNumber = u.ContactNo,
                                 DormantStatus = u.DormantStatus
                             }).ToList();


            List<UserDTO> userDtoList = new List<UserDTO>();
            foreach (var user in usersList)
            {
                UserDTO userDTO = new UserDTO
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RecordStatus = user.RecordStatus,
                    PartnerTypeName = user.PartnerTypeName,
                    EmailId = user.EmailId,
                    ContactNumber = user.ContactNumber,
                    DormantStatus = user.DormantStatus,
                    PartnerTypeCode = user.PartnerType,
                    PartnerType = user.PartnerTypes.FirstOrDefault() != null ? user.PartnerTypes.FirstOrDefault().partnerTypeName : null,
                    PartnerTypes = user.PartnerTypes.MapToDTO()

                };
                userDtoList.Add(userDTO);
            }
            return userDtoList;
        }

        public List<UserDTO> GetAllSubscribedUsersforTO(int applicationId, string subscriberId, string userId,
           string memberId, string userName, string firstName, string lastName, string partnerType, string dormantUser)
        {
            var usersList = (from u in _userContext.Users
                             join s in _userContext.SubscriptionMembers on u.PartnerId equals s.MemberId
                             join p in _userContext.Partners on u.PartnerId equals p.PartnerId
                             where s.ApplicationId == applicationId && s.PartnerId == subscriberId && p.partnerTypes.Any(d=>d.SubscriberId==subscriberId && d.IsDelete==UAMGlobalConstants.IsDeletedNo) && u.UserRoles.Any(c => c.SubscriberId == subscriberId && c.IsDeleted == UAMGlobalConstants.IsDeletedNo)
                                && (userName == "All" || (u.UserName.ToUpper().Contains(userName.ToUpper())))
                                && (firstName == "All" || (u.FirstName.ToUpper().Contains(firstName.ToUpper())))
                                && (lastName == "All" || (u.LastName.ToUpper().Contains(lastName.ToUpper())))
                                && (dormantUser == "All" || (u.DormantStatus.ToUpper().Contains(dormantUser.ToUpper())))
                             orderby u.CreatedOn descending
                             select new
                             {
                                 UserId = u.UserId,
                                 UserName = u.UserName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RecordStatus = u.RecordStatus,
                                 PartnerType = u.PartnerType,
                                 PartnerTypeName = p.PartnerType,
                                 PartnerTypes = p.partnerTypes.Where(c=>c.SubscriberId==subscriberId && c.IsDelete==UAMGlobalConstants.IsDeletedNo),
                                 PartnerTypeCode = p.PartnerType,
                                 EmailId = u.EmailId,
                                 ContactNumber = u.ContactNo,
                                 DormantStatus = u.DormantStatus
                             }).ToList();

            List<UserDTO> userDtoList = new List<UserDTO>();
            foreach (var user in usersList)
            {
                UserDTO userDTO = new UserDTO
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RecordStatus = user.RecordStatus,
                    PartnerTypeName = user.PartnerTypeName,
                    EmailId = user.EmailId,
                    ContactNumber = user.ContactNumber,
                    DormantStatus = user.DormantStatus,
                    PartnerTypeCode = user.PartnerType,
                    PartnerType = user.PartnerTypes.FirstOrDefault() != null ? user.PartnerTypes.FirstOrDefault().partnerTypeName : null,
                    PartnerTypes = user.PartnerTypes.MapToDTO()

                };
                userDtoList.Add(userDTO);
            }
            return userDtoList;
        }

        public EmailDetailsDTO GetEmailDetails(int appId, string subscriberId)
        {
            //Review : EmailPassword should be saved in encrypted format
            EmailDetailsDTO emailDetails = (from u in _userContext.Subscriptions.Where(t => t.ApplicationId.Equals(appId) && t.PartnerId.Equals(subscriberId) && t.RecordStatus.Equals(UAMGlobalConstants.RecordStatus))
                                            select new EmailDetailsDTO
                                            {
                                                FromAddress = u.FromAddress,
                                                EmailPassword = u.EmailPassword,
                                                SMTPClientId = u.SMTPClientId,
                                                SMTPPortNo = u.SMTPPortNo
                                            }).FirstOrDefault();

            return emailDetails;
        }

        public SMSDetailsDTO GetSMSDetails(int appId, string subscriberId)
        {
            //Review : SMSPWD should be saved in encrypted format
            SMSDetailsDTO smsDetails = (from u in _userContext.Subscriptions.Where(t => t.ApplicationId.Equals(appId) && t.PartnerId.Equals(subscriberId))
                                        select new SMSDetailsDTO
                                        {
                                            SmsUID = u.SMSUID,
                                            SmsPWD = u.SMSPWD,
                                            SenderId = u.SenderId,
                                            Service = u.Service

                                        }).FirstOrDefault();

            return smsDetails;
        }

        public List<UserDTO> GetUsersTobeNotified(int appId, string subscriberId, string memeberId, string roleCode)
        {
            List<UserDTO> userDtos = new List<UserDTO>();
            // In case if partnercode is sent as memberid
            string partnerid = (from u in _userContext.Partners.Where(t => t.PartnerCode.Equals(memeberId) && t.SubscriptionMembers.Any(d=>d.PartnerId==subscriberId && d.ApplicationId==appId && d.RecordStatus==UAMGlobalConstants.RecordStatus)) select u.PartnerId).FirstOrDefault();
            if (partnerid == null && string.IsNullOrEmpty(partnerid))
            {
                partnerid = memeberId;

            }
            string role = _userContext.Roles.Where(t => t.RoleCode.Equals(roleCode)).FirstOrDefault().RoleId;

            var users = (from u in _userContext.Users.Where(i => i.PartnerId.Equals(partnerid))
                         join sm in _userContext.SubscriptionMembers on u.PartnerId equals sm.MemberId
                         join ur in _userContext.UserRoles on u.UserId equals ur.UserId
                         where sm.PartnerId == subscriberId && ur.RoleId == role && sm.ApplicationId == appId && ur.IsDeleted==UAMGlobalConstants.IsDeletedNo
                         && u.IsDeleted==UAMGlobalConstants.IsDeletedNo //&& u.DormantStatus==UAMGlobalConstants.IsDormantNo
                         //&& u.PartnerId == memeberId && u.ApplicationId == appId
                         select u);



            List<UserDTO> user = users.MapToDTO();
            if (user.Any())
            {
                foreach (UserDTO userDTO in user)
                {
                    userDTO.ApplicationId = appId;
                    userDtos.Add(userDTO);
                }
                return userDtos;
            }
            return null;

        }
        public List<UserDTO> GetSpecialUsersTobeNotified(int appId, string subscriberId, string roleCode)
        {
            List<UserDTO> userDtos = new List<UserDTO>();
            string role = _userContext.Roles.Where(t => t.RoleCode.Equals(roleCode)).FirstOrDefault().RoleId;
            var users = (from u in _userContext.Users
                         join sm in _userContext.SubscriptionMembers on u.PartnerId equals sm.MemberId
                         join ur in _userContext.UserRoles on u.UserId equals ur.UserId
                         where sm.ApplicationId == appId && sm.PartnerId == subscriberId && ur.RoleId == role //&& u.PartnerId == memeberId && u.ApplicationId == appId
                         select u);

            List<UserDTO> user = users.MapToDTO();

            if (user.Any())
            {
                foreach (UserDTO userDTO in user)
                {
                    userDTO.ApplicationId = appId;
                    userDtos.Add(userDTO);
                }
                return userDtos;
            }
            return null;
        }

        #endregion

        #region GetUserForUserId
        public UserDTO GetUserForUserId(string userId, string subscriberId, int applicationId)
        {

            var user = (from u in _userContext.Users.Where(u => u.UserId == userId)
                        join p in _userContext.Partners on u.PartnerId equals p.PartnerId
                        join sm in _userContext.SubscriptionMembers on p.PartnerId equals sm.MemberId
                        where sm.PartnerId == subscriberId && u.UserRoles.Any(c=>c.SubscriberId == subscriberId && c.IsDeleted==UAMGlobalConstants.IsDeletedNo) && sm.ApplicationId ==applicationId
                        select new
                        {
                            ApplicationId = sm.ApplicationId,
                            UserId = u.UserId,
                            UserName = u.UserName,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            UserPorts = u.UserPorts,
                            UserRoles = u.UserRoles.Where(d => d.SubscriberId == subscriberId && d.IsDeleted == UAMGlobalConstants.IsDeletedNo),
                            EmailId = u.EmailId,
                            ContactNo = u.ContactNo,
                            PartnerId = u.PartnerId,
                            UserPreference = u.UserPreference,
                            PartnerType = u.PartnerType,
                            PartnerTypeName = p.PartnerType,
                            PartnerName = p.PartnerName,
                            PartnerTypes = p.partnerTypes.Where(q=>q.IsDelete==UAMGlobalConstants.IsDeletedNo && q.SubscriberId==subscriberId),
                            CreatedBy = u.CreatedBy,
                            CreatedOn = u.CreatedOn,
                            DormantStatus = u.DormantStatus,
                            RecordStatus = u.RecordStatus,
                            PwdExpiryDate=u.PwdExpiryDate,
                            InCorrectLogins=u.InCorrectLogins,
                            ValidToDate=u.ValidToDate,
                            LogTime=u.LogTime
                        }).FirstOrDefault();


            if (user != null)
            {

                UserDTO userDto = new UserDTO()
                {
                    ApplicationId = user.ApplicationId,
                    UserId = user.UserId,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserPorts = user.UserPorts.MapToDTO(),
                    UserRoles = user.UserRoles.MapToDTO(),
                    EmailId = user.EmailId,
                    ContactNumber = user.ContactNo,
                    PartnerId = user.PartnerId,
                    UserPreference = user.UserPreference.MapToDTO(),
                    PartnerTypeCode = user.PartnerType,
                    PartnerType = (from p in
                                       _commonRepository.GetPartnerTypes().Where(p => p.PartnerTypeId == user.PartnerType)
                                   select p.PartnerTypeName).FirstOrDefault(),
                    DormantStatus = user.DormantStatus,
                    PartnerTypes = user.PartnerTypes.MapToDTO(),
                    PartnerTypeName = (from p in
                                           _commonRepository.GetPartnerTypes().Where(p => p.PartnerTypeId == user.PartnerTypeName)
                                       select p.PartnerTypeName).FirstOrDefault(),
                    PartnerName = user.PartnerName,
                    CreatedBy = user.CreatedBy,
                    CreatedOn = user.CreatedOn,
                    RecordStatus = user.RecordStatus,
                    PwdExpiryDate = user.PwdExpiryDate,
                    InCorrectLogins = user.InCorrectLogins,
                    validToDate = user.ValidToDate,
                    LogTime = user.LogTime
                };
                if (userDto.UserPorts.Any())
                {
                    userDto.UserPortArray = new List<string>();
                    foreach (var port in userDto.UserPorts)
                    {
                        userDto.UserPortArray.Add(port.PortCode);
                        port.PortName = _commonRepository.GetPortByPortCode(port.PortCode).PortName;
                    }
                }

                if (userDto.UserRoles.Any())
                {
                    List<Role> rolesList = (from role in _userContext.Roles.Where(t => t.ApplicationId == userDto.ApplicationId) select role).ToList();
                    userDto.UserRoleCodeArray = new List<string>();
                    userDto.UserRoleArray = new List<string>();
                    foreach (var role in userDto.UserRoles.Where(t => t.IsDeleted.Equals(UAMGlobalConstants.IsDeletedNo)))
                    {

                        userDto.UserRoleArray.Add(role.RoleId);
                        Role userRole = rolesList.FirstOrDefault(r => r.RoleId.Equals(role.RoleId));
                        if (userRole != null)
                            userDto.UserRoleCodeArray.Add(userRole.RoleCode);
                    }

                }

                if (userDto.PartnerTypes.Any())
                {
                    string partnertypes = "";
                    foreach (var partnerName in userDto.PartnerTypes)
                    {
                        if (partnerName.IsDelete == "N")
                        {
                            if (partnerName.PartnerTypeName != UAMGlobalConstants.ConsortiumPartner)
                            {
                                var PartnerTypeName = (from p in
                                                           _commonRepository.GetPartnerTypes().Where(p => p.PartnerTypeId == partnerName.PartnerTypeName)
                                                       select p.PartnerTypeName).FirstOrDefault();
                                //userDto.PartnerTypeArray.Add(PartnerTypeName);
                                if (String.IsNullOrEmpty(partnertypes))
                                    partnertypes = PartnerTypeName;
                                else
                                    partnertypes = partnertypes + "," + PartnerTypeName;

                                userDto.PartnerTypeArray = partnertypes;
                            }

                        }
                    }

                }
                return userDto;
            }
            return null;
        }

        //public UserDTO GetUserForUserId(string userId, string memberId, string subscriberId, int applicationId)
        //{
        //    var user = (from u in _userContext.Users.Where(u => u.UserId == userId && u.PartnerId == memberId)
        //                join p in _userContext.Partners on u.PartnerId equals p.PartnerId
        //                join sm in _userContext.SubscriptionMembers on p.PartnerId equals sm.MemberId
        //                where sm.PartnerId == subscriberId && u.UserRoles.Any(c => c.SubscriberId == subscriberId && c.IsDeleted == UAMGlobalConstants.IsDeletedNo) && sm.ApplicationId == applicationId
        //                select new
        //                {
        //                    ApplicationId = sm.ApplicationId,
        //                    UserId = u.UserId,
        //                    UserName = u.UserName,
        //                    FirstName = u.FirstName,
        //                    LastName = u.LastName,
        //                    UserPorts = u.UserPorts,
        //                    UserRoles = u.UserRoles,
        //                    EmailId = u.EmailId,
        //                    ContactNo = u.ContactNo,
        //                    PartnerId = u.PartnerId,
        //                    UserPreference = u.UserPreference,
        //                    PartnerType = u.PartnerType,
        //                    PartnerTypeName = p.PartnerType,
        //                    PartnerName = p.PartnerName,
        //                    PartnerTypes = p.partnerTypes,
        //                    CreatedBy = u.CreatedBy,
        //                    CreatedOn = u.CreatedOn,
        //                    DormantStatus = u.DormantStatus,
        //                    RecordStatus = u.RecordStatus

        //                }).FirstOrDefault();


        //    if (user != null)
        //    {

        //        UserDTO userDto = new UserDTO()
        //        {
        //            ApplicationId = user.ApplicationId,
        //            UserId = user.UserId,
        //            UserName = user.UserName,
        //            FirstName = user.FirstName,
        //            LastName = user.LastName,
        //            UserPorts = user.UserPorts.MapToDTO(),
        //            UserRoles = user.UserRoles.MapToDTO(),
        //            EmailId = user.EmailId,
        //            ContactNumber = user.ContactNo,
        //            PartnerId = user.PartnerId,
        //            UserPreference = user.UserPreference.MapToDTO(),
        //            PartnerTypeCode = user.PartnerType,
        //            PartnerType = (from p in
        //                               _commonRepository.GetPartnerTypes().Where(p => p.PartnerTypeId == user.PartnerType)
        //                           select p.PartnerTypeName).FirstOrDefault(),
        //            DormantStatus = user.DormantStatus,
        //            PartnerTypes = user.PartnerTypes.MapToDTO(),
        //            PartnerTypeName = (from p in
        //                                   _commonRepository.GetPartnerTypes().Where(p => p.PartnerTypeId == user.PartnerTypeName)
        //                               select p.PartnerTypeName).FirstOrDefault(),
        //            PartnerName = user.PartnerName,
        //            CreatedBy = user.CreatedBy,
        //            CreatedOn = user.CreatedOn,
        //            RecordStatus = user.RecordStatus
        //        };
        //        if (userDto.UserPorts.Any())
        //        {
        //            userDto.UserPortArray = new List<string>();
        //            foreach (var port in userDto.UserPorts)
        //            {
        //                userDto.UserPortArray.Add(port.PortCode);
        //                port.PortName = _commonRepository.GetPortByPortCode(port.PortCode).PortName;
        //            }
        //        }

        //        if (userDto.UserRoles.Any())
        //        {
        //            List<Role> rolesList = (from role in _userContext.Roles.Where(t => t.ApplicationId == userDto.ApplicationId) select role).ToList();
        //            userDto.UserRoleCodeArray = new List<string>();
        //            userDto.UserRoleArray = new List<string>();
        //            foreach (var role in userDto.UserRoles.Where(t => t.IsDeleted.Equals(UAMGlobalConstants.IsDeletedNo)))
        //            {

        //                userDto.UserRoleArray.Add(role.RoleId);
        //                Role userRole = rolesList.FirstOrDefault(r => r.RoleId.Equals(role.RoleId));
        //                if (userRole != null)
        //                    userDto.UserRoleCodeArray.Add(userRole.RoleCode);
        //            }

        //        }

        //        if (userDto.PartnerTypes.Any())
        //        {
        //            string partnertypes = "";
        //            foreach (var partnerName in userDto.PartnerTypes)
        //            {
        //                if (partnerName.IsDelete == "N")
        //                {
        //                    if (partnerName.PartnerTypeName != UAMGlobalConstants.ConsortiumPartner)
        //                    {
        //                        var partnerTypeName = (from p in
        //                                                   _commonRepository.GetPartnerTypes().Where(p => p.PartnerTypeId == partnerName.PartnerTypeName)
        //                                               select p.PartnerTypeName).FirstOrDefault();
        //                        if (String.IsNullOrEmpty(partnertypes))
        //                            partnertypes = partnerTypeName;
        //                        else
        //                            partnertypes = partnertypes + "," + partnerTypeName;

        //                        userDto.PartnerTypeArray = partnertypes;
        //                    }

        //                }
        //            }

        //        }
        //        return userDto;
        //    }
        //    return null;
        //}

        public UserDTO GetUserForUserIdByPartnerId(string userId, string memberId, string subscriberId)
        {
            var user = (from u in _userContext.Users.Where(u => u.UserId == userId && u.PartnerId == memberId)
                        join p in _userContext.Partners on u.PartnerId equals p.PartnerId
                        join sm in _userContext.SubscriptionMembers on p.PartnerId equals sm.MemberId
                        where sm.PartnerId==subscriberId && u.UserRoles.Any(c=>c.SubscriberId==subscriberId && c.IsDeleted==UAMGlobalConstants.IsDeletedNo)
                        select new
                        {
                            ApplicationId = sm.ApplicationId,
                            UserId = u.UserId,
                            UserName = u.UserName,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            UserPorts = u.UserPorts,
                            UserRoles = u.UserRoles.Where(d=>d.SubscriberId==subscriberId),
                            EmailId = u.EmailId,
                            ContactNo = u.ContactNo,
                            PartnerId = u.PartnerId,
                            UserPreference = u.UserPreference,
                            PartnerType = u.PartnerType,
                            PartnerTypeName = p.PartnerType,
                            PartnerName = p.PartnerName,
                            PartnerTypes = p.partnerTypes,
                            CreatedBy = u.CreatedBy,
                            CreatedOn = u.CreatedOn,
                            DormantStatus = u.DormantStatus,
                            RecordStatus = u.RecordStatus,
                              PwdExpiryDate = u.PwdExpiryDate,
                            InCorrectLogins = u.InCorrectLogins,
                            ValidToDate = u.ValidToDate,
                            LogTime = u.LogTime
                        }).FirstOrDefault();


            if (user != null)
            {

                UserDTO userDto = new UserDTO()
                {
                    ApplicationId = user.ApplicationId,
                    UserId = user.UserId,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserPorts = user.UserPorts.MapToDTO(),
                    UserRoles = user.UserRoles.MapToDTO(),
                    EmailId = user.EmailId,
                    ContactNumber = user.ContactNo,
                    PartnerId = user.PartnerId,
                    UserPreference = user.UserPreference.MapToDTO(),
                    PartnerTypeCode = user.PartnerType,
                    PartnerType = (from p in
                                       _commonRepository.GetPartnerTypes().Where(p => p.PartnerTypeId == user.PartnerType)
                                   select p.PartnerTypeName).FirstOrDefault(),
                    DormantStatus = user.DormantStatus,
                    PartnerTypes = user.PartnerTypes.MapToDTO(),
                    PartnerTypeName = (from p in
                                           _commonRepository.GetPartnerTypes().Where(p => p.PartnerTypeId == user.PartnerTypeName)
                                       select p.PartnerTypeName).FirstOrDefault(),
                    PartnerName = user.PartnerName,
                    CreatedBy = user.CreatedBy,
                    CreatedOn = user.CreatedOn,
                    RecordStatus = user.RecordStatus,
                    PwdExpiryDate = user.PwdExpiryDate,
                    InCorrectLogins = user.InCorrectLogins,
                    validToDate = user.ValidToDate,
                    LogTime = user.LogTime
                };
                if (userDto.UserPorts.Any())
                {
                    userDto.UserPortArray = new List<string>();
                    foreach (var port in userDto.UserPorts)
                    {
                        userDto.UserPortArray.Add(port.PortCode);
                        port.PortName = _commonRepository.GetPortByPortCode(port.PortCode).PortName;
                    }
                }

                if (userDto.UserRoles.Any())
                {
                    List<Role> rolesList = (from role in _userContext.Roles.Where(t => t.ApplicationId == userDto.ApplicationId) select role).ToList();
                    userDto.UserRoleCodeArray = new List<string>();
                    userDto.UserRoleArray = new List<string>();
                    foreach (var role in userDto.UserRoles.Where(t => t.IsDeleted.Equals(UAMGlobalConstants.IsDeletedNo)))
                    {

                        userDto.UserRoleArray.Add(role.RoleId);
                        Role userRole = rolesList.FirstOrDefault(r => r.RoleId.Equals(role.RoleId));
                        if (userRole != null)
                            userDto.UserRoleCodeArray.Add(userRole.RoleCode);
                    }

                }

                if (userDto.PartnerTypes.Any())
                {
                    string partnertypes = "";
                    foreach (var partnerName in userDto.PartnerTypes)
                    {
                        if (partnerName.IsDelete == "N")
                        {
                            if (partnerName.PartnerTypeName != UAMGlobalConstants.ConsortiumPartner)
                            {
                                var partnerTypeName = (from p in
                                                           _commonRepository.GetPartnerTypes().Where(p => p.PartnerTypeId == partnerName.PartnerTypeName)
                                                       select p.PartnerTypeName).FirstOrDefault();
                                if (String.IsNullOrEmpty(partnertypes))
                                    partnertypes = partnerTypeName;
                                else
                                    partnertypes = partnertypes + "," + partnerTypeName;

                                userDto.PartnerTypeArray = partnertypes;
                            }

                        }
                    }

                }
                return userDto;
            }
            return null;
        }
        #endregion

        #region GetUserIdAndNames
        public List<UserDTO> GetUserIdAndNames()
        {
            List<UserDTO> userDtos = (from u in _userContext.Users
                                      select new UserDTO()
                                      {
                                          UserId = u.UserId,
                                          UserName = u.UserName
                                      }).ToList();
            return userDtos;
        }
        #endregion


        #region CheckPartnerExist
        public bool CheckPartnerExist(string partnerType, string userName)
        {
           return _userContext.Users.Any(t => t.PartnerType.ToUpper() == partnerType.ToUpper() && t.UserName.ToUpper() == userName.ToUpper());
        }
        #endregion
    }
}
