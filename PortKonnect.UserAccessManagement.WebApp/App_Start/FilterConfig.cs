﻿using System.Web.Mvc;
using PortKonnect.UserAccessManagement.Filters;
namespace PortKonnect.UserAccessManagement.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new AppSettingsAttribute());
        }
    }
}