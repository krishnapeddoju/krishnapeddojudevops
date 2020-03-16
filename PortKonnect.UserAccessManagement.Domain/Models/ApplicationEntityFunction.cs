using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class ApplicationEntityFunction
    {
        public string ApplicationEntityId { get; protected set; }
        public string FunctionCode { get; protected set; } //EntityId + Function Code are unique
        public string FunctionName { get; protected set; }
        public string IsMenuItem { get; protected set; }
        public string FunctionUrl { get; protected set; }
        public string ApiUrl { get; protected set; }
        public int Order { get; protected set; }
        public string IsDeleted { get; protected set; }
        public string RecordStatus { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }

        public ApplicationEntityFunction()
        {

        }

        public ApplicationEntityFunction(string entityId, string functionCode, string functionName, string isMenuItem, string url, string apiUrl, int order)
        {
            this.ApplicationEntityId = entityId;
            this.FunctionCode = functionCode;
            this.FunctionName = functionName;
            this.IsMenuItem = isMenuItem;
            this.FunctionUrl = url;
            this.ApiUrl = apiUrl;
            this.Order = order;
        }
    }
}
