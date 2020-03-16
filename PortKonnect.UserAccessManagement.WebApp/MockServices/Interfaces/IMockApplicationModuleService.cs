using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.WebApp.MockServices.Interfaces
{
    public interface IMockApplicationModuleService
    {
        void AddAppModule(ApplicationModule module);
        ICollection<ApplicationModuleDTO> GetAppModules(int applicationId);
        ApplicationModuleDTO GetAppModule(string appModuleId);
    }
}
