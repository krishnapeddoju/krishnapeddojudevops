using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.DataServcies;
using PortKonnect.UserAccessManagement.DataServcies.ServiceContracts;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;

namespace PortKonnect.UserAccessManagement.Domain.Tests
{
    [TestClass]
    public class RoleDataServiceTest
    {
        public IUserContext _userContext;
        public ICommonRepository _icommonRepository;
        public IRoleDataService _roleDataService;
        public RoleDataServiceTest()
        {
            _userContext = new UserContext();
            _icommonRepository = new CommonRepository(_userContext);
            _roleDataService = new RoleDataService(_userContext, _icommonRepository);
        }

        [TestMethod]
        public void GetRoleForRoleId()
        {
            int appId = 2;
            string roleId = "";
            RoleDTO role = _roleDataService.GetRoleForRoleId(appId, roleId,"KPCT","Admin");
            Assert.IsNotNull(role);
        }
    }
}
