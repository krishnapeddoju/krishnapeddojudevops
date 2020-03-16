(function (eGateRoot) {
	var PartnerModel = function (data) {

		var self = this;
		self.validationEnabled = ko.observable(false);
		self.PartnerId = ko.observable();
		self.PartnerCode = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
		self.PartnerType = ko.observable()
		self.PartnerName = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
		self.PartnerPort = ko.observable();
		self.Application = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });;
		//self.PartnerAddres = ko.observableArray();
		//self.SubscriberMembers = ko.observableArray();
		// self.PartnerAddress = ko.observableArray([]);
		self.PartnerPortArray = ko.observableArray();
		self.PartnerTypeArrays = ko.observable();
		self.PartnerTypeArray = ko.observableArray().extend({ required: { onlyIf: self.validationEnabled } });;
		self.PartnerAddress = ko.observableArray(data ? ko.utils.arrayMap(data.PartnerAddress, function (item) {
			return new PartnerAddres(item);
		}) : []);

		//self.subscriptions = ko.observableArray(data ? ko.utils.arrayMap(data.subscriptions, function (item) {
		//    return new SubscriptionMember(item);
		//}) : []);


		self.cache = function () { };
		self.set(data);
	}


	var PartnerAddres = function (data) {
		var self = this;
		self.validationEnabled2 = ko.observable(false);
		self.HouseNumber = ko.observable(data ? data.HouseNumber : "").extend({ required: { onlyIf: self.validationEnabled } });
		self.StreetName = ko.observable(data ? data.StreetName : "").extend({ required: { onlyIf: self.validationEnabled } });
		self.AreaName = ko.observable(data ? data.AreaName : "").extend({ required: { onlyIf: self.validationEnabled } });
		self.TownOrCity = ko.observable(data ? data.TownOrCity : "").extend({ required: { onlyIf: self.validationEnabled } });
		self.State = ko.observable(data ? data.State : "").extend({ required: { onlyIf: self.validationEnabled } });
		self.Country = ko.observable(data ? data.Country : "").extend({ required: { onlyIf: self.validationEnabled } });
		self.ZipCode = ko.observable(data ? data.ZipCode : "").extend({ required: { onlyIf: self.validationEnabled } });
		self.ContactNumber = ko.observable(data ? data.ContactNumber : "").extend({ required: { onlyIf: self.validationEnabled } });
		self.EmailId = ko.observable(data ? data.EmailId : "").extend({ required: { onlyIf: self.validationEnabled } });
		self.WebSite = ko.observable(data ? data.WebSite : "").extend({ required: { onlyIf: self.validationEnabled } });
		self.UploadedFiles = ko.observableArray([]);
		self.LogoFileName = ko.observable(data ? data.LogoFileName : "");
		self.LogoPath = ko.observable(data ? data.LogoPath : "");
		self.cache = function () { };
	}


	var SubscriptionMember = function (data) {
		var self = this;
		self.SubscriberId = ko.observable();
		self.ApplicationId = ko.observable();
		self.MemberId = ko.observable();
		self.cache = function () { };
	}


	var PartnerGridModel = function (data) {

		var self = this;
		self.PartnerId = ko.observable();
		self.PartnerCode = ko.observable();
		self.PartnerName = ko.observable();
		self.PartnerType = ko.observable();
		self.PartnerTypeArray = ko.observableArray();
		self.EmailId = ko.observable();
		self.ContactNumber = ko.observable();
		self.SubscribedPort = ko.observable();
		self.PartnerTypeArrays = ko.observable();

		self.PartnerCodeSort;
		self.PartnerCode.subscribe(function (value) {

			self.PartnerCodeSort = value;
		});


		self.PartnerNameSort;
		self.PartnerName.subscribe(function (value) {

			self.PartnerNameSort = value;
		});

		self.PartnerTypeSort;
		self.PartnerTypeArrays.subscribe(function (value) {
			if (value != null) {
				self.PartnerTypeSort = value.trim();
			}
		});




		self.EmailSort;
		self.EmailId.subscribe(function (value) {

			self.EmailSort = value;
		});




		self.ContactNumberSort;
		self.ContactNumber.subscribe(function (value) {

			self.ContactNumberSort = value;
		});


		self.SubscribedPortSort;
		self.SubscribedPort.subscribe(function (value) {

			self.SubscribedPortSort = value;
		});

		self.set(data);

	}
	eGateRoot.PartnerModel = PartnerModel;
	eGateRoot.PartnerAddres = PartnerAddres;
	//eGateRoot.SubscriptionMember = SubscriptionMember;

	eGateRoot.PartnerGridModel = PartnerGridModel;
}(window.eGateRoot));


eGateRoot.PartnerModel.prototype.set = function (data) {
	var self = this;

	self.PartnerId(data ? (data.PartnerId) || 0 : 0);
	self.PartnerCode(data ? (data.PartnerCode) || "" : "");
	self.PartnerName(data ? (data.PartnerName) || "" : "");
	self.PartnerType(data ? (data.PartnerType) || "" : "");
	self.PartnerPort(data ? (data.PartnerPort) || 0 : 0);
	self.Application(data ? data.Application || 0 : 0);


	self.PartnerPortArray(data ? data.PartnerPortArray : []);
	self.PartnerTypeArray(data ? data.partnerTypeArray : []);


	self.PartnerAddress(data ? $.map(data.PartnerAddress, function (PartnerAddress) {
		return new eGateRoot.PartnerAddres(PartnerAddress);
	}) : new eGateRoot.PartnerAddres(data));


	//self.subscriptions(data ? $.map(data.subscriptions, function (SubscriptionMember) {
	//    return new eGateRoot.SubscriptionMember(SubscriptionMember);
	//}) : []);

	self.cache.latestData = data;
}


eGateRoot.PartnerGridModel.prototype.set = function (data) {
	var self = this;

	self.PartnerId(data ? data.PartnerId : "");
	self.PartnerCode(data ? data.PartnerCode : "");
	self.PartnerName(data ? data.PartnerName : "");
	self.PartnerType(data ? data.PartnerType : "");
	self.PartnerTypeArray(data ? data.partnerTypeArray : []);
	self.PartnerTypeArrays(data ? data.PartnerTypeArrays : "");
	self.EmailId(data ? data.EmailId : "");
	self.ContactNumber(data ? data.ContactNumber : "");
	self.SubscribedPort(data ? data.SubscribedPort : "");


}



eGateRoot.PartnerModel.prototype.reset = function () {
	this.set(this.cache.latestData);
}