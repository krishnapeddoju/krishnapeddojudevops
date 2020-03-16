using PortKonnect.Common.Domain.Model;

namespace PortKonnect.UserAccessManagement.Domain.Events.Notification
{
    public class UserCreatedNotificationEvent : IDomainEvent
    {
        public User User { get; private set; }
        public string ReferenceId { get; private set; }

        public UserCreatedNotificationEvent(User user)
        {
            User = user;
            ReferenceId = user.UserId;
        }
    }
}
