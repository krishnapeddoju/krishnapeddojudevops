(function (eGateRoot) {
    var PartnerRegistrationModel = function (data) {
        var self = this;
        self.validationEnabled = ko.observable(false);
        self.PartnerId = ko.observable();
        self.PartnerName = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
        self.PartnerType = ko.observable();
        //self.PartnerCode = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
        self.Year = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
        self.Status = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
        self.CIN = ko.observable().extend({
            pattern: {
                params: /^([Ll|Uu]{1})([0-9]{5})([A-Za-z]{2})([0-9]{4})([A-Za-z]{3})([0-9]{6})?$/,
                message: "Please enter valid CIN. Ex:U33337EA4455ADF333222"
            }
        });
        //self.CIN = ko.observable().extend({
        //    required: { onlyIf: function () { return (self.validationEnabled && self.PartnerType() !== 'CustomHouseAgent' && self.PartnerType() !== undefined && self.PartnerType() !== "") } },
        //    pattern: {
        //        params: /^([Ll|Uu]{1})([0-9]{5})([A-Za-z]{2})([0-9]{4})([A-Za-z]{3})([0-9]{6})?$/,
        //        message: "Please enter valid CIN."
        //    }
        //});
        self.PAN = ko.observable().extend({
            required: { onlyIf: self.validationEnabled },
            pattern: {
                params: /^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$/,
                message: "Please enter valid PAN Number. Ex:AAAAA7867P"
            }
        });
        self.TAN = ko.observable().extend({
            pattern: {
                // params: /^([a-zA-Z]){4}([0-9]){5}([a-zA-Z]){1}?$/,
                params: /^[0-9|A-Za-z]{10,10}?$/,
                message: "Please enter valid TAN Number."
            }
        }); 
        self.NatureOfBusiness = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
        self.Place = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
        self.RegistrationNo = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
        self.VAT = ko.observable().extend({
            required: { onlyIf: self.validationEnabled },
            pattern: {
                params: /^[0-9|A-Za-z]{15,15}?$/,
                message: "Please enter valid GST/Service Tax/VAT Regn. No."
            }
        });
        self.BankName = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
        self.BankAddress = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
        self.AccountNo = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
        self.IFSCCode = ko.observable().extend({
            required: { onlyIf: self.validationEnabled }, pattern: {
                params: /^[0-9|A-Za-z]{11,11}?$/,
                message: "Please enter valid IFSC Code"
            }
        });     
        //self.IFSCCode = ko.observable().extend({
        //    required: { onlyIf: self.validationEnabled }, pattern: {
        //        params: /^[A-Z|a-z]{4}[0][\d]{6}?$/,
        //        message: "Please enter valid IFSC Code"
        //    }
        //});
        self.FinanceName = ko.observable();
        self.FinanceEmail = ko.observable();
        self.FinanceMobile = ko.observable();
        self.OperationsName = ko.observable();
        self.OperationsEmail = ko.observable();
        self.OperationsMobile = ko.observable();

        self.ITName = ko.observable();
        self.ITEmail = ko.observable();
        self.ITMobile = ko.observable();

        self.DocumentType = ko.observable();
        self.ValidTill = ko.observable();
        self.IsAccept = ko.observable();

        self.RequisitionNo = ko.observable();
        self.ContactNumber2 = ko.observable();
        self.Email2 = ko.observable().extend({
            pattern: {
                params: /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i,
                message: "Please enter valid Email Id."
            }
        });

        self.DocumentDTOs = ko.observableArray(data ? ko.utils.arrayMap(data.DocumentDTOs, function (document) {
            return new FileDocument(document);
        }) : []);

        //self.PartnerTypeArray = ko.observableArray().extend({ required: { onlyIf: self.validationEnabled } });

        self.PartnerRegistrationAddress = ko.observableArray(data ? ko.utils.arrayMap(data.PartnerRegistrationAddress, function (PartnerRegistrationAddress) {
            return new PartnerRegistrationAddres(PartnerRegistrationAddress);
        }) : []);

        self.PartnerRegistrationAddressEdit = ko.observable();

        //self.partnerRegistrationDocs = ko.observableArray(data ? ko.utils.arrayMap(data.partnerRegistrationDocs, function (document) {
        //    return new FileDocument(document);
        //}) : []);

        self.PartnerDirectorDetailss = ko.observableArray(data ? ko.utils.arrayMap(data.PartnerDirectorDetailss, function (PartnerDirectorDetailss) {
            return new PartnerDirectorDetails(PartnerDirectorDetailss);
        }) : []);

        self.PartnerOperationsDetailss = ko.observableArray(data ? ko.utils.arrayMap(data.PartnerOperationsDetailss, function (PartnerOperationsDetailss) {
            return new PartnerDirectorDetails(PartnerOperationsDetailss);
        }) : []);

        self.PartnerITDetailss = ko.observableArray(data ? ko.utils.arrayMap(data.PartnerITDetailss, function (PartnerITDetailss) {
            return new PartnerDirectorDetails(PartnerITDetailss);
        }) : []);

        self.PartnerFinanceDetailss = ko.observableArray(data ? ko.utils.arrayMap(data.PartnerFinanceDetailss, function (PartnerFinanceDetailss) {
            return new PartnerDirectorDetails(PartnerFinanceDetailss);
        }) : []);

        self.PartnerSalesDetailss = ko.observableArray(data ? ko.utils.arrayMap(data.PartnerSalesDetailss, function (PartnerSalesDetailss) {
            return new PartnerDirectorDetails(PartnerSalesDetailss);
        }) : []);

        self.cache = function () { };
        self.set(data);
    }


    var PartnerRegistrationAddres = function (data) {
        var self = this;
        //self.validationEnabled2 = ko.observable(false);
        self.HouseNumber = ko.observable(data ? data.HouseNumber : "").extend({ required: { onlyIf: self.validationEnabled } });
        self.StreetName = ko.observable(data ? data.StreetName : "");
        self.AreaName = ko.observable(data ? data.AreaName : "");
        self.TownOrCity = ko.observable(data ? data.TownOrCity : "").extend({ required: { onlyIf: self.validationEnabled } });
        self.State = ko.observable(data ? data.State : "").extend({ required: { onlyIf: self.validationEnabled } });
        self.Country = ko.observable(data ? data.Country : "").extend({ required: { onlyIf: self.validationEnabled } });
        self.ZipCode = ko.observable(data ? data.ZipCode : "").extend({
            pattern: {
                params: /^[0-9]{6,6}?$/,
                message: "Please enter valid Zip Code."
            }
        });
        //self.ContactNumber = ko.observable(data ? data.ContactNumber : "").extend({ required: {PDirectorMobile onlyIf: self.validationEnabled } });
        self.Email = ko.observable(data ? data.Email : "").extend({
            pattern: {
                params: /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i,
                message: "Please enter valid Email Id."
            }
        });
        //self.WebSite = ko.observable(data ? data.WebSite : "").extend({ required: { onlyIf: self.validationEnabled } });
        self.MobileNumber = ko.observable(data ? data.MobileNumber : "").extend({
            pattern: {
                params: /^[0-9-]{10,12}?$/,
                message: "Please enter valid Mobile Number."
            }
        });
        self.UploadedFiles = ko.observableArray([]);
        self.LogoFileName = ko.observable(data ? data.LogoFileName : "");
        self.LogoPath = ko.observable(data ? data.LogoPath : "");
        self.cache = function () { };
    }


    var PartnerDirectorDetails = function (data) {
        var self = this;
        self.PDirectorDetailsId = ko.observable(data ? data.PDirectorDetailsId : "");
        self.PDirectorName = ko.observable(data ? data.PDirectorName : "");
        self.PDirectorPAN = ko.observable(data ? data.PDirectorPAN : "").extend({
            pattern: {
                params: /^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$/,
                message: "Please enter valid PAN Number. Ex:AAAAA7867P"
            }
        });
        self.PDirectorAddress = ko.observable(data ? data.PDirectorAddress : "");
        self.PDirectorMobile = ko.observable(data ? data.PDirectorMobile : "").extend({
            pattern: {
                params: /^[0-9-]{10,12}?$/,
                message: "Please enter valid Mobile Number."
            }
        });
        self.PDirectorTele = ko.observable(data ? data.PDirectorTele : "").extend({
            pattern: {
                params: /^[0-9-()]{13,17}?$/,
                message: " "
            }
        });
        self.PDirectorEmail = ko.observable(data ? data.PDirectorEmail : "").extend({
            pattern: {
                params: /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i,
                message: "Please enter valid Email Id."
            }
        });
        self.PCountryCode = ko.observable(data ? data.PCountryCode : "");
        self.Type = ko.observable(data ? data.Type : "");
        self.IsDeleted = ko.observable();
        self.ErrorStatus = ko.observable(false);
        self.ErrorStatusOperations = ko.observable(false);
        self.ErrorStatusIT = ko.observable(false);
        self.ErrorStatusFinance = ko.observable(false);
        self.ErrorStatusSales = ko.observable(false);

        self.cache = function () { };
        self.set(data);
    }



    var FileDocument = function (data) {
        var self = this;
        self.Id = ko.observable(data ? data.Id : '');
        self.FileName = ko.observable(data ? data.FileName : '');
        self.OriginalName = ko.observable(data ? data.OriginalName : '');
        self.FilePath = ko.observable(data ? data.FilePath : '');
        self.FileType = ko.observable(data ? data.FileType : '');
        self.ReferenceNumber = ko.observable(data ? data.ReferenceNumber : '');
        self.EntityType = ko.observable(data ? data.EntityType : '');
        self.AppId = ko.observable(data ? data.AppId : "");
        self.SubscriberId = ko.observable(data ? data.SubscriberId : '');
        self.DocumentType = ko.observable(data ? data.DocumentType : '');
        self.UploadedDate = ko.observable(data ? kendo.toString(kendo.parseDate(data.UploadedDate, ["dd-MM-yyyy HH:mm", "yyyy-MM-ddTHH:mm:ss"]), "dd-MM-yyyy") : "");
        self.ValidTill = ko.observable(data ? kendo.toString(kendo.parseDate(data.ValidTill, ["dd-MM-yyyy HH:mm", "yyyy-MM-ddTHH:mm:ss"]), "dd-MM-yyyy") : "");
        self.IsCurrentdoc = ko.observable(data ? data.IsCurrentdoc == 'Y' ? data.IsCurrentdoc : 'N' : 'N');
        self.IsDeleted = ko.observable(data ? data.IsDeleted : "N");
        self.ErrorStatusDocument = ko.observable(false);
    }


    eGateRoot.FileDocument = FileDocument;

    eGateRoot.PartnerRegistrationModel = PartnerRegistrationModel;
    eGateRoot.PartnerDirectorDetails = PartnerDirectorDetails;
    eGateRoot.PartnerRegistrationAddres = PartnerRegistrationAddres;

}(window.eGateRoot));


eGateRoot.PartnerRegistrationModel.prototype.set = function (data) {
    var self = this;

    self.PartnerId(data ? (data.PartnerId) || 0 : 0);
    self.PartnerName(data ? (data.PartnerName) || "" : "");
    self.PartnerType(data ? (data.PartnerType) || "" : "");
    //self.PartnerCode(data ? (data.PartnerCode) || "" : "");
    self.Year(data ? (data.Year) || "" : "");
    self.Status(data ? (data.Status) || "" : "");
    self.CIN(data ? (data.CIN) || "" : "");
    self.PAN(data ? (data.PAN) || "" : "");
    self.TAN(data ? (data.TAN) || "" : "");
    self.NatureOfBusiness(data ? (data.NatureOfBusiness) || "" : "");
    self.Place(data ? (data.Place) || "" : "");
    self.RegistrationNo(data ? (data.RegistrationNo) || "" : "");
    self.VAT(data ? (data.VAT) || "" : "");
    //self.DocumentType(data ? (data.DocumentType) || "" : "");
    self.ValidTill(data ? (data.ValidTill) || "" : "");
    self.BankName(data ? (data.BankName) || "" : "");
    self.BankAddress(data ? (data.BankAddress) || "" : "");

    self.AccountNo(data ? (data.AccountNo) || "" : "");
    self.IFSCCode(data ? (data.IFSCCode) || "" : "");
    self.FinanceName(data ? (data.FinanceName) || "" : "");
    self.FinanceEmail(data ? (data.FinanceEmail) || "" : "");
    self.FinanceMobile(data ? (data.FinanceMobile) || "" : "");
    self.OperationsName(data ? (data.OperationsName) || "" : "");
    self.OperationsEmail(data ? (data.OperationsEmail) || "" : "");
    self.OperationsMobile(data ? (data.OperationsMobile) || "" : "");
    self.ITName(data ? (data.ITName) || "" : "");
    self.ITEmail(data ? (data.ITEmail) || "" : "");
    self.ITMobile(data ? (data.ITMobile) || "" : "");
    self.IsAccept(data ? data.IsAccept : false);

    self.PartnerRegistrationAddress(data ? $.map(data.PartnerRegistrationAddress, function (PartnerRegistrationAddress) {
        return new eGateRoot.PartnerRegistrationAddres(PartnerRegistrationAddress);
    }) : new eGateRoot.PartnerRegistrationAddres(data));

    self.PartnerRegistrationAddressEdit({
        HouseNumber: ko.observable(data ? data.PartnerRegistrationAddress ? data.PartnerRegistrationAddress.HouseNumber : "": ""),
        StreetName: ko.observable(data ? data.PartnerRegistrationAddress ? data.PartnerRegistrationAddress.StreetName : "": ""),
        AreaName: ko.observable(data ? data.PartnerRegistrationAddress ?  data.PartnerRegistrationAddress.AreaName : "": ""),
        TownOrCity: ko.observable(data ? data.PartnerRegistrationAddress ? data.PartnerRegistrationAddress.TownOrCity : "": ""),
        State: ko.observable(data ? data.PartnerRegistrationAddress ? data.PartnerRegistrationAddress.State : "": ""),
        Country: ko.observable(data ? data.PartnerRegistrationAddress ? data.PartnerRegistrationAddress.Country : "": ""),
        ZipCode: ko.observable(data ? data.PartnerRegistrationAddress ? data.PartnerRegistrationAddress.ZipCode : "": ""),
        Email: ko.observable(data ? data.PartnerRegistrationAddress ? data.PartnerRegistrationAddress.Email : "" : ""),
        MobileNumber: ko.observable(data ? data.PartnerRegistrationAddress ? data.PartnerRegistrationAddress.MobileNumber : "" : ""),
        LogoFileName: ko.observable(data ? data.PartnerRegistrationAddress ? data.PartnerRegistrationAddress.LogoFileName : "": ""),
        LogoPath: ko.observable(data ? data.PartnerRegistrationAddress ? data.PartnerRegistrationAddress.LogoPath : "" : ""),
        UploadedFiles : ko.observableArray([])
       });

    self.cache.latestData = data;
}

eGateRoot.PartnerRegistrationModel.prototype.reset = function () {
    this.set(this.cache.latestData);
}

eGateRoot.PartnerDirectorDetails.prototype.set = function (data) {
    var self = this;
    self.PDirectorDetailsId(data ? data.PDirectorDetailsId : "");
    self.PDirectorName(data ? data.PDirectorName : "");
    self.PDirectorPAN(data ? data.PDirectorPAN : "");
    self.PDirectorAddress(data ? data.PDirectorAddress : "");
    self.PDirectorMobile(data ? data.PDirectorMobile : "");
    self.PDirectorTele(data ? data.PDirectorTele : "");
    self.PDirectorEmail(data ? data.PDirectorEmail : "");
    self.IsDeleted(data ? data.IsDeleted : "N");
    self.cache.latestData = data;
}

eGateRoot.PartnerDirectorDetails.prototype.reset = function () {
    this.set(this.cache.latestData);
}
