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
    public class SubCategoryDataService : ISubCategoryDataService
    {
        public IUserContext _userContext;
        public ICommonRepository _commonRepository;
        public SubCategoryDataService(IUserContext userContext, ICommonRepository commonRepository)
        {
            _userContext = userContext;
            _commonRepository = commonRepository;
        }

        public SubCategoryDTO GetSubCategoryForsubCatCode(string subCatId)
        {
            
            SubCategoryDTO subCategoryDto = subCatId != "undefined" ? !string.IsNullOrEmpty(subCatId) ? (from r in _userContext.SubCategories.Where(r => r.SupCatId == subCatId) select r).FirstOrDefault().MapToDTO() : new SubCategoryDTO() : new SubCategoryDTO();
            
            return subCategoryDto;
        }

        public List<SubCategoryDTO> GetSubCategoriesSupID(ContextDTO contextDto,string supCatId)
        {
            List<SubCategoryDTO> subCategories =
                (from r in
                     _userContext.SubCategories.Where(t => t.SupCatId == supCatId).OrderByDescending(t => t.CreatedOn)
                 select new SubCategoryDTO()
                 {
                     SupCatId = r.SupCatId,
                     SubCatId = r.SubCatId,                     
                     SubCatCode = r.SubCatCode,
                     SubCatName = r.SubCatName,
                     RecordStatus = r.RecordStatus
                 }).ToList();
            return subCategories;
        }
        public List<SubCategoryDTO> GetSubCategories(ContextDTO contextDto)
        {
            List<SubCategoryDTO> subCategories =
                (from r in
                     _userContext.SubCategories.OrderByDescending(t => t.CreatedOn)
                 select new SubCategoryDTO()
                 {
                     SupCatId = r.SupCatId,
                     SubCatId = r.SubCatId,                     
                     SubCatCode = r.SubCatCode,
                     SubCatName = r.SubCatName,
                     RecordStatus = r.RecordStatus
                 }).ToList();

            return subCategories;
        }
    }
}
