using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using PortKonnect.Common.Domain.Model;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.MapToDTOS;
using PortKonnect.UserAccessManagement.Domain.Repositories;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.GlobalConstants;
using PortKonnect.Common.Enums;
using PortKonnect.UserAccessManagement.Domain.Enums;
using PortKonnect.Common.Services;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public class PartnerRegistrationApplicationService : ServiceBase, IPartnerRegistrationApplicationService
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IPartnerApplicationService _partnerApplicationService;
        private readonly IPartnerRegistrationRepository _partnerRegistrationRepository;
        private readonly ICommonRepository _commonRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserApplicationService _UserApplicationService;
        public IUserRoleRepository _userRoleRepository;

        public PartnerRegistrationApplicationService(IUserContext userContext, IPartnerRegistrationRepository partnerRegistrationRepository, ISubscriptionRepository subscriptionRepository, ICommonRepository commonRepository, IPartnerApplicationService partnerApplicationService, IPartnerRepository partnerRepository, IUserRepository userRepository, IUserRoleRepository userRoleRepository, IUserApplicationService UserApplicationService)
        {
            _partnerRepository = partnerRepository;
            _partnerApplicationService = partnerApplicationService;
            _partnerRegistrationRepository = partnerRegistrationRepository;
            _subscriptionRepository = subscriptionRepository;
            _commonRepository = commonRepository;
            _userRepository = userRepository;
            UserContext = userContext;
            _userRoleRepository = userRoleRepository;
            _UserApplicationService = UserApplicationService;
        }

        //TODO: All db calls to be written in Repository Layer


        public List<PartnerTypeDTO> GetPartnerTypes()
        {
            return _commonRepository.GetPartnerTypes().Where(t => t.PartnerTypeId != UAMGlobalConstants.ConsortiumPartner).ToList();
        }

        public List<CountryDTO> GetCountries()
        {
            return _commonRepository.GetCountries();
        }

        public List<string> GetStatuses()
        {
            return _commonRepository.GetStatusEnum();
        }

        public List<string> GetYears()
        {
            return _commonRepository.GetYearsEnum();
        }

        public List<string> GetDocumentTypes()
        {
            return _commonRepository.GetDocumentTypesEnum();
        }

        public List<string> GetDocumentTypesByPartnerType(string partnerType)
        {
            return _commonRepository.GetDocumentTypesByPartnerType(partnerType);
        }

        public List<PartnerRegistrationDocsDTO> GetDocumentTypesByPartnerTypeWithDoc(string partnerType)
        {
            List<string> docList = _commonRepository.GetDocumentTypesByPartnerType(partnerType);
            List<PartnerRegistrationDocsDTO> DocumentDTOs = new List<PartnerRegistrationDocsDTO>();
            foreach (string doc in docList)
            {
                PartnerRegistrationDocsDTO partnerRegistrationDocsDTO = new PartnerRegistrationDocsDTO();
                partnerRegistrationDocsDTO.DocumentType = doc;
                DocumentDTOs.Add(partnerRegistrationDocsDTO);
            }
            return DocumentDTOs.OrderBy(d => d.DocumentType).ToList();
        }

        public void AddPartner(PartnerRegistrationDTO partnerRegistrationDTO)
        {

            if (_partnerRepository.GetPartnerByPartnerTypeandpartnerCode(partnerRegistrationDTO.PartnerType, partnerRegistrationDTO.PartnerRegistrationId) == null)
            {
                List<string> partnertypearr = new List<string>();
                List<string> partnerportarr = new List<string>();
                partnertypearr.Add(partnerRegistrationDTO.PartnerType);
                partnerportarr.Add(UAMGlobalConstants.PortCode);
                PartnerDTO partnerDTO = new PartnerDTO();
                partnerDTO.PartnerName = partnerRegistrationDTO.PartnerName;
                partnerDTO.PartnerType = "";
                partnerDTO.RecordStatus = UAMGlobalConstants.RecordStatus;
                partnerDTO.PartnerCode = partnerRegistrationDTO.PartnerRegistrationId;
                partnerDTO.PartnerTypeArray = partnertypearr;
                partnerDTO.PartnerPortArray = partnerportarr;

                partnerDTO.CreatedBy = _userRepository.GetUserByUserName(partnerRegistrationDTO.CreatedBy).UserId;
                partnerDTO.CreatedOn = DateTime.Now;
                partnerDTO.UpdatedBy = _userRepository.GetUserByUserName(partnerRegistrationDTO.CreatedBy).UserId;
                partnerDTO.UpdatedOn = DateTime.Now;
                AddressDTO partneradd = new AddressDTO();
                partneradd.AreaName = partnerRegistrationDTO.PartnerRegistrationAddress.AreaName;
                partneradd.ContactNumber = partnerRegistrationDTO.PartnerRegistrationAddress.MobileNumber;
                partneradd.Country = partnerRegistrationDTO.PartnerRegistrationAddress.Country;
                partneradd.EmailId = partnerRegistrationDTO.PartnerRegistrationAddress.Email;
                partneradd.HouseNumber = partnerRegistrationDTO.PartnerRegistrationAddress.HouseNumber;
                partneradd.LogoFileName = partnerRegistrationDTO.PartnerRegistrationAddress.LogoFileName;
                partneradd.LogoPath = partnerRegistrationDTO.PartnerRegistrationAddress.LogoPath;
                partneradd.State = partnerRegistrationDTO.PartnerRegistrationAddress.State;
                partneradd.StreetName = partnerRegistrationDTO.PartnerRegistrationAddress.StreetName;
                partneradd.TownOrCity = partnerRegistrationDTO.PartnerRegistrationAddress.TownOrCity;
                partneradd.WebSite = "";
                partneradd.ZipCode = partnerRegistrationDTO.PartnerRegistrationAddress.ZipCode;


                partnerDTO.PartnerAddress = partneradd;
                _partnerApplicationService.AddPartner(partnerDTO);
                List<string> UsrRoleArry = new List<string>();

                UsrRoleArry.Add(ConfigurationManager.AppSettings["AgentRoleID"]);
                Domain.DTOS.UserPreferenceDTO usrpreferenceDTO = new Domain.DTOS.UserPreferenceDTO();
                usrpreferenceDTO.SendNotificationEmail = "N";
                usrpreferenceDTO.SendNotificationSms = "N";
                usrpreferenceDTO.SendSystemNotification = "N";
                ContextDTO contxtDto = new ContextDTO();
                contxtDto.ApplicationId = 6;
                contxtDto.SubscriberId = UAMGlobalConstants.SubscriberId;
                contxtDto.UserId = _userRepository.GetUserByUserName(partnerRegistrationDTO.CreatedBy).UserId;// "b8d4d782-ec73-4c93-8b0c-b2989b2825b7";
                contxtDto.UserName = _userRepository.GetUserByUserName(partnerRegistrationDTO.CreatedBy).UserName;
                UserDTO usrDTO = new UserDTO();
                usrDTO.UserName = partnerRegistrationDTO.RequisitionNo;
                usrDTO.ContactNumber = partnerRegistrationDTO.FinanceMobile;
                usrDTO.EmailId = partnerRegistrationDTO.FinanceEmail;
                usrDTO.InCorrectLogins = 0;
                usrDTO.UserPortArray = partnerportarr;
                usrDTO.UserRoleArray = UsrRoleArry;
                usrDTO.PartnerId = _partnerRepository.GetPartnerByPartnerTypeandpartnerCode(partnerRegistrationDTO.PartnerType, partnerRegistrationDTO.PartnerRegistrationId).PartnerId;
                usrDTO.PartnerType = partnerRegistrationDTO.PartnerType;

                usrDTO.InCorrectLogins = 0;
                usrDTO.IsDeleted = UAMGlobalConstants.IsDeletedNo;
                usrDTO.LastName = "";
                usrDTO.FirstName = partnerRegistrationDTO.PartnerName;
                usrDTO.RecordStatus = UAMGlobalConstants.RecordStatus;
                usrDTO.UserPreference = usrpreferenceDTO;

                _UserApplicationService.AddUser(usrDTO, contxtDto);

            }



            else
            {
                List<string> partnertypearr = new List<string>();
                List<string> partnerportarr = new List<string>();
                partnertypearr.Add(partnerRegistrationDTO.PartnerType);
                partnerportarr.Add(UAMGlobalConstants.PortCode);
                PartnerDTO partnerDTO = new PartnerDTO();
                partnerDTO.PartnerId = _partnerRepository.GetPartnerByPartnerTypeandpartnerCode(partnerRegistrationDTO.PartnerType, partnerRegistrationDTO.PartnerRegistrationId).PartnerId;

                partnerDTO.PartnerName = _partnerRepository.GetPartnerByPartnerTypeandpartnerCode(partnerRegistrationDTO.PartnerType, partnerRegistrationDTO.PartnerRegistrationId).PartnerName;
                partnerDTO.PartnerType = "";
                partnerDTO.RecordStatus = UAMGlobalConstants.RecordStatus;
                partnerDTO.PartnerCode = partnerRegistrationDTO.PartnerRegistrationId;
                partnerDTO.PartnerTypeArray = partnertypearr;
                partnerDTO.PartnerPortArray = partnerportarr;

                partnerDTO.CreatedBy = _userRepository.GetUserByUserName(partnerRegistrationDTO.CreatedBy).UserId;
                //partnerDTO.CreatedOn = DateTime.Now;
                partnerDTO.UpdatedBy = _userRepository.GetUserByUserName(partnerRegistrationDTO.CreatedBy).UserId;
                partnerDTO.UpdatedOn = DateTime.Now;
                AddressDTO partneradd = new AddressDTO();
                partneradd.AreaName = partnerRegistrationDTO.PartnerRegistrationAddress.AreaName;
                partneradd.ContactNumber = partnerRegistrationDTO.PartnerRegistrationAddress.MobileNumber;
                partneradd.Country = partnerRegistrationDTO.PartnerRegistrationAddress.Country;
                partneradd.EmailId = partnerRegistrationDTO.PartnerRegistrationAddress.Email;
                partneradd.HouseNumber = partnerRegistrationDTO.PartnerRegistrationAddress.HouseNumber;
                partneradd.LogoFileName = partnerRegistrationDTO.PartnerRegistrationAddress.LogoFileName;
                partneradd.LogoPath = partnerRegistrationDTO.PartnerRegistrationAddress.LogoPath;
                partneradd.State = partnerRegistrationDTO.PartnerRegistrationAddress.State;
                partneradd.StreetName = partnerRegistrationDTO.PartnerRegistrationAddress.StreetName;
                partneradd.TownOrCity = partnerRegistrationDTO.PartnerRegistrationAddress.TownOrCity;
                partneradd.WebSite = "";
                partneradd.ZipCode = partnerRegistrationDTO.PartnerRegistrationAddress.ZipCode;


                partnerDTO.PartnerAddress = partneradd;
                _partnerApplicationService.UpdatePartner(partnerDTO);
                List<string> UsrRoleArry = new List<string>();

                UsrRoleArry.Add(ConfigurationManager.AppSettings["AgentRoleID"]);
                Domain.DTOS.UserPreferenceDTO usrpreferenceDTO = new Domain.DTOS.UserPreferenceDTO();
                usrpreferenceDTO.SendNotificationEmail = "N";
                usrpreferenceDTO.SendNotificationSms = "N";
                usrpreferenceDTO.SendSystemNotification = "N";
                ContextDTO contxtDto = new ContextDTO();
                contxtDto.ApplicationId = 6;
                contxtDto.SubscriberId = UAMGlobalConstants.SubscriberId;
                contxtDto.UserId = _userRepository.GetUserByUserName(partnerRegistrationDTO.CreatedBy).UserId;// "b8d4d782-ec73-4c93-8b0c-b2989b2825b7";
                contxtDto.UserName = _userRepository.GetUserByUserName(partnerRegistrationDTO.CreatedBy).UserName;
                UserDTO usrDTO = new UserDTO();
                // usrDTO.UserId = _userRepository.GetUserByUserName(partnerRegistrationDTO.RequisitionNo).UserId;
                usrDTO.UserId = _userRepository.GetUserByPartnerid((_partnerRepository.GetPartnerByPartnerTypeandpartnerCode(partnerRegistrationDTO.PartnerType, partnerRegistrationDTO.PartnerRegistrationId).PartnerId)).UserId;
                
                usrDTO.UserName = partnerRegistrationDTO.RequisitionNo;
                usrDTO.ContactNumber = partnerRegistrationDTO.FinanceMobile;
                usrDTO.EmailId = partnerRegistrationDTO.FinanceEmail;
                usrDTO.InCorrectLogins = 0;
                usrDTO.UserPortArray = partnerportarr;
                usrDTO.UserRoleArray = UsrRoleArry;
                usrDTO.PartnerId = _partnerRepository.GetPartnerByPartnerTypeandpartnerCode(partnerRegistrationDTO.PartnerType, partnerRegistrationDTO.PartnerRegistrationId).PartnerId;
                usrDTO.PartnerType = partnerRegistrationDTO.PartnerType;

                usrDTO.InCorrectLogins = 0;
                usrDTO.IsDeleted = UAMGlobalConstants.IsDeletedNo;
                usrDTO.LastName = "";
                usrDTO.FirstName = partnerRegistrationDTO.PartnerName;
                usrDTO.RecordStatus = UAMGlobalConstants.RecordStatus;
                usrDTO.DormantStatus = _userRepository.GetUserByPartnerid((_partnerRepository.GetPartnerByPartnerTypeandpartnerCode(partnerRegistrationDTO.PartnerType, partnerRegistrationDTO.PartnerRegistrationId).PartnerId)).DormantStatus;
                usrDTO.UserPreference = usrpreferenceDTO;

                _UserApplicationService.UpdateUser(usrDTO, contxtDto);

            }

        }

        public void AddPartnerRegistration(PartnerRegistrationDTO partnerRegistrationDTO)
        {
            EncloseTransactionAndHandleExceptionWithoutToken(() =>
            {
                //List<PartnerListDTO> partnersListDtos = _partnerRepository.GetPartners(ApplicationContextDTO.SubscriberId, ApplicationContextDTO.ApplicationId, UAMGlobalConstants.NotApplicable, UAMGlobalConstants.NotApplicable, UAMGlobalConstants.NotApplicable, UAMGlobalConstants.NotApplicable);
                //PartnerRegistration partnerDataByCode = _partnerRepository.GetPartnerByPartnerCode(partnersListDtos, partnerRegistrationDTO.PartnerCode);
                PartnerRegistrationAddress address = new PartnerRegistrationAddress();
                if (partnerRegistrationDTO.PartnerRegistrationAddress != null)
                {
                    address = new PartnerRegistrationAddress(partnerRegistrationDTO.PartnerRegistrationAddress.HouseNumber, partnerRegistrationDTO.PartnerRegistrationAddress.StreetName, partnerRegistrationDTO.PartnerRegistrationAddress.AreaName, partnerRegistrationDTO.PartnerRegistrationAddress.TownOrCity, partnerRegistrationDTO.PartnerRegistrationAddress.State, partnerRegistrationDTO.PartnerRegistrationAddress.Country, partnerRegistrationDTO.PartnerRegistrationAddress.ZipCode, partnerRegistrationDTO.PartnerRegistrationAddress.LogoFileName, partnerRegistrationDTO.PartnerRegistrationAddress.LogoPath, partnerRegistrationDTO.PartnerRegistrationAddress.Email, partnerRegistrationDTO.PartnerRegistrationAddress.MobileNumber);
                }
                partnerRegistrationDTO.PartnerName = partnerRegistrationDTO.PartnerName.Trim();
                partnerRegistrationDTO.PartnerRegistrationId = Guid.NewGuid().ToString();
                partnerRegistrationDTO.RequisitionNo = _partnerRegistrationRepository.GenerateRequisitionNo();
                partnerRegistrationDTO.RecordStatus = UAMGlobalConstants.RecordStatus;
                partnerRegistrationDTO.WFStatus = UAMGlobalConstants.StatusNew;
                partnerRegistrationDTO.CreatedBy = UAMGlobalConstants.Anonymous;
                partnerRegistrationDTO.CreatedOn = DateTime.Now;
                partnerRegistrationDTO.UpdatedBy = UAMGlobalConstants.Anonymous;
                partnerRegistrationDTO.UpdatedOn = DateTime.Now;
                if (!string.IsNullOrEmpty(partnerRegistrationDTO.IsAccept))
                {
                    if (partnerRegistrationDTO.IsAccept.Trim() == "true" || partnerRegistrationDTO.IsAccept.Trim() == "True")
                    {
                        partnerRegistrationDTO.IsAccept = UAMGlobalConstants.Yes;
                    }
                    else
                    {
                        partnerRegistrationDTO.IsAccept = UAMGlobalConstants.Yes;
                    }
                }
                else
                {
                    partnerRegistrationDTO.IsAccept = UAMGlobalConstants.Yes;
                }

                PartnerRegistration partnerRegistration = new PartnerRegistration(partnerRegistrationDTO.PartnerRegistrationId, partnerRegistrationDTO.RequisitionNo, partnerRegistrationDTO.PartnerType, partnerRegistrationDTO.PartnerName, address, partnerRegistrationDTO.CIN, partnerRegistrationDTO.PAN, partnerRegistrationDTO.TAN, partnerRegistrationDTO.NatureOfBusiness, partnerRegistrationDTO.Year, partnerRegistrationDTO.Status, partnerRegistrationDTO.RegistrationNo,
                    partnerRegistrationDTO.Place, partnerRegistrationDTO.VAT, partnerRegistrationDTO.BankName, partnerRegistrationDTO.BankAddress, partnerRegistrationDTO.AccountNo, partnerRegistrationDTO.IFSCCode, partnerRegistrationDTO.FinanceName, partnerRegistrationDTO.FinanceEmail, partnerRegistrationDTO.FinanceMobile, partnerRegistrationDTO.OperationsName, partnerRegistrationDTO.OperationsEmail, partnerRegistrationDTO.OperationsMobile, partnerRegistrationDTO.ITName, partnerRegistrationDTO.ITEmail, partnerRegistrationDTO.ITMobile, partnerRegistrationDTO.RecordStatus, partnerRegistrationDTO.CreatedBy, partnerRegistrationDTO.CreatedOn, partnerRegistrationDTO.UpdatedBy, partnerRegistrationDTO.UpdatedOn, partnerRegistrationDTO.WFStatus, partnerRegistrationDTO.IsAccept);
                UserDTO userDTO = new UserDTO();

                if (partnerRegistrationDTO.PartnerDirectorDetailss.Any())
                {
                    foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerDirectorDetailss)
                    {
                        partnerRegistration.AddDirector(partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type);
                    }
                }
                if (partnerRegistrationDTO.PartnerOperationsDetailss.Any())
                {
                    foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerOperationsDetailss)
                    {
                        partnerRegistration.AddDirector(partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type);
                    }
                }
                if (partnerRegistrationDTO.PartnerITDetailss.Any())
                {
                    foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerITDetailss)
                    {
                        partnerRegistration.AddDirector(partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type);
                    }
                }
                if (partnerRegistrationDTO.PartnerFinanceDetailss.Any())
                {
                    foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerFinanceDetailss)
                    {
                        partnerRegistration.AddDirector(partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type);
                    }
                }
                if (partnerRegistrationDTO.PartnerSalesDetailss.Any())
                {
                    foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerSalesDetailss)
                    {
                        partnerRegistration.AddDirector(partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type);
                    }
                }
                if (partnerRegistrationDTO.DocumentDTOs.Any())
                {
                    foreach (PartnerRegistrationDocsDTO doc in partnerRegistrationDTO.DocumentDTOs)
                    {
                        if (!string.IsNullOrEmpty(doc.OriginalName))
                            partnerRegistration.AddDocumentType(doc.FileName, doc.OriginalName, doc.DocumentType, doc.ValidTill, doc.IsDeleted);
                        else if (doc.IsDeleted == UAMGlobalConstants.IsDeletedYes)
                            partnerRegistration.AddDocumentType(doc.FileName, doc.OriginalName, doc.DocumentType, doc.ValidTill, doc.IsDeleted);
                    }
                }

                _partnerRegistrationRepository.AddOrUpdatePartnerRegistration(partnerRegistration);

                userDTO.UserId = partnerRegistrationDTO.PartnerRegistrationId;
                userDTO.UserName = partnerRegistrationDTO.PartnerName;
                userDTO.PartnerId = partnerRegistrationDTO.PartnerRegistrationId;
                userDTO.EmailId = partnerRegistrationDTO.PartnerRegistrationAddress.Email;
                userDTO.ReqNo = partnerRegistrationDTO.RequisitionNo;

                SendNotification(UAMGlobalConstants.ApplicationId,
                    UAMGlobalConstants.SubscriberId,
                    partnerRegistrationDTO.PartnerRegistrationId,
                    AppEntityIds.eGatePartner.ToString(),
                    UserFunctionCodes.eGatePartnerRegistration.ToString(),
                    partnerRegistrationDTO.PartnerRegistrationId,
                    string.Empty,
                    userDTO.UserId,
                    userDTO);

                SendNotification(UAMGlobalConstants.ApplicationId,
                    UAMGlobalConstants.SubscriberId,
                    UAMGlobalConstants.SubscriberId,
                    AppEntityIds.eGatePartner.ToString(),
                    UserFunctionCodes.eGatePartnerRegistrationAcc.ToString(),
                    partnerRegistrationDTO.PartnerRegistrationId,
                    string.Empty,
                    userDTO.UserId,
                    userDTO);
            });
        }

        public void UpdatePartnerRegistration(PartnerRegistrationDTO partnerRegistrationDTO)
        {
            EncloseTransactionAndHandleExceptionWithoutToken(() =>
            {
                PartnerRegistration partnerRegistration = _partnerRegistrationRepository.GetPartnerRegistrationByPartnerId(partnerRegistrationDTO.RequisitionNo);

                #region Update Partner Registration
                string prevWFStatus = partnerRegistration.WFStatus;

                partnerRegistration.PartnerRegistrationAddress.UpdatePartnerRegistrationAddress(partnerRegistrationDTO.PartnerRegistrationAddress.HouseNumber, partnerRegistrationDTO.PartnerRegistrationAddress.StreetName, partnerRegistrationDTO.PartnerRegistrationAddress.AreaName, partnerRegistrationDTO.PartnerRegistrationAddress.TownOrCity, partnerRegistrationDTO.PartnerRegistrationAddress.State, partnerRegistrationDTO.PartnerRegistrationAddress.Country, partnerRegistrationDTO.PartnerRegistrationAddress.ZipCode, partnerRegistrationDTO.PartnerRegistrationAddress.LogoFileName, partnerRegistrationDTO.PartnerRegistrationAddress.LogoPath, partnerRegistrationDTO.PartnerRegistrationAddress.Email, partnerRegistrationDTO.PartnerRegistrationAddress.MobileNumber);

                partnerRegistrationDTO.PartnerName = partnerRegistrationDTO.PartnerName.Trim();

                partnerRegistrationDTO.UpdatedBy = UAMGlobalConstants.Anonymous;

                partnerRegistrationDTO.UpdatedOn = DateTime.Now;

                partnerRegistrationDTO.IsAccept = UAMGlobalConstants.Yes;

                partnerRegistration.UpdatePartnerRegistration(partnerRegistrationDTO.PartnerName, partnerRegistrationDTO.CIN, partnerRegistrationDTO.PAN, partnerRegistrationDTO.TAN, partnerRegistrationDTO.NatureOfBusiness, partnerRegistrationDTO.Year, partnerRegistrationDTO.Status, partnerRegistrationDTO.RegistrationNo,
                    partnerRegistrationDTO.Place, partnerRegistrationDTO.VAT, partnerRegistrationDTO.BankName, partnerRegistrationDTO.BankAddress, partnerRegistrationDTO.AccountNo, partnerRegistrationDTO.IFSCCode, partnerRegistrationDTO.FinanceName, partnerRegistrationDTO.FinanceEmail, partnerRegistrationDTO.FinanceMobile, partnerRegistrationDTO.OperationsName, partnerRegistrationDTO.OperationsEmail, partnerRegistrationDTO.OperationsMobile, partnerRegistrationDTO.ITName, partnerRegistrationDTO.ITEmail, partnerRegistrationDTO.ITMobile, UAMGlobalConstants.RecordStatus, partnerRegistrationDTO.CreatedBy, partnerRegistrationDTO.CreatedOn, partnerRegistrationDTO.UpdatedBy, partnerRegistrationDTO.UpdatedOn, partnerRegistrationDTO.IsAccept);

                UserDTO userDTO = new UserDTO(); //Used for Notification

                if (partnerRegistrationDTO.PartnerDirectorDetailss.Any())
                {
                    foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerDirectorDetailss)
                    {
                        partnerRegistration.UpdateDirector(partner.PDirectorDetailsId, partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type, partner.IsDeleted);
                    }
                }

                if (partnerRegistrationDTO.PartnerOperationsDetailss.Any())
                {
                    foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerOperationsDetailss)
                    {
                        partnerRegistration.UpdateDirector(partner.PDirectorDetailsId, partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type, partner.IsDeleted);
                    }
                }
                if (partnerRegistrationDTO.PartnerITDetailss.Any())
                {
                    foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerITDetailss)
                    {
                        partnerRegistration.UpdateDirector(partner.PDirectorDetailsId, partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type, partner.IsDeleted);
                    }
                }
                if (partnerRegistrationDTO.PartnerFinanceDetailss.Any())
                {
                    foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerFinanceDetailss)
                    {
                        partnerRegistration.UpdateDirector(partner.PDirectorDetailsId, partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type, partner.IsDeleted);
                    }
                }
                if (partnerRegistrationDTO.PartnerSalesDetailss.Any())
                {
                    foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerSalesDetailss)
                    {
                        partnerRegistration.UpdateDirector(partner.PDirectorDetailsId, partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type, partner.IsDeleted);
                    }
                }
                if (partnerRegistrationDTO.DocumentDTOs.Any())
                {
                    foreach (PartnerRegistrationDocsDTO doc in partnerRegistrationDTO.DocumentDTOs)
                    {
                        if (!string.IsNullOrEmpty(doc.OriginalName))
                            partnerRegistration.AddDocumentType(doc.FileName, doc.OriginalName, doc.DocumentType, doc.ValidTill, doc.IsDeleted);
                        else if (doc.IsDeleted == UAMGlobalConstants.IsDeletedYes)
                            partnerRegistration.AddDocumentType(doc.FileName, doc.OriginalName, doc.DocumentType, doc.ValidTill, doc.IsDeleted);
                    }
                }

                _partnerRegistrationRepository.AddOrUpdatePartnerRegistration(partnerRegistration);
                #endregion

                userDTO.UserId = partnerRegistration.PartnerRegistrationId;
                userDTO.UserName = partnerRegistration.PartnerName;
                userDTO.PartnerId = partnerRegistration.PartnerRegistrationId;
                userDTO.EmailId = partnerRegistration.PartnerRegistrationAddress.Email;
                userDTO.ReqNo = partnerRegistration.RequisitionNo;

                if (prevWFStatus == UAMGlobalConstants.StatusNew)
                {
                    SendNotification(UAMGlobalConstants.ApplicationId,
                        UAMGlobalConstants.SubscriberId,
                        partnerRegistration.PartnerRegistrationId,
                        AppEntityIds.eGatePartner.ToString(),
                        UserFunctionCodes.eGateUpdatePartnerRegistration.ToString(),
                        partnerRegistration.PartnerRegistrationId,
                        string.Empty,
                        userDTO.UserId,
                        userDTO);

                    SendNotification(UAMGlobalConstants.ApplicationId,
                        UAMGlobalConstants.SubscriberId,
                        UAMGlobalConstants.SubscriberId,
                        AppEntityIds.eGatePartner.ToString(),
                        UserFunctionCodes.eGateUpdatePartnerRegistrationACC.ToString(),
                        partnerRegistration.PartnerRegistrationId,
                        string.Empty,
                        userDTO.UserId,
                        userDTO);

                }
                else if (prevWFStatus == UAMGlobalConstants.StatusRejectedVer ||
                         prevWFStatus == UAMGlobalConstants.StatusRejected)
                {
                    SendNotification(UAMGlobalConstants.ApplicationId,
                        UAMGlobalConstants.SubscriberId,
                        partnerRegistration.PartnerRegistrationId,
                        AppEntityIds.eGatePartner.ToString(),
                        UserFunctionCodes.eGateReSubmitPartnerVerification.ToString(),
                        partnerRegistration.PartnerRegistrationId,
                        string.Empty,
                        userDTO.UserId,
                        userDTO);

                    SendNotification(UAMGlobalConstants.ApplicationId,
                        UAMGlobalConstants.SubscriberId,
                        UAMGlobalConstants.SubscriberId,
                        AppEntityIds.eGatePartner.ToString(),
                        UserFunctionCodes.eGateReSubmitPartnerVerificationACC.ToString(),
                        partnerRegistration.PartnerRegistrationId,
                        string.Empty,
                        userDTO.UserId,
                        userDTO);
                }
                
            });

        }

        public void UpdatePartnerRegistrationOnly(PartnerRegistrationDTO partnerRegistrationDTO)
        {
            EncloseTransactionAndHandleException(() =>
            {
                PartnerRegistration partnerRegistration = _partnerRegistrationRepository.GetPartnerRegistrationByPartnerId(partnerRegistrationDTO.RequisitionNo);

                #region Update Partner Registration
                string prevWFStatus = partnerRegistration.WFStatus;

                partnerRegistration.PartnerRegistrationAddress.UpdatePartnerRegistrationAddress(partnerRegistrationDTO.PartnerRegistrationAddress.HouseNumber, partnerRegistrationDTO.PartnerRegistrationAddress.StreetName, partnerRegistrationDTO.PartnerRegistrationAddress.AreaName, partnerRegistrationDTO.PartnerRegistrationAddress.TownOrCity, partnerRegistrationDTO.PartnerRegistrationAddress.State, partnerRegistrationDTO.PartnerRegistrationAddress.Country, partnerRegistrationDTO.PartnerRegistrationAddress.ZipCode, partnerRegistrationDTO.PartnerRegistrationAddress.LogoFileName, partnerRegistrationDTO.PartnerRegistrationAddress.LogoPath, partnerRegistrationDTO.PartnerRegistrationAddress.Email, partnerRegistrationDTO.PartnerRegistrationAddress.MobileNumber);

                partnerRegistrationDTO.PartnerName = partnerRegistrationDTO.PartnerName.Trim();

                partnerRegistrationDTO.UpdatedBy = UAMGlobalConstants.Anonymous;

                partnerRegistrationDTO.UpdatedOn = DateTime.Now;

                partnerRegistrationDTO.IsAccept = UAMGlobalConstants.Yes;

                partnerRegistration.UpdatePartnerRegistrationDetails(partnerRegistrationDTO.PartnerName, partnerRegistrationDTO.CIN, partnerRegistrationDTO.PAN, partnerRegistrationDTO.TAN, partnerRegistrationDTO.NatureOfBusiness, partnerRegistrationDTO.Year, partnerRegistrationDTO.Status, partnerRegistrationDTO.RegistrationNo,
                    partnerRegistrationDTO.Place, partnerRegistrationDTO.VAT, partnerRegistrationDTO.BankName, partnerRegistrationDTO.BankAddress, partnerRegistrationDTO.AccountNo, partnerRegistrationDTO.IFSCCode, partnerRegistrationDTO.FinanceName, partnerRegistrationDTO.FinanceEmail, partnerRegistrationDTO.FinanceMobile, partnerRegistrationDTO.OperationsName, partnerRegistrationDTO.OperationsEmail, partnerRegistrationDTO.OperationsMobile, partnerRegistrationDTO.ITName, partnerRegistrationDTO.ITEmail, partnerRegistrationDTO.ITMobile, UAMGlobalConstants.RecordStatus, partnerRegistrationDTO.CreatedBy, partnerRegistrationDTO.CreatedOn, partnerRegistrationDTO.UpdatedBy, partnerRegistrationDTO.UpdatedOn, partnerRegistrationDTO.IsAccept);

                

                if (partnerRegistrationDTO.PartnerDirectorDetailss.Any())
                {
                    foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerDirectorDetailss)
                    {
                        partnerRegistration.UpdateDirector(partner.PDirectorDetailsId, partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type, partner.IsDeleted);
                    }
                }

                if (partnerRegistrationDTO.PartnerOperationsDetailss.Any())
                {
                    foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerOperationsDetailss)
                    {
                        partnerRegistration.UpdateDirector(partner.PDirectorDetailsId, partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type, partner.IsDeleted);
                    }
                }
                if (partnerRegistrationDTO.PartnerITDetailss.Any())
                {
                    foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerITDetailss)
                    {
                        partnerRegistration.UpdateDirector(partner.PDirectorDetailsId, partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type, partner.IsDeleted);
                    }
                }
                if (partnerRegistrationDTO.PartnerFinanceDetailss.Any())
                {
                    foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerFinanceDetailss)
                    {
                        partnerRegistration.UpdateDirector(partner.PDirectorDetailsId, partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type, partner.IsDeleted);
                    }
                }
                if (partnerRegistrationDTO.PartnerSalesDetailss.Any())
                {
                    foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerSalesDetailss)
                    {
                        partnerRegistration.UpdateDirector(partner.PDirectorDetailsId, partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type, partner.IsDeleted);
                    }
                }
                if (partnerRegistrationDTO.DocumentDTOs.Any())
                {
                    foreach (PartnerRegistrationDocsDTO doc in partnerRegistrationDTO.DocumentDTOs)
                    {
                        if (!string.IsNullOrEmpty(doc.OriginalName))
                            partnerRegistration.AddDocumentType(doc.FileName, doc.OriginalName, doc.DocumentType, doc.ValidTill, doc.IsDeleted);
                        else if (doc.IsDeleted == UAMGlobalConstants.IsDeletedYes)
                            partnerRegistration.AddDocumentType(doc.FileName, doc.OriginalName, doc.DocumentType, doc.ValidTill, doc.IsDeleted);
                    }
                }

                _partnerRegistrationRepository.AddOrUpdatePartnerRegistration(partnerRegistration);
                #endregion

                UserDTO userDTO = new UserDTO(); 
                userDTO.UserId = partnerRegistration.PartnerRegistrationId;
                userDTO.UserName = partnerRegistration.PartnerName;
                userDTO.UpdatedByUserName = ApplicationContextDTO.UserName;
                userDTO.PartnerId = partnerRegistration.PartnerRegistrationId;
                userDTO.EmailId = partnerRegistration.PartnerRegistrationAddress.Email;
                userDTO.ReqNo = partnerRegistration.RequisitionNo;


                SendNotification(UAMGlobalConstants.ApplicationId,
                    UAMGlobalConstants.SubscriberId,
                    partnerRegistration.PartnerRegistrationId,
                    AppEntityIds.eGatePartner.ToString(),
                    UserFunctionCodes.eGateUpdatePartnerRegUser.ToString(),
                    partnerRegistration.PartnerRegistrationId,
                    string.Empty,
                    userDTO.UserId,
                    userDTO);

                SendNotification(UAMGlobalConstants.ApplicationId,
                    UAMGlobalConstants.SubscriberId,
                    UAMGlobalConstants.SubscriberId,
                    AppEntityIds.eGatePartner.ToString(),
                    UserFunctionCodes.eGateUpdatePartnerRegACC.ToString(),
                    partnerRegistration.PartnerRegistrationId,
                    string.Empty,
                    userDTO.UserId,
                    userDTO);

                SendNotification(UAMGlobalConstants.ApplicationId,
                    UAMGlobalConstants.SubscriberId,
                    UAMGlobalConstants.SubscriberId,
                    AppEntityIds.eGatePartner.ToString(),
                    UserFunctionCodes.eGateUpdatePartnerRegTO.ToString(),
                    partnerRegistration.PartnerRegistrationId,
                    string.Empty,
                    userDTO.UserId,
                    userDTO);

                

            });
        }

        public PartnerRegistrationDTO GetPartnerRegistration(string requisitionNo, string emailId, string mobNo)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                PartnerRegistration partner = _partnerRegistrationRepository.GetPartnerRegistration(requisitionNo, emailId, mobNo);
                PartnerRegistrationDTO partnerDto = null;
                if (partner != null)
                    partnerDto = partner.MapToDto();

                return partnerDto;
            });
        }

        public void ApprovePartnerRegistration(PartnerRegistrationListDTO partnerRegistrationDTO)
        {
            EncloseTransactionAndHandleException(() =>
            {
                #region Partner Registration Approval
                PartnerRegistration partnerRegistration = _partnerRegistrationRepository.GetPartnerRegistrationByPartnerId(partnerRegistrationDTO.RequisitionNo);
                AssertionConcern.AssertArgumentTrue(partnerRegistration.WFStatus == UAMGlobalConstants.StatusVerified, "KYC not valid for Approval");
                partnerRegistration.ApprovePartnerRegistration();
                _partnerRegistrationRepository.AddOrUpdatePartnerRegistration(partnerRegistration);
                #endregion

                #region Partner Creation
                AddressDTO addressdto = new AddressDTO();
                if (partnerRegistration.PartnerRegistrationAddress != null)
                {
                    addressdto = new AddressDTO(partnerRegistration.PartnerRegistrationAddress.HouseNumber, partnerRegistration.PartnerRegistrationAddress.StreetName,
                        partnerRegistration.PartnerRegistrationAddress.AreaName, partnerRegistration.PartnerRegistrationAddress.TownOrCity,
                        partnerRegistration.PartnerRegistrationAddress.State, partnerRegistration.PartnerRegistrationAddress.Country, partnerRegistration.PartnerRegistrationAddress.ZipCode,
                        partnerRegistration.PartnerRegistrationAddress.MobileNumber, partnerRegistration.PartnerRegistrationAddress.Email, string.Empty,
                        partnerRegistration.PartnerRegistrationAddress.LogoFileName, partnerRegistration.PartnerRegistrationAddress.Logopath);
                }
                List<string> portArray = new List<string>() { UAMGlobalConstants.PortCode };
                List<string> partnerTypeArray = new List<string>();
                partnerTypeArray.Add(partnerRegistration.PartnerType);
                PartnerDTO partnerDTO = new PartnerDTO(partnerRegistration.PartnerName, partnerRegistration.PartnerType, partnerRegistrationDTO.PartnerCode, addressdto, partnerTypeArray, portArray);



                Address address = new Address(partnerDTO.PartnerAddress.HouseNumber, partnerDTO.PartnerAddress.StreetName, partnerDTO.PartnerAddress.AreaName, partnerDTO.PartnerAddress.TownOrCity, partnerDTO.PartnerAddress.State, partnerDTO.PartnerAddress.Country, partnerDTO.PartnerAddress.ZipCode, partnerDTO.PartnerAddress.ContactNumber, partnerDTO.PartnerAddress.EmailId, partnerDTO.PartnerAddress.WebSite, partnerDTO.PartnerAddress.LogoFileName, partnerDTO.PartnerAddress.LogoPath);
                partnerDTO.PartnerId = Guid.NewGuid().ToString();
                partnerDTO.CreatedBy = partnerDTO.PartnerId;
                partnerDTO.CreatedOn = DateTime.Now;
                partnerDTO.UpdatedBy = partnerDTO.PartnerId;
                partnerDTO.UpdatedOn = DateTime.Now;
                if (partnerDTO.PartnerTypeArray != null)
                {
                    List<string> partnerTypes = new List<string>();
                    foreach (string partnerTypeName in partnerDTO.PartnerTypeArray)
                    {
                        partnerTypes.Add(partnerTypeName);

                    }

                    foreach (string partnerTypeName in partnerTypes)
                    {
                        if (partnerTypeName == UAMGlobalConstants.VesselOperatingAgent)
                        {
                            partnerDTO.PartnerTypeArray.Add(UAMGlobalConstants.ConsortiumPartner);

                        }

                    }

                    List<PartnerTypePriorityDTO> prioritylist = new List<PartnerTypePriorityDTO>();
                    foreach (string partnerType in partnerDTO.PartnerTypeArray)
                    {
                        PartnerTypePriorityDTO priorityList = _commonRepository.GetPartnerTypePriority(partnerType);
                        prioritylist.Add(priorityList);

                    }
                    if (prioritylist != null)
                    {
                        List<int> priorityNos = new List<int>();
                        foreach (var poritityNo in prioritylist)
                        {
                            priorityNos.Add(poritityNo.PriorityNo);

                        }
                        priorityNos.Sort();
                        int minpriorityNo = priorityNos[0];
                        partnerDTO.PartnerType = prioritylist.Find(t => t.PriorityNo == minpriorityNo).PartnerTypeCode.ToString();


                    }

                }
                Partner partner = new Partner(partnerDTO.PartnerId, partnerDTO.PartnerName, partnerDTO.PartnerType,
                    partnerDTO.PartnerCode, address, UAMGlobalConstants.RecordStatus, partnerDTO.CreatedBy,
                    partnerDTO.CreatedOn,ApplicationContextDTO.ApplicationId,ApplicationContextDTO.SubscriberId);

                foreach (string portCode in partnerDTO.PartnerPortArray)
                {
                    partner.OperateAtPort(portCode);
                }

                foreach (string partnerType in partnerDTO.PartnerTypeArray)
                {

                    partner.PartnerTypeOperator(partnerType, UAMGlobalConstants.IsDeletedNo,ApplicationContextDTO.SubscriberId);

                }
                _partnerRepository.AddPartner(partner);

                //Subscription subscription = _subscriptionRepository.GetSubscription(ApplicationContextDTO.ApplicationId, ApplicationContextDTO.SubscriberId);
                //subscription.AddMember(partnerDTO.PartnerId, ApplicationContextDTO.UserName);
                //_subscriptionRepository.AddSubscription(subscription);
                #endregion
              
                #region notification to Accounts and TO
                UserDTO userDTOMail = new UserDTO();
                userDTOMail.UserId = partnerRegistration.PartnerRegistrationId;
                userDTOMail.SubscriberId = ApplicationContextDTO.SubscriberId;
                userDTOMail.UserName = ApplicationContextDTO.UserName;// using for Username display in current template
                userDTOMail.PartnerId = partnerRegistration.PartnerRegistrationId;
                userDTOMail.EmailId = partnerRegistration.PartnerRegistrationAddress.Email;
                userDTOMail.ReqNo = partnerRegistration.RequisitionNo;

                SendNotification(ApplicationContextDTO.ApplicationId,
                  ApplicationContextDTO.SubscriberId,
                  ApplicationContextDTO.MemberId,
                  AppEntityIds.eGatePartner.ToString(),
                  UserFunctionCodes.eGatePartnerApprovedTO.ToString(),
                  partnerRegistration.PartnerRegistrationId,
                  string.Empty,
                  ApplicationContextDTO.UserId,
                  userDTOMail);

                SendNotification(ApplicationContextDTO.ApplicationId,
                 ApplicationContextDTO.SubscriberId,
                 ApplicationContextDTO.MemberId,
                 AppEntityIds.eGatePartner.ToString(),
                 UserFunctionCodes.eGatePartnerApprovedACC.ToString(),
                 partnerRegistration.PartnerRegistrationId,
                 string.Empty,
                 ApplicationContextDTO.UserId,
                 userDTOMail);
                #endregion

                #region User Creation for Partner
                UserDTO userDTO = new UserDTO();
                UserPreference userPreference = new UserPreference(UAMGlobalConstants.Yes, UAMGlobalConstants.Yes, UAMGlobalConstants.Yes);
                userDTO.UserId = Guid.NewGuid().ToString();

                string _password = PasswordDataService.Generate();
                userDTO.InCorrectLogins = 0;
                userDTO.IsFirstTimeLogin = UAMGlobalConstants.IsFirstTimeLogin;
                userDTO.validFromDate = DateTime.Now;
                userDTO.validToDate = DateTime.Now.AddDays(UAMGlobalConstants.UserCreationLifeSpan);
                userDTO.PwdExpiryDate = DateTime.Now.AddDays(UAMGlobalConstants.PwdExpiryDays);

                userDTO.UserPortArray = new List<string>();
                userDTO.UserPortArray.Add(ApplicationContextDTO.PortCode);
                userDTO.ApplicationId = ApplicationContextDTO.ApplicationId;
                userDTO.SubscriberId = ApplicationContextDTO.SubscriberId;
                User user = new User(userDTO.UserId, partnerRegistrationDTO.UserName, PasswordDataService.Encrypt(_password, true),
                    partnerRegistrationDTO.FirstName, partnerRegistrationDTO.LastName, partnerDTO.PartnerId, partnerRegistration.PartnerRegistrationAddress.MobileNumber, partnerRegistration.PartnerRegistrationAddress.Email, userPreference, ApplicationContextDTO.ApplicationId, UAMGlobalConstants.RecordStatus, ApplicationContextDTO.UserId,
                    userDTO.InCorrectLogins, UAMGlobalConstants.IsDormantNo, UAMGlobalConstants.IsDeletedNo, userDTO.IsFirstTimeLogin, userDTO.validFromDate, userDTO.validToDate, userDTO.PwdExpiryDate, partnerDTO.PartnerType,userDTO.IsCFSUser);
                userDTO.EmailId = partnerRegistration.PartnerRegistrationAddress.Email;
                userDTO.FirstName = partnerRegistrationDTO.FirstName;
                userDTO.LastName = partnerRegistrationDTO.LastName;
                userDTO.UserName = partnerRegistrationDTO.UserName;
                userDTO.ContactNumber = partnerRegistration.PartnerRegistrationAddress.MobileNumber;
                user.SetSubscriberId(ApplicationContextDTO.SubscriberId);

                foreach (string portCode in userDTO.UserPortArray)
                {
                    user.AssignToPort(portCode, UAMGlobalConstants.IsDeletedNo, UAMGlobalConstants.RecordStatus, ApplicationContextDTO.UserId);
                }
                _userRepository.AddUser(user);

                userDTO.Password = _password;

                //Notification for Password
                SendNotification(ApplicationContextDTO.ApplicationId,
                user.SubscriberId,
                user.PartnerId,
                AppEntityIds.eGateUser.ToString(),
                UserFunctionCodes.eGateUserAdd.ToString(),
                user.UserId,
                string.Empty, //TODO:Need to send Attachments physical file paths with comma separation
                user.UserId,
                userDTO);
                User user1 = _userRepository.GetUserForUserId(userDTO.UserId);
                UserDTO userDTO1 = user1.MapToDto();


                foreach (string role in partnerRegistrationDTO.UserRoleArray)
                {

                    user1.AssignRole(role, ApplicationContextDTO.ApplicationId, UAMGlobalConstants.IsDeletedNo, UAMGlobalConstants.RecordStatus, userDTO1.UserId, ApplicationContextDTO.SubscriberId);

                }

                //foreach (string role in RoleIds)
                //{
                //	user1.AssignRole(role, ApplicationContextDTO.ApplicationId, UAMGlobalConstants.IsDeletedNo, UAMGlobalConstants.RecordStatus, userDTO1.UserId);
                //}


                _userRoleRepository.AddOrUpdateUserRole(user1);
                #endregion

            });
        }

        public void VerifyPartnerRegistration(PartnerRegistrationListDTO partnerRegistrationDTO)
        {
            EncloseTransactionAndHandleException(() =>
            {
                #region Partner Registration Verification

                PartnerRegistration partnerRegistration =
                    _partnerRegistrationRepository.GetPartnerRegistrationByPartnerId(
                        partnerRegistrationDTO.RequisitionNo);

                AssertionConcern.AssertArgumentTrue(partnerRegistration.WFStatus == UAMGlobalConstants.StatusNew,
                    "KYC not valid for Verification");

                partnerRegistration.VerifyPartnerRegistration();
                _partnerRegistrationRepository.AddOrUpdatePartnerRegistration(partnerRegistration);

                #endregion

                UserDTO userDTO = new UserDTO();
                userDTO.UserId = partnerRegistration.PartnerRegistrationId;
                userDTO.SubscriberId = UAMGlobalConstants.SubscriberId;
                userDTO.UserName = partnerRegistration.PartnerName;
                userDTO.PartnerId = partnerRegistration.PartnerRegistrationId;
                userDTO.EmailId = partnerRegistration.PartnerRegistrationAddress.Email;
                userDTO.ReqNo = partnerRegistration.RequisitionNo;

                SendNotification(UAMGlobalConstants.ApplicationId,
                    UAMGlobalConstants.SubscriberId,
                    partnerRegistration.PartnerRegistrationId,
                    AppEntityIds.eGatePartner.ToString(),
                    UserFunctionCodes.eGatePartnerVerification.ToString(),
                    partnerRegistration.PartnerRegistrationId,
                    string.Empty,
                    userDTO.UserId,
                    userDTO);

                SendNotification(UAMGlobalConstants.ApplicationId,
                    UAMGlobalConstants.SubscriberId,
                    ApplicationContextDTO.MemberId,
                    AppEntityIds.eGatePartner.ToString(),
                    UserFunctionCodes.eGatePartnerVerificationACC.ToString(),
                    partnerRegistration.PartnerRegistrationId,
                    string.Empty,
                    ApplicationContextDTO.UserId,
                    userDTO);

                SendNotification(UAMGlobalConstants.ApplicationId,
                    UAMGlobalConstants.SubscriberId,
                    ApplicationContextDTO.MemberId,
                    AppEntityIds.eGatePartner.ToString(),
                    UserFunctionCodes.eGatePartnerVerificationTO.ToString(),
                    partnerRegistration.PartnerRegistrationId,
                    string.Empty,
                    ApplicationContextDTO.UserId,
                    userDTO);
            });
        }

        public void ApprovePartnerRegistration(PartnerRegistrationDTO partnerRegistrationDTO)
        {
            EncloseTransactionAndHandleException(() =>
            {
                //Method used for Approval from Edit Screen

                #region Partner Registration Approval
                PartnerRegistration partnerRegistration = _partnerRegistrationRepository.GetPartnerRegistrationByPartnerId(partnerRegistrationDTO.RequisitionNo);
                AssertionConcern.AssertArgumentTrue(partnerRegistration.WFStatus == UAMGlobalConstants.StatusVerified, "KYC not valid for Approval");
                #region update partner details
                UpdatePartnerRegistrationlDetails(partnerRegistrationDTO, partnerRegistration);

                #endregion

                partnerRegistration.ApprovePartnerRegistration();
                _partnerRegistrationRepository.AddOrUpdatePartnerRegistration(partnerRegistration);
                #endregion

                #region Partner Creation
                AddressDTO addressdto = new AddressDTO();
                if (partnerRegistration.PartnerRegistrationAddress != null)
                {
                    addressdto = new AddressDTO(partnerRegistration.PartnerRegistrationAddress.HouseNumber, partnerRegistration.PartnerRegistrationAddress.StreetName,
                        partnerRegistration.PartnerRegistrationAddress.AreaName, partnerRegistration.PartnerRegistrationAddress.TownOrCity,
                        partnerRegistration.PartnerRegistrationAddress.State, partnerRegistration.PartnerRegistrationAddress.Country, partnerRegistration.PartnerRegistrationAddress.ZipCode,
                        partnerRegistration.PartnerRegistrationAddress.MobileNumber, partnerRegistration.PartnerRegistrationAddress.Email, string.Empty,
                        partnerRegistration.PartnerRegistrationAddress.LogoFileName, partnerRegistration.PartnerRegistrationAddress.Logopath);
                }
                List<string> portArray = new List<string>() { UAMGlobalConstants.PortCode };
                List<string> partnerTypeArray = new List<string>();
                partnerTypeArray.Add(partnerRegistration.PartnerType);
                PartnerDTO partnerDTO = new PartnerDTO(partnerRegistration.PartnerName, partnerRegistration.PartnerType, partnerRegistrationDTO.PartnerRegistrationListDTO.PartnerCode, addressdto, partnerTypeArray, portArray);



                Address address = new Address(partnerDTO.PartnerAddress.HouseNumber, partnerDTO.PartnerAddress.StreetName, partnerDTO.PartnerAddress.AreaName, partnerDTO.PartnerAddress.TownOrCity, partnerDTO.PartnerAddress.State, partnerDTO.PartnerAddress.Country, partnerDTO.PartnerAddress.ZipCode, partnerDTO.PartnerAddress.ContactNumber, partnerDTO.PartnerAddress.EmailId, partnerDTO.PartnerAddress.WebSite, partnerDTO.PartnerAddress.LogoFileName, partnerDTO.PartnerAddress.LogoPath);
                partnerDTO.PartnerId = Guid.NewGuid().ToString();
                partnerDTO.CreatedBy = partnerDTO.PartnerId;
                partnerDTO.CreatedOn = DateTime.Now;
                partnerDTO.UpdatedBy = partnerDTO.PartnerId;
                partnerDTO.UpdatedOn = DateTime.Now;
                if (partnerDTO.PartnerTypeArray != null)
                {
                    List<string> partnerTypes = new List<string>();
                    foreach (string partnerTypeName in partnerDTO.PartnerTypeArray)
                    {
                        partnerTypes.Add(partnerTypeName);

                    }

                    foreach (string partnerTypeName in partnerTypes)
                    {
                        if (partnerTypeName == UAMGlobalConstants.VesselOperatingAgent)
                        {
                            partnerDTO.PartnerTypeArray.Add(UAMGlobalConstants.ConsortiumPartner);

                        }

                    }

                    List<PartnerTypePriorityDTO> prioritylist = new List<PartnerTypePriorityDTO>();
                    foreach (string partnerType in partnerDTO.PartnerTypeArray)
                    {
                        PartnerTypePriorityDTO priorityList = _commonRepository.GetPartnerTypePriority(partnerType);
                        prioritylist.Add(priorityList);

                    }
                    if (prioritylist != null)
                    {
                        List<int> priorityNos = new List<int>();
                        foreach (var poritityNo in prioritylist)
                        {
                            priorityNos.Add(poritityNo.PriorityNo);

                        }
                        priorityNos.Sort();
                        int minpriorityNo = priorityNos[0];
                        partnerDTO.PartnerType = prioritylist.Find(t => t.PriorityNo == minpriorityNo).PartnerTypeCode.ToString();


                    }

                }
                Partner partner = new Partner(partnerDTO.PartnerId, partnerDTO.PartnerName, partnerDTO.PartnerType,
                    partnerDTO.PartnerCode, address, UAMGlobalConstants.RecordStatus, partnerDTO.CreatedBy,
                    partnerDTO.CreatedOn,ApplicationContextDTO.ApplicationId, ApplicationContextDTO.SubscriberId);

                foreach (string portCode in partnerDTO.PartnerPortArray)
                {
                    partner.OperateAtPort(portCode);
                }

                foreach (string partnerType in partnerDTO.PartnerTypeArray)
                {

                    partner.PartnerTypeOperator(partnerType, UAMGlobalConstants.IsDeletedNo, ApplicationContextDTO.SubscriberId);

                }
                _partnerRepository.AddPartner(partner);

                Subscription subscription = _subscriptionRepository.GetSubscription(ApplicationContextDTO.ApplicationId, ApplicationContextDTO.SubscriberId);
                subscription.AddMember(partnerDTO.PartnerId, ApplicationContextDTO.UserName);
                _subscriptionRepository.AddSubscription(subscription);
                #endregion

                #region notification to Accounts and TO
                UserDTO userDTOMail = new UserDTO();
                userDTOMail.UserId = partnerRegistration.PartnerRegistrationId;
                userDTOMail.SubscriberId = UAMGlobalConstants.SubscriberId;
                userDTOMail.UserName = ApplicationContextDTO.UserName;// using for Username display in current template
                userDTOMail.PartnerId = partnerRegistration.PartnerRegistrationId;
                userDTOMail.EmailId = partnerRegistration.PartnerRegistrationAddress.Email;
                userDTOMail.ReqNo = partnerRegistration.RequisitionNo;

                SendNotification(UAMGlobalConstants.ApplicationId,
                  UAMGlobalConstants.SubscriberId,
                  ApplicationContextDTO.MemberId,
                  AppEntityIds.eGatePartner.ToString(),
                  UserFunctionCodes.eGatePartnerApprovedTO.ToString(),
                  partnerRegistration.PartnerRegistrationId,
                  string.Empty,
                  ApplicationContextDTO.UserId,
                  userDTOMail);

                SendNotification(UAMGlobalConstants.ApplicationId,
                 UAMGlobalConstants.SubscriberId,
                 ApplicationContextDTO.MemberId,
                 AppEntityIds.eGatePartner.ToString(),
                 UserFunctionCodes.eGatePartnerApprovedACC.ToString(),
                 partnerRegistration.PartnerRegistrationId,
                 string.Empty,
                 ApplicationContextDTO.UserId,
                 userDTOMail);
                #endregion

                #region User Creation for Partner
                UserDTO userDTO = new UserDTO();
                UserPreference userPreference = new UserPreference(UAMGlobalConstants.Yes, UAMGlobalConstants.Yes, UAMGlobalConstants.Yes);
                userDTO.UserId = Guid.NewGuid().ToString();

                string _password = PasswordDataService.Generate();
                userDTO.InCorrectLogins = 0;
                userDTO.IsFirstTimeLogin = UAMGlobalConstants.IsFirstTimeLogin;
                userDTO.validFromDate = DateTime.Now;
                userDTO.validToDate = DateTime.Now.AddDays(UAMGlobalConstants.UserCreationLifeSpan);
                userDTO.PwdExpiryDate = DateTime.Now.AddDays(UAMGlobalConstants.PwdExpiryDays);

                userDTO.UserPortArray = new List<string>();
                userDTO.UserPortArray.Add(UAMGlobalConstants.PortCode);
                userDTO.ApplicationId = ApplicationContextDTO.ApplicationId;
                userDTO.SubscriberId = ApplicationContextDTO.SubscriberId;
                User user = new User(userDTO.UserId, partnerRegistrationDTO.PartnerRegistrationListDTO.UserName, PasswordDataService.Encrypt(_password, true),
                    partnerRegistrationDTO.PartnerRegistrationListDTO.FirstName, partnerRegistrationDTO.PartnerRegistrationListDTO.LastName, partnerDTO.PartnerId, partnerRegistration.PartnerRegistrationAddress.MobileNumber, partnerRegistration.PartnerRegistrationAddress.Email, userPreference, ApplicationContextDTO.ApplicationId, UAMGlobalConstants.RecordStatus, ApplicationContextDTO.UserId,
                    userDTO.InCorrectLogins, UAMGlobalConstants.IsDormantNo, UAMGlobalConstants.IsDeletedNo, userDTO.IsFirstTimeLogin, userDTO.validFromDate, userDTO.validToDate, userDTO.PwdExpiryDate, partnerDTO.PartnerType, userDTO.IsCFSUser);
                userDTO.EmailId = partnerRegistration.PartnerRegistrationAddress.Email;
                userDTO.FirstName = partnerRegistrationDTO.PartnerRegistrationListDTO.FirstName;
                userDTO.LastName = partnerRegistrationDTO.PartnerRegistrationListDTO.LastName;
                userDTO.UserName = partnerRegistrationDTO.PartnerRegistrationListDTO.UserName;
                user.SetSubscriberId(ApplicationContextDTO.SubscriberId);

                foreach (string portCode in userDTO.UserPortArray)
                {
                    user.AssignToPort(portCode, UAMGlobalConstants.IsDeletedNo, UAMGlobalConstants.RecordStatus, ApplicationContextDTO.UserId);
                }
                _userRepository.AddUser(user);

                userDTO.Password = _password;

                //Notification for Password
                SendNotification(ApplicationContextDTO.ApplicationId,
                user.SubscriberId,
                user.PartnerId,
                AppEntityIds.eGateUser.ToString(),
                UserFunctionCodes.eGateUserAdd.ToString(),
                user.UserId,
                string.Empty, //TODO:Need to send Attachments physical file paths with comma separation
                user.UserId,
                userDTO);
                User user1 = _userRepository.GetUserForUserId(userDTO.UserId);
                UserDTO userDTO1 = user1.MapToDto();


                foreach (string role in partnerRegistrationDTO.PartnerRegistrationListDTO.UserRoleArray)
                {

                    user1.AssignRole(role, ApplicationContextDTO.ApplicationId, UAMGlobalConstants.IsDeletedNo, UAMGlobalConstants.RecordStatus, userDTO1.UserId, ApplicationContextDTO.SubscriberId);

                }

                _userRoleRepository.AddOrUpdateUserRole(user1);
                #endregion

            });
        }

        public void VerifyPartnerRegistration(PartnerRegistrationDTO partnerRegistrationDTO)
        {
            EncloseTransactionAndHandleException(() =>
            {
                #region Partner Registration Verification
                PartnerRegistration partnerRegistration = _partnerRegistrationRepository.GetPartnerRegistrationByPartnerId(partnerRegistrationDTO.RequisitionNo);

                AssertionConcern.AssertArgumentTrue(partnerRegistration.WFStatus == UAMGlobalConstants.StatusNew, "KYC not valid for Verification");
                #region update partner details
                UpdatePartnerRegistrationlDetails(partnerRegistrationDTO, partnerRegistration);

                #endregion
                partnerRegistration.VerifyPartnerRegistration();
                _partnerRegistrationRepository.AddOrUpdatePartnerRegistration(partnerRegistration);

                #endregion

                UserDTO userDTO = new UserDTO();
                userDTO.UserId = partnerRegistration.PartnerRegistrationId;
                userDTO.SubscriberId = UAMGlobalConstants.SubscriberId;
                userDTO.UserName = partnerRegistration.PartnerName;
                userDTO.PartnerId = partnerRegistration.PartnerRegistrationId;
                userDTO.EmailId = partnerRegistration.PartnerRegistrationAddress.Email;
                userDTO.ReqNo = partnerRegistration.RequisitionNo;

                SendNotification(UAMGlobalConstants.ApplicationId,
                UAMGlobalConstants.SubscriberId,
                partnerRegistration.PartnerRegistrationId,
                AppEntityIds.eGatePartner.ToString(),
                UserFunctionCodes.eGatePartnerVerification.ToString(),
                partnerRegistration.PartnerRegistrationId,
                string.Empty,
                userDTO.UserId,
                userDTO);

                SendNotification(UAMGlobalConstants.ApplicationId,
                  UAMGlobalConstants.SubscriberId,
                  ApplicationContextDTO.MemberId,
                  AppEntityIds.eGatePartner.ToString(),
                  UserFunctionCodes.eGatePartnerVerificationACC.ToString(),
                  partnerRegistration.PartnerRegistrationId,
                  string.Empty,
                  ApplicationContextDTO.UserId,
                  userDTO);

                SendNotification(UAMGlobalConstants.ApplicationId,
                  UAMGlobalConstants.SubscriberId,
                  ApplicationContextDTO.MemberId,
                  AppEntityIds.eGatePartner.ToString(),
                  UserFunctionCodes.eGatePartnerVerificationTO.ToString(),
                  partnerRegistration.PartnerRegistrationId,
                  string.Empty,
                  ApplicationContextDTO.UserId,
                  userDTO);
            });
        }

        public void RejectPartnerVerification(PartnerRegistrationListDTO partnerRegistrationDTO)
        {
            EncloseTransactionAndHandleException(() =>
            {
                PartnerRegistration partner = _partnerRegistrationRepository.GetPartnerRegistrationByPartnerId(partnerRegistrationDTO.RequisitionNo);
                AssertionConcern.AssertArgumentTrue(partner.WFStatus == UAMGlobalConstants.StatusNew, "KYC not valid for Rejecting at Verification");
                partner.RejectPartnerVerification(partnerRegistrationDTO.Remarks);

                _partnerRegistrationRepository.AddOrUpdatePartnerRegistration(partner);


                #region Email Notification for rejected while Verification Form
                UserDTO userDTO = new UserDTO();

                userDTO.UserId = partner.PartnerRegistrationId;
                userDTO.PartnerId = partner.PartnerRegistrationId;
                userDTO.SubscriberId = ApplicationContextDTO.SubscriberId;
                userDTO.ReqNo = partner.RequisitionNo;
                userDTO.Remarks = partner.Remarks;
                userDTO.EmailId = partner.PartnerRegistrationAddress.Email;

                ////TODO: Need to update the notification template content
                SendNotification(ApplicationContextDTO.ApplicationId, userDTO.SubscriberId, partner.PartnerRegistrationId, AppEntityIds.eGatePartner.ToString(),
          UserFunctionCodes.eGatePartnerRejectVerification.ToString(), partner.PartnerRegistrationId, string.Empty, partner.PartnerRegistrationId, userDTO);
                #endregion


            });
        }

        public void RejectPartnerRegistration(PartnerRegistrationListDTO partnerRegistrationDTO)
        {
            EncloseTransactionAndHandleException(() =>
            {
                PartnerRegistration partner = _partnerRegistrationRepository.GetPartnerRegistrationByPartnerId(partnerRegistrationDTO.RequisitionNo);
                AssertionConcern.AssertArgumentTrue(partner.WFStatus == UAMGlobalConstants.StatusVerified, "KYC not valid for Rejecting at Approval");
                partner.RejectPartnerRegistration(partnerRegistrationDTO.Remarks);
                _partnerRegistrationRepository.AddOrUpdatePartnerRegistration(partner);

                #region Email Notification for rejected Form
                UserDTO userDTO = new UserDTO();

                userDTO.SubscriberId = ApplicationContextDTO.SubscriberId;
                userDTO.PartnerId = partner.PartnerRegistrationId;
                userDTO.UserId = partner.PartnerRegistrationId;
                userDTO.ReqNo = partner.RequisitionNo;
                userDTO.Remarks = partner.Remarks;
                userDTO.EmailId = partner.PartnerRegistrationAddress.Email;

                SendNotification(ApplicationContextDTO.ApplicationId,
          userDTO.SubscriberId,
          partner.PartnerRegistrationId,
          AppEntityIds.eGatePartner.ToString(),
          UserFunctionCodes.eGatePartnerReject.ToString(),
           partner.PartnerRegistrationId,
          string.Empty, //TODO:Need to send Attachments physical file paths with comma separation
           partner.PartnerRegistrationId,
          userDTO);

                #endregion
            });
        }

        public List<PartnerRegistrationListDTO> GetPendingPartnerRegistrationsGridList(string estbName, string partnerType, string status)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                List<PartnerRegistrationListDTO> partnersListDtos = _partnerRegistrationRepository.GetPendingPartnerRegistrationsGridList(estbName, partnerType, status);

                return partnersListDtos;


            });
        }

        public PartnerRegistrationDTO GetPartnerRegistration(string requisitionNo)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                PartnerRegistration partner = _partnerRegistrationRepository.GetPartnerRegistrationByPartnerId(requisitionNo);
                PartnerRegistrationDTO partnerDto = partner.MapToDto();
                return partnerDto;
            });
        }

        #region Commented Code
        //public void UpdatePartner(partnerRegistrationDTO partnerRegistrationDTO)
        //{
        //    EncloseTransactionAndHandleException(() =>
        //    {
        //        PartnerRegistration partnerById = _partnerRepository.GetPartnerByPartnerRegistrationId(partnerRegistrationDTO.PartnerRegistrationId);

        //        if (partnerById == null) throw new ArgumentNullException("PartnerRegistration does not Exists");
        //        partnerRegistrationDTO partnerRegistrationDTOs = partnerById.MapToDto();


        //        if (partnerRegistrationDTOs.partnerTypes.Any())
        //        {
        //            partnerRegistrationDTOs.PartnerTypeArray = new List<string>();
        //            foreach (PartnerTypeDTO partnertype in partnerRegistrationDTOs.partnerTypes)
        //            {
        //                if (partnertype.IsDelete == UAMGlobalConstants.IsDeletedNo)
        //                {
        //                    partnerRegistrationDTOs.PartnerTypeArray.Add(partnertype.PartnerTypeName);

        //                }

        //            }
        //        }

        //        //int partnerNosOfCode = _partnerRepository.GetPartnersByCodeOtherThanPartnerRegistrationId(partnerRegistrationDTO.PartnerRegistrationId, partnerRegistrationDTO.PartnerCode);

        //        //AssertionConcern.AssertArgumentTrue(partnerNosOfCode < 1, "PartnerRegistration Code already Exists");

        //        //int partnerNosOfName = _partnerRepository.GetPartnersByNameOtherThanPartnerRegistrationId(partnerRegistrationDTO.PartnerRegistrationId, partnerRegistrationDTO.PartnerName);

        //        //AssertionConcern.AssertArgumentTrue(partnerNosOfCode < 1, "PartnerRegistration Name already Exists");
        //        if (partnerRegistrationDTO.PartnerTypeArray != null)
        //        {
        //            List<string> partnerTypes = new List<string>();

        //            foreach (string partnerTypeName in partnerRegistrationDTO.PartnerTypeArray)
        //            {
        //                partnerTypes.Add(partnerTypeName);

        //            }

        //            foreach (string partnerTypeName in partnerTypes)
        //            {
        //                if (partnerTypeName == UAMGlobalConstants.VesselOperatingAgent)
        //                {
        //                    partnerRegistrationDTO.PartnerTypeArray.Add(UAMGlobalConstants.ConsortiumPartner);

        //                }
        //                else
        //                {
        //                    if (partnerTypeName == UAMGlobalConstants.ConsortiumPartner)
        //                    {
        //                        partnerRegistrationDTO.PartnerTypeArray.Remove(UAMGlobalConstants.ConsortiumPartner);
        //                    }
        //                }

        //            }

        //            List<PartnerTypePriorityDTO> prioritylist = new List<PartnerTypePriorityDTO>();
        //            foreach (string partnerType in partnerRegistrationDTO.PartnerTypeArray)
        //            {
        //                PartnerTypePriorityDTO priorityList = _commonRepository.GetPartnerTypePriority(partnerType);
        //                prioritylist.Add(priorityList);

        //            }
        //            if (prioritylist != null)
        //            {
        //                List<int> priorityNos = new List<int>();
        //                foreach (var poritityNo in prioritylist)
        //                {
        //                    priorityNos.Add(poritityNo.PriorityNo);

        //                }
        //                priorityNos.Sort();
        //                int minpriorityNo = priorityNos[0];
        //                partnerRegistrationDTO.PartnerType = prioritylist.Find(t => t.PriorityNo == minpriorityNo).PartnerTypeCode.ToString();


        //            }

        //        }


        //        partnerById.ChangePartnerDetails(partnerRegistrationDTO.PartnerCode, partnerRegistrationDTO.PartnerName, partnerRegistrationDTO.PartnerType);
        //        partnerById.ChangeAddressDetails(partnerRegistrationDTO.PartnerRegistrationAddress.HouseNumber, partnerRegistrationDTO.PartnerRegistrationAddress.StreetName, partnerRegistrationDTO.PartnerRegistrationAddress.AreaName, partnerRegistrationDTO.PartnerRegistrationAddress.TownOrCity, partnerRegistrationDTO.PartnerRegistrationAddress.State, partnerRegistrationDTO.PartnerRegistrationAddress.Country, partnerRegistrationDTO.PartnerRegistrationAddress.ZipCode, partnerRegistrationDTO.PartnerRegistrationAddress.ContactNumber, partnerRegistrationDTO.PartnerRegistrationAddress.EmailId, partnerRegistrationDTO.PartnerRegistrationAddress.WebSite, partnerRegistrationDTO.PartnerRegistrationAddress.LogoFileName, partnerRegistrationDTO.PartnerRegistrationAddress.LogoPath);
        //        partnerById.ChangeUpdatedByAndOn(partnerRegistrationDTO.PartnerRegistrationId);
        //        PartnerTypes partnerTypeIns = new PartnerTypes();
        //        if (partnerRegistrationDTO.PartnerTypeArray != null)
        //        {
        //            foreach (PartnerTypes partnerType in partnerById.partnerTypes)
        //            {
        //                if (!partnerRegistrationDTO.PartnerTypeArray.Contains(partnerType.partnerTypeName))
        //                {
        //                    partnerType.UpdateIsDeleted(UAMGlobalConstants.IsDeletedYes);

        //                }
        //                //else if (partnerRegistrationDTO.PartnerTypeArray.Contains(partnerType.partnerTypeName))
        //                else if (partnerRegistrationDTO.PartnerTypeArray.Contains(partnerType.partnerTypeName) && partnerType.IsDelete == UAMGlobalConstants.IsDeletedYes)
        //                {
        //                    partnerType.UpdateIsDeleted(UAMGlobalConstants.IsDeletedNo);

        //                }

        //            }
        //            foreach (var partnerType in partnerRegistrationDTO.PartnerTypeArray)
        //            {
        //                if (partnerRegistrationDTOs.PartnerTypeArray == null)
        //                {
        //                    partnerById.PartnerTypeOperator(partnerType, UAMGlobalConstants.IsDeletedNo);
        //                }
        //                else if (!partnerRegistrationDTOs.PartnerTypeArray.Contains(partnerType) && partnerRegistrationDTOs.partnerTypes.FirstOrDefault(t => t.PartnerTypeName == partnerType) == null)
        //                {
        //                    partnerById.PartnerTypeOperator(partnerType, UAMGlobalConstants.IsDeletedNo);
        //                }

        //            }


        //        }



        //        _partnerRepository.UpdatePartner(partnerById);
        //    });

        //}


        //public PartnerRegistrationDTO GetPartner(string PartnerRegistrationId)
        //{
        //    return ExecuteFaultHandledOperation(() =>
        //    {
        //        PartnerRegistration partner = _partnerRepository.GetPartnerByPartnerRegistrationId(PartnerRegistrationId);
        //        partnerRegistrationDTO partnerRegistrationDTO = partner.MapToDto();

        //        if (partnerRegistrationDTO.partnerTypes.Any())
        //        {
        //            partnerRegistrationDTO.PartnerTypeArray = new List<string>();
        //            foreach (PartnerTypeDTO partnertype in partnerRegistrationDTO.partnerTypes)
        //            {
        //                if (partnertype.IsDelete == UAMGlobalConstants.IsDeletedNo)
        //                {
        //                    partnerRegistrationDTO.PartnerTypeArray.Add(partnertype.PartnerTypeName);

        //                }

        //            }
        //        }
        //        partnerRegistrationDTO.context = ApplicationContextDTO;
        //        return partnerRegistrationDTO;
        //    });
        //}




        //public PartnerRegistrationDTO GetPartnerLogo(string PartnerRegistrationId)
        //{
        //    return ExecuteFaultHandledOperation(() =>
        //    {
        //        PartnerRegistration partnerRegistration = _partnerRepository.GetPartnerByPartnerCode(PartnerRegistrationId);
        //        partnerRegistrationDTO partnerRegistrationDTO = partner.MapToDto();

        //        if (partnerRegistrationDTO.partnerTypes.Any())
        //        {
        //            partnerRegistrationDTO.PartnerTypeArray = new List<string>();
        //            foreach (PartnerTypeDTO partnertype in partnerRegistrationDTO.partnerTypes)
        //            {
        //                if (partnertype.IsDelete == UAMGlobalConstants.IsDeletedNo)
        //                {
        //                    partnerRegistrationDTO.PartnerTypeArray.Add(partnertype.PartnerTypeName);

        //                }

        //            }
        //        }
        //        partnerRegistrationDTO.context = ApplicationContextDTO;
        //        return partnerRegistrationDTO;
        //    });
        //}

        //public List<PartnerListDTO> GetPartnersList(string partnerName, string partnerType, string emailId, string contactNumber, string subscribedId, int applicationId)
        //{
        //    return ExecuteFaultHandledOperation(() =>
        //    {
        //        List<PartnerListDTO> partnersListDtos = _partnerRepository.GetPartners(subscribedId, applicationId, partnerName, partnerType, emailId, contactNumber);
        //        foreach (PartnerListDTO partner in partnersListDtos)
        //        {

        //            List<string> partnerTypes = new List<string>();
        //            foreach (string partnerTypeName in partner.partnerTypeArray)
        //            {
        //                if (partnerTypeName != UAMGlobalConstants.ConsortiumPartner)
        //                {
        //                    PartnerTypeDTO partnerTypeDto = _commonRepository.GetPartnerTypeName(partnerTypeName);
        //                    //if (partnerTypeDto != null)
        //                    //    partner.partnerTypeArray = partnerTypeDto.PartnerTypeName;
        //                    partnerTypes.Add(partnerTypeDto.PartnerTypeName);
        //                    if (String.IsNullOrEmpty(partner.PartnerTypeArrays))
        //                        partner.PartnerTypeArrays = partnerTypeDto.PartnerTypeName;
        //                    else
        //                        partner.PartnerTypeArrays = partner.PartnerTypeArrays + "," + partnerTypeDto.PartnerTypeName;
        //                    //user.PartnerTypeArray = partnertypes;
        //                }

        //            }

        //            partner.partnerTypeArray = new List<string>();
        //            foreach (string partnerTypeNames in partnerTypes)
        //            {

        //                partner.partnerTypeArray.Add(partnerTypeNames);

        //            }
        //            PortDTO portDto = _commonRepository.GetPortByPortCode(ApplicationContextDTO.PortCode);
        //            if (portDto != null)
        //                partner.SubscribedPort = portDto.PortName;
        //        }
        //        return partnersListDtos;


        //    });
        //}


        //public List<partnerRegistrationDTO> GetPartnerCodes(List<string> partnerType)
        //{
        //    return ExecuteFaultHandledOperation(() => _commonRepository.GetPartnerCodes(partnerType));
        //}

        //public List<artnerRegistrationDTO> GetPartners(List<string> partnerCodes)
        //{
        //    return _commonRepository.GetPartners(partnerCodes);
        //}
        #endregion

        public string CheckUniquePartnerName(string partnerName, string partnerType)
        {
            string isDuplicate;
            List<PartnerRegistrationListDTO> partnersListDtos = _partnerRegistrationRepository.GetPartnerRegistrationsForUniqueItem();
            PartnerRegistrationListDTO partner = partnersListDtos.FirstOrDefault(p => p.PartnerName.Equals(partnerName, StringComparison.OrdinalIgnoreCase) && p.PartnerType.Equals(partnerType, StringComparison.OrdinalIgnoreCase));
            if (partner != null)
            {
                isDuplicate = UAMGlobalConstants.Yes;
            }
            else
            {
                isDuplicate = UAMGlobalConstants.No;
            }
            return isDuplicate;
        }

        private void UpdatePartnerRegistrationlDetails(PartnerRegistrationDTO partnerRegistrationDTO, PartnerRegistration partnerRegistration)
        {
            partnerRegistration.PartnerRegistrationAddress.UpdatePartnerRegistrationAddress(partnerRegistrationDTO.PartnerRegistrationAddress.HouseNumber, partnerRegistrationDTO.PartnerRegistrationAddress.StreetName, partnerRegistrationDTO.PartnerRegistrationAddress.AreaName, partnerRegistrationDTO.PartnerRegistrationAddress.TownOrCity, partnerRegistrationDTO.PartnerRegistrationAddress.State, partnerRegistrationDTO.PartnerRegistrationAddress.Country, partnerRegistrationDTO.PartnerRegistrationAddress.ZipCode, partnerRegistrationDTO.PartnerRegistrationAddress.LogoFileName, partnerRegistrationDTO.PartnerRegistrationAddress.LogoPath, partnerRegistrationDTO.PartnerRegistrationAddress.Email, partnerRegistrationDTO.PartnerRegistrationAddress.MobileNumber);

            partnerRegistrationDTO.PartnerName = partnerRegistrationDTO.PartnerName.Trim();

            partnerRegistrationDTO.UpdatedBy = UAMGlobalConstants.Anonymous;

            partnerRegistrationDTO.UpdatedOn = DateTime.Now;

            partnerRegistrationDTO.IsAccept = UAMGlobalConstants.Yes;

            partnerRegistration.UpdatePartnerRegistrationDetails(partnerRegistrationDTO.PartnerName, partnerRegistrationDTO.CIN, partnerRegistrationDTO.PAN, partnerRegistrationDTO.TAN, partnerRegistrationDTO.NatureOfBusiness, partnerRegistrationDTO.Year, partnerRegistrationDTO.Status, partnerRegistrationDTO.RegistrationNo,
                partnerRegistrationDTO.Place, partnerRegistrationDTO.VAT, partnerRegistrationDTO.BankName, partnerRegistrationDTO.BankAddress, partnerRegistrationDTO.AccountNo, partnerRegistrationDTO.IFSCCode, partnerRegistrationDTO.FinanceName, partnerRegistrationDTO.FinanceEmail, partnerRegistrationDTO.FinanceMobile, partnerRegistrationDTO.OperationsName, partnerRegistrationDTO.OperationsEmail, partnerRegistrationDTO.OperationsMobile, partnerRegistrationDTO.ITName, partnerRegistrationDTO.ITEmail, partnerRegistrationDTO.ITMobile, UAMGlobalConstants.RecordStatus, partnerRegistrationDTO.CreatedBy, partnerRegistrationDTO.CreatedOn, partnerRegistrationDTO.UpdatedBy, partnerRegistrationDTO.UpdatedOn, partnerRegistrationDTO.IsAccept);

            if (partnerRegistrationDTO.PartnerDirectorDetailss.Any())
            {
                foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerDirectorDetailss)
                {
                    partnerRegistration.UpdateDirector(partner.PDirectorDetailsId, partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type, partner.IsDeleted);
                }
            }

            if (partnerRegistrationDTO.PartnerOperationsDetailss.Any())
            {
                foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerOperationsDetailss)
                {
                    partnerRegistration.UpdateDirector(partner.PDirectorDetailsId, partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type, partner.IsDeleted);
                }
            }
            if (partnerRegistrationDTO.PartnerITDetailss.Any())
            {
                foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerITDetailss)
                {
                    partnerRegistration.UpdateDirector(partner.PDirectorDetailsId, partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type, partner.IsDeleted);
                }
            }
            if (partnerRegistrationDTO.PartnerFinanceDetailss.Any())
            {
                foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerFinanceDetailss)
                {
                    partnerRegistration.UpdateDirector(partner.PDirectorDetailsId, partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type, partner.IsDeleted);
                }
            }
            if (partnerRegistrationDTO.PartnerSalesDetailss.Any())
            {
                foreach (PartnerDirectorDetailsDTO partner in partnerRegistrationDTO.PartnerSalesDetailss)
                {
                    partnerRegistration.UpdateDirector(partner.PDirectorDetailsId, partner.PDirectorName, partner.PDirectorPAN, partner.PDirectorAddress, partner.PDirectorMobile, partner.PDirectorTele, partner.PDirectorEmail, partner.PCountryCode, partner.Type, partner.IsDeleted);
                }
            }
            if (partnerRegistrationDTO.DocumentDTOs.Any())
            {
                foreach (PartnerRegistrationDocsDTO doc in partnerRegistrationDTO.DocumentDTOs)
                {
                    if (!string.IsNullOrEmpty(doc.OriginalName))
                        partnerRegistration.AddDocumentType(doc.FileName, doc.OriginalName, doc.DocumentType, doc.ValidTill, doc.IsDeleted);
                    else if (doc.IsDeleted == UAMGlobalConstants.IsDeletedYes)
                        partnerRegistration.AddDocumentType(doc.FileName, doc.OriginalName, doc.DocumentType, doc.ValidTill, doc.IsDeleted);

                }
            }
        }

    }
}
