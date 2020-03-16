using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Repositories;

namespace PortKonnect.UserAccessManagement.Domain.Tests
{
    [TestClass]
    public class AccountApplicationTest
    {
        private IAccountService _accountService;
        private IUserContext _userContext;

        public AccountApplicationTest()
        {
            _userContext = new UserContext();
            _accountService = new AccountService(_userContext, new AccountRepository(_userContext));
        }

        [TestMethod]
        public void UserTest()
        {
            ////Arrange
            string uname = "KPCT";

            ////Act
            List<MenuModuleDTO> menu = _accountService.GetMenuForUser(2, uname, "4");
            ////Assert
            Assert.IsNotNull(menu);
        }
    }
}
