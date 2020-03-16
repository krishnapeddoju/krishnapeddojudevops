using PortKonnect.UserAccessManagement.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class UserPortMapToDTO
    {
        public static List<UserPortDTO> MapToDTO(this IEnumerable<UserPort> userPorts)
        {
            List<UserPortDTO> userPortDtos = new List<UserPortDTO>();
            if (userPorts != null)
            {
                foreach (UserPort item in userPorts)
                {
                    userPortDtos.Add(item.MapToDTO());
                }
            }
            return userPortDtos;
        }

        public static UserPortDTO MapToDTO(this UserPort userPort)
        {
            UserPortDTO dto = new UserPortDTO();
            if (userPort != null)
            {
                dto.UserId = userPort.UserId;
                dto.PortCode = userPort.PortCode;
                dto.RecordStatus = userPort.RecordStatus;
                dto.CreatedBy = userPort.CreatedBy;
                dto.CreatedOn = userPort.CreatedOn;
                dto.UpdatedBy = userPort.UpdatedBy;
                dto.UpdatedOn = userPort.UpdatedOn;
            }
            return dto;
        }
    }
}
