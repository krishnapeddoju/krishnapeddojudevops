using System.Web.Mvc;

namespace PortKonnect.UserAccessManagement.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new CustomExceptionFilterAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new AppSettingsAttribute());
        }
    }
}