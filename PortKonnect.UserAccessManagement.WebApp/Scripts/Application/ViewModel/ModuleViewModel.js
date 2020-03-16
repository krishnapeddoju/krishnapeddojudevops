(function (eGateRoot) {
    var ModuleViewModel = function () {
        var self = this; self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.Moduledata = ko.observableArray();
       
        self.moduleModel = ko.observable();
        self.Initialize = function () {
           
            self.moduleModel(new eGateRoot.ModuleModel());
            self.LoadModules();
        }


        Logout = function () {
            localStorage.clear();
            sessionStorage.clear();
            window.location = window.location.origin + application.viewbag.appSettings.returnUrl;
        }
        // Loads the module data
        self.LoadModules = function () {
            self.months = ko.observableArray(['France', 'Germany', 'Spain']);

            var userName = self.viewModelHelper.Name();
            if (userName.indexOf('.') !== -1)
                userName= userName.replace(/\./g, '_dot_');
            self.viewModelHelper.apiGet('api/Account/GetMenuForUser/' + self.viewModelHelper.ApplicationId() + '/' + self.viewModelHelper.SubscriberId() + '/' + userName, null, function (result) {
                result = result.filter(module => module.ModuleId == "PKCUAM");
                var appFunctions = [];
                $.each(result, function (key, val) {
                    if (val.AppEntities != null) {
                        $.each(val.AppEntities, function (key1, val1) {
                            if (val1.EntityUrl === "null") {
                                val1.EntityUrl = 'javascript:;';

                            }
                            else {
                                val1.EntityUrl = '../../../../../../' + val1.EntityUrl;
                            }
                            if (val1.AppFunctions != null) {
                                $.each(val1.AppFunctions, function (key2, val2) {
                                    val2.Url = '/' + val2.Url;
                                });
                            }
                        });
                    }
                });
               
                $.each(result[0].AppEntities, function (key3, val3) {
                    $.each(val3.AppFunctions, function (key4, val4) {
                        appFunctions.push(val4);
                    });
                });

                ko.mapping.fromJS(appFunctions, {}, self.Moduledata);
               
                var strHash = document.location.pathname;

                if (strHash != "/Account/ChangePassword/Y" && strHash != "/MyProfile") {
                    jQuery("a[href='" + strHash + "']").parent().addClass("active");
                    jQuery("a[href='" + strHash + "']").parent().parent().parent().addClass("active");
                    jQuery("a[href='" + strHash + "']").parent().parent().parent().children('a').children('span.arrow').addClass('open');
                    jQuery("a[href='" + strHash + "']").parent().parent().parent().parent().parent().addClass("active");
                    jQuery("a[href='" + strHash + "']").parent().parent().parent().parent().parent().children('a').children('span.arrow').addClass("open");
                }

            }, null, null, null, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }
        self.Initialize();
    }
    eGateRoot.ModuleViewModel = ModuleViewModel;

}(window.eGateRoot));

