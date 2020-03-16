using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagement.WebApp.MockServices.Interfaces;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.WebApp.MockServices
{
    public class MockApplicationModuleService : IMockApplicationModuleService
    {
        private IApplicationModuleRepository _applicationModuleRepository;
        private IUserContext _userContext;

        public MockApplicationModuleService(IUserContext userContext, IApplicationModuleRepository applicationModuleRepository)
        {
            _applicationModuleRepository= applicationModuleRepository;
            _userContext = userContext;
        }

        public void AddAppModule(ApplicationModule module)
        {

        }

        public ICollection<ApplicationModuleDTO> GetAppModules(int applicationId)
        {
            return null;
        }

        public ApplicationModuleDTO GetAppModule(string appModuleId)
        {
            return null;
        }
    }
}