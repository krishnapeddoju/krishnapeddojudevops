using System;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class Employee
    {
        public string EmployeeID { get; protected set; }
        public string EmployeeNo { get; protected set; }        
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string OfficialMobileNo { get; protected set; }
        public string PersonalMobileNo { get; protected set; }
        public string EmailID { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public DateTime JoiningDate { get; protected set; }
        public string Gender { get; protected set; }
        public string Department { get; protected set; }
        public string Designation { get; protected set; }
        public int ApplicationId { get; protected set; }
        public string SubscriberId { get; protected set; }
        public string RecordStatus { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }
        public int LicenseCapability { get; protected set; }

        public Employee()
        {
        }

        public Employee(string empId, 
            int applicationId, 
            string subscriberId, 
            string empNo, 
            string firstName, 
            string lastName,
            string officialNo, 
            string personalNo,
            string emailId, 
            DateTime birthDate, 
            DateTime joiningDate, 
            string gender,
            string department, 
            string designation, 
            string recordStatus, 
            string createdBy, 
            int licenseCapability)
        {
            ApplicationId = applicationId;
            SubscriberId = subscriberId;
            EmployeeID = empId;
            EmployeeNo = empNo;
            FirstName = firstName;
            LastName = lastName;
            OfficialMobileNo = officialNo;
            PersonalMobileNo = personalNo;
            EmailID = emailId;
            BirthDate = birthDate;
            JoiningDate = joiningDate;
            Gender = gender;
            Department = department;
            Designation = designation;                      
            RecordStatus = recordStatus;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;
            LicenseCapability = licenseCapability;
        }

        public void UpdateEmployee(string empNo, 
            string firstName, 
            string lastName, 
            string officialNo, 
            string personalNo, 
            string emailId, 
            DateTime birthDate, 
            DateTime joiningDate, 
            string gender, 
            string department, 
            string designation, 
            string recordStatus,
            int licenseCapability)
        {
            EmployeeNo = empNo;
            FirstName = firstName;
            LastName = lastName;
            OfficialMobileNo = officialNo;
            PersonalMobileNo = personalNo;
            EmailID = emailId;
            BirthDate = birthDate;
            JoiningDate = joiningDate;
            Gender = gender;
            Department = department;
            Designation = designation;
            RecordStatus = recordStatus;
            LicenseCapability = licenseCapability;
        }
        public void ChangeUpdatedByAndOn(string userId)
        {
            UpdatedBy = userId;
            UpdatedOn = DateTime.Now;
        }
    }
}
