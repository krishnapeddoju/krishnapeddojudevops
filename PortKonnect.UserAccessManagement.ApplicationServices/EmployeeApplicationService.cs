using System;
using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.MapToDTOS;
using PortKonnect.UserAccessManagement.GlobalConstants;
using PortKonnect.UserAccessManagement.Repositories;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public class EmployeeApplicationService : ServiceBase, IEmployeeApplicationService
    {
        public IEmployeeRepository _employeeRepository;
        public EmployeeApplicationService(IUserContext userContext, IEmployeeRepository employeeRepository)
        {
            UserContext = userContext;
            _employeeRepository = employeeRepository;
        }
        public void AddEmployee(EmployeeDTO employeeDto, ContextDTO contextDto)
        {
            EncloseTransactionAndHandleException(() =>
            {
                Employee employee = new Employee();
                EmployeeDTO employeeDTO = new EmployeeDTO();
                if (employeeDto.EmployeeID != "0" && !string.IsNullOrEmpty(employeeDto.EmployeeID))
                {
                    employee = _employeeRepository.GetEmployeeForEmpId(employeeDto.EmployeeID, contextDto.ApplicationId, contextDto.SubscriberId);
                    employeeDTO = employee.MapToDTO();
                    employee.UpdateEmployee(employeeDto.EmployeeNo, employeeDto.FirstName, employeeDto.LastName, employeeDto.OfficialMobileNo, employeeDto.PersonalMobileNo, employeeDto.EmailID, employeeDto.BirthDate, employeeDto.JoiningDate, employeeDto.Gender, employeeDto.Department, employeeDto.Designation, employeeDto.RecordStatus, employeeDto.LicenseCapability);
                    employee.ChangeUpdatedByAndOn(contextDto.UserId);
                }
                else
                {
                    employeeDto.EmployeeID = Guid.NewGuid().ToString();
                    employee = new Employee(employeeDto.EmployeeID, contextDto.ApplicationId, contextDto.SubscriberId, employeeDto.EmployeeNo, employeeDto.FirstName, employeeDto.LastName, employeeDto.OfficialMobileNo, employeeDto.PersonalMobileNo, employeeDto.EmailID, employeeDto.BirthDate, employeeDto.JoiningDate, employeeDto.Gender, employeeDto.Department, employeeDto.Designation , UAMGlobalConstants.RecordStatus, contextDto.UserId, employeeDto.LicenseCapability);
                }


                _employeeRepository.AddEmployee(employee);
                SendAddEmployeeNotification(contextDto.ApplicationId, contextDto.SubscriberId, employeeDto.EmployeeID, employeeDto);
            });
        }

        public List<EmployeeDTO> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public List<EmployeeDTO> GetEmployeeForEmpId(string empId, int applicationId,  string subscriberId)
        {
            throw new NotImplementedException();
        }
    }
}

