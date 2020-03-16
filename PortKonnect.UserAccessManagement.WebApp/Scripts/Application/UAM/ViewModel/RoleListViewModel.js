(function (eGateRoot) {
    var RoleListViewModel = function () {

        var self = this;
        $('#spnTitle').html("Roles List");
        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.validationHelper = new eGateRoot.ValidationHelper();
        self.viewMode = ko.observable();
        self.RoleModel = ko.observable();
        self.RoleGridModel= ko.observable();
        self.RolesList = ko.observableArray([]);

        self.LoadRoles = function () {
            self.viewModelHelper.apiGet('api/GetRoles', null,
             function (result) {
                 self.RolesList(ko.utils.arrayMap(result, function (item) {
                     return new eGateRoot.RoleGridModel(item);
                 }));
             }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }

        self.ViewRole = function (model) {
            window.location.href = "RoleView/" + model.RoleId();
        }
        self.EditRole = function (model) {

        	window.location.href = "Role/" + model.RoleId();
        }
        self.AddRole = function (model) {
            window.location.href = "Role";
        }

        self.Initialize = function () {
            self.RoleModel(new eGateRoot.RoleModel());
            self.RoleGridModel(new eGateRoot.RoleGridModel());
            self.LoadRoles();
            self.viewMode('List');
        }
        self.Initialize();
    }
    eGateRoot.RoleListViewModel = RoleListViewModel;
}(window.eGateRoot));