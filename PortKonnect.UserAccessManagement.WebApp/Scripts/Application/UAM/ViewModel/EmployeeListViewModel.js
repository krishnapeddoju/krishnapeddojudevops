(function (eGateRoot) {
    var EmployeeListViewModel = function () {

        var self = this;
        $('#spnTitle').html("Employee List");
        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.validationHelper = new eGateRoot.ValidationHelper();
        self.viewMode = ko.observable();
        self.employeeModel = ko.observable();
        self.EmployeeGridModel = ko.observable();
        self.EmployeesList = ko.observableArray([]);
        self.DepartmentsList = ko.observableArray([]);       

        self.LoadEmployees = function () {

            self.viewModelHelper.apiGet('api/EmployeesGridList', { EmployeeNo: "All", DepartmentType: "All" },
              function (result) {
                  self.EmployeesList(ko.utils.arrayMap(result, function (item) {
                      return new eGateRoot.EmployeeGridModel(item);
                  }));
                  setTimeout(function () {
                      $('#EmployeeGrid').data().kendoGrid.dataSource.page(1);
                      $("form.k-filter-menu button[type='reset']").trigger("click");
                      $("#EmployeeGrid").data("kendoGrid").dataSource.sort({});
                  });
              }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }

        self.Filteremployee = function () {
            var EmployeeNo = $("#SearchEmployeeNo").val();
            var DepartmentType = $("#ddlDepartmentType").val();
          
            if (EmployeeNo == null || EmployeeNo == undefined || EmployeeNo == "") {
                EmployeeNo = "All";
            }

            if (DepartmentType == null || DepartmentType == undefined || DepartmentType == "") {
                DepartmentType = "All";
            }


            self.viewModelHelper.apiGet('api/EmployeesGridList', { EmployeeNo: EmployeeNo, DepartmentType: DepartmentType },
             function (result) {
                 self.EmployeesList(ko.utils.arrayMap(result, function (item) {

                     return new eGateRoot.EmployeeGridModel(item);
                 }));
                 $('#EmployeeGrid').data().kendoGrid.dataSource.page(1);
                 $("form.k-filter-menu button[type='reset']").trigger("click");
                 $("#EmployeeGrid").data("kendoGrid").dataSource.sort({});
             }, null, null, false, application.viewbag.appSettings.uamapiUrl);

                       
        }


        self.ResetFilters = function (data) {
            self.EmployeeGridModel(new eGateRoot.EmployeeGridModel());
            self.LoadEmployees();
        }

        self.LoadDepartments = function () {
            self.viewModelHelper.apiGet('api/GetDepartments', null,
             function (result) {
                 ko.mapping.fromJS(result, {}, self.DepartmentsList);
             }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }


        self.ViewEmployee = function (model) {
            window.location.href = "EmployeeView/" + model.EmployeeID();
        }
        self.EditEmployee = function (model) {            
            window.location.href = "Employee/" + model.EmployeeID();
        }
        self.AddEmployee = function (model) {
            window.location.href = "Employee";
        }

        self.Initialize = function () {
            self.employeeModel(new eGateRoot.EmployeeModel());
            self.EmployeeGridModel(new eGateRoot.EmployeeGridModel());
            self.LoadDepartments();
            self.LoadEmployees();
            self.viewMode('List');
        }
        self.Initialize();
    }
    eGateRoot.EmployeeListViewModel = EmployeeListViewModel;
}(window.eGateRoot));