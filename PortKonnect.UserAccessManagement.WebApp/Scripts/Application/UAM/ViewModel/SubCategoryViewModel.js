(function (eGateRoot) {
    var SubCategoryViewModel = function (subCatId) {
        var self = this;
        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.validationHelper = new eGateRoot.ValidationHelper();
        self.subCategoryModel = ko.observable(new eGateRoot.SubCategoryModel());        
        self.SuperCategoryList = ko.observableArray();
        self.IsEdit = ko.observable(true);
        self.viewMode = ko.observable();
        self.IsSave = ko.observable(true);
        self.IsUpdate = ko.observable(false);
        self.IsReset = ko.observable(true);
        self.SubCategoriesList = ko.observableArray([]);
        self.AllSubCategoryList = ko.observableArray([]);
        self.IsSubCodeEnable = ko.observable(true);
        self.IsSubCategoryEnable = ko.observable(true);
        self.IsSuperCatChanged = ko.observable(true);
               

        self.LoadDefaultGrid = function () {         
            self.viewModelHelper.apiGet('api/GetSuperCategories', null,
         function (result) {
             var SuperCategories = $.map(result, function (item) {
                         return new self.SuperCategory(item);
                     });
                     self.SuperCategoryList(SuperCategories);
         }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');


        };

        self.SuperCategory = function (data) {
            this.SupCatId = ko.observable(data.SupCatId);
            this.SupCatCode = ko.observable(data.SupCatCode);
            this.SupCatName = ko.observable(data.SupCatCode + '-' + data.SupCatName);
        };


        self.LoadSubCategories = function () {
            self.viewModelHelper.apiGet('api/GetSubCategories', null,
             function (result) {
                 ko.mapping.fromJS(result, {}, self.AllSubCategoryList);
             }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }

        self.EditSubCategory = function (model) {
            self.subCategoryModel(model);
            self.IsSubCodeEnable(false);
            self.IsSubCategoryEnable(true);
            self.IsSave(false);
            self.IsUpdate(true);
            self.IsReset(true);
            $(document).ready(function () {
                $('#spnTitle').html("Edit Sub Category");
            });
        }

        self.ViewSubCategory = function (model) {
            self.subCategoryModel(model);
            self.IsSubCodeEnable(false);
            self.IsSubCategoryEnable(false);
            self.IsSave(false);
            self.IsUpdate(false);
            self.IsReset(false);
            $(document).ready(function () {
                $('#spnTitle').html("View Sub Category");
            });

        }

        self.Initialize = function () {
            self.viewMode('Form');          
            self.LoadDefaultGrid();
            self.IsSubCategoryEnable(true);
            self.IsSubCodeEnable(true);
            self.IsReset(true);
           self.LoadSubCategories();
            if (subCatId != null && subCatId !== "" && subCatId != undefined) {
                self.IsSave(false);
                self.IsUpdate(true);
                $(document).ready(function () {
                    $('#spnTitle').html("Edit Sub Category");
                });

                self.IsSubCodeEnable(false);

            } else {
                self.IsSave(true);
                self.IsUpdate(false);
                $(document).ready(function () {
                    $('#spnTitle').html("Add Sub Category");
                });

                self.IsSubCodeEnable(true);
            }
        }

        self.SupCatChanged = function (event) {
            if (event.SupCatCode() == undefined) {                
                self.SubCategoryList({ SubcatCode: 0, SubcatName: '' });
                self.IsSuperCatChanged(false);
            }
            else {
                self.IsSuperCatChanged(true);
                $('#spanSupcatid').text('');
                $("#grid").show();
                self.LoadGrid(event.SupCatId());
            }
        }

        self.LoadGrid = function (supCatId) {
            if (supCatId == undefined) {
                self.SubCategoryList({ SubcatCode: 0, SubcatName: '' });
                self.IsSuperCatChanged(false);
            }
            else {
                self.viewModelHelper.apiGet('api/SubCategories/' + supCatId, null, function (result) {
                    self.SubCategoriesList(ko.utils.arrayMap(result, function (item) {
                        return new eGateRoot.SubCategoryModel(item);
                    }));
                });               
            }
        }

        self.ValidationCheck = function (model) {
            self.subCategoryModel().validationEnabled(true);
            model.validationEnabled(true);
            self.SubCategoryValidation = ko.observable(model);
            self.SubCategoryValidation().errors = ko.validation.group(self.SubCategoryValidation());
            var errors = 0;
            errors = self.SubCategoryValidation().errors().length;
            return errors;
        }

        self.SaveSubCategory = function (model) {

            var errors = self.ValidationCheck(model);
            var toasterAlerts = "N";
            $.each(self.AllSubCategoryList(), function (index, item) {
                if (item.SubCatCode().toUpperCase() == model.SubCatCode().toUpperCase().trim()) {

                    toastr.warning("Sub Category Code already Exists.", "Sub Category");
                    errors = errors + 1;
                }

            });


            $.each(self.AllSubCategoryList(), function (index, item) {
                if (item.SubCatName().toUpperCase() == model.SubCatName().toUpperCase().trim()) {

                    toastr.warning("Sub Category Name already Exists.", "Sub Category");
                    errors = errors + 1;
                }

            });

            if (errors === 0) {                
                $.confirm({
                    'title': 'Sub Category',
                    'message': 'Are you sure you want to Save Sub Category?',
                    'buttons': {
                        'Yes': {
                            'class': 'green',
                            'action': function () {
                                $('#clolebt').trigger('click');
                                self.viewModelHelper.apiPost('api/SubCategory', ko.mapping.toJSON(model), function Message(data) {
                                    toastr.options.closeButton = true;
                                    toastr.options.positionClass = "toast-top-right";
                                    toastr.success("Sub Category Details saved successfully.", "Sub Category");
                                    setTimeout(
                                            function () {
                                                window.location.href = "/SubCategories";
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


        
        self.UpdateSubCategory = function (model) {
            var errors = self.ValidationCheck(model);
            var toasterAlerts = "N";        

            
            if (errors === 0) {
                $.confirm({
                    'title': 'Sub Category',
                    'message': 'Are you sure you want to Update Sub Category?',
                    'buttons': {
                        'Yes': {
                            'class': 'green',
                            'action': function () {
                                $('#clolebt').trigger('click');
                                self.viewModelHelper.apiPost('api/SubCategory', ko.mapping.toJSON(model), function Message(data) {
                                    toastr.options.closeButton = true;
                                    toastr.options.positionClass = "toast-top-right";
                                    toastr.success("Sub Category Details updated successfully.", "Sub Category");
                                    setTimeout(
                                            function () {
                                                window.location.href = "/SubCategories";
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

        self.ResetSubCategory = function (model) {
            $.confirm({
                'title': 'Sub Category',
                'message': 'Are you sure you want to Reset Sub Category?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {                           
                            if (self.IsSave()) {
                            self.subCategoryModel().reset();
                            self.SubCategoriesList.removeAll();                                
                            } else {                              
                                ko.validation.reset();
                                self.subCategoryModel().reset();
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
            window.location.href = "/SubCategories";


        }

        self.Initialize();
    }

    eGateRoot.SubCategoryViewModel = SubCategoryViewModel;
}(window.eGateRoot));


