using System;
using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public interface ISubCategoryApplicationService
    {
        void AddSubCategory(SubCategoryDTO subCategoryDto, ContextDTO contextDto);
        List<SubCategoryDTO> GetSubCategories();
        List<SubCategoryDTO> GetSubCategoryForsubCatCode(string subCatId);
    }
}
