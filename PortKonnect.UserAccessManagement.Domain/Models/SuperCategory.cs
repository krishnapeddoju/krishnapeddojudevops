using System;
using System.Collections.Generic;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class SuperCategory
    {
        public string SupCatId { get; protected set; }
        public string SupCatCode { get; protected set; }
        public string SupCatName { get; protected set; }
        public string RecordStatus { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }       

        public virtual ICollection<SubCategory> subCategories { get; set; }

        public SuperCategory()
        {
        }

        public SuperCategory(string supCatId, string supCatCode, string supCatName, string recordStatus, string createdBy)
        {
            SupCatId = supCatId;
            SupCatCode = supCatCode;
            SupCatName = supCatName;    
            RecordStatus = recordStatus;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;                      
        }

        public void UpdateSuperCategory(string supCatCode, string supCatName, string recordStatus)
        {
            SupCatCode = supCatCode;
            SupCatName = supCatName;
            RecordStatus = recordStatus;
        }
        public void ChangeUpdatedByAndOn(string userId)
        {
            this.UpdatedBy = userId;
            this.UpdatedOn = DateTime.Now;
        }
    }
}
