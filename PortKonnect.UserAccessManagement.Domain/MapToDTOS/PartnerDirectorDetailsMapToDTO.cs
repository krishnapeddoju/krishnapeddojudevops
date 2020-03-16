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
    public static class PartnerDirectorDetailsMapToDTO
    {
        public static List<PartnerDirectorDetailsDTO> MapToDTO(this IEnumerable<PartnerDirectorDetails> partners)
        {
            List<PartnerDirectorDetailsDTO> partnerDtos = new List<PartnerDirectorDetailsDTO>();
            if (partners != null)
            {
                foreach (var item in partners)
                {
                    partnerDtos.Add(item.MapToDto());
                }
            }
            return partnerDtos;
        }

        public static PartnerDirectorDetailsDTO MapToDto(this PartnerDirectorDetails partner)
        {
            if (partner == null) return null;

            PartnerDirectorDetailsDTO partnerDTO = new PartnerDirectorDetailsDTO
            {
                PDirectorDetailsId = partner.PDirectorDetailsId,
                PDirectorName = partner.PDirectorName,
                PDirectorPAN = partner.PDirectorPAN,
                PDirectorAddress = partner.PDirectorAddress,
                PDirectorEmail = partner.PDirectorEmail,
                PDirectorMobile = partner.PDirectorMobile,
                PDirectorTele = partner.PDirectorTele,
                PCountryCode = partner.PCountryCode,
                Type = partner.Type,
                IsDeleted = partner.IsDeleted
            };

            return partnerDTO;

        }
    }
}
