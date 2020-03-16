using System.Configuration;
using PortKonnect.Common.Domain.Model;
using PortKonnect.Common.Services;

namespace PortKonnect.UserAccessManagement.DataServcies
{
    public class NotificationDataService : INotificationDataService
    {
        public void SendNotification(int appId, string subscriberId, string memeberId, string appEntityId, string entityFunctionCode, string referenceId, string attachments, string userId, object T)
        {
            NotificationTracker notificationTracker = new NotificationTracker()
            {
                ApplicationId = appId,
                SubscriberId = subscriberId,
                MemeberId = memeberId,
                ApplicationEntityId = appEntityId,
                FunctionCode = entityFunctionCode,
                ReferenceId = referenceId,
                Attachments = attachments,
                UserId = userId,
                NotificationObj = T
            };

            string RestApiUrl = ConfigurationManager.AppSettings["NotificationApiURL"];
            RestApiUrl += "api/Notification/PushNotification";
            ApiClient.RestPostNonQuery(RestApiUrl, notificationTracker);

        }
    }
}
