using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain
{
   public class PartnerTypePriority
    {
       public string PartnerTypeCode { get; protected set; }
       public string PartnerTypeName { get; protected set; }
       public string IsDeleted { get; protected set; }
       public int PriorityNo { get; protected set; }
    }
}
