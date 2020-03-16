using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.DataServcies
{
    public class UserAccessDataService
    {
        public IUserContext _userContext;
        public UserAccessDataService(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public bool AuthenticateUser(int applicationId, string userName, string password)
        {

			IQueryable<UserDTO> user = (from u in _userContext.Users.Where(u => u.UserName == userName && u.Password == password)
										 join p in _userContext.Partners on u.PartnerId equals p.PartnerId 
										 join sm in _userContext.SubscriptionMembers on p.PartnerId equals sm.MemberId
										 select new UserDTO
										 {
											 UserId = u.UserId,
											 UserName = u.UserName,
											 ApplicationId = sm.ApplicationId,
											 ContactNumber = u.ContactNo,
											 CreatedBy = u.CreatedBy,
											 CreatedOn = u.CreatedOn,
											 EmailId = u.EmailId,
											 FirstName = u.FirstName,
											 LastName = u.LastName,
											 PartnerId = u.PartnerId
										 });
			
			
			

            if (user.FirstOrDefault() != null)
            {
                if (user.ToList().Any())
                    return true;
                else
                {
                    return false;
                }
            }
            else
                return false;
        }

  

        public List<AppMemberDTO> GetMembersOfApplication(int applicationId, string subscriberId)
        {
            return null;
        }

        public List<AppMemberDTO> GetMembersOfApplication(int applicationId, string subscriberId,
            string partnerTypeCodeOfMember)
        {
            //TODO:TO be implemented

            return null;
        }

        #region Authorization Methods
        public bool IsUserAuthorizedToPerformFunction(string userName, int appId, string subscriberId, string portCode,
            string appEntityCode, string functionCode)
        {

            return true;
        }

        public bool HasPrivilege(int appId, string subscriberId, string userId, string portCode,
            string appEntityId, string functionCode)
        {
            int count = (from roleFunctions in _userContext.UserRoleEntityFunctions.Where
                (ur =>
                    ur.ApplicationId == appId && ur.SubscriberId == subscriberId && ur.UserId == userId && ur.ApplicationEntityId == appEntityId && ur.FunctionCode == functionCode)
                         select roleFunctions).Count();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        

        public ICollection<AuthorizedFunctionDTO> GetAuthorisedPermissionsForUserInEntity(string userName, int appId,
            int subscriberId, string portCode, string appEntityCode)
        {
            //TODO:TO be implemented
            return null;
        }

        public List<MenuModuleDTO> GetMenuForUser(int applicationId, string userName)
        {
            //TODO:TO be implemented
            return null;
        }
        #endregion


    }
}
