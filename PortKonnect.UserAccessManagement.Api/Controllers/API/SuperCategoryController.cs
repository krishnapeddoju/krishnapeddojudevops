using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.DataServcies.ServiceContracts;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Api
{
    public class SuperCategoryController : ApiControllerBase
    {
        private readonly ISuperCategoryApplicationService _superCategoryApplicationService;
        private readonly ISuperCategoryDataService _superCategoryDataService;

        public SuperCategoryController(ISuperCategoryApplicationService superCategoryApplicationService, ISuperCategoryDataService superCategoryDataService)
        {
            _superCategoryApplicationService = superCategoryApplicationService;
            _superCategoryDataService = superCategoryDataService;
        }      

        [Route("api/GetSuperCategories")]
        [HttpGet]
        public HttpResponseMessage GetSuperCategories(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                List<SuperCategoryDTO> superCategoryDtos = _superCategoryDataService.GetSuperCategories(contextDto);
                HttpResponseMessage response = request.CreateResponse<List<SuperCategoryDTO>>(HttpStatusCode.OK, superCategoryDtos);
                return response;
            });
        }

        [Route("api/SuperCategory/{supCatId?}")]
        public HttpResponseMessage GetSuperCategoryForsupCatCode(HttpRequestMessage request, string supCatId = null)
        {
            return GetHttpResponse(request, () =>
            {
                SuperCategoryDTO superCategory = _superCategoryDataService.GetSuperCategoryForsupCatCode(supCatId);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, superCategory);
                return response;
            });
        }

        [Route("api/SuperCategory")]
        [HttpPost]
        public HttpResponseMessage PostSuperCategory(HttpRequestMessage request, SuperCategoryDTO superCategoryDto)
        {
            return GetHttpResponse(request, () =>
            {
                _superCategoryApplicationService.AddSuperCategory(superCategoryDto, contextDto);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
                return response;
            });
        }
    }
}