(function (eGateRoot) {
    var EmployeeViewViewModel = function (empId) {
        var self = this;
        $(document).ready(function () {

            $('#spnTitle').html("View Employee");
        });

        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.viewMode = ko.observable();
        self.editableView = ko.observable(true);
        self.employeeModel = ko.observable(new eGateRoot.EmployeeModel());       
        self.IsExit = ko.observable(true);
        self.IsCodeEnable = ko.observable(true);
        toastr.options.closeButton = true;
        toastr.options.positionClass = "toast-top-right";

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

        self.ExitScreen = function () {
            window.location.href = "../../Employees";
        }

        self.EditEmployee = function () {            
            window.location.href = "../../Employee/" + empId;
        }

        self.Initialize = function () {

            self.viewMode('Form');
            self.employeeModel(new eGateRoot.EmployeeModel());   
            self.GetEmployeeDetails();
        }




        self.Initialize();
    }
    eGateRoot.EmployeeViewViewModel = EmployeeViewViewModel;
}(window.eGateRoot));

