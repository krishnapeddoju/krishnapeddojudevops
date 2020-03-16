(function (eGateRoot) {
    var SuperCategoryViewViewModel = function (supCatId) {
        var self = this;
        $(document).ready(function () {

            $('#spnTitle').html("View Super Category");
        });

        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.viewMode = ko.observable();
        self.editableView = ko.observable(true);
        self.superCategoryModel = ko.observable(new eGateRoot.SuperCategoryModel());
        self.IsExit = ko.observable(true);
        self.IsCodeEnable = ko.observable(true);
        toastr.options.closeButton = true;
        toastr.options.positionClass = "toast-top-right";

        self.GetSuperCategoryDetails = function () {
            self.viewModelHelper.apiGet('api/SuperCategory/' + supCatId,
        null,
          function (result) {
              if (result != null) {
                  if (supCatId != null && supCatId !== "" && supCatId != undefined) {
                      self.superCategoryModel(new eGateRoot.SuperCategoryModel(result));
                  } else {
                      self.superCategoryModel(new eGateRoot.SuperCategoryModel());
                  }
              }
              else {
                  toastr.error("Super Category doesn't exist", "Super Category");
                  setTimeout(function () {
                      window.location.href = window.location.origin + "/SuperCategories";
                  }, 2000);
              }
          }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }

        self.ExitScreen = function () {
            window.location.href = "../../SuperCategories";
        }

        self.EditSuperCategory = function () {
            window.location.href = "../../SuperCategory/" + supCatId;
        }

        self.Initialize = function () {
            self.viewMode('Form');
            self.superCategoryModel(new eGateRoot.SuperCategoryModel());
            self.GetSuperCategoryDetails();
        }      


        self.Initialize();
    }
    eGateRoot.SuperCategoryViewViewModel = SuperCategoryViewViewModel;
}(window.eGateRoot));

