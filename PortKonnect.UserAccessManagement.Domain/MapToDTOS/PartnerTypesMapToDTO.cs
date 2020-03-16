using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class PartnerTypesMapToDTO
    {
        public static List<PartnerTypeDTO> MapToDTO(this IEnumerable<PartnerTypes> partnerTypes)
        {
            List<PartnerTypeDTO> partnerTypeList = new List<PartnerTypeDTO>();
            if (partnerTypes != null)
            {
                foreach (PartnerTypes partnerType in partnerTypes)
                {
                    partnerTypeList.Add(partnerType.MapToDTO());
                }
            }
            return partnerTypeList;

        }

        public static PartnerTypeDTO MapToDTO(this PartnerTypes partnerType)
        {
            if (partnerType == null)
            {
                return null;
            }
            PartnerTypeDTO partnerTypeDto = new PartnerTypeDTO()
            {
                PartnerTypeId = partnerType.PartnerId,
                PartnerTypeName = partnerType.partnerTypeName,
                IsDelete=partnerType.IsDelete,
                SubscriberId=partnerType.SubscriberId
            };
            return partnerTypeDto;
        }
    }
}
