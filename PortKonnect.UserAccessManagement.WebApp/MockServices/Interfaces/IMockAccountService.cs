using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.WebApp.MockServices.Interfaces
{

    public interface IMockAccountService
    {

        List<UserDTO> GetUsers();
        List<MenuModuleDTO> GetMenuForUser(int applicationId, string userName);
    }
}