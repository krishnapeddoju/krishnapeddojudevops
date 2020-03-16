using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public interface IApplicationModuleService
    {
        void AddAppModule(ApplicationModule module);
        List<ApplicationModuleDTO> GetAppModules();
        ApplicationModuleDTO GetAppModule(string appModuleId);
    }
}
