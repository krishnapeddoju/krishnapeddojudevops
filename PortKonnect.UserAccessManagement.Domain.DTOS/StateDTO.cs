using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class StateDTO
    {
        public int StateId { get; set; }
        public string StateCode { get;set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
    }
}
