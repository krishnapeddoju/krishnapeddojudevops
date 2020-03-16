(function (eGateRoot) {
    var UserRegistrationListViewModel = function () {

        var self = this;
        $('#spnTitle').html("Users List");
        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.validationHelper = new eGateRoot.ValidationHelper();
        self.viewMode = ko.observable();
        self.UserRegistrationModel = ko.observable();
        self.UserRegistrationGridModel = ko.observable();
        self.UserList = ko.observableArray([]);
        self.PartnerTypes = ko.observableArray([]);
        self.isDormantUser = ko.observable();

        self.LoadUsers = function (data) {
           
            var UserName = $("#SearchUserName").val();
            var FirstName = $("#SearchFirstName").val();
            var LastName = $("#SearchLastName").val();
           
            var PartnerType = $("#ddlPartnerType").val();
            var DormantUser="";

            if (UserName == null || UserName == undefined || UserName == "") {
                UserName = "All";
            }

            if (FirstName == null || FirstName == undefined || FirstName == "") {
                FirstName = "All";
            }


            if (LastName == null || LastName == undefined || LastName == "") {
                LastName = "All";
            }

            if (PartnerType == "" || PartnerType == undefined || PartnerType == null) {
                PartnerType = "All";
            }

            if (self.isDormantUser() == false || self.isDormantUser() == undefined || self.isDormantUser() == "" || self.isDormantUser()==null) {
                DormantUser = "All";
            }
            else {
                DormantUser = "Y";
            }

            self.viewModelHelper.apiGet('api/GetAllSubscribedUsers', { userName: UserName, firstName: FirstName, lastName: LastName, partnerType: PartnerType, dormantUser: DormantUser },
             function (result) {
                 self.UserList(ko.utils.arrayMap(result, function (item) {
                     return new eGateRoot.UserRegistrationGridModel(item);
                 }));
                 setTimeout(function () {
                 $('#Grid2').data().kendoGrid.dataSource.page(1);
                 $("form.k-filter-menu button[type='reset']").trigger("click");
                 $("#Grid2").data("kendoGrid").dataSource.sort({});
                 });
             }, null, null, false, application.viewbag.appSettings.uamapiUrl);

        }


        self.ResetPassword = function (model) {

        	$.confirm({
        		'title': 'User',
        		'message': 'Are you sure you want to Reset User Password?',
        		'buttons': {
        			'Yes': {
        				'class': 'green',
        				'action': function () {
        					$('#clolebt').trigger('click');
        					self.viewModelHelper.apiPost('api/User/PutForgetPassword', ko.mapping.toJSON(model),
                    function responseResetUserPwd(data) {
                    	if (data === "Success") {
                    		toastr.options.closeButton = true;
                    		toastr.options.positionClass = "toast-top-right";
                    		toastr.success("Success! Check email/SMS for New Password.", "Reset Password");
                    	}
                    	else {
                    		toastr.options.closeButton = true;
                    		toastr.options.positionClass = "toast-top-right";
                    		toastr.error("Invalid UserName", "Reset Password");
                    	}
                    }, null, null, application.viewbag.appSettings.uamapiUrl, null);

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

        self.TokenServieResetPassword = function (model) {

            $.confirm({
                'title': 'User',
                'message': 'Are you sure you want to Reset User Password?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                            $('#clolebt').trigger('click');
                            self.viewModelHelper.apiPost('api/User/TokenServieResetPassword', ko.mapping.toJSON(model),
                    function responseResetUserPwd(data) {
                        if (data === "Success") {
                            toastr.options.closeButton = true;
                            toastr.options.positionClass = "toast-top-right";
                            toastr.success("Success! Check email/SMS for New Password.", "Reset Password");
                        }
                        else {
                            toastr.options.closeButton = true;
                            toastr.options.positionClass = "toast-top-right";
                            toastr.error("Invalid UserName", "Reset Password");
                        }
                    }, null, null, application.viewbag.appSettings.uamapiUrl, null);

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
        self.ViewUser = function (model) {
        		window.location.href = "User/" + model.UserId() + "/" + "View";
        }

        	self.EditUser = function (model) {
        		window.location.href = "User/" + model.UserId() + "/" + "Edit";
        }

        self.Adduser = function (model) {
            window.location.href = "User";
        }


        self.LoadPartnerTypes = function () {
            self.viewModelHelper.apiGet("api/PartnerTypes", null, function (result) {
                ko.mapping.fromJS(result, {}, self.PartnerTypes);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl);
        }

        self.ResetFilters = function (data) {
            self.UserRegistrationGridModel(new eGateRoot.UserRegistrationGridModel());
            self.isDormantUser(false);
            self.LoadUsers();
        }

        self.Initialize = function () {

            self.UserRegistrationModel(new eGateRoot.UserRegistrationModel());
            self.UserRegistrationGridModel(new eGateRoot.UserRegistrationGridModel());
            self.LoadUsers();
            self.LoadPartnerTypes();
            self.isDormantUser(false);
            self.viewMode('List');

            
        }

        self.Initialize();
       
    }
    eGateRoot.UserRegistrationListViewModel = UserRegistrationListViewModel;
}(window.eGateRoot));