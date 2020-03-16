using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class AuthorizedFunctionDTO
    {
        public string FunctionCode { get; set; }
        public string AppEntityCode { get; set; }
        public string FunctionName { get; set; }

    }
}
