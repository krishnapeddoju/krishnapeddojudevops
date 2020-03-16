using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IUserContext _userContext;

        public EmployeeRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }
        public void AddEmployee(Employee employee)
        {
            _userContext.Employees.AddOrUpdate(employee);
            _userContext.SaveChanges();
        }

        public List<EmployeeDTO> GetEmployees(int applicationId, string subscriberId)
        {
            throw new NotImplementedException();
        }       

        public Employee GetEmployeeForEmpId(string empId, int applicationId, string subscriberId)
        {
            Employee employee = (from r in _userContext.Employees
                                           where r.EmployeeID.Equals(empId) && r.ApplicationId == applicationId && r.SubscriberId == subscriberId
                                           select r).FirstOrDefault();

            return employee;
        }
    }
}
