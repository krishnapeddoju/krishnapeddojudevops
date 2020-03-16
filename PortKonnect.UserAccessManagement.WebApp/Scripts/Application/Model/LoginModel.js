(function (eGateRoot) {

    var LoginModel = function (data) {
        $('#txtusername').focus();
        var ReturnUrl = $('#spanReturnUrl').text();
        var user = $('#cusername').text();
        var pwd = $('#cpwd').text();
        var self = this;
        self.RememberMe = ko.observable();
        self.Token = ko.observable();

        if ((user != "" && user != null) && (pwd != "" && pwd != null)) {
            self.username = ko.observable(user);
            self.password = ko.observable(pwd);
            self.RememberMe = ko.observable(true);
            $('#chkRemember').closest('span').addClass('checked');
        }
        else {
            self.username = ko.observable(data ? data.username : "");
            self.password = ko.observable(data ? data.password : "");
            self.RememberMe = ko.observable(data ? data.RememberMe : false);

            self.cache = function () { };
            self.set(data);
        }

        self.ReturnUrl = ko.observable(ReturnUrl);
    }

    var ForgotPasswordModel = function (data) {
        var self = this;
        self.username = ko.observable(data ? data.username : "");
    }

    //eGateRoot.ForgotPasswordModel = ForgotPasswordModel;
    eGateRoot.LoginModel = LoginModel;

}(window.eGateRoot));

eGateRoot.LoginModel.prototype.set = function (data) {
    var self = this;
    self.username(data ? (data.username || "") : "");
    self.password(data ? (data.password || "") : "");
    self.RememberMe(data ? (data.RememberMe || "") : "");

    self.cache.latestData = data;
}

eGateRoot.LoginModel.prototype.reset = function () {
    this.set(this.cache.latestData);
}




