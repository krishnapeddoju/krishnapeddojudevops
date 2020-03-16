using System;
using System.Collections.Generic;
using System.Linq;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;
using PortKonnect.UserAccessManagement.Domain.Enums;
using System.ComponentModel;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.MapToDTOS;
using PortKonnect.UserAccessManagement.GlobalConstants;


namespace PortKonnect.UserAccessManagement.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly IUserContext _userContext;

        public CommonRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public List<string> GetPartnerTypesEnum()
        {
            var type = typeof(PartnerType);

            return Enum.GetNames(typeof(PartnerType)).Select(item => type.GetMember(item)).Select(member => ((DescriptionAttribute)member[0].GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description).ToList();

        }

        public List<string> GetStatusEnum()
        {
            var type = typeof(Status);

            return Enum.GetNames(typeof(Status)).Select(item => type.GetMember(item)).Select(member => ((DescriptionAttribute)member[0].GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description).ToList();

        }

        public List<string> GetYearsEnum()
        {
            var type = typeof(Years);

            return Enum.GetNames(typeof(Years)).Select(item => type.GetMember(item)).Select(member => ((DescriptionAttribute)member[0].GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description).ToList();

        }

        public List<string> GetDocumentTypesEnum()
        {
            var type = typeof(DocumentTypes);

            return Enum.GetNames(typeof(DocumentTypes)).Select(item => type.GetMember(item)).Select(member => ((DescriptionAttribute)member[0].GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description).ToList();

        }

        public List<string> GetDocumentTypesByPartnerType(string partnerType)
        {
            List<string> doctypes = new List<string>();
            if (!string.IsNullOrEmpty(partnerType))
            {
                if (partnerType.Trim() == UAMGlobalConstants.PartnerTypeCFS)
                {
                    var type = typeof(CFSDocTypesEnum);

                    doctypes = Enum.GetNames(typeof(CFSDocTypesEnum)).Select(item => type.GetMember(item)).Select(member => ((DescriptionAttribute)member[0].GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description).ToList();

                }
                else if (partnerType.Trim() == UAMGlobalConstants.PartnerTypeCOA)
                {
                    var type = typeof(COADocTypesEnum);

                    doctypes = Enum.GetNames(typeof(COADocTypesEnum)).Select(item => type.GetMember(item)).Select(member => ((DescriptionAttribute)member[0].GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description).ToList();
                }
                else if (partnerType.Trim() == UAMGlobalConstants.PartnerTypeVOA)
                {

                    var type = typeof(VOADocTypesEnum);

                    doctypes = Enum.GetNames(typeof(VOADocTypesEnum)).Select(item => type.GetMember(item)).Select(member => ((DescriptionAttribute)member[0].GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description).ToList();
                }
                else if (partnerType.Trim() == UAMGlobalConstants.PartnerTypeCHA)
                {

                    var type = typeof(CHADocTypesEnum);

                    doctypes = Enum.GetNames(typeof(CHADocTypesEnum)).Select(item => type.GetMember(item)).Select(member => ((DescriptionAttribute)member[0].GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description).ToList();
                }
                else
                {

                    var type = typeof(MAndRDocTypesEnum);

                    doctypes = Enum.GetNames(typeof(MAndRDocTypesEnum)).Select(item => type.GetMember(item)).Select(member => ((DescriptionAttribute)member[0].GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description).ToList();
                }
            }
            return doctypes;

        }

        public List<ApplicationDTO> GetApplicationsById(int applicationId)
        {
            List<ApplicationDTO> applications =
                (from a in _userContext.Applications.Where(a => a.ApplicationId == applicationId)
                 select new ApplicationDTO
                 {
                     ApplicationId = a.ApplicationId,
                     ApplicationName = a.ApplicationName,
                     ApplicationUrl = a.ApplicationUrl,
                     RecordStatus = a.RecordStatus,
                     CreatedBy = a.CreatedBy,
                     CreatedOn = a.CreatedOn,
                     UpdatedBy = a.UpdatedBy,
                     UpdatedOn = a.UpdatedOn
                 }).ToList();
            return applications;

        }

        public List<PortDTO> GetPorts()
        {
            var ports = new List<PortDTO>()
            {
                new PortDTO()
                {
                    PortCode="KP",
                    PortName="COPT"
                }
            };
            return ports;
        }

        public List<CountryDTO> GetCountries()
        {

            var countries = new List<CountryDTO>() 
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
                            StateCode="Andhra Pradesh",
                            StateName="Andhra Pradesh",
                            CountryId=1
                        },
                        //Arunachal Pradesh
                        new StateDTO()
                        {
                            StateId=2,
                            StateCode="Arunachal Pradesh",
                            StateName="Arunachal Pradesh",
                            CountryId=1
                        },
                        //Assam
                        new StateDTO()
                        {
                            StateId=3,
                            StateCode="Assam",
                            StateName="Assam",
                            CountryId=1
                        },
                        //Bihar
                        new StateDTO()
                        {
                            StateId=4,
                            StateCode="Bihar",
                            StateName="Bihar",
                            CountryId=1
                        },
                        //Chandigarh 
                        new StateDTO()
                        {
                            StateId=5,
                            StateCode="Chandigarh ",
                            StateName="Chandigarh ",
                            CountryId=1
                        },
                        //Chhattisgarh
                        new StateDTO()
                        {
                            StateId=6,
                            StateCode="Chhattisgarh",
                            StateName="Chhattisgarh",
                            CountryId=1
                        },
                        //Delhi
                        new StateDTO()
                        {
                            StateId=32,
                            StateCode="Delhi",
                            StateName="Delhi",
                            CountryId=1
                        },
                        //Goa
                        new StateDTO()
                        {
                            StateId=7,
                            StateCode="Goa",
                            StateName="Goa",
                            CountryId=1
                        },
                        //Gujarat
                        new StateDTO()
                        {
                            StateId=8,
                            StateCode="Gujarat",
                            StateName="Gujarat",
                            CountryId=1
                        },
                        //Haryana
                        new StateDTO()
                        {
                            StateId=9,
                            StateCode="Haryana",
                            StateName="Haryana",
                            CountryId=1
                        },
                        //Himachal Pradesh
                        new StateDTO()
                        {
                            StateId=10,
                            StateCode="Himachal Pradesh",
                            StateName="Himachal Pradesh",
                            CountryId=1
                        },
                        //Jammu and Kashmir
                        new StateDTO()
                        {
                            StateId=11,
                            StateCode="Jammu and Kashmir",
                            StateName="Jammu and Kashmir",
                            CountryId=1
                        },
                        //Jharkhand
                        new StateDTO()
                        {
                            StateId=12,
                            StateCode="Jharkhand",
                            StateName="Jharkhand",
                            CountryId=1
                        },
                        //Karnataka
                        new StateDTO()
                        {
                            StateId=13,
                            StateCode="Karnataka",
                            StateName="Karnataka",
                            CountryId=1
                        },
                        //Kerala
                        new StateDTO()
                        {
                            StateId=14,
                            StateCode="Kerala",
                            StateName="Kerala",
                            CountryId=1
                        },

                        //Madhya Pradesh
                        new StateDTO()
                        {
                            StateId=15,
                            StateCode="Madhya Pradesh",
                            StateName="Madhya Pradesh",
                            CountryId=1
                        },
                        //Maharashtra
                        new StateDTO()
                        {
                            StateId=16,
                            StateCode="Maharashtra",
                            StateName="Maharashtra",
                            CountryId=1
                        },
                        //Manipur
                        new StateDTO()
                        {
                            StateId=17,
                            StateCode="Manipur",
                            StateName="Manipur",
                            CountryId=1
                        },
                        //Meghalaya
                        new StateDTO()
                        {
                            StateId=18,
                            StateCode="Meghalaya",
                            StateName="Meghalaya",
                            CountryId=1
                        },
                        //Mizoram
                        new StateDTO()
                        {
                            StateId=19,
                            StateCode="Mizoram",
                            StateName="Mizoram",
                            CountryId=1
                        },
                        //Nagaland
                        new StateDTO()
                        {
                            StateId=20,
                            StateCode="Nagaland",
                            StateName="Nagaland",
                            CountryId=1
                },
                        //Odisha
                        new StateDTO()
                {
                            StateId=21,
                            StateCode="Odisha",
                            StateName="Odisha",
                            CountryId=1
                        },
                        //Puducherry 
                        new StateDTO()
                    {
                            StateId=22,
                            StateCode="Puducherry ",
                            StateName="Puducherry ",
                            CountryId=1
                        },
                        //Punjab
                        new StateDTO()
                        {
                            StateId=23,
                            StateCode="Punjab",
                            StateName="Punjab",
                            CountryId=1
                        },
                        //Rajasthan
                        new StateDTO()
                        {
                            StateId=24,
                            StateCode="Rajasthan",
                            StateName="Rajasthan",
                            CountryId=1
                        },
                        //Sikkim
                        new StateDTO()
                        {
                            StateId=25,
                            StateCode="Sikkim",
                            StateName="Sikkim",
                            CountryId=1
                        },
                        //Tamil Nadu
                        new StateDTO()
                        {
                            StateId=26,
                            StateCode="Tamil Nadu",
                            StateName="Tamil Nadu",
                            CountryId=1
                        },
                        //Telangana
                        new StateDTO()
                        {
                            StateId=27,
                            StateCode="Telangana",
                            StateName="Telangana",
                            CountryId=1
                        },
                        //Tripura
                        new StateDTO()
                        {
                            StateId=28,
                            StateCode="Tripura",
                            StateName="Tripura",
                            CountryId=1
                        },
                        //Uttar Pradesh
                        new StateDTO()
                        {
                            StateId=29,
                            StateCode="Uttar Pradesh",
                            StateName="Uttar Pradesh",
                            CountryId=1
                        },
                        //Uttarakhand
                        new StateDTO()
                        {
                            StateId=30,
                            StateCode="Uttarakhand",
                            StateName="Uttarakhand",
                            CountryId=1
                        },
                        //West Bengal
                        new StateDTO()
                        {
                            StateId=31,
                            StateCode="West Bengal",
                            StateName="West Bengal",
                            CountryId=1
                        },
                        //Other Union Territories
                        new StateDTO()
                        {
                            StateId=33,
                            StateCode="Other Union Territories",
                            StateName="Other Union Territories",
                            CountryId=1
                        }
                    }
                }
              
            };
            return countries;
        }

        public List<PartnerTypeDTO> GetPartnerTypes()
        {
            List<PartnerTypeDTO> partnerTypeDtos =
                (from u in _userContext.partnerTypePrioritys
                 select new PartnerTypeDTO()
                 {
                     PartnerTypeId = u.PartnerTypeCode,
                     PartnerTypeName = u.PartnerTypeName
                 }).ToList();

            return partnerTypeDtos;
        }

        public List<PartnerDTO> GetPartnerCodes(List<string> partnerType, string subscriberId)
        {
            string partnerTypeID = string.Empty;
            List<PartnerDTO> partner = new List<PartnerDTO>();
            List<PartnerTypePriorityDTO> prioritylist = new List<PartnerTypePriorityDTO>();
            if (partnerType != null)
            {
                foreach (string partnerTypename in partnerType)
                {
                    PartnerTypePriorityDTO priorityList = GetPartnerTypePriority(partnerTypename);
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
                    partnerTypeID = prioritylist.Find(t => t.PriorityNo == minpriorityNo).PartnerTypeCode.ToString();


                }
            }

            if (partnerTypeID != null)
            {
                partner = (from p in _userContext.Partners.Where(t => t.PartnerType == partnerTypeID && t.SubscriptionMembers.Any(d=>d.PartnerId == subscriberId))
                           select new PartnerDTO
                           {
                               PartnerId = p.PartnerId,
                               PartnerType = p.PartnerType,
                               PartnerCode = p.PartnerCode
                           }).ToList();

            }
            return partner;
        }

        public PortDTO GetPortByPortCode(string portCode)
        {
            PortDTO port = (from p in GetPorts()
                            where p.PortCode == portCode
                            select p).FirstOrDefault();
            return port;
        }

        public PartnerTypeDTO GetPartnerTypeName(string partnerType)
        {
            PartnerTypeDTO partnerTypeDto =
                (from t in GetPartnerTypes().Where(p => p.PartnerTypeId == partnerType) select t).FirstOrDefault();
            return partnerTypeDto;
        }

        public string GetPartnerTypeNames(string partnerType)
        {
            string partnerTypeDto = (from t in GetPartnerTypes().Where(p => p.PartnerTypeId == partnerType) select t.PartnerTypeName).FirstOrDefault();
            return partnerTypeDto;

        }

        public PartnerTypePriorityDTO GetPartnerTypePriority(string partnerType)
        {
            PartnerTypePriorityDTO partnerPriorityDto = (from t in _userContext.partnerTypePrioritys.Where(t => t.PartnerTypeCode == partnerType)
                                                         select new PartnerTypePriorityDTO
                                                         {
                                                             PriorityNo = t.PriorityNo,
                                                             PartnerTypeCode = t.PartnerTypeCode,
                                                             PartnerTypeName = t.PartnerTypeName,
                                                             IsDeleted = t.IsDeleted


                                                         }).FirstOrDefault();
            return partnerPriorityDto;

        }

        public List<PartnerTypePriorityDTO> GetPartnerTypePriorityList(List<string> partnerTypesList)
        {
            return (from t in _userContext.partnerTypePrioritys.Where(t => partnerTypesList.Contains(t.PartnerTypeCode))
                                                         select new PartnerTypePriorityDTO
                                                         {
                                                             PriorityNo = t.PriorityNo,
                                                             PartnerTypeCode = t.PartnerTypeCode,
                                                             PartnerTypeName = t.PartnerTypeName,
                                                             IsDeleted = t.IsDeleted
                                                         }).ToList();
        }

        public List<PartnerDTO> GetPartners(List<string> partnerCodes)
        {
            return _userContext.Partners.Where(t => partnerCodes.Contains(t.PartnerCode.ToUpper())).ToList().MapToDTO();
        }

        public List<PartnerDTO> GetPartnersByPartnerType(string partnerType)
        {
            return _userContext.Partners.Where(t => t.PartnerType.Equals(partnerType)).OrderBy(c => c.PartnerName).ToList().MapToDTO();
        }
    }
}
