using PortKonnect.UserAccessManagement.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PortKonnect.UserAccessManagement.Api.Controllers.API
{
    public class HealthCheckController : ApiController
    {
        [AllowAnonymous]
        [Route("api/HealthCheck")]
        [HttpGet]
        public HttpResponseMessage GetContext()
        {
            var guid = Guid.NewGuid();
            QueueListener.HealthCheck($"{DateTime.UtcNow}: {guid}: From UAM");
            var response = Request.CreateResponse(HttpStatusCode.OK, guid);
            return response;
        }
    }
}
