(function (eGateRoot) {
    var UserManualModel = function (data) {
        var self = this;
        self.Url = ko.observable();
        self.cache = function () { };
        self.set(data);
    }

    eGateRoot.UserManualModel = UserManualModel;

}(window.eGateRoot));

eGateRoot.UserManualModel.prototype.set = function (data) {
    var self = this;
    self.Url(data ? (data.Url || "") : "");
    self.cache.latestData = data;
}


eGateRoot.UserManualModel.prototype.reset = function () {
    this.set(this.cache.latestData);
}



