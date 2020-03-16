using System;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class SubCategoryDTO
    {       
        public string SubCatId { get; set; }
        public string SupCatId { get; set; }        
        public string SubCatCode { get; set; }
        public string SubCatName { get; set; }
        public string RecordStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        

    }
}
