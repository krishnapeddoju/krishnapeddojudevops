using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortKonnect.UserAccessManagement.ApplicationServices.ServiceContracts;
using PortKonnect.UserAccessManagement.DataServcies.ServiceContracts;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.GlobalConstants;
using WebApi.OutputCache.Core.Cache;
using WebApi.OutputCache.V2;
using PortKonnect.Common.Contracts;

namespace PortKonnect.UserAccessManagement.Api
{

	public class UserRoleController : ApiControllerBase
	{
		public IUserRoleApplicationService _userRoleApplicationService;
		public IUserRoleDataService _userRoleDataService;
		public UserRoleController(IUserRoleApplicationService userRoleApplicationService, IUserRoleDataService userRoleDataService)
		{
			_userRoleApplicationService = userRoleApplicationService;
			_userRoleDataService = userRoleDataService;
		}

		[Route("api/GetUsersToAssignUserRoles")]
		[HttpGet]
		public HttpResponseMessage GetUsersToAssignUserRoles(HttpRequestMessage request, string userName, string firstName, string emailId, string contactNumber)
		{
		    List<UserDTO> usersList;
            if(contextDto.MemberType==RoleCodeConstants.TO || contextDto.MemberType == RoleCodeConstants.SuperAdmin || contextDto.MemberType == CargoRoleCodeConstants.Admin)
                usersList= _userRoleDataService.GetAllUsersToAssignUserRoles(contextDto.ApplicationId, contextDto.SubscriberId, contextDto.UserId, contextDto.MemberId, userName, firstName, emailId, contactNumber);
            else
            {
                usersList = _userRoleDataService.GetUsersToAssignUserRoles(contextDto.ApplicationId, contextDto.SubscriberId, contextDto.UserId, contextDto.MemberId, userName, firstName, emailId, contactNumber);
            }
			HttpResponseMessage message = request.CreateResponse<List<UserDTO>>(HttpStatusCode.OK, usersList);
			return message;
		}

		[Route("api/GetRolesForPartnerType/{partnerId}")]
		[HttpGet]
		public HttpResponseMessage GetRolesForPartnerType(HttpRequestMessage request, string partnerId)
		{

			List<RoleDTO> rolesList = _userRoleDataService.GetRolesForPartnerType(partnerId, contextDto.ApplicationId, contextDto.MemberId, contextDto.SubscriberId);
			HttpResponseMessage message = request.CreateResponse<List<RoleDTO>>(HttpStatusCode.OK, rolesList);
			return message;
		}


		[Route("api/GetRolesByPartnerType/{partnerId}")]
		[HttpGet]
		public HttpResponseMessage GetRolesByPartnerType(HttpRequestMessage request, string partnerId)
		{

			List<RoleDTO> rolesList = _userRoleDataService.GetRoles(partnerId, contextDto.ApplicationId, contextDto.SubscriberId);
			HttpResponseMessage message = request.CreateResponse<List<RoleDTO>>(HttpStatusCode.OK, rolesList);
			return message;
		}

		[Route("api/AddOrUpdateUserRole")]
		[HttpPost]
		public HttpResponseMessage AddOrUpdateUserRole(HttpRequestMessage request, UserDTO userDTO)
		{
			return GetHttpResponse(request, () =>
			{
				_userRoleApplicationService.AddOrUpdateUserRole(userDTO, contextDto.ApplicationId);
				HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
				var cache = Configuration.CacheOutputConfiguration().GetCacheOutputProvider(Request);

				Configuration.CacheOutputConfiguration().GetCacheOutputProvider(Request).Remove("/api/Account/GetMenuForUser/" + contextDto.ApplicationId + "/" + contextDto.SubscriberId.ToLower() + "/" + userDTO.UserName.ToLower() + ":application/json:response-ct");
				Configuration.CacheOutputConfiguration().GetCacheOutputProvider(Request).Remove("/api/Account/GetMenuForUser/" + contextDto.ApplicationId + "/" + contextDto.SubscriberId.ToLower() + "/" + userDTO.UserName.ToLower() + ":application/json");
				Configuration.CacheOutputConfiguration().GetCacheOutputProvider(Request).RemoveStartsWith(Configuration.CacheOutputConfiguration().MakeBaseCachekey("AccountController", "GetMenuForUser"));
				return response;

			});
		}
	}
}