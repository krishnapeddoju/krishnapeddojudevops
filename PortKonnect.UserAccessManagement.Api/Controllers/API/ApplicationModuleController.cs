using PortKonnect.UserAccessManagement.ApplicationServices;

namespace PortKonnect.UserAccessManagement.Api
{
    public class ApplicationModuleController : ApiControllerBase
    {
        private readonly IApplicationModuleService _applicationModuleService;

        public ApplicationModuleController(IApplicationModuleService applicationModuleService)
        {
            _applicationModuleService = applicationModuleService;
        }
    }
}