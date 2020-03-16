using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class PartnerRegistrationDocsDTO
    {
        public string PDocumentId { get; set; }
        public string FileName { get; set; }
        public string OriginalName { get; set; }
        public string DocumentType { get; set; }
        public DateTime? ValidTill { get; set; }
        public string PartnerRegistrationId { get; set; }
        public string IsDeleted { get; set; }
    }       
}
