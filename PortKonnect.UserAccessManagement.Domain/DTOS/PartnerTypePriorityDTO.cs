using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{

    //TODO: Remove this DTO from here and create in PortKonnect.UserAccessManagement.Domain.DTOS project

   public class PartnerTypePriorityDTO
    {
        public string PartnerTypeCode { get;  set; }
        public string PartnerTypeName { get;  set; }
        public string IsDeleted { get;  set; }
        public int PriorityNo { get;  set; }
    }
}
