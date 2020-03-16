(function (eGateRoot) {
    var UserRegistrationViewViewModel = function (userid) {
        var self = this;
        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.viewMode = ko.observable();
        self.editableView = ko.observable(true);
        self.UserRegistrationModel = ko.observable(new eGateRoot.UserRegistrationModel());

        self.IsReset = ko.observable(true);
        self.IsSave = ko.observable(true);
        self.IsUpdate = ko.observable(true);
        self.IsExit = ko.observable(true);
        self.IsCodeEnable = ko.observable(true);
        self.validationHelper = new eGateRoot.ValidationHelper();
        toastr.options.closeButton = true;
        toastr.options.positionClass = "toast-top-right";
        self.Ports = ko.observableArray([]);
        self.Roles = ko.observableArray([]);
        self.Partners = ko.observableArray([]);
        self.PartnerTypes = ko.observable([]);
        self.ISCheckBox = ko.observable(true);
        self.isDormantVisible = ko.observable(false);


       
        self.GetUserById = function () {

            self.viewModelHelper.apiGet('api/GetUserForUserId/' + userid,
          null,
            function (result) {
                if (result != null) {

                    self.UserRegistrationModel().UserId(result.UserId);
                    self.UserRegistrationModel().UserName(result.UserName);
                    self.UserRegistrationModel().FirstName(result.FirstName);
                    self.UserRegistrationModel().LastName(result.LastName);
                    self.UserRegistrationModel().ContactNumber(result.ContactNumber);
                    self.UserRegistrationModel().EmailId(result.EmailId);
                    self.UserRegistrationModel().PartnerType(result.PartnerTypeName);
                    self.UserRegistrationModel().PartnerTypeArray(result.PartnerTypeArray);
                    self.UserRegistrationModel().PartnerId(result.PartnerName);
                    self.UserRegistrationModel().UserPortArray(result.UserPorts[0].PortName);
                    self.UserRegistrationModel().RecordStatus(result.RecordStatus == "A" ? result.RecordStatus = "Active" : result.RecordStatus = "InActive");
                    self.UserRegistrationModel().UserPreference().SendNotificationEmail(result.UserPreference.SendNotificationEmail=="Y"?true:false);
                    self.UserRegistrationModel().UserPreference().SendNotificationSms(result.UserPreference.SendNotificationSms=="Y"?true:false);
                    self.UserRegistrationModel().UserPreference().SendSystemNotification(result.UserPreference.SendSystemNotification == "Y" ? true : false);
                    self.UserRegistrationModel().DormantStatus(result.DormantStatus == "Y" ? result.DormantStatus = "Yes" : result.DormantStatus = "No");
                    if (result.DormantStatus == "Yes")
                    {
                        self.isDormantVisible(true);
                    }

                  
                }
                else { return; }
            }, null, null, false, application.viewbag.appSettings.uamapiUrl);


        }
        

        self.ExitScreen = function () {


            window.location.href = "/Users";
        }

        self.EditUser = function () {

            window.location.href = "/User/" + userid;

        }

        self.Initialize = function () {
            
            self.UserRegistrationModel(new eGateRoot.UserRegistrationModel());
            self.viewMode = ko.observable(true);
            self.GetUserById();
            self.viewMode('Form');
            $('#spnTitle').html("View User");
            self.IsSave(false);
            self.IsUpdate(false);
            self.IsReset(false);
            self.ISCheckBox(false);
        }

       

        self.Initialize();

    }
    eGateRoot.UserRegistrationViewViewModel = UserRegistrationViewViewModel;
}(window.eGateRoot));


function SetFocus() {
    $("#contactNumber").bind("focus", function () {
        if (this.createTextRange) {
            var part = this.createTextRange();
            part.move("character", 0);
            part.select();
        } else if (this.setSelectionRange) {
            var maskedinput = this;
            setTimeout(function() {
                    maskedinput.setSelectionRange(0, 0);
                },
                0);
        }
    });
}