using PortKonnect.UserAccessManagement.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public interface IAuthorizationApplicationService
    {
        //  -  /MenuModules/{AppName}/{userName}
        List<MenuModuleDTO> GetMenuForUser(int applicationId, string userName);
        
        //  -  /IsAuthorized/{AppId}/{subscriberId}/{portCode}/{EntityCode}/{FunctionCode}/For/{userName}
        bool IsUserAuthorizedToPerformFunction(string userName, int appId, int subscriberId, string portCode, string appEntityCode, string functionCode);

        // - AuthorizedFunctions/{AppName}/{subscriberId}/{portCode}/{EntityCode}/For/{userName}
        ICollection<AuthorizedFunctionDTO> GetAuthorisedPermissionsForUserInEntity(string userName, int appId, int subscriberId, string portCode, string appEntityCode);
    }
}
