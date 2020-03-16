using System.Collections.Generic;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.WebApp.MockServices.Interfaces;
using PortKonnect.UserAccessManagement.Domain.Repositories;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.WebApp.MockServices
{
    public class MockPartnerService : IMockPartnerService
    {
        private readonly IPartnerRepository _partnerRepository;

        public MockPartnerService(IPartnerRepository partnerVoyageRepository)
        {
            _partnerRepository = partnerVoyageRepository;
        }

        public List<PartnerDTO> GetPartnersList()
        {
            List<PartnerDTO> partners = new List<PartnerDTO>()
            {
                new PartnerDTO()
                {
                    PartnerId="1",
                    PartnerCode="KPCL",
                    PartnerName="KPCL"
                },
                new PartnerDTO()
                {
                    PartnerId="2",
                    PartnerCode="KPCT",
                    PartnerName="KPCT"
                },
                new PartnerDTO()
                {
                    PartnerId="3",
                    PartnerCode="VOA1",
                    PartnerName="VOA1"
                },
                new PartnerDTO()
                {
                    PartnerId="4",
                    PartnerCode="VOA2",
                    PartnerName="VOA2"
                },
                new PartnerDTO()
                {
                   PartnerId="5",
                    PartnerCode="COA1",
                    PartnerName="COA1"
                },
                new PartnerDTO()
                {
                    PartnerId="6",
                    PartnerCode="COA2",
                    PartnerName="COA2"
                }
            };
            return partners;
        }

        public List<CountryDTO> GetCountries()
        {
            List<CountryDTO> countries = new List<CountryDTO>() 
            {
                new CountryDTO()
                {
                    CountryId=1,
                    CountryCode="IND",
                    CountryName="India",
                    States=new List<StateDTO>()
                    {
                        new StateDTO()
                        {
                            StateId=1,
                            StateCode="TG",
                            StateName="Telangana",
                            CountryId=1
                        },
                        new StateDTO()
                        {
                            StateId=2,
                            StateCode="AP",
                            StateName="Andhra Pradesh",
                            CountryId=1
                        }
                    }
                },
                new CountryDTO()
                {
                    CountryId=2,
                    CountryCode="PAK",
                    CountryName="Pakistan",
                    States=new List<StateDTO>()
                    {
                        new StateDTO()
                        {
                            StateId=3,
                            StateCode="PJB",
                            StateName="Punjab",
                            CountryId=2
                        },
                        new StateDTO()
                        {
                            StateId=2,
                            StateCode="SND",
                            StateName="Sindh",
                            CountryId=2
                        }
                    }
                }
            };
            return countries;
        }

        public List<ApplicationDTO> GetApplication()
        {
            List<ApplicationDTO> applications = new List<ApplicationDTO>()
            {
                new ApplicationDTO()
                {
                    ApplicationId=1,
                    ApplicationName="Marine"
                },
                new ApplicationDTO()
                {
                    ApplicationId=2,
                    ApplicationName="eGate"
                }
            };
            return applications;
        }

        public List<PortDTO> GetPorts()
        {
            List<PortDTO> ports = new List<PortDTO>()
            {
                new PortDTO()
                {
                    PortCode="KP",
                    PortName="Krishnapatnam Port"
                }
            };
            return ports;
        }

        #region Commented
        //public List<string> GetPartnerTypes()
        //{
        //    var type = typeof(PartnerType);
        //    return Enum.GetNames(typeof(PartnerType)).Select(item => type.GetMember(item)).Select(member => ((DescriptionAttribute)member[0].GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description).ToList();
        //}
        #endregion

        public List<PartnerTypeDTO> GetPartnerTypes()
        {
            List<PartnerTypeDTO> partnerTypes = new List<PartnerTypeDTO>() 
            {
                new PartnerTypeDTO()
                {
                    PartnerTypeId="PortAuthority",
                    PartnerTypeName="Port Authority"
                },
                new PartnerTypeDTO()
                {
                    PartnerTypeId="TerminalOperator",
                    PartnerTypeName="Terminal Authority"
                },
                new PartnerTypeDTO()
                {
                    PartnerTypeId="VesselAgent",
                    PartnerTypeName="Vessel Agent"
                },
                new PartnerTypeDTO()
                {
                    PartnerTypeId="Vessel Operating Agent",
                    PartnerTypeName="Vessel Operating Agent"
                },
                new PartnerTypeDTO()
                {
                    PartnerTypeId="ContainerOperatingAgent",
                    PartnerTypeName="Container Operating Agent"
                },
                new PartnerTypeDTO()
                {
                    PartnerTypeId="ContainerFreightStation",
                    PartnerTypeName="Container Freight Station"
                },
                new PartnerTypeDTO()
                {
                    PartnerTypeId="CustomsHouseAgent",
                    PartnerTypeName="Customs House Agent"
                },
                new PartnerTypeDTO()
                {
                    PartnerTypeId="ICD",
                    PartnerTypeName="Inland Container Depot"
                },
                new PartnerTypeDTO()
                {
                    PartnerTypeId="MnR",
                    PartnerTypeName="MnR"
                }
            };
            return partnerTypes;
        }


        public void AddPartner(PartnerDTO partnerDTO)
        {
            ////PartnerDTO partner = new PartnerDTO();
            //Address address = partnerDTO.PartnerAddress;
            ////vesselVoyageDTO.OwnerId = 1;

            ////vesselVoyageDTO.PortCode = "KP";

            ////VesselVoyage vesselVoyagetest = _vesselVoyageRepository.GetVesselVoyage(vesselVoyageDTO.VesselId, vesselVoyageDTO.VoyageNumber, vesselVoyageDTO.OwnerId, vesselVoyageDTO.PortCode);

            ////AssertionConcern.AssertArgumentTrue(vesselVoyagetest == null || (vesselVoyagetest != null && vesselVoyagetest.VoyageNumber == vesselVoyageDTO.VoyageNumber), "Vessel Voyage already Exists");

            ////vesselVoyageDTO.VesselVoyageId = new VesselVoyageId().Id;

            ////if (string.IsNullOrEmpty(vesselVoyageDTO.VesselVoyageId.Trim()))
            ////{
            ////    throw new ArgumentException("Vessel Voyage Id cannot be null for a new Vessel Voyage");
            ////}

            //////TODO: Need to write a method to check in db wheather other records with same vesselid & Voyage no exists
            ////VesselVoyage vesselVoyage = new VesselVoyage(vesselVoyageDTO.VesselVoyageId, vesselVoyageDTO.VCN, vesselVoyageDTO.OwnerId, vesselVoyageDTO.VoyageNumber, vesselVoyageDTO.PortCode, vesselVoyageDTO.VesselDTO, vesselVoyageDTO.VOAId, vesselVoyageDTO.Eta, vesselVoyageDTO.Etd, vesselVoyageDTO.CargoCutOffDTOs, vesselVoyageDTO.TotalNoOfSlotsForExport, vesselVoyageDTO.Service, vesselVoyageDTO.IsLimitedSlots, vesselVoyageDTO.COAAllocationDTOs, vesselVoyageDTO.CPAllocationDTOs);
            //Partner partner = new Partner("1", partnerDTO.PartnerName, partnerDTO.PartnerType, partnerDTO.PartnerCode, address, "A", "1", DateTime.Now, "1", DateTime.Now);
            //_partnerRepository.AddPartner(partner);
        }

        public PartnerDTO GetPartner(string partnerId)
        {
            Partner partner = _partnerRepository.GetPartnerByPartnerId("1","KPCT");

            PartnerDTO partnerDTO = new PartnerDTO
            {
                PartnerId= partner.PartnerId
            };

            //TODO: Data to be get from Partner & PARTNERPORT tables based on partnerId
            return partnerDTO;
        }

    }
}