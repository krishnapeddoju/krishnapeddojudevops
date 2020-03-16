using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.DataServcies.ServiceContracts;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.MapToDTOS;
using PortKonnect.UserAccessManagement.GlobalConstants;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;

namespace PortKonnect.UserAccessManagement.DataServcies
{
    public class SuperCategoryDataService : ISuperCategoryDataService
    {
        public IUserContext _userContext;
        public ICommonRepository _commonRepository;
        public SuperCategoryDataService(IUserContext userContext, ICommonRepository commonRepository)
        {
            _userContext = userContext;
            _commonRepository = commonRepository;
        }

        public SuperCategoryDTO GetSuperCategoryForsupCatCode(string supCatId)
        {
            SuperCategoryDTO superCategoryDto = !string.IsNullOrEmpty(supCatId) ? (from r in _userContext.SuperCategories.Where(r => r.SupCatId == supCatId) select r).FirstOrDefault().MapToDTO() : new SuperCategoryDTO();
            

            return superCategoryDto;
        }

        public List<SuperCategoryDTO> GetSuperCategories(ContextDTO contextDto)
        {
            List<SuperCategoryDTO> rolesGridList =
                (from r in
                     _userContext.SuperCategories.OrderByDescending(t => t.CreatedOn)
                 select new SuperCategoryDTO()
                 {
                     SupCatId = r.SupCatId,
                     SupCatCode = r.SupCatCode,
                     SupCatName = r.SupCatName,
                     RecordStatus = r.RecordStatus
                 }).ToList();
            return rolesGridList;
        }
    }
}
