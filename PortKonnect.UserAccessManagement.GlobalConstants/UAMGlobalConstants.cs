namespace PortKonnect.UserAccessManagement.GlobalConstants
{
    //TODO:Need to move common location 
    public static class UAMGlobalConstants
    {
        //TODO: temporarily using below hardcoded value
        public const string PortCode = "KP";
        //public const int ApplicationId = 2;
        public const int ApplicationId = 6;
        //public const string SubscriberId = "KPCT";
        public const string SubscriberId = "KPCL";
        public const string UserId = "1";
        public const int UserContextCookieTimeout = 100;
        public const string UserName = "KPCT";
        public const string StatusNew = "New";
        public const string StatusApproved = "Approved";
        public const string StatusVerified = "Verified";
        public const string StatusRejectedVer = "RejectedAtVerification";
        public const string StatusRejected = "Rejected";
        public const string RecordStatus = "A";
        public const string RecordStatusInactive = "I";
        public const string IsDeletedNo = "N";
        public const string IsDeletedYes = "Y";
        public const string IsDormantYes = "Y";
        public const string IsDormantNo = "N";
        public const string IsInRoleYes = "Y";
        public const string IsInRoleNo = "N";
        public const int PasswordExpiryDays = 45;
        public const string Success = "Success";
        public const string CurrentPwdRestirction = "Current Password is wrong";
        public const string CurrentNewPwdRestirction = "Current And New Password should be different";
        public const string PasswordCheckValidation = "This Password is already Used,Please Create another password";
        public const string IsFirstTimeLogedin = "N";
        public const string IsFirstTimeLogin = "Y";
        public const string ConsortiumPartner = "ConsortiumPartner";
        public const string VesselOperatingAgent = "VesselOperatingAgent";
        public const string RememberMeYes = "Y";
        public const string RememberMeNo = "N";
        public const int NumberofInCorrectLogins = 3;
        public const int InCorrectLogins = 0;
        public const int UserCreationLifeSpan = 120;
        public const int InvalidAttemptswaitMinutes = 15;
        public const int PwdExpiryDays = 1;
        public const int DormantDays = 90;
        public const string NotApplicable = "NA";
        public const int PreviousPasswordCount = 10;
        public const string PartnerRegistrationNumberLength = "D4";
        public const string Yes = "Y";
        public const string No = "N";
        public const string PartnerTypeVOA = "VesselOperatingAgent";
        public const string PartnerTypeCHA = "CustomHouseAgent";
        public const string PartnerTypeCFS = "ContainerFreightStation";
        public const string PartnerTypeCOA = "ContainerOperatorAgent";
        public const string PartnerTypeTO = "TerminalOperator";
        public const string PartnerTypeSuperAdmin = "SuperAdmin";
        public const string PartnerTypeMAndR = "MandR";
        public const string Anonymous = "Anonymous";
        public const string Accounts = "ACC";
        public const string All = "All";
        public const string UnauthorizedCredentials = "You are not authorized user to perform this action";
        public const string YouHaveMade = ". You have made ";
        public const string UnsuccessfulAttempts = " unsuccessful attempt(s).";
        public const string SpaceConstant = " ";
        public const string Minutes = "minutes";
        //new Constants For Token Service
        public const string BillingAngular = "http://localhost:4129/";
        public const string CargoAngular = "http://localhost:4300/";
        public const string BagManagementAngular = "http://localhost:4200/";
        public const string MasterDataAngular = "http://localhost:4100/";
        public const string ImportWebAppAngular = "http://localhost:72/";
        public const string RailWebAppAngular = "http://localhost:4500/";
        public const string JettyWebAppAngular = "http://localhost:4600/";
        public const string ETSWebAppAngular = "http://localhost:4700/";
        public const string GateWebAppAngular = "http://localhost:4411/";
        public const string CargoClientSecret = "cargoclientsecret";
        public const string CargoIssuerUri = "http://PortKonnectcargo/identity";
        public const string CargoSTSOrigin = "http://localhost:252";
        public const string CargoSTS = CargoSTSOrigin + "/identity";
        public const string CargoSTSUserInfoEndpoint = CargoSTS + "/connect/userinfo";

        public const string CargoSTSTokenEndpoint = CargoSTS + "/connect/token";
        public const string UAM = "http://localhost:253/";
        public const string UAMApi = "http://localhost:251";
        public const string NotificationsQueue = "eGateNotifications";

        public const string PortKonnectCargoUAMModuleCode = "PKCUAM";

        public const string KwixeeCFS = "http://localhost:4200/";
    }

    public static class PartnerRegistrationStatus
    {
        public const string StatusNew = "New";
        public const string StatusApproved = "Approved";
        public const string StatusVerified = "Verified";
        public const string StatusRejectedVer = "RejectedAtVerification";
        public const string StatusRejected = "Rejected";
    }

    public static class RoleCodeConstants
    {
        public const string TO = "TerminalOperator";
        public const string SuperAdmin = "SuperAdmin";
    }
    public static class SuperCategoryConstants
    {
        public const string Department = "DEPT";
        public const string Designation = "DESI";
    }    
}
