namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class UserPreferenceDTO
    {
        public string SendNotificationEmail { get; set; }
        public string SendNotificationSms { get; set; }
        public string SendSystemNotification { get; set; }

    }
}
