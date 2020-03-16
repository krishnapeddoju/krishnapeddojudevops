//using System.Web.Mvc;

using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using PortKonnect.Common.Domain.Model;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.ApplicationServices.Notification;
using PortKonnect.UserAccessManagement.ApplicationServices.ServiceContracts;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.DataServcies;
using PortKonnect.UserAccessManagement.DataServcies.ServiceContracts;
using PortKonnect.UserAccessManagement.Domain.Events.Notification;
using PortKonnect.UserAccessManagement.Domain.Repositories;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;
//using Autofac.Integration.Mvc;

namespace PortKonnect.UserAccessManagement.Api
{
	public static class AutofacConfig
	{
		public static IContainer ConfigureContainer()
		{
			var builder = new ContainerBuilder();

			builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();

			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			builder.RegisterType<UserContext>().As<IUserContext>().InstancePerRequest();

			#region Registering Services with Interfaces
			builder.RegisterType<PartnerApplicationService>().As<IPartnerApplicationService>();
			builder.RegisterType<SubscriptionApplicationService>().As<ISubscriptionApplicationServices>();
			builder.RegisterType<AccountService>().As<IAccountService>();
			builder.RegisterType<ApplicationModuleService>().As<IApplicationModuleService>();
			builder.RegisterType<ApplicationEntityService>().As<IApplicationEntityService>();
			builder.RegisterType<RoleApplicationService>().As<IRoleApplicationService>();
			builder.RegisterType<UserApplicationService>().As<IUserApplicationService>();
			builder.RegisterType<UserDataService>().As<IUserDataService>();
			builder.RegisterType<UserRoleApplicationService>().As<IUserRoleApplicationService>();
			builder.RegisterType<UserRoleDataService>().As<IUserRoleDataService>();
			builder.RegisterType<RoleDataService>().As<IRoleDataService>();
			builder.RegisterType<RoleApplicationService>().As<IRoleApplicationService>();
			builder.RegisterType<NotificationDataService>().As<INotificationDataService>();

            builder.RegisterType<SuperCategoryApplicationService>().As<ISuperCategoryApplicationService>();
            builder.RegisterType<SuperCategoryDataService>().As<ISuperCategoryDataService>();
            builder.RegisterType<SubCategoryApplicationService>().As<ISubCategoryApplicationService>();
            builder.RegisterType<SubCategoryDataService>().As<ISubCategoryDataService>();
            builder.RegisterType<EmployeeApplicationService>().As<IEmployeeApplicationService>();
            builder.RegisterType<EmployeeDataService>().As<IEmployeeDataService>();

            builder.RegisterType<PartnerRegistrationApplicationService>().As<IPartnerRegistrationApplicationService>();

			#endregion

			#region Registering Repositories with Interface

			builder.RegisterType<PartnerRepository>().As<IPartnerRepository>();
			builder.RegisterType<SubscriptionRepository>().As<ISubscriptionRepository>();
			builder.RegisterType<AccountRepository>().As<IAccountRepository>();
			builder.RegisterType<CommonRepository>().As<ICommonRepository>();
			builder.RegisterType<ApplicationModuleRepository>().As<IApplicationModuleRepository>();
			builder.RegisterType<ApplicationEntityRepository>().As<IApplicationEntityRepository>();
			builder.RegisterType<RoleRepository>().As<IRoleRepository>();
			builder.RegisterType<UserRepository>().As<IUserRepository>();
			builder.RegisterType<UserRoleRepository>().As<IUserRoleRepository>();
			builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<SuperCategoryRepository>().As<ISuperCategoryRepository>();
            builder.RegisterType<SubCategoryRepository>().As<ISubCategoryRepository>();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();

            builder.RegisterType<PartnerRegistrationRepository>().As<IPartnerRegistrationRepository>();

			#endregion

			#region Registration of Domain Event Handlers
			builder.RegisterType<UserCreatedNotificationHandler>().As<IDomainHandler<UserCreatedNotificationEvent>>();
			#endregion

			var container = builder.Build();

			return container;
		}
	}
}