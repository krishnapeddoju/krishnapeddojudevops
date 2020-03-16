(function (eGateRoot) {
    var SuperCategoryModel = function (data) {

        var self = this;
        self.validationEnabled = ko.observable(false);
        self.SupCatId = ko.observable();
        self.SupCatCode = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'This field is required.' } });
        self.SupCatName = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'This field is required.' } });        
        self.RecordStatus = ko.observable();
        self.CreatedBy = ko.observable();
        self.CreatedOn = ko.observable();
        self.UpdatedBy = ko.observable();
        self.UpdatedOn = ko.observable();
        self.Status = ko.observable();

        self.cache = function () { };
        self.set(data);
    }

    var SuperCategoryGridModel = function (data) {
        var self = this;
        self.SupCatId = ko.observable();
        self.SupCatCode = ko.observable();
        self.SupCatName = ko.observable();
        self.RecordStatus = ko.observable();       

        self.SupCatCodeSort;
        self.SupCatCode.subscribe(function (value) {
            self.SupCatCodeSort = value;
        });


        self.SupCatNameSort;
        self.SupCatName.subscribe(function (value) {
            self.SupCatNameSort = value;
        });

        self.RecordStatusSort;
        self.RecordStatus.subscribe(function (value) {
            self.RecordStatusSort = value;
        });

        self.set(data);

    }
    eGateRoot.SuperCategoryModel = SuperCategoryModel;
    eGateRoot.SuperCategoryGridModel = SuperCategoryGridModel;
}(window.eGateRoot));

eGateRoot.SuperCategoryModel.prototype.set = function (data) {
    var self = this;
    
    self.SupCatId(data ? (data.SupCatId) || "" : "");
    self.SupCatCode(data ? (data.SupCatCode) || "" : "");
    self.SupCatName(data ? (data.SupCatName) || "" : "");
 
    self.RecordStatus(data ? data.RecordStatus || "A" : "A");
    self.CreatedBy(data ? data.CreatedBy || "" : "");
    self.CreatedOn(data ? data.CreatedOn || "" : "");
    self.UpdatedBy(data ? data.UpdatedBy || "" : "");
    self.UpdatedOn(data ? data.UpdatedOn || "" : "");
    self.Status(data ? data.RecordStatus == "A" ? "Active" : "Inactive" : "");

 
    self.cache.latestData = data;
}

eGateRoot.SuperCategoryGridModel.prototype.set = function (data) {
    var self = this;

    self.SupCatId(data ? (data.SupCatId) || "" : "");    
    self.SupCatCode(data ? data.SupCatCode : "");
    self.SupCatName(data ? data.SupCatName : "");
    self.RecordStatus(data ? data.RecordStatus == "A" ? "Active" : "Inactive" : "");
}

eGateRoot.SuperCategoryModel.prototype.reset = function () {
    this.set(this.cache.latestData);
}