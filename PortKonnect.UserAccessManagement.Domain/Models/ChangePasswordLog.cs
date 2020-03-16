using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class ChangePasswordLog
    {
        public string LogTransactionId { get; protected set; }//GUID
        public string UserId { get; protected set; }
        public string OldPassword { get; protected set; }
        public string NewPassword { get; protected set; }
        public DateTime ChangeDateTime { get; protected set; }
        public string IsDelete { get; protected set; }
        public DateTime ModifiedOn { get; protected set; }
        public string ModifiedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string CreatedBy { get; protected set; }

        public ChangePasswordLog()
        {
        }

        public ChangePasswordLog(string logTransactionId, string userId, string oldPassword, string newPassword, DateTime changeDateTime, string isDelete, DateTime modifiedOn, string modifiedBy, DateTime createdOn, string createdBy)
        {
            this.LogTransactionId = logTransactionId;
            this.UserId = userId;
            this.OldPassword = oldPassword;
            this.NewPassword = newPassword;
            this.ChangeDateTime = changeDateTime;
            this.IsDelete = isDelete;
            this.ModifiedOn = modifiedOn;
            this.ModifiedBy = modifiedBy;
            this.CreatedOn = createdOn;
            this.CreatedBy = createdBy;
        }

        public void UpdateIsDelete(string IsDelete,string logTransactionId) 
        {
            this.LogTransactionId = logTransactionId;
            this.IsDelete = IsDelete;
        }

    }


}
