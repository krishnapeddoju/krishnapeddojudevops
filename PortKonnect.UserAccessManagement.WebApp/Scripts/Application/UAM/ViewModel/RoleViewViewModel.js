(function (eGateRoot) {
    var RoleViewViewModel = function (roleId) {
    	var self = this;
    	$(document).ready(function () {

    		$('#spnTitle').html("View Role");
    	});
     
        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.viewMode = ko.observable();
        self.editableView = ko.observable(true);
        self.RoleModel = ko.observable(new eGateRoot.RoleModel());
        self.RoleFunctionCodeArray = ko.observableArray([]);
        self.RoleFunctions = ko.observableArray([]);
        self.Entities = ko.observableArray([]);
        self.InRoleFunctionCodes = ko.observableArray([]);
        self.IsExit = ko.observable(true);
        self.IsCodeEnable = ko.observable(true);
        self.Modules = ko.observableArray([]);
        toastr.options.closeButton = true;
        toastr.options.positionClass = "toast-top-right";

        self.GetEntityFunctions = function () {
        	
            var jsonArr = [];
            var jsonArrMarine = [];
            self.viewModelHelper.apiGet('api/Role/' + roleId,
        null,
          function (result) {
              if (result != null) {
                  console.log("moduels",result)
                  result.Modules.sort(function (left, right) {
                      return left.ModuleName == right.ModuleName ? 0 : (left.ModuleName < right.ModuleName ? 1 : -1)
                  });
                  if (roleId != null && roleId !== "" && roleId != undefined) {
                      self.RoleModel(new eGateRoot.RoleModel(result));
                      ko.mapping.fromJS(result.RoleFunctions, {}, self.RoleFunctions);
                      ko.mapping.fromJS(result.RoleFunctionCodeArray, {}, self.RoleFunctionCodeArray);
                      ko.mapping.fromJS(result.Modules, {}, self.Modules);
                  } else {
                      self.RoleModel(new eGateRoot.RoleModel());
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
                $("#treeview .k-checkbox").attr("disabled", true);

                $("#marinetreeview").kendoTreeView({
                    checkboxes: {
                        checkChildren: true
                    },

                    check: onCheck,

                    dataSource: jsonArrMarine
                });
                $("#marinetreeview .k-checkbox").attr("disabled", true);
            });
        }

        self.ExitScreen = function () {
            window.location.href = "../../Roles";
        }

        self.EditRole = function () {
            window.location.href = "../../Role/" + roleId;
        }

        self.Initialize = function () {
        	
            self.viewMode('Form');
            self.RoleModel(new eGateRoot.RoleModel());
            self.GetEntityFunctions();

            
        }

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
            // TODO: is the update of datasource needed
            var checkedNodesEntities = [],
             checkedNodesFunctions = [],
                treeView = $("#treeview").data("kendoTreeView"),
                marinetreeView = $("#marinetreeview").data("kendoTreeView"),
                message;

            checkedNodeIdsEntities(treeView.dataSource.view(), checkedNodesEntities, checkedNodesFunctions);
            checkedNodeIdsEntities(marinetreeView.dataSource.view(), checkedNodesEntities, checkedNodesFunctions);
            ko.mapping.fromJS(checkedNodesFunctions, {}, self.InRoleFunctionCodes);
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

        self.Initialize();
    }
    eGateRoot.RoleViewViewModel = RoleViewViewModel;
}(window.eGateRoot));

