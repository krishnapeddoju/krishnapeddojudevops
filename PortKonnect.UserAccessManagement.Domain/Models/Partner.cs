using System;
using System.Collections.Generic;
using System.Linq;
using PortKonnect.Common.Domain.Model;
using PortKonnect.UserAccessManagement.GlobalConstants;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class Partner
    {
        public string PartnerId { get; protected set; }

        private string _partnerName;
        public string PartnerName
        {
            get { return _partnerName; }
            protected set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "Partner Name is Required");
                _partnerName = value;
            }
        }

        private string _partnerType;
        public string PartnerType
        {
            get { return _partnerType; }
            protected set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "Partner Type is Required");
                _partnerType = value;
            }
        }

        private string _partnerCode;
        public string PartnerCode
        {
            get { return _partnerCode; }
            protected set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "Port Code is Required");
                _partnerCode = value;
            }
        }

        public string RecordStatus { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }

        public Address PartnerAddress { get; protected set; }

        public virtual ICollection<SubscriptionMember> SubscriptionMembers { get; protected set; }
        public virtual ICollection<PartnerPort> partnerPorts { get; protected set; }
        public virtual ICollection<PartnerTypes> partnerTypes { get; protected set; }


        public Partner()
        {


        }
        public Partner(string partnerId, string partnerName, string partnerType, string partnerCode, Address address, string recordStatus, string createdBy, DateTime createdOn, int applicationId, string subscriberId)
        {
            this.PartnerId = partnerId;
            this.PartnerName = partnerName;
            this.PartnerType = partnerType;
            this.PartnerCode = partnerCode;
            this.RecordStatus = recordStatus;
            this.CreatedBy = createdBy;
            this.CreatedOn = createdOn;
            //this.UpdatedBy = updatedBy;
            //this.UpdatedOn = updatedOn;
            this.PartnerAddress = address;
            this.partnerPorts = new List<PartnerPort>();
            this.partnerTypes = new List<PartnerTypes>();
            SubscribeToApplication(applicationId, subscriberId);
        }

        public void SubscribeToApplication(int applicationId,string subscriberId)
        {
            if(SubscriptionMembers==null)
                SubscriptionMembers = new List<SubscriptionMember>();

            var subscriptionMember =
                SubscriptionMembers.FirstOrDefault(
                    c => c.MemberId == PartnerId && c.PartnerId == subscriberId && c.ApplicationId == applicationId);
            if(subscriptionMember == null)
                SubscriptionMembers.Add(new SubscriptionMember(subscriberId,applicationId,PartnerId,UAMGlobalConstants.RecordStatus, CreatedBy,CreatedOn,null, null));
            //TODO: Need to check for inactive subscriptions and update as active. Currently inactive is not possible from application
        }

        public void OperateAtPort(string portCode)
        {
            //TODO:Need to search basedon partnerid and portcode if not exist raise validation Port does not exist
            partnerPorts.Add(new PartnerPort(this.PartnerId, portCode, this.RecordStatus, this.CreatedBy, DateTime.Now, this.UpdatedBy, DateTime.Now));
        }

        public void PartnerTypeOperator(string partnerType, string IsDelete, string subscriberId)
        {
            //TODO:Need to search basedon partnerid and portcode if not exist raise validation Port does not exist
            PartnerTypes partnerTypeDetails = partnerTypes.FirstOrDefault(c => c.partnerTypeName == partnerType && c.SubscriberId == subscriberId);
            if (partnerTypeDetails == null)
                partnerTypes.Add(new PartnerTypes(this.PartnerId, partnerType, IsDelete, subscriberId));
        }

        public void ChangePartnerDetails(string partnerCode, string partnerName, string partnerType)
        {
            this.PartnerCode = partnerCode;
            this.PartnerName = partnerName;
            this.PartnerType = partnerType;
        }

        public void ChangeUpdatedByAndOn(string partnerId)
        {
            this.UpdatedBy = partnerId;
            this.UpdatedOn = DateTime.Now;
        }

        public void DeletePartnerType(string partnerType, string isDelete)
        {
            PartnerTypes partnertype = null;
            if (partnerTypes.Count > 0)
            {
                partnertype = partnerTypes.ToList().Find(c => c.partnerTypeName.Equals(partnerType));
            }

            partnertype.UpdateIsDeleted(isDelete);
        }


        public void ChangeAddressDetails(string houseNo, string streetName, string areaName, string townOrCityName, string state, string country, string zipCode, string contactNumber, string emailId, string webSite, string fileName, string logopath)
        {
            this.PartnerAddress = new Address(houseNo, streetName, areaName, townOrCityName, state, country, zipCode, contactNumber, emailId, webSite, fileName, logopath);
        }
    }
}
