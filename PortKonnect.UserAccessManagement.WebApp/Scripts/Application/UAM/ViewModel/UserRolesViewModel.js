(function (eGateRoot) {

    var UserRolesViewModel = function () {

        var self = this;
        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.validationHelper = new eGateRoot.ValidationHelper();
        self.validationEnabled = ko.observable();
        self.viewMode = ko.observable();
        self.UserRolesModel = ko.observable();
        self.UserRolesGridModel = ko.observable();
        self.UsersList = ko.observableArray([]);
        self.Roles = ko.observableArray([]);
        self.PreviousRoles = ko.observableArray([]);
      

        self.LoadRoles = function () {
           
        };

        self.Initialize = function () {
            self.UserRolesModel(new eGateRoot.UserRolesModel());
            self.UserRolesGridModel(new eGateRoot.UserRolesGridModel());
            self.viewMode = ko.observable(true);
            self.GetUsers();
            self.LoadRoles();
            self.viewMode('List');
            $('#spnTitle').html("User Roles");

            $(document).ready(function () {
                $("#SearchContactNumber").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                SetFocus();
            });
         

        }


        self.getFilterDate = function () {


        }

        self.resetFilterData = function () {


        }

        self.AddRoles = function (model) {
        	self.viewModelHelper.apiGet("api/GetRolesForPartnerType/" + model.UserId(), null, function (result) {
                ko.mapping.fromJS(result, {}, self.Roles);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl);
            self.PreviousRoles(model.UserRoleArray());
            self.UserRolesGridModel(model);
            console.log("grid", self.UserRolesGridModel())
            popup('popUpDiv');
          
        }

        self.SaveRoles = function (model) {
        	var errors = 0;
        	if (model.UserRoleArray() == "" || model.UserRoleArray() == null)
        	{
        		toastr.warning("Please select atleast one role.", "User Role");
        		errors = errors + 1;
        	}

        	if (errors == 0) {
        		$.confirm({
        			'title': 'User Roles',
        			'message': 'Are you sure you want to Save User Roles?',
        			'buttons': {
        				'Yes': {
        					'class': 'green',
        					'action': function () {
        						$('#clolebt').trigger('click');
        						self.viewModelHelper.apiPost('api/AddOrUpdateUserRole', ko.mapping.toJSON(model), function Message(data) {
        							toastr.options.closeButton = true;
        							toastr.options.positionClass = "toast-top-right";
        							toastr.success("User Role Details saved successfully.", "User Role");
        							self.GetUsers();
        							popup('popUpDiv');

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

        self.ResetRoles = function (model) {
        	
        	
        	model.UserRoleArray(self.PreviousRoles())
        	if (self.PreviousRoles() == null)
        	{
        		model.UserRoleArray('');
        	}
            model.validationEnabled(false);

        }

        self.CancelRoles = function (model) {
            model.UserRoleArray(self.PreviousRoles())
            self.UserRolesGridModel(model);
            model.validationEnabled(false);

        }

        self.Exit = function (model) {


        }

        self.GetUsers = function (model) {
            var UserName = $("#SearchUserName").val();
            var FirstName = $("#SearchFirstName").val();
            var EmailId = $("#SearchEmailId").val();
            var ContactNumber = $("#SearchContactNumber").val();
            //if (ContactNumber != undefined) {
            //    ContactNumber = ContactNumber.replace(/[^a-zA-Z0-9 ]/g, "").trim();
            //    if (ContactNumber.length != 13) {
            //        ContactNumber = "All";
            //    }
            //}

            if (ContactNumber != "" && ContactNumber != null && ContactNumber != undefined) {
                ContactNumber = ContactNumber.replace(/(\)|\()|_|-+/g, '');
            }
            if (UserName == null || UserName == undefined || UserName == "") {
                UserName = "All";
            }

            if (FirstName == null || FirstName == undefined || FirstName == "") {
                FirstName = "All";
            }

            if (EmailId == null || EmailId == undefined || EmailId == "") {
                EmailId = "All";
        }

            if (ContactNumber == "" || ContactNumber == undefined || ContactNumber == null) {
                ContactNumber = "All";
            }
            self.viewModelHelper.apiGet('api/GetUsersToAssignUserRoles', { userName: UserName, firstName: FirstName, emailId: EmailId, contactNumber: ContactNumber },
            function (result) {
                self.UsersList(ko.utils.arrayMap(result, function (item) {
                    return new eGateRoot.UserRolesGridModel(item);
                }));
                setTimeout(function () {
                    $('#Grid').data().kendoGrid.dataSource.page(1);
                    $("form.k-filter-menu button[type='reset']").trigger("click");
                    $("#Grid").data("kendoGrid").dataSource.sort({});
                });
            }, null, null, false, application.viewbag.appSettings.uamapiUrl);

        };

        self.ResetFilters = function (data) {
            self.UserRolesModel(new eGateRoot.UserRolesModel());
            self.GetUsers();
            $(document).ready(function () {
                $("#SearchContactNumber").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                SetFocus();
            });
        }

        self.Initialize();

    }
    eGateRoot.UserRolesViewModel = UserRolesViewModel;

}(window.eGateRoot));
function SetFocus() {
    $("#SearchETAfrom").bind("focus", function () {
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
    $("#SearchETAto").bind("focus", function () {
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