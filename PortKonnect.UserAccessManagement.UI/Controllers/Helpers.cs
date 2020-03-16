using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace PortKonnect.UserAccessManagement.UI
{
    public static class Helpers
    {      

        public static IHtmlString ToJson(HtmlHelper html, dynamic viewBagObject)
        {
            //TODO : Need to access those setting which required instead of accessing all Appsettings section from Web.config
            var json = JsonConvert.SerializeObject(
                viewBagObject,
                Formatting.Indented,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }
            );

            return html.Raw(json);
        }

    }

}