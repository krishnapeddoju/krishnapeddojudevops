using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortKonnect.Common.Services;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.Repositories;
using PortKonnect.UserAccessManagement.Repositories;

namespace PortKonnect.UserAccessManagement.Repository.Tests
{
    [TestClass]
    public class AccountRepositoryTest
    {
        private IAccountRepository _accountRepository;
        private IUserContext _userContext;

        public AccountRepositoryTest()
        {
            _userContext = new UserContext();
            _accountRepository = new AccountRepository(_userContext);
        }

        [TestMethod]
        public void UserMenuTest()
        {
            ////Arrange


            ////Act
            List<MenuModuleDTO> menu = _accountRepository.GetMenuForUser(2, "KPCT","4");
            ////Assert
            Assert.IsNotNull(menu); 
        }

        [TestMethod]
        public void GetUsers()
        {
            int applicationId = 2;
            string userName = "KPCT";
            string pwd = "hMZWy9fnhSpctrIrdXYg7w==";
            string subscriberId = "KPCT";
            UserDTO userDto = _accountRepository.CheckUser(userName,applicationId, subscriberId);
        }


        [TestMethod]
        public void PasswordChange()
        {
            //TODO:Ensure the call is success or not by using Assert

            UserDTO user = new UserDTO();
            user.UserName = "Nageshs";
            user.Password = "D*n8y2+J}N";
            user.NewPassword = "Navayuga123$";
            string webApiUrl = "http://localhost:62030/";
            webApiUrl += "api/Account/Changepassword";
            ApiClient.RestPostNonQuery<UserDTO>(webApiUrl, user);
        }

        #region User Authentication Data Service Functions
        [TestMethod]
        public void GetAuthorisedUserFunctions()
        {
            int applicationId = 2;
            string subscriberId = "KEVIN";
            string userName = "KEVIN";
            string portCode = "KP";
            string applicationEntityId = "eGateExportRoadForm";
            List<AuthorizedFunctionDTO> userMenuFunctions = _accountRepository.GetAuthorisedUserFunctions(applicationId, subscriberId, userName, portCode, applicationEntityId);
            Assert.IsNotNull(userMenuFunctions);
        }

        [TestMethod]
        public void GetAuthorisedUserFunctionsByFunctionCode()
        {
            int applicationId = 2;
            string subscriberId = "KEVIN";
            string userName = "KEVIN";
            string portCode = "KP";
            string applicationEntityId = "eGateExportRoadForm";
            List<string> appEntityList = new List<string>();
            appEntityList.Add("eGateExportRoadFormAssignToSEZ");
            appEntityList.Add("eGateLoadedExportRoadFormCreate");
            List<AuthorizedFunctionDTO> userMenuFunctions = _accountRepository.GetAuthorisedUserFunctions(applicationId, subscriberId, userName, portCode, applicationEntityId, appEntityList);
            Assert.IsNotNull(userMenuFunctions);
        }
        #endregion

        #region Test Methods for RestAPI class
        [TestMethod]
        public void GetKpclApiUrlData()
        {
            string KPCLuserurl = "http://192.168.0.81:8090/api/Users";
            var KPCLUserDtos = ApiClient.RestGet<List<UserMasterVO>>(KPCLuserurl);
            Assert.IsNotNull(KPCLUserDtos);
        }

        [TestMethod]
        public void GetAuthorisedUserFunctions_ByRestAPI()
        {
            int applicationId = 2;
            string subscriberId = "KEVIN";
            string userId = "12";
            string portCode = "KP";
            string applicationEntityId = "eGateExportRoadForm";

            string url = "http://localhost:62030/api/Functions/GetAuthorisedUserFunctions/" + applicationId + "/" + subscriberId + "/" + userId + "/" + portCode + "/" + applicationEntityId;

            List<AuthorizedFunctionDTO> authorizedFunctionDtos = ApiClient.RestGet<List<AuthorizedFunctionDTO>>(url);
            Assert.IsNotNull(authorizedFunctionDtos);
        }

        [TestMethod]
        public void GetAuthorisedUserFunctionsByFunctionCode_RestAPI()
        {
            int applicationId = 2;
            string subscriberId = "KEVIN";
            string userId = "12";
            string portCode = "KP";
            string applicationEntityId = "eGateExportRoadForm";
            string appEntityFunctionCode = "eGateExportRoadFormAssignToSEZ,eGateExportRoadForm";

            string url = "http://localhost:62030/api/Functions/GetAuthorisedUserFunctions/" + applicationId + "/" + subscriberId + "/" + userId + "/" + portCode + "/" + applicationEntityId + "/" + appEntityFunctionCode;

            List<AuthorizedFunctionDTO> authorizedFunctionDtos = ApiClient.RestGet<List<AuthorizedFunctionDTO>>(url);
            Assert.IsNotNull(authorizedFunctionDtos);
        }

        #endregion
    }

    #region Sample DTO Classes for outside application API Url
    public class UserMasterVO
    {
        public int UserID { get; set; }
        public string SubCatCode { get; set; }
        public string UserType { get; set; }
        public string SubCatName { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserTypeID { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string ContactNo { get; set; }
        public string Designation { get; set; }
        public string EmailID { get; set; }
        public string ReferenceNo { get; set; }
        public string RecordStatus { get; set; }
        public virtual ICollection<RoleVO> Roles { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string PortCode { get; set; }
        public Nullable<int> WorkflowInstanceId { get; set; }
        public string AnonymousUserYn { get; set; }
        public string PWD { get; set; }
        public string IsFirstTimeLogin { get; set; }
        public Nullable<DateTime> PwdExpirtyDate { get; set; }
        public int IncorrectLogins { get; set; }
        public Nullable<DateTime> LoginTime { get; set; }
        public string DormantStatus { get; set; }
        public string ReasonForAccess { get; set; }
        public string ValidFromDate { get; set; }
        public string ValidToDate { get; set; }
        public List<string> PortNames { get; set; }

    }
    public class RoleVO
    {
        public int RoleID { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public string RecordStatus { get; set; }
        public int CreatedBy { get; set; }
        public int ModuleID { get; set; }
        public int SubModuleID { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public List<RolePrivilegeVO> RolePrivileges { get; set; }
    }
    public class RolePrivilegeVO
    {
        public int RoleID { get; set; }
        public int EntityID { get; set; }
        public string SubCatCode { get; set; }
        public string RecordStatus { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
    }
    #endregion
}
