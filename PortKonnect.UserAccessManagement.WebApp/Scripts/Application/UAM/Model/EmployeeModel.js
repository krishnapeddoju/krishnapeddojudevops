(function (eGateRoot) {
    var EmployeeModel = function (data) {

        var self = this;
        self.validationEnabled = ko.observable(false);
        self.EmployeeID = ko.observable();
        self.EmployeeNo = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'This field is required.' } });
        self.FirstName = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'This field is required.' } });
        self.LastName = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'This field is required.' } });
        self.OfficialMobileNo = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'This field is required.' } });
        self.PersonalMobileNo = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'This field is required.' } });
        self.EmailID = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'This field is required.' } });
        self.BirthDate = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'This field is required.' } });
        self.JoiningDate = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'This field is required.' } });
        self.Gender = ko.observable("GENM");
        self.Department = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'This field is required.' } });
        self.Designation = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'This field is required.' } });       

        self.ApplicationId = ko.observable();
        self.SubscriberId = ko.observable();

        self.RecordStatus = ko.observable("A");
        self.CreatedBy = ko.observable();
        self.CreatedOn = ko.observable();
        self.UpdatedBy = ko.observable();
        self.UpdatedOn = ko.observable();
        self.Status = ko.observable();

        self.GenderName = ko.observable();
        self.DepartmentName = ko.observable();
        self.DesignationName = ko.observable();
        self.LicenseCapability = ko.observable();

        self.cache = function () { };
        self.set(data);
    }

    var EmployeeGridModel = function (data) {
        var self = this;
        self.EmployeeID = ko.observable();
        self.EmployeeName = ko.observable();
        self.Department = ko.observable();
        self.DepartmentName = ko.observable();
        self.DesignationName = ko.observable();
        self.EmployeeNo = ko.observable();
        self.FirstName = ko.observable();
        self.LastName = ko.observable();

        self.RecordStatus = ko.observable();

        self.EmployeeNameSort;
        self.EmployeeName.subscribe(function (value) {
            self.EmployeeNameSort = value;
        });

        self.DepartmentNameSort;
        self.DepartmentName.subscribe(function (value) {
            self.DepartmentNameSort = value;
        });

        self.DesignationNameSort;
        self.DesignationName.subscribe(function (value) {
            self.DesignationNameSort = value;
        });

        self.EmployeeNoSort;
        self.EmployeeNo.subscribe(function (value) {
            self.EmployeeNoSort = value;
        });

        self.RecordStatusSort;
        self.RecordStatus.subscribe(function (value) {
            self.RecordStatusSort = value;
        });

        self.set(data);

    }
    eGateRoot.EmployeeModel = EmployeeModel;
    eGateRoot.EmployeeGridModel = EmployeeGridModel;
}(window.eGateRoot));

eGateRoot.EmployeeModel.prototype.set = function (data) {
    var self = this;

    self.EmployeeID(data ? (data.EmployeeID) || "" : "");
    self.EmployeeNo(data ? (data.EmployeeNo) || "" : "");
    self.FirstName(data ? (data.FirstName) || "" : "");
    self.LastName(data ? (data.LastName) || "" : "");
    self.OfficialMobileNo(data ? (data.OfficialMobileNo) || "" : "");
    self.PersonalMobileNo(data ? (data.PersonalMobileNo) || "" : "");
    self.EmailID(data ? (data.EmailID) || "" : "");    
    self.BirthDate(data ? (moment(data.BirthDate).format('DD-MM-YYYY') || "") : "");
    self.JoiningDate(data ? (moment(data.JoiningDate).format('DD-MM-YYYY') || "") : "");    
    self.Gender(data ? (data.Gender) || "" : "GENM");
    self.Department(data ? (data.Department) || "" : "");
    self.Designation(data ? (data.Designation) || "" : "");

    self.RecordStatus(data ? data.RecordStatus || "A" : "A");
    self.CreatedBy(data ? data.CreatedBy || "" : "");
    self.CreatedOn(data ? data.CreatedOn || "" : "");
    self.UpdatedBy(data ? data.UpdatedBy || "" : "");
    self.UpdatedOn(data ? data.UpdatedOn || "" : "");
    self.Status(data ? data.RecordStatus == "A" ? "Active" : "Inactive" : "");

    self.ApplicationId(data ? data.ApplicationId || "" : "");
    self.SubscriberId(data ? data.SubscriberId || "" : "");
    self.GenderName(data ? (data.Gender == "GENM" ? "Male" : "Female") || "" : "");
    self.DesignationName(data ? (data.DesignationName) || "" : "");
    self.DepartmentName(data ? (data.DepartmentName) || "" : "");
    self.LicenseCapability(data ? (data.LicenseCapability) || "" : "");

    self.cache.latestData = data;
}

eGateRoot.EmployeeGridModel.prototype.set = function (data) {
    var self = this;

    self.EmployeeID(data ? (data.EmployeeID) || "" : "");
    self.FirstName(data ? (data.FirstName) || "" : "");
    self.LastName(data ? (data.LastName) || "" : "");
    self.EmployeeName(data ? (data.EmployeeName) || "" : "");
    self.Department(data ? (data.Department) || "" : "");
    self.DepartmentName(data ? (data.DepartmentName) || "" : "");
    self.DesignationName(data ? (data.DesignationName) || "" : "");
    self.EmployeeNo(data ? (data.EmployeeNo) || "" : "");
    self.RecordStatus(data ? data.RecordStatus == "A" ? "Active" : "Inactive" : "");    
}

eGateRoot.EmployeeModel.prototype.reset = function () {
    this.set(this.cache.latestData);
}