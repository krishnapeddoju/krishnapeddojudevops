using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.DataServcies.ServiceContracts;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Api
{
    public class SubCategoryController : ApiControllerBase
    {
        private readonly ISubCategoryApplicationService _subCategoryApplicationService;
        private readonly ISubCategoryDataService _subCategoryDataService;

        public SubCategoryController(ISubCategoryApplicationService subCategoryApplicationService, ISubCategoryDataService subCategoryDataService)
        {
            _subCategoryApplicationService = subCategoryApplicationService;
            _subCategoryDataService = subCategoryDataService;
        }

        [Route("api/GetSubCategories")]
        [HttpGet]
        public HttpResponseMessage GetSubCategories(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                List<SubCategoryDTO> subCategoryDtos = _subCategoryDataService.GetSubCategories(contextDto);
                HttpResponseMessage response = request.CreateResponse<List<SubCategoryDTO>>(HttpStatusCode.OK, subCategoryDtos);
                return response;
            });
        }

        [Route("api/SubCategory/{subCatId?}")]
        public HttpResponseMessage GetSubCategoryForsubCatCode(HttpRequestMessage request, string subCatId = null)
        {
            return GetHttpResponse(request, () =>
            {
                SubCategoryDTO subCategory = _subCategoryDataService.GetSubCategoryForsubCatCode(subCatId);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, subCategory);
                return response;
            });
        }

        [Route("api/SubCategories/{supCatId?}")]
        [HttpGet]
        public HttpResponseMessage GetSubCategoriesSupID(HttpRequestMessage request, string supCatId = null)
        {
            return GetHttpResponse(request, () =>
            {
                List<SubCategoryDTO> subCategoryDtos = _subCategoryDataService.GetSubCategoriesSupID(contextDto, supCatId);
                HttpResponseMessage response = request.CreateResponse<List<SubCategoryDTO>>(HttpStatusCode.OK, subCategoryDtos);
                return response;
            });
        }

        [Route("api/SubCategory")]
        [HttpPost]
        public HttpResponseMessage PostSubCategory(HttpRequestMessage request, SubCategoryDTO subCategoryDto)
        {
            return GetHttpResponse(request, () =>
            {
                _subCategoryApplicationService.AddSubCategory(subCategoryDto, contextDto);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
                return response;
            });
        }
    }
}