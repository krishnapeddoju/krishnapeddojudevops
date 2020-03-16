using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public class SuperCategoryRepository : ISuperCategoryRepository
    {
        public IUserContext _userContext;

        public SuperCategoryRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }
        public void AddSuperCategory(SuperCategory superCategory)
        {
            _userContext.SuperCategories.AddOrUpdate(superCategory);
            _userContext.SaveChanges();
        }

        public List<SuperCategoryDTO> GetSuperCategories(int applicationId, string subscriberId)
        {
            throw new NotImplementedException();
        }       

        public SuperCategory GetSuperCategoryForsupCatCode(string supCatId)
        {
            SuperCategory superCategory = (from r in _userContext.SuperCategories                         
                         where r.SupCatId.Equals(supCatId) select r).FirstOrDefault();

            return superCategory;
        }
    }
}
