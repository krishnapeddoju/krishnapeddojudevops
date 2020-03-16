using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class EmployeeDTO
    {
        public string EmployeeID { get; set; }
        public string EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficialMobileNo { get; set; }
        public string PersonalMobileNo { get; set; }
        public string EmailID { get;  set; }
        public DateTime BirthDate { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public int ApplicationId { get; set; }
        public string SubscriberId { get; set; }
        public string RecordStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public int LicenseCapability { get; set; }
    }
}
