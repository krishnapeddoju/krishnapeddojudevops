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
	public class RoleDataService : IRoleDataService
	{
		public IUserContext _userContext;
		public ICommonRepository _commonRepository;
		public RoleDataService(IUserContext userContext, ICommonRepository commonRepository)
		{
			_userContext = userContext;
			_commonRepository = commonRepository;
		}

        public RoleDTO GetRoleForRoleId(int appId, string roleId, string subscriberId, string userId)
        {
            RoleDTO roleDto = !string.IsNullOrEmpty(roleId) ? (from r in _userContext.Roles.Where(r => r.RoleId == roleId && r.SubscriberId == subscriberId) select r).FirstOrDefault().MapToDTO() : new RoleDTO();

            if (!string.IsNullOrEmpty(roleId) && roleDto == null)
                return null;


            List<ModulesEntityFunction> modulesEntityFunctions = (from m in _userContext.ModulesEntityFunctions.Where(m => m.ApplicationId == appId) select m).Distinct().ToList();

            List<UserRoleEntityFunction> userRoleEntityFunctions =
                (from u in
                     _userContext.UserRoleEntityFunctions.Where(
                         u => u.ApplicationId == appId && u.SubscriberId == subscriberId && u.UserId == userId)
                 select u).Distinct().ToList();

            List<string> entityIds =
                (from e in
                     userRoleEntityFunctions
                 select e.ApplicationEntityId).ToList();


            List<ApplicationEntity> appEntities = (from e in _userContext.ApplicationEntities.Where(t => entityIds.Contains(t.ApplicationEntityId)) select e).ToList();
            List<string> entityFuncIds =
                (from e in
                     userRoleEntityFunctions
                 select e.FunctionCode).ToList();
            List<MenuModuleDTO> moduleCodes =
                (from m in
                     modulesEntityFunctions.Where(m => entityIds.Contains(m.ApplicationEntityId))
                 select new MenuModuleDTO()
                 {
                     ModuleId = m.ModuleCode,
                     ModuleName = m.ModuleName,
                     ModuleIcon = m.ModuleIcon
                 }).ToList();
            moduleCodes = moduleCodes.GroupBy(m => m.ModuleId).Select(m => m.FirstOrDefault()).ToList();
            List<MenuModuleDTO> menuModules = new List<MenuModuleDTO>();
            foreach (var mod in moduleCodes)
            {
                List<MenuEntityDTO> menuEntities = new List<MenuEntityDTO>();
                List<MenuEntityDTO> entities = (from m in modulesEntityFunctions.Where(m => entityIds.Contains(m.ApplicationEntityId) && mod.ModuleId == m.ModuleCode && m.ApplicationId == appId)
                                                select new MenuEntityDTO()
                                                {
                                                    AppEntityId = m.ApplicationEntityId,
                                                    AppEntityName = m.EntityName,
                                                    EntityUrl = m.EntityUrl,
                                                  //  AppFunctions = m.applicationEntityFunctions.MapToDTO()
                                                }).Distinct().ToList();
                entities = entities.GroupBy(m => m.AppEntityId).Select(m => m.FirstOrDefault()).ToList();
                foreach (var ent in entities)
                {
                    List<MenuFunctionDTO> entityFunctions = (from m in modulesEntityFunctions.Where(m => entityFuncIds.Contains(m.FunctionCode) && ent.AppEntityId == m.ApplicationEntityId)
                                                             select new MenuFunctionDTO()
                                                             {
                                                                 FunctionCode = m.FunctionCode,
                                                                 FunctioName = m.FunctionName,
                                                                 Url = m.FormUrl,
                                                                 MenuOrder = m.FunctionOrder,                                                                                                                                  
                                                                 IsInRole = roleDto.RoleFunctions != null ? roleDto.RoleFunctions.FirstOrDefault(t => t.FunctionCode == m.FunctionCode && t.IsDeleted == UAMGlobalConstants.IsDeletedNo) != null ? UAMGlobalConstants.IsInRoleYes : UAMGlobalConstants.IsInRoleNo : UAMGlobalConstants.IsInRoleNo
                                                             }).Distinct().ToList();
                    if (entityFunctions.Any())
                    {
                        menuEntities.Add(new MenuEntityDTO()
                        {
                            AppEntityId = ent.AppEntityId,
                            AppEntityName = ent.AppEntityName,
                            EntityUrl = (from m in entityFunctions orderby m.MenuOrder select m.Url).FirstOrDefault(),
                            AppFunctions = entityFunctions
                        });
                    }
                }
                menuModules.Add(new MenuModuleDTO()
                {
                    ModuleId = mod.ModuleId,
                    ModuleName = mod.ModuleName,
                    ModuleIcon = mod.ModuleIcon,
                    AppEntities = menuEntities
                });
            }

            roleDto.Modules = menuModules;
            roleDto.PartnerTypeNameArray = new List<string>();
            if (roleDto.PartnerTypeArray != null)
            {
                foreach (var partnerType in roleDto.PartnerTypeArray)
                {
                    string partnerTypeName = _commonRepository.GetPartnerTypeNames(partnerType);
                    roleDto.PartnerTypeNameArray.Add(partnerTypeName);

                }
            }


            return roleDto;
        }       

        public List<RoleDTO> GetRoles(ContextDTO contextDto)
		{
            // Hide default roles which start with _
			List<RoleDTO> rolesGridList =
				(from r in
					 _userContext.Roles.Where(
						 t => t.ApplicationId == contextDto.ApplicationId 
                           && t.SubscriberId == contextDto.SubscriberId
                           && !t.RoleName.StartsWith("_")).OrderByDescending(t => t.CreatedOn)
				 select new RoleDTO()
				 {
					 RoleId = r.RoleId,
					 RoleCode = r.RoleCode,
					 RoleName = r.RoleName,
					 RecordStatus = r.RecordStatus
				 }).ToList();
			return rolesGridList;
		}
	}
}
