using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.Enums;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class PartnerMapToDTO
    {
        public static List<PartnerDTO> MapToDTO(this IEnumerable<Partner> partners)
        {
            List<PartnerDTO> partnerDtos = new List<PartnerDTO>();
            if (partners != null)
            {
                foreach (var item in partners)
                {
                    partnerDtos.Add(item.MapToDto());
                }
            }
            return partnerDtos;
        }

        public static PartnerDTO MapToDto(this Partner partner)
        {
            if (partner == null) return null;

            PartnerDTO partnerDTO = new PartnerDTO
            {
                PartnerId = partner.PartnerId,
                PartnerName = partner.PartnerName,
                PartnerType = partner.PartnerType,
                PartnerCode = partner.PartnerCode,
                PartnerAddress =
                    new AddressDTO(partner.PartnerAddress.HouseNumber, partner.PartnerAddress.StreetName,
                        partner.PartnerAddress.AreaName, partner.PartnerAddress.TownOrCity, partner.PartnerAddress.State,
                        partner.PartnerAddress.Country, partner.PartnerAddress.ZipCode,
                        partner.PartnerAddress.ContactNumber, partner.PartnerAddress.EmailId,
                        partner.PartnerAddress.WebSite,partner.PartnerAddress.LogoFileName,partner.PartnerAddress.Logopath),
                partnerPorts = partner.partnerPorts.MapToDTO(),
                partnerTypes=partner.partnerTypes.MapToDTO(),
                RecordStatus = partner.RecordStatus,
                CreatedBy = partner.CreatedBy,
                CreatedOn = partner.CreatedOn,
                UpdatedBy = partner.UpdatedBy,
                UpdatedOn = partner.UpdatedOn
            };

            if (partnerDTO.partnerPorts.Any())
            {
                partnerDTO.PartnerPortArray = new List<string>();
                foreach (var port in partnerDTO.partnerPorts)
                {
                    partnerDTO.PartnerPortArray.Add(port.PortCode);
                }
            }

            if (partnerDTO.partnerTypes.Any()) 
            {
                partnerDTO.PartnerTypeArray = new List<string>();
                foreach (var partnertype in partnerDTO.partnerTypes)
                {
                    partnerDTO.PartnerTypeArray.Add(partnertype.PartnerTypeName);

                }
            
            
            }
            return partnerDTO;

        }
    }
}
