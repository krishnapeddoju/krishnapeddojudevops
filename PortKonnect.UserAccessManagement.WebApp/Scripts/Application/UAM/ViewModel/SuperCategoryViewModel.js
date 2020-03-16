(function (eGateRoot) {
    var SuperCategoryViewModel = function (supCatId) {
        var self = this;
        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.validationHelper = new eGateRoot.ValidationHelper();
        self.superCategoryModel = ko.observable(new eGateRoot.SuperCategoryModel());        
        self.IsEdit = ko.observable(true);
        self.viewMode = ko.observable();
        self.IsSave = ko.observable(true);
        self.IsUpdate = ko.observable(false);
        self.IsReset = ko.observable(true);
        self.SuperCategoriesList = ko.observableArray([]);
        self.IsSuperCodeEnable = ko.observable(true);
        self.IsSuperCategoryEnable = ko.observable(true);


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


        self.LoadSuperCategories = function () {
            self.viewModelHelper.apiGet('api/GetSuperCategories', null,
             function (result) {
                 ko.mapping.fromJS(result, {}, self.SuperCategoriesList);
             }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }

        self.EditSuperCategory = function () {

        }

        self.Initialize = function () {
            self.viewMode('Form');
            self.GetSuperCategoryDetails();            
            self.IsSuperCategoryEnable(true);
            self.LoadSuperCategories();
            if (supCatId != null && supCatId !== "" && supCatId != undefined) {
                self.IsSave(false);
                self.IsUpdate(true);
                $(document).ready(function () {
                    $('#spnTitle').html("Edit Super Category");
                });
                
                self.IsSuperCodeEnable(false);

            } else {
                self.IsSave(true);
                self.IsUpdate(false);
                $(document).ready(function () {
                    $('#spnTitle').html("Add Super Category");
                });

                self.IsSuperCodeEnable(true);
            }
        }        

        self.ValidationCheck = function (model) {
            self.superCategoryModel().validationEnabled(true);
            model.validationEnabled(true);
            self.SuperCategoryValidation = ko.observable(model);
            self.SuperCategoryValidation().errors = ko.validation.group(self.SuperCategoryValidation());
            var errors = 0;
            errors = self.SuperCategoryValidation().errors().length;
            return errors;
        }

        self.SaveSuperCategory = function (model) {

            var errors = self.ValidationCheck(model);
            var toasterAlerts = "N";
            $.each(self.SuperCategoriesList(), function (index, item) {
                if (item.SupCatCode().toUpperCase() == model.SupCatCode().toUpperCase().trim()) {

                    toastr.warning("Super Category Code already Exists.", "Super Category");
                    errors = errors + 1;
                }
            });

            $.each(self.SuperCategoriesList(), function (index, item) {
                if (item.SupCatName().toUpperCase() == model.SupCatName().toUpperCase().trim()) {

                    toastr.warning("Super Category Name already Exists.", "Super Category");
                    errors = errors + 1;
                }

            });

            if (errors === 0) {              
                $.confirm({
                    'title': 'Super Category',
                    'message': 'Are you sure you want to Save Super Category?',
                    'buttons': {
                        'Yes': {
                            'class': 'green',
                            'action': function () {
                                $('#clolebt').trigger('click');
                                self.viewModelHelper.apiPost('api/SuperCategory', ko.mapping.toJSON(model), function Message(data) {
                                    toastr.options.closeButton = true;
                                    toastr.options.positionClass = "toast-top-right";
                                    toastr.success("Super Category Details saved successfully.", "Super Category");
                                    setTimeout(
                                            function () {
                                                window.location.href = "/SuperCategories";
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
       
        self.UpdateSuperCategory = function (model) {
            var errors = self.ValidationCheck(model);
            var toasterAlerts = "N";

            if (errors === 0) {
                $.each(self.SuperCategoriesList(), function (index, item) {
                    if (!((item.SupCatCode()).toLowerCase() == (model.SupCatCode()).toLowerCase())) {
                        if ((item.SupCatName()).toLowerCase() == (model.SupCatName()).toLowerCase()) {
                            toastr.warning("Super Category Name already Exists.", "Super Category");
                            errors = errors + 1;
                        }
                    }
                });
            }
          
            if (errors === 0) {    

                $.confirm({
                    'title': 'Super Category',
                    'message': 'Are you sure you want to Update Super Category?',
                    'buttons': {
                        'Yes': {
                            'class': 'green',
                            'action': function () {
                                $('#clolebt').trigger('click');
                                self.viewModelHelper.apiPost('api/SuperCategory', ko.mapping.toJSON(model), function Message(data) {
                                    toastr.options.closeButton = true;
                                    toastr.options.positionClass = "toast-top-right";
                                    toastr.success("Super Category Details updated successfully.", "Super Category");
                                    setTimeout(
                                            function () {
                                                window.location.href = "/SuperCategories";
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

        self.ResetSuperCategory = function (model) {
            $.confirm({
                'title': 'Super Category',
                'message': 'Are you sure you want to Reset Super Category?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                            if (supCatId != null && supCatId !== "" && supCatId != undefined) {
                                 self.GetSuperCategoryDetails();                                
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
            window.location.href = "/SuperCategories";


        }

        self.Initialize();
    }

    eGateRoot.SuperCategoryViewModel = SuperCategoryViewModel;
}(window.eGateRoot));


