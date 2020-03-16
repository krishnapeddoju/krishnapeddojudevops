using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Api
{
    public class ApplicationEntityController : ApiControllerBase
    {
        private readonly IApplicationEntityService _applicationEntityService;

        public ApplicationEntityController(IApplicationEntityService applicationEntityService)
        {
            _applicationEntityService = applicationEntityService;
        }

        [Route("api/EntityGridList")]
        [HttpGet]
        public HttpResponseMessage GetEntitiesGridList(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                List<ApplicationEntityDTO> applicationEntities = _applicationEntityService.GetEntities(contextDto.ApplicationId);
                HttpResponseMessage response = request.CreateResponse<List<ApplicationEntityDTO>>(HttpStatusCode.OK, applicationEntities);
                return response;
            });
        }

        [Route("api/ApplicationEntity")]
        [HttpPost]
        public HttpResponseMessage PostApplicationEntity(HttpRequestMessage request, ApplicationEntityDTO applicationEntityDto)
        {
            return GetHttpResponse(request, () =>
            {

                _applicationEntityService.AddApplicationEntity(applicationEntityDto);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
                return response;
            });
        }

        [Route("api/UpdateApplicationEntity")]
        [HttpPut]
        public HttpResponseMessage PutApplicationEntity(HttpRequestMessage request, ApplicationEntityDTO applicationEntityDto)
        {
            return GetHttpResponse(request, () =>
            {

                _applicationEntityService.UpdatePartner(applicationEntityDto);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
                return response;
            });
        }

        [Route("api/ApplicationEntity/{applicationEntityId}")]
        [HttpGet]
        public HttpResponseMessage GetPartner(HttpRequestMessage request, string applicationEntityId)
        {
            return GetHttpResponse(request, () =>
            {
                ApplicationEntityDTO applicationEntityDto = _applicationEntityService.GetEntityForApplicationEntityId(applicationEntityId);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, applicationEntityDto);
                return response;
            });
        }

    }
}