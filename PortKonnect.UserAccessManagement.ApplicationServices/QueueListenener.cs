using PortKonnect.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using MassTransit;
//using IPMS.Domain.Models;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.Repositories;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;
using PortKonnect.UserAccessManagement.Repositories;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using log4net.Config;
using log4net;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public class QueueListener
    {
        public static IPartnerRegistrationApplicationService Service;
        public static void Setup(IUserContext userContext,
                                IPartnerRegistrationRepository partnerRegistrationRepository,
                                ISubscriptionRepository subscriptionRepository,
                                ICommonRepository commonRepository,
                                IPartnerApplicationService partnerApplicationService,
                                IPartnerRepository partnerRepository,
                                IUserRepository userRepository,
                                IUserRoleRepository userRoleRepository, IUserApplicationService UserApplicationService)
        {

            Service = new PartnerRegistrationApplicationService(userContext, 
                partnerRegistrationRepository, 
                subscriptionRepository, 
                commonRepository, 
                partnerApplicationService, 
                partnerRepository,
                userRepository,
                userRoleRepository, UserApplicationService);

            var rabbitMQHost = ConfigurationManager.AppSettings["RabbitMQHost"];
            var rabbitMQUsername = ConfigurationManager.AppSettings["RabbitMQUsername"];
            var rabbitMQPassword = ConfigurationManager.AppSettings["RabbitMQPassword"];

            var rabbitMqRootUri = new Uri(rabbitMQHost);
            var rabbitBusControl = Bus.Factory.CreateUsingRabbitMq(rabbit =>
            {
                var host = rabbit.Host(rabbitMqRootUri, settings =>
                {
                    settings.Username(rabbitMQUsername);
                    settings.Password(rabbitMQPassword);
                });

                rabbit.ReceiveEndpoint(host, "PortKonnect.Common.Contracts:IAgentAddEvent:Queue", e =>
                {
                    e.Consumer<AgentAddConsumer>();
                });
            });

            rabbitBusControl.Start();
        }

        public static void HealthCheck(string message)
        {
            Uri rabbitMqRootUri = new Uri(ConfigurationManager.AppSettings["RabbitMQHost"]);

            IBusControl rabbitBusControl = Bus.Factory.CreateUsingRabbitMq(rabbit =>
            {
                rabbit.Host(rabbitMqRootUri, settings =>
                {
                    settings.Username(ConfigurationManager.AppSettings["RabbitMqUserName"]);
                    settings.Password(ConfigurationManager.AppSettings["RabbitMqPassword"]);
                });
            });

            Task publishTask = rabbitBusControl.Publish<IHealthCheckEvent>(new
            {
                Message = message
            });
        }
    }

    public class AgentAddConsumer : IConsumer<IAgentAddEvent>
    {
        public  ILog _log;
        public Task Consume(ConsumeContext<IAgentAddEvent> context)
        {
            XmlConfigurator.Configure();
            _log = LogManager.GetLogger(typeof(ServiceBase));

            try
            {
                var partner = context.Message.Partner;
                //partner.PartnerRegistrationAddress = new PartnerRegistrationAddressDTO(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, partner.ITEmail, string.Empty);
               // QueueListener.Service.AddPartnerRegistration(partner);
                QueueListener.Service.AddPartner(partner);
                
            }
            catch (Exception e)
            {
                _log.Error($"AgentAddConsumer - Failed - {e.Message} {Environment.NewLine} {e.StackTrace}");
                throw e;

            }

            return Task.FromResult(0);
        }
    }


}
