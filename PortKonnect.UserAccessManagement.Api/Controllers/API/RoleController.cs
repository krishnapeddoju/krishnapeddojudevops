using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.DataServcies.ServiceContracts;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Api
{
    public class RoleController : ApiControllerBase
    {
        private readonly IRoleApplicationService _roleApplicationService;
        private readonly IRoleDataService _roleDataService;

        public RoleController(IRoleApplicationService roleApplicationService, IRoleDataService roleDataService)
        {
            _roleApplicationService = roleApplicationService;
            _roleDataService = roleDataService;
        }

        public HttpResponseMessage GetAllUsers(HttpRequestMessage request)
        {
            List<UserDTO> usersList = new List<UserDTO>();
            HttpResponseMessage message = request.CreateResponse<List<UserDTO>>(HttpStatusCode.OK, usersList);
            return message;
        }

        [Route("api/GetRoles")]
        [HttpGet]
        public HttpResponseMessage GetRoles(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                List<RoleDTO> roleDtos = _roleDataService.GetRoles(contextDto);
                HttpResponseMessage response = request.CreateResponse<List<RoleDTO>>(HttpStatusCode.OK, roleDtos);
                return response;
            });
        }

        [Route("api/Role/{roleId?}")]
        public HttpResponseMessage GetRoleForRoleId(HttpRequestMessage request, string roleId = null)
        {
            return GetHttpResponse(request, () =>
            {
                RoleDTO role = _roleDataService.GetRoleForRoleId(contextDto.ApplicationId, roleId, contextDto.SubscriberId, contextDto.UserId);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, role);
                return response;
            });
        }

        [Route("api/Role")]
        [HttpPost]
        public HttpResponseMessage PostRole(HttpRequestMessage request, RoleDTO roleDto)
        {
            return GetHttpResponse(request, () =>
            {
                _roleApplicationService.AddRole(roleDto, contextDto);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
                return response;
            });
        }
    }
}