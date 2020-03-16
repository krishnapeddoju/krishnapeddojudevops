using Autofac;
using System.Reflection;

namespace PortKonnect.UserAccessManagement.WebApp
{
    public class AutofacConfig
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            var container = builder.Build();
            return container;
        }
    }
}