(function (eGateRoot) {
    var LoginViewModel = function () {
        var self = this;
        self.viewModelHelper = new eGateRoot.viewModelHelper();
        self.validationHelper = new eGateRoot.validationHelper();
        self.accountModel = ko.observable(new eGateRoot.LoginModel());
        self.forgotPasswordModel = ko.observable(new eGateRoot.ForgotPasswordModel());

        self.Initialize = function () {
        }

       

        self.Initialize();

    }
    eGateRoot.LoginViewModel = LoginViewModel;
}(window.eGateRoot));