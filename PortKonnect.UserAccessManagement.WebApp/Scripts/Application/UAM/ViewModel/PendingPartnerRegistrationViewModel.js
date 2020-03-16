(function (eGateRoot) {
    ko.validation.configure({
        registerExtenders: true,
        messagesOnModified: true,
        insertMessages: true,
        parseInputAttributes: true,
        messageTemplate: null
    });
    ko.validation.registerExtenders();

    var PendingPartnerRegistrationViewModel = function (userRole) {
        var self = this;
        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.viewMode = ko.observable();
        self.PendingPartnerRegistrationModel = ko.observable();
        self.PendingRegistrationList = ko.observableArray();
        self.AdvanceSearch = ko.observable(new eGateRoot.PendingPartnerRegistrationSearchModel());
        self.validationHelper = new eGateRoot.ValidationHelper();
        self.ToasterStaticValue = new eGateRoot.ToasterStaticValue();
        self.IsRemarksVisible = ko.observable(true);
        self.IsPageLoad = ko.observable(true);
        self.IsReject = ko.observable(false);
        self.IsApprove = ko.observable(false);
        self.IsVerify = ko.observable(false);
        self.ReqNo = ko.observable('');
        self.PartnerTypeCode = ko.observable('');
        self.LoadUserIdAndUsers = ko.observableArray([]);
        self.UserIdsAndUsers = ko.observableArray([]);
        self.partnerCodes = ko.observableArray([]);
        self.Roles = ko.observableArray([]);
        self.PartnerTypeVals = ko.observableArray([{ name: 'All', val: 'All' },
            { name: 'Container Freight Station', val: 'ContainerFreightStation' },
            { name: 'Container Operator Agent', val: 'ContainerOperatorAgent' },
            { name: 'Custom House Agent', val: 'CustomHouseAgent' },
            { name: 'M & R', val: 'MandR' },
            { name: 'Vessel Operating Agent', val: 'VesselOperatingAgent' }]);
        self.UserRole = ko.observable(userRole);
        toastr.options.closeButton = true;
        toastr.options.positionClass = self.ToasterStaticValue.Toast_Top_Right();

        //#region Initialize
        self.Initialize = function () {
            self.viewMode = ko.observable(true);
            self.PendingPartnerRegistrationModel(new eGateRoot.PendingPartnerRegistrationModel());
            self.AdvanceSearch().WFStatus(userRole === 'ACC' ? 'New' : '');
            self.LoadPendingRegistrationList();
            self.LoadUsersAndUserIds();
            self.viewMode('List');
        }
        //#endregion Initialize


        self.GetRoles = function (model) {

            self.viewModelHelper.apiGet("api/GetRolesByPartnerType/" + model.PartnerType(), null, function (result) {
                ko.mapping.fromJS(result, {}, self.Roles);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl);

        }


        //#region Load Pending Registration List
        self.LoadPendingRegistrationList = function () {
            self.viewModelHelper.apiGet('api/PendingPartnerRegistrationsGridList', { estbName: isEmpty(self.AdvanceSearch().PartnerName())?'All':self.AdvanceSearch().PartnerName(), partnerType: self.AdvanceSearch().PartnerType(), status: self.AdvanceSearch().WFStatus() },
                function (result) {
                    self.PendingRegistrationList(ko.utils.arrayMap(result, function (item) {
                        return new eGateRoot.PendingPartnerRegistrationModel(item);
                    }));
                    setTimeout(function () {
                        $('#Grid').data().kendoGrid.dataSource.page(1);
                        $("form.k-filter-menu button[type='reset']").trigger("click");
                        $("#Grid").data("kendoGrid").dataSource.sort({});
                    });
                }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }
        //#endregion 

        self.FilterPartnerRegistrations = function () {
            self.LoadPendingRegistrationList();
        }

        self.ResetAdvanceSearchFilters = function () {
            self.AdvanceSearch(new eGateRoot.PendingPartnerRegistrationSearchModel());
            self.AdvanceSearch().WFStatus(userRole === 'ACC' ? 'New' : 'Verified');
            self.LoadPendingRegistrationList();
        }
        
        self.GetPartnerCode = function () {

            var PartnerTypeName = [];


            PartnerTypeName.push(self.PartnerTypeCode());




            self.viewModelHelper.apiGet("api/GetPartnerCodes", { partnerType: PartnerTypeName }, function (result) {
                ko.mapping.fromJS(result, {}, self.partnerCodes);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');


        }

        self.LoadUsersAndUserIds = function () {
            self.viewModelHelper.apiGet("api/GetUserIdAndNames", null, function (result) {
                ko.mapping.fromJS(result, {}, self.LoadUserIdAndUsers);
                ko.mapping.fromJS(result, {}, self.UserIdsAndUsers);

            }, null, null, false, application.viewbag.appSettings.uamapiUrl);

        };




        self.DupliacteValidation = function (model) {

            self.GetPartnerCode(model);
            if ($('#txtAreaPartnerCode').val() == "") {
                toastr.warning(" * Please Enter Partner Code");

            }

            else {
                $.each(self.partnerCodes(), function (k, v) {
                    $('#spanApprove').text('');
                    if (v.PartnerCode().toUpperCase() == $('#txtAreaPartnerCode').val().toUpperCase()) {
                        toastr.warning("Partner Code Already Exists");
                    }
                });
            }
        }



        self.validateUserName = function (model) {
            $.each(self.LoadUserIdAndUsers(), function (i, val) {
                if ($('#txtAreaUserName').val() == "") {
                    toastr.warning(" * Please Enter User Name");
                }
                else if (val.UserName().toUpperCase() == $('#txtAreaUserName').val().toUpperCase()) {
                    toastr.warning("Username Already exists");
                }
                else {
                    $('#spanUserName').text('');
                }
            });
        }


        //#region ResetFilters
        self.ResetFilters = function () {
            self.PendingPartnerRegistrationModel(new eGateRoot.PendingPartnerRegistrationModel());
            self.LoadPendingRegistrationList();
        }
        //#endregion ResetFilters

        //#region ViewForm
        self.ViewForm = function (model) {
            window.location.href = "PendingPartnerRegistrationView/" + model.RequisitionNo();
        }
        //#endregion ViewForm

        //#region EditForm
        self.EditForm = function (model) {
            window.location.href = "PendingPartnerRegistrationEdit/" + model.RequisitionNo();
        }
        //#endregion ViewForm

        //#region Reject Functionality
        self.closeRejectPopup = function () {
            $('#reject').modal('hide');
        }

        self.closeRejectBulkPopup = function () {
            $('#rejectBulk').modal('hide');
            $('#spanUserName').text('');
            $('#spanFirstName').text('');
            $('#spanLastName').text('');
            $('#spanReject').text('');
            $('#spanApprove').text('');

        }

        self.ShowContainersPopup = function (model, e) {

            self.PendingPartnerRegistrationModel().validationEnabled(false);
            //var checkFlag = false;
            //for (var i = 0; i < self.ImportRailFormsList().length; i++) {
            //    if (self.ImportRailFormsList()[i].Ischecked() === true && self.ImportRailFormsList()[i].IsEndorsed() === 'N') {
            //        checkFlag = true;
            //    }
            //}
            self.ReqNo(model.RequisitionNo());
            self.PartnerTypeCode(model.PartnerType());
            if (e.currentTarget.id === 'btnReject' || e.currentTarget.id === 'btnRejectVerification') {
                self.IsReject(true);
                self.IsApprove(false);
                self.IsVerify(false);
                self.IsRemarksVisible(true);
                $('#spanReject').text('');
                $('#txtAreaRejectsRemarks').val("");
                $('#lblRejectsContainer').text("Are you sure you want to Reject Selected Partner?");
                $('#lblMainHeading').text('Partner Registration Rejection');
            }
            else if (e.currentTarget.id === 'btnApprove') {

                self.IsReject(false);
                self.IsApprove(true);
                self.IsVerify(false);

                self.GetRoles(model);

                var multiSelect = $('#userPort').data("kendoMultiSelect");
                multiSelect.value([]);
                $('#lblMainHeading').text('Partner Registration Approval');
                $('#txtAreaPartnerCode').val('');
                $('#txtAreaUserName').val('');
                $('#txtAreaFirstName').val('');
                $('#txtAreaLastName').val('');
                $('#spanApprove').text('');
                $('#spanUserName').text('');
                $('#spanFirstName').text('');
                $('#spanLastName').text('');
                $("#lblRejectsContainer").text("Are you sure you want to Approve Selected Partner?");
                $('#spnrole').text('');
                self.IsRemarksVisible(true);
            } else {
                self.IsReject(false);
                self.IsApprove(false);
                self.IsVerify(true);

                self.IsRemarksVisible(false);
                $('#lblMainHeading').text('Partner Registration Verification');
                $("#lblRejectsContainer").text("Are you sure you want to Verify Selected Partner?");


            }
        }

        HandleValidateRejectRemarks = function (event) {
            if (event.id === "txtAreaRejectsRemarks" && $("#txtAreaRejectsRemarks").val().trim() === "") {
                $("#spanReject").text('* Please Enter Reason');
            } else if (event.id === "txtAreaRemarks" && $('#txtAreaRemarks').val().trim() === "") {
                $('#spanReject').text('* Please Enter Reason');
            } else {
                $("#spanReject").text('');
            }
        }

        self.RejectsForm = function (model) {
            if ($('#txtAreaRejectsRemarks').val().trim() === "") {
                $('#spanReject').text('* Please Enter Reason');
            } else {
                $('#rejectBulkClose').trigger('click');
                model.Remarks($('#txtAreaRejectsRemarks').val());
                model.RequisitionNo(self.ReqNo());
                    self.viewModelHelper.apiPost('api/RejectPartnerRegistration', ko.mapping.toJSON(model), function message(data) {
                        toastr.options.closeButton = true;
                        toastr.options.positionClass = "toast-top-right";
                        toastr.success("Partner Registration rejected successfully", "Partner Registration");
                        setTimeout(
                                function () {
                                    window.location.href = "/PendingPartnerRegistrations";
                                }, 2000);
                    }, null, false, application.viewbag.appSettings.uamapiUrl, null, 'UAM');
            }
        }

        //self.RejectVerificationForm = function (model) {
        //    if ($('#txtAreaRejectsRemarks').val().trim() === "") {
        //        $('#spanReject').text('* Please Enter Reason');
        //    } else {
        //        $('#rejectBulkClose').trigger('click');
        //        model.Remarks($('#txtAreaRejectsRemarks').val());
        //        model.RequisitionNo(self.ReqNo());
        //        self.viewModelHelper.apiPost('api/RejectPartnerVerification', ko.mapping.toJSON(model), function message(data) {
        //            toastr.options.closeButton = true;
        //            toastr.options.positionClass = "toast-top-right";
        //            toastr.success("Partner Registration rejected successfully", "Partner Registration");
        //            setTimeout(
        //                    function () {
        //                        window.location.href = "/PendingPartnerRegistrations";
        //                    }, 2000);
        //        }, null, false, application.viewbag.appSettings.uamapiUrl, null, 'UAM');
        //    }
        //}
        //#endregion

        //#region Approval
        self.ApproveForm = function (model) {
            var errors = 0;
            self.GetPartnerCode(model);
            $.each(self.LoadUserIdAndUsers(), function (i, val) {
                if ($('#txtAreaPartnerCode').val() !== '') {
                    if (val.UserName().toUpperCase() == $('#txtAreaUserName').val().toUpperCase()) {
                        toastr.warning("Username Already exists", "User");
                        errors = errors + 1;
                        return;
                    }
                }
            });

            $.each(self.partnerCodes(), function (k, v) {

                if (v.PartnerCode().toUpperCase() == $('#txtAreaPartnerCode').val().toUpperCase()) {
                    toastr.warning("Partner Code Already Exists", "Partner");
                    errors = errors + 1;
                    return;

                }


            });

            if ($('#txtAreaPartnerCode').val().trim() === "") {
                $('#spanApprove').text('* Please Enter Partner Code');
                errors = errors + 1;
            }

            if ($('#txtAreaUserName').val().trim() === "") {
                $('#spanUserName').text('* Please Enter User Name');
                errors = errors + 1;
            }

            if ($('#txtAreaFirstName').val().trim() === "") {
                $('#spanFirstName').text('* Please Enter First Name');
                errors = errors + 1;
            }

            if ($('#txtAreaLastName').val().trim() === "") {
                $('#spanLastName').text('* Please Enter Last Name');
                errors = errors + 1;
            }

            if (model.UserRoleArray().length === 0) {
                $('#spnrole').text('* Please Select Role');
                errors = errors + 1;
            }

            else if (errors == 0) {
                $('#rejectBulkClose').trigger('click');
                model.PartnerCode($('#txtAreaPartnerCode').val());
                model.UserName($('#txtAreaUserName').val());
                model.FirstName($('#txtAreaFirstName').val());
                model.LastName($('#txtAreaLastName').val());
                model.RequisitionNo(self.ReqNo());
                self.viewModelHelper.apiPost('api/ApprovePartnerRegistration', ko.mapping.toJSON(model), function message(data) {
                    toastr.options.closeButton = true;
                    toastr.options.positionClass = "toast-top-right";
                    toastr.success("Partner Registration approved successfully", "Partner Registration");
                    setTimeout(
                            function () {
                                window.location.href = "/PendingPartnerRegistrations";
                            }, 2000);
                }, null, false, application.viewbag.appSettings.uamapiUrl, null, 'UAM');
            }
        }
        //#endregion

        //#region Verify
        self.VerifyForm = function (model) {
            var errors = 0;
         
            if (errors == 0) {
                $('#rejectBulkClose').trigger('click');
                model.RequisitionNo(self.ReqNo());
                self.viewModelHelper.apiPost('api/VerifyPartnerRegistration', ko.mapping.toJSON(model), function message(data) {
                    toastr.options.closeButton = true;
                    toastr.options.positionClass = "toast-top-right";
                    toastr.success("Partner Registration verified successfully", "Partner Registration");
                    setTimeout(
                            function () {
                                window.location.href = "/PendingPartnerRegistrations";
                            }, 2000);
                }, null, false, application.viewbag.appSettings.uamapiUrl, null, 'UAM');
            }
        }
        //#endregion

        self.Initialize();
    };

    eGateRoot.PendingPartnerRegistrationViewModel = PendingPartnerRegistrationViewModel;

}(window.eGateRoot));


validateRole = function () {
    if ($('#userPort').val().trim() !== '' || $('#userPort').val().trim() !== null || $('#userPort').val().trim() !== undefined) {
        $('#spnrole').text('');

    }


}



changeFirstname = function () {
    if ($('#txtAreaFirstName').val() !== '' || $('#txtAreaFirstName').val() !== null || $('#txtAreaFirstName').val() !== undefined) {
        $('#spanFirstName').text('');
    }

}



changeLastname = function () {
    if ($('#txtAreaLastName').val() !== '' || $('#txtAreaLastName').val() !== null || $('#txtAreaLastName').val() !== undefined) {
        $('#spanLastName').text('');
    }

}