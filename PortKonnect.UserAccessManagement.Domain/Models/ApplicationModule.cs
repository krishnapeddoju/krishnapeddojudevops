using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class ApplicationModule
    {
        public string ModuleId { get; protected set; }
        public int ApplicationId { get; protected set; }
        public string ModuleName { get; protected set; }
        public string ParentModuleId { get; protected set; }
        public string Url { get; protected set; }
        public int Order { get; protected set; }
        public string RecordStatus { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }
        public virtual ICollection<ApplicationModuleEntity> ModuleEntities { get; protected set; }
        public ApplicationModule(string moduleId, int appId, string moduleName, string parentModuleId, string url, int order)
        {
            this.ModuleId = moduleId;
            this.ApplicationId = appId;
            this.ModuleName = moduleName;
            this.ParentModuleId = parentModuleId;
            this.Url = url;
            this.Order = order;
        }

        public void AddApplicationEntity(string applicationEntityId)
        {
            this.ModuleEntities.Add(new ApplicationModuleEntity(this.ModuleId, applicationEntityId, this.Order));
        }

        public void RemoveApplicationEntity(ApplicationModuleEntity moduleEntity)
        {
            this.ModuleEntities.Remove(moduleEntity);
        }

    }
}
