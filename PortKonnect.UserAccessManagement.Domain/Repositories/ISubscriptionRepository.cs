using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.Repositories
{
    public interface ISubscriptionRepository
    {
        void AddSubscription(Subscription subscription);
        Subscription GetSubscription(int applicationId, string subscriberId);

    }
}
