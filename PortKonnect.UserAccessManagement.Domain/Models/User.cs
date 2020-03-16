using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using PortKonnect.Common.Domain.Model;
using PortKonnect.UserAccessManagement.Domain.Events.Notification;
using UserPreferenceDTO = PortKonnect.UserAccessManagement.Domain.DTOS.UserPreferenceDTO;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class User
    {
        public string UserId { get; protected set; } //GUID
        public string UserName { get; protected set; }
        public string Password { get; protected set; }
        public string PartnerId { get; protected set; }
		public string PartnerType { get; protected set; }
        public string ContactNo { get; protected set; }
        public string EmailId { get; protected set; }
        public UserPreference UserPreference { get; protected set; }
		
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public int InCorrectLogins { get; protected set; }
        public string DormantStatus { get; protected set; }
        public string IsFirstTimeLogin { get; protected set; }
        public string RecordStatus { get; protected set; }
        public string IsDeleted { get; protected set; }
        public DateTime? PwdExpiryDate { get; protected set; }
        public DateTime? LogTime { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }
        public DateTime? ValidFromDate { get; protected set; }
        public DateTime? ValidToDate { get; protected set; }
		public Partner partner { get; set; }
        public string IsCFSUser { get;  set; }
        public virtual ICollection<UserPort> UserPorts { get; protected set; }
        public virtual ICollection<UserRole> UserRoles { get; protected set; }
    
        [NotMapped]
        public string SubscriberId { get; set; }

		[NotMapped]
		public int ApplicationId { get; set; }

        public User()
        {



        }

        public User(string userId, string userName, string password, string firstName, string lastName, string partnerId, string contactNo, string emailId, UserPreference userPreference, int applicationId, string recordStatus, string createdBy, int inCorrectLogins, string dormantStatus, string isDeleted, string isFirstTimeLogin,DateTime? validFromDate,DateTime? validToDate,DateTime? pwdExpiryDate,string partnerType, string IsCFSUser)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            PartnerId = partnerId;
            ContactNo = contactNo;
            EmailId = emailId;
            InCorrectLogins = inCorrectLogins;
            DormantStatus = dormantStatus;
            UserPreference = userPreference;
            //ApplicationId = applicationId;
            IsDeleted = isDeleted;
            RecordStatus = recordStatus;
            CreatedBy = createdBy;
            IsFirstTimeLogin = isFirstTimeLogin;
            ValidFromDate = validFromDate;
            ValidToDate = validToDate;
            PwdExpiryDate = pwdExpiryDate;
            CreatedOn = DateTime.Now;
            UserPorts = new List<UserPort>();
            UserRoles = new List<UserRole>();
			PartnerType = partnerType;
            IsCFSUser = IsCFSUser;
        }


        public void UpdateChangePassword(string userId, string newPassword, DateTime? pwdExpiryDate,string isFirstTimeLogin)
        {
            this.UserId = userId;
            this.Password = newPassword;
            this.PwdExpiryDate = pwdExpiryDate;
            this.IsFirstTimeLogin = isFirstTimeLogin;
        }

       

        public void UpdateLogTimeAndIncorrectLogins(string userId, DateTime? logTime, int inCorrectLogins)
        {
            this.UserId = userId;
            this.LogTime = logTime;
            this.InCorrectLogins = inCorrectLogins;
        
        }

        public void SetSubscriberId(string subId)
        {
            this.SubscriberId = subId;
        }

        //public void SetIsQuixyUser(string IsQuixyUser)
        //{
        //    this.IsQuixyUser = IsQuixyUser;
        //}

        public void AssignToPort(string portCode, string isDeleted, string recordStatus, string userId)
        {
            UserPorts.Add(new UserPort(UserId, portCode, isDeleted, recordStatus, userId));
        }

        public void AssignRole(string roleId, int applicationId, string isDeleted, string recordStatus, string createdBy, string subscriberId)
        {
			UserRoles.Add(new UserRole(UserId, roleId, subscriberId, applicationId, isDeleted, recordStatus, createdBy));
        }

        public List<UserRole> GetRoles()
        {
            return UserRoles.ToList();
        }

        public void ChangeUserDetails(string userName, string firstName, string lastName, string contactNo, string emailId, string partnerId)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            ContactNo = contactNo;
            EmailId = emailId;
            PartnerId = partnerId;
        }

        public void ChangeUpdatedByAndOn(string userId)
        {
            UpdatedBy = userId;
            UpdatedOn = DateTime.Now;
        }


        public void ChangeRecordStatus(string userId, string isDeleted)
        {
            this.UpdatedBy = userId;
            this.UpdatedOn = DateTime.Now;
            this.IsDeleted = isDeleted;
            this.RecordStatus = isDeleted == "N" ? RecordStatus = "A" : RecordStatus = "I";
        }

        public void ChangeUserPreference(string userId, UserPreferenceDTO userPreference)
        {
            UserPreference = new UserPreference(userPreference.SendNotificationEmail, userPreference.SendNotificationSms, userPreference.SendSystemNotification);
        }

        public void UpdateIncorrectLogin(string userId, int inCorrectLogins)
        {
            this.UserId = UserId;
            this.InCorrectLogins = inCorrectLogins;

        }

        public void UpdateLogTime(string userId, DateTime? logTime)
        {
            this.UserId = userId;
            this.LogTime = logTime;
        
        }

        public void UpdateDormantStatus(string dormantStatus,string userId, DateTime? pwdExpiryDate, DateTime? validToDate, DateTime? logTime, int inCorrectLogins)
        {
            this.UserId = userId;
            this.DormantStatus = dormantStatus;
            this.PwdExpiryDate = pwdExpiryDate;
            this.ValidToDate = validToDate;
            this.LogTime = logTime;
            this.InCorrectLogins = inCorrectLogins;
        }


        public void UpdatePasswordDetails(string password, int incorecctLogins, string recordStatus, string isDelete, string userId, DateTime? pwdExpiryDate,string isFirstTimeLogin)
        {

            this.UserId = userId;
            this.Password = password;
            this.RecordStatus = recordStatus;
            this.IsDeleted = isDelete;
            this.InCorrectLogins = incorecctLogins;
            this.PwdExpiryDate = pwdExpiryDate;
            this.IsFirstTimeLogin=isFirstTimeLogin;
        }


        #region Notification Methods
        public void RaiseDomainUserNotificationEvent(User user)
        {
            DomainEvent.Raise(new UserCreatedNotificationEvent(user));
        }

        #endregion




    }
}
