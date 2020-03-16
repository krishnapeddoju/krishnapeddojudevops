//Kendo Upload Functions
function SelectFile(e) {
    var errors = 0;
    var fileExtension = ['.pdf', '.jpg', '.jpeg','.bmp','.gif','.png','.csv' , '.docx', '.doc', '.xlsx', '.xls'];
    if ($.inArray(e.files[0].extension.toLowerCase(), fileExtension) === -1) {
        toastr.warning('Please Upload a file with extension ' + fileExtension + '.', 'File Upload');
        errors++;
        e.preventDefault();
    }

    if (errors === 0 && (e.files[0].size / (1024 * 1024)) > 2) {
        toastr.warning('File size should not be more than 2MB.', 'File Upload');
        e.preventDefault();
    }
}

function UploadFile(data, e) {
    $.each(data, function (i, val) {
        if (e.files[0].name === val.OriginalName()) {
            toastr.warning("Same file should not be uploaded twice");
            e.preventDefault();
        }
    });
}

function DeleteFile(filepath, fileName) {
    var val = 0;
    if (filepath === null) {
        filepath = '';
    }
    var self = this;
    self.viewModelHelper = new eGateRoot.ViewModelHelper();
    self.viewModelHelper.apiPut('api/FileUpload/DeleteFile/' + filepath + fileName,
        null,
        function (result) {
            val = 1;
        }, null, null, false);
    if (val === 1)
        return true;
    return false;
}

function isEmpty(val) {
    return (val === undefined || val == null || val.length <= 0) ? true : false;
}

function htmlDecode(value) {
    return $("<textarea/>").html(value).text();
}

function destroyKendoMaskedControl(id) {
    $("#"+id).data("kendoMaskedMobile").destroy();
    $("#"+id).data("kendoMaskedTextBox").destroy();
}

function PrintForm(data) {
    data = isEmpty(data) ? "e-Xpressway" : data;
    document.title = data;
    window.print();
    document.title = "Cargo";
}
function endOfDay(date) {
    var self = this;
    var deliveryexpiryDate = kendo.parseDate(date, 'dd-MM-yyyy HH:mm');
    if (!isEmpty(deliveryexpiryDate)) {
        deliveryexpiryDate.setHours(23, 59, 0, 0);
    }
    self.endofDate = deliveryexpiryDate;
    return self.endofDate;
}
//End of Kendo Upload related Functions


function ValidateVehicleNumber(id, isToastrRequired) {
    var vehicleVal = $('#' + id).val();
    var reg = /[^A-Za-z0-9 ]/;
    if (!isEmpty(vehicleVal) && (vehicleVal.replace(/ /g, "").length > 10 || reg.test(vehicleVal))) {
        $('#' + id).val('');
        if (isToastrRequired)
            toastr.warning("Invalid Vehicle No.");
        return false;
    } else if (!isEmpty(vehicleVal) && vehicleVal.trim().indexOf(' ') >= 0) {
        $('#' + id).val(vehicleVal.replace(/ /g, ""));
    }

}

function ValidateDriverName(id, isToastrRequired) {
    var driverVal = $('#' + id).val();
    var reg = /[^A-Za-z ]/;
    if (!isEmpty(driverVal) && reg.test(driverVal)) {
        $('#' + id).val('');
        if (isToastrRequired)
            toastr.warning("Invalid Driver Name");
        return false;
    } else if (!isEmpty(driverVal)) {
        $('#' + id).val(driverVal.trim());
    }

}

function ValidateLicenseNumber(id,isToastrRequired) {
    var licenseVal = $('#' + id).val();
    var reg = /[^A-Za-z0-9 ]/;
    if (!isEmpty(licenseVal) && reg.test(licenseVal)) {
        $('#' + id).val('');
        if (isToastrRequired)
            toastr.warning("Invalid License No.");
        return false;
    } else if (!isEmpty(licenseVal) && licenseVal.trim().indexOf(' ') >= 0) {
        $('#' + id).val(licenseVal.replace(/ /g, ""));
    }

}

function SetFocus(id) {
    $("#"+id).bind("focus", function () {
        if (this.createTextRange) {
            var part = this.createTextRange();
            part.move("character", 0);
            part.select();
        } else if (this.setSelectionRange) {
            var maskedinput = this;
            setTimeout(function () {
                maskedinput.setSelectionRange(0, 0);
            }, 0);
        }
    });
}



//maskedDatePicker.js
(function ($) {
    var kendo = window.kendo,
        ui = kendo.ui,
        Widget = ui.Widget,
        proxy = $.proxy,
        CHANGE = "change",
        BLUR = "blur",
        PROGRESS = "progress",
        ERROR = "error",
        nss = ".kendoMaskedTextBox",
        NS = ".generalInfo";

    var MaskedDatePicker = Widget.extend({
        init: function (element, options) {
            var that = this;
            //alert();
            Widget.fn.init.call(this, element, options);

            $(element).kendoMaskedTextBox({ mask: that.options.dateOptions.mask })
            .kendoDatePicker({
                format: that.options.dateOptions.format,
                parseFormats: that.options.dateOptions.parseFormats
            })
            .closest(".k-datepicker")
            .add(element)
                .on("blur" + nss, function () {
                    var value = element.value;

                    //console.log(value);
                    if (!value) {
                        //caret(element, 0);
                        //  element.value = that._emptyMask;
                    } else {
                        //that._togglePrompt(true);
                        if (kendo.parseDate(value, that.options.dateOptions.format) === null) {
                            //element.value = '';
                            //value = '';
                            toastr.options = {
                                "closeButton": true,
                                "newestOnTop": true,
                                "positionClass": "toast-top-right",
                                "prevent-any-duplicates": false,
                                "showMethod": "fadeIn",
                                "hideMethod": "fadeOut"
                            }
                            //toastr.clear();
                            toastr.warning("Invalid date", "");
                        }

                    }
                    that._oldValue = value;
                    that._timeoutId = setTimeout(function () {
                        //  caret(element, 0, value ? that._maskLength : 0);
                        // alert('focus');
                        if (value != '' && kendo.parseDate(value, that.options.dateOptions.format) === null) {
                            setTimeout(
                            function () {
                                element.focus();
                            }, 50);

                        }
                    });
                })
                .on("focus" + nss, function () {
                    var value = element.value;
                    if (value == "__-__-____") {
                        setTimeout((function (element) {
                            var strLength = element.value.length;
                            return function () {
                                if (element.setSelectionRange !== undefined) {
                                    element.setSelectionRange(strLength, 0);
                                } else {
                                    $(element).val(element.value);
                                }
                            }
                        }(this)), 0);
                    }
                })
          
                .removeClass("k-textbox");

            that.element.data("kendoDatePicker").bind("change", function () {
                that.trigger(CHANGE);
            });
        },
        options: {
            name: "MaskedDatePicker",
            dateOptions: {
                mask: "00-00-0000",
                format: "dd-MM-yyyy",
                parseFormats: ["yyyy-MM-dd"]
            }
        },
        events: [
          CHANGE
        ],
        destroy: function () {
            var that = this;
            Widget.fn.destroy.call(that);
            kendo.destroy(that.element);
        },
        value: function (value) {
            var datepicker = this.element.data("kendoDatePicker");

            if (value === undefined) {
                return datepicker.value();
            }

            datepicker.value(value);
        }
    });

    var MaskedDateTimePicker = Widget.extend({

        init: function (element, options) {
          
            var that = this;
            //alert();
            Widget.fn.init.call(this, element, options);

            $(element).kendoMaskedTextBox({ mask: that.options.dateOptions.mask })
            .kendoDateTimePicker({
                format: that.options.dateOptions.format,
                parseFormats: that.options.dateOptions.parseFormats,
                timeFormat: that.options.dateOptions.timeFormat
            })
            .closest(".k-datetimepicker")
            .add(element)
                .on("blur" + nss, function () {
                    var value = element.value;

                    //console.log(value);
                    if (!value) {
                        //caret(element, 0);
                        //  element.value = that._emptyMask;
                    } else {
                        //that._togglePrompt(true);
                        if (kendo.parseDate(value, that.options.dateOptions.format) === null) {
                            //element.value = '';
                            //value = '';
                            toastr.options = {
                                "closeButton": true,
                                "newestOnTop": true,
                                "positionClass": "toast-top-right",
                                "prevent-any-duplicates": false,
                                "showMethod": "fadeIn",
                                "hideMethod": "fadeOut"
                            }
                            //toastr.clear();
                            toastr.warning("Invalid date", "");
                        }

                    }
                    that._oldValue = value;
                    that._timeoutId = setTimeout(function () {
                        //  caret(element, 0, value ? that._maskLength : 0);
                        // alert('focus');
                        if (value != '' && kendo.parseDate(value, that.options.dateOptions.format) === null) {
                            setTimeout(
                            function () {
                                element.focus();
                            }, 50);

                        }
                    });
                })
                   .on("focus" + nss, function () {
                       var value = element.value;
                       if (value == "__-__-____ __:__") {
                           setTimeout((function (element) {
                               var strLength = element.value.length;
                               return function () {
                                   if (element.setSelectionRange !== undefined) {
                                       element.setSelectionRange(strLength, 0);
                                   } else {
                                       $(element).val(element.value);
                                   }
                               }
                           }(this)), 0);
                       }
                   })

            .removeClass("k-textbox");

            //that.element.data("kendoDateTimePicker").bind("change", function () {
            //    that.trigger(CHANGE);
            //});
        },
        options: {
            name: "MaskedDateTimePicker",
            dateOptions: {
                mask: "00-00-0000 00:00",
                format: "dd-MM-yyyy HH:mm",
                parseFormats: ["yyyy-MM-dd HH:mm", "yyyy-MM-ddTHH:mm"], timeFormat: "HH:mm"
            }
        },
        events: [CHANGE],
        destroy: function () {
            var that = this;
            Widget.fn.destroy.call(that);

            kendo.destroy(that.element);
        },
        value: function (value) {
            var datepicker = this.element.data("kendoDateTimePicker");

            if (value === undefined) {
                return datepicker.value();
            }
            datepicker.value(value);
        }
    });

    var MaskedPhoneNumber = Widget.extend({
        init: function (element, options) {
            var that = this;
            //alert();
            Widget.fn.init.call(this, element, options);
            $(element).kendoMaskedTextBox({ mask: that.options.mask });
            that.element.data("kendoMaskedTextBox").bind("change", function () {
                that.trigger(CHANGE);
            });
        },
        events: [CHANGE],
        options: {
            name: "MaskedPhoneNumber",
            mask: "(999) 999-9999"
        },
        destroy: function () {
            var that = this;
            Widget.fn.destroy.call(that);
            kendo.destroy(that.element);
        },
        value: function (value) {
            var datepicker = this.element.data("kendoMaskedTextBox");

            if (value === undefined) {
                return datepicker.value();
            }
            datepicker.value(value);
        }
    });

    ui.plugin(MaskedDatePicker);
    ui.plugin(MaskedDateTimePicker);
    ui.plugin(MaskedPhoneNumber);
})(window.kendo.jQuery);

//ko.bindingHandlers.kendoDateTimePicker.options = {
//    parseFormats: ['yyyy-MM-dd HH:mm', 'yyyy-MM-ddTHH:mm'],
//    format: 'dd-MM-yyyy HH:mm',
//    month: { empty: '<span class="k-state-disabled">#= data.value #</span>' }
//}
//ko.bindingHandlers.kendoDatePicker.options = {
//        parseFormats: ['yyyy-MM-dd'],
//        format: 'dd-MM-yyyy',
//        month: {
//            empty: '<span class="k-state-disabled">#= data.value #</span>'
//        }
//}

//ko.bindingHandlers.kendoGrid.options = {
//    pageable: { pageSize: 10, pageSizes: [10, 25, 50, 100] }
//    }

///Masked TextBox Format For Mobile Number
    ;(function ($) {
    var kendo = window.kendo,
        ui = kendo.ui,
        Widget = ui.Widget,
        proxy = $.proxy,
        CHANGE = "change",
        PROGRESS = "progress",
        ERROR = "error",
        NS = ".generalInfo",
    nss = ".kendoMaskedTextBox";
    var MaskedMobile = Widget.extend({
        init: function (element, options) {
            var that = this;
            Widget.fn.init.call(this, element, options);
            $(element).kendoMaskedTextBox({ mask: that.options.mask })
               .on("blur" + nss, function () {
                   var value = element.value;
                   var len = that.value().replace("_", "");
                   if (len.length != 0) {
                       if (len.length < that.options.mask.length || len == that.options.mask) {
                           toastr.options = {
                               "closeButton": true,
                               "newestOnTop": true,
                               "positionClass": "toast-top-right",
                               "prevent-any-duplicates": false,
                               "showMethod": "fadeIn",
                               "hideMethod": "fadeOut"
                           }
                           toastr.warning("Invalid Mobile Number", "");
                           element.focus();
                       }
                   }
               })
              .on("focus" + nss, function () {
                  var value = element.value;
                  if (value == "___-___-____") {

                      setTimeout((function (element) {
                          var strLength = element.value.length;
                          return function () {
                              if (element.setSelectionRange !== undefined) {
                                  element.setSelectionRange(strLength, 0);
                              } else {
                                  $(element).val(element.value);
                              }
                          }
                      }(this)), 0);
                    }
                })
            ;
        },
        options: {
            name: "MaskedMobile",
            mask: "000-000-0000"
        },

        events: [
          CHANGE
        ],
        destroy: function () {
            var that = this;
            Widget.fn.destroy.call(that);
            kendo.destroy(that.element);
        },
        value: function (value) {
            var phoneMask = this.element.data("kendoMaskedTextBox");

            if (value === undefined) {
                return phoneMask.value();
            }
            phoneMask.value(value);
        }
    });

    ui.plugin(MaskedMobile);
})(window.kendo.jQuery);




//kendo.data.binders.widget.raw = kendo.data.Binder.extend({
//    init: function (widget, bindings, options) {
//        //call the base constructor
//        kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
//        this.widget = widget;
//        this._change = $.proxy(this.change, this);
//        this.widget.first("change", this._change);
//        this._initChange = false;
//    },
//    change: function () {
//        var that = this;
//        var value = that.widget.raw();

//        that._initChange = true;

//        that.bindings.raw.set(value);

//        that._initChange = false;
//    },
//    refresh: function () {
//        if (!this._initChange) {
//            var value = this.bindings.raw.get();
//            this.widget.value(value);
//        }
//    }
//});
//self.phnno = ko.observable();



/////////// <---  Bar Code Scanner Started Here --->
/////////// <---  Kamachari V --->


//;(function ($) {
//    $.fn.getBarCode = function (options) {
//        var settings = $.extend({}, $.fn.getBarCode.defaults, options);

//        return this.each(function () {
//            var pressed = false;
//            var chars = [];
//            var $input = $(this);

//            $(window).keypress(function (e) {
//                var keycode = (e.which) ? e.which : e.keyCode;
//                if ((keycode >= 65 && keycode <= 90) ||
//                    (keycode >= 97 && keycode <= 122) ||
//                    (keycode >= 48 && keycode <= 57)
//                ) {
//                    chars.push(String.fromCharCode(e.which));
//                }
//                if (pressed == false) {
//                    setTimeout(function () {
//                        if (chars.length >= settings.minEntryChars) {
//                            var barcode = chars.join('');
//                            settings.onScan($input, barcode);
//                        }
//                        chars = [];
//                        pressed = false;
//                    }, settings.maxEntryTime);
//                }
//                pressed = true;
//            });

//            $(this).keypress(function (e) {
//                if (e.which === 13) {
//                    e.preventDefault();
//                }
//            });

//            return $(this);
//        });
//    };

//    $.fn.getBarCode.defaults = {
//        minEntryChars: 8,
//        maxEntryTime: 100,
//        onScan: function ($element, barcode) {
//            $element.val(barcode);
//        }
//    };
//})(jQuery);


/////////// <---  Bar Code Scanner Ended Here --->


/////////// <---  Web Cam Code Started Here --->

; (function ($) {
    $.fn.scriptcam = function (options) {
        // merge passed options with default values
        var opts = $.extend({}, $.fn.scriptcam.defaults, options);
        // off we go
        return this.each(function () {

            // add flash to div
            opts.id = this.id; // add id of plugin to the options structure
            data = opts; // pass options to jquery internal data field to make them available to the outside world
            data.path = decodeURIComponent(data.path); // convert URI back to normal string
            $('#' + opts.id).html(opts.noFlashFound); // inject no flash found message
            // forward incoming flash movie calls to outgoing functions
            $.scriptcam.SC_promptWillShow = data.promptWillShow;
            $.scriptcam.SC_fileReady = data.fileReady;
            $.scriptcam.SC_fileConversionStarted = data.fileConversionStarted;
            $.scriptcam.SC_onMotion = data.onMotion;
            $.scriptcam.SC_onError = data.onError;
            $.scriptcam.SC_onHandLeft = data.onHandLeft;
            $.scriptcam.SC_onHandRight = data.onHandRight;
            $.scriptcam.SC_onWebcamReady = data.onWebcamReady;
            $.scriptcam.SC_connected = data.connected;
            $.scriptcam.SC_onPictureAsBase64 = data.onPictureAsBase64;
            $.scriptcam.SC_disconnected = data.disconnected;
            $.scriptcam.SC_setVolume = data.setVolume;
            $.scriptcam.SC_timeLeft = data.timeLeft;
            $.scriptcam.SC_userLeft = data.userLeft;
            $.scriptcam.SC_userJoined = data.userJoined;
            $.scriptcam.SC_addChatText = function (value) {
                value = value.replace(":{", '<img src="' + data.path + 'angry.gif" width="16" height="16" class="smiley"/>');
                $('#' + data.chatWindow).append(value + '<br/>');
                $('#' + data.chatWindow).animate({ scrollTop: $('#' + data.chatWindow).prop("scrollHeight") - $('#' + data.chatWindow).height() }, 100);
            }
            if (opts.canvasHeight && opts.canvasHeight) {
                var newWidth = opts.canvasWidth;
                var newHeight = opts.canvasHeight;
            }
            else {
                // no canvas dimensions given, make our own horizontal layout
                var newWidth = opts.width * opts.zoom;
                var newHeight = opts.height * opts.zoom;
                if (opts.chatRoom) {
                    newWidth = (opts.width * opts.zoom) + (opts.width * opts.zoomChat) + 5; // make room for two horizontal video windows with a margin of 5
                    opts.posX = (opts.width * opts.zoom) + 5;
                    newHeight = opts.height * Math.max(opts.zoom, opts.zoomChat);
                };
            }
            // make new dimensions are not below minimum flash size
            if (newWidth < 215) {
                newWidth = 215;
            }
            if (newHeight < 138) {
                newHeight = 138;
            }
            if (opts.rotate != 0 || opts.skewX != 0 || opts.skewY != 0 || opts.flip != 0 || opts.zoom != 1 || opts.zoomChat != 1) {
                // no GPU acceleration
                var params = {
                    menu: 'false',
                    wmode: 'window',
                    allowScriptAccess: 'always',
                    allowFullScreen: 'true'
                };
            }
            else {
                // GPU acceleration when no filter is used
                var params = {
                    menu: 'false',
                    wmode: 'direct',
                    allowScriptAccess: 'always',
                    allowFullScreen: 'true'
                };
            };
            // Escape all values contained in the flashVars (IE needs this)
            for (var key in opts) {
                opts[key] = encodeURIComponent(opts[key]);
            };
            if (fileExists(decodeURIComponent(data.path) + 'Scripts/scriptcam.swf')) {

                swfobject.embedSWF(decodeURIComponent(data.path) + 'Scripts/scriptcam.swf', opts.id, newWidth, newHeight, '11.6', false, opts, params);
            }
            else {
                alert(decodeURIComponent(data.path) + 'scriptcam.swf not found, please check the path parameter');
            }
        });
    };

    function fileExists(url) {
        var http = new XMLHttpRequest();
        http.open('HEAD', url, false);

        http.send();
        return http.status == 200;
    }

    $.scriptcam = {};

    // outgoing functions (calling the flash movie)

    $.scriptcam.getFrameAsBase64 = function () {

        return $('#' + data.id).get(0).SC_getFrameAsBase64();
    }

    $.scriptcam.version = function () {

        return $('#' + data.id).get(0).SC_version();
    }

    $.scriptcam.hardwareacceleration = function () {

        return $('#' + data.id).get(0).SC_hardwareacceleration();
    }

    $.scriptcam.getMotionParameters = function () {

        $('#' + data.id).get(0).SC_getMotionParameters();
    }

    $.scriptcam.getBarCode = function () {

        return $('#' + data.id).get(0).SC_getBarCode();
    }

    $.scriptcam.startRecording = function () {

        $('#' + data.id).get(0).SC_startRecording();
    }

    $.scriptcam.pauseRecording = function () {
        $('#' + data.id).get(0).SC_pauseRecording();
    }

    $.scriptcam.resumeRecording = function () {

        $('#' + data.id).get(0).SC_resumeRecording();
    }

    $.scriptcam.closeCamera = function () {

        $('#' + data.id).get(0).SC_closeCamera();
    }

    $.scriptcam.changeVolume = function (value) {

        $('#' + data.id).get(0).SC_changeVolume(value);
    }

    $.scriptcam.sendMessage = function (value) {

        $('#' + data.id).get(0).SC_sendMessage(value);
    }

    $.scriptcam.playMP3 = function (value) {

        $('#' + data.id).get(0).SC_playMP3(value);
    }

    $.scriptcam.changeCamera = function (value) {

        $('#' + data.id).get(0).SC_changeCamera(value);
    }

    $.scriptcam.changeMicrophone = function (value) {

        $('#' + data.id).get(0).SC_changeMicrophone(value);
    }

    // set javascript default values (flash default values are managed in the swf file)
    $.fn.scriptcam.defaults = {
        width: 320,
        height: 240,
        chatWindow: 'chatWindow',
        path: '',
        zoom: 1,
        zoomChat: 1,
        rotate: 0,
        skewX: 0,
        skewY: 0,
        flip: 0,
        noFlashFound: '<p>You need <a href="http://www.adobe.com/go/getflashplayer">Adobe Flash Player 11.7</a> to use this software.<br/>Please click on the link to download the installer.</p>'
    };
})(jQuery);

// incoming functions (calls coming from flash) - must be public and forward calls to the scriptcam plugin

function SC_onError(errorId, errorMsg) {

    $.scriptcam.SC_onError(errorId, errorMsg);
}

function SC_fileReady(fileName) {

    $.scriptcam.SC_fileReady(fileName);
}

function SC_fileConversionStarted(fileName) {

    $.scriptcam.SC_fileConversionStarted(fileName);
}

function SC_onMotion(decodedString) {

    $.scriptcam.SC_onMotion(decodedString);
}

function SC_promptWillShow() {

    $.scriptcam.SC_promptWillShow();
}
function SC_onHandLeft() {

    $.scriptcam.SC_onHandLeft();
}
function SC_onHandRight() {

    $.scriptcam.SC_onHandRight();
}
function SC_onWebcamReady(cameraNames, camera, microphoneNames, microphone) {

    $.scriptcam.SC_onWebcamReady(cameraNames, camera, microphoneNames, microphone);
    $.scriptcam.getBarCode();
}

function SC_onPictureAsBase64(value) {

    $.scriptcam.SC_onPictureAsBase64(value);
}

function SC_connected() {

    $.scriptcam.SC_connected();
}

function SC_disconnected() {

    $.scriptcam.SC_disconnected();
}

function SC_setVolume(value) {

    $.scriptcam.SC_setVolume(value);
}

function SC_onMotion(motion, brightness, color, motionx, motiony) {

    $.scriptcam.SC_onMotion(motion, brightness, color, motionx, motiony);
}

function SC_timeLeft(value) {

    $.scriptcam.SC_timeLeft(value);
}

function SC_addChatText(value) {

    $.scriptcam.SC_addChatText(value);
}

function SC_userJoined(value) {

    $.scriptcam.SC_userJoined(value);
}

function SC_userLeft(value) {

    $.scriptcam.SC_userLeft(value);
}



/*	SWFObject v2.2 <http://code.google.com/p/swfobject/> 
	is released under the MIT License <http://www.opensource.org/licenses/mit-license.php> 
*/
var swfobject = function () { var D = "undefined", r = "object", S = "Shockwave Flash", W = "ShockwaveFlash.ShockwaveFlash", q = "application/x-shockwave-flash", R = "SWFObjectExprInst", x = "onreadystatechange", O = window, j = document, t = navigator, T = false, U = [h], o = [], N = [], I = [], l, Q, E, B, J = false, a = false, n, G, m = true, M = function () { var aa = typeof j.getElementById != D && typeof j.getElementsByTagName != D && typeof j.createElement != D, ah = t.userAgent.toLowerCase(), Y = t.platform.toLowerCase(), ae = Y ? /win/.test(Y) : /win/.test(ah), ac = Y ? /mac/.test(Y) : /mac/.test(ah), af = /webkit/.test(ah) ? parseFloat(ah.replace(/^.*webkit\/(\d+(\.\d+)?).*$/, "$1")) : false, X = !+"\v1", ag = [0, 0, 0], ab = null; if (typeof t.plugins != D && typeof t.plugins[S] == r) { ab = t.plugins[S].description; if (ab && !(typeof t.mimeTypes != D && t.mimeTypes[q] && !t.mimeTypes[q].enabledPlugin)) { T = true; X = false; ab = ab.replace(/^.*\s+(\S+\s+\S+$)/, "$1"); ag[0] = parseInt(ab.replace(/^(.*)\..*$/, "$1"), 10); ag[1] = parseInt(ab.replace(/^.*\.(.*)\s.*$/, "$1"), 10); ag[2] = /[a-zA-Z]/.test(ab) ? parseInt(ab.replace(/^.*[a-zA-Z]+(.*)$/, "$1"), 10) : 0 } } else { if (typeof O.ActiveXObject != D) { try { var ad = new ActiveXObject(W); if (ad) { ab = ad.GetVariable("$version"); if (ab) { X = true; ab = ab.split(" ")[1].split(","); ag = [parseInt(ab[0], 10), parseInt(ab[1], 10), parseInt(ab[2], 10)] } } } catch (Z) { } } } return { w3: aa, pv: ag, wk: af, ie: X, win: ae, mac: ac } }(), k = function () { if (!M.w3) { return } if ((typeof j.readyState != D && j.readyState == "complete") || (typeof j.readyState == D && (j.getElementsByTagName("body")[0] || j.body))) { f() } if (!J) { if (typeof j.addEventListener != D) { j.addEventListener("DOMContentLoaded", f, false) } if (M.ie && M.win) { j.attachEvent(x, function () { if (j.readyState == "complete") { j.detachEvent(x, arguments.callee); f() } }); if (O == top) { (function () { if (J) { return } try { j.documentElement.doScroll("left") } catch (X) { setTimeout(arguments.callee, 0); return } f() })() } } if (M.wk) { (function () { if (J) { return } if (!/loaded|complete/.test(j.readyState)) { setTimeout(arguments.callee, 0); return } f() })() } s(f) } }(); function f() { if (J) { return } try { var Z = j.getElementsByTagName("body")[0].appendChild(C("span")); Z.parentNode.removeChild(Z) } catch (aa) { return } J = true; var X = U.length; for (var Y = 0; Y < X; Y++) { U[Y]() } } function K(X) { if (J) { X() } else { U[U.length] = X } } function s(Y) { if (typeof O.addEventListener != D) { O.addEventListener("load", Y, false) } else { if (typeof j.addEventListener != D) { j.addEventListener("load", Y, false) } else { if (typeof O.attachEvent != D) { i(O, "onload", Y) } else { if (typeof O.onload == "function") { var X = O.onload; O.onload = function () { X(); Y() } } else { O.onload = Y } } } } } function h() { if (T) { V() } else { H() } } function V() { var X = j.getElementsByTagName("body")[0]; var aa = C(r); aa.setAttribute("type", q); var Z = X.appendChild(aa); if (Z) { var Y = 0; (function () { if (typeof Z.GetVariable != D) { var ab = Z.GetVariable("$version"); if (ab) { ab = ab.split(" ")[1].split(","); M.pv = [parseInt(ab[0], 10), parseInt(ab[1], 10), parseInt(ab[2], 10)] } } else { if (Y < 10) { Y++; setTimeout(arguments.callee, 10); return } } X.removeChild(aa); Z = null; H() })() } else { H() } } function H() { var ag = o.length; if (ag > 0) { for (var af = 0; af < ag; af++) { var Y = o[af].id; var ab = o[af].callbackFn; var aa = { success: false, id: Y }; if (M.pv[0] > 0) { var ae = c(Y); if (ae) { if (F(o[af].swfVersion) && !(M.wk && M.wk < 312)) { w(Y, true); if (ab) { aa.success = true; aa.ref = z(Y); ab(aa) } } else { if (o[af].expressInstall && A()) { var ai = {}; ai.data = o[af].expressInstall; ai.width = ae.getAttribute("width") || "0"; ai.height = ae.getAttribute("height") || "0"; if (ae.getAttribute("class")) { ai.styleclass = ae.getAttribute("class") } if (ae.getAttribute("align")) { ai.align = ae.getAttribute("align") } var ah = {}; var X = ae.getElementsByTagName("param"); var ac = X.length; for (var ad = 0; ad < ac; ad++) { if (X[ad].getAttribute("name").toLowerCase() != "movie") { ah[X[ad].getAttribute("name")] = X[ad].getAttribute("value") } } P(ai, ah, Y, ab) } else { p(ae); if (ab) { ab(aa) } } } } } else { w(Y, true); if (ab) { var Z = z(Y); if (Z && typeof Z.SetVariable != D) { aa.success = true; aa.ref = Z } ab(aa) } } } } } function z(aa) { var X = null; var Y = c(aa); if (Y && Y.nodeName == "OBJECT") { if (typeof Y.SetVariable != D) { X = Y } else { var Z = Y.getElementsByTagName(r)[0]; if (Z) { X = Z } } } return X } function A() { return !a && F("6.0.65") && (M.win || M.mac) && !(M.wk && M.wk < 312) } function P(aa, ab, X, Z) { a = true; E = Z || null; B = { success: false, id: X }; var ae = c(X); if (ae) { if (ae.nodeName == "OBJECT") { l = g(ae); Q = null } else { l = ae; Q = X } aa.id = R; if (typeof aa.width == D || (!/%$/.test(aa.width) && parseInt(aa.width, 10) < 310)) { aa.width = "310" } if (typeof aa.height == D || (!/%$/.test(aa.height) && parseInt(aa.height, 10) < 137)) { aa.height = "137" } j.title = j.title.slice(0, 47) + " - Flash Player Installation"; var ad = M.ie && M.win ? "ActiveX" : "PlugIn", ac = "MMredirectURL=" + O.location.toString().replace(/&/g, "%26") + "&MMplayerType=" + ad + "&MMdoctitle=" + j.title; if (typeof ab.flashvars != D) { ab.flashvars += "&" + ac } else { ab.flashvars = ac } if (M.ie && M.win && ae.readyState != 4) { var Y = C("div"); X += "SWFObjectNew"; Y.setAttribute("id", X); ae.parentNode.insertBefore(Y, ae); ae.style.display = "none"; (function () { if (ae.readyState == 4) { ae.parentNode.removeChild(ae) } else { setTimeout(arguments.callee, 10) } })() } u(aa, ab, X) } } function p(Y) { if (M.ie && M.win && Y.readyState != 4) { var X = C("div"); Y.parentNode.insertBefore(X, Y); X.parentNode.replaceChild(g(Y), X); Y.style.display = "none"; (function () { if (Y.readyState == 4) { Y.parentNode.removeChild(Y) } else { setTimeout(arguments.callee, 10) } })() } else { Y.parentNode.replaceChild(g(Y), Y) } } function g(ab) { var aa = C("div"); if (M.win && M.ie) { aa.innerHTML = ab.innerHTML } else { var Y = ab.getElementsByTagName(r)[0]; if (Y) { var ad = Y.childNodes; if (ad) { var X = ad.length; for (var Z = 0; Z < X; Z++) { if (!(ad[Z].nodeType == 1 && ad[Z].nodeName == "PARAM") && !(ad[Z].nodeType == 8)) { aa.appendChild(ad[Z].cloneNode(true)) } } } } } return aa } function u(ai, ag, Y) { var X, aa = c(Y); if (M.wk && M.wk < 312) { return X } if (aa) { if (typeof ai.id == D) { ai.id = Y } if (M.ie && M.win) { var ah = ""; for (var ae in ai) { if (ai[ae] != Object.prototype[ae]) { if (ae.toLowerCase() == "data") { ag.movie = ai[ae] } else { if (ae.toLowerCase() == "styleclass") { ah += ' class="' + ai[ae] + '"' } else { if (ae.toLowerCase() != "classid") { ah += " " + ae + '="' + ai[ae] + '"' } } } } } var af = ""; for (var ad in ag) { if (ag[ad] != Object.prototype[ad]) { af += '<param name="' + ad + '" value="' + ag[ad] + '" />' } } aa.outerHTML = '<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"' + ah + ">" + af + "</object>"; N[N.length] = ai.id; X = c(ai.id) } else { var Z = C(r); Z.setAttribute("type", q); for (var ac in ai) { if (ai[ac] != Object.prototype[ac]) { if (ac.toLowerCase() == "styleclass") { Z.setAttribute("class", ai[ac]) } else { if (ac.toLowerCase() != "classid") { Z.setAttribute(ac, ai[ac]) } } } } for (var ab in ag) { if (ag[ab] != Object.prototype[ab] && ab.toLowerCase() != "movie") { e(Z, ab, ag[ab]) } } aa.parentNode.replaceChild(Z, aa); X = Z } } return X } function e(Z, X, Y) { var aa = C("param"); aa.setAttribute("name", X); aa.setAttribute("value", Y); Z.appendChild(aa) } function y(Y) { var X = c(Y); if (X && X.nodeName == "OBJECT") { if (M.ie && M.win) { X.style.display = "none"; (function () { if (X.readyState == 4) { b(Y) } else { setTimeout(arguments.callee, 10) } })() } else { X.parentNode.removeChild(X) } } } function b(Z) { var Y = c(Z); if (Y) { for (var X in Y) { if (typeof Y[X] == "function") { Y[X] = null } } Y.parentNode.removeChild(Y) } } function c(Z) { var X = null; try { X = j.getElementById(Z) } catch (Y) { } return X } function C(X) { return j.createElement(X) } function i(Z, X, Y) { Z.attachEvent(X, Y); I[I.length] = [Z, X, Y] } function F(Z) { var Y = M.pv, X = Z.split("."); X[0] = parseInt(X[0], 10); X[1] = parseInt(X[1], 10) || 0; X[2] = parseInt(X[2], 10) || 0; return (Y[0] > X[0] || (Y[0] == X[0] && Y[1] > X[1]) || (Y[0] == X[0] && Y[1] == X[1] && Y[2] >= X[2])) ? true : false } function v(ac, Y, ad, ab) { if (M.ie && M.mac) { return } var aa = j.getElementsByTagName("head")[0]; if (!aa) { return } var X = (ad && typeof ad == "string") ? ad : "screen"; if (ab) { n = null; G = null } if (!n || G != X) { var Z = C("style"); Z.setAttribute("type", "text/css"); Z.setAttribute("media", X); n = aa.appendChild(Z); if (M.ie && M.win && typeof j.styleSheets != D && j.styleSheets.length > 0) { n = j.styleSheets[j.styleSheets.length - 1] } G = X } if (M.ie && M.win) { if (n && typeof n.addRule == r) { n.addRule(ac, Y) } } else { if (n && typeof j.createTextNode != D) { n.appendChild(j.createTextNode(ac + " {" + Y + "}")) } } } function w(Z, X) { if (!m) { return } var Y = X ? "visible" : "hidden"; if (J && c(Z)) { c(Z).style.visibility = Y } else { v("#" + Z, "visibility:" + Y) } } function L(Y) { var Z = /[\\\"<>\.;]/; var X = Z.exec(Y) != null; return X && typeof encodeURIComponent != D ? encodeURIComponent(Y) : Y } var d = function () { if (M.ie && M.win) { window.attachEvent("onunload", function () { var ac = I.length; for (var ab = 0; ab < ac; ab++) { I[ab][0].detachEvent(I[ab][1], I[ab][2]) } var Z = N.length; for (var aa = 0; aa < Z; aa++) { y(N[aa]) } for (var Y in M) { M[Y] = null } M = null; for (var X in swfobject) { swfobject[X] = null } swfobject = null }) } }(); return { registerObject: function (ab, X, aa, Z) { if (M.w3 && ab && X) { var Y = {}; Y.id = ab; Y.swfVersion = X; Y.expressInstall = aa; Y.callbackFn = Z; o[o.length] = Y; w(ab, false) } else { if (Z) { Z({ success: false, id: ab }) } } }, getObjectById: function (X) { if (M.w3) { return z(X) } }, embedSWF: function (ab, ah, ae, ag, Y, aa, Z, ad, af, ac) { var X = { success: false, id: ah }; if (M.w3 && !(M.wk && M.wk < 312) && ab && ah && ae && ag && Y) { w(ah, false); K(function () { ae += ""; ag += ""; var aj = {}; if (af && typeof af === r) { for (var al in af) { aj[al] = af[al] } } aj.data = ab; aj.width = ae; aj.height = ag; var am = {}; if (ad && typeof ad === r) { for (var ak in ad) { am[ak] = ad[ak] } } if (Z && typeof Z === r) { for (var ai in Z) { if (typeof am.flashvars != D) { am.flashvars += "&" + ai + "=" + Z[ai] } else { am.flashvars = ai + "=" + Z[ai] } } } if (F(Y)) { var an = u(aj, am, ah); if (aj.id == ah) { w(ah, true) } X.success = true; X.ref = an } else { if (aa && A()) { aj.data = aa; P(aj, am, ah, ac); return } else { w(ah, true) } } if (ac) { ac(X) } }) } else { if (ac) { ac(X) } } }, switchOffAutoHideShow: function () { m = false }, ua: M, getFlashPlayerVersion: function () { return { major: M.pv[0], minor: M.pv[1], release: M.pv[2] } }, hasFlashPlayerVersion: F, createSWF: function (Z, Y, X) { if (M.w3) { return u(Z, Y, X) } else { return undefined } }, showExpressInstall: function (Z, aa, X, Y) { if (M.w3 && A()) { P(Z, aa, X, Y) } }, removeSWF: function (X) { if (M.w3) { y(X) } }, createCSS: function (aa, Z, Y, X) { if (M.w3) { v(aa, Z, Y, X) } }, addDomLoadEvent: K, addLoadEvent: s, getQueryParamValue: function (aa) { var Z = j.location.search || j.location.hash; if (Z) { if (/\?/.test(Z)) { Z = Z.split("?")[1] } if (aa == null) { return L(Z) } var Y = Z.split("&"); for (var X = 0; X < Y.length; X++) { if (Y[X].substring(0, Y[X].indexOf("=")) == aa) { return L(Y[X].substring((Y[X].indexOf("=") + 1))) } } } return "" }, expressInstallCallback: function () { if (a) { var X = c(R); if (X && l) { X.parentNode.replaceChild(l, X); if (Q) { w(Q, true); if (M.ie && M.win) { l.style.display = "block" } } if (E) { E(B) } } a = false } } } }();


/////////// <---  Web Cam Code Ended Here --->

