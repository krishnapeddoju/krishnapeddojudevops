using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;

namespace PortKonnect.UserAccessManagement.Domain.Tests
{
    [TestClass]
    public class PartnerDomainTest
    {
        private IPartnerApplicationService _partnerApplicationService;
        private IUserContext userContext;
        private ICommonRepository commonRepository;

        public PartnerDomainTest()
        {
            userContext = new UserContext();
            _partnerApplicationService = new PartnerApplicationService(userContext, new PartnerRepository(userContext), new SubscriptionRepository(userContext), new CommonRepository(userContext), new UserRepository(userContext));
        }

        [TestMethod]
        public void PartnerTest()
        {
            ////arrange
            Partner partner = new Partner("ASD", "wer", "ssdf", "er", null, "A", "qwe", DateTime.Now,2,"KPCT");
            ////Act
            partner.SubscribeToApplication(2,"KPCT");
            partner.OperateAtPort("KP");
            ////Assert
            Assert.IsNotNull(partner); //TODO: object is null or not
        }

        [TestMethod]
        public void GetPartnerTest()
        {
            //Arrange
            string partnerId = "PA-KPCT";
            //Act
            PartnerDTO partnerDto = _partnerApplicationService.GetPartner(partnerId);
            //Assert
            Assert.IsNotNull(partnerDto);
        }

        [TestMethod]
        public void GetPartnersTest()
        {
            //Arrange
            //List<PartnerListDTO> partnerDtos = _partnerApplicationService.GetPartnersList("sdf", "sdfsdf", "sdfsdf", "sdfsdf");
            ////Act
            ////Assert
            //Assert.IsNotNull(partnerDtos);
        }
    }
}
