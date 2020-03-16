using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.GlobalConstants;
using System.Configuration;

namespace PortKonnect.UserAccessManagement.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IUserContext _userContext;

		public UserRepository(IUserContext userContext)
		{
			_userContext = userContext;
		}

		public void AddUser(User user)
		{

			_userContext.Users.AddOrUpdate(user);
			_userContext.SaveChanges();
		}

		public User GetUserForUserId(string userId)
		{
			User user = (from u in _userContext.Users.Where(t => t.UserId == userId) select u).FirstOrDefault();
			if (user != null)
			{
				user.ApplicationId = _userContext.SubscriptionMembers.Where(t => t.MemberId == user.PartnerId).Select(q => q.ApplicationId).FirstOrDefault();
			}
			return user;
		}

		public UserDTO GetUserForUserName(string userName)
		{
			throw new NotImplementedException();
		}


        public User GetUserByUserName(string userName)
        {
            User user = (from u in _userContext.Users.Where(t => t.UserName == userName) select u).FirstOrDefault();
            //if (user != null)
            //{
            //    user.ApplicationId = _userContext.SubscriptionMembers.Where(t => t.MemberId == user.PartnerId).Select(q => q.ApplicationId).FirstOrDefault();
            //}
            return user;

        }

        public User GetUserByPartnerid(string Partnerid)
        {
            User user = (from u in _userContext.Users.Where(t => t.PartnerId == Partnerid) select u).FirstOrDefault();
            //if (user != null)
            //{
            //    user.ApplicationId = _userContext.SubscriptionMembers.Where(t => t.MemberId == user.PartnerId).Select(q => q.ApplicationId).FirstOrDefault();
            //}
            return user;

        }
        public List<UserDTO> GetUsers(string UserId, int applicationId, string subscriberId)
		{
			List<string> userId1 = _userContext.Conversations.Where(q => q.FromUserId == UserId).Select(t => t.ToUserId).ToList();
			List<string> userId2 = _userContext.Conversations.Where(q => q.ToUserId == UserId).Select(t => t.FromUserId).ToList();


			List<UserDTO> userDtos = (from u in _userContext.Users.Where(t => t.RecordStatus == UAMGlobalConstants.RecordStatus && t.IsDeleted == UAMGlobalConstants.IsDeletedNo)
									  join p in _userContext.Partners on u.PartnerId equals p.PartnerId
									  join sm in _userContext.SubscriptionMembers on p.PartnerId equals sm.MemberId
									  where !userId1.Contains(u.UserId) && !userId2.Contains(u.UserId) && u.UserId != UserId && sm.ApplicationId == applicationId && sm.PartnerId == subscriberId
									  select new UserDTO
									  {
										  UserId = u.UserId,
										  UserName = u.UserName,
										  FirstName = u.FirstName,
										  LastName = u.LastName

									  }).ToList();

			return userDtos.OrderBy(t => t.UserName).ToList();
		}

		public List<UserDTO> GetUsersForPartner(string partnerId)
		{
			throw new NotImplementedException();
		}

		public List<PartnerTypeDTO> GetPartnerTypesForUser(ContextDTO contextDto)
		{
			string roles = ConfigurationManager.AppSettings["RolesForpartnerType"];
			List<PartnerTypeDTO> partnerTypes = new List<PartnerTypeDTO>();
			if (roles.Contains(contextDto.MemberType))
			{
				partnerTypes = _userContext.partnerTypePrioritys.Select(t => new PartnerTypeDTO
				{
					PartnerTypeId = t.PartnerTypeCode,
					PartnerTypeName = t.PartnerTypeName,
					MemberType = contextDto.MemberType,
					//PartnerCode=
				}).OrderBy(q => q.PartnerTypeName).ToList();


			}
			else
			{
				var PartnertypeList = (from p in _userContext.PartnerTypes.Where(t => t.PartnerId == contextDto.MemberId && t.SubscriberId==contextDto.SubscriberId) select p.partnerTypeName).ToList();

				foreach (var partnerType in PartnertypeList.ToList())
				{
					string partner = partnerType.ToString();
					PartnerTypeDTO partners = (from pt in _userContext.partnerTypePrioritys.Where(t => t.PartnerTypeCode == partner)
											   select new PartnerTypeDTO
												   {
													   PartnerTypeId = pt.PartnerTypeCode,
													   PartnerTypeName = pt.PartnerTypeName,
													   MemberType = contextDto.MemberType,
													   MemberCode = contextDto.MemberId,
													   PartnerCode=contextDto.MemberCode
												   }).FirstOrDefault();

					partnerTypes.Add(partners);
				}
			}
			return partnerTypes;

		}

		public bool AuthenticateUser(int applicationId, string userName, string password)
		{
			IQueryable<UserDTO> user = (from u in _userContext.Users.Where(u => u.UserName == userName && u.Password == password)
										join p in _userContext.Partners on u.PartnerId equals p.PartnerId
										join sm in _userContext.SubscriptionMembers on p.PartnerId equals sm.MemberId
										where sm.ApplicationId.Equals(applicationId)
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
											IsDeleted = u.IsDeleted,
											IsFirstTimeLogin = u.IsFirstTimeLogin,
											InCorrectLogins = u.InCorrectLogins,
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

		public List<User> GetUsersForMemberId(int appId, string subscriberId, string memeberId)
		{
			List<User> user = new List<User>();
			List<User> users = (from u in _userContext.Users.Where((t => t.PartnerId == subscriberId || t.PartnerId == memeberId))
								join p in _userContext.Partners on u.PartnerId equals p.PartnerId
								join sm in _userContext.SubscriptionMembers on p.PartnerId equals sm.MemberId
								where sm.ApplicationId == appId

								select u).ToList();

			if (users.ToList() != null)
			{
				foreach (User u in users.ToList())
				{
					u.ApplicationId = appId;
					user.Add(u);
				}
				return user;
			}
			return null;
		}

		public List<User> GetUsersForMemberByRole(int appId, string subscriberId, string memeberId, string roleId)
		{
			List<User> user = new List<User>();
			IQueryable<User> users = (from u in
										  _userContext.Users.Where(t => (t.PartnerId == subscriberId || t.PartnerId == memeberId) &&
											  (from r in t.UserRoles select r.RoleId).Contains(roleId))
									  join p in _userContext.Partners on u.PartnerId equals p.PartnerId
									  join sm in _userContext.SubscriptionMembers on p.PartnerId equals sm.MemberId
									  where sm.ApplicationId == appId
									  select u);


			if (users.ToList() != null)
			{
				foreach (User u in users.ToList())
				{
					u.ApplicationId = appId;
					user.Add(u);
				}
				return user;
			}
			return null;
		}
		public int GetUsersForUserNameOtherThanUserId(string userId, string userName)
		{
			int count =
				(from u in _userContext.Users.Where(u => u.UserName == userName && u.UserId != userId) select u).Count();
			return count;
		}

		public void UpdateUser(User user)
		{
			_userContext.Users.AddOrUpdate(user);
			_userContext.SaveChanges();
		}

		public List<AppMemberDTO> GetAllSubscribedPartners(int applicationId, string subscriberId, string PartnerType)
		{
			var partners= _userContext.Partners.Where(c => c.SubscriptionMembers.Any(d => d.PartnerId == subscriberId) && c.partnerTypes.Any(e=>e.partnerTypeName== PartnerType && e.SubscriberId == subscriberId))
                .Select(c=>new
                {
                    PartnerCode = c.PartnerId,
                    PartnerName = c.PartnerName,
                    PartnerType = c.PartnerType
                }).Distinct().ToList();

		    return partners.Select(partner => new AppMemberDTO
		    {
		        PartnerCode = partner.PartnerCode, PartnerName = partner.PartnerName, PartnerType = partner.PartnerType
		    }).ToList();
		}
	}
}
