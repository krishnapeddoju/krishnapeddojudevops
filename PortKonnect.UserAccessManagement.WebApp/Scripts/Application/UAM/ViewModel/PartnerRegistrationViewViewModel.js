(function (eGateRoot) {
    var PartnerRegistrationViewViewModel = function (requisitionNo,formMode) {
        var self = this;

        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.validationHelper = new eGateRoot.ValidationHelper();
        self.validationEnabled = ko.observable();
        //self.validationEnabled2 = ko.observable();
        self.viewMode = ko.observable();
        self.editableView = ko.observable(true);
        self.ViewPartnerRegistrationModel = ko.observable(new eGateRoot.ViewPartnerRegistrationModel());
        self.PartnerRegistrationAddres = ko.observable(new eGateRoot.PartnerRegistrationAddres());
        self.PartnerTypeCode = ko.observable('');
        self.PartnerDirectorDetails = ko.observableArray();
        toastr.options.closeButton = true;
        toastr.options.positionClass = "toast-top-right";
        self.Countries = ko.observableArray([]);
        self.PartnerTypes = ko.observableArray([]);
        self.States = ko.observableArray([]);
        self.partnerCodes = ko.observableArray([]);
        self.StatusList = ko.observableArray([]);
        self.DocumentList = ko.observableArray([]);
        self.YearsList = ko.observableArray([]);
        self.bufferPartnerType = ko.observable();
        self.BooleanCharacter = new eGateRoot.BooleanCharacter();
        self.dateFormat = new eGateRoot.DateFormat();
        self.Roles = ko.observableArray([]);
        self.IsReject = ko.observable(false);
        self.IsApprove = ko.observable(false);
        self.IsVerify = ko.observable(false);
        self.IsRemarksVisible = ko.observable(true);
        self.IsUpdate = ko.observable(false);
        self.Isview = ko.observable(formMode==='View'?false:true);

        self.ReqNo = ko.observable('');
        self.LoadUserIdAndUsers = ko.observableArray([]);
        self.UserIdsAndUsers = ko.observableArray([]);
        self.SelectStatesForView = function (model) {
            $.each(self.Countries(), function (k, v) {
                if (v.CountryCode() == model.PartnerRegistrationAddress().Country()) {
                    ko.mapping.fromJS(v.States, {}, self.States);
                }
            });
        }



        self.GetRoles = function (model) {

            self.viewModelHelper.apiGet("api/GetRolesByPartnerType/" + model.PartnerType(), null, function (result) {
                ko.mapping.fromJS(result, {}, self.Roles);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl);

        }



        self.DupliacteValidation = function (model) {

            self.GetPartnerCode(model);
            if ($('#txtAreaPartnerCode').val() == "") {
                toastr.warning(" * Please Enter Partner Code");

            } else {
                $.each(self.partnerCodes(), function (k, v) {
                    $('#spanApprove').text('');
                    if (v.PartnerCode().toUpperCase() == $('#txtAreaPartnerCode').val().toUpperCase()) {
                        toastr.warning("Partner Code Already Exists", "Partner");

                    }


                });
            }
        }

        self.GetDocTypes = function(partnerTypevar) {
            self.viewModelHelper.apiGetAno("api/GetDocumentTypesByPartnerType", { partnerType: partnerTypevar }, function (result) {
                self.ViewPartnerRegistrationModel().DocumentDTOs([]);
                self.ViewPartnerRegistrationModel().DocumentDTOs(ko.utils.arrayMap(result, function (document) {                   
                    return new eGateRoot.FileDocument(document);
                }));
                $.each(self.ViewPartnerRegistrationModel().DocumentDTOs(), function (indexIntern, itemData) {
                    if (itemData.DocumentType() == "Service Tax/VAT Registration Certificate") {
                        itemData.DocumentType("GST/Service Tax/VAT Registration Certificate")
                    }
                });

                $.each(self.DocumentDTOs(), function (index, item) {
                    $.each(self.ViewPartnerRegistrationModel().DocumentDTOs(), function (indexIntern, itemData) {

                        if (itemData.DocumentType() === item.DocumentType()) {
                            if (itemData.DocumentType() == "Service Tax/VAT Registration Certificate")
                            {
                                itemData.DocumentType("GST/Service Tax/VAT Registration Certificate");
                                item.DocumentType("GST/Service Tax/VAT Registration Certificate");
                            }
                            itemData.FileName(item.FileName());
                            itemData.ValidTill(item.ValidTill());
                            itemData.OriginalName(item.OriginalName());
                            itemData.IsDeleted(item.IsDeleted());
                        }
                    });
                    
                });
                setTimeout(function() {
                    $.each(self.ViewPartnerRegistrationModel().DocumentDTOs(), function (index, item) {
                        if (!isEmpty(item.FileName())) {
                            var nextDayDate = new Date();
                            nextDayDate.setDate((new Date()).getDate() + 1);
                        if ((partnerTypevar === "VesselOperatingAgent") && (item.DocumentType() === "Agreement With Agency" || item.DocumentType() === "Valid M.L.O Licence With Customs At Vijayawada" || item.DocumentType() === "Valid Steamer Agency Licence With Jurisdictional Customs")) {
                            $("#IsvalidTill" + index).show();
                            setTimeout(function () { $("#validTill" + index).data('kendoDatePicker').min(nextDayDate); }, 200);
                        } else if ((partnerTypevar === "ContainerOperatorAgent") && (item.DocumentType() === "Valid Agency Agreement" || item.DocumentType() === "Valid Customs Continuity Bond" || item.DocumentType() === "Valid Steamer Agency Licence With Jurisdictional Customs")) {
                            $("#IsvalidTill" + index).show();
                            setTimeout(function () { $("#validTill" + index).data('kendoDatePicker').min(nextDayDate); }, 200);
                        } else if ((partnerTypevar === "CustomHouseAgent") && (item.DocumentType() === "CHA/MTO (For CHA/FF) Licence Registration With Krishnapatnam Port")) {
                            $("#IsvalidTill" + index).show();
                            setTimeout(function () { $("#validTill" + index).data('kendoDatePicker').min(nextDayDate); }, 200);
                        } else if ((partnerTypevar === "ContainerFreightStation") && (item.DocumentType() === "CFS Licence Copy")) {
                            $("#IsvalidTill" + index).show();
                            setTimeout(function () { $("#validTill" + index).data('kendoDatePicker').min(nextDayDate); }, 200);
                        } else if ((partnerTypevar === "MandR") && (item.DocumentType() === "IICL Copy")) {
                            $("#IsvalidTill" + index).show();
                            setTimeout(function () { $("#validTill" + index).data('kendoDatePicker').min(nextDayDate); }, 200);
                        } else {
                            $("#IsvalidTill" + index).hide();
                        }
                        }
                    });
                }, 700);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }

        self.GetPartnerCode = function () {
            var PartnerTypeName = [];
            PartnerTypeName.push(self.PartnerTypeCode());
            self.viewModelHelper.apiGet("api/GetPartnerCodes", { partnerType: PartnerTypeName }, function (result) {
                ko.mapping.fromJS(result, {}, self.partnerCodes);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');


        }
        self.Initialize = function () {
            self.ViewPartnerRegistrationModel(new eGateRoot.ViewPartnerRegistrationModel());
            self.PartnerRegistrationAddres(new eGateRoot.PartnerRegistrationAddres());
            self.viewMode = ko.observable(true);
            self.LoadCountries();
            self.LoadStatusList();
            self.LoadDocumentType();
            self.LoadYearsList();
            self.LoadRegistrationDetails();
            self.LoadUsersAndUserIds();
            self.viewMode('Form');
            $(document).ready(function () {
                $("#validTill").kendoMaskedDatePicker();
                $('#validTill').data('kendoDatePicker');
                $.each(self.ViewPartnerRegistrationModel().PartnerDirectorDetailss(), function (index, item) {
                    if (item.Type() === "Director") {
                        $("#pDirectorMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                    }
                });
                $.each(self.ViewPartnerRegistrationModel().PartnerOperationsDetailss(), function (index, item) {
                    $("#pOperationsMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                });
                $.each(self.ViewPartnerRegistrationModel().PartnerITDetailss(), function (index, item) {
                    $("#pITMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                });
                $.each(self.ViewPartnerRegistrationModel().PartnerFinanceDetailss(), function (index, item) {
                    $("#pFinanceMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                });
                $.each(self.ViewPartnerRegistrationModel().PartnerSalesDetailss(), function (index, item) {
                    $("#pSalesMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                });
                SetFocus();
            });
        }


        self.LoadRegistrationDetails = function () {
            self.viewModelHelper.apiGet("api/PartnerRegistration/" + requisitionNo, null, function (result) {
                self.ViewPartnerRegistrationModel(new eGateRoot.ViewPartnerRegistrationModel(result));
                self.ViewPartnerRegistrationModel().validationEnabled(false);
                $.each(self.ViewPartnerRegistrationModel().DocumentDTOs(), function (indexIntern, itemData) {
                    if (itemData.DocumentType() === "Service Tax/VAT Registration Certificate") {
                        itemData.DocumentType("GST/Service Tax/VAT Registration Certificate")
                    }
                    });
                self.abc = ko.observable(new eGateRoot.ViewPartnerRegistrationModel(result));
                self.partnerDirectorArray = ko.observableArray([]);
                //$("#txtMobileNo").kendoMaskedTextBox({ mask: "000-000-0000" });
                
                $.each(self.abc().PartnerDirectorDetailss(), function (index, item) {
                    if (item.Type() === "Operations") {
                        self.ViewPartnerRegistrationModel().PartnerOperationsDetailss.push(item);
                        $("#pOperationsMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                    } else if (item.Type() === "IT") {
                        self.ViewPartnerRegistrationModel().PartnerITDetailss.push(item);
                        $("#pITMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                    } else if (item.Type() === "Finance") {
                        self.ViewPartnerRegistrationModel().PartnerFinanceDetailss.push(item);
                        $("#pFinanceMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                    } else if (item.Type() === "Sales") {
                        self.ViewPartnerRegistrationModel().PartnerSalesDetailss.push(item);
                        $("#pSalesMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                    } else {
                        self.partnerDirectorArray.push(item);
                    }
                });
                self.ViewPartnerRegistrationModel().PartnerDirectorDetailss([]);
                self.ViewPartnerRegistrationModel().PartnerDirectorDetailss(self.partnerDirectorArray());

                if(self.Isview()){
                    self.DocumentDTOs = ko.observable(ko.utils.arrayMap(result.DocumentDTOs, function (document) {
                        if (document.DocumentType === "Service Tax/VAT Registration Certificate") 
                        { document.DocumentType = "GST/Service Tax/VAT Registration Certificate"; }
                    return new eGateRoot.FileDocument(document);
                }));
                self.GetDocTypes(result.PartnerType);
            }
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
             self.SelectStatesForView(self.ViewPartnerRegistrationModel());
          $(document).ready(function () {
                document.getElementById("sigImage").src = application.viewbag.appSettings.uamapiUrl + "/FileUploads/Logo/" + self.ViewPartnerRegistrationModel().PartnerRegistrationAddress().LogoPath();
            });
            setTimeout(function () { $("#txtMobileNo").kendoMaskedTextBox({ mask: "(000)000-000-0000" }); }, 200);


            //$.each(self.ViewPartnerRegistrationModel().PartnerDirectorDetailss(), function (index, item) {
            //    if (item.Type() === "Operations") {
            //        self.ViewPartnerRegistrationModel().PartnerOperationsDetailss().push(item);
            //    }
            //    else if (item.Type() === "IT") {
            //        self.ViewPartnerRegistrationModel().PartnerITDetailss().push(item);
            //    }
            //    else if (item.Type() === "Finance") {
            //        self.ViewPartnerRegistrationModel().PartnerFinanceDetailss().push(item);
            //    }
            //    else if (item.Type() === "Sales") {
            //        self.ViewPartnerRegistrationModel().PartnerSalesDetailss().push(item);
            //    }
            //});


        };


        self.LoadDocumentType = function () {
            self.viewModelHelper.apiGet("api/GetDocumentTypes", null, function (result) {
                ko.mapping.fromJS(result, {}, self.DocumentList);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
            $.each(self.DocumentList(), function (indexIntern, itemData) {
                if (itemData === "Service Tax/VAT Registration Certificate") {
                    itemData = "GST/Service Tax/VAT Registration Certificate";
                }
            });
        };

        self.LoadStatusList = function () {
            self.viewModelHelper.apiGet("api/GetStatuses", null, function (result) {
                ko.mapping.fromJS(result, {}, self.StatusList);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        };


        self.LoadCountries = function () {
            self.viewModelHelper.apiGet("api/Countries", null, function (result) {
                ko.mapping.fromJS(result, {}, self.Countries);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        };

        self.LoadYearsList = function () {
            self.viewModelHelper.apiGetAno("api/GetYears", null, function (result) {
                ko.mapping.fromJS(result, {}, self.YearsList);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        };

        self.uploadFile = function (e) {
            var uploadedFiles = [];
            var documentData = [];
            uploadedFiles = self.ViewPartnerRegistrationModel().PartnerRegistrationAddress().UploadedFiles();
            var opmlFile = $('#fileToUpload')[0];
            var flag = true;

            if (opmlFile.files.length > 0) {
                for (var i = 0; i < opmlFile.files.length; i++) {
                    var match = null;
                   
                    var reader = new FileReader();
                    var image = new Image();

                    reader.onload = function (e) {

                        image.src = e.target.result;
                        image.onload = function (e) {

                            var width = this.width,
                                height = this.height;
                            
                        };
                    };
                    reader.readAsDataURL(opmlFile.files[i]);

                    if (match == null) {

                        var elem = {};
                        elem.FileName = opmlFile.files[i].name;
                        var extension = opmlFile.files[i].name.split('.').pop().toLowerCase();
                        var fileExtension = ['jpg', 'png'];
                        if ($.inArray(extension, fileExtension) != -1) {
                            var size = opmlFile.files[i].size;
                           

                            elem.CategoryName = $('#selUploadDocs option:selected').text();
                            elem.CategoryCode = $('#selUploadDocs option:selected').val();
                            elem.FileDetails = opmlFile.files[i];
                            elem.IsAlreadyExists = false;

                            uploadedFiles.push(elem);
                            self.ViewPartnerRegistrationModel().PartnerRegistrationAddress().UploadedFiles(uploadedFiles);

                            var reader = new FileReader();
                            reader.onload = function (e) {
                                $('#sigImage').attr('src', e.target.result);
                            }
                            reader.readAsDataURL(opmlFile.files[i]);
                            

                        } else {
                            toastr.error("Please upload the files with formats (.JPG, .PNG) only", "Error");
                            return;
                        }
                    }
                }

                var formData = new FormData();

                ko.utils.arrayMap(self.ViewPartnerRegistrationModel().PartnerRegistrationAddress().UploadedFiles(), function (item) {
                    formData.append(item.FileName, item.FileDetails);
                });


                self.viewModelHelper.apiUploadAno('api/FileUpload/ImageUploadAno?documentType=Doc1', formData, function Message(data) {
                    ko.utils.arrayMap(data, function (item) {
                        self.ViewPartnerRegistrationModel().PartnerRegistrationAddress().LogoFileName(item.OrginalFileName);
                        self.ViewPartnerRegistrationModel().PartnerRegistrationAddress().LogoPath(item.FileName);

                    });
                }, null, null, null, null, 'UAM');

               
            } else {
                toastr.warning("Please select image", "Error");
            }
            if (opmlFile.files.length > 0) {
                self.ViewPartnerRegistrationModel().PartnerRegistrationAddress().UploadedFiles([]);

                $('#fileToUpload').val('');
                $('#sigImage').attr('src', "");
            }
            return;
        }

        self.Upload = function (e) {

            if (self.ViewPartnerRegistrationModel().DocumentType() != undefined) {

                if ((self.ViewPartnerRegistrationModel().PartnerType() === "VesselOperatingAgent" || self.ViewPartnerRegistrationModel().PartnerType() === "ContainerOperatorAgent" || self.ViewPartnerRegistrationModel().PartnerType() === "CustomHouseAgent" || self.ViewPartnerRegistrationModel().PartnerType() === "ContainerFreightStation" || self.ViewPartnerRegistrationModel().PartnerType() === "MandR")
					&& (self.ViewPartnerRegistrationModel().DocumentType() === "Agreement With Agency" || self.ViewPartnerRegistrationModel().DocumentType() === "Valid M.L.O Licence With Customs At Vijayawada" || self.ViewPartnerRegistrationModel().DocumentType() === "Valid Steamer Agency Licence With Jurisdictional Customs" || self.ViewPartnerRegistrationModel().DocumentType() === "Valid Agency Agreement" || self.ViewPartnerRegistrationModel().DocumentType() === "Valid Customs Continuity Bond" || self.ViewPartnerRegistrationModel().DocumentType() === "Valid Steamer Agency Licence With Jurisdictional Customs"
					|| self.ViewPartnerRegistrationModel().DocumentType() === "CHA/MTO (For CHA/FF) Licence Registration With Krishnapatnam Port" || self.ViewPartnerRegistrationModel().DocumentType() === "CFS Licence Copy" || self.ViewPartnerRegistrationModel().DocumentType() === "IICL Copy")) {

                    if (self.ViewPartnerRegistrationModel().ValidTill() === '' || self.ViewPartnerRegistrationModel().ValidTill() === null || self.ViewPartnerRegistrationModel().ValidTill() === undefined) {

                        $('#validTilltxt').text('* This field is required.');
                        e.preventDefault();
                        return false;


                    }
                    else if (kendo.toString(kendo.parseDate(self.ViewPartnerRegistrationModel().ValidTill(), 'dd-MM-yyyy'), 'yyyy-MM-dd') < kendo.toString(new Date(), 'yyyy-MM-dd')) {

                        toastr.warning("Please select valid date");
                        e.preventDefault();
                        return false;
                    }
                    else {
                        $('#validTilltxt').text('');
                        UploadFile(self.ViewPartnerRegistrationModel().DocumentDTOs(), e);

                    }
                }

                else {

                    UploadFile(self.ViewPartnerRegistrationModel().DocumentDTOs(), e);
                }
            }
            //else {
            //    toastr.warning("Please select document type");
            //    e.preventDefault();
            //    return false;
            //}


        }

        self.FileSuccess = function (data) {
            if (typeof (data.response) == "string") {
                toastr.error(data.response, "File Upload");
                return false;
            }
            var id = parseInt(data.sender.element[0].id.split('upload')[1]);
            var obj = new eGateRoot.FileDocument();
            obj.OriginalName(data.response.FileName);
            obj.FileName(data.response.FileName);
            obj.UploadedDate(data.response.UploadDate);
            obj.IsCurrentdoc(self.BooleanCharacter.Yes());

            self.ViewPartnerRegistrationModel().DocumentDTOs()[id].OriginalName(data.response.FileName);
            self.ViewPartnerRegistrationModel().DocumentDTOs()[id].FileName(data.response.FileName);
            self.ViewPartnerRegistrationModel().DocumentDTOs()[id].IsDeleted("N");

            var docType = self.ViewPartnerRegistrationModel().DocumentDTOs()[id].DocumentType();
            var partnerType = self.ViewPartnerRegistrationModel().PartnerType();
            if ((partnerType === "VesselOperatingAgent") && (docType === "Agreement With Agency" || docType === "Valid M.L.O Licence With Customs At Vijayawada" || docType === "Valid Steamer Agency Licence With Jurisdictional Customs")) {
                $("#IsvalidTill" + id).show();
            }
            else if ((partnerType === "ContainerOperatorAgent") && (docType === "Valid Agency Agreement" || docType === "Valid Customs Continuity Bond" || docType === "Valid Steamer Agency Licence With Jurisdictional Customs")) {
                $("#IsvalidTill" + id).show();
            }
            else if ((partnerType === "CustomHouseAgent") && (docType === "CHA/MTO (For CHA/FF) Licence Registration With Krishnapatnam Port")) {
                $("#IsvalidTill" + id).show();
            }
            else if ((partnerType === "ContainerFreightStation") && (docType === "CFS Licence Copy")) {
                $("#IsvalidTill" + id).show();
            }
            else if ((partnerType === "MandR") && (docType === "IICL Copy")) {
                $("#IsvalidTill" + id).show();
            }
            else {
                $("#IsvalidTill" + id).hide();
            }
            var nextDayDate = new Date();
            nextDayDate.setDate((new Date()).getDate() + 1);
            setTimeout(function () { $("#validTill" + id).data('kendoDatePicker').min(nextDayDate); }, 200);
            $(".k-upload-button").removeClass("k-state-focused");
            //$("#validTill" + id).kendoMaskedDatePicker();
            //
            //$("#validTill" + id).data('kendoDatePicker').min(new Date());
            //$('#validTill' + id).data("kendoMaskedTextBox").enable(false);
            //self.PartnerRegistrationModel().DocumentDTOs.push(obj);
            //self.PartnerRegistrationModel().DocumentDTOs()[self.PartnerRegistrationModel().DocumentDTOs().length - 1].DocumentType(self.PartnerRegistrationModel().DocumentType());
            //self.PartnerRegistrationModel().DocumentDTOs()[self.PartnerRegistrationModel().DocumentDTOs().length - 1].ValidTill(self.PartnerRegistrationModel().ValidTill());
            //$('#ddlDoctype').val('');
            //$('#validTill').val('');
            //self.PartnerRegistrationModel().DocumentType('');
            //self.PartnerRegistrationModel().ValidTill('');
        }

        self.LoadPartnerTypes = function () {
            self.viewModelHelper.apiGet("api/PartnerTypes", null, function (result) {
                ko.mapping.fromJS(result, {}, self.PartnerTypes);
            }, null, null, false, eGateRoot.uamRootPath);
        };



        self.SelectStates = function (model) {
            self.States([]);
            $.each(self.Countries(), function (k, v) {
                if (v.CountryCode() === model.Country()) {
                    ko.mapping.fromJS(v.States, {}, self.States);
                }
            });
        }

        self.ExitScreen = function () {
            window.location.href = "/PendingPartnerRegistrations";
        }

        self.LoadUsersAndUserIds = function () {
            self.viewModelHelper.apiGet("api/GetUserIdAndNames", null, function (result) {
                ko.mapping.fromJS(result, {}, self.LoadUserIdAndUsers);
                ko.mapping.fromJS(result, {}, self.UserIdsAndUsers);

            }, null, null, false, application.viewbag.appSettings.uamapiUrl);

        };


        self.validateUserName = function (model) {
            $.each(self.LoadUserIdAndUsers(), function (i, val) {
                if ($('#txtAreaUserName').val() == "") {
                    toastr.warning(" * Please Enter User Name");
                }
                else if (val.UserName().toUpperCase() == $('#txtAreaUserName').val().toUpperCase()) {
                    toastr.warning("Username Already exists", "User");
                }
                else {
                    $('#spanUserName').text('');
                }

            });
        }
        self.AddNewDetails = function () {
            if (self.ViewPartnerRegistrationModel().PartnerDirectorDetailss().length > 0) {
                self.ViewPartnerRegistrationModel().PartnerDirectorDetailss.push(new eGateRoot.PartnerDirectorDetails());
                setTimeout(function(){
                $("#pDirectorMobile" + (self.ViewPartnerRegistrationModel().PartnerDirectorDetailss().length - 1)).kendoMaskedTextBox({ mask: "000-000-0000" });
                $("#PDirectorTele" + (self.ViewPartnerRegistrationModel().PartnerDirectorDetailss().length - 1)).kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                SetFocusGrid(("#PDirectorTele" + (self.ViewPartnerRegistrationModel().PartnerDirectorDetailss().length - 1)));
                SetFocusGrid(("#pDirectorMobile" + (self.ViewPartnerRegistrationModel().PartnerDirectorDetailss().length - 1)));
                },100);
                
                self.ViewPartnerRegistrationModel().PartnerDirectorDetailss()[self.ViewPartnerRegistrationModel().PartnerDirectorDetailss().length - 1].Type("Director");
            }
            else {
                self.ViewPartnerRegistrationModel().PartnerDirectorDetailss.push(new eGateRoot.PartnerDirectorDetails());
                self.ViewPartnerRegistrationModel().PartnerDirectorDetailss()[0].Type("Director");
                $("#pDirectorMobile0").kendoMaskedTextBox({ mask: "000-000-0000" });
                $("#PDirectorTele0").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                SetFocusGrid(("#pDirectorMobile0"));
                SetFocusGrid(("#PDirectorTele0"));
            }
        }
        self.RemoveDetails = function (row) {
            $.confirm({
                'title': 'Partner Registration',
                'message': 'Are you sure you want to Remove Directors/Partners/Promoters Details?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                            if (isEmpty(row.PDirectorDetailsId())) {
                                self.ViewPartnerRegistrationModel().PartnerDirectorDetailss.remove(row);
                            } else {
                                row.IsDeleted("Y");
                            }
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
        //#endregion
        //#endregion

        self.RemoveDocument = function (model, e) {
            $.confirm({
                'title': 'Partner Registration',
                'message': 'Are you sure you want to Remove Document?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                            model.OriginalName('');
                            model.FileName('');
                            model.ValidTill('');
                            model.IsDeleted('Y');
                            model.ErrorStatusDocument(false);
                            $("#IsvalidTill" + e.target.id).hide();
                            $(".k-upload-button").removeClass("k-state-focused");
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

        //#region Add Remove Operations Details
        //#region Add New Details 
        self.AddNewOperationsDetails = function () {
            if (self.ViewPartnerRegistrationModel().PartnerOperationsDetailss().length > 0) {
                self.ViewPartnerRegistrationModel().PartnerOperationsDetailss.push(new eGateRoot.PartnerDirectorDetails());
                $("#pOperationsMobile" + (self.ViewPartnerRegistrationModel().PartnerOperationsDetailss().length - 1)).kendoMaskedTextBox({ mask: "000-000-0000" });
                SetFocusGrid(("#pOperationsMobile" + (self.ViewPartnerRegistrationModel().PartnerOperationsDetailss().length - 1)));
                self.ViewPartnerRegistrationModel().PartnerOperationsDetailss()[self.ViewPartnerRegistrationModel().PartnerOperationsDetailss().length - 1].Type("Operations");
            }
            else {
                self.ViewPartnerRegistrationModel().PartnerOperationsDetailss.push(new eGateRoot.PartnerDirectorDetails());
                self.ViewPartnerRegistrationModel().PartnerOperationsDetailss()[0].Type("Operations");
                $("#pOperationsMobile0").kendoMaskedTextBox({ mask: "000-000-0000" });
                SetFocusGrid(("#pOperationsMobile0"));
            }
        }
        //#endregion

        //#region Remove Row
        self.RemoveOperationsDetails = function (row) {
            $.confirm({
                'title': 'Partner Registration',
                'message': 'Are you sure you want to Remove Operations Representative Detail?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                            if (isEmpty(row.PDirectorDetailsId())) {
                                self.ViewPartnerRegistrationModel().PartnerOperationsDetailss.remove(row);
                            } else {
                                row.IsDeleted("Y");
                            }
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
        //#endregion
        //#endregion

        //#region Add Remove IT Details
        //#region Add New Details 
        self.AddNewITDetails = function () {
            if (self.ViewPartnerRegistrationModel().PartnerITDetailss().length > 0) {
                self.ViewPartnerRegistrationModel().PartnerITDetailss.push(new eGateRoot.PartnerDirectorDetails());
                $("#pITMobile" + (self.ViewPartnerRegistrationModel().PartnerITDetailss().length - 1)).kendoMaskedTextBox({ mask: "000-000-0000" });
                SetFocusGrid(("#pITMobile" + (self.ViewPartnerRegistrationModel().PartnerITDetailss().length - 1)));
                self.ViewPartnerRegistrationModel().PartnerITDetailss()[self.ViewPartnerRegistrationModel().PartnerITDetailss().length - 1].Type("IT");
            }
            else {
                self.ViewPartnerRegistrationModel().PartnerITDetailss.push(new eGateRoot.PartnerDirectorDetails());
                self.ViewPartnerRegistrationModel().PartnerITDetailss()[0].Type("IT");
                $("#pITMobile0").kendoMaskedTextBox({ mask: "000-000-0000" });
                SetFocusGrid(("#pITMobile0"));
            }
        }
        //#endregion

        //#region Remove Row
        self.RemoveITDetails = function (row) {
            $.confirm({
                'title': 'Partner Registration',
                'message': 'Are you sure you want to Remove IT Representative Detail?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                            if (isEmpty(row.PDirectorDetailsId())) {
                                self.ViewPartnerRegistrationModel().PartnerITDetailss.remove(row);
                            } else {
                                row.IsDeleted("Y");
                            }
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
        //#endregion
        //#endregion

        //#region Add Remove Finance Details
        //#region Add New Details 
        self.AddNewFinanceDetails = function () {
            if (self.ViewPartnerRegistrationModel().PartnerFinanceDetailss().length > 0) {
                self.ViewPartnerRegistrationModel().PartnerFinanceDetailss.push(new eGateRoot.PartnerDirectorDetails());
                $("#pFinanceMobile" + (self.ViewPartnerRegistrationModel().PartnerFinanceDetailss().length - 1)).kendoMaskedTextBox({ mask: "000-000-0000" });
                SetFocusGrid(("#pFinanceMobile" + (self.ViewPartnerRegistrationModel().PartnerFinanceDetailss().length - 1)));
                self.ViewPartnerRegistrationModel().PartnerFinanceDetailss()[self.ViewPartnerRegistrationModel().PartnerFinanceDetailss().length - 1].Type("Finance");
            }
            else {
                self.ViewPartnerRegistrationModel().PartnerFinanceDetailss.push(new eGateRoot.PartnerDirectorDetails());
                self.ViewPartnerRegistrationModel().PartnerFinanceDetailss()[0].Type("Finance");
                $("#pFinanceMobile0").kendoMaskedTextBox({ mask: "000-000-0000" });
                SetFocusGrid(("#pFinanceMobile0"));
            }
        }
        //#endregion

        //#region Remove Row
        self.RemoveFinanceDetails = function (row) {
            $.confirm({
                'title': 'Partner Registration',
                'message': 'Are you sure you want to Remove Finance Representative Detail?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                            if (isEmpty(row.PDirectorDetailsId())) {
                                self.ViewPartnerRegistrationModel().PartnerFinanceDetailss.remove(row);
                            } else {
                                row.IsDeleted("Y");
                            }
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
        //#endregion
        //#endregion

        //#region Add Remove Sales Details
        //#region Add New Details 
        self.AddNewSalesDetails = function () {
            if (self.ViewPartnerRegistrationModel().PartnerSalesDetailss().length > 0) {
                self.ViewPartnerRegistrationModel().PartnerSalesDetailss.push(new eGateRoot.PartnerDirectorDetails());
                $("#pSalesMobile" + (self.ViewPartnerRegistrationModel().PartnerSalesDetailss().length - 1)).kendoMaskedTextBox({ mask: "000-000-0000" });
                SetFocusGrid(("#pSalesMobile" + (self.ViewPartnerRegistrationModel().PartnerSalesDetailss().length - 1)));
                self.ViewPartnerRegistrationModel().PartnerSalesDetailss()[self.ViewPartnerRegistrationModel().PartnerSalesDetailss().length - 1].Type("Sales");
            }
            else {
                self.ViewPartnerRegistrationModel().PartnerSalesDetailss.push(new eGateRoot.PartnerDirectorDetails());
                self.ViewPartnerRegistrationModel().PartnerSalesDetailss()[0].Type("Sales");
                $("#pSalesMobile0").kendoMaskedTextBox({ mask: "000-000-0000" });
                SetFocusGrid(("#pSalesMobile0"));
            }
        }
        //#endregion

        //#region Remove Row
        self.RemoveSalesDetails = function (row) {
            $.confirm({
                'title': 'Partner Registration',
                'message': 'Are you sure you want to Remove Sales Representative Detail?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                            if (isEmpty(row.PDirectorDetailsId())) {
                                self.ViewPartnerRegistrationModel().PartnerSalesDetailss.remove(row);
                            } else {
                                row.IsDeleted("Y");
                            }
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
        //#endregion
        //#endregion


        //#region Reject Functionality
        self.closeRejectPopup = function () {
            $('#reject').modal('hide');
        }
        self.closeRejectBulkPopup = function () {
            $('#rejectBulk').modal('hide');
            $('#spanUserName').text('');
            $('#spanFirstName').text('');
            $('#spanLastName').text('');
            $('#spanReject').text('');
            $('#spanApprove').text('');

        }

        self.validateContainersPopup = function (model, e) {
            var errors = 0;
            if (e.target.id != 'btnRejectVerification0' && e.target.id != 'btnReject0'){
                errors = self.ValidateControls(model,e);
            }
            if (errors === 0) {
                $('#' + e.target.id.split('0')[0]).trigger('click');
            }
        }

        self.ShowContainersPopup = function (model, e) {
            //self.PendingPartnerRegistrationModel().validationEnabled(false);
            //var checkFlag = false;
            //for (var i = 0; i < self.ImportRailFormsList().length; i++) {
            //    if (self.ImportRailFormsList()[i].Ischecked() === true && self.ImportRailFormsList()[i].IsEndorsed() === 'N') {
            //        checkFlag = true;
            //    }
            //}
            var errors = self.ValidateControls(model,e);
            if (errors === 0) {
                self.ReqNo(model.RequisitionNo());
                self.PartnerTypeCode(model.PartnerType());
                if (e.currentTarget.id === 'btnReject' || e.currentTarget.id === 'btnRejectVerification') {
                    self.IsReject(true);
                    self.IsApprove(false);
                    self.IsVerify(false);
                    self.IsUpdate(false);
                    self.IsRemarksVisible(true);
                    //$("#btnPopUpNo").text("No");
                    $('#spanReject').text('');
                    $('#txtAreaRejectsRemarks').val("");
                    $('#lblRejectsContainer').text("Are you sure you want to Reject Selected Partner?");
                    $('#lblMainHeading').text('Partner Registration Rejection');
                } else if (e.currentTarget.id === 'btnApprove') {
                    self.IsReject(false);
                    self.IsApprove(true);
                    self.IsVerify(false);
                    self.IsUpdate(false);
                    self.GetRoles(model);
                    // model.UserRoleArray(undefined);

                    var multiSelect = $('#userPort').data("kendoMultiSelect");
                    multiSelect.value([]);
                    $('#lblMainHeading').text('Partner Registration Approval');
                    $('#txtAreaPartnerCode').val('');
                    $('#txtAreaUserName').val('');
                    $('#txtAreaFirstName').val('');
                    $('#txtAreaLastName').val('');
                    $('#spanApprove').text('');
                    $('#spanUserName').text('');
                    $('#spanFirstName').text('');
                    $('#spanLastName').text('');
                    $('#spnrole').text('');
                    $("#lblRejectsContainer").text("Are you sure you want to Approve Selected Partner?");
                    self.IsRemarksVisible(true);
                }
                else if (e.currentTarget.id === 'btnUpdate') {
                    self.IsReject(false);
                    self.IsApprove(false);
                    self.IsVerify(false);
                    self.IsRemarksVisible(false);
                    self.IsUpdate(true);
                    //$("#btnPopUpNo").text("No");
                    $('#spanReject').text('');
                    $('#txtAreaRejectsRemarks').val("");
                    $('#lblRejectsContainer').text("Are you sure you want to Update Selected Partner?");
                    $('#lblMainHeading').text('Partner Registration Updation');
                } else {
                    self.IsReject(false);
                    self.IsApprove(false);
                    self.IsVerify(true);
                    self.IsUpdate(false);
                    self.IsRemarksVisible(false);
                    $('#lblMainHeading').text('Partner Registration Verification');
                    $("#lblRejectsContainer").text("Are you sure you want to Verify Selected Partner?");
                }
            } else {
                setTimeout(function() { $('#rejectBulkClose').trigger('click'); });

            }
        }

        HandleValidateRejectRemarks = function (event) {
            if (event.id === "txtAreaRejectsRemarks" && $("#txtAreaRejectsRemarks").val().trim() === "") {
                $("#spanReject").text('* Please Enter Reason');
            } else if (event.id === "txtAreaRemarks" && $('#txtAreaRemarks').val().trim() === "") {
                $('#spanReject').text('* Please Enter Reason');
            } else {
                $("#spanReject").text('');
            }
        }

        self.RejectsForm = function (model) {
            if ($('#txtAreaRejectsRemarks').val().trim() === "") {
                $('#spanReject').text('* Please Enter Reason');
            } else {
                $('#rejectBulkClose').trigger('click');
                model.Remarks($('#txtAreaRejectsRemarks').val());
                model.RequisitionNo(self.ReqNo());
                self.viewModelHelper.apiPost('api/RejectPartnerRegistration', ko.mapping.toJSON(model), function message(data) {
                    toastr.options.closeButton = true;
                    toastr.options.positionClass = "toast-top-right";
                    toastr.success("Partner Registration rejected successfully", "Partner Registration");
                    setTimeout(
                            function () {
                                window.location.href = "/PendingPartnerRegistrations";
                            }, 2000);
                }, null, false, application.viewbag.appSettings.uamapiUrl, null, 'UAM');
            }
        }
        //#endregion

        //#region Approval
        self.ApproveForm = function (model) {
            var errors = 0;
            $.each(self.LoadUserIdAndUsers(), function (i, val) {
                if (val.UserName().toUpperCase() != "" && val.UserName().toUpperCase() == $('#txtAreaUserName').val().toUpperCase()) {
                    toastr.warning("Username Already exists", "User");
                    errors = errors + 1;
                    return;
                }
            });

            $.each(self.partnerCodes(), function (k, v) {

                if (v.PartnerCode().toUpperCase() == $('#txtAreaPartnerCode').val().toUpperCase()) {
                    toastr.warning("Partner Code Already Exists", "Partner");
                    errors = errors + 1;
                    return;

                }


            });

            if ($('#txtAreaUserName').val().trim() === "") {
                $('#spanUserName').text('* Please Enter User Name');
                errors = errors + 1;
            }

            if ($('#txtAreaFirstName').val().trim() === "") {
                $('#spanFirstName').text('* Please Enter First Name');
                errors = errors + 1;
            }

            if ($('#txtAreaLastName').val().trim() === "") {
                $('#spanLastName').text('* Please Enter Last Name');
                errors = errors + 1;

            }

            if ($('#txtAreaPartnerCode').val().trim() === "") {
                $('#spanApprove').text('* Please Enter Partner Code');
                errors = errors + 1;
            }
            if (model.UserRoleArray().length === 0) {
                $('#spnrole').text('* Please Select Role');
                errors = errors + 1;

            }
            else if (errors == 0) {
                $('#rejectBulkClose').trigger('click');
                model.PartnerCode($('#txtAreaPartnerCode').val());
                model.UserName($('#txtAreaUserName').val());
                model.FirstName($('#txtAreaFirstName').val());
                model.LastName($('#txtAreaLastName').val());
                self.ViewPartnerRegistrationModel().PartnerRegistrationListDTO(new eGateRoot.PartnerRegistrationListDTO());
                self.ViewPartnerRegistrationModel().PartnerRegistrationListDTO().PartnerName(model.PartnerCode());
                self.ViewPartnerRegistrationModel().PartnerRegistrationListDTO().PartnerType(model.PartnerType());
                self.ViewPartnerRegistrationModel().PartnerRegistrationListDTO().RequisitionNo(model.RequisitionNo());
                self.ViewPartnerRegistrationModel().PartnerRegistrationListDTO().PartnerCode(model.PartnerCode());
                self.ViewPartnerRegistrationModel().PartnerRegistrationListDTO().UserName(model.UserName());
                self.ViewPartnerRegistrationModel().PartnerRegistrationListDTO().FirstName(model.FirstName());
                self.ViewPartnerRegistrationModel().PartnerRegistrationListDTO().LastName(model.LastName());
                self.ViewPartnerRegistrationModel().PartnerRegistrationListDTO().UserRoleArray(model.UserRoleArray());
                model.RequisitionNo(self.ReqNo());
                $.each(self.ViewPartnerRegistrationModel().DocumentDTOs(), function (index, item) {
                    if (item.ValidTill() !== null && item.ValidTill() !== '') {
                        var validDate = self.ConvertDates(item.ValidTill());
                        item.ValidTill(validDate);
                    }
                });
                self.viewModelHelper.apiPost('api/ApprovePartnerRegistrationWithDocs', ko.mapping.toJSON(self.ViewPartnerRegistrationModel()), function message(data) {
                    toastr.options.closeButton = true;
                    toastr.options.positionClass = "toast-top-right";
                    toastr.success("Partner Registration approved successfully", "Partner Registration");
                    setTimeout(
                            function () {
                                window.location.href = "/PendingPartnerRegistrations";
                            }, 2000);
                }, null, false, application.viewbag.appSettings.uamapiUrl, null, 'UAM');
            }
        }

        self.ConvertDates = function (date) {
            var converted = kendo.parseDate(date, "dd-MM-yyyy");
            converted = kendo.toString(converted, "yyyy-MM-dd");
            return converted;
        }

        self.ReConvertDates = function (date) {
            var converted = kendo.parseDate(date, "yyyy-MM-dd");
            converted = kendo.toString(converted, "dd-MM-yyyy");
            return converted;
        }

        self.CheckUniqueCIN = function (model) {
            var regexpforCIN = new RegExp(/^([L|U]{1})([0-9]{5})([A-Za-z]{2})([0-9]{4})([A-Za-z]{3})([0-9]{6})$/);
            if (model.CIN() === '' && model.PartnerType() !== 'CustomHouseAgent' && self.PartnerRegistrationModel().validationEnabled() === true) {
                $('#validationCIN').text('* This field is required.');
            } else {
                $('#validationCIN').text('');
            }
            if (model.CIN() !== '') {
                if (!regexpforCIN.test(model.CIN().toUpperCase())) {
                    $('#validationCIN').text('Please Enter Valid CIN. Ex:U33337EA4455ADF333222');
                } else {
                    $('#validationCIN').text('');
                }
            }
        }

        //#region Verify
        self.VerifyForm = function (model) {
            var errors = 0;
            
            if (errors == 0) {
                $('#rejectBulkClose').trigger('click');
                model.RequisitionNo(self.ReqNo());
                $.each(model.DocumentDTOs(), function (index, item) {
                    if (item.ValidTill() !== null && item.ValidTill() !== '') {
                        var validDate = self.ConvertDates(item.ValidTill());
                        item.ValidTill(validDate);
                    }
                });
                self.viewModelHelper.apiPost('api/VerifyPartnerRegistrationWithDocs', ko.mapping.toJSON(model), function message(data) {
                    toastr.options.closeButton = true;
                    toastr.options.positionClass = "toast-top-right";
                    toastr.success("Partner Registration verified successfully", "Partner Registration");
                    setTimeout(function () {
                                window.location.href = "/PendingPartnerRegistrations";
                            }, 2000);
                }, null, false, application.viewbag.appSettings.uamapiUrl, null, 'UAM');
            }
        }
        //#endregion

        self.UpdateForm = function (model) {
            var errors = 0;

            if (errors == 0) {
                $('#rejectBulkClose').trigger('click');
                model.RequisitionNo(self.ReqNo());
                $.each(model.DocumentDTOs(), function (index, item) {
                    if (item.ValidTill() !== null && item.ValidTill() !== '') {
                        var validDate = self.ConvertDates(item.ValidTill());
                        item.ValidTill(validDate);
                    }
                });
                self.viewModelHelper.apiPost('api/UpdateRegistration', ko.mapping.toJSON(model), function message(data) {
                    toastr.options.closeButton = true;
                    toastr.options.positionClass = "toast-top-right";
                    toastr.success("Partner Registration updated successfully", "Partner Registration");
                    $.each(model.DocumentDTOs(), function (index, item) {
                        if (item.ValidTill() !== null && item.ValidTill() !== '') {
                            var validDate = self.ReConvertDates(item.ValidTill());
                            item.ValidTill(validDate);
                        }
                    });
                    
                }, null, false, application.viewbag.appSettings.uamapiUrl, null, 'UAM');
            }
        }
        

        self.ValidateControls = function(model, e) {
            if (e != undefined && e.isTrigger !== 3) {
                self.ViewPartnerRegistrationModel().validationEnabled(true);
                model.validationEnabled(true);
                self.PartnerValidation = ko.observable(model);
                self.PartnerValidation().errors = ko.validation.group(self.PartnerValidation());
                var errors = 0, dateErrors = 0;
                errors = self.PartnerValidation().errors().length;
                var regexpforEmail = new RegExp(/^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i);
                //var regexpforTAN = new RegExp(/^([a-zA-Z]){4}([0-9]){5}([a-zA-Z]){1}?$/);
                var regexpforTAN = new RegExp(/^[0-9|A-Za-z]{10,10}?$/);
                var regexpforPAN = new RegExp(/^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$/);
                var regexpforCIN = new RegExp(/^([L|U]{1})([0-9]{5})([A-Za-z]{2})([0-9]{4})([A-Za-z]{3})([0-9]{6})$/);
                //if (model.PartnerTypeArray() == "") {

                //    errors = errors + 1;
                //    $('#validationParterType').text('* This field is required.');
                //}

                if (model.PartnerType() === "") {
                    errors = errors + 1;
                    toastr.warning("Please select a Partner");
                }
                if (model.PartnerName().trim() === "") {
                    errors = errors + 1;
                    $('#partnerName').text('* This field is required.');
                }

                if (model.PartnerRegistrationAddress().HouseNumber().trim() === "") {
                    errors = errors + 1;
                    $('#validationHouseNumber').text('* This field is required.');
                }
                //if (model.PartnerRegistrationAddress().StreetName().trim() === "") {
                //    errors = errors + 1;
                //    $('#validationStreetName').text('* This field is required.');
                //}
                //if (model.PartnerRegistrationAddress().AreaName().trim() === "") {
                //    errors = errors + 1;
                //    $('#validationAreaName').text('* This field is required.');
                //}
                if (model.PartnerRegistrationAddress().TownOrCity().trim() === "") {
                    errors = errors + 1;
                    $('#validationTownOrCity').text('* This field is required.');
                }
                if (model.PartnerRegistrationAddress().ZipCode().trim() === "") {
                    errors = errors + 1;
                    $('#validationZipCode').text('* This field is required.');
                } else if (model.PartnerRegistrationAddress().ZipCode().length !== 6) {
                    errors = errors + 1;
                    $('#validationZipCode').text('Please Enter Valid Zip Code');
                }

                if (model.PAN() === '') {
                    errors = errors + 1;
                    $('#validationPAN').text('* This field is required.');
                }
                if (model.PAN() !== '') {
                    if (!regexpforPAN.test(model.PAN())) {
                        errors = errors + 1;
                        $('#validationPAN').text('Please enter valid PAN Number. Ex:AAAAA7867P');
                    }
                }

                if (model.PartnerRegistrationAddress().Country() == undefined) {
                    errors = errors + 1;
                    $('#validationCountry').text('* This field is required.');
                }
                if (model.PartnerRegistrationAddress().State() == undefined) {
                    errors = errors + 1;
                    $('#validationState').text('* This field is required.');
                }
                if (model.Place().trim() == "") {
                    errors = errors + 1;
                    $('#txtPlace').text('* This field is required.');
                }
                if (model.NatureOfBusiness().trim() == "") {
                    errors = errors + 1;
                    $('#txtNatureOfBusiness').text('* This field is required.');
                }
                if (model.TAN() === '' && model.PartnerType() === 'CustomHouseAgent') {
                    $('#validationTAN').text('');
                }
                if (model.TAN() === '' && model.PartnerType() !== 'CustomHouseAgent') {
                    errors = errors + 1;
                    $('#validationTAN').text('* This field is required.');
                }
                if (model.TAN() !== '') {
                    if (!regexpforTAN.test(model.TAN())) {
                        errors = errors + 1;
                        $('#validationTAN').text('Please Enter Valid TAN Numebr');
                    }
                }
                if (model.CIN() === '' && model.PartnerType() !== 'CustomHouseAgent') {
                    errors = errors + 1;
                    $('#validationCIN').text('* This field is required.');
                }
                if (model.CIN() !== '') {
                    if (!regexpforCIN.test(model.CIN().toUpperCase())) {
                        errors = errors + 1;
                        $('#validationCIN').text('Please enter valid CIN. Ex:U33337EA4455ADF333222');
                    }
                }

                var MainError = self.BooleanCharacter.Yes();
                // var i = 0;
                $.each(self.ViewPartnerRegistrationModel().PartnerDirectorDetailss(), function(index, item) {
                    var error = 0;
                    if (item !== undefined) {
                        if (item.PDirectorName().trim() === '' || item.PDirectorName().trim() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        } else if (item.PDirectorPAN() === '' || item.PDirectorPAN() === null || item.PDirectorPAN().length !== 10) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        } else if (item.PDirectorAddress().trim() === '' || item.PDirectorAddress().trim() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        } else if (item.PCountryCode() === '' || item.PCountryCode() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        } else if (item.PDirectorMobile() === '' || item.PDirectorMobile() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        } else if (item.PDirectorEmail() === '' || item.PDirectorEmail() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        }
                        if (item.PDirectorMobile() !== "") {
                            var telenumber1 = item.PDirectorMobile();
                            telenumber1 = telenumber1.replace(/(\)|\()|_|-+/g, '');
                            if (telenumber1.length !== 10) {
                                error++;
                                MainError = self.BooleanCharacter.No();
                            } else {
                                item.PDirectorMobile(telenumber1);
                            }
                        }
                        if (item.PDirectorEmail() !== '') {
                            if (!regexpforEmail.test(item.PDirectorEmail())) {
                                error++;
                                MainError = self.BooleanCharacter.No();
                            }
                        }
                        if (item.PDirectorPAN() !== '') {
                            if (!regexpforPAN.test(item.PDirectorPAN())) {
                                error++;
                                MainError = self.BooleanCharacter.No();
                            }
                        }


                        if (error > 0) {
                            item.ErrorStatus(true);
                            errors = errors + 1;

                        } else {
                            item.ErrorStatus(false);
                        }
                    }
                });

                $.each(self.ViewPartnerRegistrationModel().PartnerOperationsDetailss(), function(index, item) {
                    var error = 0;
                    if (item !== undefined) {
                        if (item.PDirectorName().trim() === '' || item.PDirectorName().trim() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        } else if (item.PCountryCode() === '' || item.PCountryCode() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        } else if (item.PDirectorMobile() === '' || item.PDirectorMobile() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        } else if (item.PDirectorEmail() === '' || item.PDirectorEmail() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        }
                        if (item.PDirectorMobile() !== "") {
                            var telenumber1 = item.PDirectorMobile();
                            telenumber1 = telenumber1.replace(/(\)|\()|_|-+/g, '');
                            if (telenumber1.length !== 10) {
                                error++;
                                MainError = self.BooleanCharacter.No();
                            } else {
                                item.PDirectorMobile(telenumber1);
                            }
                        }
                        if (item.PDirectorEmail() !== '') {
                            if (!regexpforEmail.test(item.PDirectorEmail())) {
                                error++;
                                MainError = self.BooleanCharacter.No();
                            }
                        }
                        if (error > 0) {
                            item.ErrorStatusOperations(true);
                            errors = errors + 1;

                        } else {
                            item.ErrorStatusOperations(false);
                        }
                    }
                });

                $.each(self.ViewPartnerRegistrationModel().PartnerITDetailss(), function(index, item) {
                    var error = 0;
                    if (item !== undefined) {
                        if (item.PDirectorName().trim() === '' || item.PDirectorName().trim() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        } else if (item.PCountryCode() === '' || item.PCountryCode() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        } else if (item.PDirectorMobile() === '' || item.PDirectorMobile() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        } else if (item.PDirectorEmail() === '' || item.PDirectorEmail() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        }
                        if (item.PDirectorMobile() !== "") {
                            var telenumber1 = item.PDirectorMobile();
                            telenumber1 = telenumber1.replace(/(\)|\()|_|-+/g, '');
                            if (telenumber1.length !== 10) {
                                error++;
                                MainError = self.BooleanCharacter.No();
                            } else {
                                item.PDirectorMobile(telenumber1);
                            }
                        }
                        if (item.PDirectorEmail() !== '') {
                            if (!regexpforEmail.test(item.PDirectorEmail())) {
                                error++;
                                MainError = self.BooleanCharacter.No();
                            }
                        }
                        if (error > 0) {
                            item.ErrorStatusIT(true);
                            errors = errors + 1;

                        } else {
                            item.ErrorStatusIT(false);
                        }
                    }
                });

                $.each(self.ViewPartnerRegistrationModel().PartnerFinanceDetailss(), function(index, item) {
                    var error = 0;
                    if (item !== undefined) {
                        if (item.PDirectorName().trim() === '' || item.PDirectorName().trim() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        } else if (item.PCountryCode() === '' || item.PCountryCode() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        } else if (item.PDirectorMobile() === '' || item.PDirectorMobile() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        } else if (item.PDirectorEmail() === '' || item.PDirectorEmail() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        }
                        if (item.PDirectorMobile() !== "") {
                            var telenumber1 = item.PDirectorMobile();
                            telenumber1 = telenumber1.replace(/(\)|\()|_|-+/g, '');
                            if (telenumber1.length !== 10) {
                                error++;
                                MainError = self.BooleanCharacter.No();
                            } else {
                                item.PDirectorMobile(telenumber1);
                            }
                        }
                        if (item.PDirectorEmail() !== '') {
                            if (!regexpforEmail.test(item.PDirectorEmail())) {
                                error++;
                                MainError = self.BooleanCharacter.No();
                            }
                        }
                        if (error > 0) {
                            item.ErrorStatusFinance(true);
                            errors = errors + 1;

                        } else {
                            item.ErrorStatusFinance(false);
                        }
                    }
                });

                $.each(self.ViewPartnerRegistrationModel().PartnerSalesDetailss(), function(index, item) {
                    var error = 0;
                    if (item !== undefined) {
                        if (item.PDirectorName().trim() === '' || item.PDirectorName().trim() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        } else if (item.PCountryCode() === '' || item.PCountryCode() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        } else if (item.PDirectorMobile() === '' || item.PDirectorMobile() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        } else if (item.PDirectorEmail() === '' || item.PDirectorEmail() === null) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        }
                        if (item.PDirectorMobile() !== "") {
                            var telenumber1 = item.PDirectorMobile();
                            telenumber1 = telenumber1.replace(/(\)|\()|_|-+/g, '');
                            if (telenumber1.length !== 10) {
                                error++;
                                MainError = self.BooleanCharacter.No();
                            } else {
                                item.PDirectorMobile(telenumber1);
                            }
                        }
                        if (item.PDirectorEmail() !== '') {
                            if (!regexpforEmail.test(item.PDirectorEmail())) {
                                error++;
                                MainError = self.BooleanCharacter.No();
                            }
                        }
                        if (error > 0) {
                            item.ErrorStatusSales(true);
                            errors = errors + 1;

                        } else {
                            item.ErrorStatusSales(false);
                        }
                    }
                });


                if (model.PartnerRegistrationAddress().Email() === "") {
                    errors = errors + 1;
                    $('#validationPartnerEmail').text('* This field is required.');
                }

                if (model.PartnerRegistrationAddress().Email() !== "") {
                    if (!regexpforEmail.test(model.PartnerRegistrationAddress().Email())) {
                        errors = errors + 1;
                        $('#validationPartnerEmail').text('Please Enter Valid Email Id');
                    }
                }

                if (model.PartnerRegistrationAddress().MobileNumber() === "") {
                    errors = errors + 1;
                    $('#validationPartnerMobile').text('* This field is required.');
                }
                if (!isEmpty(model.PartnerRegistrationAddress().MobileNumber())) {
                    var mobilNumber = model.PartnerRegistrationAddress().MobileNumber();
                    mobilNumber = mobilNumber.replace(/(\)|\()|_|-+/g, '');
                    if (mobilNumber.length !== 13) {
                        errors = errors + 1;
                    } else {
                        model.PartnerRegistrationAddress().MobileNumber(mobilNumber);
                    }
                }

                //if (model.PartnerRegistrationAddress().LogoFileName() == "") {

                //    $('#validationLogo').text('Please Select Logo');

                //}


                //if (model.PartnerRegistrationAddress().WebSite() == "") {
                //    errors = errors + 1;
                //    $('#validationWebSite').text('* This Field is Required');

                //}
                if (errors > 0) {
                    self.PartnerValidation().errors.showAllMessages();
                    toastr.warning("Please fill all the required data");
                    //$("#finMobile").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                    //$("#operationMobile").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                    //$("#iTMobile").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                    $.each(self.ViewPartnerRegistrationModel().PartnerDirectorDetailss(), function(index, item) {
                        $("#pDirectorMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                        $("#PDirectorTele" + index).kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                    });
                    $.each(self.ViewPartnerRegistrationModel().PartnerOperationsDetailss(), function(index, item) {
                        $("#pOperationsMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                    });
                    $.each(self.ViewPartnerRegistrationModel().PartnerITDetailss(), function(index, item) {
                        $("#pITMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                    });
                    $.each(self.ViewPartnerRegistrationModel().PartnerFinanceDetailss(), function(index, item) {
                        $("#pFinanceMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                    });
                    $.each(self.ViewPartnerRegistrationModel().PartnerSalesDetailss(), function(index, item) {
                        $("#pSalesMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                    });
                } else if (MainError !== self.BooleanCharacter.Yes()) {
                    toastr.warning("Please fill all the required data");
                }

                if (errors === 0 && model.PartnerDirectorDetailss().length === 0) {
                    errors = errors + 1;
                    toastr.warning("Please fill Details of Directors/Partners/Promoters.");
                } else if (errors === 0 && model.PartnerOperationsDetailss().length === 0) {
                    errors = errors + 1;
                    toastr.warning("Please fill Details of Operations Representative.");
                } else if (errors === 0 && model.PartnerITDetailss().length === 0) {
                    errors = errors + 1;
                    toastr.warning("Please fill Details of IT Representative.");
                } else if (errors === 0 && model.PartnerFinanceDetailss().length === 0) {
                    errors = errors + 1;
                    toastr.warning("Please fill Details of Finance Representative.");
                }


                if (errors === 0) {
                    var isAllDocs = 'Y';
                    var isRequiredDoc = 'Y';
                    var isDate = 'Y';
                    if (model.PartnerType() === "VesselOperatingAgent") {
                        $.each(model.DocumentDTOs(), function(index, item) {
                            item.ErrorStatusDocument(false);
                            if (item.DocumentType() === 'PAN Card (For Entity/Organization)' && (item.FileName() === null || item.FileName() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'Address Proof' && (item.FileName() === null || item.FileName() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'Valid Steamer Agency Licence With Jurisdictional Customs' && (item.FileName() === null || item.FileName() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'GST/Service Tax/VAT Registration Certificate' && (item.FileName() === null || item.FileName() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'Valid M.L.O Licence With Customs At Vijayawada' && (item.FileName() === null || item.FileName() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'TAN Card (For Entity/Organization)' && (item.FileName() === null || item.FileName() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                isRequiredDoc = 'N';
                            }

                            if (item.DocumentType() === 'Agreement With Agency' && item.FileName() !== null && item.FileName() !== '' && (item.ValidTill() === null || item.ValidTill() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                            }
                            if (item.DocumentType() === 'Valid M.L.O Licence With Customs At Vijayawada' && item.FileName() !== null && item.FileName() !== '' && (item.ValidTill() === null || item.ValidTill() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                            }
                            if (item.DocumentType() === 'Valid Steamer Agency Licence With Jurisdictional Customs' && item.FileName() !== null && item.FileName() !== '' && (item.ValidTill() === null || item.ValidTill() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                            }
                            if ($("#validTill" + index).is(':visible') === true && ($("#validTill" + index).val() === null || $("#validTill" + index).val() === "")) {
                                isDate = 'N';
                            }

                        });
                        if (isAllDocs === 'N') {
                            errors = errors + 1;
                            if (isRequiredDoc === 'N' && isDate === 'N') {
                                toastr.warning("Please Upload all the required document");
                                toastr.warning("Please fill Valid Till Date");
                            } else if (isRequiredDoc === 'N') {
                                toastr.warning("Please Upload all the required document");
                            } else if (isDate === 'N') {
                                toastr.warning("Please fill Valid Till Date");
                            }
                        }
                    } else if (model.PartnerType() === "ContainerOperatorAgent") {
                        $.each(model.DocumentDTOs(), function(index, item) {
                            item.ErrorStatusDocument(false);
                            if (item.DocumentType() === 'PAN Card (For Entity/Organization)' && (item.FileName() === null || item.FileName() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                isRequiredDoc = 'N';
                            }

                            if (item.DocumentType() === 'Address Proof' && (item.FileName() === null || item.FileName() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                isRequiredDoc = 'N';
                            }

                            if (item.DocumentType() === 'Valid Steamer Agency Licence With Jurisdictional Customs' && (item.FileName() === null || item.FileName() === '')) {
                                isAllDocs = 'N';
                                item.ErrorStatusDocument(true);
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'Valid Customs Continuity Bond' && (item.FileName() === null || item.FileName() === '')) {
                                isAllDocs = 'N';
                                item.ErrorStatusDocument(true);
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'GST/Service Tax/VAT Registration Certificate' && (item.FileName() === null || item.FileName() === '')) {
                                isAllDocs = 'N';
                                item.ErrorStatusDocument(true);
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'TAN Card (For Entity/Organization)' && (item.FileName() === null || item.FileName() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'Valid Agency Agreement' && item.FileName() !== null && item.FileName() !== '' && (item.ValidTill() === null || item.ValidTill() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                            }
                            if (item.DocumentType() === 'Valid Customs Continuity Bond' && item.FileName() !== null && item.FileName() !== '' && (item.ValidTill() === null || item.ValidTill() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                            }
                            if (item.DocumentType() === 'Valid Steamer Agency Licence With Jurisdictional Customs' && item.FileName() !== null && item.FileName() !== '' && (item.ValidTill() === null || item.ValidTill() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                            }
                            if ($("#validTill" + index).is(':visible') === true && ($("#validTill" + index).val() === null || $("#validTill" + index).val() === "")) {
                                isDate = 'N';
                            }

                        });
                        if (isAllDocs === 'N') {
                            errors = errors + 1;
                            if (isRequiredDoc === 'N' && isDate === 'N') {
                                toastr.warning("Please Upload all the required document");
                                toastr.warning("Please fill Valid Till Date");
                            } else if (isRequiredDoc === 'N') {
                                toastr.warning("Please Upload all the required document");
                            } else if (isDate === 'N') {
                                toastr.warning("Please fill Valid Till Date");
                            }
                        }
                    } else if (model.PartnerType() === "CustomHouseAgent") {
                        $.each(model.DocumentDTOs(), function(index, item) {
                            item.ErrorStatusDocument(false);
                            if (item.DocumentType() === 'PAN Card (For Entity/Organization/Individual)' && (item.FileName() === null || item.FileName() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'Address Proof' && (item.FileName() === null || item.FileName() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'GST/Service Tax/VAT Registration Certificate' && (item.FileName() === null || item.FileName() === '')) {
                                isAllDocs = 'N';
                                item.ErrorStatusDocument(true);
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'CHA/MTO (For CHA/FF) Licence Registration With Krishnapatnam Port' && (item.FileName() === null || item.FileName() === '')) {
                                isAllDocs = 'N';
                                item.ErrorStatusDocument(true);
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'CHA/MTO (For CHA/FF) Licence Registration With Krishnapatnam Port' && item.FileName() !== null && item.FileName() !== '' && (item.ValidTill() === null || item.ValidTill() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                            }
                            if ($("#validTill" + index).is(':visible') === true && ($("#validTill" + index).val() === null || $("#validTill" + index).val() === "")) {
                                isDate = 'N';
                            }

                        });
                        if (isAllDocs === 'N') {
                            errors = errors + 1;
                            if (isRequiredDoc === 'N' && isDate === 'N') {
                                toastr.warning("Please Upload all the required document");
                                toastr.warning("Please fill Valid Till Date");
                            } else if (isRequiredDoc === 'N') {
                                toastr.warning("Please Upload all the required document");
                            } else if (isDate === 'N') {
                                toastr.warning("Please fill Valid Till Date");
                            }
                        }
                    } else if (model.PartnerType() === "ContainerFreightStation") {
                        $.each(model.DocumentDTOs(), function(index, item) {
                            item.ErrorStatusDocument(false);
                            if ((item.DocumentType() === 'PAN Card (For Entity/Organization)' || item.DocumentType() === 'PAN/TAN Card (For Entity/Organization)') && (item.FileName() === null || item.FileName() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'CFS Licence Copy' && (item.FileName() === null || item.FileName() === '')) {
                                isAllDocs = 'N';
                                item.ErrorStatusDocument(true);
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'Address Proof' && (item.FileName() === null || item.FileName() === '')) {
                                isAllDocs = 'N';
                                item.ErrorStatusDocument(true);
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'GST/Service Tax/VAT Registration Certificate' && (item.FileName() === null || item.FileName() === '')) {
                                isAllDocs = 'N';
                                item.ErrorStatusDocument(true);
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'CFS Licence Copy' && item.FileName() !== null && item.FileName() !== '' && (item.ValidTill() === null || item.ValidTill() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                            }
                            if ($("#validTill" + index).is(':visible') === true && ($("#validTill" + index).val() === null || $("#validTill" + index).val() === "")) {
                                isDate = 'N';
                            }
                        });
                        if (isAllDocs === 'N') {
                            errors = errors + 1;
                            if (isRequiredDoc === 'N' && isDate === 'N') {
                                toastr.warning("Please Upload all the required document");
                                toastr.warning("Please fill Valid Till Date");
                            } else if (isRequiredDoc === 'N') {
                                toastr.warning("Please Upload all the required document");
                            } else if (isDate === 'N') {
                                toastr.warning("Please fill Valid Till Date");
                            }
                        }
                    } else if (model.PartnerType() === "MandR") {
                        $.each(model.DocumentDTOs(), function(index, item) {
                            item.ErrorStatusDocument(false);
                            if (item.DocumentType() === 'PAN Card (For Entity/Organization)' && (item.FileName() === null || item.FileName() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'IICL Copy' && (item.FileName() === null || item.FileName() === '')) {
                                isAllDocs = 'N';
                                item.ErrorStatusDocument(true);
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'Address Proof' && (item.FileName() === null || item.FileName() === '')) {
                                isAllDocs = 'N';
                                item.ErrorStatusDocument(true);
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'TAN Card (For Entity/Organization)' && (item.FileName() === null || item.FileName() === '')) {
                                isAllDocs = 'N';
                                item.ErrorStatusDocument(true);
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'GST/Service Tax/VAT Registration Certificate' && (item.FileName() === null || item.FileName() === '')) {
                                isAllDocs = 'N';
                                item.ErrorStatusDocument(true);
                                isRequiredDoc = 'N';
                            }
                            if (item.DocumentType() === 'IICL Copy' && item.FileName() !== null && item.FileName() !== '' && (item.ValidTill() === null || item.ValidTill() === '')) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                            }
                            if ($("#validTill" + index).is(':visible') === true && ($("#validTill" + index).val() === null || $("#validTill" + index).val() === "")) {
                                isDate = 'N';
                            }
                        });
                        if (isAllDocs === 'N') {
                            errors = errors + 1;
                            if (isRequiredDoc === 'N' && isDate === 'N') {
                                toastr.warning("Please Upload all the required document");
                                toastr.warning("Please fill Valid Till Date");
                            } else if (isRequiredDoc === 'N') {
                                toastr.warning("Please Upload all the required document");
                            } else if (isDate === 'N') {
                                toastr.warning("Please fill Valid Till Date");
                            }
                        }
                    }
                }


                //#endregion 
                return errors;


            } else {
                return 0;
            }
        }


        self.Initialize();

    }
    eGateRoot.PartnerRegistrationViewViewModel = PartnerRegistrationViewViewModel;
}(window.eGateRoot));


validateHouseNumber = function () {
    if ($('#houseNumber').val() !== "") {
        $('#validationHouseNumber').text('');
    }
}


validateStreetName = function () {
    if ($('#streetName').val() !== "") {
        $('#validationStreetName').text('');
    }
}

validateareaName = function () {
    if ($('#areaName').val() !== "") {
        $('#validationAreaName').text('');
    }
}

validatetownOrCity = function () {
    if ($('#townOrCity').val() !== "") {
        $('#validationTownOrCity').text('');
    }
}

validatezipCode = function () {
    if ($('#zipCode').val() !== "") {
        $('#validationZipCode').text('');
    }
}

validateCountry = function () {
    if ($('#ddlCountry').val() != undefined) {
        $('#validationCountry').text('');
    }
}

validateContactNumber = function () {
    $("#contactNumber").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
    if ($('#contactNumber').val() != "") {
        $('#validationContactNumber').text('');
    }
}
validatefinNumber = function () {
    $("#finMobile").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
    if ($('#finMobile').val() !== "") {
        $('#validationfinMobile').text('');
    }
}
validateITMobile = function () {
    $("#iTMobile").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
    if ($('#iTMobile').val() !== "") {
        $('#validationiTMobile').text('');
    }
}
validateOperationMobile = function () {
    $("#operationMobile").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
    if ($('#operationMobile').val() !== "") {
        $('#validationOperationMobile').text('');
    }
}
//validateEmailId = function () {
//    if ($('#emailId').val() != "") {
//        $('#validationEmailId').text('');
//    }
//}
validateFinEmailId = function () {
    if ($('#finEmail').val() !== "") {
        $('#validationFinEmail').text('');
    }
}
validateOperationEmail = function () {
    if ($('#operationEmail').val() !== "") {
        $('#validationOperationsEmail').text('');
    }
}
validateITEmail = function () {
    if ($('#itEmail').val() !== "") {
        $('#ValidationiTEmail').text('');
    }
}
validatePAN = function () {
    if ($('#txtPAN').val() !== "") {
        $('#validationPAN').text('');
    }
}
validatePartnerEmail = function () {
    if ($('#PartnerEmailId').val() !== "") {
        $('#validationPartnerEmail').text('');
    }
}
validatePartnerMobile = function () {
    $("#txtMobileNo").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
    if ($('#txtMobileNo').val() !== "") {
        var mobilNumber = $('#txtMobileNo').val();
        $('#validationPartnerMobile').text('');
        mobilNumber = mobilNumber.replace(/(\)|\()|_|-+/g, '');
        if (mobilNumber.length !== 13) {
            $('#validationPartnerMobile').text("Please enter valid Mobile Number.");
        }
    }
}
validateState = function () {

    if ($('#ddlState').val() != undefined) {

        $('#validationState').text('');

    }

}

function SetFocus() {
    $("#finMobile").bind("focus", function () {
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
    $("#operationMobile").bind("focus", function () {
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
    $("#iTMobile").bind("focus", function () {
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

function SetFocusGrid(id) {
    $(id).bind("focus", function () {
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


validateRole = function () {
    if ($('#userPort').val().trim() !== '' || $('#userPort').val().trim() !== null || $('#userPort').val().trim() !== undefined) {
        $('#spnrole').text('');

    }


}


changeFirstname = function () {
    if ($('#txtAreaFirstName').val() !== '' || $('#txtAreaFirstName').val() !== null || $('#txtAreaFirstName').val() !== undefined) {
        $('#spanFirstName').text('');
    }

}
changeLastname = function () {
    if ($('#txtAreaLastName').val() !== '' || $('#txtAreaLastName').val() !== null || $('#txtAreaLastName').val() !== undefined) {
        $('#spanLastName').text('');
    }

}
