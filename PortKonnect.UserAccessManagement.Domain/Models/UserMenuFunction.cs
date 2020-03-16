using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class UserMenuFunction
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string PartnerId { get; set; }
        public int ApplicationId { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public string ParentModuleCode { get; set; }
        public string ParentModuleName { get; set; }
        public string ApplicationEntityId { get; set; }
        public string EntityName { get; set; }
        public string FormUrl { get; set; }
        public string FunctionCode { get; set; }
        public string FunctionName { get; set; }
        public string MenuOrder { get; set; }
        public string SubscriberId { get; set; }
    }
}
