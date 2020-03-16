using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.DataServcies.ServiceContracts
{
    public interface ISuperCategoryDataService
    {
        SuperCategoryDTO GetSuperCategoryForsupCatCode(string supCatId);
        List<SuperCategoryDTO> GetSuperCategories(ContextDTO contextDto);
    }
}

