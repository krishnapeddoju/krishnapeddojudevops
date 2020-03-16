namespace PortKonnect.UserAccessManagement.DataServcies
{
    public interface INotificationDataService
    {
        void SendNotification(int appId, string subscriberId, string memeberId, string appEntityId, string entityFunctionCode, string referenceId, string attachments, string userId, object T);
    }
}
