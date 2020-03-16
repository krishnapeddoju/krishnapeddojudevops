using PortKonnect.UserAccessManagement.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class UserMapToDTO
    {
        public static List<UserDTO> MapToDTO(this IEnumerable<User> users)
        {
            List<UserDTO> userDtos = new List<UserDTO>();
            if (users != null)
            {
                foreach (User item in users)
                {
                    userDtos.Add(item.MapToDto());
                }
            }
            return userDtos;
        }
        //Review Added ValidFromdate,ValidToDate and Logtime 
        public static UserDTO MapToDto(this User user)
        {
            if (user == null) return null;

            UserDTO userDTO = new UserDTO
            {
                //TODO: Null data has to be validate
                UserId = user.UserId,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailId = user.EmailId,
                ContactNumber = user.ContactNo,
                PartnerId = user.PartnerId,
                ApplicationId = user.ApplicationId,
                Password = user.Password,
                UserPorts = user.UserPorts.MapToDTO(),
                UserRoles = user.UserRoles.MapToDTO(),
                UserPreference = user.UserPreference.MapToDTO(),
                IsDeleted = user.IsDeleted,
                IsFirstTimeLogin = user.IsFirstTimeLogin,
                InCorrectLogins = user.InCorrectLogins,
                RecordStatus = user.RecordStatus,
                validFromDate=user.ValidFromDate==null?null:user.ValidFromDate,
                validToDate=user.ValidToDate==null?null:user.ValidToDate,
                PwdExpiryDate=user.PwdExpiryDate==null?null:user.PwdExpiryDate,
                LogTime=user.LogTime==null?null:user.LogTime,
                DormantStatus=user.DormantStatus==null?null:user.DormantStatus,
                CreatedBy = user.CreatedBy,
                CreatedOn = user.CreatedOn,
                UpdatedBy = user.UpdatedBy,
                UpdatedOn = user.UpdatedOn,
                IsCFSUser = user.IsCFSUser,
                PartnerType =user.PartnerType
            };

            if (userDTO.UserPorts.Any())
            {
                userDTO.UserPortArray = new List<string>();
                foreach (var port in userDTO.UserPorts)
                {
                    userDTO.UserPortArray.Add(port.PortCode);
                }
            }
            if (userDTO.UserRoles.Any())
            {
                userDTO.UserRoleArray = new List<string>();
                foreach (var role in userDTO.UserRoles)
                {
                    userDTO.UserRoleArray.Add(role.RoleId);
                }
            }
            return userDTO;

        }
    }
}
