using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public interface ISubCategoryRepository
    {
        void AddSubCategory(SubCategory subCategory);
        List<SubCategoryDTO> GetSubCategories(int applicationId, string subscriberId);        
        SubCategory GetSubCategoryForsubCatCode(string subCatId);
    }
}
