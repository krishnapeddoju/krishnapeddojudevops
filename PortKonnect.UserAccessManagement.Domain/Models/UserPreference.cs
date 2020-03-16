using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class UserPreference
    {
        [Column("SENDNOTIFICATIONEMAIL")]
        public string SendNotificationEmail { get; protected set; }
        [Column("SENDNOTIFICATIONSMS")]
        public string SendNotificationSms { get; protected set; }
        [Column("SENDSYSTEMNOTIFICATION")]
        public string SendSystemNotification { get; protected set; }

        public UserPreference()
        {
        }

        public UserPreference(string sendNotificationEmail, string sendNotificationSms, string sendSystemNotification)
        {
            this.SendNotificationEmail = sendNotificationEmail;
            this.SendNotificationSms = sendNotificationSms;
            this.SendSystemNotification = sendSystemNotification;
        }
    }
}
