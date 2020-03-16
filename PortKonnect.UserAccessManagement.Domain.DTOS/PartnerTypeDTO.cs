
namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class PartnerTypeDTO
    {
        public string PartnerTypeId { get; set; }
        public string PartnerTypeName { get; set; }
        public string IsDelete { get; set; }
		public string MemberType { get; set; }
		public string MemberCode { get; set; }
		public string PartnerCode { get; set; }
		public string SubscriberId { get; set; }
        public PartnerTypeDTO()
        {

        }
        public PartnerTypeDTO(string partnerTypeId, string partnerTypeName, string IsDelete)
        {
            this.PartnerTypeId = partnerTypeId;
            this.PartnerTypeName = partnerTypeName;
            this.IsDelete = IsDelete;
        }
    }
}
