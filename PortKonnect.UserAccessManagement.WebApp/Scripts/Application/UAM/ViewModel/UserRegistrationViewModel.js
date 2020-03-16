(function (eGateRoot) {
    var UserRegistrationViewModel = function (userId, path) {
        var self = this;
        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.viewMode = ko.observable();
        self.editableView = ko.observable(true);
        self.UserRegistrationModel = ko.observable(new eGateRoot.UserRegistrationModel());
        self.IsReset = ko.observable(true);
        self.IsSave = ko.observable(true);
        self.IsUpdate = ko.observable(true);
        self.IsExit = ko.observable(true);
        self.IsActive = ko.observable(true);
        self.IsInActive = ko.observable(true);
        self.IsCodeEnable = ko.observable(true);
        self.validationHelper = new eGateRoot.ValidationHelper();
        toastr.options.closeButton = true;
        toastr.options.positionClass = "toast-top-right";
        self.Ports = ko.observableArray([]);
        self.Roles = ko.observableArray([]);
        self.Employees = ko.observableArray([]);
        self.Partners = ko.observableArray([]);
        self.PartnerTypes = ko.observable([]);
        self.SelectedPartners = ko.observableArray([]);
        self.LoadUserIdAndUsers = ko.observableArray([]);
        self.UserIdsAndUsers = ko.observableArray([]);
        self.IsUserNameEnable = ko.observable(true);
        self.EmailValidationEnable = ko.observable(true);
        self.IsPartnerTypeVisible = ko.observable(true);
        self.IsPartnerTypelabel = ko.observable(true);
        self.isDormantVisible = ko.observable(false);
        self.isDormantEnable = ko.observable(false);
        self.isDormantUser = ko.observable(false);
        self.IsEnable = ko.observable(true);
        self.EnableEmployeeSelection = ko.observable(false);
        self.IsRecordStatus = ko.observable(true);
        self.PartnerTypeenable = ko.observable(true);
        self.PartnerNameenable = ko.observable(true);
        self.displayUsername = ko.observable(false);
        self.displayForSpecialRoles = ko.observable(false);
        self.PartnerTypeName = ko.observable();
        self.RolesList = ko.observableArray([]);
        self.showLabels = ko.observable(true);
        self.MemberTypeRole = ko.observable();
        self.UserNameSeperator = ko.observable('.');
        var checkOnChange = false;
        self.LoadPorts = function () {
            self.viewModelHelper.apiGet("api/Ports", null, function (result) {
                ko.mapping.fromJS(result, {}, self.Ports);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl);
        };

        self.LoadUsersAndUserIds = function () {
            self.viewModelHelper.apiGet("api/GetUserIdAndNames", null, function (result) {
                ko.mapping.fromJS(result, {}, self.LoadUserIdAndUsers);
                ko.mapping.fromJS(result, {}, self.UserIdsAndUsers);

            }, null, null, false, application.viewbag.appSettings.uamapiUrl);

        };

        self.validateUserName = function (model) {


            if (userId != null && userId !== "" && userId != undefined) {

            }
            else {
                $.each(self.LoadUserIdAndUsers(), function (i, val) {
                    if (val.UserName().toUpperCase() == model.UserName().toUpperCase()) {
                        toastr.warning("Username Already exists", "User");
                    }
                });
            }
        }

        //self.LoadPartners = function () {
        //    self.viewModelHelper.apiGet("api/GetAllSubscribedPartners", null, function (result) {
        //        ko.mapping.fromJS(result, {}, self.Partners);
        //    }, null, null, false, application.viewbag.appSettings.uamapiUrl,'UAM');
        //};

        self.LoadRoles = function () {
            self.viewModelHelper.apiGet("api/GetRolesCreatedBySubscriber", null, function (result) {
                ko.mapping.fromJS(result, {}, self.Roles);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        };

        self.LoadEmployees = function () {
            self.viewModelHelper.apiGet("api/EmployeesGridList?EmployeeNo=All&DepartmentType=All", null, function (result) {
                ko.mapping.fromJS(result, {}, self.Employees);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        };


        self.LoadPartnerTypes = function () {
            self.viewModelHelper.apiGet("api/PartnerTypesForUser", null, function (result) {
                ko.mapping.fromJS(result, {}, self.PartnerTypes);


            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');

            $.each(self.PartnerTypes(), function (i, val) {
                if (isEmpty(self.MemberTypeRole())) {
                    self.MemberTypeRole(val.MemberType());
                }
                if (val.MemberType() ===  'Admin' || val.MemberType() === 'TerminalOperator' || val.MemberType() === 'SuperAdmin' || val.MemberType() === 'VesselOperatingAgent') {
                    self.displayUsername(false);
                    self.displayForSpecialRoles(true);
                    self.PartnerTypeName(val.MemberType());
                    if (val.MemberType() === 'VesselOperatingAgent') {

                        self.viewModelHelper.apiGet('api/GetAllSubscribedPartners/' + val.PartnerTypeId(), null, function (result) {
                            ko.mapping.fromJS(result, {}, self.Partners);
                        }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');

                        self.UserRegistrationModel().PartnerTypeId('NA');
                        self.UserRegistrationModel().PartnerId(val.MemberCode());
                        self.UserRegistrationModel().MemberTypeCode(val.PartnerCode());
                        self.PartnerNameenable(false);
                        self.displayUsername(true);
                        self.displayForSpecialRoles(false);
                        return false;
                    }


                }
                else {
                    self.PartnerTypeName(val.MemberType());
                    self.viewModelHelper.apiGet('api/GetAllSubscribedPartners/' + val.PartnerTypeId(), null, function (result) {
                        ko.mapping.fromJS(result, {}, self.Partners);
                    }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
                    self.UserRegistrationModel().PartnerType(val.PartnerTypeId());
                    self.UserRegistrationModel().PartnerId(val.MemberCode());
                    self.UserRegistrationModel().MemberTypeCode(val.PartnerCode());
                    self.PartnerTypeenable(false);
                    self.PartnerNameenable(false);
                    self.displayUsername(true);
                    self.GetRoles(val.MemberType());

                    //PartnerTypeId
                    if (val.PartnerTypeId() === 'ContainerOperatorAgent') {
                        self.UserRegistrationModel().PartnerTypeId('COA');

                    }
                    else if (val.PartnerTypeId() === 'Customs') {

                        self.UserRegistrationModel().PartnerTypeId('Customs');
                    }
                    else if (val.PartnerTypeId() === 'CustomHouseAgent') {

                        self.UserRegistrationModel().PartnerTypeId('CHA');
                    }

                    else if (val.PartnerTypeId() === 'Finance') {

                        self.UserRegistrationModel().PartnerTypeId('Finance');
                    }
                    else if (val.PartnerTypeId() === 'GateOperator') {

                        self.UserRegistrationModel().PartnerTypeId('GO');
                    }
                    else if (val.PartnerTypeId() === 'MandR') {

                        self.UserRegistrationModel().PartnerTypeId('MandR');
                    }
                    else if (val.PartnerTypeId() === 'Security') {

                        self.UserRegistrationModel().PartnerTypeId('Security');
                    }
                    else if (val.PartnerTypeId() === 'ContainerFreightStation') {

                        self.UserRegistrationModel().PartnerTypeId('CFS');
                    }

                    return false;

                }

            });

        };




        self.LoadPorts = function () {
            self.viewModelHelper.apiGet("api/Ports", null, function (result) {
                ko.mapping.fromJS(result, {}, self.Ports);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        };

        self.ValidationCheck = function (model) {
            self.UserRegistrationModel().validationEnabled(true);
            model.validationEnabled(true);
            self.UserValidation = ko.observable(model);
            self.UserValidation().errors = ko.validation.group(self.UserValidation());
            var errors = 0, dateErrors = 0;
            errors = self.UserValidation().errors().length;
            var contactNumber = model.ContactNumber();
            var regexpforEmail = new RegExp(/^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i);

            contactNumber1 = contactNumber.replace(/(\)|\()|_|-+/g, '');
            if (errors == 0) {
                if (contactNumber1.length != 13) {
                    errors = errors + 1;
                    toastr.warning("Enter a Valid Contact Number", "User");
                    //$('#contactNum').text("Enter Valid Number");

                }
                if (parseInt(contactNumber1) === 0) {
                    errors = errors + 1;
                    toastr.warning("Enter a Valid Contact Number", "User");
                }
            }


            if (model.EmailId() == "") {
                errors = errors + 1;
                $('#validationEmailId').text('* This field is required.');

            }

            if (model.EmailId() != "") {

                if (!regexpforEmail.test(model.EmailId())) {
                    errors = errors + 1;
                    $('#validationEmailId').text('Please enter a proper email address');
                }
            }

            if (model.UserRoleArray().length === 0) {
                errors = errors + 1;
                $('#spnrole').text('* This field is required.');


            }



            return errors;

        }

        self.ExitScreen = function () {

            window.location.href = "/Users";


        }


        self.GetRoles = function (PartnerType) {

            self.viewModelHelper.apiGet("api/GetRolesByPartnerType/" + PartnerType, null, function (result) {
                ko.mapping.fromJS(result, {}, self.RolesList);
                console.log("roles",result)
            }, null, null, false, application.viewbag.appSettings.uamapiUrl);

        }
        self.SaveScreen = function (model) {
            var errors = self.ValidationCheck(model);
            if (model.UserName() != '' && model.UserName() != undefined && model.UserName() != null) {
                $.each(self.LoadUserIdAndUsers(), function (i, val) {
                    if (val.UserName().toUpperCase() == model.UserName().toUpperCase()) {
                        toastr.warning("Username Already exists", "User");
                        errors = errors + 1;
                        return;
                    }
                });
            }
            //

            if (errors == 0) {

                $.confirm({
                    'title': 'User',
                    'message': 'Are you sure you want to Save User?',
                    'buttons': {
                        'Yes': {
                            'class': 'green',
                            'action': function () {
                                //if (self.MemberTypeRole() !== 'TerminalOperator' && self.MemberTypeRole() !== 'SuperAdmin' && self.MemberTypeRole() !== 'Admin') {
                                //    debugger;
                                //    model.UserName(model.PartnerTypeId() + self.UserNameSeperator() + model.MemberTypeCode() + self.UserNameSeperator() + model.UserName());
                                //}

                                $('#clolebt').trigger('click');
                                var contactNumber = model.ContactNumber();
                                contactNumber1 = contactNumber.replace(/(\)|\()|_|-+/g, '');
                                model.ContactNumber(contactNumber1);

                                if (model.UserPreference().SendNotificationEmail()) {
                                    model.UserPreference().SendNotificationEmail("Y");
                                }
                                else
                                    model.UserPreference().SendNotificationEmail("N");

                                if (model.UserPreference().SendNotificationSms()) {
                                    model.UserPreference().SendNotificationSms("Y")
                                }
                                else
                                    model.UserPreference().SendNotificationSms("N")
                                if (model.UserPreference().SendSystemNotification()) {
                                    model.UserPreference().SendSystemNotification("Y")
                                }
                                else
                                    model.UserPreference().SendSystemNotification("N")

                                if (!self.EnableEmployeeSelection()) {
                                    model.EmployeeGUID('');
                                }

                                self.viewModelHelper.apiPost('api/User', ko.mapping.toJSON(model), function Message(data) {
                                    toastr.options.closeButton = true;
                                    toastr.options.positionClass = "toast-top-right";
                                    toastr.success("User Details saved successfully.", "User");
                                    setTimeout(
                                        function () {
                                            window.location.href = "../../Users";
                                        }, 2000);

                                }, null, false, application.viewbag.appSettings.uamapiUrl, null, 'UAM');

                            }
                        },
                        'No': {
                            'class': 'red',
                            'action': function () {
                            }
                        }
                    }
                });
            }


        }

        //#region for converting Dates
        ConvertDates = function (date) {
            var converted = kendo.parseDate(date, "dd-MM-yyyy");
            converted = kendo.toString(converted, "yyyy-MM-dd HH:mm");
            return converted;
        }
        //#endregion

        self.UpdateScreen = function (model) {
            var errors = self.ValidationCheck(model);
            if (errors == 0) {
                $.confirm({
                    'title': 'User',
                    'message': 'Are you sure you want to Update User?',
                    'buttons': {
                        'Yes': {
                            'class': 'green',
                            'action': function () {
                                $('#clolebt').trigger('click');
                                var contactNumber = model.ContactNumber();
                                contactNumber1 = contactNumber.replace(/(\)|\()|_|-+/g, '');
                                model.ContactNumber(contactNumber1);

                                if (model.UserPreference().SendNotificationEmail()) {
                                    model.UserPreference().SendNotificationEmail("Y");
                                }
                                else
                                    model.UserPreference().SendNotificationEmail("N");

                                if (model.UserPreference().SendNotificationSms()) {
                                    model.UserPreference().SendNotificationSms("Y");
                                }else
                                    model.UserPreference().SendNotificationSms("N");
                                if (model.UserPreference().SendSystemNotification()) {
                                    model.UserPreference().SendSystemNotification("Y");
                                }else
                                    model.UserPreference().SendSystemNotification("N");
                                if (self.isDormantUser()) {
                                    model.DormantStatus('Y');
                                }
                                else
                                    model.DormantStatus('N');
                                model.PwdExpiryDate(ConvertDates(model.PwdExpiryDate()));
                                model.validToDate(ConvertDates(model.validToDate()));
                                model.LogTime(ConvertDates(model.LogTime()));

                                self.viewModelHelper.apiPost('api/UpdateUser', ko.mapping.toJSON(model), function Message(data) {
                                    toastr.options.closeButton = true;
                                    toastr.options.positionClass = "toast-top-right";
                                    toastr.success("User Details Updated successfully.", "User");
                                    setTimeout(
                                           function () {
                                               window.location.href = "/Users";
                                           }, 2000);

                                }, null, false, application.viewbag.appSettings.uamapiUrl, null, 'UAM');

                            }
                        },
                        'No': {
                            'class': 'red',
                            'action': function () {
                            }
                        }
                    }
                });
            }

        }

        self.ResetScreen = function (model) {

            $.confirm({
                'title': 'User',
                'message': 'Are you sure you want to Reset User?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                            $('#clolebt').trigger('click');
                            self.ResetUser(model);
                        }
                    },
                    'No': {
                        'class': 'red',
                        'action': function () {
                        }
                    }
                }
            });
        }



        self.ResetUser = function (model) {
            model.validationEnabled(false);
            if (userId != null && userId != undefined && userId != "") {

                self.Initialize();


                $(document).ready(function () {
                    $("#contactNumber").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                    SetFocus();
                });
            }
            else {

                self.Initialize();
                $(document).ready(function () {
                    $("#contactNumber").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                    SetFocus();
                });

            }


        }

        self.GetUserById = function () {

            self.viewModelHelper.apiGet('api/GetUserForUserId/' + userId,
          null,
            function (result) {
                if (result != null) {
                    if (typeof (result) == "string") {
                        toastr.error(result);
                        return false;
                    }
                    self.UserRegistrationModel().UserId(result.UserId);
                    self.UserRegistrationModel().UserName(result.UserName);
                    self.UserRegistrationModel().FirstName(result.FirstName);
                    self.UserRegistrationModel().LastName(result.LastName);
                    self.UserRegistrationModel().ContactNumber(result.ContactNumber);
                    self.UserRegistrationModel().EmailId(result.EmailId);
                    self.UserRegistrationModel().PartnerType(result.PartnerType);
                    self.UserRegistrationModel().PartnerTypeArray(result.PartnerTypeArray);
                    //self.selectPartnerNameonEdit(result.PartnerType);
                    self.UserRegistrationModel().PartnerId(result.PartnerId);
                    self.UserRegistrationModel().UserPortArray(result.UserPortArray);
                    self.UserRegistrationModel().UserRoleArray(result.UserRoleArray);
                    self.UserRegistrationModel().PartnerTypeCode(result.PartnerTypeCode);
                    self.UserRegistrationModel().PwdExpiryDate(result ? kendo.toString(kendo.parseDate(result.PwdExpiryDate, ["dd-MM-yyyy HH:mm", "yyyy-MM-ddTHH:mm:ss"]), "dd-MM-yyyy") : "");
                    self.UserRegistrationModel().validToDate(result ? kendo.toString(kendo.parseDate(result.validToDate, ["dd-MM-yyyy HH:mm", "yyyy-MM-ddTHH:mm:ss"]), "dd-MM-yyyy") : "");
                    self.UserRegistrationModel().LogTime(result ? kendo.toString(kendo.parseDate(result.LogTime, ["dd-MM-yyyy HH:mm", "yyyy-MM-ddTHH:mm:ss"]), "dd-MM-yyyy") : "");

                    self.UserRegistrationModel().InCorrectLogins(result.InCorrectLogins);
                    self.UserRegistrationModel().IsDeleted(result.IsDeleted == "N" ? result.IsDeleted = "Active" : result.IsDeleted = "InActive");
                    if (self.UserRegistrationModel().IsDeleted() == "Active") {
                        self.IsActive(false);
                        self.IsInActive(true);
                    }
                    else {
                        self.IsActive(true);
                        self.IsInActive(false);
                    }
                    self.UserRegistrationModel().RecordStatus(result.RecordStatus == "A" ? result.RecordStatus = "Active" : result.RecordStatus = "InActive");
                    if (self.UserRegistrationModel().RecordStatus() == "Active") {
                        self.IsActive(false);
                        self.IsInActive(true);
                    }
                    else {
                        self.IsActive(true);
                        self.IsInActive(false);
                    }
                    self.UserRegistrationModel().UserPreference().SendNotificationEmail(result.UserPreference.SendNotificationEmail == "Y" ? true : false);
                    self.UserRegistrationModel().UserPreference().SendNotificationSms(result.UserPreference.SendNotificationSms == "Y" ? true : false);
                    self.UserRegistrationModel().UserPreference().SendSystemNotification(result.UserPreference.SendSystemNotification == "Y" ? true : false);

                    if (result.DormantStatus == "Y") {
                        self.isDormantVisible(true);
                        self.isDormantEnable(true);
                        self.isDormantUser(true);
                    }

                }
                else {
                    toastr.error("Invalid User", "User");
                    setTimeout(function () {
                        window.location.href = window.location.origin + "/Users";
                    }, 2000);
                }
            }, null, null, false, application.viewbag.appSettings.uamapiUrl);


        }   

        self.Activate = function (model) {
            var isDeleted = "N";
            $.confirm({
                'title': 'User',
                'message': 'Are you sure you want to Activate User?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                            $('#clolebt').trigger('click');
                            self.viewModelHelper.apiPost('api/ActivateOrDeActivateUser/' + userId + '/' + isDeleted, null, function Message(data) {
                                toastr.options.closeButton = true;
                                toastr.options.positionClass = "toast-top-right";
                                toastr.success("User Is Activated successfully.", "User");
                                window.location.href = "/Users";


                            }, null, false, application.viewbag.appSettings.uamapiUrl, null, 'UAM');

                        }
                    },
                    'No': {
                        'class': 'red',
                        'action': function () {
                        }
                    }
                }
            });

        }

        self.DeActivate = function (model) {
            var isDeleted = "Y";
            $.confirm({
                'title': 'User',
                'message': 'Are you sure you want to DeActivate User?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                            $('#clolebt').trigger('click');
                            self.viewModelHelper.apiPost('api/ActivateOrDeActivateUser/' + userId + '/' + isDeleted, null, function Message(data) {
                                toastr.options.closeButton = true;
                                toastr.options.positionClass = "toast-top-right";
                                toastr.success("User Is DeActivated successfully.", "User");
                                window.location.href = "/Users";

                            }, null, false, application.viewbag.appSettings.uamapiUrl, null, 'UAM');

                        }
                    },
                    'No': {
                        'class': 'red',
                        'action': function () {
                        }
                    }
                }
            });
        }

        self.Initialize = function () {
            self.UserRegistrationModel(new eGateRoot.UserRegistrationModel());
            self.viewMode = ko.observable(true);

            //self.LoadRoles();
            self.LoadPorts();
            self.LoadPartnerTypes();
            self.LoadEmployees();

            self.viewMode('Form');
            self.LoadUsersAndUserIds();
            if (userId != null && userId != undefined && userId != "") {

                if (path == "View") {
                    self.GetUserById();
                    self.IsPartnerTypeVisible(false);
                    self.IsPartnerTypelabel(true);
                    self.PartnerNameenable(false);                   
                    //self.LoadPartners();
                    self.IsSave(false);
                    self.IsUpdate(false);
                    self.IsReset(false);
                    self.IsExit(true);
                    self.IsActive(false);
                    self.IsInActive(false);
                    self.IsRecordStatus(true);
                    self.IsUserNameEnable(false);
                    self.IsEnable(false);
                    self.showLabels(false);
                    if (self.UserRegistrationModel().PartnerTypeCode() !== "" && self.UserRegistrationModel().PartnerTypeCode() !== undefined && self.UserRegistrationModel().UserName() !== "" && self.UserRegistrationModel().UserName() !== undefined) {
                        self.viewModelHelper.apiGet('api/GetAllSubscribedPartners/' + self.UserRegistrationModel().PartnerTypeCode(), null, function(result) {
                            ko.mapping.fromJS(result, {}, self.Partners);
                        }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
                        self.GetRoles(self.UserRegistrationModel().PartnerTypeCode());
                    }
                    $(document).ready(function () {
                        $('#spnTitle').html("View User");
                    });
                    self.UserRegistrationModel().PartnerTypeCode(self.UserRegistrationModel().PartnerType());
                }
                if (path == "Edit") {
                    self.IsPartnerTypeVisible(false);
                    self.IsPartnerTypelabel(true);
                    //self.LoadPartners();
                    self.IsSave(false);
                    self.IsUpdate(true);
                    self.IsReset(true);
                    self.IsExit(true);
                    self.IsActive(true);
                    self.IsInActive(true);
                    self.IsUserNameEnable(false);                    
                    self.IsRecordStatus(true);
                    self.GetUserById();
                    self.showLabels(false);
                    if ((self.UserRegistrationModel().PartnerTypeCode() === "" || self.UserRegistrationModel().PartnerTypeCode() === undefined) && (self.UserRegistrationModel().UserName() === "" || self.UserRegistrationModel().UserName() === undefined)) {
                        self.IsActive(false);
                        self.IsInActive(false);
                    } else {
                        self.viewModelHelper.apiGet('api/GetAllSubscribedPartners/' + self.UserRegistrationModel().PartnerTypeCode(), null, function (result) {
                            ko.mapping.fromJS(result, {}, self.Partners);
                        }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
                        self.GetRoles(self.UserRegistrationModel().PartnerTypeCode());
                    }
                    $(document).ready(function () {
                        $('#spnTitle').html("Edit User");

                    });
                    self.UserRegistrationModel().PartnerTypeCode(self.UserRegistrationModel().PartnerType());
                }

            }
            else {
                self.IsPartnerTypelabel(false);
                self.IsPartnerTypeVisible(true);
                self.IsSave(true);
                self.IsUpdate(false);
                self.IsReset(true);
                self.IsExit(true);
                self.IsActive(false);
                self.IsInActive(false);
                self.IsUserNameEnable(true);
                self.IsRecordStatus(false);
                $(document).ready(function () {
                    $('#spnTitle').html("Add User");
                });
            }

            $(document).ready(function () {
                $("#contactNumber").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                $("#datetimePwdExpiryDate").kendoMaskedDatePicker();
                $('#datetimePwdExpiryDate').data('kendoDatePicker');
                $("#datetimeValidToDate").kendoMaskedDatePicker();
                $('#datetimeValidToDate').data('kendoDatePicker');
                $("#datetimeLogTime").kendoMaskedDatePicker();
                $('#datetimeLogTime').data('kendoDatePicker');

                SetFocus();
            });

        }

        self.selectEmployee = function (model) {
        }

        self.selectPartnerName = function (model) {

            if (model.PartnerType() !== null && model.PartnerType() !== undefined && model.PartnerType() !== "") {

                self.viewModelHelper.apiGet('api/GetAllSubscribedPartners/' + model.PartnerType(), null, function (result) {
                    ko.mapping.fromJS(result, {}, self.Partners);
                }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');

                self.GetRoles(model.PartnerType());

                if (model.PartnerType() === 'VesselOperatingAgent') {
                    self.UserRegistrationModel().PartnerTypeId('VOA');
                    checkOnChange = true;
                }
                else if (model.PartnerType() === 'ConsortiumPartner') {
                    self.UserRegistrationModel().PartnerTypeId('CP');
                    checkOnChange = true;
                }

                self.EnableEmployeeSelection(model.PartnerType() === 'PortAuthority');

            } else {
                if (self.PartnerTypeName() === 'TerminalOperator' || self.PartnerTypeName() === 'SuperAdmin') {
                    self.Partners([]);
                    $("#ddlPartner").data("kendoDropDownList").select(0);
                }
                if (checkOnChange === true) {
                    if (model.PartnerType() === undefined || model.PartnerType() === '' || model.PartnerType() === null) {
                        self.UserRegistrationModel().PartnerTypeId('NA');
                    }
                }



            }
            setTimeout(function () {
                var dropdown = $("#ddlPartnerType").data("kendoDropDownList");
                dropdown.focus();
            }, 1000);
        }

        self.selectPartnerNameonEdit = function (model) {
            for (var i = self.Partners().length - 1; i >= 0; i--) {

                if (model != self.Partners()[i].PartnerType()) {

                    self.Partners.remove(self.Partners()[i]);
                }
            }
        }

        self.Initialize();

    }
    eGateRoot.UserRegistrationViewModel = UserRegistrationViewModel;
}(window.eGateRoot));
function SetFocus() {
    $("#contactNumber").bind("focus", function () {
        if (this.createTextRange) {
            var part = this.createTextRange();
            part.move("character", 0);
            part.select();
        } else if (this.setSelectionRange) {
            var maskedinput = this;
            setTimeout(function () {
                maskedinput.setSelectionRange(0, 0);
            }, 0)
        }
    });
}

validateEmailId = function () {

    if ($('#emailId').val() != "") {

        $('#validationEmailId').text('');

    }

}

validateRole = function () {
    if ($('#userRole').val().trim() !== '' || $('#userRole').val().trim() !== null || $('#userRole').val().trim() !== undefined) {
        $('#spnrole').text('');

    }
}