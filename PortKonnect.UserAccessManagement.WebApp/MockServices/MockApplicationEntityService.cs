using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagement.WebApp.MockServices.Interfaces;

namespace PortKonnect.UserAccessManagement.WebApp.MockServices
{
    public class MockApplicationEntityService : IMockApplicationEntityService
    {
        private IApplicationEntityRepository _applicationEntityRepository;
        private IUserContext _userContext;

        public MockApplicationEntityService(IUserContext userContext, IApplicationEntityRepository applicationEntityRepository)
        {
            _applicationEntityRepository = applicationEntityRepository;
            _userContext = userContext;
        }


    }
}