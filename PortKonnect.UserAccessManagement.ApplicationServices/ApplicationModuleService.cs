using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public class ApplicationModuleService : ServiceBase, IApplicationModuleService
    {
        private IApplicationModuleRepository _applicationModuleRepository;
        private IUserContext _userContext;

        public ApplicationModuleService(IUserContext userContext, IApplicationModuleRepository applicationModuleRepository)
        {
            _applicationModuleRepository= applicationModuleRepository;
            _userContext = userContext;
            //TODO : To be remove
            if (ApplicationContextDTO == null)
            {
                ApplicationContextDTO = new ContextDTO() { ApplicationId = 2, PortCode = "KP", SubscriberId = "PA-KPCT", UserId = "1" };
            }
        }

        public void AddAppModule(ApplicationModule module)
        {
            EncloseTransactionAndHandleException(() => { });
        }

        public List<ApplicationModuleDTO> GetAppModules()
        {
            return ExecuteFaultHandledOperation(() => _applicationModuleRepository.GetAppModules(ApplicationContextDTO.ApplicationId));
        }

        public ApplicationModuleDTO GetAppModule(string appModuleId)
        {
            return null;
        }
    }
}
