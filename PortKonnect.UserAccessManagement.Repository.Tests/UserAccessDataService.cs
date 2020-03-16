using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PortKonnect.Common.Enums;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.DataServcies;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.MapToDTOS;
using PortKonnect.UserAccessManagement.Repositories;
using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;

namespace PortKonnect.UserAccessManagement.Repository.Tests
{
    [TestClass]
    public class UserAccessDataServiceTest
    {
        public IUserContext _userContext;
        public IUserRepository _userRepository;
        private IUserDataService _userDataService;
        public INotificationDataService _notificationDataService;
        private ICommonRepository _commonRepository;
        public UserAccessDataServiceTest()
        {
            _userContext = new UserContext();
            _userRepository = new UserRepository(_userContext);
            _commonRepository = new CommonRepository(_userContext);
            _userDataService = new UserDataService(_userContext, _commonRepository);
            _notificationDataService = new NotificationDataService();
        }


        [TestMethod]
        public void UserTest()
        {

            string dashboardUrlBase = "http://localhost:62030/api/GetUser";

            //public ActionResult Index() //This view is strongly typed against User
            //{
            //testing against Joe Bob
            WebClient client = new WebClient();
            string url = dashboardUrlBase;
            //'User' is a Model class that I have defined.
            ContextDTO result = JsonConvert.DeserializeObject<ContextDTO>(client.DownloadString(url));

            //return View(result);
            //}

        }


        [TestMethod]
        public void GetAllSubscribedUsers()
        {
            // TODO Check All cases
            //1.Login through subsribered member 
            //2.Login through subscriber member with Terminal Operator role
            int applicationId = 2;
            string subscriberId = "KPCT";
            string userId = "3";
            string membetId = "KPCT";
            string UserName = "All";
            string Firstname = "All";
            string LastName = "All";
            string partnerType = "All";
            string dormantUser = "All";


            List<UserDTO> usersList = _userDataService.GetAllSubscribedUsers(applicationId, subscriberId, userId, membetId, UserName, Firstname, LastName, partnerType,dormantUser);
            Assert.IsNotNull(usersList);
        }
        [TestMethod]
        public void PostNewUserNotification()
        {
            var userdto = _userRepository.GetUserForUserId("3").MapToDto();
            string attachments = "";
            _notificationDataService.SendNotification(2, "KPCT", "BLP", AppEntityIds.eGateUser.ToString(), AppEntityCodes.eGateUserAdd.ToString(), userdto.UserId, attachments, userdto.UserId, userdto);
            Assert.AreEqual(true, !string.IsNullOrEmpty(userdto.UserId));

        }

        [TestMethod]
        public void CheckUser()
{
            string type = "ContainerOperatorAgent";
            string userNmae = "BLP_COA";
            bool isExist = _userDataService.CheckPartnerExist(type, userNmae);
            Assert.IsTrue(isExist);
            userNmae = "KPCT";
            isExist = _userDataService.CheckPartnerExist(type, userNmae);
            Assert.IsTrue(isExist);

        }

    }
}
