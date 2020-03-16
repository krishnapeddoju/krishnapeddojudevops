(function (eGateRoot) {
    var RoleModel = function (data) {

        var self = this;
        self.validationEnabled = ko.observable(false);
        self.RoleId = ko.observable();
        self.RoleCode = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'This field is required.' } });
        self.RoleName = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'This field is required.' } });
        self.ApplicationId = ko.observable();
        self.SubscriberId = ko.observable();
        self.RecordStatus = ko.observable();
        self.CreatedBy = ko.observable();
        self.CreatedOn = ko.observable();
        self.UpdatedBy = ko.observable();
        self.UpdatedOn = ko.observable();
        self.RoleFunctionCodeArray = ko.observableArray([]);
        self.RoleFunctions = ko.observableArray([]);
        self.Modules = ko.observableArray([]);
        self.Entities = ko.observableArray([]);
        self.PartnerTypeArray = ko.observableArray([]);
        self.PartnerTypeNameArray = ko.observableArray([]);

        self.cache = function () { };
        self.set(data);
    }

    var RoleGridModel = function (data) {
        var self = this;
        self.RoleId = ko.observable();
        self.RoleCode = ko.observable();
        self.RoleName = ko.observable();
        self.RecordStatus = ko.observable();


        self.RoleCodeSort;
        self.RoleCode.subscribe(function (value) {
            self.RoleCodeSort = value;
        });


        self.RoleNameSort;
        self.RoleName.subscribe(function (value) {
            self.RoleNameSort = value;
        });

        self.RecordStatusSort;
        self.RecordStatus.subscribe(function (value) {
        	self.RecordStatusSort = value;
        });

        self.set(data);

    }
    eGateRoot.RoleModel = RoleModel;
    eGateRoot.RoleGridModel = RoleGridModel;
}(window.eGateRoot));

eGateRoot.RoleModel.prototype.set = function (data) {
    var self = this;

    self.RoleId(data ? (data.RoleId) || 0 : 0);
    self.RoleCode(data ? (data.RoleCode) || "" : "");
    self.RoleName(data ? (data.RoleName) || "" : "");
    self.ApplicationId(data ? (data.ApplicationId) || 0 : 0);
    self.SubscriberId(data ? (data.SubscriberId) || "" : "");
    self.RecordStatus(data ? data.RecordStatus || "A" : "A");
    self.CreatedBy(data ? data.CreatedBy || "" : "");
    self.CreatedOn(data ? data.CreatedOn || "" : "");
    self.UpdatedBy(data ? data.UpdatedBy || "" : "");
    self.UpdatedOn(data ? data.UpdatedOn || "" : "");

    self.RoleFunctionCodeArray(data ? data.RoleFunctionCodeArray : []);
    self.RoleFunctions(data ? data.RoleFunctions : []);
    self.Entities(data ? data.Entities : []);
    self.Modules(data ? data.Modules : []);    
    self.PartnerTypeArray(data ? data.PartnerTypeArray : []);
    self.PartnerTypeNameArray(data ? data.PartnerTypeNameArray : []);
    self.cache.latestData = data;
}

eGateRoot.RoleGridModel.prototype.set = function (data) {
    var self = this;

    self.RoleId(data ? data.RoleId : "");
    self.RoleCode(data ? data.RoleCode : "");
    self.RoleName(data ? data.RoleName : "");
    self.RecordStatus(data ? data.RecordStatus == "A" ? "Active" : "Inactive" : "");
}

eGateRoot.RoleModel.prototype.reset = function () {
    this.set(this.cache.latestData);
}