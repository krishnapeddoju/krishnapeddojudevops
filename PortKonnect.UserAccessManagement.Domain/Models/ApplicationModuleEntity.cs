using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class ApplicationModuleEntity
    {
        public string ModuleId { get; protected set; }
        public string ApplicationEntityId { get; protected set; }
        public int Order { get; protected set; }
        public string RecordStatus { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }
        public ApplicationModuleEntity(string moduleId, string appEntityId, int order)
        {
            this.ModuleId = moduleId;
            this.ApplicationEntityId = appEntityId;
            this.Order = order;
        }
    }
}
