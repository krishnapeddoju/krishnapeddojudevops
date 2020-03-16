using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.GlobalConstants;


namespace PortKonnect.UserAccessManagement.Api
{
    public class PartnerRegistrationController : ApiControllerBase
    {
        private readonly IPartnerRegistrationApplicationService _partnerRegistrationService;

        public PartnerRegistrationController(IPartnerRegistrationApplicationService partnerRegistrationService)
        {
            _partnerRegistrationService = partnerRegistrationService;
        }

        [Route("api/PendingPartnerRegistrationsGridList")]
        [HttpGet]
        public HttpResponseMessage GetPendingPartnerRegistrationsGridList(HttpRequestMessage request, string estbName, string partnerType, string status)
        {

            List<PartnerRegistrationListDTO> partners = _partnerRegistrationService.GetPendingPartnerRegistrationsGridList(estbName, partnerType, status);
            HttpResponseMessage response = request.CreateResponse<List<PartnerRegistrationListDTO>>(HttpStatusCode.OK, partners);
            return response;

        }

        [AllowAnonymous]
        [Route("api/CountriesPartner")]
        [HttpGet]
        public HttpResponseMessage GetCountries(HttpRequestMessage request)
        {
            List<CountryDTO> countries = _partnerRegistrationService.GetCountries();
            HttpResponseMessage response = request.CreateResponse<List<CountryDTO>>(HttpStatusCode.OK, countries);
            return response;
        }

        [AllowAnonymous]

        [Route("api/GetStatuses")]
        [HttpGet]
        public HttpResponseMessage GetStatuses(HttpRequestMessage request)
        {

            List<string> status = _partnerRegistrationService.GetStatuses();
            HttpResponseMessage response = request.CreateResponse<List<string>>(HttpStatusCode.OK, status);
            return response;

        }

        [AllowAnonymous]

        [Route("api/GetYears")]
        [HttpGet]
        public HttpResponseMessage GetYears(HttpRequestMessage request)
        {

            List<string> Years = _partnerRegistrationService.GetYears();
            HttpResponseMessage response = request.CreateResponse<List<string>>(HttpStatusCode.OK, Years);
            return response;

        }


        [AllowAnonymous]
        [Route("api/GetDocumentTypes")]
        [HttpGet]
        public HttpResponseMessage GetDocumentTypes(HttpRequestMessage request)
        {

            List<string> status = _partnerRegistrationService.GetDocumentTypes();
            HttpResponseMessage response = request.CreateResponse<List<string>>(HttpStatusCode.OK, status);
            return response;

        }

        [AllowAnonymous]
        [Route("api/GetDocumentTypesByPartnerType")]
        [HttpGet]
        public HttpResponseMessage GetDocumentTypesByPartnerType(HttpRequestMessage request, string partnerType)
        {
            //List<string> status = _partnerRegistrationService.GetDocumentTypesByPartnerType(partnerType);
            List<PartnerRegistrationDocsDTO> DocumentDTOs = _partnerRegistrationService.GetDocumentTypesByPartnerTypeWithDoc(partnerType);
            HttpResponseMessage response = request.CreateResponse<List<PartnerRegistrationDocsDTO>>(HttpStatusCode.OK, DocumentDTOs);
            return response;

        }

        [Route("api/PartnerRegistration")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage PostPartnerRegistration(HttpRequestMessage request, PartnerRegistrationDTO partnerRegistrationDTO)
        {
            _partnerRegistrationService.AddPartnerRegistration(partnerRegistrationDTO);
            //partnerRegistrationDTO.context = contextDto;
            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
            return response;

        }

        [Route("api/ApprovePartnerRegistration")]
        [HttpPost]
        public HttpResponseMessage ApprovePartnerRegistration(HttpRequestMessage request, PartnerRegistrationListDTO partnerRegistrationDTO)
        {
            _partnerRegistrationService.ApprovePartnerRegistration(partnerRegistrationDTO);
            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
            return response;
        }

        [Route("api/ApprovePartnerRegistrationWithDocs")]
        [HttpPost]
        public HttpResponseMessage ApprovePartnerRegistrationWithDocs(HttpRequestMessage request, PartnerRegistrationDTO partnerRegistrationDTO)
        {
            _partnerRegistrationService.ApprovePartnerRegistration(partnerRegistrationDTO);
            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
            return response;
        }

        [Route("api/RejectPartnerRegistration")]
        [HttpPost]
        public HttpResponseMessage RejectPartnerRegistration(HttpRequestMessage request, PartnerRegistrationListDTO partnerRegistrationDTO)
        {
            if (contextDto.UserRoles.Contains(UAMGlobalConstants.Accounts))
                _partnerRegistrationService.RejectPartnerVerification(partnerRegistrationDTO);
            else
                _partnerRegistrationService.RejectPartnerRegistration(partnerRegistrationDTO);

            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
            return response;
        }

        [Route("api/PartnerRegistration/{requisitionNo}")]
        [HttpGet]
        public HttpResponseMessage GetPartnerRegistration(HttpRequestMessage request, string requisitionNo)
        {
            PartnerRegistrationDTO partnerRegistrationDto = _partnerRegistrationService.GetPartnerRegistration(requisitionNo);
            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, partnerRegistrationDto);
            return response;

        }


        [Route("api/GetPartnerRegistration")]
        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetPartnerRegistration(HttpRequestMessage request, string requisitionNo, string emailId, string mobileNumber)
        {
            PartnerRegistrationDTO partnerRegistrationDto = _partnerRegistrationService.GetPartnerRegistration(requisitionNo, emailId, mobileNumber);
            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, partnerRegistrationDto);
            return response;

        }

        [Route("api/UpdatePartnerRegistration")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage UpdatePartnerRegistration(HttpRequestMessage request, PartnerRegistrationDTO partnerRegistrationDTO)
        {
            _partnerRegistrationService.UpdatePartnerRegistration(partnerRegistrationDTO);
            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
            return response;

        }

        [Route("api/UpdateRegistration")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage UpdateRegistration(HttpRequestMessage request, PartnerRegistrationDTO partnerRegistrationDTO)
        {
            _partnerRegistrationService.UpdatePartnerRegistrationOnly(partnerRegistrationDTO);
            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
            return response;

        }

        [Route("api/VerifyPartnerRegistration")]
        [HttpPost]
        public HttpResponseMessage VerifyPartnerRegistration(HttpRequestMessage request, PartnerRegistrationListDTO partnerRegistrationDTO)
        {
            _partnerRegistrationService.VerifyPartnerRegistration(partnerRegistrationDTO);
            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
            return response;
        }


        [Route("api/VerifyPartnerRegistrationWithDocs")]
        [HttpPost]
        public HttpResponseMessage VerifyPartnerRegistrationWithDocs(HttpRequestMessage request, PartnerRegistrationDTO partnerRegistrationDTO)
        {
            _partnerRegistrationService.VerifyPartnerRegistration(partnerRegistrationDTO);
            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
            return response;
        }


        [AllowAnonymous]
        [Route("api/CheckUniquePartnerName")]
        [HttpGet]
        public HttpResponseMessage CheckUniquePartnerName(HttpRequestMessage request, string partnerName, string partnerType)
        {
            string isDuplicate = _partnerRegistrationService.CheckUniquePartnerName(partnerName, partnerType);
            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, isDuplicate);
            return response;

        }

        //Need to Remove this method if not using anywhere
        //[AllowAnonymous]
        //[Route("api/sCheckUniquePartnerName/{partnerName}")]
        //[HttpPost]
        //public HttpResponseMessage sCheckUniquePartnerName(HttpRequestMessage request, string partnerName)
        //{
        //    string isDuplicate = _partnerRegistrationService.CheckUniquePartnerName(partnerName);
        //    HttpResponseMessage response = request.CreateResponse<string>(HttpStatusCode.OK, isDuplicate);
        //    return response;

        //}
    }
}