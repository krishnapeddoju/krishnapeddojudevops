(function (eGateRoot) {
    var RoleViewModel = function (roleId) {
        var self = this;
        self.viewModelHelper = new eGateRoot.ViewModelHelper();
		self.validationHelper = new eGateRoot.ValidationHelper();
        self.roleModel = ko.observable(new eGateRoot.RoleModel());
        self.RoleFunctionCodeArray = ko.observableArray([]);
        self.RoleFunctions = ko.observableArray([]);
        self.Entities = ko.observableArray([]);
        self.InRoleFunctionCodes = ko.observableArray([]);
        self.InRoleEntityCodes = ko.observableArray([]);
        self.PartnerTypes = ko.observableArray([]);
        self.IsEdit = ko.observable(true);
        self.viewMode = ko.observable();
        self.IsSave = ko.observable(true);
        self.IsUpdate = ko.observable(false);
        self.IsReset = ko.observable(true);
        self.RolesList = ko.observableArray([]);
        self.IsRoleCodeEnable = ko.observable(true);
        self.Modules = ko.observableArray([]);
        self.GetEntityFunctions = function () {
            var jsonArr = [];
            var jsonArrMarine = [];
            self.viewModelHelper.apiGet('api/Role/' + roleId,
        null,
          function (result) {              
              if (result != null) {                  
                  result.Modules.sort(function (left, right) {

                      return left.ModuleName == right.ModuleName ? 0 : (left.ModuleName < right.ModuleName ? 1 : -1)

                  });
                  if (roleId != null && roleId !== "" && roleId != undefined) {
                      self.roleModel(new eGateRoot.RoleModel(result));
                      ko.mapping.fromJS(result.RoleFunctions, {}, self.RoleFunctions);
                      ko.mapping.fromJS(result.RoleFunctionCodeArray, {}, self.RoleFunctionCodeArray);
                      ko.mapping.fromJS(result.RoleFunctionCodeArray, {}, self.InRoleFunctionCodes);
                      ko.mapping.fromJS(result.Modules, {}, self.Modules);
                  } else {
                      self.roleModel(new eGateRoot.RoleModel());
                      ko.mapping.fromJS(result.Modules, {}, self.Modules);
                  }
                  $.each(result.Modules, function (k1, item) {                      
                      var itemArray1 = [];
                      $.each(item.AppEntities, function (k, v) {                          
                          var itemArray = [];
                          if (v.AppFunctions != null) {
                              $.each(v.AppFunctions,
                                  function (k, v) {
                                      itemArray.push({
                                          id: v.FunctionCode,
                                          text: v.FunctioName,
                                          checked: v.IsInRole === "Y" ? true : false
                                      });
                                  });
                          }
                          itemArray1.push({
                              id: v.AppEntityId,
                              text: v.AppEntityName,
                              checked: false,
                              items: itemArray
                          });
                      });

                      if (item.ModuleId.startsWith('PKMARINE')) {
                          // MARINE related
                          jsonArrMarine.push({
                              id: item.ModuleId,
                              text: item.ModuleName,
                              expanded: false,
                              items: itemArray1
                          });
                      } else {
                          jsonArr.push({
                              id: item.ModuleId,
                              text: item.ModuleName,
                              expanded: false,
                              items: itemArray1
                          });
                      }
                  });                 
              }
              else {
                  toastr.error("Invalid Role", "Role");
                  setTimeout(function () {
                      window.location.href = window.location.origin + "/Roles";
                  }, 2000);
              }
          }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
            $(document).ready(function () {
                $("#treeview").kendoTreeView({
                    checkboxes: {
                        checkChildren: true
                    },

                    check: onCheck,

                    dataSource: jsonArr
                });

                $("#marinetreeview").kendoTreeView({
                    checkboxes: {
                        checkChildren: true
                    },

                    check: onCheck,

                    dataSource: jsonArrMarine
                });
            });
        }


        self.LoadRoles = function () {
            self.viewModelHelper.apiGet('api/GetRoles', null,
             function (result) {
                 ko.mapping.fromJS(result, {}, self.RolesList);
             }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }

        self.EditRole = function () {

        }

        self.Initialize = function () {
            self.viewMode('Form');
            self.GetEntityFunctions();
            self.LoadPartnerTypes();
            self.LoadRoles();
            if (roleId != null && roleId !== "" && roleId != undefined) {
                self.IsSave(false);
                self.IsUpdate(true);
                $(document).ready(function () {
                	$('#spnTitle').html("Edit Role");
                });
             
                self.IsRoleCodeEnable(false);
            } else {
                self.IsSave(true);
                self.IsUpdate(false);
                $(document).ready(function () {
                	$('#spnTitle').html("Add Role");
                });
            
                self.IsRoleCodeEnable(true);
            }
        }

        self.LoadPartnerTypes = function () {
            self.viewModelHelper.apiGet("api/PartnerTypes", null, function (result) {
                ko.mapping.fromJS(result, {}, self.PartnerTypes);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        };

        // function that gathers IDs of checked nodes
        function checkedNodeIdsEntities(nodes, checkedNodesEntities, checkedNodesFunctions) {
            for (var i = 0; i < nodes.length; i++) {
                var childnodes = nodes[i].children.view();
                for (var j = 0; j < childnodes.length; j++) {
                    if (childnodes[j].checked) {
                        checkedNodesEntities.push(childnodes[j].id);
                    }

                    if (childnodes[j].hasChildren) {
                        checkedNodeIdsFunctions(childnodes[j].children.view(), checkedNodesFunctions);
                    }
                }
            }
        }

        // function that gathers IDs of checked nodes
        function checkedNodeIdsFunctions(nodes, checkedNodesFunctions) {
            for (var i = 0; i < nodes.length; i++) {
                if (nodes[i].checked) {
                    checkedNodesFunctions.push(nodes[i].id);
                }
            }
        }

        // show checked node IDs on datasource change
        function onCheck() {            
        	
            var checkedNodesEntities = [],
             checkedNodesFunctions = [],
                treeView = $("#treeview").data("kendoTreeView"),
                marinetreeView = $("#marinetreeview").data("kendoTreeView"),
                message;

            checkedNodeIdsEntities(treeView.dataSource.view(), checkedNodesEntities, checkedNodesFunctions);
            checkedNodeIdsEntities(marinetreeView.dataSource.view(), checkedNodesEntities, checkedNodesFunctions);
            ko.mapping.fromJS(checkedNodesFunctions, {}, self.InRoleFunctionCodes);
            ko.mapping.fromJS(checkedNodesEntities, {}, self.InRoleEntityCodes);
            if (self.RoleFunctions() != null && self.RoleFunctions().length > 0) {
                $.each(self.RoleFunctions(), function (k, v) {
                    if (checkedNodesFunctions.indexOf(v.FunctionCode()) === -1) {
                        v.IsDeleted("Y");
                    }
                    if (checkedNodesFunctions.indexOf(v.FunctionCode()) > -1 && v.IsDeleted() === "Y") {
                        v.IsDeleted("N");
                    }
                });
            }
            if (checkedNodesEntities.length > 0 || checkedNodesFunctions.length > 0) {
                message = "IDs of checked nodes: Entities:- " + checkedNodesEntities.join(",") + " and Functions:- " + checkedNodesFunctions.join(",");
            } else {
                message = "No nodes checked.";
            }

            $("#result").html(message);
        }

        self.ValidationCheck = function (model) {
            self.roleModel().validationEnabled(true);
            model.validationEnabled(true);
            self.RoleValidation = ko.observable(model);
            self.RoleValidation().errors = ko.validation.group(self.RoleValidation());
            var errors = 0;
            errors = self.RoleValidation().errors().length;
            return errors;
        };

        self.SaveRole = function (model) {
           
            var errors = self.ValidationCheck(model);
            var toasterAlerts = "N";
            $.each(self.RolesList(), function (index, item) {
				if (item.RoleCode().toUpperCase() == model.RoleCode().toUpperCase().trim()) {

                    toastr.warning("Role Code already Exists.", "Role");
                    errors = errors + 1;
                }

            });


            $.each(self.RolesList(), function (index, item) {
                if (item.RoleName().toUpperCase() == model.RoleName().toUpperCase().trim()) {

                    toastr.warning("Role Name already Exists.", "Role");
                    errors = errors + 1;
                }

            });

			if (model.PartnerTypeArray().length === 0) {
                $('#validatePartnerType').text('This field is required.');
                errors = errors + 1;

            }
			if (self.InRoleFunctionCodes().length === 0) {

				toastr.warning("Please select atleast one Module and Sub Module", "Role");
				errors = errors + 1;
			}

            //if (errors === 0) {
            //}

            if (errors === 0 && toasterAlerts === "N") {
                ko.mapping.fromJS(self.RoleFunctions, {}, model.RoleFunctions);
                ko.mapping.fromJS(self.InRoleFunctionCodes, {}, model.RoleFunctionCodeArray);
                ko.mapping.fromJS(self.Modules, {}, model.Modules);
                $.confirm({
                    'title': 'Role',
                    'message': 'Are you sure you want to Save Role?',
                    'buttons': {
                        'Yes': {
                            'class': 'green',
                            'action': function () {
                            	$('#clolebt').trigger('click');
                                self.viewModelHelper.apiPost('api/Role', ko.mapping.toJSON(model), function Message(data) {
                                    toastr.options.closeButton = true;
                                    toastr.options.positionClass = "toast-top-right";
                                    toastr.success("Role Details saved successfully.", "Role");
                                    setTimeout(
                                            function () {
                                                window.location.href = "/Roles";
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


		self.changevalidatePartnerType = function (model) {

            if (model.PartnerTypeArray().length > 0) {
                $('#validatePartnerType').text('');

            }


        }
        self.UpdateRole = function (model) {
            var errors = self.ValidationCheck(model);
            var toasterAlerts = "N";
         
            //if (errors === 0) {
            //}

            if (model.PartnerTypeArray() === null || model.PartnerTypeArray().length === 0) {
                $('#validatePartnerType').text('This field is required.');
                errors = errors + 1;
            }


         
            if (self.InRoleFunctionCodes() == null || self.InRoleFunctionCodes().length === 0) {

				toastr.warning("Please select atleast one Module and Sub Module", "Role");
				errors = errors + 1;
			}
            if (errors === 0 && toasterAlerts === "N") {
                ko.mapping.fromJS(self.RoleFunctions, {}, model.RoleFunctions);
                ko.mapping.fromJS(self.InRoleFunctionCodes, {}, model.RoleFunctionCodeArray);
                ko.mapping.fromJS(self.Modules, {}, model.Modules);

                $.confirm({
                    'title': 'Role',
                    'message': 'Are you sure you want to Update Role?',
                    'buttons': {
                        'Yes': {
                            'class': 'green',
                            'action': function () {
                            	$('#clolebt').trigger('click');
                                self.viewModelHelper.apiPost('api/Role', ko.mapping.toJSON(model), function Message(data) {
                                    toastr.options.closeButton = true;
                                    toastr.options.positionClass = "toast-top-right";
                                    toastr.success("Role Details updated successfully.", "Role");
                                    setTimeout(
                                            function () {
                                                window.location.href = "/Roles";
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

        self.ResetRole = function (model) {           
            $.confirm({
                'title': 'Role',
                'message': 'Are you sure you want to Reset Role?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {                            
                            if (roleId != null && roleId !== "" && roleId != undefined) {
                                self.GetEntityFunctions();
                                $('#validatePartnerType').text('');
                            } else {
                            	self.Initialize();
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
                            window.location.href = "/Roles";
	
           
        }

        self.Initialize();
    }

    eGateRoot.RoleViewModel = RoleViewModel;
}(window.eGateRoot));


