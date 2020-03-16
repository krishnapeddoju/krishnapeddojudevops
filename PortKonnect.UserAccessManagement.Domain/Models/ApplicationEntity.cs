using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain
{
    //TODO:  Need to identify a good name for the entity
    public class ApplicationEntity
    {
        public string ApplicationEntityId { get; protected set; }
        public int ApplicationId { get; protected set; }  // Every application will have some Application Entities.
        public string EntityName { get; protected set; }
        public string Url { get; protected set; }

        public string IsMenu { get; protected set; }
        public string MailNotification { get; protected set; }
        public string SysNotification { get; protected set; }
        public string Sms { get; protected set; }
        public string WorkFlow { get; protected set; }
        public string ApiUrl { get; protected set; }

        public int MenuOrder { get; protected set; }
        public string IsDeleted { get; protected set; }
        public string RecordStatus { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }
        public string MENUICON { get; protected set; }
        public string MENUICON1 { get; protected set; }
        public string MENUICON2 { get; protected set; }
        public virtual List<ApplicationEntityFunction> applicationEntityFunctions { get; protected set; }

        public ApplicationEntity()
        {

        }

        public ApplicationEntity(string applicationEntityId, int applicationId, string EntityName, string url, int menuOrder)
        {
            this.ApplicationEntityId = applicationEntityId;
            this.EntityName = EntityName;
            this.ApplicationId = applicationId;
            this.Url = url;
            this.MenuOrder = menuOrder;
        }

        public void AddFunction(string functionCode, string functionName, string isMenu, string url, string apiUrl, int order)
        {
            this.applicationEntityFunctions.Add(new ApplicationEntityFunction(this.ApplicationEntityId, functionCode, functionName, isMenu, url, apiUrl, order));
        }

        public void DisableFunction(string functionCode)
        {
        }

        public void ActivateFunction(string functionCode)
        {
        }

        public void MakeFunctionAvailableInMenu(string functionCode)
        {
        }

        public void RemoveFunctionFromMenu(string functionCode)
        {
        }

    }
}
