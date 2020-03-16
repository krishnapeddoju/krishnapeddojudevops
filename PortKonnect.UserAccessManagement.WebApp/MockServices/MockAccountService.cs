using System.Collections.Generic;
using PortKonnect.UserAccessManagement.WebApp.MockServices.Interfaces;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.WebApp.MockServices
{
    public class MockAccountService : IMockAccountService
    {
        public List<MenuModuleDTO> GetMenuForUser(int applicationId, string userName)
        {
            #region Modules
            List<MenuModuleDTO> modules = new List<MenuModuleDTO>() 
            {
                #region Module1
                new MenuModuleDTO
                {
                    ModuleId="1",
                    ModuleName="Voyage",
                    AppEntities=new List<MenuEntityDTO>()
                    {
                        new MenuEntityDTO
                        {
                            AppEntityId="11",
                            AppEntityName="Vessel Voyage",
                            EntityUrl="",
                            AppFunctions=new List<MenuFunctionDTO>()
                            {
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-VesselVoyage-Create",
                                    FunctioName="Create",
                                    Url="VesselVoyages"
                                },
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-VesselVoyage-List",
                                    FunctioName="List",
                                    Url=""
                                },
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-VesselVoyage-View",
                                    FunctioName="View",
                                    Url="VesselVoyages"
                                },
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-VesselVoyage-AllocateToCP",
                                    FunctioName="AllocateToCP",
                                    Url=""
                                }
                            }
                        }
                    }
                },
                #endregion

                #region Module2
                new MenuModuleDTO
                {
                    ModuleId="2",
                    ModuleName="Export",
                    AppEntities=new List<MenuEntityDTO>()
                    {
                        new MenuEntityDTO
                        {
                            AppEntityId="21",
                            AppEntityName="Form 6E",
                            EntityUrl="",
                            AppFunctions=new List<MenuFunctionDTO>()
                            {
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-Form6E-Generate",
                                    FunctioName="Generate",
                                    Url="VesselVoyages"
                                },
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-Form6E-AssignToCHA",
                                    FunctioName="AssignToCHA",
                                    Url=""
                                },
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-Form6E-SelectCustomsClearance",
                                    FunctioName="Select Customs Clearance",
                                    Url="VesselVoyages"
                                },
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-Form6E-Approve",
                                    FunctioName="Approve",
                                    Url=""
                                },
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-Form6E-ApproveMultiple",
                                    FunctioName="Approve Multiple",
                                    Url=""
                                }
                            }
                        },
                        new MenuEntityDTO
                        {
                            AppEntityId="22",
                            AppEntityName="Form 8",
                            EntityUrl="",
                            AppFunctions=new List<MenuFunctionDTO>()
                            {
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-Form 8-Generate",
                                    FunctioName="Generate",
                                    Url="VesselVoyages"
                                },
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-Form 8-Print",
                                    FunctioName="Print",
                                    Url=""
                                },
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-Form 8-Endorse to Containers",
                                    FunctioName="Endorse to Containers",
                                    Url="VesselVoyages"
                                },
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-Form 8-Upload Endorsed Copy",
                                    FunctioName="Upload Endorsed Copy",
                                    Url=""
                                },
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-Form 8-Generate Final Advice",
                                    FunctioName="Generate Final Advice",
                                    Url=""
                                },
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-Form 8-View Final Advice",
                                    FunctioName="View Final Advice",
                                    Url=""
                                }
                            }
                        },
                        new MenuEntityDTO
                        {
                            AppEntityId="23",
                            AppEntityName="Shutout Container",
                            EntityUrl="",
                            AppFunctions=new List<MenuFunctionDTO>()
                            {
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-ShutoutContainer-Map Shutout & unassigned Containers to New Voyage",
                                    FunctioName="Map Shutout & unassigned Containers to New Voyage",
                                    Url="VesselVoyages"
                                }
                            }
                        },
                        new MenuEntityDTO
                        {
                            AppEntityId="24",
                            AppEntityName="EAL",
                            EntityUrl="",
                            AppFunctions=new List<MenuFunctionDTO>()
                            {
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-EAL-New Change Request",
                                    FunctioName="New Change Request",
                                    Url="VesselVoyages"
                                },
                                new MenuFunctionDTO
                                {
                                    FunctionCode="eGate-EAL-Approve New Change Request",
                                    FunctioName="Approve New Change Request",
                                    Url=""
                                }
                            }
                        }
                    }
                },
                #endregion

                #region Module3
                new MenuModuleDTO
                {
                    ModuleId="3",
                    ModuleName="Import",
                    AppEntities=new List<MenuEntityDTO>()
                    {
                        new MenuEntityDTO
                        {
                            AppEntityId="31",
                            AppEntityName="Form 6I",
                            EntityUrl="",
                            AppFunctions = null
                            #region Commented
                            //AppFunctions=new List<MenuFunctionDTO>()
                            //{
                            //    new MenuFunctionDTO
                            //    {
                            //        FunctionCode="LI",
                            //        FunctioName="List",
                            //        Url="VesselVoyages"
                            //    },
                            //    new MenuFunctionDTO
                            //    {
                            //        FunctionCode="CR",
                            //        FunctioName="Create",
                            //        Url=""
                            //    }
                            //}
                            #endregion
                        },
                        new MenuEntityDTO
                        {
                            AppEntityId="32",
                            AppEntityName="Form 10",
                            EntityUrl="",
                            AppFunctions = null
                            #region Commented
                            //AppFunctions=new List<MenuFunctionDTO>()
                            //{
                            //    new MenuFunctionDTO
                            //    {
                            //        FunctionCode="LI",
                            //        FunctioName="List",
                            //        Url="VesselVoyages"
                            //    },
                            //    new MenuFunctionDTO
                            //    {
                            //        FunctionCode="CR",
                            //        FunctioName="Create",
                            //        Url=""
                            //    }
                            //}
                            #endregion
                        },
                        new MenuEntityDTO
                        {
                            AppEntityId="33",
                            AppEntityName="SMTP",
                            EntityUrl="",
                            AppFunctions = null
                            #region Commented
                            //AppFunctions=new List<MenuFunctionDTO>()
                            //{
                            //    new MenuFunctionDTO
                            //    {
                            //        FunctionCode="LI",
                            //        FunctioName="List",
                            //        Url="VesselVoyages"
                            //    },
                            //    new MenuFunctionDTO
                            //    {
                            //        FunctionCode="CR",
                            //        FunctioName="Create",
                            //        Url=""
                            //    }
                            //}
                            #endregion
                        },
                        new MenuEntityDTO
                        {
                            AppEntityId="34",
                            AppEntityName="Form 12",
                            EntityUrl="",
                            AppFunctions = null
                            #region Commented
                            //AppFunctions=new List<MenuFunctionDTO>()
                            //{
                            //    new MenuFunctionDTO
                            //    {
                            //        FunctionCode="LI",
                            //        FunctioName="List",
                            //        Url="VesselVoyages"
                            //    },
                            //    new MenuFunctionDTO
                            //    {
                            //        FunctionCode="CR",
                            //        FunctioName="Create",
                            //        Url=""
                            //    }
                            //}
                            #endregion
                        }
                    }
                },
                #endregion

                #region Module4
                new MenuModuleDTO
                {
                    ModuleId="4",
                    ModuleName="Administration",
                    AppEntities=new List<MenuEntityDTO>()
                    {
                        new MenuEntityDTO
                        {
                            AppEntityId="41",
                            AppEntityName="Partners",
                            EntityUrl="",
                            AppFunctions=new List<MenuFunctionDTO>()
                            {
                                new MenuFunctionDTO
                                {
                                    FunctionCode="UAM-Partner-Add",
                                    FunctioName="Add",
                                    Url="Partner"
                                },
                                new MenuFunctionDTO
                                {
                                    FunctionCode="UAM-Partner-View",
                                    FunctioName="View",
                                    Url=""
                                },
                                new MenuFunctionDTO
                                {
                                    FunctionCode="UAM-Partner-List",
                                    FunctioName="List",
                                    Url=""
                                }
                            }
                        },
                        new MenuEntityDTO
                        {
                            AppEntityId="42",
                            AppEntityName="Users",
                            EntityUrl="",
                            AppFunctions=new List<MenuFunctionDTO>()
                            {
                                new MenuFunctionDTO
                                {
                                    FunctionCode="UAM-User-Add",
                                    FunctioName="Add",
                                    Url="VesselVoyages"
                                },
                                new MenuFunctionDTO
                                {
                                    FunctionCode="UAM-User-Search",
                                    FunctioName="Search",
                                    Url=""
                                },
                                new MenuFunctionDTO
                                {
                                    FunctionCode="UAM-User-ResetPwd",
                                    FunctioName="Reset Password",
                                    Url=""
                                }
                            }
                        },
                        new MenuEntityDTO
                        {
                            AppEntityId="43",
                            AppEntityName="Roles",
                            EntityUrl="",
                            AppFunctions=new List<MenuFunctionDTO>()
                            {
                                new MenuFunctionDTO
                                {
                                    FunctionCode="UAM-User-Add",
                                    FunctioName="Add",
                                    Url="VesselVoyages"
                                }
                            }
                        }
                    }
                },
                #endregion

                #region Module5
                new MenuModuleDTO
                {
                    ModuleId="5",
                    ModuleName="MIS",
                    AppEntities = null
                },
                #endregion
            };
            return modules;
            #endregion

            #region Commented
            //List<ApplicationModule> modules = new List<ApplicationModule>();

            //var modules1 = (from m in GetAllApplicationModules()
            //                join e in GetApplicationModuleEntities()
            //                              on m.ModuleId equals e.ModuleId
            //                join rp in GetRoleFunctions()
            //                              on e.ApplicationEntityId equals rp.ApplicationEntityId
            //                join ur in GetRoles()
            //                              on rp.RoleID equals ur.RoleID
            //                join us in _unitOfWork.Repository<User>().Queryable() on ur.UserID equals us.UserID
            //                where ur.UserID == userId && e.HasMenuItem == "Y" && ur.RecordStatus == RecordStatus.Active && rp.RecordStatus == RecordStatus.Active
            //                && us.IsFirstTimeLogin == "N"
            //                orderby m.OrderNo
            //                select m).Distinct().ToList();



            //foreach (var item in module)
            //{
            //    List<Module> submodules1 = (from m in _unitOfWork.Repository<Module>().Queryable()
            //                                join e in _unitOfWork.Repository<Entity>().Queryable()
            //                                           on m.ModuleID equals e.ModuleID
            //                                join rp in _unitOfWork.Repository<RolePrivilege>().Queryable()
            //                                           on e.EntityID equals rp.EntityID
            //                                join ur in _unitOfWork.Repository<UserRole>().Queryable()
            //                                           on rp.RoleID equals ur.RoleID
            //                                where ur.UserID == userId && m.ParentModuleID == item.ModuleID && ur.RecordStatus == RecordStatus.Active && rp.RecordStatus == RecordStatus.Active && m.RecordStatus == RecordStatus.Active
            //                                orderby m.OrderNo
            //                                select m).Distinct().ToList();

            //    moduleVo = submodules1.MapToListDto();
            //    submodules1 = moduleVo.MapToListEntity();

            //    List<Module> submodulesm = new List<Module>();
            //    foreach (var sm in submodules1)
            //    {
            //        // to get the entities of the module
            //        var entity = (from e in _unitOfWork.Repository<Entity>().Queryable()
            //                      join rp in _unitOfWork.Repository<RolePrivilege>().Queryable()
            //                                on e.EntityID equals rp.EntityID
            //                      join ur in _unitOfWork.Repository<UserRole>().Queryable()
            //                                on rp.RoleID equals ur.RoleID
            //                      where ur.UserID == userId && e.ModuleID == sm.ModuleID && e.HasMenuItem == "Y" && ur.RecordStatus == RecordStatus.Active && rp.RecordStatus == RecordStatus.Active
            //                      orderby e.OrderNo
            //                      select e).ToList();
            //        entity = entity.Distinct().ToList();

            //        List<EntityVO> entityVo = entity.MapToListDto();
            //        entity = entityVo.MapToListEntity();

            //        submodulesm.Add(new Module()
            //        {
            //            ModuleID = sm.ModuleID,
            //            ParentModuleID = sm.ParentModuleID,
            //            ModuleName = sm.ModuleName,
            //            Entities = entity
            //        });
            //    }

            //    modules.Add(new Module()
            //    {
            //        ModuleID = item.ModuleID,
            //        ModuleName = item.ModuleName,
            //        ParentModuleID = item.ParentModuleID,
            //        Module1 = submodulesm
            //    });
            //}

            //return modules;
            #endregion
           
        }

        public List<ApplicationModuleDTO> GetAllApplicationModules()
        {
            List<ApplicationModuleDTO> allApplicationModuleDtos = new List<ApplicationModuleDTO>()
            {
                new ApplicationModuleDTO()
                {
                    ApplicationId = 2,
                    ModuleId = "EX",
                    ModuleName = "Export",
                    ParentModuleId = "",
                    Order = 2,
                    Url = "",
                    ModuleEntities = new List<ApplicationModuleEntityDTO>()
                    {
                        new ApplicationModuleEntityDTO()
                        {
                            ModuleId = "EX",
                            ApplicationEntityId = "Form6E",
                            Order = 1
                        },
                        new ApplicationModuleEntityDTO()
                        {
                            ModuleId = "EX",
                            ApplicationEntityId = "Form8",
                            Order = 2
                        },
                        new ApplicationModuleEntityDTO()
                        {
                            ModuleId = "EX",
                            ApplicationEntityId = "Form8GateIn",
                            Order = 3
                        }
                    }
                },
                new ApplicationModuleDTO()
                {
                    ApplicationId = 2,
                    ModuleId = "IM",
                    ModuleName = "Import",
                    ParentModuleId = "",
                    Order = 3,
                    Url = "",
                    ModuleEntities = new List<ApplicationModuleEntityDTO>()
                    {
                        new ApplicationModuleEntityDTO()
                        {
                            ModuleId = "",
                            ApplicationEntityId = "",
                            Order = 1
                        },
                        new ApplicationModuleEntityDTO()
                        {
                            ModuleId = "",
                            ApplicationEntityId = "",
                            Order = 2
                        }
                    }
                },
                new ApplicationModuleDTO()
                {
                    ApplicationId = 2,
                    ModuleId = "VV",
                    ModuleName = "Vessel Voyage",
                    ParentModuleId = "",
                    Order = 1,
                    Url = "",
                    ModuleEntities = new List<ApplicationModuleEntityDTO>()
                    {
                        new ApplicationModuleEntityDTO()
                        {
                            ModuleId = "VV",
                            ApplicationEntityId = "VV",
                            Order = 1
                        }
                    }
                },
                new ApplicationModuleDTO()
                {
                    ApplicationId = 2,
                    ModuleId = "EAL",
                    ModuleName = "EAL",
                    ParentModuleId = "",
                    Order = 4,
                    Url = "",
                    ModuleEntities = new List<ApplicationModuleEntityDTO>()
                    {
                        new ApplicationModuleEntityDTO()
                        {
                            ModuleId = "",
                            ApplicationEntityId = "",
                            Order = 1
                        },
                        new ApplicationModuleEntityDTO()
                        {
                            ModuleId = "",
                            ApplicationEntityId = "",
                            Order = 2
                        }
                    }
                },
                new ApplicationModuleDTO()
                {
                    ApplicationId = 2,
                    ModuleId = "Admin",
                    ModuleName = "Administration",
                    ParentModuleId = "",
                    Order = 5,
                    Url = "",
                    ModuleEntities = new List<ApplicationModuleEntityDTO>()
                    {
                        new ApplicationModuleEntityDTO()
                        {
                            ModuleId = "Admin",
                            ApplicationEntityId = "Partner",
                            Order = 1
                        },
                        new ApplicationModuleEntityDTO()
                        {
                            ModuleId = "",
                            ApplicationEntityId = "",
                            Order = 2
                        }
                    }
                }
            };
            return allApplicationModuleDtos;
        }

        public List<ApplicationModuleEntityDTO> GetApplicationModuleEntities()
        {
            List<ApplicationModuleEntityDTO> allApplicationModuleEntities = new List<ApplicationModuleEntityDTO>()
            {
                new ApplicationModuleEntityDTO()
                {
                    ModuleId = "EX",
                    ApplicationEntityId = "Form6E",
                    Order = 1
                },
                new ApplicationModuleEntityDTO()
                {
                    ModuleId = "EX",
                    ApplicationEntityId = "Form8",
                    Order = 2
                },
                new ApplicationModuleEntityDTO()
                {
                    ModuleId = "EX",
                    ApplicationEntityId = "Form8GateIn",
                    Order = 3
                },
                new ApplicationModuleEntityDTO()
                {
                    ModuleId = "VV",
                    ApplicationEntityId = "VV",
                    Order = 1
                }
            };
            return allApplicationModuleEntities;
        }

        public List<ApplicationEntityDTO> GetApplicationEntities()
        {
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
            return allApplicationEntities;
        }

        public List<ApplicationEntityFunctionDTO> GetApplicationEntityFunctions()
        {
            List<ApplicationEntityFunctionDTO> applicationEntityFunctions = new List<ApplicationEntityFunctionDTO>()
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
                    IsMenuItem = "N",
                    Order = 3
                },
                new ApplicationEntityFunctionDTO()
                {
                    ApplicationEntityId = "VV",
                    FunctionCode = "eGate-VesselVoyage-AllocateToCP",
                    FunctionName = "Allocate To CP",
                    FunctionUrl = "eGate/ALlocateToCP",
                    ApiUrl = "",
                    IsMenuItem = "N",
                    Order = 4
                },
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
                },
                new ApplicationEntityFunctionDTO()
                {
                    ApplicationEntityId = "Partner",
                    FunctionCode = "UAM-Partner-Add",
                    FunctionName = "Add Partner",
                    FunctionUrl = "uam/Partner",
                    ApiUrl = "",
                    IsMenuItem = "Y",
                    Order = 1
                },
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
                },
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
            };
            return applicationEntityFunctions;
        }

        public List<RoleDTO> GetRoles()
        {
            List<RoleDTO> roleDtos = new List<RoleDTO>()
            {
                new RoleDTO()
                {
                    RoleId = "TOAdmin",
                    RoleName = "Terminal Operator Admin",
                    ApplicationId = 2,
                    SubscriberId = "2",
                    RoleFunctions = new List<RoleFunctionDTO>()
                    {
                        new RoleFunctionDTO()
                        {
                            RoleId = "TOAdmin",
                            ApplicationEntityId = "VV",
                            FunctionCode = "eGate-VesselVoyage-Create"
                        },
                        new RoleFunctionDTO()
                        {
                            RoleId = "TOAdmin",
                            ApplicationEntityId = "VV",
                            FunctionCode = "eGate-VesselVoyage-List"
                        },
                        new RoleFunctionDTO()
                        {
                            RoleId = "TOAdmin",
                            ApplicationEntityId = "VV",
                            FunctionCode = "eGate-VesselVoyage-View"
                        },
                        new RoleFunctionDTO()
                        {
                            RoleId = "TOAdmin",
                            ApplicationEntityId = "VV",
                            FunctionCode = "eGate-VesselVoyage-AllocateToCP"
                        }
                    }
                },
                new RoleDTO()
                {
                    RoleId = "VOA",
                    RoleName = "VOA",
                    ApplicationId = 2,
                    SubscriberId = "2",
                    RoleFunctions = new List<RoleFunctionDTO>()
                    {
                        new RoleFunctionDTO()
                        {
                            RoleId = "VOA",
                            ApplicationEntityId = "VV",
                            FunctionCode = "eGate-VesselVoyage-Create"
                        }
                    }
                },
                new RoleDTO()
                {
                    RoleId = "COA",
                    RoleName = "COA",
                    ApplicationId = 2,
                    SubscriberId = "2",
                    RoleFunctions = new List<RoleFunctionDTO>()
                    {
                        new RoleFunctionDTO()
                        {
                            RoleId = "COA",
                            ApplicationEntityId = "Form6E",
                            FunctionCode = "eGate-Form6E-Generate"
                        },
                        new RoleFunctionDTO()
                        {
                            RoleId = "COA",
                            ApplicationEntityId = "Form6E",
                            FunctionCode = "eGate-Form6E-AssignToCHA"
                        },
                        new RoleFunctionDTO()
                        {
                            RoleId = "COA",
                            ApplicationEntityId = "Form6E",
                            FunctionCode = "eGate-Form6E-Approve"
                        },
                        new RoleFunctionDTO()
                        {
                            RoleId = "COA",
                            ApplicationEntityId = "Form6E",
                            FunctionCode = "eGate-Form6E-ApproveMultiple"
                        }
                    }
                },
                new RoleDTO()
                {
                    RoleId = "CHA",
                    RoleName = "CHA",
                    ApplicationId = 2,
                    SubscriberId = "2",
                    RoleFunctions = new List<RoleFunctionDTO>()
                    {
                        new RoleFunctionDTO()
                        {
                            RoleId = "CHA",
                            ApplicationEntityId = "Form6E",
                            FunctionCode = "eGate-Form6E-SelectCustomsClearance"
                        }
                    }
                }
            };
            return roleDtos;
        }

        public List<RoleFunctionDTO> GetRoleFunctions()
        {
            List<RoleFunctionDTO> roleFunctionDtos = new List<RoleFunctionDTO>()
            {
                new RoleFunctionDTO()
                {
                    RoleId = "TOAdmin",
                    ApplicationEntityId = "VV",
                    FunctionCode = "eGate-VesselVoyage-Create"
                },
                new RoleFunctionDTO()
                {
                    RoleId = "TOAdmin",
                    ApplicationEntityId = "VV",
                    FunctionCode = "eGate-VesselVoyage-List"
                },
                new RoleFunctionDTO()
                {
                    RoleId = "TOAdmin",
                    ApplicationEntityId = "VV",
                    FunctionCode = "eGate-VesselVoyage-View"
                },
                new RoleFunctionDTO()
                {
                    RoleId = "TOAdmin",
                    ApplicationEntityId = "VV",
                    FunctionCode = "eGate-VesselVoyage-AllocateToCP"
                },
                new RoleFunctionDTO()
                {
                    RoleId = "VOA",
                    ApplicationEntityId = "VV",
                    FunctionCode = "eGate-VesselVoyage-Create"
                },
                new RoleFunctionDTO()
                {
                    RoleId = "COA",
                    ApplicationEntityId = "Form6E",
                    FunctionCode = "eGate-Form6E-Generate"
                },
                new RoleFunctionDTO()
                {
                    RoleId = "COA",
                    ApplicationEntityId = "Form6E",
                    FunctionCode = "eGate-Form6E-AssignToCHA"
                },new RoleFunctionDTO()
                {
                    RoleId = "COA",
                    ApplicationEntityId = "Form6E",
                    FunctionCode = "eGate-Form6E-Approve"
                },
                new RoleFunctionDTO()
                {
                    RoleId = "COA",
                    ApplicationEntityId = "Form6E",
                    FunctionCode = "eGate-Form6E-ApproveMultiple"
                },
                new RoleFunctionDTO()
                {
                    RoleId = "CHA",
                    ApplicationEntityId = "Form6E",
                    FunctionCode = "eGate-Form6E-SelectCustomsClearance"
                }
            };
            return roleFunctionDtos;
        }

        public List<UserDTO> GetUsers()
        {
            List<UserDTO> users = new List<UserDTO>(){  
                     
            new UserDTO{ UserId ="1",UserName="admin",Password="Navayuga123$",PartnerId="2",
              //  Address=new AddressDTO{AreaName="Hyd",Country="India",HouseNumber="Ramnagar",StreetName="Sec-bad",TownOrCity="Hyd",ZipCode="500044"}
            },
            new UserDTO{ UserId ="2",UserName="VOA1",Password="Navayuga123$",PartnerId="3",
            //    Address=new AddressDTO{AreaName="Hyd",Country="India",HouseNumber="Ramnagar",StreetName="Sec-bad",TownOrCity="Hyd",ZipCode="500044"}
            }
            
            
            };
            return users;
        }

        public List<UserPortDTO> GetUserPorts()
        {
            List<UserPortDTO> userPortDtos = new List<UserPortDTO>()
            {
                new UserPortDTO()
                {
                    UserId = "1",
                    PortCode = "KP",
                },
                new UserPortDTO()
                {
                    UserId = "2",
                    PortCode = "KP",
                }
            };
            return userPortDtos;
        }

        public List<UserRoleDTO> GetUserRoles()
        {
            List<UserRoleDTO> userRoles = new List<UserRoleDTO>()
            {
                new UserRoleDTO()
                {
                    UserId = "1",
                    SubscriberId = "",
                    ApplicationId = 2,
                    RoleId = "TOAdmin"
                },
                new UserRoleDTO()
                {
                    UserId = "2",
                    SubscriberId = "",
                    ApplicationId = 2,
                    RoleId = "VOA"
                }
            };
            return userRoles;
        }
    }
}