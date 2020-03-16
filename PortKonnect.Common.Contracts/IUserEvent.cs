using PortKonnect.UserAccessManagement.Domain.DTOS;
using System;

namespace PortKonnect.Common.Contracts
{
    public interface IUserEvent
    {
            UserDTO UserDTO { get; }
    }
}
