using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.DataServcies;
using PortKonnect.UserAccessManagement.DataServcies.ServiceContracts;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;

namespace PortKonnect.UserAccessManagement.Repository.Tests
{
    [TestClass]
    public class UserRoleDataServiceTest
    {
        private IUserRoleDataService _userRoleDataService;
        public ICommonRepository _commonRepository;
        private IUserContext _userContext;

        public UserRoleDataServiceTest()
        {
            _userContext = new UserContext();
            _userRoleDataService = new UserRoleDataService(_userContext,new CommonRepository(_userContext));
        }

        [TestMethod]
        public void GetUsersToAssignUserRoles()
        {
            List<UserDTO> users = _userRoleDataService.GetUsersToAssignUserRoles(2, "KPCT", "3", "KPCT","2","KPCT","asdasd@gmail.com","5456465464");
            Assert.IsNotNull(users);
        }
    }
}
