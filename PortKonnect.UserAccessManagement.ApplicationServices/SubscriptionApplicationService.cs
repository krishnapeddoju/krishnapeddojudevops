using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.Repositories;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public class SubscriptionApplicationService : ServiceBase, ISubscriptionApplicationServices
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionApplicationService(IUserContext userContext, ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            UserContext = userContext;
        }

        public void AddSubscription(Subscription subscription)
        {
            //TODO: Data to be inserted into SUBSCRIPTION & SUBSCRIPTIONMEMBER tables
        }

        public Subscription GetSubscription(int applicationId, int subscriberId)
        {
            //TODO: Data to be get from SUBSCRIPTION & SUBSCRIPTIONMEMBER tables based on applicationId and 
            return null;
        }

    }
}
