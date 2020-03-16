(function (eGateRoot) {
    var ChangePasswordViewModel = function (IsFirstTimeLogin) {
        var self = this;
        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.changepasswordModel = ko.observable(new eGateRoot.ChangePasswordModel());
        self.Name = ko.observable('acs');
        self.ModuleList = ko.observable();
        self.backurl = ko.observable();
        if (!isEmpty(application.viewbag.name))
            self.Name(application.viewbag.name.toLowerCase());



        self.Initialize = function () {
            var profileDropDown = $("#profileDropDown");
            profileDropDown.removeClass('active');
            $("#currentPassword").val("");
            self.backurl($("#custId").val());
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
                                           window.location.href = window.location.origin;
                                       }, delay);

                                   } else {
                                       toastr.warning(data, "Change Password");
                                       self.CPValidation().errors.showAllMessages();
                                       return;
                                   }


                               }, null, false, application.viewbag.appSettings.eGateAPIUrl, null, 'UAM');
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
                                           ///  window.location.href = window.location.origin;
                                           if (self.backurl() != null && self.backurl() != "") {
                                               var list1 = localStorage.getItem("ModuleList")
                                               var list = list1.split(",");
                                               $.each(list, function (key, val) {
                                                   console.log(key, val);
                                                   var fin = (val.split("-")[0]).replace(/[\"\[\]]/g, " ").trim();
                                                   if (fin == self.backurl()) {
                                                       // var fin2 = (val.split("-")[1]).replace(/[\"\[\]]/g, " ").trim() + "/Dashboard";
                                                       var fin2 = (val.split("-")[1]).replace(/[\"\[\]]/g, " ").trim();
                                                       window.location.href = fin2;
                                                       //window.location.href = fin2.replace("192.168.0.139", "localhost");
                                                   }
                                               });
                                           }
                                           else {
                                               window.location.href = window.location.origin;
                                           }
                                       }, delay);

                                   } else {
                                       toastr.warning(data, "Change Password");
                                       self.CPValidation().errors.showAllMessages();
                                       return;
                                   }

                                   if ((self.backurl() == null || self.backurl() == "") && IsFirstTimeLogin == "Y") {

                                       setTimeout(function () {
                                           window.location.href = application.viewbag.appSettings.returnUrl;
                                       }, 2000);
                                   }

                               }, null, false, application.viewbag.appSettings.uamapiUrl, null, 'UAM');
            }
            else {
                self.CPValidation().errors.showAllMessages();
                return;
            }

        }

        self.Cancel = function (model) {
            debugger;
            if (self.backurl() != null && self.backurl() != "") {
                var list1 = localStorage.getItem("ModuleList")
                var list = list1.split(",");
                $.each(list, function (key, val) {
                    console.log(key, val);

                    var fin = (val.split("-")[0]).replace(/[\"\[\]]/g, " ").trim();
                    if (fin == self.backurl()) {
                        //var fin2 = (val.split("-")[1]).replace(/[\"\[\]]/g, " ").trim() + "/Dashboard";
                        var fin2 = (val.split("-")[1]).replace(/[\"\[\]]/g, " ").trim();
                        window.location.href = fin2;
                        //window.location.href = fin2.replace("192.168.0.139", "localhost");
                    }
                });
            }
            else {
                if ( IsFirstTimeLogin == "Y")
                    window.location.href = window.location.origin;
                else
                    window.location.href = window.location.origin;
            }
        }
        self.Initialize();
    }

    eGateRoot.ChangePasswordViewModel = ChangePasswordViewModel;
}(window.eGateRoot));

