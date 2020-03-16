using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain.Repositories;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly IUserContext _userContext;
        public SubscriptionRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public void AddSubscription(Subscription subscription)
        {
          
            _userContext.Subscriptions.AddOrUpdate(subscription);
            _userContext.SaveChanges();
        }

        public Subscription GetSubscription(int applicationId, string subscriberId)
        {
            //TODO:To be implemented
            Subscription subscription = (from sub in
                                             _userContext.Subscriptions.Where(
                                                 s => s.PartnerId == subscriberId && s.ApplicationId == applicationId)
                                         select sub).FirstOrDefault();
            
            return subscription;
        }

    }
}
