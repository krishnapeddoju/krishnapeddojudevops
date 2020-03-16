using PortKonnect.UserAccessManagement.Domain.DTOS;
using System.Collections.Generic;

namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class EmployeeMapToDTO
    {
        public static List<EmployeeDTO> MapToDTO(this IEnumerable<Employee> employees)
        {
            List<EmployeeDTO> employeesDtos = new List<EmployeeDTO>();
            if (employees != null)
            {
                foreach (Employee item in employees)
                {
                    employeesDtos.Add(item.MapToDTO());
                }
            }
            return employeesDtos;
        }

        public static EmployeeDTO MapToDTO(this Employee employee)
        {
            if (employee == null)
            {
                return null;
            }
            EmployeeDTO employeeDto = new EmployeeDTO()
            {
                ApplicationId = employee.ApplicationId,
                SubscriberId = employee.SubscriberId,
                EmployeeID = employee.EmployeeID,
                EmployeeNo = employee.EmployeeNo,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                OfficialMobileNo = employee.OfficialMobileNo,
                PersonalMobileNo = employee.PersonalMobileNo,
                EmailID = employee.EmailID,
                BirthDate = employee.BirthDate,
                JoiningDate = employee.JoiningDate,
                Gender = employee.Gender,
                Department = employee.Department,
                Designation = employee.Designation,
                RecordStatus = employee.RecordStatus,
                CreatedBy = employee.CreatedBy,
                CreatedOn = employee.CreatedOn,
                UpdatedBy = employee.UpdatedBy,
                UpdatedOn = employee.UpdatedOn
            };

            return employeeDto;
        }
    }
}
