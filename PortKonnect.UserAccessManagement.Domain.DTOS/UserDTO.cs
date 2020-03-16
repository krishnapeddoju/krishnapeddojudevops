using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
	public class UserDTO
	{
		public string UserId { get; set; } //GUID
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Token { get; set; }
		public string PartnerId { get; set; }
		public string PartnerType { get; set; }
		public string PartnerTypeCode { get; set; }
		public string PartnerTypeName { get; set; }
		public string PartnerName { get; set; }
		public int ApplicationId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Name { get; set; }
		public string ContactNumber { get; set; }
		public string EmailId { get; set; }
		public int InCorrectLogins { get; set; }
		public string DormantStatus { get; set; }
		public string IsFirstTimeLogin { get; set; }
		public string IsDeleted { get; set; }
		public DateTime? PwdExpiryDate { get; set; }
		public DateTime? validFromDate { get; set; }
		public DateTime? validToDate { get; set; }
		public UserPreferenceDTO UserPreference { get; set; }
		//public AddressDTO Address { get;  set; }
		public string RecordStatus { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public string UpdatedBy { get; set; }
		public DateTime? UpdatedOn { get; set; }
		public List<string> UserPortArray { get; set; }
		public List<string> UserRoleArray { get; set; }
		public string UserRoleNameArray { get; set; }
		public List<PartnerTypeDTO> PartnerTypes { get; set; }
		public string PartnerTypeArray { get; set; }
		public List<UserPortDTO> UserPorts { get; set; }
		public List<UserRoleDTO> UserRoles { get; set; }
		public string NewPassword { get; set; }
		public string ReturnUrl { get; set; }
		public string SubscriberId { get; set; }
		public string RememberMe { get; set; }
		public string ForgetPasswordLink { get; set; }
		public string LogTransId { get; set; }
		public DateTime? LogTime { get; set; }
		public string LoginUserId { get; set; }
        public string Remarks { get; set; }
        public string ReqNo { get; set; }
        public string UpdatedByUserName { get; set; }
        public List<string> UserRoleCodeArray { get; set; }
        public string LoginLink { get; set; }
        public string EmployeeGUID { get; set; }
        public string IsCFSUser { get; set; }
       
    }
}
