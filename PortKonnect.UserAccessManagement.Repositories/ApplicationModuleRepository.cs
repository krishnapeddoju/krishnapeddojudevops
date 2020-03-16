using PortKonnect.UserAccessManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public class ApplicationModuleRepository : IApplicationModuleRepository
    {
        private readonly IUserContext _userContext;
        public ApplicationModuleRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public void AddAppModule(ApplicationModule module)
        {

        }

        public List<ApplicationModuleDTO> GetAppModules(int applicationId)
        {
            List<ApplicationModuleDTO> applicationModules = new List<ApplicationModuleDTO>()
            {
                new ApplicationModuleDTO()
                {
                    
                }
            };
            return null;
        }

        public ApplicationModuleDTO GetAppModule(string appModuleId)
        {
            return null;
        }
    }
}