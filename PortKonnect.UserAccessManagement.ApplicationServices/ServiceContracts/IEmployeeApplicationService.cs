using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public interface IEmployeeApplicationService
    {
        void AddEmployee(EmployeeDTO employeeDto, ContextDTO contextDto);
        List<EmployeeDTO> GetEmployees();
        List<EmployeeDTO> GetEmployeeForEmpId(string empId, int applicationId, string subscriberId);
    }
}

