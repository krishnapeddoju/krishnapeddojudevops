using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.DataServcies.ServiceContracts
{
    public interface IEmployeeDataService
    {
        EmployeeDTO GetEmployeeForEmpId(string empId, int applicationId, string subscriberId);
        List<EmployeeDTO> GetEmployees(string employeeNo, string departmentType, int appId, string subscriberId);
        List<SubCategoryDTO> GetDepartments();
        List<SubCategoryDTO> GetDesignations();
    }
}

