(function (eGateRoot) {
	var UserRegistrationModel = function (data) {

		var self = this;
		self.validationEnabled = ko.observable(false);
		self.UserId = ko.observable();
		self.UserName = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
		self.Password = ko.observable();
		self.FirstName = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
		self.LastName = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
		self.ContactNumber = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
		self.EmailId = ko.observable();
		self.PartnerId = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });
		self.PartnerType = ko.observable().extend({ required: { onlyIf: self.validationEnabled } });;
		self.PartnerTypeCode = ko.observable()
		self.ApplicationId = ko.observable();
		self.UserPortArray = ko.observableArray().extend({ required: { onlyIf: self.validationEnabled } });
		self.RecordStatus = ko.observable();
		self.IsDeleted = ko.observable();
		self.PartnerTypeArray = ko.observable();
		self.DormantStatus = ko.observable();
		self.UserRoleArray = ko.observableArray();
		self.PartnerTypeId = ko.observable();
		self.MemberTypeCode = ko.observable();
		//self.UserRoleArray = ko.observableArray().extend({ required: { onlyIf: self.validationEnabled } });
		self.PwdExpiryDate = ko.observable();
		self.validToDate = ko.observable();
		self.LogTime = ko.observable();
		self.InCorrectLogins = ko.observable();
        self.EmployeeGUID = ko.observable();
		self.UserPreference = ko.observableArray(data ? ko.utils.arrayMap(data.UserPreference, function (item) {
		    return new UserPreferenceModels(item);
		}) : []);

		self.cache = function () { };
		self.set(data);
	}


	var UserPreferenceModels = function (data) {

		var self = this;
		self.SendNotificationEmail = ko.observable(data ? (data.SendNotificationEmail) || "" : "");
		self.SendNotificationSms = ko.observable(data ? (data.SendNotificationSms) || "" : "");
		self.SendSystemNotification = ko.observable(data ? (data.SendSystemNotification) || "" : "");
		self.cache = function () { };

	}


	var UserRegistrationGridModel = function (data) {
		var self = this;
		self.UserId = ko.observable();
		self.UserName = ko.observable();
		self.FirstName = ko.observable();
		self.LastName = ko.observable();
		self.PartnerType = ko.observableArray();
		self.PartnerTypeArray = ko.observableArray();
		self.RecordStatus = ko.observable();
		self.EmailId = ko.observable();
		self.ContactNo = ko.observable();

		self.UserNameSort;
		self.UserName.subscribe(function (value) {

			self.UserNameSort = value;
		});


		self.FirstNameSort;
		self.FirstName.subscribe(function (value) {

			self.FirstNameSort = value;
		});

		self.LastNameSort;
		self.LastName.subscribe(function (value) {

			self.LastNameSort = value;
		});




		self.PartnerTypeSort;
		self.PartnerType.subscribe(function (value) {
			if (value != null) {
				self.PartnerTypeSort = value.trim();
			}
		});




		self.RecordStatusSort;
		self.RecordStatus.subscribe(function (value) {

			self.RecordStatusSort = value;
		});

		self.EmailIdSort;
		self.EmailId.subscribe(function (value) {

			self.EmailIdSort = value;
		});

		self.ContactNoSort;
		self.ContactNo.subscribe(function (value) {

			self.ContactNoSort = value;
		});



		self.set(data);

	}

	eGateRoot.UserRegistrationModel = UserRegistrationModel;
	eGateRoot.UserPreferenceModels = UserPreferenceModels;
	eGateRoot.UserRegistrationGridModel = UserRegistrationGridModel;

}(window.eGateRoot));

eGateRoot.UserRegistrationModel.prototype.set = function (data) {
	var self = this;

	self.UserId(data ? (data.UserId) || 0 : 0);
	self.UserName(data ? (data.UserName) || "" : "");
	self.Password(data ? (data.Password) || "" : "");
	self.FirstName(data ? data.FirstName || "" : "");
	self.LastName(data ? data.LastName || "" : "");
	self.ContactNumber(data ? data.ContactNumber || "" : "");
	self.EmailId(data ? data.EmailId || "" : "");
	self.PartnerType(data ? data.PartnerType || "" : "");
	self.PartnerTypeCode(data ? data.PartnerTypeCode || "" : "");
	self.ApplicationId(data ? data.ApplicationId || 0 : 0);
	self.PartnerId(data ? data.PartnerId || "" : "");
	self.RecordStatus(data ? data.RecordStatus || "" : "");
	self.DormantStatus(data ? data.DormantStatus || "" : "");
	self.PartnerTypeArray(data ? data.PartnerTypeArray || "" : "");
	self.UserPortArray(data ? data.PartnerPortArray : []);
	self.IsDeleted(data ? data.IsDeleted || "" : "");
	self.PwdExpiryDate(data ? kendo.toString(kendo.parseDate(data.PwdExpiryDate, ["dd-MM-yyyy HH:mm", "yyyy-MM-ddTHH:mm:ss"]), "dd-MM-yyyy") : "");
	self.validToDate(data ? kendo.toString(kendo.parseDate(data.validToDate, ["dd-MM-yyyy HH:mm", "yyyy-MM-ddTHH:mm:ss"]), "dd-MM-yyyy") : "");
	self.LogTime(data ? kendo.toString(kendo.parseDate(data.LogTime, ["dd-MM-yyyy HH:mm", "yyyy-MM-ddTHH:mm:ss"]), "dd-MM-yyyy") : "");
	self.InCorrectLogins(data ? data.InCorrectLogins || 0 : 0);

	//self.UserRoleArray(data ? data.RolesArray : []);


	self.UserPreference(data ? $.map(data.UserPreference, function (item) {
		return new eGateRoot.UserPreferenceModels(item);
	}) : new eGateRoot.UserPreferenceModels(data));


	self.cache.latestData = data;
}


eGateRoot.UserRegistrationGridModel.prototype.set = function (data) {
	var self = this;

	self.UserId(data ? data.UserId : "");
	self.UserName(data ? data.UserName : "");
	self.FirstName(data ? data.FirstName : "");
	self.LastName(data ? data.LastName : "");
	self.PartnerType(data ? data.PartnerType : "");
	self.PartnerTypeArray(data ? data.PartnerTypeArray : "");
	self.ContactNo(data ? data.ContactNumber : "");
	self.EmailId(data ? data.EmailId : "");
	self.RecordStatus(data ? data.RecordStatus == "A" ? "Active" : "Inactive" : "");


}

eGateRoot.UserRegistrationModel.prototype.reset = function () {
	this.set(this.cache.latestData);
}