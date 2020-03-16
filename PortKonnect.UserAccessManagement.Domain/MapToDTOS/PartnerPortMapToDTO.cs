using PortKonnect.UserAccessManagement.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class PartnerPortMapToDTO
    {
        public static List<PartnerPortDTO> MapToDTO(this IEnumerable<PartnerPort> partnerPorts)
        {
            List<PartnerPortDTO> partnerPortDtos = new List<PartnerPortDTO>();
            if (partnerPorts != null)
            {
                foreach (var item in partnerPorts)
                {
                    partnerPortDtos.Add(item.MapToDTO());
                }
            }
            return partnerPortDtos;
        }

        public static PartnerPortDTO MapToDTO(this PartnerPort data)
        {
            PartnerPortDTO dto = new PartnerPortDTO();
            if (data != null)
            {
                dto.PartnerId = data.PartnerId;
                dto.PortCode = data.PortCode;
                dto.RecordStatus = data.RecordStatus;
                dto.CreatedBy = data.CreatedBy;
                dto.CreatedOn = data.CreatedOn;
                dto.UpdatedBy = data.UpdatedBy;
                dto.UpdatedOn = data.UpdatedOn;
            }
            return dto;
        }
    }
}
