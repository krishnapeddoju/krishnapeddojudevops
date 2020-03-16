using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.Domain.DTOS;


namespace PortKonnect.UserAccessManagement.Api
{
    public class PartnerController : ApiControllerBase
    {
        private readonly IPartnerApplicationService _partnerService;
        


        public PartnerController(IPartnerApplicationService partnerService)
        {
            _partnerService = partnerService;
        }

        [Route("api/PartnersGridList")]
        [HttpGet]
        public HttpResponseMessage GetPartnersGridList(HttpRequestMessage request, string partnerName,string partnerType,string emailId,string contactNumber)
        {
            return GetHttpResponse(request, () =>
            {
                List<PartnerListDTO> partners = _partnerService.GetPartnersList( partnerName, partnerType, emailId, contactNumber,contextDto.SubscriberId,contextDto.ApplicationId);
                HttpResponseMessage response = request.CreateResponse<List<PartnerListDTO>>(HttpStatusCode.OK, partners);
                return response;
            });
        }

        [AllowAnonymous]
        [Route("api/Countries")]
        [HttpGet]
        public HttpResponseMessage GetCountries(HttpRequestMessage request)
        {
            List<CountryDTO> countries = _partnerService.GetCountries();
            HttpResponseMessage response = request.CreateResponse<List<CountryDTO>>(HttpStatusCode.OK, countries);
            return response;
        }

        //TODO:A: Is it used anywhere....to be removed.
        [Route("api/Applications")]
        [HttpGet]
        public HttpResponseMessage GetApplications(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                List<ApplicationDTO> applications = _partnerService.GetApplication();
                HttpResponseMessage response = request.CreateResponse<List<ApplicationDTO>>(HttpStatusCode.OK, applications);
                return response;
            });
        }

        [Route("api/Ports")]
        [HttpGet]
        public HttpResponseMessage GetPorts(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                List<PortDTO> ports = _partnerService.GetPorts();
                HttpResponseMessage response = request.CreateResponse<List<PortDTO>>(HttpStatusCode.OK, ports);
                return response;
            });
        }


        [Route("api/GetPartnerCodes")]
        [HttpGet]
        public HttpResponseMessage GetPartnerCodes(HttpRequestMessage request, [FromUri] List<string> partnerType)
        {
            return GetHttpResponse(request, () =>
            {
                List<PartnerDTO> ports = _partnerService.GetPartnerCodes(partnerType);
                HttpResponseMessage response = request.CreateResponse<List<PartnerDTO>>(HttpStatusCode.OK, ports);
                return response;
            });
        }

        [Route("api/PartnerTypes")]
        [HttpGet]
        public HttpResponseMessage GetPartnerTypes(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                List<PartnerTypeDTO> partnerTypes = _partnerService.GetPartnerTypes();
                HttpResponseMessage response = request.CreateResponse<List<PartnerTypeDTO>>(HttpStatusCode.OK, partnerTypes);
                return response;
            });
        }

        [Route("api/Partner")]
        [HttpPost]
        public HttpResponseMessage PostPartner(HttpRequestMessage request, PartnerDTO partnerDTO)
        {
            return GetHttpResponse(request, () =>
            {
                _partnerService.AddPartner(partnerDTO);
                partnerDTO.context = contextDto;
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
                return response;
            });
        }

        [Route("api/UpdatePartner")]
        [HttpPost]
        public HttpResponseMessage PutPartner(HttpRequestMessage request, PartnerDTO partnerDTO)
        {
            return GetHttpResponse(request, () =>
            {

                _partnerService.UpdatePartner(partnerDTO);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
                return response;
            });
        }

        [Route("api/Partner/{partnerId}")]
        [HttpGet]
        public HttpResponseMessage GetPartner(HttpRequestMessage request, string partnerId)
        {
            return GetHttpResponse(request, () =>
            {
                PartnerDTO partnerDto = _partnerService.GetPartner(partnerId);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, partnerDto);
                return response;
            });
        }


		[Route("api/PartnerLogo/{partnerCode}")]
		[HttpGet]
        public HttpResponseMessage GetPartnerLogo(HttpRequestMessage request, string partnerCode)
		{
			return GetHttpResponse(request, () =>
			{
                PartnerDTO partnerDto = _partnerService.GetPartnerLogo(partnerCode);
				HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, partnerDto);
				return response;
			});
		}

        [Route("api/GetPartners")]
        [HttpPost]
        public HttpResponseMessage GetPartnerLogo(HttpRequestMessage request, List<string> partnerCodes)
        {
            return GetHttpResponse(request, () =>
            {
                List<PartnerDTO> partnerDtos = _partnerService.GetPartners(partnerCodes);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, partnerDtos);
                return response;
            });
        }

        [Route("api/GetPartnersByPartnerType/{partnerType}")]
        [HttpGet]
        public HttpResponseMessage GetPartnersByPartnerType(HttpRequestMessage request, string partnerType)
        {
            return GetHttpResponse(request, () =>
            {
                List<PartnerDTO> partnerDtos = _partnerService.GetPartnersByPartnerType(partnerType);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, partnerDtos);
                return response;
            });
        }

    }

}
