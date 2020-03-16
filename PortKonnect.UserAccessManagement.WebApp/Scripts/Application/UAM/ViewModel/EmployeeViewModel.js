(function (eGateRoot) {
    var EmployeeViewModel = function (empId) {
        var self = this;
        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.validationHelper = new eGateRoot.ValidationHelper();
        self.employeeModel = ko.observable(new eGateRoot.EmployeeModel());
        self.IsEdit = ko.observable(true);
        self.viewMode = ko.observable();
        self.IsSave = ko.observable(true);
        self.IsUpdate = ko.observable(false);
        self.IsReset = ko.observable(true);
        self.EmployeesList = ko.observableArray([]);
        self.IsEmployeeCodeEnable = ko.observable(true);
        self.IsEmployeeEnable = ko.observable(true);

        self.DepartmentsList = ko.observable();
        self.DesignationsList = ko.observable();        

        self.GetEmployeeDetails = function () {            
            self.viewModelHelper.apiGet('api/Employee/' + empId,
        null,
          function (result) {
              if (result != null) {
                  if (empId != null && empId !== "" && empId != undefined) {
                      self.employeeModel(new eGateRoot.EmployeeModel(result));
                  } else {
                      self.employeeModel(new eGateRoot.EmployeeModel());
                  }
              }
              else {
                  toastr.error("Employee doesn't exist", "Employee");
                  setTimeout(function () {
                      window.location.href = window.location.origin + "/Employees";
                  }, 2000);
              }
          }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }


        self.LoadDepartments = function () {
            self.viewModelHelper.apiGet('api/GetDepartments', null,
             function (result) {
                 ko.mapping.fromJS(result, {}, self.DepartmentsList);
             }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }

        self.LoadDesignations = function () {
            self.viewModelHelper.apiGet('api/GetDesignations', null,
             function (result) {
                 ko.mapping.fromJS(result, {}, self.DesignationsList);
             }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }

        self.EditEmployee = function () {

        }

        self.Initialize = function () {            
            self.viewMode('Form');
            self.LoadDepartments();
            self.LoadDesignations();
           self.GetEmployeeDetails();
            self.IsEmployeeEnable(true);            
            if (empId != null && empId !== "" && empId != undefined) {
                self.IsSave(false);
                self.IsUpdate(true);
                $(document).ready(function () {
                    $('#spnTitle').html("Edit Employee");
                });

                self.IsEmployeeCodeEnable(false);

            } else {
                self.IsSave(true);
                self.IsUpdate(false);
                $(document).ready(function () {
                    $('#spnTitle').html("Add Employee");
                });

                self.IsEmployeeCodeEnable(true);
            }
            $(document).ready(function () {
                $("#OfficialMobileNo").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                $("#PersonalMobileNo").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                SetFocus();
            });
        }

        self.ValidationCheck = function (model) {
            self.employeeModel().validationEnabled(true);
            model.validationEnabled(true);
            self.EmployeeValidation = ko.observable(model);
            self.EmployeeValidation().errors = ko.validation.group(self.EmployeeValidation());
            var errors = 0;
            errors = self.EmployeeValidation().errors().length;

            var officialMobileNo = model.OfficialMobileNo();
            var regexpforEmail = new RegExp(/^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i);

            officialMobileNo1 = officialMobileNo.replace(/(\)|\()|_|-+/g, '');
            if (errors == 0) {
                if (officialMobileNo1.length != 13) {
                    errors = errors + 1;
                    toastr.warning("Enter a Valid Official Mobile No.", "Employee");

                }
                if (parseInt(officialMobileNo1) === 0) {
                    errors = errors + 1;
                    toastr.warning("Enter a Valid Official Mobile No.", "Employee");
                }
            }

            var personalMobileNo = model.PersonalMobileNo();
            //var regexpforEmail = new RegExp(/^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i);

            personalMobileNo1 = personalMobileNo.replace(/(\)|\()|_|-+/g, '');
            if (errors == 0) {
                if (personalMobileNo1.length != 13) {
                    errors = errors + 1;
                    toastr.warning("Enter a Valid Personal Mobile No.", "Employee");
                }
                if (parseInt(personalMobileNo1) === 0) {
                    errors = errors + 1;
                    toastr.warning("Enter a Valid Personal Mobile No.", "Employee");
                }
            }

            if (model.EmailID() == "") {
                errors = errors + 1;
                $('#validationEmailId').text('* This field is required.');

            }

            if (model.EmailID() != "") {

                if (!regexpforEmail.test(model.EmailID())) {
                    errors = errors + 1;
                    $('#validationEmailId').text('Please enter a proper email address');
                }
            }

            return errors;
        }


        self.SaveEmployee = function (model) {

            var errors = self.ValidationCheck(model);
            var toasterAlerts = "N";
         
            if (errors === 0) {
                $.each(self.EmployeesList(), function (index, item) {
                    if (item.EmployeeNo().toLowerCase() == model.EmployeeNo().toLowerCase()) {
                        toastr.warning("Employee No. already Exists.", "Employee");
                        errors = errors + 1;
                    }

                });
            }

            if (errors === 0) {
                $.confirm({
                    'title': 'Employee',
                    'message': 'Are you sure you want to Save Employee?',
                    'buttons': {
                        'Yes': {
                            'class': 'green',
                            'action': function () {
                                $('#clolebt').trigger('click');
                                var officialMobileNo = model.OfficialMobileNo();
                                officialMobileNo1 = officialMobileNo.replace(/(\)|\()|_|-+/g, '');
                                model.OfficialMobileNo(officialMobileNo1);

                                var personalMobileNo = model.PersonalMobileNo();
                                personalMobileNo1 = personalMobileNo.replace(/(\)|\()|_|-+/g, '');
                                model.PersonalMobileNo(personalMobileNo1);

                                self.viewModelHelper.apiPost('api/Employee', ko.mapping.toJSON(model), function Message(data) {
                                    toastr.options.closeButton = true;
                                    toastr.options.positionClass = "toast-top-right";
                                    toastr.success("Employee Details saved successfully.", "Employee Category");
                                    setTimeout(
                                            function () {
                                                window.location.href = "/Employees";
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

        self.UpdateEmployee = function (model) {
            var errors = self.ValidationCheck(model);
            var toasterAlerts = "N";           

            if (errors === 0) {

                $.confirm({
                    'title': 'Employee',
                    'message': 'Are you sure you want to Update Employee?',
                    'buttons': {
                        'Yes': {
                            'class': 'green',
                            'action': function () {
                                $('#clolebt').trigger('click');
                                var officialMobileNo = model.OfficialMobileNo();
                                officialMobileNo1 = officialMobileNo.replace(/(\)|\()|_|-+/g, '');
                                model.OfficialMobileNo(officialMobileNo1);

                                var personalMobileNo = model.PersonalMobileNo();
                                personalMobileNo1 = personalMobileNo.replace(/(\)|\()|_|-+/g, '');
                                model.PersonalMobileNo(personalMobileNo1);

                                self.viewModelHelper.apiPost('api/Employee', ko.mapping.toJSON(model), function Message(data) {
                                    toastr.options.closeButton = true;
                                    toastr.options.positionClass = "toast-top-right";
                                    toastr.success("Employee Details updated successfully.", "Employee");
                                    setTimeout(
                                            function () {
                                                window.location.href = "/Employees";
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
        

        calmaxtoday18 = function () {
            var today = new Date();
            var dd = Number(today.getDate());
            var mm = Number(today.getMonth() + 1);
            var yyyy = Number(today.getFullYear());

            var year = new Date().getYear() - 19;

            this.max(new Date(yyyy - 19, mm - 1, dd - 1));
        };

        calmaxtoday = function () {
            this.max(new Date());

        };

        self.ResetEmployee = function (model) {
            $.confirm({
                'title': 'Employee',
                'message': 'Are you sure you want to Reset Employee?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                            if (empId != null && empId !== "" && empId != undefined) {
                                self.GetEmployeeDetails();
                                $(document).ready(function () {
                                    $("#OfficialMobileNo").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                                    $("#PersonalMobileNo").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                                    SetFocus();
                                });                             
                            } else {
                                self.Initialize();
                                $(document).ready(function () {
                                    $("#OfficialMobileNo").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                                    $("#PersonalMobileNo").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                                    SetFocus();
                                });
                            }
                            model.validationEnabled(false);
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
        
        self.ExitScreen = function () {
            window.location.href = "/Employees";


        }

        //Preventing Backspace
        PreventBackSpace = function () {
            return self.validationHelper.PreventBackspaces_keydownEvent(event);
        }

        self.Initialize();
    }

    eGateRoot.EmployeeViewModel = EmployeeViewModel;
}(window.eGateRoot));
function SetFocus() {
    $("#OfficialMobileNo").bind("focus", function () {
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
    $("#PersonalMobileNo").bind("focus", function () {
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

    if ($('#EmailID').val() != "") {

        $('#validationEmailId').text('');

    }

}