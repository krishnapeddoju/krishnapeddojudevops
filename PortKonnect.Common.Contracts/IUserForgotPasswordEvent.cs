using PortKonnect.UserAccessManagement.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.Common.Contracts
{
    public interface IUserForgotPasswordEvent
    {
        int AppId { get; }

        string SubscriberId { get; }

        DateTime ApplicationDate { get; }

        string MemberId { get; }

        string AppEntityId { get; }

        string EntityFunctionCode { get; }

        string ReferenceId { get; }

        string Attachments { get; }

        string UserId { get; }

        UserDTO UserDTO { get; }
    }
}
