using System.Collections.Generic;
using System.Linq;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.DataServcies.ServiceContracts;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.GlobalConstants;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;

namespace PortKonnect.UserAccessManagement.DataServcies
{
    public class EmployeeDataService : IEmployeeDataService
    {
        public IUserContext _userContext;
        public ICommonRepository _commonRepository;
        public EmployeeDataService(IUserContext userContext, ICommonRepository commonRepository)
        {
            _userContext = userContext;
            _commonRepository = commonRepository;
        }

        public EmployeeDTO GetEmployeeForEmpId(string empId, int applicationId, string subscriberId)
        {
            EmployeeDTO employeeDto = new EmployeeDTO();

            if (!string.IsNullOrEmpty(empId))
            {
                employeeDto = (from r in _userContext.Employees
                                           join dep in _userContext.SubCategories on r.Department equals dep.SubCatCode
                                           join des in _userContext.SubCategories on r.Designation equals des.SubCatCode
                                           where r.ApplicationId == applicationId && r.SubscriberId == subscriberId && r.EmployeeID == empId
                                           orderby r.CreatedOn descending
                                           select new EmployeeDTO()
                                           {
                                               EmployeeID = r.EmployeeID,
                                               EmployeeNo = r.EmployeeNo,
                                               FirstName = r.FirstName,
                                               LastName = r.LastName,                                               
                                               DepartmentName = dep.SubCatName,
                                               DesignationName = des.SubCatName,
                                               OfficialMobileNo = r.OfficialMobileNo,
                                               PersonalMobileNo = r.PersonalMobileNo,
                                               EmailID = r.EmailID,
                                               BirthDate = r.BirthDate,
                                               JoiningDate = r.JoiningDate,
                                               Gender = r.Gender,
                                               Department = r.Department,
                                               Designation = r.Designation,
                                               RecordStatus = r.RecordStatus,
                                               LicenseCapability = r.LicenseCapability
                                           }).FirstOrDefault();
            }
            return employeeDto;
        }

        public List<EmployeeDTO> GetEmployees(string employeeNo, string departmentType, int appId, string subscriberId)
        {
            List<EmployeeDTO> employeesList = (from r in _userContext.Employees
                                               join dep in _userContext.SubCategories on r.Department  equals  dep.SubCatCode
                                               join des in _userContext.SubCategories on  r.Designation  equals des.SubCatCode
                                               where r.ApplicationId == appId && r.SubscriberId == subscriberId
                                               orderby r.CreatedOn descending                                               
                                               select new EmployeeDTO()
                                               {
                                                   EmployeeID = r.EmployeeID,
                                                   EmployeeNo = r.EmployeeNo,
                                                   FirstName = r.FirstName,
                                                   LastName = r.LastName,                                                   
                                                   DepartmentName = dep.SubCatName,
                                                   DesignationName = des.SubCatName,
                                                   OfficialMobileNo = r.OfficialMobileNo,
                                                   PersonalMobileNo = r.PersonalMobileNo,
                                                   EmailID = r.EmailID,
                                                   BirthDate = r.BirthDate,
                                                   JoiningDate = r.JoiningDate,
                                                   Gender = r.Gender,
                                                   Department = r.Department,
                                                   Designation = r.Designation,
                                                   RecordStatus = r.RecordStatus,
                                                   LicenseCapability = r.LicenseCapability
                                               }).ToList();

            if (employeeNo != "All")
            {
                employeesList = employeesList.Where(k => k.EmployeeNo.ToUpper().Contains(employeeNo.ToUpper())).ToList();
            }
            if (departmentType != "All")
            {
                employeesList = employeesList.Where(k => k.Department.ToUpper().Contains(departmentType.ToUpper())).ToList();
            }

            return employeesList;
        }

        public List<SubCategoryDTO> GetDepartments()
        {           

            List<SubCategoryDTO> subCategories = (from sb in _userContext.SubCategories
                         join sp in _userContext.SuperCategories on sb.SupCatId equals sp.SupCatId 
                         where sp.SupCatCode.Equals(SuperCategoryConstants.Department) && sp.RecordStatus == UAMGlobalConstants.RecordStatus
                                                  select new SubCategoryDTO()
                           {
                               SupCatId = sp.SupCatId,
                               SubCatId = sb.SubCatId,
                               SubCatCode = sb.SubCatCode,
                               SubCatName = sb.SubCatName,
                               RecordStatus = sb.RecordStatus
                           }).ToList();

            return subCategories;
        }

        public List<SubCategoryDTO> GetDesignations()
        {
            List<SubCategoryDTO> subCategories = (from sb in _userContext.SubCategories
                                                  join sp in _userContext.SuperCategories on sb.SupCatId equals sp.SupCatId 
                                                  where sp.SupCatCode.Equals(SuperCategoryConstants.Designation) && sp.RecordStatus == UAMGlobalConstants.RecordStatus

                                                  select new SubCategoryDTO()
                                                  {
                                                      SupCatId = sp.SupCatId,
                                                      SubCatId = sb.SubCatId,
                                                      SubCatCode = sb.SubCatCode,
                                                      SubCatName = sb.SubCatName,
                                                      RecordStatus = sb.RecordStatus
                                                  }).ToList();

            return subCategories;
        }
    }
}
