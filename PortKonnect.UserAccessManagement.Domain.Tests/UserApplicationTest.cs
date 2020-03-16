using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.DataServcies;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.MapToDTOS;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;

namespace PortKonnect.UserAccessManagement.Domain.Tests
{
    [TestClass]
    public class UserApplicationTest
    {
        private IUserApplicationService _userApplicationService;
        private IUserDataService _userDataService;
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IUserContext _userContext;

        public UserApplicationTest()
        {
            _userContext = new UserContext();
            _userApplicationService = new UserApplicationService(_userContext, new UserRepository(_userContext), new RoleRepository(_userContext), new CommonRepository(_userContext),new NotificationDataService(), new PartnerRepository(_userContext));
            _userDataService = new UserDataService(_userContext, new CommonRepository(_userContext));
            _userRepository = new UserRepository(_userContext);
            _roleRepository = new RoleRepository(_userContext);
        }

        [TestMethod]
        public void UserTest()
        {
            ////Arrange

            string partnerType = "VesselOperatingAgent";
            int applicationId = 2;
            string subscriberId = "KPCT";
            ////Act
           // _userApplicationService.GetAllSubscribedPartners();
            ////Assert
            //Assert.NotNull(); //TODO: object is null or not
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            ////Arrange
            UserDTO user = new UserDTO();
            string userid = "73e36e21-3c45-42ed-9783-cbdefa329932";
            user = _userRepository.GetUserForUserId(userid).MapToDto();
            user.UpdatedOn = DateTime.Now;
            user.UpdatedBy = "1";
            ContextDTO contextDto = new ContextDTO()
            {
                UserId = "3",
                UserName = "KPCT",
                ApplicationId = 2,
                MemberId = "KPCT",
                SubscriberId = "KPCT",
                PortCode = "KP",
                MemberType = "TerminalOperator"
            };
            _userApplicationService.UpdateUser(user, contextDto);

        }

        [TestMethod]
        public void UpdateUserTest1()
        {
            ////Arrange
            UserDTO user = new UserDTO();
            string userid = "b6f5c610-2b75-4036-afd0-456e6e30e2d7";
            user = _userRepository.GetUserForUserId(userid).MapToDto();
            user.UserName = "SravanKumar";
            user.FirstName = "Kumar";
            user.LastName = "Sravan";
            user.EmailId = "sravanbankam@navayugainfotech.com";
            user.ContactNumber = "040222222222";
            user.UserPortArray = new List<string>() { "PK" };
            ContextDTO contextDto = new ContextDTO()
            {
                UserId = "3",
                UserName = "KPCT",
                ApplicationId = 2,
                MemberId = "KPCT",
                SubscriberId = "KPCT",
                PortCode = "KP",
                MemberType = "TerminalOperator"
            };
            user.UserPreference = new UserPreferenceDTO() { SendNotificationEmail = "N", SendSystemNotification = "N", SendNotificationSms = "N" };
            _userApplicationService.UpdateUser(user, contextDto);

        } 

    }
}
