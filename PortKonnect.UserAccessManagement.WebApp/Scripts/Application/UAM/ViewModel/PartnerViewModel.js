(function (eGateRoot) {
	var PartnerViewModel = function (PartnerId, path) {
        var self = this;

        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        //self.validationEnabled = ko.observable();
        self.viewMode = ko.observable();
        self.editableView = ko.observable(true);
        self.PartnerModel = ko.observable(new eGateRoot.PartnerModel());

        self.IsReset = ko.observable(true);
        self.IsSave = ko.observable(true);
        self.IsUpdate = ko.observable(true);
        self.IsExit = ko.observable(true);
        self.IsCodeEnable = ko.observable(true);
        self.validationHelper = new eGateRoot.ValidationHelper();
        toastr.options.closeButton = true;
        toastr.options.positionClass = "toast-top-right";
        self.Applications = ko.observableArray([]);
        self.Ports = ko.observableArray([]);
        self.Countries = ko.observableArray([]);
        self.PartnerTypes = ko.observableArray([]);
        self.States = ko.observableArray([]);
        self.partnerCodes = ko.observableArray([]);
        self.EditMode = ko.observable(true);
        self.IsEdit = ko.observable(true);
        self.editableView = ko.observable(true);
        self.applicationDisabled = ko.observable(true);
        self.IsUpload = ko.observable(true);
        self.PartnerCodeEnable = ko.observable(true);
        self.bufferPartnerType = ko.observable();
        //self.Uploadfilesarray = ko.observableArray([]);
        //self.FileName = ko.observable();
        //self.FilePathName = ko.observable();
        self.SelectStatesForView = function (model) {
            $.each(self.Countries(), function (k, v) {
                if (v.CountryCode() == model.PartnerAddress.Country) {
                    ko.mapping.fromJS(v.States, {}, self.States);
                }
            });
        }

        self.GetPartnerById = function () {

            self.viewModelHelper.apiGet('api/Partner/' + PartnerId,
          null,
            function (result) {
                if (result != null) {
                    self.PartnerModel().PartnerId(result.PartnerId);
                    self.PartnerModel().PartnerCode(result.PartnerCode);
                    self.PartnerModel().PartnerType(result.PartnerType);
                    self.PartnerModel().PartnerName(result.PartnerName);
                    self.PartnerModel().Application(result.Application);
                    self.PartnerModel().PartnerTypeArray(result.PartnerTypeArray);
                    self.PartnerModel().PartnerAddress().HouseNumber(result.PartnerAddress.HouseNumber);
                    self.PartnerModel().PartnerAddress().StreetName(result.PartnerAddress.StreetName);
                    self.PartnerModel().PartnerAddress().AreaName(result.PartnerAddress.AreaName);
                    self.PartnerModel().PartnerAddress().TownOrCity(result.PartnerAddress.TownOrCity);
                    self.PartnerModel().PartnerAddress().Country(result.PartnerAddress.Country);
                    self.SelectStatesForView(result);
                    self.PartnerModel().PartnerAddress().ContactNumber(result.PartnerAddress.ContactNumber);
                    self.PartnerModel().PartnerAddress().EmailId(result.PartnerAddress.EmailId);
                    self.PartnerModel().PartnerAddress().WebSite(result.PartnerAddress.WebSite);
                    self.PartnerModel().PartnerAddress().State(result.PartnerAddress.State);
                    self.PartnerModel().PartnerAddress().ZipCode(result.PartnerAddress.ZipCode);
                    self.PartnerModel().PartnerAddress().LogoFileName(result.PartnerAddress.LogoFileName);
                    self.PartnerModel().PartnerAddress().LogoPath(result.PartnerAddress.LogoPath);
                    // document.getElementById("sigImage").src = "data:image/png;base64," + result.LogoPath;
                    $(document).ready(function () {
                    	document.getElementById("sigImage").src = application.viewbag.appSettings.uamapiUrl+"/FileUploads/Logo/" + result.PartnerAddress.LogoPath;
                    });

                }
                else {
                    toastr.error("Partner doesn't exist", "Partner");
                    setTimeout(function () {
                        window.location.href = window.location.origin + "/Partners";
                    },2000);
                    
                }
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');


        }

        self.Initialize = function () {

            self.PartnerModel(new eGateRoot.PartnerModel());
            self.viewMode = ko.observable(true);
            self.LoadApplications();
            self.LoadCountries();
            self.LoadPorts();
            self.LoadPartnerTypes();
            if (PartnerId != "" && PartnerId != null && PartnerId != undefined) {
            	
            	if (path == "View") {
            		self.IsSave(false);
            		self.IsUpdate(false);
            		self.IsReset(false);
            		self.IsExit(true);
            		self.EditMode(false);
            		self.IsEdit(true);
            		self.editableView(false);
            		self.GetPartnerById();
            		self.IsUpload(false);
            		self.PartnerCodeEnable(false);
            		$(document).ready(function () {
            			
            			$('#spnTitle').html("View Partner");
            		});
				
            	}
            	if (path == "Edit") {
            		self.IsSave(false);
            		self.IsEdit(false);
            		self.EditMode(true);
            		self.IsUpdate(true);
            		self.IsReset(true);
            		self.IsExit(true);
            		self.editableView(true);
            		self.IsUpload(true);
            		self.PartnerCodeEnable(false);
            		self.GetPartnerById();
            		//self.bufferPartnerType(model.partnerType);
            		
            		$(document).ready(function () {
            			$('#spnTitle').html("Edit Partner");
            			$("#contactNumber").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
            			SetFocus();
            		});

            	}
            }
            else {
                self.IsSave(true);
                self.IsUpdate(false);
                self.IsReset(true);
                self.IsExit(true);
                self.EditMode(true);
                self.IsEdit(false);
                self.editableView(true);
                self.IsUpload(true);
                $(document).ready(function () {
                	$('#spnTitle').html("Add Partner");
                });
          
            }
            self.applicationDisabled(false);

            self.PartnerModel().PartnerPortArray.push(self.Ports()[0].PortCode());
            self.viewMode('Form');
           
            $(document).ready(function () {
            	$('#spnTitile').html("Add Partner");
                $("#contactNumber").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                SetFocus();
            });

        }

        self.GetPartnerCode = function (model) {
            
            var PartnerTypeName = [];
            
            $.each(model.PartnerTypeArray(),function(index,item)
            {
                PartnerTypeName.push(item);

            });
           
           
            	self.viewModelHelper.apiGet("api/GetPartnerCodes", { partnerType: PartnerTypeName }, function (result) {
            		ko.mapping.fromJS(result, {}, self.partnerCodes);
            	}, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
            

        }

        self.LoadApplications = function () {
            self.viewModelHelper.apiGet("api/Applications", null, function (result) {
                ko.mapping.fromJS(result, {}, self.Applications);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        };

        self.LoadPorts = function () {
            self.viewModelHelper.apiGet("api/Ports", null, function (result) {
                ko.mapping.fromJS(result, {}, self.Ports);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        };

        self.LoadCountries = function () {
            self.viewModelHelper.apiGet("api/Countries", null, function (result) {
                ko.mapping.fromJS(result, {}, self.Countries);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        };

        self.LoadPartnerTypes = function () {
            self.viewModelHelper.apiGet("api/PartnerTypes", null, function (result) {
                ko.mapping.fromJS(result, {}, self.PartnerTypes);
            }, null, null, false, application.viewbag.appSettings.uamapiUrl, 'UAM');
        };

        self.EditPartner = function (model) {
            self.IsEdit(false);
            self.EditMode(true);
            self.IsUpdate(true);
            self.IsReset(true);
            self.IsExit(true);
            self.editableView(true);
            self.IsUpload(true);
            self.PartnerCodeEnable(false);
            self.bufferPartnerType(model.partnerType);
          
            $(document).ready(function () {
            	$('#spnTitle').html("Edit Partner");
                $("#contactNumber").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                SetFocus();
            });

        }


        self.ValidateControls = function (model) {
            self.PartnerModel().validationEnabled(true);
            model.validationEnabled(true)
            self.PartnerValidation = ko.observable(model);
            self.PartnerValidation().errors = ko.validation.group(self.PartnerValidation());
            var errors = 0, dateErrors = 0;
            errors = self.PartnerValidation().errors().length;
            var regexpforEmail = new RegExp(/^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i);

            if (model.PartnerTypeArray() == "") {

                errors = errors + 1;
                $('#validationParterType').text('* This field is required');
            }

            if (model.PartnerAddress().HouseNumber() == "") {

                errors = errors + 1;
                $('#validationHouseNumber').text('* This field is required');
            }
            if (model.PartnerAddress().StreetName() == "") {
                errors = errors + 1;
                $('#validationStreetName').text('* This field is required');

            }
            if (model.PartnerAddress().AreaName() == "") {

                errors = errors + 1;
                $('#validationAreaName').text('* This field is required');
            }
            if (model.PartnerAddress().TownOrCity() == "") {
                errors = errors + 1;
                $('#validationTownOrCity').text('* This field is required');

            }
            if (model.PartnerAddress().ZipCode() == "") {
                errors = errors + 1;
                $('#validationZipCode').text('* This field is required');

            }
            if (model.PartnerAddress().ContactNumber() == "") {
                errors = errors + 1;
                $('#validationContactNumber').text('* This field is required');

            }

            if (model.PartnerAddress().EmailId() == "") {
                errors = errors + 1;
                $('#validationEmailId').text('* This field is required');

            }

            if (model.PartnerAddress().Country() == undefined) {
                errors = errors + 1;
                $('#validationCountry').text('* This field is required');

            }

            if (model.PartnerAddress().State() == undefined) {
                errors = errors + 1;
                $('#validationState').text('* This field is required');

            }

            if (model.PartnerAddress().EmailId() != "") {

                if (!regexpforEmail.test(model.PartnerAddress().EmailId())) {
                    errors = errors + 1;
                    $('#validationEmailId').text('Enter Valid Email Id');
                }
            }


            if (model.PartnerAddress().ContactNumber() != "") {

                var telenumber1 = model.PartnerAddress().ContactNumber();
                telenumber1 = telenumber1.replace(/(\)|\()|_|-+/g, '');
                if (telenumber1.length != 13) {
                    errors = errors + 1;
                    $('#validationContactNumber').text('Enter Valid Contact Number');

                }
                if (parseInt(telenumber1) === 0) {
                    errors = errors + 1;
                    $('#validationContactNumber').text('Enter Valid Contact Number');
                }
            }

            //if (model.PartnerAddress().LogoFileName() == "") {

            //    $('#validationLogo').text('Please Select Logo');

            //}


            //if (model.PartnerAddress().WebSite() == "") {
            //    errors = errors + 1;
            //    $('#validationWebSite').text('* * This field is required');

            //}
            if (errors > 0) {
                self.PartnerValidation().errors.showAllMessages()
            }

            return errors;


        }

        self.SaveScreen = function (model) {
        	var errors = self.ValidateControls(model);
        	if (errors == 0) {
        		self.GetPartnerCode(model);
        		$.each(self.partnerCodes(), function (k, v) {
        			if (v.PartnerCode().toUpperCase() == model.PartnerCode().toUpperCase()) {
        				toastr.warning("Partner Code Already Exists For This Partner Type", "Partner");
        				errors = errors + 1;
        			}

        		});
        	}

            if (errors == 0) {

                $.confirm({
                    'title': 'Partner',
                    'message': 'Are you sure you want to Save Partner?',
                    'buttons': {
                        'Yes': {
                            'class': 'green',
                            'action': function () {
                            	$('#clolebt').trigger('click');
                                if (model.PartnerAddress().ContactNumber() != "") {
                                    var telenumber1 = model.PartnerAddress().ContactNumber();
                                    telenumber1 = telenumber1.replace(/(\)|\()|_|-+/g, '');
                                    model.PartnerAddress().ContactNumber(telenumber1);
                                }
                                self.viewModelHelper.apiPost('api/Partner', ko.mapping.toJSON(model), function Message(data) {
                                    toastr.options.closeButton = true;
                                    toastr.options.positionClass = "toast-top-right";
                                    toastr.success("Partner Details saved successfully.", "Partner");
                                    setTimeout(
                                            function () {
                                                window.location.href = "../../Partners";
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


        self.ResetScreen = function (model) {

            $.confirm({
                'title': 'Partner',
                'message': 'Are you sure you want to Reset Partner?',
                'buttons': {
                    'Yes': {
                        'class': 'green',
                        'action': function () {
                        	$('#clolebt').trigger('click');
                            self.ResetPartner(model);
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

        self.UpdateScreen = function (model) {

            var errors = self.ValidateControls(model);

            if (errors == 0) {

                $.confirm({
                    'title': 'Partner',
                    'message': 'Are you sure you want to Update Partner?',
                    'buttons': {
                        'Yes': {
                            'class': 'green',
                            'action': function () {
                            	$('#clolebt').trigger('click');
                                if (model.PartnerAddress().ContactNumber() != "") {

                                    var telenumber1 = model.PartnerAddress().ContactNumber();
                                    telenumber1 = telenumber1.replace(/(\)|\()|_|-+/g, '');
                                    model.PartnerAddress().ContactNumber(telenumber1);


                                }
                               
                                self.viewModelHelper.apiPost('api/UpdatePartner', ko.mapping.toJSON(model), function Message(data) {
                                    toastr.options.closeButton = true;
                                    toastr.options.positionClass = "toast-top-right";
                                    toastr.success("Partner Details updated successfully.", "Partner");
                                    setTimeout(
                                            function () {
                                                window.location.href = "../../Partners";
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

        self.ResetPartner = function (model) {

            if (self.IsSave()) {

                model.PartnerCode('');
                model.PartnerType(undefined);
                model.PartnerName('');
                model.PartnerPort('');
                model.PartnerTypeArray('');
                //model.Application(undefined);
                // self.PartnerModel().PartnerPortArray.push(self.Ports()[0].PortCode());
                model.PartnerAddress().HouseNumber('');
                model.PartnerAddress().StreetName('');
                model.PartnerAddress().AreaName('');
                model.PartnerAddress().TownOrCity('');
                model.PartnerAddress().ZipCode('');
                model.PartnerAddress().ContactNumber('');
                model.PartnerAddress().Country(undefined);
                model.PartnerAddress().State(undefined);
                model.PartnerAddress().EmailId('');
                model.PartnerAddress().WebSite('');
                $('#fileToUpload').val('');
                $('#sigImage').attr('src', "");
                model.PartnerAddress().LogoFileName('');
                model.PartnerAddress().LogoPath(''); 
                model.validationEnabled(false);
                $('#validationHouseNumber').text('');
                $('#validationStreetName').text('');
                $('#validationAreaName').text('');
                $('#validationTownOrCity').text('');
                $('#validationZipCode').text('');
                $('#validationCountry').text('');
                $('#validationContactNumber').text('');
                $('#validationState').text('');
                $('#validationEmailId').text('');
                $('#validationParterType').text('');

            }
            else {
            	self.Initialize();
            	//model.PartnerType(undefined);
            	//model.PartnerTypeArray('');
            	//self.PartnerModel().PartnerTypeArray('');
                //self.GetPartnerById();
                //model.validationEnabled(false);
                //// self.PartnerModel().PartnerPortArray.push(self.Ports()[0].PortCode());
                //$(document).ready(function () {
                //    $("#contactNumber").kendoMaskedTextBox({ mask: "(000)000-000-0000" });
                //    SetFocus();
                //});
                //$('#validationHouseNumber').text('');
                //$('#validationStreetName').text('');
                //$('#validationAreaName').text('');
                //$('#validationTownOrCity').text('');
                //$('#validationZipCode').text('');
                //$('#validationCountry').text('');
                //$('#validationContactNumber').text('');
                //$('#validationEmailId').text('');
                //$('#validationState').text('');
                //$('#validationParterType').text('');
            }

        }

        self.validatepartnerType = function () {
           
            if (self.PartnerModel().PartnerTypeArray() != "") {
                $('#validationParterType').text('');
            }
             setTimeout(function () {
                 $("#partnerName").focus();
            },2300);
        }
        self.SelectStates = function (model) {
            if (model.Country() !== undefined && model.Country() !== null && model.Country() !== "") {
                $.each(self.Countries(), function(k, v) {
                    if (v.CountryCode() == model.Country()) {
                        ko.mapping.fromJS(v.States, {}, self.States);
                        $.each(self.States(), function(item) {
                            self.States().sort(function(a, b) {
                                var nameA = a.StateName().toLowerCase(), nameB = b.StateName().toLowerCase();
                                if (nameA < nameB)
                                    return -1;
                                if (nameA > nameB)
                                    return 1;
                                return 0;
                            });
                        });
            }
                });
            } else {
                self.States([]);
            }
        }

        self.ExitScreen = function (model) {

        	self.cancel();
        }

        self.uploadFile = function (e) {
            var uploadedFiles = [];
            var documentData = [];
            uploadedFiles = self.PartnerModel().PartnerAddress().UploadedFiles();
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
                            elem.IsAlreadyExists = false

                            uploadedFiles.push(elem);
                            self.PartnerModel().PartnerAddress().UploadedFiles(uploadedFiles);

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

                ko.utils.arrayMap(self.PartnerModel().PartnerAddress().UploadedFiles(), function (item) {
                    formData.append(item.FileName, item.FileDetails);
                });


                self.viewModelHelper.apiUpload('api/FileUpload/ImageUpload?documentType=Doc1', formData, function Message(data) {
                    ko.utils.arrayMap(data, function (item) {
                        self.PartnerModel().PartnerAddress().LogoFileName(item.OrginalFileName);
                        self.PartnerModel().PartnerAddress().LogoPath(item.FileName);

                    });
                }, null, null, null,null, 'UAM');

                //var formData = new FormData();

                //ko.utils.arrayMap(self.PartnerModel().PartnerAddress().UploadedFiles(), function (item) {
                //    formData.append(item.FileName, item.FileDetails);
                //});

                //self.viewModelHelper.apiUpload('api/FileUpload/MultipleFileUpload', null, function Message(data) {
                //    ko.utils.arrayMap(data, function (item) {
                //        formData.append(item.FileName, item.FileDetails);

                //    });
                //});

            } else {
                toastr.warning("Please select image", "Error");
            }
            if (opmlFile.files.length > 0) {
                self.PartnerModel().PartnerAddress().UploadedFiles([]);

                $('#fileToUpload').val('');
                $('#sigImage').attr('src', "");
            }
            return;
        }

        self.cancel = function () {
            window.location.href = "/Partners";
           
        }

        self.DupliacteValidation = function (model) {
        	if (PartnerId != "" && PartnerId != undefined && PartnerId != null) {
        		if (model.PartnerTypeArray().length > 0) {
        			self.GetPartnerCode(model);
        		}

                $.each(self.partnerCodes(), function (k, v) {
                    if (v.PartnerId() != model.PartnerId()) {
                        if (v.PartnerCode().toUpperCase() == model.PartnerCode().toUpperCase()) {
                            toastr.warning("Partner Code Already Exists For This Partner Type", "Partner");

                        }
                    }

                });
            }
        	else {
        // Validation for Duplicate partner in Add Partner Screen
        	    if (model.PartnerTypeArray().length > 0) {
        			self.GetPartnerCode(model);
        		}
                $.each(self.partnerCodes(), function (k, v) {
                    if (v.PartnerCode().toUpperCase() == model.PartnerCode().toUpperCase()) {
                        toastr.warning("Partner Code Already Exists For This Partner Type", "Partner");

                    }

                });
        	}
        	
        	}

	    self.Initialize();

    }
    eGateRoot.PartnerViewModel = PartnerViewModel;
}(window.eGateRoot));


validateHouseNumber = function () {

    if ($('#houseNumber').val() != "") {

        $('#validationHouseNumber').text('');

    }


}

validateLogo = function () {

    if (model.PartnerAddress().LogoFileName() != "") {

        $('#validationLogo').text('');

    }

}
validateStreetName = function () {

    if ($('#streetName').val() != "") {

        $('#validationStreetName').text('');

    }

}



validateareaName = function () {

    if ($('#areaName').val() != "") {

        $('#validationAreaName').text('');

    }

}

validatetownOrCity = function () {

    if ($('#townOrCity').val() != "") {

        $('#validationTownOrCity').text('');

    }

}

validatezipCode = function () {

    if ($('#zipCode').val() != "") {

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

validateEmailId = function () {

    if ($('#emailId').val() != "") {

        $('#validationEmailId').text('');

    }

}


validateState = function () {

    if ($('#ddlState').val() != undefined) {

        $('#validationState').text('');

    }

}

function SetFocus() {
    $("#contactNumber").bind("focus", function () {
        if (this.createTextRange) {
            var part = this.createTextRange();
            part.move("character", 0);
            part.select();
        } else if (this.setSelectionRange) {
            var maskedinput = this;
            setTimeout(function () {
                maskedinput.setSelectionRange(0, 0);
            }, 0)
        }
    });
}
