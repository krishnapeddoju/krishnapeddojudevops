(function (eGateRoot) {
    var UserViewModel = function () {
        var self = this;
        var tokenKey = 'accessToken';
        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.validationHelper = new eGateRoot.ValidationHelper();
        self.accountModel = ko.observable(new eGateRoot.UserModel());
        self.forgotPasswordModel = ko.observable(new eGateRoot.ForgotPasswordModel());
        self.LinkVisible = ko.observable(false);

        self.Initialize = function () {
            self.accountModel().AppId(clientId.split("-")[1]);
            if (self.accountModel().AppId() === '2') {
                self.LinkVisible(true);
            }

            
        }

        function showError(jqXHR) {
            console.log(jqXHR.status + ': ' + jqXHR.statusText);
        }

        ResetUserPwd = function (model) {
            self.CPValidation = ko.observable(model);
            self.CPValidation().errors = ko.validation.group(self.CPValidation());
            var errors = self.CPValidation().errors().length;
            if (errors === 0 && (model.userName() !== null && model.userName() !== "" && model.userName() !== undefined)) {
                model.ApplicationId(clientId.split("-")[1]);
                model.SubscriberId(clientId.split("-")[0]);
                self.viewModelHelper.apiPost('api/Account/ResetPassword', ko.mapping.toJSON(model),
                      function responseResetUserPwd(data) {
                          if (data === "Success") {
                              toastr.options.closeButton = true;
                              toastr.options.positionClass = "toast-top-right";
                              toastr.success("Success! Check email/SMS for New Password.", "Forgot Password");
                              setTimeout(function () {
                                  window.location = window.location.origin;
                              }, 2000);
                              

                          }
                          else {
                              toastr.options.closeButton = true;
                              toastr.options.positionClass = "toast-top-right";
                              toastr.error("Invalid Login Credentials");
                              setTimeout(function () {
                              }, 2000);
                          }
                      }, null, false, application.viewbag.appSettings.uamapiUrl, null, 'UAM');
            }
            else {
                $('#txtusername1').val('');;
                $('#txtusername1').focus();
                toastr.error("Invalid Login Credentials");
                self.CPValidation().errors.showAllMessages();
            }
        }

        Back = function (model) {

            $('#txtusername1').val("");
            $('#txtusername1').focus();

        }


        checkLogindet = function (model) {
            $('#loader').show();
            $('.form-wizard').css('opacity', '0.3');
            $('#chkRemember').attr('disabled', true);
            $('#btnLogin').attr('disabled', true);

            var displayMode = (jQuery.browser = jQuery.browser || {}).mobile = /(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test() || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test()
            var isMobile = {
                Android: function () { return navigator.userAgent.match(/Android/i); },
                BlackBerry: function () { return navigator.userAgent.match(/BlackBerry/i); },
                iOS: function () { return navigator.userAgent.match(/iPhone|iPad|iPod/i); },
                Opera: function () { return navigator.userAgent.match(/Opera Mini/i); },
                Windows: function () { return navigator.userAgent.match(/IEMobile/i); },
                any: function () { return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Opera() || isMobile.Windows()); }
            };
            self.CPValidation = ko.observable(model);
            self.CPValidation().errors = ko.validation.group(self.CPValidation());
            var errors = self.CPValidation().errors().length;
            if (model.userName() != null && model.userName() != null && model.userName() != undefined) {
                model.userName(model.userName().trim());
            }
            if (errors === 0) {
                self.viewModelHelper.apiPost('Login', ko.mapping.toJSON(model),
                                function responseCheckLoginDetail(data) {

                                    if (data.success == false) {
                                        toastr.options.closeButton = true;
                                        toastr.options.positionClass = "toast-top-right";
                                        toastr.error(data.message);
                                        $('#loader').hide();
                                        $('.form-wizard').css('opacity', '1');
                                        $('#btnLogin').attr('disabled', false);
                                        $('#chkRemember').attr('disabled', false);
                                    } else {
                                        localStorage.setItem("KPCT-2AccessKey", data.token);
                                        if (data.IsFirstTimeLogin === "Y") {
                                            window.location.href = "../../Account/ChangePassword/" + data.IsFirstTimeLogin;
                                        } else {
                                            if (model.ReturnUrl() !== "" && model.ReturnUrl().length > 1) {
                                                window.location.href = "/" + model.ReturnUrl().substring(1);
                                            } else {
                                                window.location.href = "/Home";
                                            }
                                        }
                                    }
                                }
                                ,
                               function failure(result) {
                                   $('#loader').hide();
                                   $('.form-wizard').css('opacity', '1');
                                   $('#btnLogin').attr('disabled', false);
                                   $('#chkRemember').attr('disabled', false);
                                   toastr.options.closeButton = true;
                                   toastr.options.positionClass = "toast-top-right";
                                   model.RememberMe(false);
                                   toastr.error(result.responseText);
                               });
            }
            else {
                $('#txtusername').focus();
                if (self.CPValidation().userName() !== "" && self.CPValidation().password() === "")
                    $('#txtpwd').focus();
                $('#loader').hide();
                $('.form-wizard').css('opacity', '1');
                $('#btnLogin').attr('disabled', false);
                $('#chkRemember').attr('disabled', false);
                self.CPValidation().errors.showAllMessages();
            }
        }

        self.Initialize();

    }
    eGateRoot.UserViewModel = UserViewModel;
}(window.eGateRoot));



function onclickDropDown() {
    var a = $("#profileDropDown").attr('class');
    if (a == "dropdown open") {

        $('#profileDropDown').removeClass('open');
    }
    else {

        $('#profileDropDown').addClass('open');
    }




}