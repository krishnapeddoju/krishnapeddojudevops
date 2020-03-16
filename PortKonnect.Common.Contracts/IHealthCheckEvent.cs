using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.Common.Contracts
{
    public interface IHealthCheckEvent
    {
        string Message { get; }
    }
}
