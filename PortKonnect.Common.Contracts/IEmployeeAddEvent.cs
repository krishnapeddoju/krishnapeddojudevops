﻿using PortKonnect.UserAccessManagement.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.Common.Contracts
{
    public interface IEmployeeAddEvent
    {
        int AppId { get; }

        string SubscriberId { get; }

        EmployeeDTO Employee { get; }
    }
}