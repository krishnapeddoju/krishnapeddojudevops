using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.Common.Domain.Model;
using PortKonnect.UserAccessManagement.ApplicationServices.ServiceContracts;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.MapToDTOS;
using PortKonnect.UserAccessManagement.Domain.Repositories;
using PortKonnect.UserAccessManagement.GlobalConstants;
using PortKonnect.UserAccessManagement.Repositories;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public class UserRoleApplicationService : ServiceBase, IUserRoleApplicationService
    {
        public IUserRoleRepository _userRoleRepository;
        public IUserRepository _userRepository;

        public UserRoleApplicationService(IUserContext userContext, IUserRoleRepository userRoleRepository, IUserRepository userRepository)
        {
            UserContext = userContext;
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
        }

        public void AddOrUpdateUserRole(UserDTO userDto, int applicationId)
        {
            EncloseTransactionAndHandleException(() =>
            {
                User user = _userRepository.GetUserForUserId(userDto.UserId);
                UserDTO userDTO = user.MapToDto();


                if (userDTO.UserRoles.Any())
                {
                    var userRolesApp = user.UserRoles.Where(t => t.ApplicationId == applicationId && t.SubscriberId == ApplicationContextDTO.SubscriberId);

                    foreach (UserRole userRole in userRolesApp)
                    {
                        if (userDto.UserRoleArray.Contains(userRole.RoleId))
                        {
                            userRole.UpdateIsDeleted(UAMGlobalConstants.IsDeletedNo);
                            userRole.ChangeUpdatedByAndOn(userDto.UserId);
                        }
                    }


                    foreach (UserRole userRole in user.UserRoles.Where(c=>c.SubscriberId == ApplicationContextDTO.SubscriberId && c.ApplicationId == ApplicationContextDTO.ApplicationId))
                    {
                        if (userRole.ApplicationId == applicationId)
                        {
                            if (!userDto.UserRoleArray.Contains(userRole.RoleId))
                            {
                                userRole.UpdateIsDeleted(UAMGlobalConstants.IsDeletedYes);
                                userRole.ChangeUpdatedByAndOn(userDto.UserId);
                            }
                        }
                    }


                    userDTO.UserRoleArray.Clear();
                    foreach (var role in userRolesApp)
                    {
                        userDTO.UserRoleArray.Add(role.RoleId);
                    }


                    foreach (string roleId in userDto.UserRoleArray)
                    {
                        if (!userDTO.UserRoleArray.Contains(roleId))
                        {
                            user.AssignRole(roleId, ApplicationContextDTO.ApplicationId, UAMGlobalConstants.IsDeletedNo, UAMGlobalConstants.RecordStatus, userDto.UserId, ApplicationContextDTO.SubscriberId);
                        }
                    }
                }
                else
                {
                    foreach (string role in userDto.UserRoleArray)
                    {
                        user.AssignRole(role, ApplicationContextDTO.ApplicationId, UAMGlobalConstants.IsDeletedNo, UAMGlobalConstants.RecordStatus, userDTO.UserId, ApplicationContextDTO.SubscriberId);
                    }
                }

                _userRoleRepository.AddOrUpdateUserRole(user);

                //As per requirement Any role / user information is changed, no need to trigger notification more over template is not defined in this case
                //SendAddOrUpdateUserNotification(user.MapToDto());
            });
        }
    }
}
