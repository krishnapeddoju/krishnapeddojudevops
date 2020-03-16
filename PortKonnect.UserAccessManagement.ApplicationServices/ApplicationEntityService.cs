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
    public class ApplicationEntityService : ServiceBase, IApplicationEntityService
    {
        private readonly IApplicationEntityRepository _applicationEntityRepository;
        private IUserContext _userContext;

        public ApplicationEntityService(IUserContext userContext, IApplicationEntityRepository applicationEntityRepository)
        {
            _applicationEntityRepository = applicationEntityRepository;
            _userContext = userContext;
            //TODO : To be remove
            if (ApplicationContextDTO == null)
            {
                ApplicationContextDTO = new ContextDTO() { ApplicationId = 2, PortCode = "KP", SubscriberId = "PA-KPCT", UserId = "1" };
            }
        }

        public List<ApplicationEntityDTO> GetEntities(int applicationId)
        {
            return
                ExecuteFaultHandledOperation(
                    () => _applicationEntityRepository.GetEntities(applicationId));

        }

        public ApplicationEntityDTO GetEntity(int applicationId, string applicationEntityCode)
        {
            throw new NotImplementedException();
        }

        public ApplicationEntityDTO GetEntityForApplicationEntityId(string applicationEntityId)
        {
            return
               ExecuteFaultHandledOperation(
                   () => _applicationEntityRepository.GetEntityForApplicationEntityId(applicationEntityId));
        }

        public List<ApplicationEntityDTO> GetEntitiesForModule(int applicationId, string moduleId)
        {
            throw new NotImplementedException();
        }

        public void AddApplicationEntity(ApplicationEntityDTO appEntityDto)
        {
            EncloseTransactionAndHandleException(() =>
            {
                ApplicationEntity applicationEntity = new ApplicationEntity();
                _applicationEntityRepository.AddApplicationEntity(applicationEntity);
            });
        }

        public void UpdatePartner(ApplicationEntityDTO applicationEntityDto)
        {
            EncloseTransactionAndHandleException(() =>
            {
                ApplicationEntity applicationEntity = new ApplicationEntity();
                _applicationEntityRepository.UpdateApplicationEntity(applicationEntity);
            });
        }
    }
}
