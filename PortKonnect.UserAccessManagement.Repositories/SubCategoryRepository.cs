using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        public IUserContext _userContext;

        public SubCategoryRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }
        public void AddSubCategory(SubCategory subCategory)
        {
            _userContext.SubCategories.AddOrUpdate(subCategory);
            _userContext.SaveChanges();
        }

        public List<SubCategoryDTO> GetSubCategories(int applicationId, string subscriberId)
        {
            throw new NotImplementedException();
        }       
        public SubCategory GetSubCategoryForsubCatCode(string subCatId)
        {
            SubCategory subCategory = (from r in _userContext.SubCategories
                                       where r.SubCatId.Equals(subCatId)
                                           select r).FirstOrDefault();

            return subCategory;
        }
    }
}

