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
   public static class UserPreferenceMapToDTO
    {

        public static List<UserPreferenceDTO> MapToDTO(this IEnumerable<UserPreference> userPreferences)
        {
            List<UserPreferenceDTO> userPreferenceDtos = new List<UserPreferenceDTO>();
            if (userPreferences != null)
            {
                foreach (var item in userPreferences)
                {
                    userPreferenceDtos.Add(item.MapToDTO());
                }
            }
            return userPreferenceDtos;
        }

        public static UserPreferenceDTO MapToDTO(this UserPreference data)
        {
            UserPreferenceDTO dto = new UserPreferenceDTO();
            if (data != null)
            {
                dto.SendNotificationEmail = data.SendNotificationEmail;
                dto.SendNotificationSms = data.SendNotificationSms;
                dto.SendSystemNotification = data.SendSystemNotification;
            }
            return dto;
        }
    }
}
