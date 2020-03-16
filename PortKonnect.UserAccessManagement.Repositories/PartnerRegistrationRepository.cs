using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.Repositories;
using PortKonnect.UserAccessManagement.GlobalConstants;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public class PartnerRegistrationRepository : IPartnerRegistrationRepository
    {
        private readonly IUserContext _userContext;
        public PartnerRegistrationRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public void AddOrUpdatePartnerRegistration(PartnerRegistration partnerRegistration)
        {

            _userContext.PartnerRegistrations.AddOrUpdate(partnerRegistration);
        }

        public string GenerateRequisitionNo()
        {
            string formNumber = string.Empty;
            int formNumberCount = _userContext.PartnerRegistrations.Count(e => !string.IsNullOrEmpty(e.RequisitionNo));
            while (formNumber == string.Empty)
            {
                formNumberCount++;
                formNumber = "REQ" + DateTime.Now.ToString("yyyyMMdd") + formNumberCount.ToString(UAMGlobalConstants.PartnerRegistrationNumberLength);

                if (_userContext.PartnerRegistrations.Count(c => c.RequisitionNo.Equals(formNumber)) > 0)
                {
                    formNumber = string.Empty;
                }
            }

            return formNumber;
        }

        public List<PartnerRegistrationListDTO> GetPendingPartnerRegistrationsGridList(string estbName, string partnerType, string status)
        {
            IQueryable<PartnerRegistrationListDTO> partnerListDtos = (from p in _userContext.PartnerRegistrations
                                  orderby p.CreatedOn descending where p.RecordStatus == UAMGlobalConstants.RecordStatus
                                  select new PartnerRegistrationListDTO
                                  {
                                      PartnerRegistrationId = p.PartnerRegistrationId,
                                      PartnerName = p.PartnerName,
                                      PartnerType = p.PartnerType,
                                      RequisitionNo = p.RequisitionNo,
                                      CreatedOn = p.CreatedOn,
                                      WFStatus=p.WFStatus
                                  });
            
            if (!string.IsNullOrWhiteSpace(estbName) && estbName != UAMGlobalConstants.All)
            {
                partnerListDtos = partnerListDtos.Where(k => k.PartnerName.Contains(estbName));
            }

            if (!string.IsNullOrWhiteSpace(partnerType) && partnerType != UAMGlobalConstants.All)
            {
                partnerListDtos = partnerListDtos.Where(k => k.PartnerType.ToUpper().Contains(partnerType.ToUpper()));
            }

            if (!string.IsNullOrWhiteSpace(status) && status != UAMGlobalConstants.All)
            {
                partnerListDtos = partnerListDtos.Where(k => k.WFStatus.ToUpper().Contains(status.ToUpper()));
            }

            return partnerListDtos.OrderByDescending(c=>c.CreatedOn).ToList();
        }

        public PartnerRegistration GetPartnerRegistrationByPartnerId(string requisitionNo)
        {
            PartnerRegistration partner = (from p in _userContext.PartnerRegistrations.Where(p => p.RequisitionNo == requisitionNo) select p).FirstOrDefault();
            if (partner != null)
            {
                partner.AssignPartnerRegistrationDoc(partner.partnerRegistrationDocs.OrderBy(d => d.PDocumentType).ToList());
            }
            return partner;
        }

        public PartnerRegistration GetPartnerRegistration(string requisitionNo, string emailId, string mobNo)
        {
            PartnerRegistration partner = (from p in _userContext.PartnerRegistrations.Where(p => p.RequisitionNo == requisitionNo && p.PartnerRegistrationAddress.Email.Equals(emailId) && p.PartnerRegistrationAddress.MobileNumber.Equals(mobNo) && p.RecordStatus==UAMGlobalConstants.RecordStatus) select p).FirstOrDefault();
            if (partner != null)
            {
                partner.AssignPartnerRegistrationDoc(partner.partnerRegistrationDocs.OrderBy(d => d.PDocumentType).ToList());
            }
            return partner;
        }

        public List<string> GetRoleIdsBasedOnPartnerType(string partnerType, int appId, string subscriberId)
        {
            List<string> roleIds = (from p in _userContext.PartnerTypeRoles.Where(p => p.PartnerTypeId == partnerType && p.SubscriberId == subscriberId && p.ApplicationId == appId) select p.RoleId).Distinct().ToList();
            return roleIds;
        }
        
        public List<PartnerRegistrationListDTO> GetPartnerRegistrationsForUniqueItem()
        {
            List<PartnerRegistrationListDTO> partnerListDtos = new List<PartnerRegistrationListDTO>();
            var partnerListDto = (from p in _userContext.PartnerRegistrations
                                  orderby p.CreatedOn descending
                                  select new
                                  {
                                      PartnerRegistrationId = p.PartnerRegistrationId,
                                      PartnerName = p.PartnerName,
                                      PartnerType = p.PartnerType,
                                      RequisitionNo = p.RequisitionNo,
                                      CreatedOn = p.CreatedOn
                                  });

            foreach (var dto in partnerListDto.ToList())
            {
                PartnerRegistrationListDTO partner = new PartnerRegistrationListDTO()
                {
                    PartnerRegistrationId = dto.PartnerRegistrationId,
                    PartnerName = dto.PartnerName,
                    PartnerType = dto.PartnerType,
                    RequisitionNo = dto.RequisitionNo,
                    CreatedOn = dto.CreatedOn


                };

                partnerListDtos.Add(partner);
            }
            return partnerListDtos;
        }
    }
}
