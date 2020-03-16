using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.DataServcies;
using PortKonnect.UserAccessManagement.Repositories;

namespace PortKonnect.UserAccessManagement.Domain.Tests
{
    [TestClass]
    public class UserAccessDataServiceTest
    {
        public IUserContext _userContext;
        public UserAccessDataService userAccessDataService;
        public UserDataService userDataService;
        public UserAccessDataServiceTest()
        {
            _userContext = new UserContext();
            userDataService=new UserDataService(_userContext,new CommonRepository(_userContext));
        }

        [TestMethod]
        public void HasPrivilegeTest()
        {
            var data = userDataService.GetUsersTobeNotified(2, "PIPAVAV","MTVOA", "c35f96a9-f8f9-4dca-a340-495bcc768d64");
        }
    }
}
