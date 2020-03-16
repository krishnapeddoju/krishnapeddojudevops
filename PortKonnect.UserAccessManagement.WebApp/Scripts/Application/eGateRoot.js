window.eGateRoot = {};
var clientId;
(function (cr) {
  
    var initialId;
    cr.initialId = initialId;


    //Logout = function () {
    //    localStorage.clear();
    //    sessionStorage.clear();
    //    window.location = window.location.origin + application.viewbag.appSettings.returnUrl;
    //}

    //var ModuleViewModel = function () {
    //    var self = this;
    //    self.Moduledata = ko.observableArray();
    //    self.viewModelHelper = new eGateRoot.ViewModelHelper();
    //    self.moduleModel = ko.observable();
    //    self.Initialize = function () {
           

    //        self.moduleModel(new eGateRoot.ModuleModel());

    //    }
    //}

    //Logout = function () {
   
    //        localStorage.clear();
    //        sessionStorage.clear();
    //        window.location = window.location.origin + application.viewbag.appSettings.returnUrl;
    //    }
    //    // Loads the module data
       
       
    //}
    //eGateRoot.ModuleViewModel = ModuleViewModel;
    CutPaste();
}(window.eGateRoot));

/*
jQuery.browser.mobile (http://detectmobilebrowser.com/)
 *
 * jQuery.browser.mobile will be true if the browser is a mobile device
 *
 **/
(function (a) {
    (jQuery.browser = jQuery.browser || {}).mobile = /(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(a) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(a.substr(0, 4));
})(navigator.userAgent || navigator.vendor || window.opera);

(function (cr) {
    var initialState;
    cr.initialState = initialState;
    CutPaste();
}(window.eGateRoot));

(function (cr) {
    var rootPath;
    cr.rootPath = rootPath;
    CutPaste();
}(window.eGateRoot));

(function (cr) {
    var mustEqual = function (val, other) {
        return val == other();
    }
    cr.mustEqual = mustEqual;
    CutPaste();
}(window.eGateRoot));

(function (cr) {
    var viewModelHelper = function () {
        var self = this;

        self.modelIsValid = ko.observable(true);
        self.modelErrors = ko.observableArray();
        self.months = ko.observableArray(['France', 'Germany', 'Spain']);
        self.isLoading = ko.observable(false);
        self.statePopped = false;
        localStorage.setItem("KPCT-2AccessKey", application.viewbag.accessToken);
        localStorage.setItem("accessTokenExpiry", application.viewbag.accessTokenExpiry);
        localStorage.setItem("accessToken", application.viewbag.accessToken);
        //  localStorage.accessToken = application.viewbag.accessToken;
        self.authtoken = ko.observable('Bearer ' + localStorage.getItem("KPCT-2AccessKey"));
        self.authtokenExpiry = ko.observable(localStorage.getItem("accessTokenExpiry"));
        self.dateFormat = new eGateRoot.DateFormat();
        self.DefaultApiUrl = ko.observable(application.viewbag.appSettings.eGateAPIUrl);
        self.Name = ko.observable();
        if (!isEmpty(application.viewbag.name))
            self.Name(application.viewbag.name.toLowerCase());
        self.stateInfo = {};
        var token = localStorage.accessToken;
        var headers = {};
        clientId = application.viewbag.appSettings.client_id;
        self.ApplicationId = ko.observable(application.viewbag.applicationId);
        self.SubscriberId = ko.observable(application.viewbag.subscriberId);
        self.signin = ko.observable(application.viewbag.signin);

        self.StaticFilePath = ko.observable(application.viewbag.appSettings.staticFilePath);
        if (token) {
            headers.Authorization = 'Bearer ' + token;
        }
        self.apiGet = function (uri, data, success, failure, always, isAsync, rootPath, serviceDomain) {
            self.isLoading(true);
            self.modelIsValid(true);
            if (isAsync === undefined) {
                isAsync = true;
            }
            if (rootPath == undefined) {
                rootPath = application.viewbag.appSettings.eGateAPIUrl;//eGateRoot.rootPath;
                //alert('rootPath : ' + rootPath);
            }

            if (serviceDomain === 'UAM') {
                rootPath = application.viewbag.appSettings.uamapiUrl;
                //alert('UAM rootPath : ' + rootPath);

            }

            if (serviceDomain === 'CSA') {
                rootPath = application.viewbag.appSettings.containerApiURL;
                //alert('UAM rootPath : ' + rootPath);

            }

            if (serviceDomain === 'TASK') {
                rootPath = application.viewbag.appSettings.taskApiURL;
                //alert('UAM rootPath : ' + rootPath);

            }

            if (serviceDomain === 'CHAT') {
                rootPath = application.viewbag.appSettings.chatAPIUrl;
            }
            var token = localStorage.getItem("KPCT-2AccessKey");
            if (token == null && uri != 'api/LoadPartnerTypes' && uri != 'api/CheckPartnerExist') {
                window.location = application.viewbag.appSettings.sessionExpired;
            }
            $.ajax({
                type: 'Get', url: rootPath + uri, data: data, contentType: 'application/json;charset=utf-8', headers: headers,
                dataType: 'json', async: isAsync, headers: { 'Authorization': 'Bearer ' + token }, cache: false
            })
                .done(success)
                .fail(function (result) {
                    if (failure == null) {
                        if (result.status == 401) { //Token Expires
                            setTimeout(
                                function () {
                                    RedirectToSessionExpiredPage();
                                }, 2000);
                        } else if (result.status == 400) {
                            self.modelErrors(JSON.parse(result.responseText));
                        } else {
                            self.modelErrors([result.status + ':' + result.statusText + ':' + result.responseText]);
                        }
                        toastr.options.closeButton = true;
                        toastr.options.positionClass = "toast-top-right";
                        toastr.error(result.responseText);
                        self.modelIsValid(false);
                    }
                    else
                        failure(result);
                })
                .always(function () {
                    if (always == null) {
                        setTimeout(function () { self.isLoading(false); }, 1000);

                    } else
                        always();
                });
        };

        self.apiGetAno = function (uri, data, success, failure, always, isAsync, rootPath, serviceDomain) {
            self.isLoading(true);
            self.modelIsValid(true);
            if (isAsync === undefined) {
                isAsync = true;
            }
            if (rootPath == undefined) {
                rootPath = application.viewbag.appSettings.eGateAPIUrl;//eGateRoot.rootPath;
                //alert('rootPath : ' + rootPath);
            }

            if (serviceDomain === 'UAM') {
                rootPath = application.viewbag.appSettings.uamapiUrl;
                //alert('UAM rootPath : ' + rootPath);

            }

            if (serviceDomain === 'CHAT') {
                rootPath = application.viewbag.appSettings.chatAPIUrl;
            }
            if (token == null && uri != 'Login' && uri != 'api/Account/ForgotPassword' && uri != 'api/Account/ResetPassword'
                && uri != 'api/GetStatuses' && uri != 'api/GetYears' && uri != 'api/GetDocumentTypes' && uri != 'api/GetDocumentTypesByPartnerType' && uri != 'api/PartnerRegistration' && uri != 'api/CountriesPartner' && uri != 'api/GetPartnerRegistration' && uri != 'api/CheckUniquePartnerName') {
                window.location = application.viewbag.appSettings.sessionExpired;
            }
            $.ajax({
                type: 'Get', url: rootPath + uri, data: data, contentType: 'application/json;charset=utf-8', headers: headers,
                dataType: 'json', async: isAsync, cache: false
            })
                .done(success)
                .fail(function (result) {

                })
                .always(function () {
                    if (always == null) {
                        setTimeout(function () { self.isLoading(false); }, 1000);

                    } else
                        always();
                });
        };

        self.apiPost = function (uri, data, sucessCallback, failureCallback, alwaysCallback, rootPath, contentType, serviceDomain) {
            self.isLoading(true);
            self.modelIsValid(true);
            if (rootPath == undefined) {
                rootPath = application.viewbag.appSettings.eGateAPIUrl;//eGateRoot.rootPath;
            }
            if (serviceDomain === 'UAM') {
                rootPath = application.viewbag.appSettings.uamapiUrl;

            }
            if (serviceDomain === 'CHAT') {
                rootPath = application.viewbag.appSettings.chatAPIUrl;
            }
            if (contentType == undefined) {
                contentType = "application/json; charset=utf-8";
            }

            var token = localStorage.getItem("KPCT-2AccessKey");

            if (token == null && uri != 'Login' && uri != 'api/Account/ForgotPassword' && uri != 'api/Account/ResetPassword'
                && uri != 'api/GetStatuses' && uri != 'api/GetDocumentTypes' && uri != 'api/GetDocumentTypesByPartnerType' && uri != 'api/PartnerRegistration' && uri != 'api/SavePartnerFeedbackByAno') {
                window.location = application.viewbag.appSettings.sessionExpired;
            }
            var csrfToken = $("input[name='__RequestVerificationToken']").val() != undefined ? $("input[name='__RequestVerificationToken']").val() : null;

            $.ajax({
                type: 'Post', url: rootPath + uri, data: data, contentType: contentType, headers: headers,
                dataType: 'json', async: false, headers: { 'Authorization': 'Bearer ' + token}
            })
                .done(sucessCallback)
                .fail(function (result) {
                    if (failureCallback == null) {
                        if (result.status == 401) { //Token Expires
                            setTimeout(
                                function () {
                                    RedirectToSessionExpiredPage();
                                }, 2000);
                        } else if (result.status == 400) {
                            self.modelErrors(JSON.parse(result.responseText));
                        } else {
                            self.modelErrors([result.status + ':' + result.statusText + ':' + result.responseText]);
                        }
                        toastr.options.closeButton = true;
                        toastr.options.positionClass = "toast-top-right";
                        toastr.error(result.responseText);
                        self.modelIsValid(false);
                    } else {
                        failureCallback(result);
                    }
                })
                .always(function () {
                    if (alwaysCallback == null) {
                        self.isLoading(false);
                    } else {
                        alwaysCallback();
                    }
                });
        };
        self.apiPutAsync = function (uri, data, sucessCallback, failureCallback, alwaysCallback, rootPath, contentType, serviceDomain) {
            self.isLoading(true);
            self.modelIsValid(true);
            if (rootPath == undefined) {
                rootPath = application.viewbag.appSettings.eGateAPIUrl;//eGateRoot.rootPath;
            }
            if (serviceDomain === 'UAM') {
                rootPath = application.viewbag.appSettings.uamapiUrl;
                //alert('UAM rootPath : ' + rootPath);

            }
            if (serviceDomain === 'CHAT') {
                rootPath = application.viewbag.appSettings.chatAPIUrl;
            }
            if (contentType == undefined) {
                contentType = "application/json; charset=utf-8";
            }

            var token = localStorage.getItem("KPCT-2AccessKey");
            if (token == null) {
                window.location = application.viewbag.appSettings.sessionExpired;
            }

            $.ajax({
                type: 'Put', url: rootPath + uri, data: data, contentType: 'application/json;charset=utf-8', headers: headers,
                dataType: 'json', async: false, headers: { 'Authorization': 'Bearer ' + token }
            })
                .done(sucessCallback)
                .fail(function (result) {
                    if (failureCallback == null) {
                        if (result.status == 401) { //Token Expires
                            setTimeout(
                                function () {
                                    RedirectToSessionExpiredPage();
                                }, 2000);
                        } else if (result.status == 400) {
                            self.modelErrors(JSON.parse(result.responseText));
                        } else {
                            self.modelErrors([result.status + ':' + result.statusText + ':' + result.responseText]);
                        }
                        toastr.options.closeButton = true;
                        toastr.options.positionClass = "toast-top-right";
                        toastr.error(result.responseText);
                        self.modelIsValid(false);
                    } else {
                        failureCallback(result);
                    }
                })
                .always(function () {
                    if (alwaysCallback == null) {
                        self.isLoading(false);
                    } else {
                        alwaysCallback();
                    }
                });
        };
        self.apiPostAno = function (uri, data, sucessCallback, failureCallback, alwaysCallback, rootPath, contentType, serviceDomain) {
            self.isLoading(true);
            self.modelIsValid(true);
            if (rootPath == undefined) {
                rootPath = application.viewbag.appSettings.eGateAPIUrl;//eGateRoot.rootPath;
            }
            if (serviceDomain === 'UAM') {
                rootPath = application.viewbag.appSettings.uamapiUrl;

            }
            if (serviceDomain === 'CHAT') {
                rootPath = application.viewbag.appSettings.chatAPIUrl;
            }
            if (contentType == undefined) {
                contentType = "application/json; charset=utf-8";
            }

            var token = localStorage.getItem("KPCT-2AccessKey");

            if (token == null && uri != 'Login' && uri != 'api/Account/ForgotPassword' && uri != 'api/Account/ResetPassword'
                && uri != 'api/GetStatuses' && uri != 'api/GetDocumentTypes' && uri != 'api/GetDocumentTypesByPartnerType' && uri != 'api/PartnerRegistration' && uri != 'api/UpdatePartnerRegistration') {
                window.location = application.viewbag.appSettings.sessionExpired;
            }

            $.ajax({
                type: 'Post', url: rootPath + uri, data: data, contentType: contentType, headers: headers,
                dataType: 'json', async: false
            })
                .done(sucessCallback)
                .fail(function (result) {
                    if (failureCallback == null) {
                        if (result.status == 401) { //Token Expires
                            //setTimeout(
                            //function () {
                            //    window.location.href = application.viewbag.appSettings.eGateAPIUrl + 'SessionExpired';
                            //}, 2000);
                        } else if (result.status == 400) {
                            self.modelErrors(JSON.parse(result.responseText));
                        } else {
                            self.modelErrors([result.status + ':' + result.statusText + ':' + result.responseText]);
                        }
                        toastr.options.closeButton = true;
                        toastr.options.positionClass = "toast-top-right";
                        toastr.error(result.responseText);
                        self.modelIsValid(false);
                    } else {
                        failureCallback(result);
                    }
                })
                .always(function () {
                    if (alwaysCallback == null) {
                        self.isLoading(false);
                    } else {
                        alwaysCallback();
                    }
                });
        };

        self.apiUpload = function (uri, data, sucessCallback, failureCallback, alwaysCallback, rootPath, contentType, serviceDomain) {
            self.isLoading(true);
            self.modelIsValid(true);
            if (rootPath == undefined) {
                rootPath = application.viewbag.appSettings.eGateAPIUrl;//eGateRoot.rootPath;
            }
            if (serviceDomain === 'UAM') {
                rootPath = application.viewbag.appSettings.uamapiUrl;
                //alert('UAM rootPath : ' + rootPath);

            }
            if (serviceDomain === 'CHAT') {
                rootPath = application.viewbag.appSettings.chatAPIUrl;
            }
            if (contentType == undefined) {
                contentType = "application/json; charset=utf-8";
            }


            var token = localStorage.getItem("KPCT-2AccessKey");
            if (token == null) {
                window.location = application.viewbag.appSettings.sessionExpired;
            }

            $.ajax({
                type: 'Post', url: rootPath + uri, data: data, cache: false, contentType: false, processData: false, dataType: 'json',
                headers: { 'Authorization': 'Bearer ' + token }
            })
                .done(sucessCallback)
                .fail(function (result) {
                    if (failureCallback == null) {
                        if (result.status == 401) { //Token Expires
                            setTimeout(
                                function () {
                                    RedirectToSessionExpiredPage();
                                }, 2000);
                        } else if (result.status == 400) {
                            self.modelErrors(JSON.parse(result.responseText));
                        } else {
                            self.modelErrors([result.status + ':' + result.statusText + ':' + result.responseText]);
                        }
                        toastr.options.closeButton = true;
                        toastr.options.positionClass = "toast-top-right";
                        toastr.error(result.responseText);
                        self.modelIsValid(false);
                    } else {
                        failureCallback(result);
                    }
                })
                .always(function () {
                    if (alwaysCallback == null) {
                        self.isLoading(false);
                    } else {
                        alwaysCallback();
                    }
                });
        };

        self.apiUploadAno = function (uri, data, sucessCallback, failureCallback, alwaysCallback, rootPath, contentType, serviceDomain) {
            self.isLoading(true);
            self.modelIsValid(true);
            if (rootPath == undefined) {
                rootPath = application.viewbag.appSettings.eGateAPIUrl;//eGateRoot.rootPath;
            }
            if (serviceDomain === 'UAM') {
                rootPath = application.viewbag.appSettings.uamapiUrl;
                //alert('UAM rootPath : ' + rootPath);

            }
            if (serviceDomain === 'CHAT') {
                rootPath = application.viewbag.appSettings.chatAPIUrl;
            }
            if (contentType == undefined) {
                contentType = "application/json; charset=utf-8";
            }


            var token = localStorage.getItem("KPCT-2AccessKey");
            if (token == null && uri != 'Login' && uri != 'api/Account/ForgotPassword' && uri != 'api/Account/ResetPassword'
                && uri != 'api/GetStatuses' && uri != 'api/GetDocumentTypes' && uri != 'api/GetDocumentTypesByPartnerType' && uri != 'api/PartnerRegistration') {
                //    window.location = application.viewbag.appSettings.sessionExpired;
            }

            $.ajax({
                type: 'Post', url: rootPath + uri, data: data, cache: false, contentType: false, processData: false, dataType: 'json'
            })
                .done(sucessCallback)
                .fail(function (result) {
                    if (failureCallback == null) {
                        if (result.status == 401) { //Token Expires

                        } else if (result.status == 400) {
                            self.modelErrors(JSON.parse(result.responseText));
                        } else {
                            self.modelErrors([result.status + ':' + result.statusText + ':' + result.responseText]);
                        }
                        toastr.options.closeButton = true;
                        toastr.options.positionClass = "toast-top-right";
                        toastr.error(result.responseText);
                        self.modelIsValid(false);
                    } else {
                        failureCallback(result);
                    }
                })
                .always(function () {
                    if (alwaysCallback == null) {
                        self.isLoading(false);
                    } else {
                        alwaysCallback();
                    }
                });
        };

        self.apiPut = function (uri, data, sucessCallback, failureCallback, alwaysCallback, rootPath, contentType, serviceDomain) {
            self.isLoading(true);
            self.modelIsValid(true);
            if (rootPath == undefined) {
                rootPath = application.viewbag.appSettings.eGateAPIUrl;//eGateRoot.rootPath;
            }
            if (serviceDomain === 'UAM') {
                rootPath = application.viewbag.appSettings.uamapiUrl;
                //alert('UAM rootPath : ' + rootPath);

            }
            if (serviceDomain === 'CHAT') {
                rootPath = application.viewbag.appSettings.chatAPIUrl;
            }
            if (contentType == undefined) {
                contentType = "application/json; charset=utf-8";
            }

            var token = localStorage.getItem("KPCT-2AccessKey");
            if (token == null) {
                window.location = application.viewbag.appSettings.sessionExpired;
            }

            $.ajax({
                type: 'Put', url: rootPath + uri, data: data, contentType: 'application/json;charset=utf-8', headers: headers,
                dataType: 'json', headers: { 'Authorization': 'Bearer ' + token }
            })
                .done(sucessCallback)
                .fail(function (result) {
                    if (failureCallback == null) {
                        if (result.status == 401) { //Token Expires
                            setTimeout(
                                function () {
                                    RedirectToSessionExpiredPage();
                                }, 2000);
                        } else if (result.status == 400) {
                            self.modelErrors(JSON.parse(result.responseText));
                        } else {
                            self.modelErrors([result.status + ':' + result.statusText + ':' + result.responseText]);
                        }
                        toastr.options.closeButton = true;
                        toastr.options.positionClass = "toast-top-right";
                        toastr.error(result.responseText);
                        self.modelIsValid(false);
                    } else {
                        failureCallback(result);
                    }
                })
                .always(function () {
                    if (alwaysCallback == null) {
                        self.isLoading(false);
                    } else {
                        alwaysCallback();
                    }
                });
        };

        self.apiDelete = function (uri, data, sucessCallback, failureCallback, alwaysCallback, rootPath, serviceDomain) {
            self.isLoading(true);
            self.modelIsValid(true);

            if (rootPath == undefined) {
                rootPath = eGateRoot.rootPath;
            }
            if (serviceDomain === 'UAM') {
                rootPath = application.viewbag.appSettings.uamapiUrl;
                //alert('UAM rootPath : ' + rootPath);

            }
            if (serviceDomain === 'CHAT') {
                rootPath = application.viewbag.appSettings.chatAPIUrl;
            }
            var token = localStorage.getItem("KPCT-2AccessKey");
            if (token == null) {
                window.location = application.viewbag.appSettings.sessionExpired;
            }

            $.ajax({
                type: 'Delete', url: rootPath + uri, data: data, contentType: 'application/json;charset=utf-8', headers: headers,
                dataType: 'json', headers: { 'Authorization': 'Bearer ' + token }
            })
                .done(sucessCallback)
                .fail(function (result) {
                    if (failureCallback == null) {
                        if (result.status == 401) { //Token Expires
                            setTimeout(
                                function () {
                                    RedirectToSessionExpiredPage();
                                }, 2000);
                        } else if (result.status == 400) {
                            self.modelErrors(JSON.parse(result.responseText));
                        } else {
                            self.modelErrors([result.status + ':' + result.statusText + ':' + result.responseText]);
                        }
                        self.modelIsValid(false);
                    } else {
                        failureCallback(result);
                    }
                })
                .always(function () {
                    if (alwaysCallback == null) {
                        self.isLoading(false);
                    } else {
                        alwaysCallback();
                    }
                });
        };

        self.GetServerTime = function () {
            var variable = "expired";
            self.apiGet('api/GetServerTime', null,
                function (result) {
                    if (result != null) {
                        var expTimeInMins = Math.round((new Date(localStorage.accessTokenExpiry * 1000) - kendo.parseDate(result, self.dateFormat.eGateUTCDateFormat()) - 10 * 60000) / 60000);
                        if (expTimeInMins < 2) {
                            $("#mysessionModal .modal-body").html("Your session will expire soon. Please re-login or refresh the screen.");
                            $('#Headerclassadd').addClass('navbar-fixed-top-disableheader');
                            $("#mysessionModal").modal();
                        }
                        else if (expTimeInMins < 30) {
                            $("#mysessionModal .modal-body").html("Your session is about to expire in <b>" + expTimeInMins + "</b> min(s). Please re-login or refresh the screen.");
                            $('#Headerclassadd').addClass('navbar-fixed-top-disableheader');
                            $("#mysessionModal").modal();
                        } else {
                            variable = "success";
                        }
                    }
                });
            return variable;
        };

        self.GetServerTimeforSave = function () {
            var variable = "expired";
            self.apiGet('api/GetServerTime', null,
                function (result) {
                    var expTimeInMins = Math.round((new Date(localStorage.accessTokenExpiry * 1000) - kendo.parseDate(result, self.dateFormat.eGateUTCDateFormat())) / 60000);
                    if (expTimeInMins < 0) {
                        $("#mysessionModal .modal-body").html("Your session is expired. Please re-login or refresh the screen");
                        $('#Headerclassadd').addClass('navbar-fixed-top-disableheader');
                        $("#mysessionModal").modal();
                    } else if (expTimeInMins < 2) {
                        $("#mysessionModal .modal-body").html("Your session will expire soon. Please re-login or refresh the screen.");
                        $('#Headerclassadd').addClass('navbar-fixed-top-disableheader');
                        $("#mysessionModal").modal();
                    }
                    else if (expTimeInMins < 10) {
                        $("#mysessionModal .modal-body").html("Your session is about to expire in <b>" + expTimeInMins + "</b> min(s).For executing this process please re-login or refresh the screen.");
                        $('#Headerclassadd').addClass('navbar-fixed-top-disableheader');
                        $("#mysessionModal").modal();
                    } else {
                        variable = "success";
                    }
                }, null, null, false);

            return variable;
        };

        self.pushUrlState = function (code, title, id, url) {
            self.stateInfo = { State: { Code: code, Id: id }, Title: title, Url: eGateRoot.rootPath + url };
        }

        self.handleUrlState = function (initialState) {
            if (!self.statePopped) {
                if (initialState != '') {
                    history.replaceState(self.stateInfo.State, self.stateInfo.Title, self.stateInfo.Url);

                    // we're past the initial nav state so from here on everything should push
                    initialState = '';
                } else {
                    history.pushState(self.stateInfo.State, self.stateInfo.Title, self.stateInfo.Url);
                }
            } else
                self.statePopped = false; // only actual popping of state should set this to true

            return initialState;
        }

        self.ValidateAlphaNumericWithHyphenChange = function (data) {
            if (!/^[a-z0-9]+[a-z0-9-]+[a-z0-9]+$/i.test(data)) {
                return false;
            }
            return true;
        }
        self.ValidateAlphaNumericChange = function (data) {
            if (! /^[a-zA-Z0-9\b]+$/i.test(data)) {
                return false;
            }
            return true;
        }
        self.ValidateNumericChange = function (data) {
            if (!/[0-9.\b]+$/i.test(data)) {
                return false;
            }
            return true;
        }
        self.ValidateAlphabetsWithSpacesChange = function (data) {
            if (!/^[a-zA-Z \b]*$/i.test(data)) {
                return false;
            }
            return true;
        }
        self.ValidateAlphaNumericsWithSpacesChange = function (data) {
            if (!/^[a-zA-Z0-9 \b]*$/i.test(data)) {
                return false;
            }
            return true;
        }
        self.ValidateAlphanumericEmailChange = function (data) {
            if (!/^[a-zA-Z0-9\b*.@_-]/i.test(data)) {
                return false;
            }
            return true;
        }
    }
    CutPaste();
    cr.ViewModelHelper = viewModelHelper;
}(window.eGateRoot));

//#region Date Formats
(function (cr) {
    var dateFormat = function () {
        var self = this;

        self.eGateDateFormat = ko.observable('dd-MM-yyyy');
        self.eGateDateTimeFormat = ko.observable('dd-MM-yyyy HH:mm');
        self.eGateDateFormatForModel = ko.observable('DD-MM-YYYY');
        self.eGateDateTimeFormatForModel = ko.observable('DD-MM-YYYY HH:mm');
        self.eGateDateFormat_yyyyMMddHHmm = ko.observable('yyyy-MM-dd HH:mm');
        self.eGateDateFormat_yyyyMMddHHmmss = ko.observable('yyyy-MM-ddTHH:mm:ss');
        self.eGateDateFormat_MMddyyyy = ko.observable('MM-dd-yyyy');
        self.eGateUTCDateFormat = ko.observable('yyyy-MM-ddTHH:mm:ss.fffffffzz');
    }
    CutPaste();
    cr.DateFormat = dateFormat;
}(window.eGateRoot));
//#endregion Date Formats

//#region Advanced Search
(function (cr) {
    var advanceSearch = function () {
        var self = this;
        self.SearchAll = ko.observable('All');
    }
    cr.AdvanceSearch = advanceSearch;
}(window.eGateRoot));
//#endregion Advanced Search
//#region Advanced Search
(function (cr) {
    var endOfDay = function (date) {
        var self = this;
        var deliveryexpiryDate = kendo.parseDate(date, 'dd-MM-yyyy HH:mm');
        deliveryexpiryDate.setHours(23, 59, 0, 0);
        self.endofDate = deliveryexpiryDate;
        return self.endofDate;
    }
    cr.endOfDay = endOfDay;
}(window.eGateRoot));
//#endregion Advanced Search

//#region Boolean Character
(function (cr) {
    var booleanCharacter = function () {
        var self = this;
        self.Yes = ko.observable('Y');
        self.No = ko.observable('N');
        self.True = ko.observable(true);
        self.False = ko.observable(false);
    }
    cr.BooleanCharacter = booleanCharacter;
}(window.eGateRoot));
//#endregion Boolean Character

//#region Toaster
(function (cr) {
    var toasterStaicValue = function () {
        var self = this;
        self.Toast_Top_Right = ko.observable('toast-top-right');
    }
    cr.ToasterStaticValue = toasterStaicValue;
}(window.eGateRoot));
//#endregion Toaster

//#region unique 6 character key
(function (cr) {
    var generateQRCodeValue = function () {
        var self = this;
        self.generatecode = function () {
            //var d = new Date().valueOf();
            //var n = d.toString();
            var result = '';
            var length = 6;
            //var p = 0;
            var chars = '0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ';  //'0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';

            for (var i = length; i > 0; --i) {
                // result += ((i & 1) && n.charAt(p) ? n.charAt(p) : chars[Math.floor(Math.random() * chars.length)]);
                result += (chars[Math.floor(Math.random() * chars.length)]);
                //if (i & 1) p++;
            };
            return result;
        }
    }

    cr.GenerateQRCodeValue = generateQRCodeValue;
}(window.eGateRoot));
//#endregion unique 6 character key

// Validation Helper
(function (cr) {
    CutPaste();
    var validationHelper = function () {
        var self = this;
        var keynum;
        var keychar;
        var charcheck;

        // Alphanumeric
        self.ValidateAlphaNumeric = function (data, event) {
            CutPaste();
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            charcheck = /^[a-zA-Z0-9\b]/;
            return charcheck.test(keychar);
        }

        // Alphanumeric with paste
        self.ValidateAlphaNumericWithPaste = function (data, event) {
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            charcheck = /^[a-zA-Z0-9\b]/;
            return charcheck.test(keychar);
        }

        self.ValidateAlphaNumericWithStarChracter = function (data, event) {
            CutPaste();
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            charcheck = /^[a-zA-Z0-9\b*]/;
            return charcheck.test(keychar);
        }

        self.ValidateAlphaNumericWithHypenChracter = function (data, event) {
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            charcheck = /^[a-zA-Z0-9\b-]/;   ///^[a-zA-Z '.-]+$/;
            return charcheck.test(keychar);
        }

        // Numeric 
        self.ValidateNumeric = function (data, event) {
            CutPaste();
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            //charcheck = /[0-9]/;
            charcheck = /[0-9.\b]/;
            return charcheck.test(keychar);
        }
        // Numeric 
        self.ValidateNumericWithPaste = function (data, event) {
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            //charcheck = /[0-9]/;
            charcheck = /[0-9.\b]/;
            return charcheck.test(keychar);
        }

        self.ValidateAlphanumericEmail = function (data, event) {
            CutPaste();
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            charcheck = /^[a-zA-Z0-9\b*.@_-]/;
            return ((keychar.match(charcheck) == null) ? false : true);

        }
        // Numeric 
        self.ValidateNumericOnly = function (data, event) {
            CutPaste();
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            //charcheck = /[0-9]/;
            charcheck = /[0-9\b]/;
            return charcheck.test(keychar);
        }

        // Alphanumeric_keypressEvent
        self.ValidateAlphaNumeric_keypressEvent = function (data, event) {
            CutPaste();
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            charcheck = /^[a-zA-Z0-9\b]/;
            return ((keychar.match(charcheck) == null) ? false : true);
        }


        self.ValidateAlphaNumeric_keypressEventWithOutCutPaste = function (data, event) {

            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            charcheck = /^[a-zA-Z0-9\b]/;
            return ((keychar.match(charcheck) == null) ? false : true);
        }

        // Alphanumeric_keypressEvent
        self.ValidateAlphaNumericWithSpaces_keypressEvent = function (data, event) {
            CutPaste();
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            charcheck = /^[a-zA-Z0-9\b ]/;
            return ((keychar.match(charcheck) == null) ? false : true);
        }

        self.ValidateNumericTime_keypressEvent = function (data, event) {
            CutPaste();
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            charcheck = /[0-9\b:]/g;
            // var result = keychar.match(charcheck)
            return ((keychar.match(charcheck) == null) ? false : true);
        }

        // Numeric
        //Reason : Added on key press event to check valid or not
        self.ValidateNumeric_keypressEvent = function (data, event) {
            CutPaste();
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            charcheck = /[0-9\b]/g;
            // var result = keychar.match(charcheck)
            return ((keychar.match(charcheck) == null) ? false : true);
        }
        //Reason : Added on key press event to check valid or not
        self.ValidateNumeric_keypressEventWithPaste = function (data, event) {
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            charcheck = /[0-9\b]/g;
            // var result = keychar.match(charcheck)
            return ((keychar.match(charcheck) == null) ? false : true);
        }
        //Reason : Added on key press event to check valid or not
        // Accept only Alphabets and spaces
        self.ValidateAlphabetsWithSpaces_keypressEvent = function (data, event) {
            CutPaste();
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            charcheck = /^[a-zA-Z\b ]*$/;
            return ((keychar.match(charcheck) == null) ? false : true);
        }

        //Reason : Added on key press event to check valid or not
        // Accept only Alphabets and spaces
        self.ValidateAlphabetsWithSpacesAndSpecialChars_keypressEvent = function (data, event) {
            CutPaste();
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            charcheck = /^[A-Za-z \b_@./#&$*()+-]*$/;
            return ((keychar.match(charcheck) == null) ? false : true);
        }

        //Reason : Added on key down event to prevent backspace
        // Prevent Backspace Button in text field
        self.PreventBackspaces_keydownEvent = function (event) {
            CutPaste();
            var evt = event || window.event;
            if (evt) {
                var keyCode = evt.charCode || evt.keyCode;
                if (keyCode === 8 || keyCode === 46) {
                    if (evt.preventDefault) {
                        evt.preventDefault();
                    } else {
                        evt.returnValue = false;
                    }
                }
            }
        }

        self.ValidateAlphabetsWithOutSpaces = function (data, event) {
            CutPaste();
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            charcheck = /^[a-zA-Z\b]*$/;
            // var result = keychar.match(charcheck)
            return ((keychar.match(charcheck) == null) ? false : true);
        }

        // Accept only Alphabets and spaces
        self.ValidateAlphabetsWithSpaces = function (data, event) {
            CutPaste();
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            charcheck = /^[a-zA-Z \b]*$/;
            return charcheck.test(keychar);
        }

        // Accept only Alphabets and spaces
        self.ValidateAlphabetsWithSpacesandPaste = function (data, event) {
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            charcheck = /^[a-zA-Z \b]*$/;
            return charcheck.test(keychar);
        }

        // Accept only AlphaNumaeric and spaces
        self.ValidateAlphaNumericWithSpaces = function (data, event) {
            CutPaste();
            if (window.event) // IE
                keynum = event.keyCode;
            else if (event.which) // Netscape/Firefox/Opera
                keynum = event.which;
            if (event.which == 0)
                return true;
            keychar = String.fromCharCode(keynum);
            charcheck = /^[a-zA-Z0-9 \b]*$/;
            return charcheck.test(keychar);
        }
        // AlphaNumeric values sorting
        self.AlphanumericStringSort = function (as, bs) {
            var a, b, a1, b1, i = 0, l, rx = /(\d+)|(\D+)/g, rd = /\d/;
            if (isFinite(as) && isFinite(bs)) return as - bs;
            a = String(as).toLowerCase();
            b = String(bs).toLowerCase();
            if (a === b) return 0;
            if (!(rd.test(a) && rd.test(b))) return a > b ? 1 : -1;
            a = a.match(rx);
            b = b.match(rx);
            l = a.length > b.length ? b.length : a.length;
            while (i < l) {
                a1 = a[i];
                b1 = b[i++];
                if (a1 !== b1) {
                    if (isFinite(a1) && isFinite(b1)) {
                        if (a1.charAt(0) === '0') a1 = '.' + a1;
                        if (b1.charAt(0) === '0') b1 = '.' + b1;
                        return a1 - b1;
                    }
                    else return a1 > b1 ? 1 : -1;
                }
            }
            return a.length - b.length;
        }

        // Five positive digit with two digit after decimal  
        self.allowOnlyfivePositiveDigtsonly = function (el, evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            var number = evt.target.value.split('.');
            if (charCode != 8) {
                if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
                    return false;
                }
                //just one dot
                if (number.length > 1 && charCode == 46) {
                    return false;
                }
                //get the carat position
                var caratPos = getSelectionStart(el);
                var dotPos = evt.target.value.indexOf('.');
                if (caratPos > dotPos && dotPos > -1 && (number[1].length > 1)) {
                    return false;
                }
                if (dotPos == -1 && charCode != 46 && evt.target.value.length > 4) {
                    return false;
                }
            }
            return true;
        }

        //Reason : Added on key down event to prevent dop
        // Prevent prevent drop into text box
        self.PreventDrop = function (event) {
            event.preventDefault();
        }
    }
    cr.ValidationHelper = validationHelper;

}(window.eGateRoot));

function CutPaste() {
    //var controls = $(".form-control");
    //controls.bind("paste", function () {
    //    return false;
    //});
    //controls.bind("drop", function () {
    //    return false;
    //});
    //controls.bind("cut", function () {
    //    return false;
    //});
    //controls.bind("copy", function () {
    //    return false;
    //});
}

// Restrict Container Number with a Pattern given 
function validateContainerNumberTest(data, event) {
    var regexchar = new RegExp("[a-zA-Z]{4}");

    CutPaste();
    if (window.event) // IE
        keynum = event.keyCode;
    else if (event.which) // Netscape/Firefox/Opera
        keynum = event.which;
    if (event.which === 0)
        return true;
    var check = true;

    var substr = event.target.value.substring(0, 4);

    if (keynum !== 8) {
        if (parseInt(getSelectionStart(data)) < 4 && !regexchar.test(substr)) {
            if ((event.which > 96 && event.which < 123) || (event.which > 64 && event.which < 91)) {
                return true;
            }
            else {
                check = false;
            }
        }
        else if (parseInt(getSelectionStart(data)) > 3) {
            if ((event.which > 47 && event.which < 58)) {
                return true;
            } else {
                check = false;
            }
        } else {

            check = false;
        }
    }
    return check;
}
function validateContainerNumberTestWithPaste(data, event) {
    var regexchar = new RegExp("[a-zA-Z]{4}");
    // CutPaste();
    if (window.event) // IE
        keynum = event.keyCode;
    else if (event.which) // Netscape/Firefox/Opera
        keynum = event.which;
    if (event.which === 0)
        return true;
    var check = true;
    var substr = event.target.value.substring(0, 4);
    if (keynum !== 8) {
        if (parseInt(getSelectionStart(data)) < 4 && !regexchar.test(substr)) {
            if ((event.which > 96 && event.which < 123) || (event.which > 64 && event.which < 91)) {
                return true;
            }
            else {
                check = false;
            }
        }
        else if (parseInt(getSelectionStart(data)) > 3) {
            if ((event.which > 47 && event.which < 58)) {
                return true;
            } else {
                check = false;
            }
        } else {
            check = false;
        }
    }
    return check;
}
(function (eGateRoot) {
    CutPaste();
}(window.eGateRoot));

ko.bindingHandlers.datepicker = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        //initialize datepicker with some optional options
        var options = allBindingsAccessor().datepickerOptions || {};
        $(element).datepicker(options);

        //handle the field changing
        ko.utils.registerEventHandler(element, "change", function () {
            var observable = valueAccessor();
            var newDate = $(element).datepicker("getDate");
            // newDate format is 2013-01-11T06:11:00.000Z
            observable(moment(newDate).format('MM/DD/YYYY'));
        });

        //handle disposal (if KO removes by the template binding)
        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).datepicker("destroy");
        });

    },
    // get the value from the viewmodel and format it for display
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        var date = moment(value);
        current = $(element).datepicker("getDate");

        if (value != null) {
            if (value - current !== 0) {
                var date = moment(value);
                $(element).val(date.format("L"));
            }
        }
    }
}
ko.bindingHandlers.progressBar = {
    init: function (element) {
        return { controlsDescendantBindings: true };
    },
    update: function (element, valueAccessor, bindingContext) {
        var options = ko.unwrap(valueAccessor());

        var value = options.value();

        var width = value + "%";

        $(element).addClass("progressBar");

        ko.applyBindingsToNode(element, {
            html: '<div data-bind="style: { width: \'' + width + '\' }"></div><div class="progressText" data-bind="text: \'' + value + ' %\'"></div>'
        });

        ko.applyBindingsToDescendants(bindingContext, element);
    }
}
ko.bindingHandlers.loadingWhen = {
    // any ViewModel using this extension needs a property called isLoading
    // the div tag to contain the loaded content uses a data-bind="loadingWhen: isLoading"
    init: function (element) {
        var
            $element = $(element),
            currentPosition = $element.css("position");
        $loader = $("<div>").addClass("loading-loader").hide();

        //add the loader
        $element.append($loader);

        //make sure that we can absolutely position the loader against the original element
        if (currentPosition == "auto" || currentPosition == "static")
            $element.css("position", "static");

        //center the loader
        $loader.css({
            position: "absolute",
            top: "50%",
            left: "50%",
            "margin-left": -($loader.width() / 2) + "px",
            "margin-top": -($loader.height() / 2) + "px"
        });
    },
    update: function (element, valueAccessor) {
        var isLoading = ko.utils.unwrapObservable(valueAccessor()),
            $element = $(element),
            $childrenToHide = $element.children(":not(div.loading-loader)"),
            $loader = $element.find("div.loading-loader");
        isLoading = false; //This variable is assigned false value in order to avoid two loaders on screen 
        if (isLoading) {
            $childrenToHide.css("visibility", "hidden").attr("disabled", "disabled");
            $loader.show();
        } else {
            $loader.fadeOut("fast");
            $childrenToHide.css("visibility", "visible").removeAttr("disabled");
        }
    }
};

ko.extenders.numeric = function (target, precision) {
    //create a writeable computed observable to intercept writes to our observable
    var result = ko.computed({
        read: target,  //always return the original observables value
        write: function (newValue) {
            var current = target(),
                roundingMultiplier = Math.pow(10, precision),
                newValueAsNum = isNaN(newValue) ? 0 : parseFloat(+newValue),
                valueToWrite = Math.round(newValueAsNum * roundingMultiplier) / roundingMultiplier;

            //only write if it changed
            if (valueToWrite !== current) {
                target(valueToWrite);
            } else {
                //if the rounded value is the same, but a different value was written, force a notification for the current field
                if (newValue !== current) {
                    target.notifySubscribers(valueToWrite);
                }
            }
        }
    });

    //initialize with current value to make sure it is rounded appropriately
    result(target());

    //return the new computed observable
    return result;
};

ko.bindingHandlers.date = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        // TODO: this should be able to support foreign date formats
        var jsonDate = valueAccessor(); // 2013-02-19T00:00:00
        var ret = $.datepicker.formatDate('mm-dd-yy', new Date(jsonDate()));
        element.innerHTML = ret;
    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
    }
};

ko.bindingHandlers.enterkey = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var inputSelector = 'input,textarea,select,checkbox,form';
        $(document).on('keypress', inputSelector, function (e) {
            var allBindings = allBindingsAccessor();
            //  $(element).on('keypress', 'input, textarea, select', function (e) {
            var keyCode = e.which || e.keyCode;
            if (keyCode !== 13) {
                return true;
            }

            var target = e.target;
            target.blur();

            allBindings.enterkey.call(viewModel, viewModel, target, element);

            return false;
            // });
        });
    }
};

//thanks: http://javascript.nwbox.com/cursor_position/
function getSelectionStart(o) {
    if (o.createTextRange) {
        var r = o.createTextRange().duplicate();
        r.moveEnd('character', o.value.length);
        return o.value.length;
    } else return o.selectionStart;
}

function RedirectToSessionExpiredPage() {
    window.location.href = window.location.origin + application.viewbag.appSettings.sessionExpired;
}

function closeSessionPopup() {
    $('#Headerclassadd').removeClass('navbar-fixed-top-disableheader');
}
