(function (eGateRoot) {
    var SuperCategoryListViewModel = function () {

        var self = this;
        $('#spnTitle').html("Super Category List");
        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.validationHelper = new eGateRoot.ValidationHelper();
        self.viewMode = ko.observable();
        self.superCategoryModel = ko.observable();
        self.SuperCategoryGridModel = ko.observable();
        self.SuperCategoriesList = ko.observableArray([]);

        self.LoadSuperCategories = function () {
            self.viewModelHelper.apiGet('api/GetSuperCategories', null,
             function (result) {
                 self.SuperCategoriesList(ko.utils.arrayMap(result, function (item) {
                     return new eGateRoot.SuperCategoryGridModel(item);
                 }));
             }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }

        self.ViewSuperCategory = function (model) {
           window.location.href = "SuperCategoryView/" + model.SupCatId();
        }
        self.EditSuperCategory = function (model) {

            window.location.href = "SuperCategory/" + model.SupCatId();
        }
        self.AddSuperCategory = function (model) {
            window.location.href = "SuperCategory";
        }

        self.Initialize = function () {
            self.superCategoryModel(new eGateRoot.SuperCategoryModel());
            self.SuperCategoryGridModel(new eGateRoot.SuperCategoryGridModel());
            self.LoadSuperCategories();
            self.viewMode('List');
        }
        self.Initialize();
    }
    eGateRoot.SuperCategoryListViewModel = SuperCategoryListViewModel;
}(window.eGateRoot));