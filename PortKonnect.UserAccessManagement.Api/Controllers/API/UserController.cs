using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.DataServcies;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.Common.Domain.Model;
using PortKonnect.UserAccessManagement.GlobalConstants;
using PortKonnect.Common.Contracts;

namespace PortKonnect.UserAccessManagement.Api
{
	public class UserController : ApiControllerBase
	{
		private readonly IUserApplicationService _userApplicationService;
		private readonly IUserDataService _userDataService;
		private readonly IAccountService _accountService;
		public UserController(IUserApplicationService userApplicationService, IUserDataService userDataService, IAccountService accountService)
		{
			_userApplicationService = userApplicationService;
			_userDataService = userDataService;
			_accountService = accountService;
		}

		[Route("api/GetAllSubscribedUsers")]
		[HttpGet]
		public HttpResponseMessage GetAllSubscribedUsers(HttpRequestMessage request, string userName, string firstName, string lastName, string partnerType, string dormantUser)
		{
            List<UserDTO> usersList;
            if (contextDto.MemberType == RoleCodeConstants.TO || contextDto.MemberType  == CargoRoleCodeConstants.Admin)
            {
                usersList = _userDataService.GetAllSubscribedUsersforTO(contextDto.ApplicationId, contextDto.SubscriberId,
                    contextDto.UserId, contextDto.MemberId, userName, firstName, lastName, partnerType, dormantUser);
            }
            else
            {
                usersList= _userDataService.GetAllSubscribedUsers(contextDto.ApplicationId, contextDto.SubscriberId, contextDto.UserId, contextDto.MemberId, userName, firstName, lastName, partnerType, dormantUser);
            }
            HttpResponseMessage message = request.CreateResponse<List<UserDTO>>(HttpStatusCode.OK, usersList);
			return message;
		}

		[Route("api/GetUserForUserId/{userId}")]
		[HttpGet]
		public HttpResponseMessage GetUserForUserId(HttpRequestMessage request, string userId)
		{
		    return GetHttpResponse(request, () =>
		    {
                //TODO: Need to test
                //    // UserDTO user = _userDataService.GetUserForUserId(userId);
                //          // HttpResponseMessage message = request.CreateResponse<UserDTO>(HttpStatusCode.OK, user);

                //     UserDTO user = (contextDto == null || contextDto.MemberType == UAMGlobalConstants.PartnerTypeTO || contextDto.MemberType == UAMGlobalConstants.PartnerTypeSuperAdmin) ? _userDataService.GetUserForUserId(userId) : _userDataService.GetUserForUserId(userId, contextDto.MemberId);
                //           HttpResponseMessage message = (user == null) ? request.CreateResponse<string>(HttpStatusCode.OK, UAMGlobalConstants.UnauthorizedCredentials) : request.CreateResponse<UserDTO>(HttpStatusCode.OK, user);
                //           return message;
                UserDTO user;
                if(contextDto.MemberType == RoleCodeConstants.TO ||contextDto.MemberType == RoleCodeConstants.SuperAdmin || contextDto.MemberType  == CargoRoleCodeConstants.Admin)
                    user = _userDataService.GetUserForUserId(userId, contextDto.SubscriberId, contextDto.ApplicationId);
                else
                    user = _userDataService.GetUserForUserIdByPartnerId(userId, contextDto.MemberId ,contextDto.SubscriberId);


                HttpResponseMessage message = request.CreateResponse<UserDTO>(HttpStatusCode.OK, user);
                return message;
            });
		}



		[AllowAnonymous]
		[Route("api/GetUserForUserId_Notification/{userId}")]
		[HttpGet]
		public HttpResponseMessage GetUserForUserId_Notification(HttpRequestMessage request, string userId)
		{
            // hard-coded temporarily as allow anonymous method will not have token to dill contextDto
            UserDTO user = _userDataService.GetUserForUserId(userId, contextDto==null ? "KPCT": contextDto.SubscriberId, contextDto == null ? 2 : contextDto.ApplicationId);
            HttpResponseMessage message = request.CreateResponse<UserDTO>(HttpStatusCode.OK, user);
			return message;
		}



		[Route("api/GetAllSubscribedPartners/{PartnerType}")]
		[HttpGet]
		public HttpResponseMessage GetAllSubscribedPartners(HttpRequestMessage request, string PartnerType)
		{
			List<AppMemberDTO> usersList = _userApplicationService.GetAllSubscribedPartners(contextDto, PartnerType);
			HttpResponseMessage message = request.CreateResponse<List<AppMemberDTO>>(HttpStatusCode.OK, usersList);
			return message;
		}

		[Route("api/User")]
		[HttpPost]
		public HttpResponseMessage PostUser(HttpRequestMessage request, UserDTO userDTO)
		{
			return GetHttpResponse(request, () =>
			{
                

                _userApplicationService.AddUser(userDTO, contextDto);
				HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
				return response;
			});
		}

		[Route("api/UpdateUser")]
		[HttpPost]
		public HttpResponseMessage UpdateUser(HttpRequestMessage request, UserDTO userDTO)
		{
			return GetHttpResponse(request, () =>
			{
				_userApplicationService.UpdateUser(userDTO, contextDto);
				HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
				return response;
			});
		}

		[Route("api/ActivateOrDeActivateUser/{userId}/{isDeleted}")]
		[HttpPost]
		public HttpResponseMessage ActivateOrDeActivateUser(HttpRequestMessage request, string userId, string isDeleted)
		{
			return GetHttpResponse(request, () =>
			{
				_userApplicationService.ActivateOrDeActivateUser(userId, isDeleted, contextDto);
				HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, true);
				return response;
			});
		}

		[Route("api/GetUserIdAndNames")]
		[HttpGet]
		public HttpResponseMessage GetUserIdAndNames(HttpRequestMessage request)
		{
			List<UserDTO> usersList = _userDataService.GetUserIdAndNames();
			HttpResponseMessage message = request.CreateResponse<List<UserDTO>>(HttpStatusCode.OK, usersList);
			return message;
		}

		[Route("api/User/GetUsersForMemberId/{appId}/{subscriberId}/{memeberId}")]
		[HttpGet]

		public HttpResponseMessage GetUsersForMemberId(HttpRequestMessage request, int appId, string subscriberId, string memeberId)
		{
			List<UserDTO> usersList = _userApplicationService.GetUsersForMemberId(appId, subscriberId, memeberId);
			HttpResponseMessage message = request.CreateResponse<List<UserDTO>>(HttpStatusCode.OK, usersList);
			return message;
		}






		[Route("api/User/GetUsersForMemberByRole/{appId}/{subscriberId}/{memeberId}/{roleId}")]
		[HttpGet]
		[AllowAnonymous]
		public HttpResponseMessage GetUsersForMemberByRole(HttpRequestMessage request, int appId, string subscriberId, string memeberId, string roleId)
		{
			List<UserDTO> usersList = _userApplicationService.GetUsersForMemberByRole(appId, subscriberId, memeberId, roleId);
			HttpResponseMessage message = request.CreateResponse<List<UserDTO>>(HttpStatusCode.OK, usersList);
			return message;
		}
		[Route("api/User/GetUsersTobeNotified/{appId}/{subscriberId}/{memeberId}/{roleId}")]
		[HttpGet]
		[AllowAnonymous]
		public HttpResponseMessage GetUsersTobeNotified(HttpRequestMessage request, int appId, string subscriberId, string memeberId, string roleId)
		{
			List<UserDTO> usersList = _userDataService.GetUsersTobeNotified(appId, subscriberId, memeberId, roleId);
			HttpResponseMessage message = request.CreateResponse<List<UserDTO>>(HttpStatusCode.OK, usersList);
			return message;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="request"></param>
		/// <param name="appId"></param>
		/// <param name="subscriberId"></param>
		/// <param name="memeberId"></param>
		/// <param name="roleId"></param>
		/// <returns></returns>
		[AllowAnonymous]
		[Route("api/User/GetUsersTobeNotified_Notification/{appId}/{subscriberId}/{memeberId}/{roleId}")]
		[HttpGet]
		public HttpResponseMessage GetUsersTobeNotified_Notification(HttpRequestMessage request, int appId, string subscriberId, string memeberId, string roleId)
		{
			List<UserDTO> usersList = _userDataService.GetUsersTobeNotified(appId, subscriberId, memeberId, roleId);
			HttpResponseMessage message = request.CreateResponse<List<UserDTO>>(HttpStatusCode.OK, usersList);
			return message;
		}


		[AllowAnonymous]
		[Route("api/User/GetEmailDetails_Notification/{appId}/{subscriberId}")]
		[HttpGet]
		public HttpResponseMessage GetEmailDetails_Notification(HttpRequestMessage request, int appId, string subscriberId)
		{
			EmailDetailsDTO emailDetailsDTO = _userDataService.GetEmailDetails(appId, subscriberId);
			HttpResponseMessage message = request.CreateResponse<EmailDetailsDTO>(HttpStatusCode.OK, emailDetailsDTO);
			return message;
		}


		[AllowAnonymous]
		[Route("api/User/GetSMSDetails_Notification/{appId}/{subscriberId}")]
		[HttpGet]
		public HttpResponseMessage GetSMSDetails_Notification(HttpRequestMessage request, int appId, string subscriberId)
		{
			SMSDetailsDTO smsDetailsDTO = _userDataService.GetSMSDetails(appId, subscriberId);
			HttpResponseMessage message = request.CreateResponse<SMSDetailsDTO>(HttpStatusCode.OK, smsDetailsDTO);
			return message;
		}

		[Route("api/User/GetSpecialUsersTobeNotified/{appId}/{subscriberId}/{roleId}")]
		[HttpGet]
		[AllowAnonymous]
		public HttpResponseMessage GetUsersTobeNotified(HttpRequestMessage request, int appId, string subscriberId, string roleId)
		{
			List<UserDTO> usersList = _userDataService.GetSpecialUsersTobeNotified(appId, subscriberId, roleId);
			HttpResponseMessage message = request.CreateResponse<List<UserDTO>>(HttpStatusCode.OK, usersList);
			return message;
		}


		[AllowAnonymous]
		[Route("api/User/GetSpecialUsersTobeNotified_Notification/{appId}/{subscriberId}/{roleId}")]
		[HttpGet]
		public HttpResponseMessage GetSpecialUsersTobeNotified_Notification(HttpRequestMessage request, int appId, string subscriberId, string roleId)
		{
			List<UserDTO> usersList = _userDataService.GetSpecialUsersTobeNotified(appId, subscriberId, roleId);
			HttpResponseMessage message = request.CreateResponse<List<UserDTO>>(HttpStatusCode.OK, usersList);
			return message;
		}


		[Route("api/PartnerTypesForUser")]
		[HttpGet]
		public HttpResponseMessage GetPartnerTypesForUser(HttpRequestMessage request)
		{
			return GetHttpResponse(request, () =>
			{
				List<PartnerTypeDTO> partnerTypes = _userApplicationService.GetPartnerTypesForUser(contextDto);
				HttpResponseMessage response = request.CreateResponse<List<PartnerTypeDTO>>(HttpStatusCode.OK, partnerTypes);
				return response;
			});

		}


        [Route("api/GetUsers")]
		[HttpGet]
		public HttpResponseMessage GetUsers(HttpRequestMessage request)
		{
			return GetHttpResponse(request, () =>
			{
				List<UserDTO> usersList = _userApplicationService.GetUsers(contextDto.UserId, contextDto.ApplicationId, contextDto.SubscriberId);
				HttpResponseMessage response = request.CreateResponse<List<UserDTO>>(HttpStatusCode.OK, usersList);
				return response;
			});

		}


		[Route("api/User/PutForgetPassword")]
		[HttpPost]
		public HttpResponseMessage PutForgetPassword(HttpRequestMessage request, UserDTO userDTO)
		{
			return GetHttpResponse(request, () =>
			{
				string msg = _accountService.ResetPassword(contextDto.ApplicationId, contextDto.SubscriberId, userDTO.UserName);
				HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, msg);
				return response;
			});
		}
        [Route("api/User/TokenServieResetPassword")]
        [HttpPost]
        public HttpResponseMessage TokenServieResetPassword(HttpRequestMessage request, UserDTO userDTO)
        {
            return GetHttpResponse(request, () =>
            {
                string msg = _accountService.TokenServieResetPassword(contextDto.ApplicationId, contextDto.SubscriberId, userDTO.UserName,null);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, msg);
                return response;
            });
        }

        [Route("api/GetContext")]
		[HttpGet]
		public HttpResponseMessage GetContext(HttpRequestMessage request)
		{
			return GetHttpResponse(request, () =>
			{
				ContextDTO contextDTO = contextDto;
				HttpResponseMessage response = request.CreateResponse<ContextDTO>(HttpStatusCode.OK, contextDto);
				return response;
			});

		}

        [AllowAnonymous]
        [Route("api/GetExistingUser/{parterType}/{userName}")]
        [HttpGet]
        public HttpResponseMessage GetExistingUser(HttpRequestMessage request, string parterType, string userName)
        {
            bool user = _userDataService.CheckPartnerExist(parterType, userName);
            HttpResponseMessage message = request.CreateResponse<bool>(HttpStatusCode.OK, user);
            return message;
        }

	}
}