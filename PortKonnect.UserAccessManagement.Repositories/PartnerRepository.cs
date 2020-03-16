using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain.Repositories;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.MapToDTOS;
using PortKonnect.UserAccessManagement.GlobalConstants;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {

        private readonly IUserContext _userContext;
        public PartnerRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public void AddPartner(Partner partner)
        {

            _userContext.Partners.AddOrUpdate(partner);
            _userContext.SaveChanges();
        }

        public void UpdatePartner(Partner partner)
        {
            _userContext.Partners.AddOrUpdate(partner);
            _userContext.SaveChanges();
        }

        public Partner GetPartnerByPartnerId(string partnerId, string subscriberId)
        {
            Partner partner = (from p in _userContext.Partners.Where(p => p.PartnerId == partnerId && p.SubscriptionMembers.Any(k => k.PartnerId == subscriberId)) select p).FirstOrDefault();

            return partner;
        }

        public Partner GetPartnerByPartnerCode(string partnerCode)
        {
            Partner partner = (from p in _userContext.Partners.Where(p => p.PartnerCode == partnerCode) select p).FirstOrDefault();

            return partner;
        }

        public Partner GetPartnerByPartnerCode(List<PartnerListDTO> partnersListDtos, string partnerCode)
        {

            Partner partner = (from p in _userContext.Partners.Where(p => p.PartnerCode == partnerCode) select p).FirstOrDefault();

            return partner;
        }

        public Partner GetPartnerByPartnerName(string partnerName)
        {
            Partner partner = (from p in _userContext.Partners.Where(p => p.PartnerName == partnerName) select p).FirstOrDefault();

            return partner;
        }

        public List<PartnerListDTO> GetPartners(string subscriberId, int applicationId, string partnerName, string partnerType, string emailId, string contactNumber)
        {
            //TODO: Need to optimise the query based on IQueryable
            var partnerListDto = (from p in _userContext.Partners
                                  where p.SubscriptionMembers.Any(c=>c.PartnerId==subscriberId)
                                  orderby p.CreatedOn descending
                                  select new PartnerListDTO
                                  {
                                      PartnerId = p.PartnerId,
                                      PartnerCode = p.PartnerCode,
                                      PartnerName = p.PartnerName,
                                      PartnerType = p.PartnerType,
                                      EmailId = p.PartnerAddress.EmailId,
                                      ContactNumber = p.PartnerAddress.ContactNumber,
                                      partnerTypeArray = p.partnerTypes.Where(c=>c.SubscriberId==subscriberId && c.IsDelete==UAMGlobalConstants.IsDeletedNo).Select(d=>d.partnerTypeName).ToList()

                                  }).ToList();


            if (partnerName != "All")
            {
                partnerListDto = partnerListDto.Where(k => k.PartnerName.ToUpper().Contains(partnerName.ToUpper())).ToList();
            }
            if (partnerType != "All")
            {
                partnerListDto = partnerListDto.Where(k => k.PartnerType.ToUpper().Contains(partnerType.ToUpper())).ToList();
            }

            if (emailId != "All")
            {
                partnerListDto = partnerListDto.Where(k => !string.IsNullOrEmpty(k.EmailId) ? (k.EmailId.ToUpper().Contains(emailId.ToUpper())) : (k.EmailId != null)).ToList();
            }

            if (contactNumber != "All")
            {
                partnerListDto = partnerListDto.Where(k => !string.IsNullOrEmpty(k.ContactNumber) ? (k.ContactNumber.ToUpper().Contains(contactNumber.ToUpper())) : (k.ContactNumber != null)).ToList();
            }
            return partnerListDto;
        }

        public int GetPartnersByCodeOtherThanPartnerId(string partnerId, string partnerCode)
        {
            int partnerNos = (from p in _userContext.Partners.Where(p => p.PartnerId != partnerId && p.PartnerCode == partnerCode)
                              select p).Count();
            return partnerNos;
        }

        public int GetPartnersByNameOtherThanPartnerId(string partnerId, string partnerName)
        {
            int partnerNos = (from p in _userContext.Partners.Where(p => p.PartnerId != partnerId && p.PartnerName == partnerName)
                              select p).Count();
            return partnerNos;
        }

        public void DeletePartnerTypes(Partner partner)
        {
            var list = partner.partnerTypes;
            PartnerDTO partnerdtos = partnerdtos = partner.MapToDto();



            //foreach (var item in list)
            //{
            _userContext.PartnerTypes.Remove(partner.partnerTypes.FirstOrDefault());
            //  item.ObjectState=ObjectState.Deleted;
            //}



            _userContext.SaveChanges();
        }

        public Partner GetPartner(int applicationId, string partnerCode)
        {
            Partner partnerDetails = _userContext.Partners.FirstOrDefault(c => c.PartnerCode == partnerCode && c.SubscriptionMembers.Any(d => d.ApplicationId == applicationId));

            return partnerDetails;
        }

        public Partner GetPartnerByPartnerTypeandpartnerCode(string PartnerType, string partnerCode)
        {
            Partner partnerDetails = _userContext.Partners.FirstOrDefault(c => c.PartnerCode == partnerCode && c.PartnerType == PartnerType);

            return partnerDetails;
        }


    }
}
