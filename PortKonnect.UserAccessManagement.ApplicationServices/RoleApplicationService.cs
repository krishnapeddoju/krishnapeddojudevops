using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.MapToDTOS;
using PortKonnect.UserAccessManagement.Domain.Repositories;
using PortKonnect.UserAccessManagement.GlobalConstants;
using PortKonnect.UserAccessManagement.Repositories;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
	public class RoleApplicationService : ServiceBase, IRoleApplicationService
	{
		public IRoleRepository _roleRepository;
		public RoleApplicationService(IUserContext userContext, IRoleRepository roleRepository)
		{
			UserContext = userContext;
			_roleRepository = roleRepository;
		}
		public void AddRole(RoleDTO roleDto, ContextDTO contextDto)
		{
			EncloseTransactionAndHandleException(() =>
			{
				Role role = new Role();
				RoleDTO roleDTO = new RoleDTO();
                bool isNewRole = false;

				if (roleDto.RoleId != "0" && !string.IsNullOrEmpty(roleDto.RoleId))
				{
					role = _roleRepository.GetRolesForRoleId(roleDto.RoleId, contextDto.ApplicationId,contextDto.SubscriberId);
					roleDTO = role.MapToDTO();
					role.UpdateRole(roleDto.RoleName, roleDto.RoleCode);
					role.ChangeUpdatedByAndOn(contextDto.UserId);
				}
				else
				{
                    isNewRole = true;
                    roleDto.RoleId = Guid.NewGuid().ToString();
					role = new Role(roleDto.RoleId, contextDto.ApplicationId, contextDto.SubscriberId, roleDto.RoleName, roleDto.RoleCode, UAMGlobalConstants.RecordStatus, contextDto.UserId);
				}


				if (roleDTO.RoleFunctions != null)
				{
						foreach (RoleFunction r in role.roleFunctions)
					{
						if (roleDto.RoleFunctions.FirstOrDefault(t => t.FunctionCode == r.FunctionCode) != null && roleDto.RoleFunctions.FirstOrDefault(t => t.FunctionCode == r.FunctionCode).IsDeleted == UAMGlobalConstants.IsDeletedYes)
						{
							r.UpdateIsDeleted(UAMGlobalConstants.IsDeletedYes);
							r.ChangeUpdatedByAndOn(contextDto.UserId);
						}
						else if (roleDto.RoleFunctions.FirstOrDefault(t => t.FunctionCode == r.FunctionCode) != null && roleDto.RoleFunctions.FirstOrDefault(t => t.FunctionCode == r.FunctionCode).IsDeleted == UAMGlobalConstants.IsDeletedNo)
						{
							r.UpdateIsDeleted(UAMGlobalConstants.IsDeletedNo);
							r.ChangeUpdatedByAndOn(contextDto.UserId);
						}
					}
					foreach (string funcCode in roleDto.RoleFunctionCodeArray)
					{
						if (roleDTO.RoleFunctionCodeArray == null)
						{
                            foreach (var item in roleDto.Modules)
                            {
                                foreach (MenuEntityDTO m in item.AppEntities)
                                {
                                    if (m.AppFunctions.FirstOrDefault(t => t.FunctionCode == funcCode) != null)
                                    {
                                        role.AddRoleFunction(m.AppEntityId, funcCode, UAMGlobalConstants.IsDeletedNo, UAMGlobalConstants.RecordStatus, contextDto.UserId, contextDto.ApplicationId, contextDto.SubscriberId);
                                    }
                                }
                            }
						}
						else if (!roleDTO.RoleFunctionCodeArray.Contains(funcCode))
						{
                            foreach (var item in roleDto.Modules)
                            {
                                foreach (MenuEntityDTO m in item.AppEntities)
                                {
                                    if (m.AppFunctions.FirstOrDefault(t => t.FunctionCode == funcCode) != null)
                                    {
                                        role.AddRoleFunction(m.AppEntityId, funcCode, UAMGlobalConstants.IsDeletedNo, UAMGlobalConstants.RecordStatus, contextDto.UserId, contextDto.ApplicationId, contextDto.SubscriberId);
                                    }
                                }
                            }
						}
					}
				}
				else
				{
					foreach (string funcCode in roleDto.RoleFunctionCodeArray)
                    {
                        foreach (var item in roleDto.Modules)
                        {
                            foreach (MenuEntityDTO m in item.AppEntities)
                            {
                                if (m.AppFunctions.FirstOrDefault(t => t.FunctionCode == funcCode) != null)
                                {
                                    role.AddRoleFunction(m.AppEntityId, funcCode, UAMGlobalConstants.IsDeletedNo, UAMGlobalConstants.RecordStatus, contextDto.UserId, contextDto.ApplicationId, contextDto.SubscriberId);
                                }
                            }
                        }
					}
				}


				if (roleDTO.PartnerTypeRoles != null)
				{
					foreach (PartnerTypeRole partnerTypeRole in role.PartnerTypeRoles)
					{
						if (!roleDto.PartnerTypeArray.Contains(partnerTypeRole.PartnerTypeId))
						{
							partnerTypeRole.UpdateIsDeleted(UAMGlobalConstants.IsDeletedYes);
						}
						else if (roleDto.PartnerTypeArray.Contains(partnerTypeRole.PartnerTypeId) && partnerTypeRole.IsDeleted == UAMGlobalConstants.IsDeletedYes)
						{
							partnerTypeRole.UpdateIsDeleted(UAMGlobalConstants.IsDeletedNo);
						}
					}
					foreach (string partnerTypeId in roleDto.PartnerTypeArray)
					{
						if (roleDTO.PartnerTypeArray == null)
						{
							role.AddPartnerTypeRole(partnerTypeId, UAMGlobalConstants.IsDeletedNo, contextDto.ApplicationId, contextDto.SubscriberId);
						}
						else if (!roleDTO.PartnerTypeArray.Contains(partnerTypeId) && roleDTO.PartnerTypeRoles.FirstOrDefault(t => t.PartnerTypeId == partnerTypeId) == null)
						{
							role.AddPartnerTypeRole(partnerTypeId, UAMGlobalConstants.IsDeletedNo, contextDto.ApplicationId, contextDto.SubscriberId);
						}
					}
				}
				else
				{
					foreach (string partnerType in roleDto.PartnerTypeArray)
					{
						role.AddPartnerTypeRole(partnerType, UAMGlobalConstants.IsDeletedNo, contextDto.ApplicationId, contextDto.SubscriberId);
					}
				}

				_roleRepository.AddRole(role);

                if (isNewRole)
                {
                    SendAddRoleNotification(role.MapToDTO());
                }
            });
		}

		public List<RoleDTO> GetRoles()
		{
			throw new NotImplementedException();
		}

		public List<RoleDTO> GetRolesForUser(int applicationId, string subscriberId, string userId)
		{
			throw new NotImplementedException();
		}
	}
}
