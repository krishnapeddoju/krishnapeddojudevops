using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.DataServcies.ServiceContracts;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.MapToDTOS;
using PortKonnect.UserAccessManagement.GlobalConstants;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;

namespace PortKonnect.UserAccessManagement.DataServcies
{
	public class UserRoleDataService : IUserRoleDataService
	{
		public IUserContext _userContext;
		public ICommonRepository _commonRepository;
		public UserRoleDataService(IUserContext userContext, ICommonRepository commonRepository)
		{
			_userContext = userContext;
			_commonRepository = commonRepository;
		}

		public List<UserDTO> GetUsersToAssignUserRoles(int applicationId, string subscriberId, string userId,
		   string memberId, string userName, string firstName, string emailId, string contactNumber)
		{
            List<UserDTO> usersList = new List<UserDTO>();

            var userdto = (from u in _userContext.Users
                           join s in _userContext.SubscriptionMembers on u.PartnerId equals s.MemberId
                           join p in _userContext.Partners on u.PartnerId equals p.PartnerId
                           where s.ApplicationId == applicationId && s.MemberId==memberId && u.UserRoles.Any(c=>c.SubscriberId==subscriberId && c.IsDeleted == UAMGlobalConstants.IsDeletedNo)
                           && s.PartnerId == subscriberId && p.partnerTypes.Any(d => d.SubscriberId == subscriberId)
                           && (userName == "All" || (u.UserName.ToUpper().Contains(userName.ToUpper())))
                           && (firstName == "All" || ((u.FirstName + " " + u.LastName).ToUpper().Contains(firstName.ToUpper())))
                           && (emailId == "All" || (u.EmailId.ToUpper().Contains(emailId.ToUpper())))
                           && (contactNumber == "All" || (u.ContactNo.ToUpper().Contains(contactNumber.ToUpper())))
                           orderby u.CreatedOn descending
                           select new
                           {
                               UserId = u.UserId,
                               UserName = u.UserName,
                               FirstName = u.FirstName,
                               LastName = u.LastName,
                               ContactNumber = u.ContactNo,
                               EmailId = u.EmailId,
                               RecordStatus = u.RecordStatus,
                               PartnerType = p.PartnerType,
                               PartnerId = p.PartnerId,
                               UserRoles = u.UserRoles.Where(c => c.SubscriberId == subscriberId)
                           }).ToList();


            List<Role> roles = (from role in _userContext.Roles select role).ToList();

            foreach (var dto in userdto)
            {
                UserDTO userDto = new UserDTO()
                {
                    UserId = dto.UserId,
                    UserName = dto.UserName,
                    Name = dto.FirstName + " " + dto.LastName,
                    ContactNumber = dto.ContactNumber,
                    EmailId = dto.EmailId,
                    PartnerId = dto.PartnerId,
                    PartnerType = dto.PartnerType,
                    UserRoles = dto.UserRoles.MapToDTO()
                };
                if (dto.UserRoles.Any())
                {
                    userDto.UserRoleArray = new List<string>();
                    //userDto.UserRoleNameArray = new List<string>();
                    foreach (var item in userDto.UserRoles.Where(t => t.IsDeleted == UAMGlobalConstants.IsDeletedNo && t.ApplicationId == applicationId && t.SubscriberId == subscriberId))
                    {
                        var firstOrDefault = roles.FirstOrDefault(t => t.RoleId == item.RoleId);
                        if (firstOrDefault != null)
                        {
                            userDto.UserRoleArray.Add(firstOrDefault.RoleId);
                            //userDto.UserRoleNameArray.Add(firstOrDefault.RoleName);
                            if (String.IsNullOrEmpty(userDto.UserRoleNameArray))
                                userDto.UserRoleNameArray = firstOrDefault.RoleName;
                            else
                                userDto.UserRoleNameArray = userDto.UserRoleNameArray + "," + firstOrDefault.RoleName;
                        }
                    }
                }
                usersList.Add(userDto);
            }
            
            return usersList;
        }


        public List<UserDTO> GetAllUsersToAssignUserRoles(int applicationId, string subscriberId, string userId,
           string memberId, string userName, string firstName, string emailId, string contactNumber)
        {
            List<UserDTO> usersList = new List<UserDTO>();

            var userdto = (from u in _userContext.Users
                           join s in _userContext.SubscriptionMembers on u.PartnerId equals s.MemberId
                           join p in _userContext.Partners on u.PartnerId equals p.PartnerId
                           where s.ApplicationId == applicationId  
                           && s.PartnerId==subscriberId && p.partnerTypes.Any(d=>d.SubscriberId==subscriberId && d.IsDelete == UAMGlobalConstants.IsDeletedNo) 
                           && u.UserRoles.Any(c => c.SubscriberId == subscriberId && c.IsDeleted == UAMGlobalConstants.IsDeletedNo)
                           && (userName == "All" || (u.UserName.ToUpper().Contains(userName.ToUpper())))
                           && (firstName == "All" || ((u.FirstName + " " + u.LastName).ToUpper().Contains(firstName.ToUpper())))
                           && (emailId == "All" || (u.EmailId.ToUpper().Contains(emailId.ToUpper())))
                           && (contactNumber == "All" || (u.ContactNo.ToUpper().Contains(contactNumber.ToUpper())))
                           orderby u.CreatedOn descending
                           select new
                           {
                               UserId = u.UserId,
                               UserName = u.UserName,
                               FirstName = u.FirstName,
                               LastName = u.LastName,
                               ContactNumber = u.ContactNo,
                               EmailId = u.EmailId,
                               RecordStatus = u.RecordStatus,
                               PartnerType = p.PartnerType,
                               PartnerId = p.PartnerId,
                               UserRoles = u.UserRoles.Where(c=>c.SubscriberId==subscriberId)
                           }).ToList();


            List<Role> roles = (from role in _userContext.Roles select role).ToList();

                    foreach (var dto in userdto)
                    {
                        UserDTO userDto = new UserDTO()
                        {
                            UserId = dto.UserId,
                            UserName = dto.UserName,
                            Name = dto.FirstName + " " + dto.LastName,
                            ContactNumber = dto.ContactNumber,
                            EmailId = dto.EmailId,
                            PartnerId = dto.PartnerId,
                            PartnerType = dto.PartnerType,
                            UserRoles = dto.UserRoles.MapToDTO()
                        };
                        if (dto.UserRoles.Any())
                        {
                            userDto.UserRoleArray = new List<string>();
                            //userDto.UserRoleNameArray = new List<string>();
                            foreach (var item in userDto.UserRoles.Where(t => t.IsDeleted == UAMGlobalConstants.IsDeletedNo && t.ApplicationId==applicationId && t.SubscriberId==subscriberId))
                            {
                                var firstOrDefault = roles.FirstOrDefault(t => t.RoleId == item.RoleId);
                                if (firstOrDefault != null)
                                {
                                    userDto.UserRoleArray.Add(firstOrDefault.RoleId);
                                    //userDto.UserRoleNameArray.Add(firstOrDefault.RoleName);
                                    if (String.IsNullOrEmpty(userDto.UserRoleNameArray))
                                        userDto.UserRoleNameArray = firstOrDefault.RoleName;
                                    else
                                        userDto.UserRoleNameArray = userDto.UserRoleNameArray + "," + firstOrDefault.RoleName;
                                }
                            }
                        }
                        usersList.Add(userDto);
                    }
                   return usersList;
        }


        public List<RoleDTO> GetRoles(string PartnerType, int applicationId, string subScriberId)
		{
			List<RoleDTO> roleDto = (from pt in _userContext.PartnerTypeRoles
									 join r in _userContext.Roles on pt.RoleId equals r.RoleId
									 where
										 pt.PartnerTypeId.Equals(PartnerType) && pt.ApplicationId.Equals(applicationId) && pt.SubscriberId == subScriberId
									 select new RoleDTO
									 {
										 RoleId = pt.RoleId,
										 RoleCode = r.RoleCode,
										 RoleName = r.RoleName
									 }).OrderBy(t => t.RoleName).Distinct().ToList();
			return roleDto;
		}

		public List<RoleDTO> GetRolesForPartnerType(string userId, int applicationId, string membeId, string subscriberId)
		{
			User users = (from u in _userContext.Users.Where(t => t.UserId == userId)
						  join partner in _userContext.Partners on u.PartnerId equals partner.PartnerId
						  join sm in _userContext.SubscriptionMembers on partner.PartnerId equals sm.MemberId
						  where sm.ApplicationId == applicationId
                          select u).FirstOrDefault();

			List<Role> roles = (from role in _userContext.Roles.Where(r => r.ApplicationId == applicationId && r.SubscriberId==subscriberId)
								select role).ToList();
			List<RoleDTO> roleDtos = new List<RoleDTO>();

			if (users != null)
			{

				string PartnerTypeCode = users.PartnerType;
				foreach (var role in roles)
				{
                        if (role.PartnerTypeRoles.FirstOrDefault(t => t.PartnerTypeId == PartnerTypeCode && t.IsDeleted == UAMGlobalConstants.IsDeletedNo) != null)
                        {
                            roleDtos.Add(new RoleDTO()
                            {
                                RoleId = role.RoleId,
                                RoleCode = role.RoleCode,
                                RoleName = role.RoleName
                            });
                        }                    
				}
			}

			return roleDtos;
		}

	}
}
