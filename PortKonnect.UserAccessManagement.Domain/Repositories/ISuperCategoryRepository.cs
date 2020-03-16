using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public interface ISuperCategoryRepository
    {
        void AddSuperCategory(SuperCategory superCategory);
        List<SuperCategoryDTO> GetSuperCategories(int applicationId, string subscriberId);
        SuperCategory GetSuperCategoryForsupCatCode(string supCatId);
    }
}
