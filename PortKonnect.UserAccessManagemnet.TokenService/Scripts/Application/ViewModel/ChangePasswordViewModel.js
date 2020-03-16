(function (eGateRoot) {
    var ChangePasswordViewModel = function (IsFirstTimeLogin) {
        var self = this;
        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.changepasswordModel = ko.observable(new eGateRoot.ChangePasswordModel());




        self.Initialize = function () {
            var profileDropDown = $("#profileDropDown");
            profileDropDown.removeClass('active');
            $("#currentPassword").val("");
        }

        self.SubmitForgotPassword = function (model) {
            model.UserName($('#loginusername').text());
            model.Password($('#loginpassword').val());
            model.LogTransId($('#logTransId').text());
            self.CPValidation = ko.observable(model);
            self.CPValidation().errors = ko.validation.group(self.CPValidation());
            var errors = self.CPValidation().errors().length;
            if (errors == 0) {
                self.viewModelHelper.apiPost('api/Account/ForgotPassword', ko.mapping.toJSON(model),
                               function Message(data) {
                                   toastr.options.closeButton = true;
                                   toastr.options.positionClass = "toast-top-right";
                                   if (data == 'Success') {
                                       toastr.success("Password Changed successfully", "Change Password");
                                       var delay = 2000;
                                       setTimeout(function () {
                                           window.location.href = "../../Account/Login";
                                       }, delay);

                                   } else {
                                       toastr.warning(data, "Change Password");
                                       self.CPValidation().errors.showAllMessages();
                                       return;
                                   }


                               }, null, false, application.viewbag.appSettings.apiUrl, null, 'UAM');
            }
            else {
                self.CPValidation().errors.showAllMessages();
                return;
            }


        }

        self.SubmitPassword = function (model) {
            self.CPValidation = ko.observable(model);
            self.CPValidation().errors = ko.validation.group(self.CPValidation());
            var errors = self.CPValidation().errors().length;
            if (errors == 0) {
                self.viewModelHelper.apiPost('api/Account/ChangePassword', ko.mapping.toJSON(model),
                               function Message(data) {
                                   toastr.options.closeButton = true;
                                   toastr.options.positionClass = "toast-top-right";
                                   if (data == 'Success') {
                                       toastr.success("Password Changed successfully", "Change Password");
                                       var delay = 2000;
                                       setTimeout(function () {
                                           window.location.href = "../../Home";
                                       }, delay);

                                   } else {
                                       toastr.warning(data, "Change Password");
                                       self.CPValidation().errors.showAllMessages();
                                       return;
                                   }
                                   if (IsFirstTimeLogin == "Y") {
                                       setTimeout(function () {
                                           window.location.href = application.viewbag.appSettings.returnUrl;
                                       }, 2000);
                                   }

                               }, null, false, application.viewbag.appSettings.uamapiUrl,null,'UAM');
            }
            else {
                self.CPValidation().errors.showAllMessages();
                return;
            }

        }

        self.Cancel = function (model) {
            if (IsFirstTimeLogin == "Y")
                window.location.href = "../../Account/Login";
            else
                window.location.href = "../../Home";
        }
        self.Initialize();
    }

    eGateRoot.ChangePasswordViewModel = ChangePasswordViewModel;
}(window.eGateRoot));

