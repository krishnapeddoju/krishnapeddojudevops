(function (eGateRoot) {
    var PartnerKYCFormViewModel = function () {
        var self = this;

        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.validationHelper = new eGateRoot.ValidationHelper();
        self.validationEnabled = ko.observable();
        //self.validationEnabled2 = ko.observable();
        self.viewMode = ko.observable();
        self.editableView = ko.observable(true);
        self.PartnerRegistrationModel = ko.observable(new eGateRoot.PartnerRegistrationModel());
        self.PartnerRegistrationAddres = ko.observable(new eGateRoot.PartnerRegistrationAddres());

        self.FileDocument = ko.observable(new eGateRoot.FileDocument());

        self.PartnerDirectorDetails = ko.observableArray();

        self.IsReset = ko.observable(true);
        self.IsSave = ko.observable(true);
        self.IsUpdate = ko.observable(true);
        self.IsExit = ko.observable(true);
        self.IsCodeEnable = ko.observable(true);

        toastr.options.closeButton = true;
        toastr.options.positionClass = "toast-top-right";
        toastr.options.timeOut = 2000;
        //toastr.options.timeOut = 100;
        self.Applications = ko.observableArray([]);
        self.Ports = ko.observableArray([]);
        self.Countries = ko.observableArray([]);
        self.PartnerTypes = ko.observableArray([]);
        self.States = ko.observableArray([]);
        self.partnerCodes = ko.observableArray([]);
        self.YearsList = ko.observableArray([]);
        self.StatusList = ko.observableArray([]);
        self.DocumentList = ko.observableArray([]);
        self.DocsList = ko.observableArray([]);

        self.IsUpload = ko.observable(true);
        self.PartnerCodeEnable = ko.observable(true);
        self.bufferPartnerType = ko.observable();
        self.BooleanCharacter = new eGateRoot.BooleanCharacter();
        self.dateFormat = new eGateRoot.DateFormat();
        self.visibleValidTill = ko.observable(false);
        self.IsPartnerDuplicate = ko.observable(false);
        //self.Uploadfilesarray = ko.observableArray([]);
        //self.FileName = ko.observable();
        //self.FilePathName = ko.observable();
        self.SelectStatesForView = function (model) {
            $.each(self.Countries(), function (k, v) {
                if (v.CountryCode() == model.PartnerRegistrationAddress.Country) {
                    ko.mapping.fromJS(v.States, {}, self.States);
                }
            });
        }
        self.enablePanel = ko.observable(false);
        self.changeValidDate = function (model) {

            $('#validTill').val('');
            model.ValidTill('');
            if (self.PartnerRegistrationModel().DocumentDTOs().length > 0) {
                $.each(self.PartnerRegistrationModel().DocumentDTOs(), function (index, item) {

                    if (item.DocumentType() === model.DocumentType()) {

                        toastr.warning(model.DocumentType() + " Already Uploaded", $('#spnTitle').text());
                        model.DocumentType('');
                        return false;

                    }


                });

            }
            if ((model.PartnerType() === "VesselOperatingAgent") && (model.DocumentType() === "Agreement With Agency" || model.DocumentType() === "Valid M.L.O Licence With Customs At Vijayawada" || model.DocumentType() === "Valid Steamer Agency Licence With Jurisdictional Customs")) {
                self.visibleValidTill(true);


            }
            else if ((model.PartnerType() === "ContainerOperatorAgent") && (model.DocumentType() === "Valid Agency Agreement" || model.DocumentType() === "Valid Customs Continuity Bond" || model.DocumentType() === "Valid Steamer Agency Licence With Jurisdictional Customs")) {

                self.visibleValidTill(true);


            }
            else if ((model.PartnerType() === "CustomHouseAgent") && (model.DocumentType() === "CHA/MTO (For CHA/FF) Licence Registration With Krishnapatnam Port")) {

                self.visibleValidTill(true);


            }
            else if ((model.PartnerType() === "ContainerFreightStation") && (model.DocumentType() === "CFS Licence Copy")) {

                self.visibleValidTill(true);


            }
            else if ((model.PartnerType() === "MandR") && (model.DocumentType() === "IICL Copy")) {

                self.visibleValidTill(true);


            }
            else {
                self.visibleValidTill(false);

            }



        }

        self.Initialize = function () {
            self.PartnerRegistrationModel(new eGateRoot.PartnerRegistrationModel());
            self.PartnerRegistrationModel().PartnerDirectorDetailss.push(new eGateRoot.PartnerDirectorDetails());
            self.PartnerRegistrationModel().PartnerOperationsDetailss.push(new eGateRoot.PartnerDirectorDetails());
            self.PartnerRegistrationModel().PartnerITDetailss.push(new eGateRoot.PartnerDirectorDetails());
            self.PartnerRegistrationModel().PartnerFinanceDetailss.push(new eGateRoot.PartnerDirectorDetails());

            setTimeout(function () {
                self.PartnerRegistrationModel().PartnerDirectorDetailss()[0].Type("Director");
                $("#pDirectorMobile0").kendoMaskedTextBox({ mask: "000-000-0000" });
                $("#PDirectorTele0").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                SetFocusGrid(("#pDirectorMobile0"));
                SetFocusGrid(("#PDirectorTele0"));

                self.PartnerRegistrationModel().PartnerOperationsDetailss()[0].Type("Operations");
                $("#pOperationsMobile0").kendoMaskedTextBox({ mask: "000-000-0000" });
                SetFocusGrid(("#pOperationsMobile0"));

                self.PartnerRegistrationModel().PartnerITDetailss()[0].Type("IT");
                $("#pITMobile0").kendoMaskedTextBox({ mask: "000-000-0000" });
                SetFocusGrid(("#pITMobile0"));

                self.PartnerRegistrationModel().PartnerFinanceDetailss()[0].Type("Finance");
                $("#pFinanceMobile0").kendoMaskedTextBox({ mask: "000-000-0000" });
                SetFocusGrid(("#pFinanceMobile0"));

            }, 500);
            self.PartnerRegistrationAddres(new eGateRoot.PartnerRegistrationAddres());
            self.viewMode = ko.observable(true);
            //self.LoadApplications();
            self.LoadYearsList();
            self.LoadCountries();
            self.LoadStatusList();
            self.LoadDocumentType();
            self.GetDocTypes();
            //self.LoadPorts();
            //self.LoadPartnerTypes();
            self.viewMode('Form');
            $('#spnTitile').html("Add Partner");
            $(document).ready(function () {
                $("#validTill").kendoMaskedDatePicker();
                $('#validTill').data('kendoDatePicker');
                //$('#validTill').data('kendoDatePicker').min(new Date());

                $("#txtMobileNo").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                $("#txtMobileNoSearch").kendoMaskedTextBox({ mask: "(000)000-000-0000" });

                //$("#operationMobile").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                //$("#iTMobile").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                SetFocus();
            });

            //$(document).ready(function () {

            //});

        }


        ////#region Getting Documnt type
        //self.GetDocTypes = function (model) {
        //    self.PartnerRegistrationModel().PartnerType();
        //    self.viewModelHelper.apiGetAno("api/GetDocumentTypesByPartnerType", { partnerType: self.PartnerRegistrationModel().PartnerType() }, function (result) {
        //        ko.mapping.fromJS(result, {}, self.DocumentList);
        //        self.PartnerRegistrationModel().DocumentType('');
        //        self.PartnerRegistrationModel().DocumentDTOs([]);
        //        self.PartnerRegistrationModel().ValidTillPartnerRegistrationModel('');
        //    }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        //    return true;
        //}
        ////#endregion



        //#region Getting Documnt type
        self.GetDocTypes = function (model) {

            if (model !== undefined && model !== null) {
                var partnerType = '';
                if (self.PartnerRegistrationModel().validationEnabled() && model.PartnerType() !== "CustomHouseAgent" && model.CIN() === '') {
                    $('#validationCIN').text('* This field is required.');
                } else {
                    $('#validationCIN').text('');
                }
                if (model.PartnerType() === "VesselOperatingAgent") {
                    partnerType = "VOA";
                } else if (model.PartnerType() === "ContainerOperatorAgent") {
                    partnerType = "COA";
                } else if (model.PartnerType() === "CustomHouseAgent") {
                    partnerType = "CHA / FF";
                } else if (model.PartnerType() === "ContainerFreightStation") {
                    partnerType = "CFS";
                } else if (model.PartnerType() === "MandR") {
                    partnerType = "M&R";
                }

                $.confirm({
                    'title': 'Partner Registration',
                    'message': 'You are registering as <label id="lblMiss" style="line-height: 120%;"> ' + partnerType + ',  </label> <br/> <br/>' + '    Are you sure ?',
                    'buttons': {
                        'Yes': {
                            'class': 'green',
                            'action': function () {
                                 $('#' + self.PartnerRegistrationModel().PartnerType()).prop('checked', true);
                                self.viewModelHelper.apiGetAno("api/GetDocumentTypesByPartnerType", { partnerType: self.PartnerRegistrationModel().PartnerType() }, function (result) {
                                    self.PartnerRegistrationModel().DocumentDTOs(ko.utils.arrayMap(result, function (document) {                                       
                                        return new eGateRoot.FileDocument(document);
                                    }));                                 
                                        $.each(self.PartnerRegistrationModel().DocumentDTOs(), function (indexIntern, itemData) {
                                                if (itemData.DocumentType() === "Service Tax/VAT Registration Certificate") {
                                                    itemData.DocumentType("GST/Service Tax/VAT Registration Certificate")
                                            }                                      
                                    });
                                    self.CheckUniquePartnerName(model);
                                }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
                                return true;

                            }
                        },
                        'No': {
                            'class': 'red',
                            'action': function () {
                                model.PartnerType('');
                                //$('#' + self.PartnerRegistrationModel().PartnerType()).attr('checked', true);
                            }
                        }
                    }
                });
            }

        }
        //#endregion

        self.GetDocTypesByPartnerType = function (partnerTypevar) {
            self.viewModelHelper.apiGetAno("api/GetDocumentTypesByPartnerType", { partnerType: partnerTypevar }, function (result) {
                self.PartnerRegistrationModel().DocumentDTOs([]);
                self.PartnerRegistrationModel().DocumentDTOs(ko.utils.arrayMap(result, function (document) {
                    return new eGateRoot.FileDocument(document);
                }));

                $.each(self.DocumentDTOs(), function (index, item) {
                    $.each(self.PartnerRegistrationModel().DocumentDTOs(), function (indexIntern, itemData) {
                        if (itemData.DocumentType() === item.DocumentType()) {
                            if (itemData.DocumentType() === "Service Tax/VAT Registration Certificate")
                            {
                                itemData.DocumentType("GST/Service Tax/VAT Registration Certificate")
                            }

                            itemData.FileName(item.FileName());
                            itemData.OriginalName(item.OriginalName());
                            itemData.ValidTill(item.ValidTill());
                            itemData.IsDeleted(item.IsDeleted());
                        }
                    });
                });
                setTimeout(function () {
                    $.each(self.PartnerRegistrationModel().DocumentDTOs(), function (index, item) {
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

        self.GetPartnerDetails = function (model) {

            var errors = 0;
            if (isEmpty(model.RequisitionNo())) {
                toastr.warning("Please enter Request No.", $('#spnTitle').text());
                errors++;
                return false;
            }
            else if (isEmpty(model.Email2())) {
                toastr.warning("Please enter Email Id", $('#spnTitle').text());
                errors++;
                return false;
            }
            else if (isEmpty(model.ContactNumber2())) {
                toastr.warning("Please enter Mobile Number", $('#spnTitle').text());
                errors++;
                return false;
            }
            else if (!isEmpty(model.ContactNumber2()) && model.ContactNumber2().indexOf('_') !== -1) {
                toastr.warning("Please enter valid Mobile Number", $('#spnTitle').text());
                errors++;
                return false;
            }
            self.PartnerRegistrationModel(new eGateRoot.PartnerRegistrationModel);
            if (errors === 0) {
                var telenumber1 = model.ContactNumber2();
                model.ContactNumber2(telenumber1.replace(/(\)|\()|_|-+/g, ''));
                self.viewModelHelper.apiGetAno("api/GetPartnerRegistration", { requisitionNo: model.RequisitionNo(), emailId: model.Email2(), mobileNumber: model.ContactNumber2() }, function (result) {
                    self.PartnerRegistrationModel().RequisitionNo(model.RequisitionNo());
                    self.PartnerRegistrationModel().Email2(model.Email2());
                    self.PartnerRegistrationModel().ContactNumber2(model.ContactNumber2());
                    if (result !== null) {
                        if (result.WFStatus == 'New' || result.WFStatus == 'Rejected' || result.WFStatus == 'RejectedAtVerification') {
                            self.enablePanel(true);
                            self.DocumentDTOs = ko.observable(ko.utils.arrayMap(result.DocumentDTOs, function (document) {
                                return new eGateRoot.FileDocument(document);
                            }));
                            self.SelectStatesforEdit(result.PartnerRegistrationAddress);
                            self.PartnerRegistrationModel(new eGateRoot.PartnerRegistrationModel(result));
                            self.PartnerRegistrationModel().RequisitionNo(model.RequisitionNo());
                            self.PartnerRegistrationModel().Email2(model.Email2());
                            self.PartnerRegistrationModel().ContactNumber2(model.ContactNumber2());
                            self.abc = ko.observable(new eGateRoot.PartnerRegistrationModel(result));
                            self.partnerDirectorArray = ko.observableArray([]);
                            $("#txtMobileNo").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                            $("#txtMobileNoSearch").kendoMaskedTextBox({ mask: "(000)000-000-0000" });

                            $.each(self.abc().PartnerDirectorDetailss(), function (index, item) {
                                if (item.Type() === "Operations") {
                                    self.PartnerRegistrationModel().PartnerOperationsDetailss.push(item);
                                    $("#pOperationsMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                                } else if (item.Type() === "IT") {
                                    self.PartnerRegistrationModel().PartnerITDetailss.push(item);
                                    $("#pITMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                                } else if (item.Type() === "Finance") {
                                    self.PartnerRegistrationModel().PartnerFinanceDetailss.push(item);
                                    $("#pFinanceMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                                } else if (item.Type() === "Sales") {
                                    self.PartnerRegistrationModel().PartnerSalesDetailss.push(item);
                                    $("#pSalesMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                                } else {
                                    self.partnerDirectorArray.push(item);
                                }
                            });


                            self.PartnerRegistrationModel().PartnerDirectorDetailss([]);
                            self.PartnerRegistrationModel().PartnerDirectorDetailss(self.partnerDirectorArray());

                            $.each(self.PartnerRegistrationModel().PartnerDirectorDetailss(), function (index, item) {
                                if (item.Type() === "Director") {
                                    $("#pDirectorMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                                }
                            });
                            $.each(self.PartnerRegistrationModel().PartnerOperationsDetailss(), function (index, item) {
                                $("#pOperationsMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                            });
                            $.each(self.PartnerRegistrationModel().PartnerITDetailss(), function (index, item) {
                                $("#pITMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                            });
                            $.each(self.PartnerRegistrationModel().PartnerFinanceDetailss(), function (index, item) {
                                $("#pFinanceMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                            });
                            $.each(self.PartnerRegistrationModel().PartnerSalesDetailss(), function (index, item) {
                                $("#pSalesMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                            });

                            var partnerType = self.PartnerRegistrationModel().PartnerType();
                            self.GetDocTypesByPartnerType(partnerType);
                            //var nextDayDate = new Date();
                            //nextDayDate.setDate((new Date()).getDate() + 1);
                            //$.each(self.PartnerRegistrationModel().DocumentDTOs(), function(index, item) {
                            //    if ((partnerType === "VesselOperatingAgent") && (item.DocumentType() === "Agreement With Agency" || item.DocumentType() === "Valid M.L.O Licence With Customs At Vijayawada" || item.DocumentType() === "Valid Steamer Agency Licence With Jurisdictional Customs")) {
                            //        $("#IsvalidTill" + index).show();
                            //        setTimeout(function () { $("#validTill" + index).data('kendoDatePicker').min(nextDayDate); }, 200);
                            //    } else if ((partnerType === "ContainerOperatorAgent") && (item.DocumentType() === "Valid Agency Agreement" || item.DocumentType() === "Valid Customs Continuity Bond" || item.DocumentType() === "Valid Steamer Agency Licence With Jurisdictional Customs")) {
                            //        $("#IsvalidTill" + index).show();
                            //        setTimeout(function () { $("#validTill" + index).data('kendoDatePicker').min(nextDayDate); }, 200);
                            //    } else if ((partnerType === "CustomHouseAgent") && (item.DocumentType() === "CHA/MTO (For CHA/FF) Licence Registration With Krishnapatnam Port")) {
                            //        $("#IsvalidTill" + index).show();
                            //        setTimeout(function () { $("#validTill" + index).data('kendoDatePicker').min(nextDayDate); }, 200);
                            //    } else if ((partnerType === "ContainerFreightStation") && (item.DocumentType() === "CFS Licence Copy")) {
                            //        $("#IsvalidTill" + index).show();
                            //        setTimeout(function () { $("#validTill" + index).data('kendoDatePicker').min(nextDayDate); }, 200);
                            //    } else if ((partnerType === "MandR") && (item.DocumentType() === "IICL Copy")) {
                            //        $("#IsvalidTill" + index).show();
                            //        setTimeout(function () { $("#validTill" + index).data('kendoDatePicker').min(nextDayDate); }, 200);
                            //    } else {
                            //        $("#IsvalidTill" + index).hide();
                            //    }
                            //});

                            setTimeout(function () {
                                document.getElementById("sigImage").src = application.viewbag.appSettings.uamapiUrl + "/FileUploads/Logo/" + self.PartnerRegistrationModel().PartnerRegistrationAddressEdit().LogoPath();
                            });
                        } else {
                            toastr.warning("Approval for the record is in progress", $('#spnTitle').text());
                            $("#txtMobileNoSearch").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                            self.enablePanel(false);
                        }
                    } else {
                        toastr.warning("No matching records found", $('#spnTitle').text());
                        $("#txtMobileNoSearch").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                        self.enablePanel(false);
                    }
                }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');

            }

        }

        //#region Add Remove Director Details
        //#region Add New Details 
        self.AddNewDetails = function () {
            if (self.PartnerRegistrationModel().PartnerDirectorDetailss().length > 0) {
                self.PartnerRegistrationModel().PartnerDirectorDetailss.push(new eGateRoot.PartnerDirectorDetails());
                $("#pDirectorMobile" + (self.PartnerRegistrationModel().PartnerDirectorDetailss().length - 1)).kendoMaskedTextBox({ mask: "000-000-0000" });
                $("#PDirectorTele" + (self.PartnerRegistrationModel().PartnerDirectorDetailss().length - 1)).kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                SetFocusGrid(("#PDirectorTele" + (self.PartnerRegistrationModel().PartnerDirectorDetailss().length - 1)));
                SetFocusGrid(("#pDirectorMobile" + (self.PartnerRegistrationModel().PartnerDirectorDetailss().length - 1)));
                self.PartnerRegistrationModel().PartnerDirectorDetailss()[self.PartnerRegistrationModel().PartnerDirectorDetailss().length - 1].Type("Director");
            }
            else {
                self.PartnerRegistrationModel().PartnerDirectorDetailss.push(new eGateRoot.PartnerDirectorDetails());
                self.PartnerRegistrationModel().PartnerDirectorDetailss()[0].Type("Director");
                $("#pDirectorMobile0").kendoMaskedTextBox({ mask: "000-000-0000" });
                $("#PDirectorTele0").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                SetFocusGrid(("#pDirectorMobile0"));
                SetFocusGrid(("#PDirectorTele0"));
            }
        }
        //#endregion

        //#region Remove Row
        self.RemoveDetails = function (row) {
            $.confirm({
                'title': 'Partner Registration',
                'message': 'Are you sure you want to Remove Directors/Partners/Promoters Details?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                            if (isEmpty(row.PDirectorDetailsId())) {
                                self.PartnerRegistrationModel().PartnerDirectorDetailss.remove(row);
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

        //#region Add Remove Operations Details
        //#region Add New Details 
        self.AddNewOperationsDetails = function () {
            if (self.PartnerRegistrationModel().PartnerOperationsDetailss().length > 0) {
                self.PartnerRegistrationModel().PartnerOperationsDetailss.push(new eGateRoot.PartnerDirectorDetails());
                $("#pOperationsMobile" + (self.PartnerRegistrationModel().PartnerOperationsDetailss().length - 1)).kendoMaskedTextBox({ mask: "000-000-0000" });
                SetFocusGrid(("#pOperationsMobile" + (self.PartnerRegistrationModel().PartnerOperationsDetailss().length - 1)));
                self.PartnerRegistrationModel().PartnerOperationsDetailss()[self.PartnerRegistrationModel().PartnerOperationsDetailss().length - 1].Type("Operations");
            }
            else {
                self.PartnerRegistrationModel().PartnerOperationsDetailss.push(new eGateRoot.PartnerDirectorDetails());
                self.PartnerRegistrationModel().PartnerOperationsDetailss()[0].Type("Operations");
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
                                self.PartnerRegistrationModel().PartnerOperationsDetailss.remove(row);
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
            if (self.PartnerRegistrationModel().PartnerITDetailss().length > 0) {
                self.PartnerRegistrationModel().PartnerITDetailss.push(new eGateRoot.PartnerDirectorDetails());
                $("#pITMobile" + (self.PartnerRegistrationModel().PartnerITDetailss().length - 1)).kendoMaskedTextBox({ mask: "000-000-0000" });
                SetFocusGrid(("#pITMobile" + (self.PartnerRegistrationModel().PartnerITDetailss().length - 1)));
                self.PartnerRegistrationModel().PartnerITDetailss()[self.PartnerRegistrationModel().PartnerITDetailss().length - 1].Type("IT");
            }
            else {
                self.PartnerRegistrationModel().PartnerITDetailss.push(new eGateRoot.PartnerDirectorDetails());
                self.PartnerRegistrationModel().PartnerITDetailss()[0].Type("IT");
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
                                self.PartnerRegistrationModel().PartnerITDetailss.remove(row);
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
            if (self.PartnerRegistrationModel().PartnerFinanceDetailss().length > 0) {
                self.PartnerRegistrationModel().PartnerFinanceDetailss.push(new eGateRoot.PartnerDirectorDetails());
                $("#pFinanceMobile" + (self.PartnerRegistrationModel().PartnerFinanceDetailss().length - 1)).kendoMaskedTextBox({ mask: "000-000-0000" });
                SetFocusGrid(("#pFinanceMobile" + (self.PartnerRegistrationModel().PartnerFinanceDetailss().length - 1)));
                self.PartnerRegistrationModel().PartnerFinanceDetailss()[self.PartnerRegistrationModel().PartnerFinanceDetailss().length - 1].Type("Finance");
            }
            else {
                self.PartnerRegistrationModel().PartnerFinanceDetailss.push(new eGateRoot.PartnerDirectorDetails());
                self.PartnerRegistrationModel().PartnerFinanceDetailss()[0].Type("Finance");
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
                                self.PartnerRegistrationModel().PartnerFinanceDetailss.remove(row);
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
            if (self.PartnerRegistrationModel().PartnerSalesDetailss().length > 0) {
                self.PartnerRegistrationModel().PartnerSalesDetailss.push(new eGateRoot.PartnerDirectorDetails());
                $("#pSalesMobile" + (self.PartnerRegistrationModel().PartnerSalesDetailss().length - 1)).kendoMaskedTextBox({ mask: "000-000-0000" });
                SetFocusGrid(("#pSalesMobile" + (self.PartnerRegistrationModel().PartnerSalesDetailss().length - 1)));
                self.PartnerRegistrationModel().PartnerSalesDetailss()[self.PartnerRegistrationModel().PartnerSalesDetailss().length - 1].Type("Sales");
            }
            else {
                self.PartnerRegistrationModel().PartnerSalesDetailss.push(new eGateRoot.PartnerDirectorDetails());
                self.PartnerRegistrationModel().PartnerSalesDetailss()[0].Type("Sales");
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
                                self.PartnerRegistrationModel().PartnerSalesDetailss.remove(row);
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




        self.Upload = function (e) {

            if (self.PartnerRegistrationModel().DocumentType() != undefined) {

                if ((self.PartnerRegistrationModel().PartnerType() === "VesselOperatingAgent" || self.PartnerRegistrationModel().PartnerType() === "ContainerOperatorAgent" || self.PartnerRegistrationModel().PartnerType() === "CustomHouseAgent" || self.PartnerRegistrationModel().PartnerType() === "ContainerFreightStation" || self.PartnerRegistrationModel().PartnerType() === "MandR")
					&& (self.PartnerRegistrationModel().DocumentType() === "Agreement With Agency" || self.PartnerRegistrationModel().DocumentType() === "Valid M.L.O Licence With Customs At Vijayawada" || self.PartnerRegistrationModel().DocumentType() === "Valid Steamer Agency Licence With Jurisdictional Customs" || self.PartnerRegistrationModel().DocumentType() === "Valid Agency Agreement" || self.PartnerRegistrationModel().DocumentType() === "Valid Customs Continuity Bond" || self.PartnerRegistrationModel().DocumentType() === "Valid Steamer Agency Licence With Jurisdictional Customs"
					|| self.PartnerRegistrationModel().DocumentType() === "CHA/MTO (For CHA/FF) Licence Registration With Krishnapatnam Port" || self.PartnerRegistrationModel().DocumentType() === "CFS Licence Copy" || self.PartnerRegistrationModel().DocumentType() === "IICL Copy")) {

                    if (self.PartnerRegistrationModel().ValidTill() === '' || self.PartnerRegistrationModel().ValidTill() === null || self.PartnerRegistrationModel().ValidTill() === undefined) {

                        $('#validTilltxt').text('* This field is required.');
                        e.preventDefault();
                        return false;


                    }
                    else if (kendo.toString(kendo.parseDate(self.PartnerRegistrationModel().ValidTill(), 'dd-MM-yyyy'), 'yyyy-MM-dd') < kendo.toString(new Date(), 'yyyy-MM-dd')) {

                        toastr.warning("Please select valid date", $('#spnTitle').text());
                        e.preventDefault();
                        return false;
                    }
                    else {
                        $('#validTilltxt').text('');
                        UploadFile(self.PartnerRegistrationModel().DocumentDTOs(), e);

                    }
                }

                else {

                    UploadFile(self.PartnerRegistrationModel().DocumentDTOs(), e);
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

            self.PartnerRegistrationModel().DocumentDTOs()[id].OriginalName(data.response.FileName);
            self.PartnerRegistrationModel().DocumentDTOs()[id].FileName(data.response.FileName);
            self.PartnerRegistrationModel().DocumentDTOs()[id].IsDeleted("N");

            var docType = self.PartnerRegistrationModel().DocumentDTOs()[id].DocumentType();
            var partnerType = self.PartnerRegistrationModel().PartnerType();
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

        self.LoadStatusList = function () {
            self.viewModelHelper.apiGetAno("api/GetStatuses", null, function (result) {
                ko.mapping.fromJS(result, {}, self.StatusList);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        };

        self.LoadDocumentType = function () {
            self.viewModelHelper.apiGetAno("api/GetDocumentTypes", null, function (result) {
                ko.mapping.fromJS(result, {}, self.DocumentList);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        };


        self.LoadYearsList = function () {
            self.viewModelHelper.apiGetAno("api/GetYears", null, function (result) {
                ko.mapping.fromJS(result, {}, self.YearsList);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        };
        //self.LoadPorts = function () {
        //    self.viewModelHelper.apiGetAno("api/Ports", null, function (result) {
        //        ko.mapping.fromJS(result, {}, self.Ports);
        //    }, null, null, false, eGateRoot.uamRootPath);
        //};

        self.LoadCountries = function () {
            self.viewModelHelper.apiGetAno("api/CountriesPartner", null, function (result) {
                ko.mapping.fromJS(result, {}, self.Countries);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        };

        //self.SelectStates = function (model) {
        //	if (model.Country() !== undefined && model.Country() !== null && model.Country() !== "") {
        //		$.each(self.Countries(), function (k, v) {
        //			if (v.CountryCode() == model.Country()) {
        //				ko.mapping.fromJS(v.States, {}, self.States);
        //				$.each(self.States(), function (item) {
        //					self.States().sort(function (a, b) {
        //						var nameA = a.StateName().toLowerCase(), nameB = b.StateName().toLowerCase();
        //						if (nameA < nameB)
        //							return -1;
        //						if (nameA > nameB)
        //							return 1;
        //						return 0;
        //					});
        //				});
        //			}
        //		});
        //	} else {
        //		self.States([]);
        //	}
        //}


        //self.LoadPartnerTypes = function () {
        //    self.viewModelHelper.apiGetAno("api/PartnerTypes", null, function (result) {
        //        ko.mapping.fromJS(result, {}, self.PartnerTypes);
        //    }, null, null, false, eGateRoot.uamRootPath);
        //};




        self.ValidateControls = function (model) {
            self.PartnerRegistrationModel().validationEnabled(true);
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
                toastr.warning("Please select a Partner", $('#spnTitle').text());
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
            }
            else if (model.PartnerRegistrationAddress().ZipCode().length !== 6) {
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
                    $('#validationPAN').text('Please Enter Valid PAN Number. Ex:AAAAA7867P');
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
                    $('#validationCIN').text('Please Enter Valid CIN. Ex:U33337EA4455ADF333222');
                }
            }

            var MainError = self.BooleanCharacter.Yes();
            // var i = 0;
            var atLeastOneDirRecord = 0, atLeastOneOpsRecord = 0, atLeastOneItRecord = 0, atLeastOneFinRecord = 0, atLeastOneSalesRecord = 0;
            $.each(self.PartnerRegistrationModel().PartnerDirectorDetailss(), function (index, item) {
                var error = 0;

                if (item !== undefined && item.IsDeleted() === 'N') {
                    atLeastOneDirRecord++;
                    if (item.PDirectorName().trim() === '' || item.PDirectorName().trim() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    else if (item.PDirectorPAN() === '' || item.PDirectorPAN() === null || item.PDirectorPAN().length !== 10) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    else if (item.PDirectorAddress().trim() === '' || item.PDirectorAddress().trim() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    else if (item.PCountryCode() === '' || item.PCountryCode() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    else if (item.PDirectorMobile() === '' || item.PDirectorMobile() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    else if (item.PDirectorEmail() === '' || item.PDirectorEmail() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    if (item.PDirectorMobile() !== "") {
                        var telenumber1 = item.PDirectorMobile();
                        telenumber1 = telenumber1.replace(/(\)|\()|_|-+/g, '');
                        if (telenumber1.length !== 10) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        }
                        else {
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

            $.each(self.PartnerRegistrationModel().PartnerOperationsDetailss(), function (index, item) {
                var error = 0;
                if (item !== undefined && item.IsDeleted() === 'N') {
                    atLeastOneOpsRecord++;
                    if (item.PDirectorName().trim() === '' || item.PDirectorName().trim() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    else if (item.PCountryCode() === '' || item.PCountryCode() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    else if (item.PDirectorMobile() === '' || item.PDirectorMobile() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    else if (item.PDirectorEmail() === '' || item.PDirectorEmail() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    if (item.PDirectorMobile() !== "") {
                        var telenumber1 = item.PDirectorMobile();
                        telenumber1 = telenumber1.replace(/(\)|\()|_|-+/g, '');
                        if (telenumber1.length !== 10) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        }
                        else {
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

            $.each(self.PartnerRegistrationModel().PartnerITDetailss(), function (index, item) {
                var error = 0;
                if (item !== undefined && item.IsDeleted() === 'N') {
                    atLeastOneItRecord++;
                    if (item.PDirectorName().trim() === '' || item.PDirectorName().trim() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    else if (item.PCountryCode() === '' || item.PCountryCode() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    else if (item.PDirectorMobile() === '' || item.PDirectorMobile() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    else if (item.PDirectorEmail() === '' || item.PDirectorEmail() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    if (item.PDirectorMobile() !== "") {
                        var telenumber1 = item.PDirectorMobile();
                        telenumber1 = telenumber1.replace(/(\)|\()|_|-+/g, '');
                        if (telenumber1.length !== 10) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        }
                        else {
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

            $.each(self.PartnerRegistrationModel().PartnerFinanceDetailss(), function (index, item) {
                var error = 0;
                if (item !== undefined && item.IsDeleted() === 'N') {
                    atLeastOneFinRecord++;
                    if (item.PDirectorName().trim() === '' || item.PDirectorName().trim() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    else if (item.PCountryCode() === '' || item.PCountryCode() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    else if (item.PDirectorMobile() === '' || item.PDirectorMobile() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    else if (item.PDirectorEmail() === '' || item.PDirectorEmail() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    if (item.PDirectorMobile() !== "") {
                        var telenumber1 = item.PDirectorMobile();
                        telenumber1 = telenumber1.replace(/(\)|\()|_|-+/g, '');
                        if (telenumber1.length !== 10) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        }
                        else {
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

            $.each(self.PartnerRegistrationModel().PartnerSalesDetailss(), function (index, item) {
                var error = 0;
                if (item !== undefined && item.IsDeleted() === 'N') {
                    atLeastOneSalesRecord++;
                    if (item.PDirectorName().trim() === '' || item.PDirectorName().trim() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    else if (item.PCountryCode() === '' || item.PCountryCode() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    else if (item.PDirectorMobile() === '' || item.PDirectorMobile() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    else if (item.PDirectorEmail() === '' || item.PDirectorEmail() === null) {
                        error++;
                        MainError = self.BooleanCharacter.No();
                    }
                    if (item.PDirectorMobile() !== "") {
                        var telenumber1 = item.PDirectorMobile();
                        telenumber1 = telenumber1.replace(/(\)|\()|_|-+/g, '');
                        if (telenumber1.length !== 10) {
                            error++;
                            MainError = self.BooleanCharacter.No();
                        }
                        else {
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
            if (model.PartnerRegistrationAddress().MobileNumber() !== "") {
                var mobilNumber = model.PartnerRegistrationAddress().MobileNumber();
                mobilNumber = mobilNumber.replace(/(\)|\()|_|-+/g, '');
                if (mobilNumber.length !== 13) {
                    errors = errors + 1;
                }
                else {
                    model.PartnerRegistrationAddress().MobileNumber(mobilNumber);
                    if (errors > 0) {

                    }
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
                toastr.warning("Please fill all the required data", $('#spnTitle').text());
                //$("#finMobile").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                //$("#operationMobile").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                //$("#iTMobile").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                $("#txtMobileNo").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                $.each(self.PartnerRegistrationModel().PartnerDirectorDetailss(), function (index, item) {
                    $("#pDirectorMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                    $("#PDirectorTele" + index).kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                });
                $.each(self.PartnerRegistrationModel().PartnerOperationsDetailss(), function (index, item) {
                    $("#pOperationsMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                });
                $.each(self.PartnerRegistrationModel().PartnerITDetailss(), function (index, item) {
                    $("#pITMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                });
                $.each(self.PartnerRegistrationModel().PartnerFinanceDetailss(), function (index, item) {
                    $("#pFinanceMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                });
                $.each(self.PartnerRegistrationModel().PartnerSalesDetailss(), function (index, item) {
                    $("#pSalesMobile" + index).kendoMaskedTextBox({ mask: "000-000-0000" });
                });
            }
            else if (MainError !== self.BooleanCharacter.Yes()) {
                toastr.warning("Please fill all the required data", $('#spnTitle').text());
            }

            if (errors === 0 && (model.PartnerDirectorDetailss().length === 0 || atLeastOneDirRecord === 0)) {
                errors = errors + 1;
                toastr.warning("Please fill Details of Directors/Partners/Promoters.", $('#spnTitle').text());
            }
            else if (errors === 0 && (model.PartnerOperationsDetailss().length === 0 || atLeastOneOpsRecord === 0)) {
                errors = errors + 1;
                toastr.warning("Please fill Details of Operations Representative.", $('#spnTitle').text());
            }
            else if (errors === 0 && (model.PartnerITDetailss().length === 0 || atLeastOneItRecord === 0)) {
                errors = errors + 1;
                toastr.warning("Please fill Details of IT Representative.", $('#spnTitle').text());
            }
            else if (errors === 0 && (model.PartnerFinanceDetailss().length === 0 || atLeastOneFinRecord === 0)) {
                errors = errors + 1;
                toastr.warning("Please fill Details of Finance Representative.", $('#spnTitle').text());
            }


            if (errors === 0) {
                var isAllDocs = 'Y';
                var isRequiredDoc = 'Y';
                var isDate = 'Y';
                if (model.PartnerType() === "VesselOperatingAgent") {
                    $.each(model.DocumentDTOs(), function (index, item) {
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
                        } else if (item.DocumentType() === 'Agreement With Agency' && item.FileName() !== null && item.FileName() !== '' && !isEmpty(item.ValidTill())) {
                            var validDate = kendo.toString(kendo.parseDate(item.ValidTill(), 'dd-MM-yyyy'), "yyyy-MM-dd");
                            var todayDate = new Date();
                            todayDate.setDate(todayDate.getDate() + 1);
                            var nextDayDate = kendo.toString(todayDate, "yyyy-MM-dd");
                            if (validDate < nextDayDate) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                toastr.warning("Valid Till Date is Expired", item.DocumentType());
                                return false;
                            }
                        }
                        if (item.DocumentType() === 'Valid M.L.O Licence With Customs At Vijayawada' && item.FileName() !== null && item.FileName() !== '' && (item.ValidTill() === null || item.ValidTill() === '')) {
                            item.ErrorStatusDocument(true);
                            isAllDocs = 'N';
                        } else if (item.DocumentType() === 'Valid M.L.O Licence With Customs At Vijayawada' && item.FileName() !== null && item.FileName() !== '' && !isEmpty(item.ValidTill())) {
                            var validDate = kendo.toString(kendo.parseDate(item.ValidTill(), 'dd-MM-yyyy'), "yyyy-MM-dd");
                            var todayDate = new Date();
                            todayDate.setDate(todayDate.getDate() + 1);
                            var nextDayDate = kendo.toString(todayDate, "yyyy-MM-dd");
                            if (validDate < nextDayDate) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                toastr.warning("Valid Till Date is Expired", item.DocumentType());
                                return false;
                            }
                        }
                        if (item.DocumentType() === 'Valid Steamer Agency Licence With Jurisdictional Customs' && item.FileName() !== null && item.FileName() !== '' && (item.ValidTill() === null || item.ValidTill() === '')) {
                            item.ErrorStatusDocument(true);
                            isAllDocs = 'N';
                        } else if (item.DocumentType() === 'Valid Steamer Agency Licence With Jurisdictional Customs' && item.FileName() !== null && item.FileName() !== '' && !isEmpty(item.ValidTill())) {
                            var validDate = kendo.toString(kendo.parseDate(item.ValidTill(), 'dd-MM-yyyy'), "yyyy-MM-dd");
                            var todayDate = new Date();
                            todayDate.setDate(todayDate.getDate() + 1);
                            var nextDayDate = kendo.toString(todayDate, "yyyy-MM-dd");
                            if (validDate < nextDayDate) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                toastr.warning("Valid Till Date is Expired", item.DocumentType());
                                return false;
                            }
                        }
                        if ($("#validTill" + index).is(':visible') === true && ($("#validTill" + index).val() === null || $("#validTill" + index).val() === "")) {
                            isDate = 'N';
                        }

                    });
                    if (isAllDocs === 'N') {
                        errors = errors + 1;
                        if (isRequiredDoc === 'N' && isDate === 'N') {
                            toastr.warning("Please Upload all the required document", $('#spnTitle').text());
                            toastr.warning("Please fill Valid Till Date", $('#spnTitle').text());
                        } else if (isRequiredDoc === 'N') {
                            toastr.warning("Please Upload all the required document", $('#spnTitle').text());
                        } else if (isDate === 'N') {
                            toastr.warning("Please fill Valid Till Date", $('#spnTitle').text());
                        }
                    }
                }

                else if (model.PartnerType() === "ContainerOperatorAgent") {
                    $.each(model.DocumentDTOs(), function (index, item) {
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
                        } else if (item.DocumentType() === 'Valid Agency Agreement' && item.FileName() !== null && item.FileName() !== '' && !isEmpty(item.ValidTill())) {
                            var validDate = kendo.toString(kendo.parseDate(item.ValidTill(), 'dd-MM-yyyy'), "yyyy-MM-dd");
                            var todayDate = new Date();
                            todayDate.setDate(todayDate.getDate() + 1);
                            var nextDayDate = kendo.toString(todayDate, "yyyy-MM-dd");
                            if (validDate < nextDayDate) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                toastr.warning("Valid Till Date is Expired", item.DocumentType());
                                return false;
                            }
                        }
                        if (item.DocumentType() === 'Valid Customs Continuity Bond' && item.FileName() !== null && item.FileName() !== '' && (item.ValidTill() === null || item.ValidTill() === '')) {
                            item.ErrorStatusDocument(true);
                            isAllDocs = 'N';
                        } else if (item.DocumentType() === 'Valid Customs Continuity Bond' && item.FileName() !== null && item.FileName() !== '' && !isEmpty(item.ValidTill())) {
                            var validDate = kendo.toString(kendo.parseDate(item.ValidTill(), 'dd-MM-yyyy'), "yyyy-MM-dd");
                            var todayDate = new Date();
                            todayDate.setDate(todayDate.getDate() + 1);
                            var nextDayDate = kendo.toString(todayDate, "yyyy-MM-dd");
                            if (validDate < nextDayDate) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                toastr.warning("Valid Till Date is Expired", item.DocumentType());
                                return false;
                            }
                        }
                        if (item.DocumentType() === 'Valid Steamer Agency Licence With Jurisdictional Customs' && item.FileName() !== null && item.FileName() !== '' && (item.ValidTill() === null || item.ValidTill() === '')) {
                            item.ErrorStatusDocument(true);
                            isAllDocs = 'N';
                        } else if (item.DocumentType() === 'Valid Steamer Agency Licence With Jurisdictional Customs' && item.FileName() !== null && item.FileName() !== '' && !isEmpty(item.ValidTill())) {
                            var validDate = kendo.toString(kendo.parseDate(item.ValidTill(), 'dd-MM-yyyy'), "yyyy-MM-dd");
                            var todayDate = new Date();
                            todayDate.setDate(todayDate.getDate() + 1);
                            var nextDayDate = kendo.toString(todayDate, "yyyy-MM-dd");
                            if (validDate < nextDayDate) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                toastr.warning("Valid Till Date is Expired", item.DocumentType());
                                return false;
                            }
                        }
                        if ($("#validTill" + index).is(':visible') === true && ($("#validTill" + index).val() === null || $("#validTill" + index).val() === "")) {
                            isDate = 'N';
                        }

                    });
                    if (isAllDocs === 'N') {
                        errors = errors + 1;
                        if (isRequiredDoc === 'N' && isDate === 'N') {
                            toastr.warning("Please Upload all the required document",$('#spnTitle').text());
                            toastr.warning("Please fill Valid Till Date", $('#spnTitle').text());
                        } else if (isRequiredDoc === 'N') {
                            toastr.warning("Please Upload all the required document",$('#spnTitle').text());
                        } else if (isDate === 'N') {
                            toastr.warning("Please fill Valid Till Date",$('#spnTitle').text());
                        }
                    }
                }

                else if (model.PartnerType() === "CustomHouseAgent") {
                    $.each(model.DocumentDTOs(), function (index, item) {
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
                        } else if (item.DocumentType() === 'CHA/MTO (For CHA/FF) Licence Registration With Krishnapatnam Port' && item.FileName() !== null && item.FileName() !== '' && !isEmpty(item.ValidTill())) {
                            var validDate = kendo.toString(kendo.parseDate(item.ValidTill(), 'dd-MM-yyyy'), "yyyy-MM-dd");
                            var todayDate = new Date();
                            todayDate.setDate(todayDate.getDate() + 1);
                            var nextDayDate = kendo.toString(todayDate, "yyyy-MM-dd");
                            if (validDate < nextDayDate) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                toastr.warning("Valid Till Date is Expired", item.DocumentType());
                                return false;
                            }
                        }
                        if ($("#validTill" + index).is(':visible') === true && ($("#validTill" + index).val() === null || $("#validTill" + index).val() === "")) {
                            isDate = 'N';
                        }

                    });
                    if (isAllDocs === 'N') {
                        errors = errors + 1;
                        if (isRequiredDoc === 'N' && isDate === 'N') {
                            toastr.warning("Please Upload all the required document", $('#spnTitle').text());
                            toastr.warning("Please fill Valid Till Date", $('#spnTitle').text());
                        } else if (isRequiredDoc === 'N') {
                            toastr.warning("Please Upload all the required document", $('#spnTitle').text());
                        } else if (isDate === 'N') {
                            toastr.warning("Please fill Valid Till Date", $('#spnTitle').text());
                        }
                    }
                }

                else if (model.PartnerType() === "ContainerFreightStation") {
                    $.each(model.DocumentDTOs(), function (index, item) {
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
                        } else if (item.DocumentType() === 'CFS Licence Copy' && item.FileName() !== null && item.FileName() !== '' && !isEmpty(item.ValidTill())) {
                            var validDate = kendo.toString(kendo.parseDate(item.ValidTill(), 'dd-MM-yyyy'), "yyyy-MM-dd");
                            var todayDate = new Date();
                            todayDate.setDate(todayDate.getDate() + 1);
                            var nextDayDate = kendo.toString(todayDate, "yyyy-MM-dd");
                            if (validDate < nextDayDate) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                toastr.warning("Valid Till Date is Expired", item.DocumentType());
                                return false;
                            }
                        }
                        if ($("#validTill" + index).is(':visible') === true && ($("#validTill" + index).val() === null || $("#validTill" + index).val() === "")) {
                            isDate = 'N';
                        }
                    });
                    if (isAllDocs === 'N') {
                        errors = errors + 1;
                        if (isRequiredDoc === 'N' && isDate === 'N') {
                            toastr.warning("Please Upload all the required document", $('#spnTitle').text());
                            toastr.warning("Please fill Valid Till Date", $('#spnTitle').text());
                        } else if (isRequiredDoc === 'N') {
                            toastr.warning("Please Upload all the required document", $('#spnTitle').text());
                        } else if (isDate === 'N') {
                            toastr.warning("Please fill Valid Till Date", $('#spnTitle').text());
                        }
                    }
                }

                else if (model.PartnerType() === "MandR") {
                    $.each(model.DocumentDTOs(), function (index, item) {
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
                        else if (item.DocumentType() === 'IICL Copy' && item.FileName() !== null && item.FileName() !== '' && !isEmpty(item.ValidTill())) {
                            var validDate = kendo.toString(kendo.parseDate(item.ValidTill(), 'dd-MM-yyyy'), "yyyy-MM-dd");
                            var todayDate = new Date();
                            todayDate.setDate(todayDate.getDate() + 1);
                            var nextDayDate = kendo.toString(todayDate, "yyyy-MM-dd");
                            if (validDate < nextDayDate) {
                                item.ErrorStatusDocument(true);
                                isAllDocs = 'N';
                                toastr.warning("Valid Till Date is Expired", item.DocumentType());
                                return false;
                            }
                        }
                        if ($("#validTill" + index).is(':visible') === true && ($("#validTill" + index).val() === null || $("#validTill" + index).val() === "")) {
                            isDate = 'N';
                        }
                    });
                    if (isAllDocs === 'N') {
                        errors = errors + 1;
                        if (isRequiredDoc === 'N' && isDate === 'N') {
                            toastr.warning("Please Upload all the required document", $('#spnTitle').text());
                            toastr.warning("Please fill Valid Till Date", $('#spnTitle').text());
                        } else if (isRequiredDoc === 'N') {
                            toastr.warning("Please Upload all the required document", $('#spnTitle').text());
                        } else if (isDate === 'N') {
                            toastr.warning("Please fill Valid Till Date", $('#spnTitle').text());
                        }
                    }
                }
            }


            //#endregion 
            return errors;


        }


        self.ConvertDates = function (date) {
            var converted = kendo.parseDate(date, "dd-MM-yyyy");
            converted = kendo.toString(converted, "yyyy-MM-dd");
            return converted;
        }


        self.SaveScreen = function (model) {
            //if (self.IsPartnerDuplicate()) {
            //    $('#partnerName').focus();
            //    toastr.warning("Form with same Partner name is already submitted.", $('#spnTitle').text());
            //    return false;
            //}
            var errors = self.ValidateControls(model);

            if (errors === 0) {
                if (model.IsAccept() === false) {
                    toastr.warning("Please Accept the Terms", $('#spnTitle').text());
                } else {
                    var partnerType = "";
                    if (model.PartnerType() === "VesselOperatingAgent") {
                        partnerType = "VOA";
                    }
                    else if (model.PartnerType() === "ContainerOperatorAgent") {
                        partnerType = "COA";
                    }
                    else if (model.PartnerType() === "CustomHouseAgent") {
                        partnerType = "CHA / FF";
                    }
                    else if (model.PartnerType() === "ContainerFreightStation") {
                        partnerType = "CFS";
                    }
                    else if (model.PartnerType() === "MandR") {
                        partnerType = "M&R";
                    }

                    $.confirm({
                        'title': 'Partner Registration',
                        'message': 'You are registering as <label id="lblMiss" style="line-height: 120%;"> ' + partnerType + ',  </label> <br/> <br/>' + '    Are you sure ?',
                        'buttons': {
                            'Yes': {
                                'class': 'green',
                                'action': function () {
                                    $.each(model.DocumentDTOs(), function (index, item) {
                                        if (item.ValidTill() !== null && item.ValidTill() !== '') {
                                            var validDate = self.ConvertDates(item.ValidTill());
                                            item.ValidTill(validDate);
                                        }
                                    });
                                    model.IFSCCode(model.IFSCCode().toUpperCase());
                                    $('#confirmOverlay').remove();
                                    self.viewModelHelper.apiPostAno('api/PartnerRegistration', ko.mapping.toJSON(model), function Message(data) {
                                        toastr.options.closeButton = true;
                                        toastr.options.positionClass = "toast-top-right";
                                        toastr.success("Your KYC form is successfully submitted. You will receive an email with instructions to login after e-Xpressway approves your form.", "Partner Registration");
                                        setTimeout(
                                                function () {
                                                    window.location.href = window.location.origin;
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
        }

        self.UpdateScreen = function (model) {
            model.PartnerRegistrationAddress(model.PartnerRegistrationAddressEdit());
            var errors = self.ValidateControls(model);

            if (errors === 0) {
                if (model.IsAccept() === false) {
                    toastr.warning("Please Accept the Terms", $('#spnTitle').text());
                } else {
                    var partnerType = "";
                    if (model.PartnerType() === "VesselOperatingAgent") {
                        partnerType = "VOA";
                    }
                    else if (model.PartnerType() === "ContainerOperatorAgent") {
                        partnerType = "COA";
                    }
                    else if (model.PartnerType() === "CustomHouseAgent") {
                        partnerType = "CHA / FF";
                    }
                    else if (model.PartnerType() === "ContainerFreightStation") {
                        partnerType = "CFS";
                    }
                    else if (model.PartnerType() === "MandR") {
                        partnerType = "M&R";
                    }

                    $.confirm({
                        'title': 'Partner Registration',
                        'message': 'You are resubmitting as <label id="lblMiss" style="line-height: 120%;"> ' + partnerType + ',  </label> <br/> <br/>' + '    Are you sure ?',
                        'buttons': {
                            'Yes': {
                                'class': 'green',
                                'action': function () {
                                    $.each(model.DocumentDTOs(), function (index, item) {
                                        if (item.ValidTill() !== null && item.ValidTill() !== '') {
                                            var validDate = self.ConvertDates(item.ValidTill());
                                            item.ValidTill(validDate);
                                        }
                                    });
                                    model.IFSCCode(model.IFSCCode().toUpperCase());
                                    $('#confirmOverlay').remove();
                                    self.viewModelHelper.apiPostAno('api/UpdatePartnerRegistration', ko.mapping.toJSON(model), function Message(data) {
                                        toastr.options.closeButton = true;
                                        toastr.options.positionClass = "toast-top-right";
                                        toastr.success("Your KYC form is successfully resubmitted.", "Partner Registration");
                                        setTimeout(
                                                function () {
                                                    window.location.href = window.location.origin;
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
        }

        self.ResetScreen = function (model) {
            $.confirm({
                'title': 'Partner Registration',
                'message': 'Are you sure you want to Reset ?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                            self.Initialize();
                            $("#registrationBody").trigger('click');
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

        self.SearchResetDetails = function (model) {
            $.confirm({
                'title': 'Update Partner Registration',
                'message': 'Are you sure you want to Reset ?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                            window.location.href = "/PartnerRegistrationEdit";
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


        self.SelectStates = function (model) {
            $.each(self.Countries(), function (k, v) {
                if (v.CountryCode() == model.Country()) {
                    ko.mapping.fromJS(v.States, {}, self.States);
                }
                if (model.Country() == undefined)
                { self.States([]); }
            });
        }

        self.SelectStatesforEdit = function (model) {
            $.each(self.Countries(), function (k, v) {
                if (v.CountryCode() == model.Country) {
                    ko.mapping.fromJS(v.States, {}, self.States);
                }
                if (model.Country == undefined)
                { self.States([]); }
            });
        }

        self.ExitScreen = function (model) {

            $.confirm({
                'title': $('#spnTitle').text(),
                'message': 'Are you sure you want to Exit Partner registration?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                            self.cancel();
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

        self.RedirecttoEdit = function (model) {

            $.confirm({
                'title': 'Partner Registration',
                'message': 'Are you sure you want to Edit Partner registration?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                            window.location.href = "/PartnerRegistrationEdit";
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

        self.uploadFile = function (e) {
            var uploadedFiles = [];
            var documentData = [];
            uploadedFiles = self.PartnerRegistrationModel().PartnerRegistrationAddress().UploadedFiles();
            var opmlFile = $('#fileToUpload')[0];
            var flag = true;

            if (opmlFile.files.length > 0) {
                for (var i = 0; i < opmlFile.files.length; i++) {
                    var match = null;
                    //var match = ko.utils.arrayFirst(self.signatoryModel().SignatoryDocuments(), function (item) {
                    //    return item.FileName() === opmlFile.files[i].name;
                    //});
                    var reader = new FileReader();
                    var image = new Image();

                    reader.onload = function (e) {

                        image.src = e.target.result;
                        image.onload = function (e) {

                            var width = this.width,
                                height = this.height;
                            //if (width > 120) {

                            //    toastr.warning("Image width should be less than 120px", "warning");
                            //    $('#sigImage').attr('src', null);
                            //    //self.signatoryModel().SignatoryDocuments('');
                            //    //self.signatoryModel().UploadedFiles([]);
                            //    //flag = false;
                            //}
                        };
                    };
                    reader.readAsDataURL(opmlFile.files[i]);
                    //&& flag==true

                    if (match == null) {

                        var elem = {};
                        elem.FileName = opmlFile.files[i].name;
                        var extension = opmlFile.files[i].name.split('.').pop().toLowerCase();
                        var fileExtension = ['jpg', 'png'];
                        if ($.inArray(extension, fileExtension) != -1) {
                            var size = opmlFile.files[i].size;
                            //if (size <= 5000) {

                            elem.CategoryName = $('#selUploadDocs option:selected').text();
                            elem.CategoryCode = $('#selUploadDocs option:selected').val();
                            elem.FileDetails = opmlFile.files[i];
                            elem.IsAlreadyExists = false;

                            uploadedFiles.push(elem);
                            self.PartnerRegistrationModel().PartnerRegistrationAddress().UploadedFiles(uploadedFiles);

                            var reader = new FileReader();
                            reader.onload = function (e) {
                                $('#sigImage').attr('src', e.target.result);
                            }
                            reader.readAsDataURL(opmlFile.files[i]);
                            //}
                            //else {
                            //    toastr.error("Please upload the files with size 100 only", "Error");
                            //    return;
                            //}


                        } else {
                            toastr.error("Please upload the files with formats (.JPG, .PNG) only", "Error");
                            return;
                        }
                    }
                }

                var formData = new FormData();

                ko.utils.arrayMap(self.PartnerRegistrationModel().PartnerRegistrationAddress().UploadedFiles(), function (item) {
                    formData.append(item.FileName, item.FileDetails);
                });


                self.viewModelHelper.apiUploadAno('api/FileUpload/ImageUploadAno?documentType=Doc1', formData, function Message(data) {
                    ko.utils.arrayMap(data, function (item) {
                        self.PartnerRegistrationModel().PartnerRegistrationAddress().LogoFileName(item.OrginalFileName);
                        self.PartnerRegistrationModel().PartnerRegistrationAddress().LogoPath(item.FileName);

                    });
                }, null, null, null, null, 'UAM');

                //var formData = new FormData();

                //ko.utils.arrayMap(self.PartnerModel().PartnerRegistrationAddress().UploadedFiles(), function (item) {
                //    formData.append(item.FileName, item.FileDetails);
                //});

                //self.viewModelHelper.apiUpload('api/FileUpload/MultipleFileUpload', null, function Message(data) {
                //    ko.utils.arrayMap(data, function (item) {
                //        formData.append(item.FileName, item.FileDetails);

                //    });
                //});

            } else {
                toastr.warning("Please select image", $('#spnTitle').text());
            }
            if (opmlFile.files.length > 0) {
                self.PartnerRegistrationModel().PartnerRegistrationAddress().UploadedFiles([]);

                $('#fileToUpload').val('');
                $('#sigImage').attr('src', "");
            }
            return;
        }

        self.uploadFileforEdit = function (e) {
            var uploadedFiles = [];
            var documentData = [];
            uploadedFiles = self.PartnerRegistrationModel().PartnerRegistrationAddressEdit().UploadedFiles();
            var opmlFile = $('#fileToUpload')[0];
            var flag = true;

            if (opmlFile.files.length > 0) {
                for (var i = 0; i < opmlFile.files.length; i++) {
                    var match = null;
                    //var match = ko.utils.arrayFirst(self.signatoryModel().SignatoryDocuments(), function (item) {
                    //    return item.FileName() === opmlFile.files[i].name;
                    //});
                    var reader = new FileReader();
                    var image = new Image();

                    reader.onload = function (e) {

                        image.src = e.target.result;
                        image.onload = function (e) {

                            var width = this.width,
                                height = this.height;
                            //if (width > 120) {

                            //    toastr.warning("Image width should be less than 120px", "warning");
                            //    $('#sigImage').attr('src', null);
                            //    //self.signatoryModel().SignatoryDocuments('');
                            //    //self.signatoryModel().UploadedFiles([]);
                            //    //flag = false;
                            //}
                        };
                    };
                    reader.readAsDataURL(opmlFile.files[i]);
                    //&& flag==true

                    if (match == null) {

                        var elem = {};
                        elem.FileName = opmlFile.files[i].name;
                        var extension = opmlFile.files[i].name.split('.').pop().toLowerCase();
                        var fileExtension = ['jpg', 'png'];
                        if ($.inArray(extension, fileExtension) != -1) {
                            var size = opmlFile.files[i].size;
                            //if (size <= 5000) {

                            elem.CategoryName = $('#selUploadDocs option:selected').text();
                            elem.CategoryCode = $('#selUploadDocs option:selected').val();
                            elem.FileDetails = opmlFile.files[i];
                            elem.IsAlreadyExists = false;

                            uploadedFiles.push(elem);
                            self.PartnerRegistrationModel().PartnerRegistrationAddressEdit().UploadedFiles(uploadedFiles);

                            var reader = new FileReader();
                            reader.onload = function (e) {
                                $('#sigImage').attr('src', e.target.result);
                            }
                            reader.readAsDataURL(opmlFile.files[i]);
                            //}
                            //else {
                            //    toastr.error("Please upload the files with size 100 only", "Error");
                            //    return;
                            //}


                        } else {
                            toastr.error("Please upload the files with formats (.JPG, .PNG) only", "Error");
                            return;
                        }
                    }
                }

                var formData = new FormData();

                ko.utils.arrayMap(self.PartnerRegistrationModel().PartnerRegistrationAddressEdit().UploadedFiles(), function (item) {
                    formData.append(item.FileName, item.FileDetails);
                });


                self.viewModelHelper.apiUploadAno('api/FileUpload/ImageUploadAno?documentType=Doc1', formData, function Message(data) {
                    ko.utils.arrayMap(data, function (item) {
                        self.PartnerRegistrationModel().PartnerRegistrationAddressEdit().LogoFileName(item.OrginalFileName);
                        self.PartnerRegistrationModel().PartnerRegistrationAddressEdit().LogoPath(item.FileName);

                    });
                }, null, null, null, null, 'UAM');

                //var formData = new FormData();

                //ko.utils.arrayMap(self.PartnerModel().PartnerRegistrationAddress().UploadedFiles(), function (item) {
                //    formData.append(item.FileName, item.FileDetails);
                //});

                //self.viewModelHelper.apiUpload('api/FileUpload/MultipleFileUpload', null, function Message(data) {
                //    ko.utils.arrayMap(data, function (item) {
                //        formData.append(item.FileName, item.FileDetails);

                //    });
                //});

            } else {
                toastr.warning("Please select image", $('#spnTitle').text());
            }
            if (opmlFile.files.length > 0) {
                self.PartnerRegistrationModel().PartnerRegistrationAddressEdit().UploadedFiles([]);

                $('#fileToUpload').val('');
                $('#sigImage').attr('src', "");
            }
            return;
        }

        self.cancel = function () {
            window.location.href = window.location.origin;
            $('#spnTitle').html("Partners");
        }





        self.CheckUniquePartnerName = function (model) {
           if (!isEmpty(model.PartnerName().trim()) && isEmpty(model.PartnerType())) {
                toastr.warning("Please select Partner Type.", $('#spnTitle').text());
                return false;
            }
            if (isEmpty(model.PartnerName().trim()) && !isEmpty(model.PartnerType())) {
                return false;
            }
            self.viewModelHelper.apiGetAno("api/CheckUniquePartnerName", { partnerName: model.PartnerName(), partnerType: model.PartnerType() }, function (result) {
                if (result === 'Y') {
                    model.PartnerName('');
                    setTimeout(function() {
                        $('#partnerName').focus();
                        toastr.warning("Form with "+ model.PartnerName()+" Partner name is already submitted.", $('#spnTitle').text());
                    });

                } else {
                    self.IsPartnerDuplicate(false);
                }
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
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
            //self.viewModelHelper.apiGetAno("api/CheckUniqueCIN", { partnerName: model.CIN() }, function (result) {
            //    if (result === 'Y') {
            //        model.CIN('');
            //        toastr.warning("Form with given CIN is already submitted.");
            //    }
            //}, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }

        self.CheckUniquePAN = function (model) {
            //self.viewModelHelper.apiGetAno("api/CheckUniquePAN", { partnerName: model.PAN() }, function (result) {
            //    if (result === 'Y') {
            //        model.PAN('');
            //        toastr.warning("Form with given PAN is already submitted.");
            //    }
            //}, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }

        self.CheckUniqueTAN = function (model) {
            //self.viewModelHelper.apiGetAno("api/CheckUniqueTAN", { partnerName: model.TAN() }, function (result) {
            //    if (result === 'Y') {
            //        model.TAN('');
            //        toastr.warning("Form with given TAN is already submitted.");
            //    }
            //}, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }
        self.CheckUniqueRegistrationNo = function (model) {
            //self.viewModelHelper.apiGetAno("api/CheckUniqueRegistrationNo", { partnerName: model.RegistrationNo() }, function (result) {
            //    if (result === 'Y') {
            //        model.RegistrationNo('');
            //        toastr.warning("Form with given CheckUniqueRegistrationNo is already submitted.");
            //    }
            //}, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }

        self.CheckUniqueVAT = function (model) {
            //self.viewModelHelper.apiGetAno("api/CheckUniqueVAT", { partnerName: model.VAT() }, function (result) {
            //    if (result === 'Y') {
            //        model.VAT('');
            //        toastr.warning("Form with given Service Tax/VAT Reg. No. is already submitted.");
            //    }
            //}, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }

        self.Initialize();

    }
    eGateRoot.PartnerKYCFormViewModel = PartnerKYCFormViewModel;
}(window.eGateRoot));


validateHouseNumber = function () {
    if ($('#houseNumber').val().trim() !== "") {
        $('#validationHouseNumber').text('');
    }
    else {
        model.PartnerRegistrationAddress().HouseNumber('');
        $('#houseNumber').val('');
    }
}

validateLogo = function () {
    if (model.PartnerRegistrationAddress().LogoFileName() !== "") {
        $('#validationLogo').text('');
    }
}
//validateStreetName = function () {
//    if ($('#streetName').val().trim() !== "") {
//        $('#validationStreetName').text('');
//    }
//}

//validateareaName = function () {
//    if ($('#areaName').val().trim() !== "") {
//        $('#validationAreaName').text('');
//    }
//}

validatetownOrCity = function () {
    if ($('#townOrCity').val().trim() !== "") {
        $('#validationTownOrCity').text('');
    }
}

validatezipCode = function () {
    if ($('#zipCode').val().trim() !== "") {
        $('#validationZipCode').text('');
    }
}

validateCountry = function () {
    if ($('#ddlCountry').val().trim() != undefined) {
        $('#validationCountry').text('');
    }
}

validateContactNumber = function () {
    $("#contactNumber").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
    if ($('#contactNumber').val().trim() != "") {
        $('#validationContactNumber').text('');
    }
}
validatefinNumber = function () {
    $("#finMobile").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
    if ($('#finMobile').val().trim() !== "") {
        $('#validationfinMobile').text('');
    }
}
validateITMobile = function () {
    $("#iTMobile").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
    if ($('#iTMobile').val().trim() !== "") {
        $('#validationiTMobile').text('');
    }
}
//validateOperationMobile = function () {
//    $("#operationMobile").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
//    if ($('#operationMobile').val().trim() !== "") {
//        $('#validationOperationMobile').text('');
//    }
//}
//validateEmailId = function () {
//    if ($('#emailId').val() != "") {
//        $('#validationEmailId').text('');
//    }
//}
//validateFinEmailId = function () {
//    if ($('#finEmail').val().trim() !== "") {
//        $('#validationFinEmail').text('');
//    }
//}
//validateOperationEmail = function () {
//    if ($('#operationEmail').val() !== "") {
//        $('#validationOperationsEmail').text('');
//    }
//}
//validateITEmail = function () {
//    if ($('#itEmail').val() !== "") {
//        $('#ValidationiTEmail').text('');
//    }
//}

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
validatePAN = function () {
    if ($('#txtPAN').val().trim() !== "") {
        $('#validationPAN').text('');
    }
}

validateTAN = function () {
    if ($('#txtTAN').val().trim() !== "") {
        $('#validationTAN').text('');
    }
}
validateCIN = function () {
    if ($('#txtCIN').val().trim() !== "") {
        $('#validationCIN').text('');
    }
}
validateState = function () {

    if ($('#ddlState').val().trim() != undefined) {

        $('#validationState').text('');

    }

}


validateChangeDate = function () {

    if ($('#validTill').val() != '') {

        $('#validTilltxt').text('');

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
    $("#txtMobileNo").bind("focus", function () {
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
    $("#txtMobileNoSearch").bind("focus", function () {
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
