(function (eGateRoot) {
    var SubCategoryModel = function (data) {

        var self = this;
        self.validationEnabled = ko.observable(false);
        self.SupCatId = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'This field is required.' } });
        self.SubCatId = ko.observable();
        self.SupCatCode = ko.observable();
        self.SubCatCode = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'This field is required.' } });
        self.SubCatName = ko.observable().extend({ required: { onlyIf: self.validationEnabled, message: 'This field is required.' } });       
        self.RecordStatus = ko.observable();
        self.CreatedBy = ko.observable();
        self.CreatedOn = ko.observable();
        self.UpdatedBy = ko.observable();
        self.UpdatedOn = ko.observable();

        self.Status = ko.observable();

        self.cache = function () { };
        self.set(data);
    }

    var SubCategoryGridModel = function (data) {
        var self = this;
        self.SupCatId = ko.observable();
        self.SubCatId = ko.observable();
        self.SupCatCode = ko.observable();
        self.SubCatCode = ko.observable();
        self.SubCatName = ko.observable();
        self.RecordStatus = ko.observable();        

     
          

        self.SubCatCodeSort;
        self.SubCatCode.subscribe(function (value) {
            self.SubCatCodeSort = value;
        });


        self.SubCatNameSort;
        self.SubCatName.subscribe(function (value) {
            self.SubCatNameSort = value;
        });

        self.RecordStatusSort;
        self.RecordStatus.subscribe(function (value) {
            self.RecordStatusSort = value;
        });

        self.set(data);

    }
    eGateRoot.SubCategoryModel = SubCategoryModel;
    eGateRoot.SubCategoryGridModel = SubCategoryGridModel;
}(window.eGateRoot));

eGateRoot.SubCategoryModel.prototype.set = function (data) {
    var self = this;
    
    self.SubCatId(data ? (data.SubCatId) || "" : "");
    self.SupCatId(data ? (data.SupCatId) || "" : "");
    self.SupCatCode(data ? (data.SupCatCode) || "" : "");
    self.SubCatCode(data ? (data.SubCatCode) || "" : "");
    self.SubCatName(data ? (data.SubCatName) || "" : "");

    self.RecordStatus(data ? data.RecordStatus || "A" : "A");
    self.CreatedBy(data ? data.CreatedBy || "" : "");
    self.CreatedOn(data ? data.CreatedOn || "" : "");
    self.UpdatedBy(data ? data.UpdatedBy || "" : "");
    self.UpdatedOn(data ? data.UpdatedOn || "" : "");
    self.Status(data ? data.RecordStatus == "A" ? "Active" : "Inactive" : "");


    self.cache.latestData = data;
}

eGateRoot.SubCategoryGridModel.prototype.set = function (data) {
    var self = this;
    self.SubCatId(data ? (data.SubCatId) || "" : "");
    self.SupCatId(data ? (data.SupCatId) || "" : "");
    self.SupCatCode(data ? (data.SupCatCode) || "" : "");
    self.SubCatCode(data ? data.SubCatCode : "");
    self.SubCatName(data ? data.SubCatName : "");
    self.RecordStatus(data ? data.RecordStatus == "A" ? "Active" : "Inactive" : ""); 
}

eGateRoot.SubCategoryModel.prototype.reset = function () {
    this.set(this.cache.latestData);
}