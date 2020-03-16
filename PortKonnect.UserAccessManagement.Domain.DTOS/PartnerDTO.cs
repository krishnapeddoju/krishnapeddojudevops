using System;
using System.Collections.Generic;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
	public class PartnerDTO
	{
		public string PartnerId { get; set; }
		public string PartnerName { get; set; }
		public string PartnerType { get; set; }
		public string PartnerCode { get; set; }
		public AddressDTO PartnerAddress { get; set; }
		public string RecordStatus { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public string UpdatedBy { get; set; }
		public DateTime? UpdatedOn { get; set; }
		public List<string> PartnerTypeArray { get; set; }
		public List<string> PartnerPortArray { get; set; }
		public string PartnerTypeArrays { get; set; }
		public List<PartnerTypeDTO> partnerTypes { get; set; }
		public ICollection<PartnerPortDTO> partnerPorts { get; set; }
		public ContextDTO context { get; set; }

        public PartnerDTO()
        {
        }

        public PartnerDTO(string partnerName, string partnerType, string partnerCode, AddressDTO address, List<string> partnerTypeArray, List<string> partnerPortArray)
        {
            this.PartnerName = partnerName.Trim();
            this.PartnerType = partnerType;
            this.PartnerCode = partnerCode;
            this.PartnerAddress = address;
            this.PartnerTypeArray = partnerTypeArray;
            this.PartnerPortArray = partnerPortArray;
        }
    }

	public class PartnerListDTO
	{
		public string PartnerId { get; set; }
		public string PartnerName { get; set; }
		public string PartnerType { get; set; }
		public string PartnerCode { get; set; }
		public string ContactNumber { get; set; }
		public string EmailId { get; set; }
		public List<PartnerTypeDTO> partnerTypes { get; set; }
		public List<string> partnerTypeArray { get; set; }
		public string PartnerTypeArrays { get; set; }
		public string SubscribedPort { get; set; }
	}
}
