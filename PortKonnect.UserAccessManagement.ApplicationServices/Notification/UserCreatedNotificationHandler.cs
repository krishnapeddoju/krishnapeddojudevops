using PortKonnect.Common.Domain.Model;
using PortKonnect.Common.Enums;
using PortKonnect.Common.Services;
using PortKonnect.UserAccessManagement.DataServcies;
using PortKonnect.UserAccessManagement.Domain.DTOS;
using PortKonnect.UserAccessManagement.Domain.Enums;
using PortKonnect.UserAccessManagement.Domain.Events.Notification;
using PortKonnect.UserAccessManagement.Domain.MapToDTOS;

namespace PortKonnect.UserAccessManagement.ApplicationServices.Notification
{
    public class UserCreatedNotificationHandler : IDomainHandler<UserCreatedNotificationEvent>
    {
          private readonly INotificationDataService _notificationDataService;

        public UserCreatedNotificationHandler(INotificationDataService notificationDataService)
        {
            _notificationDataService = notificationDataService;
        }

        public void Handle(UserCreatedNotificationEvent userCreatedNotificationEvent)
        {
            UserDTO userDto = userCreatedNotificationEvent.User.MapToDto();
            userDto.Password = PasswordDataService.Decrypt(userDto.Password, true);

            //Sending data to Message queue Service through data Service
			_notificationDataService.SendNotification(2,
				userCreatedNotificationEvent.User.SubscriberId,
				userCreatedNotificationEvent.User.PartnerId,
				AppEntityIds.eGateUser.ToString(),
				UserFunctionCodes.eGateUserAdd.ToString(),
				userCreatedNotificationEvent.User.UserId,
				"", //TODO:Need to send Attachments physical file paths with comma separation
				userCreatedNotificationEvent.User.UserId,
				userDto);
        }

        public bool IsHandlerForExternal()
        {
            return false;
        }
    }
}
