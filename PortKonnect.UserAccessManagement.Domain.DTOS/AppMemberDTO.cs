﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class AppMemberDTO
    {
        public string PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string PartnerCode { get; set; }
        public string PartnerType { get; set; }
        public int ApplicationId { get;  set; }
        public string MemberId { get; set; }
		public string MemberCode { get; set; }
        public string RecordStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}