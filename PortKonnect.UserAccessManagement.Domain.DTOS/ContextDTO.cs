using System;
using System.Collections.Generic;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class ContextDTO
    {
        public int ApplicationId { get; set; }
        public string SubscriberId { get; set; }
        public string PortCode { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string MemberId { get; set; }
        public string MemberType { get; set; }
		public string PartnerType { get; set; }
        public string IsFirstTimeLogin { get; set; }
        public string Token { get; set; }
		public string MemberCode { get; set; }
        public string PartnerTypes { get; set; }
        public string UserRoles { get; set; }
        public DateTime Tokenvalidto { get; set; }
        public DateTime Tokenvalidfrom { get; set; }
        public string ExceptionMessage { get; set; }
        public string PartnerLogo { get; set; }
        public string Email { get; set; }
        public string Mobile{ get; set; }

        public string Name { get; set; }

        public List<string> UserRoleCodeArray { get; set; }
        public ContextDTO()
        {

        }

        public void SetContext(ContextDTO copyContext)
        {
            this.ApplicationId = copyContext.ApplicationId;
            this.SubscriberId = copyContext.SubscriberId;
            this.PortCode = copyContext.PortCode;
            this.UserId = copyContext.UserId;
            this.UserName = copyContext.UserName;
            this.MemberId = copyContext.MemberId;
            this.MemberType = copyContext.MemberType;
			this.MemberCode = copyContext.MemberCode;
            this.IsFirstTimeLogin = copyContext.IsFirstTimeLogin;
            this.UserRoles = copyContext.UserRoles;
            this.Tokenvalidfrom = copyContext.Tokenvalidfrom;
            this.Tokenvalidto = copyContext.Tokenvalidto;
            this.PartnerLogo = copyContext.PartnerLogo;

        }


    }
}