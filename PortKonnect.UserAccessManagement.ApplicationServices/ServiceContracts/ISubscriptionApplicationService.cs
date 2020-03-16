using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public interface ISubscriptionApplicationServices
    {
        void AddSubscription(Subscription subscription);
        Subscription GetSubscription(int applicationId, int subscriberId);

    }
}
