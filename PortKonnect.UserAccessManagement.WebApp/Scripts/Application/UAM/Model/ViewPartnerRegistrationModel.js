(function (eGateRoot) {
    var ViewPartnerRegistrationModel = function (data) {
        var self = this;
        self.validationEnabled = ko.observable(false);
        self.PartnerId = ko.observable();
        self.PartnerName = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
        self.PartnerType = ko.observable("");
        //self.PartnerCode = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
        self.Year = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
        self.Status = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
        self.CIN = ko.observable().extend({
            pattern: {
                params: /^([Ll|Uu]{1})([0-9]{5})([A-Za-z]{2})([0-9]{4})([A-Za-z]{3})([0-9]{6})?$/,
                message: "Please enter valid CIN. Ex:U33337EA4455ADF333222"
            }
        });
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
        self.FinanceName = ko.observable();
        self.FinanceEmail = ko.observable();
        self.FinanceMobile = ko.observable();
        self.OperationsName = ko.observable();
        self.OperationsEmail = ko.observable();
        self.OperationsMobile = ko.observable();

        self.ITName = ko.observable();
        self.ITEmail = ko.observable();
        self.ITMobile = ko.observable();

        self.DocumentType = ko.observable();//.extend({ required: { onlyIf: self.validationEnabled } });
        self.ValidTill = ko.observable();
        self.IsAccept = ko.observable();
        self.RequisitionNo = ko.observable();
        self.PartnerCode = ko.observable();
        self.UserName = ko.observable();
        self.FirstName = ko.observable();
        self.LastName = ko.observable();
        self.Remarks = ko.observable('');
        self.WFStatus = ko.observable();
        self.UserRoleArray = ko.observableArray();

        self.DocumentDTOs = ko.observableArray(data ? ko.utils.arrayMap(data.DocumentDTOs, function (document) {
            return new FileDocument(document);
        }) : []);

        //self.PartnerTypeArray = ko.observableArray().extend({ required: { onlyIf: self.validationEnabled } });

        //self.PartnerRegistrationAddress = ko.observableArray(data ? ko.utils.arrayMap(data.PartnerRegistrationAddress, function (PartnerRegistrationAddress) {
        //    return new PartnerRegistrationAddres(PartnerRegistrationAddress);
        //}) : []);

        self.PartnerRegistrationAddress = ko.observable(data ? new PartnerRegistrationAddres(data.PartnerRegistrationAddress) : null);
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

        self.PartnerRegistrationListDTO = ko.observable();

        self.cache = function () { };
        self.set(data);
    }


    var PartnerRegistrationAddres = function (data) {
        var self = this;
        //self.validationEnabled2 = ko.observable(false);
        self.HouseNumber = ko.observable(data ? data.HouseNumber : "").extend({ required: { onlyIf: self.validationEnabled } });
        self.StreetName = ko.observable(data ? data.StreetName : "").extend({ required: { onlyIf: self.validationEnabled } });
        self.AreaName = ko.observable(data ? data.AreaName : "").extend({ required: { onlyIf: self.validationEnabled } });
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
        //self.EmailId = ko.observable(data ? data.EmailId : "").extend({ required: { onlyIf: self.validationEnabled } });
        //self.WebSite = ko.observable(data ? data.WebSite : "").extend({ required: { onlyIf: self.validationEnabled } });
        self.UploadedFiles = ko.observableArray([]);
        self.LogoFileName = ko.observable(data ? data.LogoFileName : "");
        self.LogoPath = ko.observable(data ? data.LogoPath : "");
        self.cache = function () { };
    }

    var PartnerRegistrationListDTO = function (data) {
        var self = this;
        self.PartnerRegistrationId = ko.observable(data ? data.PartnerRegistrationId : "");
        self.PartnerName = ko.observable(data ? data.PartnerName : "");
        self.PartnerType = ko.observable(data ? data.PartnerType : "");
        self.RequisitionNo = ko.observable(data ? data.RequisitionNo : "");
        self.PartnerCode = ko.observable(data ? data.PartnerCode : "");
        self.UserName = ko.observable(data ? data.UserName : "");
        self.FirstName = ko.observable(data ? data.FirstName : "");
        self.LastName = ko.observable(data ? data.LastName : "");
        self.Remarks = ko.observable(data ? data.Remarks : "");
        self.UserRoleArray = ko.observableArray();
        self.CreatedOn = ko.observable(data ? data.CreatedOn : "");
        self.WFStatus = ko.observable(data ? data.WFStatus : "");
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
        self.Type = ko.observable(data ? data.Type : "");
        self.PCountryCode = ko.observable(data ? data.PCountryCode : "");
        self.ErrorStatus = ko.observable(false);
        self.ErrorStatusOperations = ko.observable(false);
        self.ErrorStatusIT = ko.observable(false);
        self.ErrorStatusFinance = ko.observable(false);
        self.ErrorStatusSales = ko.observable(false);
        self.IsDeleted = ko.observable("N");
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

    eGateRoot.ViewPartnerRegistrationModel = ViewPartnerRegistrationModel;
    eGateRoot.PartnerDirectorDetails = PartnerDirectorDetails;
    eGateRoot.PartnerRegistrationAddres = PartnerRegistrationAddres;
    eGateRoot.PartnerRegistrationListDTO = PartnerRegistrationListDTO;

}(window.eGateRoot));


eGateRoot.ViewPartnerRegistrationModel.prototype.set = function (data) {
    var self = this;

    self.PartnerId(data ? (data.PartnerId) || 0 : 0);
    self.PartnerName(data ? (data.PartnerName) || "" : "");
    self.PartnerType(data ? (data.PartnerType) || "" : "VOA");
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
    self.DocumentType(data ? (data.DocumentType) || "" : "");
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
    self.RequisitionNo(data ? data.RequisitionNo : '');
    self.PartnerCode(data ? data.PartnerCode : '');
    self.Remarks(data ? data.Remarks : '');
    self.WFStatus(data ? data.WFStatus : '');
    //self.PartnerRegistrationAddress(data ? $.map(data.PartnerRegistrationAddress, function (PartnerRegistrationAddress) {
    //    return new eGateRoot.PartnerRegistrationAddres(PartnerRegistrationAddress);
    //}) : new eGateRoot.PartnerRegistrationAddres(data));
    self.PartnerRegistrationListDTO(new eGateRoot.PartnerRegistrationListDTO());
    self.cache.latestData = data;
}

eGateRoot.ViewPartnerRegistrationModel.prototype.reset = function () {
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

    //self.CPDropdownByVesselVoyageMain(data ? data.CPDropdownByVesselVoyage : []);
    self.cache.latestData = data;
}

eGateRoot.PartnerDirectorDetails.prototype.reset = function () {
    this.set(this.cache.latestData);
}

//var PartnerRegistrationAddress = function (data) {
//    var self = this;
//    //self.validationEnabled2(false);
//    self.HouseNumber (data ? data.HouseNumber : "");
//    self.StreetName (data ? data.StreetName : "");
//    self.AreaName (data ? data.AreaName : "");
//    self.TownOrCity (data ? data.TownOrCity : "");
//    self.State (data ? data.State : "");
//    self.Country (data ? data.Country : "");
//    self.ZipCode (data ? data.ZipCode : "");
//    //self.ContactNumber (data ? data.ContactNumber : "");
//    //self.EmailId (data ? data.EmailId : "");
//    //self.WebSite (data ? data.WebSite : "");
//    self.LogoFileName(data ? data.LogoFileName : "");
//    self.LogoPath (data ? data.LogoPath : "");
//    self.cache = function () { };
//}
//eGateRoot.PartnerRegistrationAddress.prototype.reset = function () {
//    this.set(this.cache.latestData);
//}