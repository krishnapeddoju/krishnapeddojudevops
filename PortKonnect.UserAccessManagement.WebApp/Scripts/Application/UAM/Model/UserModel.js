(function (eGateRoot) {

    var UserModel = function (data) {
        
        $('#txtusername').focus();
        var ReturnUrl = $('#spanReturnUrl').text();
        var user = $('#cusername').text();
        var pwd = $('#cpwd').text();
        var self = this;
        self.RememberMe = ko.observable();
        self.AppId = ko.observable();
        self.Token = ko.observable();
        if ((user != "" && user != null) && (pwd != "" && pwd != null)) {
            self.userName = ko.observable(user);
            self.password = ko.observable(pwd);
            self.RememberMe = ko.observable(true);
            $('#chkRemember').closest('span').addClass('checked');
        }
        else {
            self.userName = ko.observable(data ? data.userName : "");
            self.password = ko.observable(data ? data.password : "");
            self.RememberMe = ko.observable(data ? data.RememberMe : false);

            self.cache = function () { };
            self.set(data);
        }

        self.ReturnUrl = ko.observable(ReturnUrl);
    }

    var ForgotPasswordModel = function (data) {
        var self = this;
        self.userName = ko.observable(data ? data.userName : "");
        self.ApplicationId = ko.observable();
        self.SubscriberId = ko.observable();
    }

    eGateRoot.ForgotPasswordModel = ForgotPasswordModel;
    eGateRoot.UserModel = UserModel;

}(window.eGateRoot));

eGateRoot.UserModel.prototype.set = function (data) {
   
    var self = this;
    self.userName(data ? (data.userName || "") : "");
    self.password(data ? (data.password || "") : "");
    self.RememberMe(data ? (data.RememberMe || "") : "");

    self.cache.latestData = data;
}

eGateRoot.UserModel.prototype.reset = function () {
    this.set(this.cache.latestData);
}




