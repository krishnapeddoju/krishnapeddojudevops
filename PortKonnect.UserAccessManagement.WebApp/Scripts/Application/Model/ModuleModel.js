/// <reference path="../ViewModel/PortViewModel.js" />
(function (eGateRoot) {
    var ModuleModel = function () {
        var self = this;
        self.ModuleList = ko.observableArray([]);
        self.ModuleName  = ko.observable();
        self.Module1 = ko.observable();
        self.Entities = ko.observableArray([]);
      
    }
    eGateRoot.ModuleModel = ModuleModel;
}(window.eGateRoot));

