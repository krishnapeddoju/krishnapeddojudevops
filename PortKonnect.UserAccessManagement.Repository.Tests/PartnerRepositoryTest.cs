using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Repositories;

namespace PortKonnect.UserAccessManagement.Repository.Tests
{
    [TestClass]
   public class PartnerRepositoryTest
    {
        private readonly PartnerRepository _partnerRepository;
        private readonly UserContext _userContext;
        public PartnerRepositoryTest()
        {
            _userContext=new UserContext();
            _partnerRepository =new PartnerRepository(_userContext);
        }

        [TestMethod]
        public void GetPartnerDetails()
        {
            var partnerDetails = _partnerRepository.GetPartner(2, "SupportAdmin");
            Assert.IsNotNull(partnerDetails);
        }

    }
}
