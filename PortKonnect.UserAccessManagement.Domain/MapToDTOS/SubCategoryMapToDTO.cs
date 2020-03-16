using PortKonnect.UserAccessManagement.Domain.DTOS;
using System.Collections.Generic;

namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class SubCategoryMapToDTO
    {
        public static List<SubCategoryDTO> MapToDTO(this IEnumerable<SubCategory> subCategories)
        {
            List<SubCategoryDTO> subCategoriesDtos = new List<SubCategoryDTO>();
            if (subCategories != null)
            {
                foreach (SubCategory subCategory in subCategories)
                {
                    subCategoriesDtos.Add(subCategory.MapToDTO());
                }
            }
            return subCategoriesDtos;
        }

        public static SubCategoryDTO MapToDTO(this SubCategory subCategory)
        {
            if (subCategory == null)
            {
                return null;
            }
            SubCategoryDTO subCategoryDto = new SubCategoryDTO()
            {
                SubCatId = subCategory.SubCatId,
                SupCatId = subCategory.SupCatId,                
                SubCatCode = subCategory.SubCatCode,
                SubCatName = subCategory.SubCatName,
                RecordStatus = subCategory.RecordStatus,
                CreatedBy = subCategory.CreatedBy,
                CreatedOn = subCategory.CreatedOn,
                UpdatedBy = subCategory.UpdatedBy,
                UpdatedOn = subCategory.UpdatedOn
            };

            return subCategoryDto;
        }
    }
}
