
namespace PortKonnect.UserAccessManagement.Domain
{
    public class PartnerTypes 
    {
        public string PartnerId { get; protected set; }
        public string partnerTypeName { get; protected set; }
        public string IsDelete { get; protected set; }
        public string SubscriberId { get; protected set; }

        public PartnerTypes()
        {


        }

        public PartnerTypes(string partnerId, string partnerType, string isDelete, string subscriberId)
        {
            PartnerId = partnerId;
            partnerTypeName = partnerType;
            IsDelete = isDelete;
            SubscriberId = subscriberId;
        }


        public void UpdateIsDeleted(string isDelete)
        {
            IsDelete = isDelete;
        }



    }
}
