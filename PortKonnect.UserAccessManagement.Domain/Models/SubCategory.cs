using System;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class SubCategory
    {
        public string SubCatId { get; protected set; }
        public string SupCatId { get; protected set; }        
        public string SubCatCode { get; protected set; }
        public string SubCatName { get; protected set; }
        public string RecordStatus { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }        

        public SubCategory()
        {
        }

        public SubCategory(string subCatId, string supCatId, string subCatCode, string subCatName, string recordStatus, string createdBy)
        {
            SubCatId = subCatId;
            SupCatId = supCatId;            
            SubCatCode = subCatCode;
            SubCatName = subCatName;
            RecordStatus = recordStatus;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;        
        }

        public void UpdateSubCategory(string subCatCode, string subCatName, string recordStatus)
        {
            RecordStatus = recordStatus;            
            SubCatCode = subCatCode;
            SubCatName = subCatName;
        }
        public void ChangeUpdatedByAndOn(string userId)
        {
            this.UpdatedBy = userId;
            this.UpdatedOn = DateTime.Now;
        }
    }
}
