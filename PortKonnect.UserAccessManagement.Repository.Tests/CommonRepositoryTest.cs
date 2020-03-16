using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;

namespace PortKonnect.UserAccessManagement.Repository.Tests
{
    [TestClass]
    public class CommonRepositoryTest
    {
        public IUserContext _UserContext;
        public ICommonRepository _CommonRepository;
        public CommonRepositoryTest()
        {
            _UserContext=new UserContext();
            _CommonRepository = new CommonRepository(_UserContext);
        }

        [TestMethod]
        public void GetPartnerTypes()
        {
            var partnerTypes = _CommonRepository.GetPartnerTypes();
            Assert.IsNotNull(partnerTypes);
        }
    }
}
