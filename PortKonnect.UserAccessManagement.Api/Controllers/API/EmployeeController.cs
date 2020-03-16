using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.DataServcies.ServiceContracts;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Api
{
    public class EmployeeController : ApiControllerBase
    {
        private readonly IEmployeeApplicationService _employeeApplicationService;
        private readonly IEmployeeDataService _employeeDataService;

        public EmployeeController(IEmployeeApplicationService employeeApplicationService, IEmployeeDataService employeeDataService)
        {
            _employeeApplicationService = employeeApplicationService;
            _employeeDataService = employeeDataService;
        }

        [Route("api/EmployeesGridList")]
        [HttpGet]
        public HttpResponseMessage GetEmployees(HttpRequestMessage request, string employeeNo, string departmentType)
        {
            return GetHttpResponse(request, () =>
            {
                List<EmployeeDTO> employeeDtos = _employeeDataService.GetEmployees(employeeNo, departmentType, contextDto.ApplicationId, contextDto.SubscriberId);
                HttpResponseMessage response = request.CreateResponse<List<EmployeeDTO>>(HttpStatusCode.OK, employeeDtos);
                return response;
            });
        }

        [Route("api/Employee/{empId?}")]
        public HttpResponseMessage GetEmployeeForEmpId(HttpRequestMessage request, string empId = null)
        {
            return GetHttpResponse(request, () =>
            {
                EmployeeDTO employee = _employeeDataService.GetEmployeeForEmpId(empId, contextDto.ApplicationId, contextDto.SubscriberId);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, employee);
                return response;
            });
        }

        [Route("api/Employee")]
        [HttpPost]
        public HttpResponseMessage PostEmployee(HttpRequestMessage request, EmployeeDTO employeeDto)
        {
            return GetHttpResponse(request, () =>
            {
                _employeeApplicationService.AddEmployee(employeeDto, contextDto);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
                return response;
            });
        }

        [Route("api/GetDepartments")]
        [HttpGet]
        public HttpResponseMessage GetDepartments(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                List<SubCategoryDTO> subCategoryDtos = _employeeDataService.GetDepartments();
                HttpResponseMessage response = request.CreateResponse<List<SubCategoryDTO>>(HttpStatusCode.OK, subCategoryDtos);
                return response;
            });
        }

        [Route("api/GetDesignations")]
        [HttpGet]
        public HttpResponseMessage GetDesignations(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                List<SubCategoryDTO> subCategoryDtos = _employeeDataService.GetDesignations();
                HttpResponseMessage response = request.CreateResponse<List<SubCategoryDTO>>(HttpStatusCode.OK, subCategoryDtos);
                return response;
            });
        }
    }
}