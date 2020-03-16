(function (eGateRoot) {
	var PartnerListViewModel = function () {
		var self = this;
		$('#spnTitle').html("Partners List");
		self.viewModelHelper = new eGateRoot.ViewModelHelper();
		self.validationHelper = new eGateRoot.ValidationHelper();
		self.PartnerModel = ko.observable();
		self.PartnerGridModel = ko.observable();
		self.PartnerList = ko.observableArray([]);
		self.PartnerTypes = ko.observableArray([]);
		self.viewMode = ko.observable();



		self.LoadPartners = function () {

			self.viewModelHelper.apiGet('api/PartnersGridList', { PartnerName: "All", PartnerType: "All", EmailId: "All", ContactNumber: "All" },
              function (result) {
              	self.PartnerList(ko.utils.arrayMap(result, function (item) {
              		return new eGateRoot.PartnerGridModel(item);
              	}));
              	setTimeout(function () {
              	    $('#Grid').data().kendoGrid.dataSource.page(1);
              	    $("form.k-filter-menu button[type='reset']").trigger("click");
              	    $("#Grid").data("kendoGrid").dataSource.sort({});
              	});
              }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
		}


		self.Filterpartner = function () {
			var PartnerName = $("#SearchPartnerName").val();
			var PartnerType = $("#ddlPartnerType").val();
			var EmailId = $("#SearchEmailId").val();
			var ContactNumber = $("#SearchContactNumber").val();
			if (ContactNumber != "" && ContactNumber != null && ContactNumber != undefined) {
				ContactNumber = ContactNumber.replace(/(\)|\()|_|-+/g, '');
			}
			if (PartnerName == null || PartnerName == undefined || PartnerName == "") {
				PartnerName = "All";
			}

			if (PartnerType == null || PartnerType == undefined || PartnerType == "") {
				PartnerType = "All";
			}


			if (EmailId == null || EmailId == undefined || EmailId == "") {
				EmailId = "All";
			}

			if (ContactNumber == "" || ContactNumber == undefined || ContactNumber == null) {
				ContactNumber = "All";
			}

			self.viewModelHelper.apiGet('api/PartnersGridList', { PartnerName: PartnerName, PartnerType: PartnerType, EmailId: EmailId, ContactNumber: ContactNumber },
             function (result) {
             	self.PartnerList(ko.utils.arrayMap(result, function (item) {

             		return new eGateRoot.PartnerGridModel(item);
             	}));
             	    $('#Grid').data().kendoGrid.dataSource.page(1);
             	    $("form.k-filter-menu button[type='reset']").trigger("click");
             	    $("#Grid").data("kendoGrid").dataSource.sort({});
             }, null, null, false, application.viewbag.appSettings.uamapiUrl);


			$(document).ready(function () {
				$("#SearchContactNumber").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
				SetFocus();
			});
		}

		self.LoadPartnerTypes = function () {
			self.viewModelHelper.apiGet("api/PartnerTypes", null, function (result) {
				ko.mapping.fromJS(result, {}, self.PartnerTypes);
			}, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
		};



		self.ViewPartner = function (model) {
			window.location.href = "Partner/" + model.PartnerId() + "/" + "View";
		}

		self.EditPartner = function (model) {
			window.location.href = "Partner/" + model.PartnerId() + "/" + "Edit";
		}
		

		self.AddPartner = function (model) {
			window.location.href = "Partner";
		}

		self.ResetFilters = function (data) {
			self.PartnerGridModel(new eGateRoot.PartnerGridModel());
			self.LoadPartners();
			$(document).ready(function () {
				$("#SearchContactNumber").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
				SetFocus();
			});
		}

		self.Initialize = function () {

			self.PartnerModel(new eGateRoot.PartnerModel());
			self.PartnerGridModel(new eGateRoot.PartnerGridModel());
			self.LoadPartners();
			self.LoadPartnerTypes();
			self.viewMode('List');

			$(document).ready(function () {
				$("#SearchContactNumber").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
				SetFocus();
			});
		}

		self.Initialize();
	}
	eGateRoot.PartnerListViewModel = PartnerListViewModel;

}(window.eGateRoot));

function SetFocus() {
	$("#SearchContactNumber").bind("focus", function () {
		if (this.createTextRange) {
			var part = this.createTextRange();
			part.move("character", 0);
			part.select();
		} else if (this.setSelectionRange) {
			var maskedinput = this;
		    setTimeout(function() {
		        maskedinput.setSelectionRange(0, 0);
		    }, 0);
		}
	});

}








