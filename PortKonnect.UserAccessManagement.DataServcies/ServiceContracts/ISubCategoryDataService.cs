using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.DataServcies.ServiceContracts
{
    public interface ISubCategoryDataService
    {
        SubCategoryDTO GetSubCategoryForsubCatCode(string subCatId);
        List<SubCategoryDTO> GetSubCategories(ContextDTO contextDto);
        List<SubCategoryDTO> GetSubCategoriesSupID(ContextDTO contextDto, string supCatId);
    }
}

