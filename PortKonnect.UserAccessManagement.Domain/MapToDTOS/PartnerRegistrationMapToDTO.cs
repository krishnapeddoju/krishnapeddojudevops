using System.Collections.Generic;
using System.Linq;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.GlobalConstants;

namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class PartnerRegistrationMapToDTO
    {
        public static List<PartnerRegistrationDTO> MapToDTO(this IEnumerable<PartnerRegistration> partners)
        {
            List<PartnerRegistrationDTO> partnerDtos = new List<PartnerRegistrationDTO>();
            if (partners != null)
            {
                foreach (var item in partners)
                {
                    partnerDtos.Add(item.MapToDto());
                }
            }
            return partnerDtos;
        }

        public static PartnerRegistrationDTO MapToDto(this PartnerRegistration partner)
        {
            if (partner == null) return null;

            PartnerRegistrationDTO partnerDTO = new PartnerRegistrationDTO
            {
                PartnerRegistrationId = partner.PartnerRegistrationId,

                PartnerType = partner.PartnerType,
                RegistrationNo = partner.RegistrationNo,
                RequisitionNo = partner.RequisitionNo,

                PartnerName = partner.PartnerName,
                PartnerRegistrationAddress =
                    new PartnerRegistrationAddressDTO(partner.PartnerRegistrationAddress.HouseNumber, partner.PartnerRegistrationAddress.StreetName,
                        partner.PartnerRegistrationAddress.AreaName, partner.PartnerRegistrationAddress.TownOrCity, partner.PartnerRegistrationAddress.State,
                        partner.PartnerRegistrationAddress.Country, partner.PartnerRegistrationAddress.ZipCode, partner.PartnerRegistrationAddress.LogoFileName, partner.PartnerRegistrationAddress.Logopath, partner.PartnerRegistrationAddress.Email, partner.PartnerRegistrationAddress.MobileNumber),

                PartnerDirectorDetailss = partner.partnerDirectorDetails.Where(c => c.IsDeleted == UAMGlobalConstants.IsDeletedNo).MapToDTO(),
                DocumentDTOs = partner.partnerRegistrationDocs.Where(c => c.IsDeleted == UAMGlobalConstants.IsDeletedNo).MapToListDto(),

                CIN = partner.CIN,
                PAN = partner.PAN,
                TAN = partner.TAN,
                NatureOfBusiness = partner.NatureOfBusiness,
                Year = partner.Year,
                Status = partner.Status,
                Place = partner.Place,
                VAT = partner.VAT,

                BankName = partner.BankName,
                AccountNo = partner.AccountNo,
                BankAddress = partner.BankAddress,
                IFSCCode = partner.IFSCCode,

                FinanceName = partner.FinanceName,
                FinanceEmail = partner.FinanceEmail,
                FinanceMobile = partner.FinanceMobile,

                OperationsName = partner.OperationsName,
                OperationsEmail = partner.OperationsEmail,
                OperationsMobile = partner.OperationsMobile,

                ITName = partner.ITName,
                ITEmail = partner.ITEmail,
                ITMobile = partner.ITMobile,

                WFStatus = partner.WFStatus,

                IsAccept = partner.IsAccept,

                Remarks = partner.Remarks,

                CreatedBy = partner.CreatedBy,
                CreatedOn = partner.CreatedOn,
                UpdatedBy = partner.UpdatedBy,
                UpdatedOn = partner.UpdatedOn
            };

            return partnerDTO;

        }
    }
}
