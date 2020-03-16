(function (eGateRoot) {

	var PendingPartnerRegistrationModel = function (data) {
		var self = this;
		self.validationEnabled = ko.observable(false);
		//self.TrainSummaryId = ko.observable('');
		self.RequisitionNo = ko.observable('');
		self.PartnerType = ko.observable('');
		self.PartnerName = ko.observable();
		self.RequestedDate = ko.observable();
		self.Remarks = ko.observable('');
		self.PartnerCode = ko.observable();
		self.UserName = ko.observable();
		self.FirstName = ko.observable();
		self.LastName = ko.observable();
		self.WFStatus = ko.observable();
		self.StatusDisplay = ko.observable();
	    self.PartnerTypeDisplay = ko.observable();
		self.UserRoleArray = ko.observableArray();
		
		self.RequisitionNoSort;
		self.RequisitionNo.subscribe(function (value) {
			self.RequisitionNoSort = value;
		});
		self.PartnerTypeSort;
		self.PartnerTypeDisplay.subscribe(function (value) {
			self.PartnerTypeSort = value;
		});
		self.PartnerNameSort;
		self.PartnerName.subscribe(function (value) {
			self.PartnerNameSort = value;
		});
		self.RequestedDateSort;
		self.RequestedDate.subscribe(function (value) {
			self.RequestedDateSort = value;
		});
		self.StatusDisplaySort;
		self.StatusDisplay.subscribe(function (value) {
		    self.StatusDisplaySort = value;
		});

       

		self.cache = function () { };
		self.set(data);
	}

	var PendingPartnerRegistrationSearchModel = function () {
	    var self = this;
	    self.PartnerName = ko.observable();
	    self.PartnerType = ko.observable('All');
	    self.WFStatus = ko.observable();
	   
	}


	eGateRoot.PendingPartnerRegistrationSearchModel = PendingPartnerRegistrationSearchModel;
	eGateRoot.PendingPartnerRegistrationModel = PendingPartnerRegistrationModel;

}(window.eGateRoot));

eGateRoot.PendingPartnerRegistrationModel.prototype.set = function (data) {
	var self = this;
	self.dateFormat = new eGateRoot.DateFormat();
	//self.TrainSummaryId(data ? (data.TrainSummaryId || '') : '');
	self.RequisitionNo(data ? (data.RequisitionNo || '') : '');
	self.PartnerType(data ? (data.PartnerType || '') : '');
	self.PartnerName(data ? (data.PartnerName || '') : '');
	self.RequestedDate(data ? kendo.toString(kendo.parseDate(data.CreatedOn, ["dd-MM-yyyy HH:mm", "yyyy-MM-ddTHH:mm:ss"]), "dd-MM-yyyy") : "");
	self.Remarks(data ? (data.Remarks || '') : '');
	self.PartnerCode(data ? (data.PartnerCode || '') : '');
	self.UserName(data ? (data.UserName || '') : '');
	self.FirstName(data ? (data.FirstName || '') : '');
	self.LastName(data ? (data.LastName || '') : '');
	self.WFStatus(data ? (data.WFStatus || '') : '');
	self.UserRoleArray(data ? data.UserRoleArray : []);

	if (!isEmpty(data)) {
	    if (data.WFStatus === 'New') {
	        self.StatusDisplay('New');
	    }
	    if (data.WFStatus === 'Approved') {
	        self.StatusDisplay('Approved');
	    }
	    if (data.WFStatus === 'Verified') {
	        self.StatusDisplay('Verified');
	    }
	    if (data.WFStatus === 'Rejected') {
	        self.StatusDisplay('Rejected');
	    }
	    if (data.WFStatus === 'RejectedAtVerification') {
	        self.StatusDisplay('Rejected At Verification');
	    }
	}

	if (!isEmpty(data)) {
	    if (data.PartnerType === 'CustomHouseAgent') {
	        self.PartnerTypeDisplay('Custom House Agent');
	    }
	    if (data.PartnerType === 'MandR') {
	        self.PartnerTypeDisplay('M & R');
	    }
	    if (data.PartnerType === 'VesselOperatingAgent') {
	        self.PartnerTypeDisplay('Vessel Operating Agent');
	    }
	    if (data.PartnerType === 'ContainerFreightStation') {
	        self.PartnerTypeDisplay('Container Freight Station');
	    }
	    if (data.PartnerType === 'ContainerOperatorAgent') {
	        self.PartnerTypeDisplay('Container Operator Agent');
	    }
	    if (data.PartnerType === 'ContainerFreightStation') {
	        self.PartnerTypeDisplay('Container Freight Station');
	    }
	} 
	self.cache.latestData = data;
}

eGateRoot.PendingPartnerRegistrationModel.prototype.reset = function () {
	this.set(this.cache.latestData);
}
