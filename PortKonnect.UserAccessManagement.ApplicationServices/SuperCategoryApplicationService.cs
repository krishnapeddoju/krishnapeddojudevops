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
    public class SuperCategoryApplicationService : ServiceBase, ISuperCategoryApplicationService
    {
        public ISuperCategoryRepository _superCategoryRepository;
        public SuperCategoryApplicationService(IUserContext userContext, ISuperCategoryRepository superCategoryRepository)
        {
            UserContext = userContext;
            _superCategoryRepository = superCategoryRepository;
        }
        public void AddSuperCategory(SuperCategoryDTO superCategoryDto, ContextDTO contextDto)
        {
            EncloseTransactionAndHandleException(() =>
            {
                SuperCategory superCategory = new SuperCategory();
                SuperCategoryDTO superCategoryDTO = new SuperCategoryDTO();
                if (superCategoryDto.SupCatId != "0" && !string.IsNullOrEmpty(superCategoryDto.SupCatId))
                {
                    superCategory = _superCategoryRepository.GetSuperCategoryForsupCatCode(superCategoryDto.SupCatId);
                    superCategoryDTO = superCategory.MapToDTO();
                    superCategory.UpdateSuperCategory(superCategoryDto.SupCatCode, superCategoryDto.SupCatName, superCategoryDto.RecordStatus);
                    superCategory.ChangeUpdatedByAndOn(contextDto.UserId);
                }
                else
                {
                    superCategoryDto.SupCatId = Guid.NewGuid().ToString();
                    superCategory = new SuperCategory(superCategoryDto.SupCatId, superCategoryDto.SupCatCode, superCategoryDto.SupCatName, UAMGlobalConstants.RecordStatus, contextDto.UserId);
                }


                _superCategoryRepository.AddSuperCategory(superCategory);
            });
        }

        public List<SuperCategoryDTO> GetSuperCategories()
        {
            throw new NotImplementedException();
        }

        public List<SuperCategoryDTO> GetSuperCategoryForsupCatCode(string supCatId)
        {
            throw new NotImplementedException();
        }
    }
}

