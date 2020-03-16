using System;
using System.Linq;
using System.Collections.Generic;
using PortKonnect.Common.Domain.Model;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.MapToDTOS;
using PortKonnect.UserAccessManagement.Domain.Repositories;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.GlobalConstants;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public class PartnerApplicationService : ServiceBase, IPartnerApplicationService
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly ICommonRepository _commonRepository;
        private readonly IUserRepository _userRepository;

        public PartnerApplicationService(IUserContext userContext, IPartnerRepository partnerRepository, ISubscriptionRepository subscriptionRepository, ICommonRepository commonRepository, IUserRepository userRepository)
        {
            _partnerRepository = partnerRepository;
            _subscriptionRepository = subscriptionRepository;
            _commonRepository = commonRepository;
            UserContext = userContext;
            _userRepository = userRepository;
        }

        //TODO: All db calls to be written in Repository Layer

        public List<PartnerListDTO> GetPartnersList(string partnerName, string partnerType, string emailId, string contactNumber, string subscribedId, int applicationId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                List<PartnerListDTO> partnersListDtos = _partnerRepository.GetPartners(subscribedId, applicationId, partnerName, partnerType, emailId, contactNumber);
                foreach (PartnerListDTO partner in partnersListDtos)
                {

                    List<string> partnerTypes = new List<string>();
                    foreach (string partnerTypeName in partner.partnerTypeArray)
                    {
                        if (partnerTypeName != UAMGlobalConstants.ConsortiumPartner)
                        {
                            PartnerTypeDTO partnerTypeDto = _commonRepository.GetPartnerTypeName(partnerTypeName);
                            //if (partnerTypeDto != null)
                            //    partner.partnerTypeArray = partnerTypeDto.PartnerTypeName;
                            partnerTypes.Add(partnerTypeDto.PartnerTypeName);
                            if (String.IsNullOrEmpty(partner.PartnerTypeArrays))
                                partner.PartnerTypeArrays = partnerTypeDto.PartnerTypeName;
                            else
                                partner.PartnerTypeArrays = partner.PartnerTypeArrays + "," + partnerTypeDto.PartnerTypeName;
                            //user.PartnerTypeArray = partnertypes;
                        }

                    }

                    partner.partnerTypeArray = new List<string>();
                    foreach (string partnerTypeNames in partnerTypes)
                    {

                        partner.partnerTypeArray.Add(partnerTypeNames);

                    }
                    PortDTO portDto = _commonRepository.GetPortByPortCode(ApplicationContextDTO.PortCode);
                    if (portDto != null)
                        partner.SubscribedPort = portDto.PortName;
                }
                return partnersListDtos;


            });
        }

        public List<PortDTO> GetPorts()
        {
            return ExecuteFaultHandledOperation(() => _commonRepository.GetPorts());
        }

        public List<CountryDTO> GetCountries()
        {
            return ExecuteFaultHandledOperation(() => _commonRepository.GetCountries());
        }

        public List<ApplicationDTO> GetApplication()
        {
            return ExecuteFaultHandledOperation(() => _commonRepository.GetApplicationsById(ApplicationContextDTO.ApplicationId));

        }

        public List<PartnerDTO> GetPartnerCodes(List<string> partnerType)
        {
            return ExecuteFaultHandledOperation(() => _commonRepository.GetPartnerCodes(partnerType, ApplicationContextDTO.SubscriberId));
        }

        public List<PartnerDTO> GetPartners(List<string> partnerCodes)
        {
            return _commonRepository.GetPartners(partnerCodes);
        }

        public List<PartnerDTO> GetPartnersByPartnerType(string partnerType)
        {
            return _commonRepository.GetPartnersByPartnerType(partnerType);
        }

        public List<PartnerTypeDTO> GetPartnerTypes()
        {
            return ExecuteFaultHandledOperation(() => _commonRepository.GetPartnerTypes().Where(t => t.PartnerTypeId != UAMGlobalConstants.ConsortiumPartner).ToList());
        }

        public void AddPartner(PartnerDTO partnerDTO)
        {
            EncloseTransactionAndHandleException(() =>
            {

                if(ApplicationContextDTO.UserName == null || ApplicationContextDTO.UserName == "")
                {
                    ApplicationContextDTO.ApplicationId = UAMGlobalConstants.ApplicationId;
                    ApplicationContextDTO.SubscriberId = UAMGlobalConstants.SubscriberId;
                    ApplicationContextDTO.UserName = _userRepository.GetUserForUserId(partnerDTO.CreatedBy).UserName;
       
                }
                Partner partner = _partnerRepository.GetPartner(ApplicationContextDTO.ApplicationId, partnerDTO.PartnerCode);
                
                if (partner != null)
                {
                    AssertionConcern.AssertArgumentFalse(partner.SubscriptionMembers.Any(c => c.PartnerId == ApplicationContextDTO.SubscriberId), "Partner already exists");

                    //TODO: Need to create another table for Address for saving based on SubscriberId
                    partner.SubscribeToApplication(ApplicationContextDTO.ApplicationId, ApplicationContextDTO.SubscriberId);
                    partner.ChangeUpdatedByAndOn(ApplicationContextDTO.UserName);
                }
                else
                {
                    partnerDTO.PartnerId = Guid.NewGuid().ToString();
                    if (string.IsNullOrEmpty(partnerDTO.PartnerId.Trim()))
                    {
                        throw new ArgumentException("Partner Id cannot be null for a new Partner");
                    }
                    partnerDTO.CreatedBy = ApplicationContextDTO.UserName;
                    partnerDTO.CreatedOn = DateTime.Now;

                    if (partnerDTO.PartnerTypeArray.Contains(UAMGlobalConstants.VesselOperatingAgent))
                        partnerDTO.PartnerTypeArray.Add(UAMGlobalConstants.ConsortiumPartner);

                    List<PartnerTypePriorityDTO> prioritylist = _commonRepository.GetPartnerTypePriorityList(partnerDTO.PartnerTypeArray);

                    var partnerTypePriorityDto = prioritylist.OrderBy(c => c.PriorityNo).FirstOrDefault();
                    if (partnerTypePriorityDto != null)
                        partnerDTO.PartnerType = partnerTypePriorityDto.PartnerTypeCode;

                    Address address = new Address(partnerDTO.PartnerAddress.HouseNumber, partnerDTO.PartnerAddress.StreetName, partnerDTO.PartnerAddress.AreaName, partnerDTO.PartnerAddress.TownOrCity, partnerDTO.PartnerAddress.State, partnerDTO.PartnerAddress.Country, partnerDTO.PartnerAddress.ZipCode, partnerDTO.PartnerAddress.ContactNumber, partnerDTO.PartnerAddress.EmailId, partnerDTO.PartnerAddress.WebSite, partnerDTO.PartnerAddress.LogoFileName, partnerDTO.PartnerAddress.LogoPath);
                    partner = new Partner(partnerDTO.PartnerId, partnerDTO.PartnerName, partnerDTO.PartnerType,
    partnerDTO.PartnerCode, address, UAMGlobalConstants.RecordStatus, ApplicationContextDTO.UserName,
    DateTime.Now, ApplicationContextDTO.ApplicationId, ApplicationContextDTO.SubscriberId);

                    foreach (string portCode in partnerDTO.PartnerPortArray)
                    {
                        partner.OperateAtPort(portCode);
                    }
                }
                #region Code to be Removed
                //if (partnerDTO.PartnerTypeArray != null)
                //{


                //    #region Code to be Removed
                //    //List<string> partnerTypes = partnerDTO.PartnerTypeArray;
                //    //foreach (string partnerTypeName in partnerDTO.PartnerTypeArray)
                //    //{
                //    //    partnerTypes.Add(partnerTypeName);
                //    //}
                //    //foreach (string partnerTypeName in partnerTypes)
                //    //{
                //    //    if (partnerTypeName == UAMGlobalConstants.VesselOperatingAgent)
                //    //    {
                //    //        partnerDTO.PartnerTypeArray.Add(UAMGlobalConstants.ConsortiumPartner);
                //    //    }
                //    //}
                //    #endregion



                //    
                //    //foreach (string partnerType in partnerDTO.PartnerTypeArray)
                //    //{
                //    //    PartnerTypePriorityDTO priorityList = _commonRepository.GetPartnerTypePriorityList(partnerType);
                //    //    prioritylist.Add(priorityList);

                //    //}
                //   

                //    //if (prioritylist != null)
                //    //{
                //    //    List<int> priorityNos = new List<int>();
                //    //    foreach (var poritityNo in prioritylist)
                //    //    {
                //    //        priorityNos.Add(poritityNo.PriorityNo);

                //    //    }
                //    //    priorityNos.Sort();
                //    //    int minpriorityNo = priorityNos[0];
                //    //    partnerDTO.PartnerType = prioritylist.Find(t => t.PriorityNo == minpriorityNo).PartnerTypeCode.ToString();


                //    //}

                //}
                #endregion

                foreach (string partnerType in partnerDTO.PartnerTypeArray)
                {
                    partner.PartnerTypeOperator(partnerType, UAMGlobalConstants.IsDeletedNo, ApplicationContextDTO.SubscriberId);
                }
                _partnerRepository.AddPartner(partner);

                //Subscription subscription = _subscriptionRepository.GetSubscription(ApplicationContextDTO.ApplicationId, ApplicationContextDTO.SubscriberId);

                //subscription.AddMember(partnerDTO.PartnerId, ApplicationContextDTO.UserName);
                //_subscriptionRepository.AddSubscription(subscription);

            });
        }

        public void UpdatePartner(PartnerDTO partnerDTO)
        {
            EncloseTransactionAndHandleException(() =>
            {

                if (ApplicationContextDTO.UserName == null || ApplicationContextDTO.UserName == "")
                {
                    ApplicationContextDTO.ApplicationId = UAMGlobalConstants.ApplicationId;
                    ApplicationContextDTO.SubscriberId = UAMGlobalConstants.SubscriberId;
                    ApplicationContextDTO.UserName = _userRepository.GetUserForUserId(partnerDTO.CreatedBy).UserName;

                }


                Partner partnerById = _partnerRepository.GetPartnerByPartnerId(partnerDTO.PartnerId, ApplicationContextDTO.SubscriberId);

                if (partnerById == null) throw new ArgumentNullException("Partner does not Exists");

                if (partnerDTO.PartnerTypeArray.Contains(UAMGlobalConstants.VesselOperatingAgent) && !partnerDTO.PartnerTypeArray.Contains(UAMGlobalConstants.ConsortiumPartner))
                    partnerDTO.PartnerTypeArray.Add(UAMGlobalConstants.ConsortiumPartner);

                List<string> partnerTypeList = partnerById.partnerTypes.Select(c => c.partnerTypeName).ToList();
                partnerTypeList.AddRange(partnerDTO.PartnerTypeArray);
                partnerTypeList = partnerTypeList.Distinct().ToList();

                List<PartnerTypePriorityDTO> prioritylist = _commonRepository.GetPartnerTypePriorityList(partnerTypeList);

                var partnerTypePriorityDto = prioritylist.OrderBy(c => c.PriorityNo).FirstOrDefault();
                if (partnerTypePriorityDto != null)
                    partnerDTO.PartnerType = partnerTypePriorityDto.PartnerTypeCode;

                partnerById.ChangePartnerDetails(partnerDTO.PartnerCode, partnerDTO.PartnerName, partnerDTO.PartnerType);
                partnerById.ChangeAddressDetails(partnerDTO.PartnerAddress.HouseNumber, partnerDTO.PartnerAddress.StreetName, partnerDTO.PartnerAddress.AreaName, partnerDTO.PartnerAddress.TownOrCity, partnerDTO.PartnerAddress.State, partnerDTO.PartnerAddress.Country, partnerDTO.PartnerAddress.ZipCode, partnerDTO.PartnerAddress.ContactNumber, partnerDTO.PartnerAddress.EmailId, partnerDTO.PartnerAddress.WebSite, partnerDTO.PartnerAddress.LogoFileName, partnerDTO.PartnerAddress.LogoPath);
                partnerById.ChangeUpdatedByAndOn(partnerDTO.PartnerId);

                if (partnerDTO.PartnerTypeArray != null)
                {
                    foreach (PartnerTypes partnerType in partnerById.partnerTypes.Where(c => c.SubscriberId == ApplicationContextDTO.SubscriberId))
                    {
                        if (!partnerDTO.PartnerTypeArray.Contains(partnerType.partnerTypeName))
                        {
                            partnerType.UpdateIsDeleted(UAMGlobalConstants.IsDeletedYes);
                        }
                        //else if (partnerDTO.PartnerTypeArray.Contains(partnerType.partnerTypeName))
                        else if (partnerDTO.PartnerTypeArray.Contains(partnerType.partnerTypeName) && partnerType.IsDelete == UAMGlobalConstants.IsDeletedYes)
                        {
                            partnerType.UpdateIsDeleted(UAMGlobalConstants.IsDeletedNo);
                        }
                    }
                    foreach (var partnerType in partnerDTO.PartnerTypeArray)
                    {
                        partnerById.PartnerTypeOperator(partnerType, UAMGlobalConstants.IsDeletedNo, ApplicationContextDTO.SubscriberId);
                    }
                }
                _partnerRepository.UpdatePartner(partnerById);
            });

        }

        public PartnerDTO GetPartner(string partnerId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                Partner partner = _partnerRepository.GetPartnerByPartnerId(partnerId, ApplicationContextDTO.SubscriberId);
                PartnerDTO partnerDto = partner.MapToDto();

                if (partnerDto != null && partnerDto.partnerTypes.Any())
                {
                    partnerDto.PartnerTypeArray = partnerDto.partnerTypes.Where(c => c.SubscriberId == ApplicationContextDTO.SubscriberId && c.IsDelete == UAMGlobalConstants.IsDeletedNo).Select(c => c.PartnerTypeName).ToList();
                    partnerDto.context = ApplicationContextDTO;
                    //foreach (PartnerTypeDTO partnertype in partnerDto.partnerTypes.Where(c=>c.SubscriberId==ApplicationContextDTO.SubscriberId))
                    //{
                    //    if (partnertype.IsDelete == UAMGlobalConstants.IsDeletedNo)
                    //    {
                    //        partnerDto.PartnerTypeArray.Add(partnertype.PartnerTypeName);

                    //    }

                    //}
                }

                return partnerDto;
            });
        }

        public PartnerDTO GetPartnerLogo(string partnerId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                Partner partner = _partnerRepository.GetPartnerByPartnerCode(partnerId);
                PartnerDTO partnerDto = partner.MapToDto();

                if (partnerDto.partnerTypes.Any())
                {
                    partnerDto.PartnerTypeArray = new List<string>();
                    foreach (PartnerTypeDTO partnertype in partnerDto.partnerTypes)
                    {
                        if (partnertype.IsDelete == UAMGlobalConstants.IsDeletedNo)
                        {
                            partnerDto.PartnerTypeArray.Add(partnertype.PartnerTypeName);

                        }

                    }
                }
                partnerDto.context = ApplicationContextDTO;
                return partnerDto;
            });
        }
    }
}
