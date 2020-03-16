using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class ModulesEntityFunction
    {
        public int ApplicationId { get; protected set; }
        public string ModuleCode { get; protected set; }
        public string ModuleName { get; protected set; }
		public string ModuleIcon { get; protected set; }
        public string ParentModuleCode { get; protected set; }
        public int ModuleOrder { get; protected set; }
        public string ApplicationEntityId { get; protected set; }
        public string EntityName { get; protected set; }
        public int EntityOrder { get; protected set; }
        public string FormUrl { get; protected set; }
        public string EntityUrl { get; protected set; }
        public string FunctionCode { get; protected set; }
        public string FunctionName { get; protected set; }
        public int FunctionOrder { get; protected set; }
        public string ModuleUrl { get; protected set; }
        public string MENUICON { get; protected set; }
        public string MENUICON1 { get; protected set; }
        public string MENUICON2 { get; protected set; }
        public string IsMenuItem { get; protected set; }
    }
}
