using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public interface IApplicationModuleRepository
    {
        void AddAppModule(ApplicationModule module);
        List<ApplicationModuleDTO> GetAppModules(int applicationId);
        ApplicationModuleDTO GetAppModule(string appModuleId);
        //TODO:As if now there are no child modules, hence need to use below method when child modules exist
        //ICollection<ApplicationModule> GetChildAppModules(int applicationId, string parentAppModuleId);
    }
}
