using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.ApplicationServices.ServiceContracts;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.Repositories;
using PortKonnect.UserAccessManagement.Repositories;

namespace PortKonnect.UserAccessManagement.Domain.Tests
{
    [TestClass]
    public class UserRoleApplicationServiceTest
    {
        public IUserContext _userContext;
        public IUserRoleApplicationService _userRoleApplicationService;
        public UserRoleApplicationServiceTest()
        {
            _userContext = new UserContext();
            _userRoleApplicationService = new UserRoleApplicationService(_userContext, new UserRoleRepository(_userContext), new UserRepository(_userContext));
        }

        [TestMethod]
        public void AddUserRoleTest()
        {
            UserDTO userDto = new UserDTO();
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
            userDto.UserId = "24";
            userDto.UserRoleArray = new List<string>() { "VesselOperatingAgent" };
            _userRoleApplicationService.AddOrUpdateUserRole(userDto, contextDto.ApplicationId);
        }

    }
}
