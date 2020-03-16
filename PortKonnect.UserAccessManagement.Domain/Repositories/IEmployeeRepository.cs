using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        List<EmployeeDTO> GetEmployees(int applicationId, string subscriberId);        
        Employee GetEmployeeForEmpId(string empId, int applicationId, string subscriberId);
    }
}
