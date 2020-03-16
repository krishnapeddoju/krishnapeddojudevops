(function (eGateRoot) {

	var UserRolesGridModel = function (data) {
		var self = this;
		self.validationEnabled = ko.observable(false);
		self.UserId = ko.observable();
		self.UserName = ko.observable();
		self.Name = ko.observable();
		self.ContactNumber = ko.observable();
		self.EmailId = ko.observable();
		self.PartnerId = ko.observable();
		self.PartnerType = ko.observable();
		self.UserRoleArray = ko.observableArray().extend({ required: { onlyIf: self.validationEnabled } });;
		self.UserRoleNameArray = ko.observable();

		self.UserNameSort;
		self.UserName.subscribe(function (value) {

			self.UserNameSort = value;
		});


		self.NameSort;
		self.Name.subscribe(function (value) {

			self.NameSort = value;
		});


		self.RoleNameSort;
		self.UserRoleNameArray.subscribe(function (value) {
			if (value != null) {
				self.RoleNameSort = value.trim();
			}
		});



		self.ContactNumberSort;
		self.ContactNumber.subscribe(function (value) {

			self.ContactNumberSort = value;
		});

		self.EmailIdSort;
		self.EmailId.subscribe(function (value) {

			self.EmailIdSort = value;
		});

		self.cache = function () { };
		self.set(data);
	}

	var UserRolesModel = function (data) {

		var self = this;
		self.UserId = ko.observable();
		self.UserName = ko.observable();
		self.Name = ko.observable();
		self.ContactNumber = ko.observable();
		self.EmailId = ko.observable();
		self.UserRoleArray = ko.observableArray();
		self.UserRoleNameArray = ko.observable();
		self.cache = function () { };
		self.set(data);


	}

	eGateRoot.UserRolesGridModel = UserRolesGridModel;
	eGateRoot.UserRolesModel = UserRolesModel;
}(window.eGateRoot));

eGateRoot.UserRolesModel.prototype.set = function (data) {
	var self = this;

	self.UserId(data ? (data.UserId) || 0 : 0);
	self.UserName(data ? (data.UserName) || "" : "");
	self.Name(data ? (data.Name) || "" : "");
	self.ContactNumber(data ? data.ContactNumber || "" : "");
	self.EmailId(data ? data.EmailId || "" : "");


	self.cache.latestData = data;
}

eGateRoot.UserRolesGridModel.prototype.set = function (data) {
	var self = this;

	self.UserId(data ? (data.UserId) || 0 : 0);
	self.UserName(data ? (data.UserName) || "" : "");
	self.Name(data ? (data.Name) || "" : "");
	self.ContactNumber(data ? data.ContactNumber || "" : "");
	self.EmailId(data ? data.EmailId || "" : "");
	self.UserRoleArray(data ? data.UserRoleArray : []);
	self.UserRoleNameArray(data ? data.UserRoleNameArray : "");
	self.PartnerId(data ? data.PartnerId : "");
	self.PartnerType(data ? data.PartnerType : "");
	self.cache.latestData = data;
}

eGateRoot.UserRolesModel.prototype.reset = function () {
	this.set(this.cache.latestData);
}