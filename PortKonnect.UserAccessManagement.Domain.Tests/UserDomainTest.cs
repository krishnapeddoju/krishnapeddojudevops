using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.DataServcies;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;

namespace PortKonnect.UserAccessManagement.Domain.Tests
{
    [TestClass]
    public class UserDomainTest
    {
        private IUserApplicationService _userApplicationService;
        private IUserContext _userContext;
        private ICommonRepository _commonRepository;

        public UserDomainTest()
        {
            _userContext = new UserContext();
            _userApplicationService = new UserApplicationService(_userContext, new UserRepository(_userContext), new RoleRepository(_userContext), new CommonRepository(_userContext),new NotificationDataService(),new PartnerRepository(_userContext));
        }

        [TestMethod]
        public void UserTest()
        {
            ////Arrange
            UserDTO user = new UserDTO();
            user.UserId = Guid.NewGuid().ToString();
            user.UserName = "Sravan";
            user.FirstName = "Sravan";
            user.LastName = "Kumar";
            user.Password = "hMZWy9fnhSpctrIrdXYg7w==";
            user.ApplicationId = 2;
            user.PartnerId = "PA-KPCT";
            user.EmailId = "sravan@navayugainfotech.com";
            user.ContactNumber = "040999999999";
            user.RecordStatus = "A";
            user.InCorrectLogins = 0;
            user.DormantStatus = "N";
            user.UserRoleArray = new List<string>() { "VesselOperatingAgent", "ContainerOperatorAgent", "CustomHouseAgent" };
            user.UserPortArray = new List<string>() { "KP" };
            user.UserPreference = new UserPreferenceDTO() { SendNotificationEmail = "Y", SendSystemNotification = "Y", SendNotificationSms = "Y" };
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
            _userApplicationService.AddUser(user, contextDto);

        }


    }
}
