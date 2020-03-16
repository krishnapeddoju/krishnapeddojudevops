using PortKonnect.UserAccessManagement.Domain.DTOS;
using System.Collections.Generic;

namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class SuperCategoryMapToDTO
    {
        public static List<SuperCategoryDTO> MapToDTO(this IEnumerable<SuperCategory> superCategories)
        {
            List<SuperCategoryDTO> superCategoriesDtos = new List<SuperCategoryDTO>();
            if (superCategories != null)
            {
                foreach (SuperCategory superCategory in superCategories)
                {
                    superCategoriesDtos.Add(superCategory.MapToDTO());
                }
            }
            return superCategoriesDtos;
        }

        public static SuperCategoryDTO MapToDTO(this SuperCategory superCategory)
        {
            if (superCategory == null)
            {
                return null;
            }
            SuperCategoryDTO superCategoryDto = new SuperCategoryDTO()
            {
                SupCatId = superCategory.SupCatId,
                SupCatCode = superCategory.SupCatCode,
                SupCatName = superCategory.SupCatName,    
                RecordStatus = superCategory.RecordStatus,
                CreatedBy = superCategory.CreatedBy,
                CreatedOn = superCategory.CreatedOn,
                UpdatedBy = superCategory.UpdatedBy,
                UpdatedOn = superCategory.UpdatedOn
            };

            return superCategoryDto;
        }
    }
}
