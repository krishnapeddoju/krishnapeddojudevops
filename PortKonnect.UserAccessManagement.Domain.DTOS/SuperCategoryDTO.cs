using System;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class SuperCategoryDTO
    {
        public string SupCatId { get; set; }
        public string SupCatCode { get; set; }        
        public string SupCatName { get; set; }
        public string RecordStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }  
   
    }
}
