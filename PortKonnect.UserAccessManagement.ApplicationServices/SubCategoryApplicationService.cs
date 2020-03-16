using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.MapToDTOS;
using PortKonnect.UserAccessManagement.Domain.Repositories;
using PortKonnect.UserAccessManagement.GlobalConstants;
using PortKonnect.UserAccessManagement.Repositories;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public class SubCategoryApplicationService : ServiceBase, ISubCategoryApplicationService
    {
        public ISubCategoryRepository _subCategoryRepository;
        public SubCategoryApplicationService(IUserContext userContext, ISubCategoryRepository subCategoryRepository)
        {
            UserContext = userContext;
            _subCategoryRepository = subCategoryRepository;
        }
        public void AddSubCategory(SubCategoryDTO subCategoryDto, ContextDTO contextDto)
        {
            EncloseTransactionAndHandleException(() =>
            {
                SubCategory subCategory = new SubCategory();
                SubCategoryDTO subCategoryDTO = new SubCategoryDTO();
                if (subCategoryDto.SubCatId != "0" && !string.IsNullOrEmpty(subCategoryDto.SubCatId))
                {
                    subCategory = _subCategoryRepository.GetSubCategoryForsubCatCode(subCategoryDto.SubCatId);
                    subCategoryDTO = subCategory.MapToDTO();
                    subCategory.UpdateSubCategory(subCategoryDto.SubCatCode, subCategoryDto.SubCatName, subCategoryDto.RecordStatus);
                    subCategory.ChangeUpdatedByAndOn(contextDto.UserId);
                }
                else
                {
                    subCategoryDto.SubCatId = Guid.NewGuid().ToString();
                    subCategory = new SubCategory(subCategoryDto.SubCatId, subCategoryDto.SupCatId, subCategoryDto.SubCatCode, subCategoryDto.SubCatName, UAMGlobalConstants.RecordStatus, contextDto.UserId);
                }


                _subCategoryRepository.AddSubCategory(subCategory);
            });
        }

        public List<SubCategoryDTO> GetSubCategories()
        {
            throw new NotImplementedException();
        }

        public List<SubCategoryDTO> GetSubCategoryForsubCatCode(string subCatId)
        {
            throw new NotImplementedException();
        }
    }
}


