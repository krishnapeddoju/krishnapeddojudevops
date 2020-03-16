using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public class ApplicationEntityRepository : IApplicationEntityRepository
    {
        private readonly IUserContext _userContext;
        public ApplicationEntityRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public List<ApplicationEntityDTO> GetEntities(int appId)
        {
            #region AllApplicationEntities
            List<ApplicationEntityDTO> allApplicationEntities = new List<ApplicationEntityDTO>()
            {
                new ApplicationEntityDTO()
                {
                    ApplicationEntityId = "VV",
                    ApplicationId = 2,
                    EntityCode = "VesselVoyage",
                    EntityName = "Vessel Voyage",
                    Url = "",
                    applicationEntityFunctions = new List<ApplicationEntityFunctionDTO>()
                    {
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "VV",
                            FunctionCode = "eGate-VesselVoyage-Create",
                            FunctionName = "Create Vessel Voyage",
                            FunctionUrl = "eGate/VesselVoyage",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 1
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "VV",
                            FunctionCode = "eGate-VesselVoyage-List",
                            FunctionName = "Vessel Voyages",
                            FunctionUrl = "eGate/VesselVoyages",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 2
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "VV",
                            FunctionCode = "eGate-VesselVoyage-View",
                            FunctionName = "View Vessel Voyage",
                            FunctionUrl = "eGate/VesselVoyages/{VoyageId}",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 3
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "VV",
                            FunctionCode = "eGate-VesselVoyage-AllocateToCP",
                            FunctionName = "Allocate To CP",
                            FunctionUrl = "eGate/ALlocateToCP",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 4
                        }
                    }
                },
                new ApplicationEntityDTO()
                {
                    ApplicationEntityId = "Form6E",
                    ApplicationId = 2,
                    EntityCode = "ExportFormRoadTransport",
                    EntityName = "Form 6E",
                    Url = "",
                    applicationEntityFunctions = new List<ApplicationEntityFunctionDTO>()
                    {
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "Form6E",
                            FunctionCode = "eGate-Form6E-Generate",
                            FunctionName = "Generate Form 6E",
                            FunctionUrl = "eGate/Form6E",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 1
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "Form6E",
                            FunctionCode = "eGate-Form6E-AssignToCHA",
                            FunctionName = "Generate Form 6E",
                            FunctionUrl = "eGate/Form6Es/{Form6EId}/AssignCHA",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 2
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "Form6E",
                            FunctionCode = "eGate-Form6E-SelectCustomsClearance",
                            FunctionName = "Select customs clearnace",
                            FunctionUrl = "eGate/Form6Es/{Form6EId}/SelectCustomsClearance",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 3
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "Form6E",
                            FunctionCode = "eGate-Form6E-Approve",
                            FunctionName = "Approve Form 6E",
                            FunctionUrl = "eGate/Form6Es/{Form6EId}/Appoval",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 4
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "Form6E",
                            FunctionCode = "eGate-Form6E-ApproveMultiple",
                            FunctionName = "Approve Form 6E (Multiple)",
                            FunctionUrl = "eGate/Form6Es/Approval",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 5
                        }
                    }
                },
                new ApplicationEntityDTO()
                {
                    ApplicationEntityId = "Form8",
                    ApplicationId = 2,
                    EntityCode = "ExportFormRailTransport",
                    EntityName = "Form 8",
                    Url = "",
                    applicationEntityFunctions = new List<ApplicationEntityFunctionDTO>()
                    {
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "",
                            FunctionCode = "",
                            FunctionName = "",
                            FunctionUrl = "",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 1
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "",
                            FunctionCode = "",
                            FunctionName = "",
                            FunctionUrl = "",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 1
                        }
                    }
                },
                new ApplicationEntityDTO()
                {
                    ApplicationEntityId = "Partner",
                    ApplicationId = 2,
                    EntityCode = "Partner",
                    EntityName = "Partner",
                    Url = "",
                    applicationEntityFunctions = new List<ApplicationEntityFunctionDTO>()
                    {
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "Partner",
                            FunctionCode = "UAM-Partner-Add",
                            FunctionName = "Add Partner",
                            FunctionUrl = "uam/Partner",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 1
                        }
                    }
                },
                new ApplicationEntityDTO()
                {
                    ApplicationEntityId = "User",
                    ApplicationId = 2,
                    EntityCode = "User",
                    EntityName = "User",
                    Url = "",
                    applicationEntityFunctions = new List<ApplicationEntityFunctionDTO>()
                    {
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "User",
                            FunctionCode = "UAM-User-Add",
                            FunctionName = "Add User",
                            FunctionUrl = "uam/User",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 1
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "User",
                            FunctionCode = "UAM-User-Search",
                            FunctionName = "Search Users",
                            FunctionUrl = "uam/Users/Search",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 2
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "User",
                            FunctionCode = "UAM-User-ResetPwd",
                            FunctionName = "Reset Password",
                            FunctionUrl = "uam/ResetPwd",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 3
                        }
                    }
                },
                new ApplicationEntityDTO()
                {
                    ApplicationEntityId = "Role",
                    ApplicationId = 2,
                    EntityCode = "Role",
                    EntityName = "Role",
                    Url = "",
                    applicationEntityFunctions = new List<ApplicationEntityFunctionDTO>()
                    {
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "Role",
                            FunctionCode = "UAM-Role-Add",
                            FunctionName = "Add Role",
                            FunctionUrl = "uam/Role",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 1
                        }
                    }
                }
            };
            #endregion

            List<ApplicationEntityDTO> applicationEntityDtos = (from applicationEntity in allApplicationEntities
                select new ApplicationEntityDTO
                {
                    ApplicationEntityId = applicationEntity.ApplicationEntityId,
                    EntityCode = applicationEntity.EntityCode,
                    EntityName = applicationEntity.EntityName,
                    Url = applicationEntity.Url
                }).ToList();

            return applicationEntityDtos;
        }

        public ApplicationEntityDTO GetEntity(int applicationId, string applicationEntityCode)
        {
            throw new NotImplementedException();
        }

        public ApplicationEntityDTO GetEntityForApplicationEntityId(string applicationEntityId)
        {
            #region AllApplicationEntities
            List<ApplicationEntityDTO> allApplicationEntities = new List<ApplicationEntityDTO>()
            {
                new ApplicationEntityDTO()
                {
                    ApplicationEntityId = "VV",
                    ApplicationId = 2,
                    EntityCode = "VesselVoyage",
                    EntityName = "Vessel Voyage",
                    Url = "",
                    applicationEntityFunctions = new List<ApplicationEntityFunctionDTO>()
                    {
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "VV",
                            FunctionCode = "eGate-VesselVoyage-Create",
                            FunctionName = "Create Vessel Voyage",
                            FunctionUrl = "eGate/VesselVoyage",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 1
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "VV",
                            FunctionCode = "eGate-VesselVoyage-List",
                            FunctionName = "Vessel Voyages",
                            FunctionUrl = "eGate/VesselVoyages",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 2
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "VV",
                            FunctionCode = "eGate-VesselVoyage-View",
                            FunctionName = "View Vessel Voyage",
                            FunctionUrl = "eGate/VesselVoyages/{VoyageId}",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 3
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "VV",
                            FunctionCode = "eGate-VesselVoyage-AllocateToCP",
                            FunctionName = "Allocate To CP",
                            FunctionUrl = "eGate/ALlocateToCP",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 4
                        }
                    }
                },
                new ApplicationEntityDTO()
                {
                    ApplicationEntityId = "Form6E",
                    ApplicationId = 2,
                    EntityCode = "ExportFormRoadTransport",
                    EntityName = "Form 6E",
                    Url = "",
                    applicationEntityFunctions = new List<ApplicationEntityFunctionDTO>()
                    {
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "Form6E",
                            FunctionCode = "eGate-Form6E-Generate",
                            FunctionName = "Generate Form 6E",
                            FunctionUrl = "eGate/Form6E",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 1
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "Form6E",
                            FunctionCode = "eGate-Form6E-AssignToCHA",
                            FunctionName = "Generate Form 6E",
                            FunctionUrl = "eGate/Form6Es/{Form6EId}/AssignCHA",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 2
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "Form6E",
                            FunctionCode = "eGate-Form6E-SelectCustomsClearance",
                            FunctionName = "Select customs clearnace",
                            FunctionUrl = "eGate/Form6Es/{Form6EId}/SelectCustomsClearance",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 3
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "Form6E",
                            FunctionCode = "eGate-Form6E-Approve",
                            FunctionName = "Approve Form 6E",
                            FunctionUrl = "eGate/Form6Es/{Form6EId}/Appoval",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 4
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "Form6E",
                            FunctionCode = "eGate-Form6E-ApproveMultiple",
                            FunctionName = "Approve Form 6E (Multiple)",
                            FunctionUrl = "eGate/Form6Es/Approval",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 5
                        }
                    }
                },
                new ApplicationEntityDTO()
                {
                    ApplicationEntityId = "Form8",
                    ApplicationId = 2,
                    EntityCode = "ExportFormRailTransport",
                    EntityName = "Form 8",
                    Url = "",
                    applicationEntityFunctions = new List<ApplicationEntityFunctionDTO>()
                    {
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "",
                            FunctionCode = "",
                            FunctionName = "",
                            FunctionUrl = "",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 1
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "",
                            FunctionCode = "",
                            FunctionName = "",
                            FunctionUrl = "",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 1
                        }
                    }
                },
                new ApplicationEntityDTO()
                {
                    ApplicationEntityId = "Partner",
                    ApplicationId = 2,
                    EntityCode = "Partner",
                    EntityName = "Partner",
                    Url = "",
                    applicationEntityFunctions = new List<ApplicationEntityFunctionDTO>()
                    {
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "Partner",
                            FunctionCode = "UAM-Partner-Add",
                            FunctionName = "Add Partner",
                            FunctionUrl = "uam/Partner",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 1
                        }
                    }
                },
                new ApplicationEntityDTO()
                {
                    ApplicationEntityId = "User",
                    ApplicationId = 2,
                    EntityCode = "User",
                    EntityName = "User",
                    Url = "",
                    applicationEntityFunctions = new List<ApplicationEntityFunctionDTO>()
                    {
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "User",
                            FunctionCode = "UAM-User-Add",
                            FunctionName = "Add User",
                            FunctionUrl = "uam/User",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 1
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "User",
                            FunctionCode = "UAM-User-Search",
                            FunctionName = "Search Users",
                            FunctionUrl = "uam/Users/Search",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 2
                        },
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "User",
                            FunctionCode = "UAM-User-ResetPwd",
                            FunctionName = "Reset Password",
                            FunctionUrl = "uam/ResetPwd",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 3
                        }
                    }
                },
                new ApplicationEntityDTO()
                {
                    ApplicationEntityId = "Role",
                    ApplicationId = 2,
                    EntityCode = "Role",
                    EntityName = "Role",
                    Url = "",
                    applicationEntityFunctions = new List<ApplicationEntityFunctionDTO>()
                    {
                        new ApplicationEntityFunctionDTO()
                        {
                            ApplicationEntityId = "Role",
                            FunctionCode = "UAM-Role-Add",
                            FunctionName = "Add Role",
                            FunctionUrl = "uam/Role",
                            ApiUrl = "",
                            IsMenuItem = "Y",
                            Order = 1
                        }
                    }
                }
            };
            #endregion

            ApplicationEntityDTO applicationEntityDto =
                (from applicationEntity in allApplicationEntities.Where(e => e.ApplicationEntityId == applicationEntityId)
                 select applicationEntity
                    ).FirstOrDefault();
            return applicationEntityDto;
        }

        public List<ApplicationEntityDTO> GetEntitiesForModule(int applicationId, string moduleId)
        {
            throw new NotImplementedException();
        }

        public void AddApplicationEntity(ApplicationEntity appEntity)
        {
            throw new NotImplementedException();
        }

        public void UpdateApplicationEntity(ApplicationEntity applicationEntity)
        {
            throw new NotImplementedException();
        }
    }
}
