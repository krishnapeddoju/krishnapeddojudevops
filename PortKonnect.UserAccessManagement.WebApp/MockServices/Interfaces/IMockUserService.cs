using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.WebApp.MockServices.Interfaces
{
    public interface IMockUserService
    {
        List<UserDTO> GetUsersUnderTO();
    }
}
