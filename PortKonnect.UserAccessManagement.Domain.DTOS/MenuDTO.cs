using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class MenuDTO
    {
        public List<MenuModuleDTO> modules {get; set;}
    }

    public class MenuModuleDTO 
    {
        public string ModuleId {get;set;}
        public string ModuleName {get; set;}
		public string ModuleIcon { get; set; }
        public string ModuleUrl { get; set; }
        public List<MenuModuleDTO> ChildModuleDTO {get; set;}
        public List<MenuEntityDTO> AppEntities {get; set;}
    }

    public class MenuEntityDTO
    {
        public string AppEntityId {get; set;}
        public string AppEntityName {get; set;}
        public string EntityUrl { get; set; }
		public int ApplicationId { get; set; }
        public string MENUICON { get; set; }
        public string MENUICON1 { get; set; }
        public string MENUICON2 { get; set; }
        public List<MenuFunctionDTO> AppFunctions {get;set;}
    }

    public class MenuFunctionDTO 
    {
        public string FunctionCode {get;set;}
        public string FunctioName {get;set;}
        public string Url {get;set;}
        public string IsInRole { get; set; }
		public int MenuOrder { get; set; }
        public string IsMenu { get; set; }
    }

}
