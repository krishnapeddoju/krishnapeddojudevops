using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.DataServcies;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;

namespace PortKonnect.UserAccessManagement.Repository.Tests
{
    [TestClass]
    public class UserRepositoryTest
    {
        private IUserRepository _userRepository;
        private IUserDataService _userDataService;
        private IUserContext _userContext;
        private ICommonRepository _commonRepository;

        public UserRepositoryTest()
        {
            _userContext = new UserContext();
            _commonRepository = new CommonRepository(_userContext);
            _userRepository = new UserRepository(_userContext);
            _userDataService = new UserDataService(_userContext, _commonRepository);
        }

        [TestMethod]
        public void UserTest()
        {
            ////Arrange
            string partnerType = "VesselOperatingAgent";

            ////Act
            //List<AppMemberDTO> appMembers = _userRepository.GetAllSubscribedPartners(2, "KPCT");
            ////Assert
            //Assert.IsNotNull(appMembers);
        }

        [TestMethod]
        public void GetAllSubscribedUsers()
        {

            List<UserDTO> usersList = _userDataService.GetAllSubscribedUsers(2, "KPCT", "3", "KPCT", "KPCT", "NIT", "NIT", "VOA","All");
            Assert.IsNotNull(usersList);
        }

        [TestMethod]
        public void GetUserForUserId()
        {
            string userid = "1";
            UserDTO usersList = _userDataService.GetUserForUserId(userid,"KPCT",2);
            Assert.IsNotNull(usersList);
        }

        [TestMethod]
        public void GetUserIdAndNamesTest()
        {
            List<UserDTO> userDtos = _userDataService.GetUserIdAndNames();
            Assert.IsNotNull(userDtos);
        }

        [TestMethod]
        public void GetUsersForMemberByRole()
        {
            int appId = 2;
            string subId = "KPCT";
            string memId = "BLP";
            string roleId = "ContainerOperatorAgent";
            //string roleId = "VesselOperatingAgent";
            List<UserDTO> user = _userDataService.GetUsersTobeNotified(appId, subId, memId, roleId);
            Assert.IsNotNull(user);
        }
    }
}
