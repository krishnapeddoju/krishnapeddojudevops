using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public interface ISuperCategoryApplicationService
    {
        void AddSuperCategory(SuperCategoryDTO superCategoryDto, ContextDTO contextDto);
        List<SuperCategoryDTO> GetSuperCategories();
        List<SuperCategoryDTO> GetSuperCategoryForsupCatCode(string supCatId);
    }
}
