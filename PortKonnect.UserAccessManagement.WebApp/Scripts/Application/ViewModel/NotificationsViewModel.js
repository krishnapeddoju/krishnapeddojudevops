(function (eGateRoot) {
    var NotificationsViewModel = function () {

        var self = this;
        self.viewModelHelper = new eGateRoot.ViewModelHelper();
        self.sysNotifications = ko.observableArray([]);
        self.notificationModel = ko.observable(new eGateRoot.NotificationsModel());
        self.conversationModel = ko.observable(new eGateRoot.ConversationModel());
        self.contextModel = ko.observable(new eGateRoot.ContextModel());
        self.getConversationUserDetails = ko.observableArray([]);
        self.getConversations = ko.observableArray([]);       
        

        self.getMessages = ko.observableArray([]);
        self.TotalCount = ko.observable();
        self.userslist = ko.observableArray([]);
        self.RefUserName = ko.observable();
        self.Total = ko.observable(0);
        self.UserManualModelLink = ko.observable();
        self.TaskCount = ko.observable(0);
        self.EventsCount = ko.observable(0);
        self.validationHelper = new eGateRoot.ValidationHelper();
        self.ContainerManageModel = ko.observable();
        self.RefContainerNumber = ko.observable();
        self.viewMode = ko.observable();
        self.DisplayVesselVoyageDetails = ko.observable(false);
        self.IsLogoDispaly = ko.observable(false);

        self.LoadSysNotifications = function () {
            self.viewModelHelper.apiGet('api/Account/GetSystemNotifications',
                null,
                function (result) {
                	if (result != null) {
                		self.sysNotifications([]);
                		for (var i = 0; i < result.length; i++) {
                			self.sysNotifications.push(new eGateRoot.NotificationsModel(result[i]));
                		}
                		self.Total(self.sysNotifications()[0].TotalCount());
                	}
                   },
                    null, null, true, application.viewbag.appSettings.uamapiUrl, 'UAM');
        }

        self.LoadMyTaskCount = function () {

            self.viewModelHelper.apiGet('api/GetMyTasksCount', null, function (result) {
                if (result != null) {
                    self.TaskCount(result);
                }
            }, null, null, true, null, 'TASK');
        }


        self.LoadEventsCount = function ()
        {
            self.viewModelHelper.apiGet('api/GetNewsCount', null, function (result) {
                if (result != null) {
                    self.EventsCount(result);
                }
            }, null, null, true);

        }


        self.LoadTasks= function() {
           
            window.location.href = "../../../../../../../../../../../../../Tasks";
        }

        self.GetNotificationCount = function () {
            
            self.viewModelHelper.apiGet('api/Account/GetSystemNotificationsCount',
                null,
                function (result) {
                	if (result != null) {
                		self.Total(result);
                	}
                   },
                    null, null, true, application.viewbag.appSettings.uamapiUrl, 'UAM');

        }

        self.NotificationStatus = function (model) {
            var notificationId = model.NotificationId();
            self.viewModelHelper.apiPost('api/Account/UpdateSystemNotification',
         ko.mapping.toJSON(model),
           function (result) {
               self.GetNotificationCount();
           }, null, null,  application.viewbag.appSettings.uamapiUrl,null, 'UAM');

        }

        self.GetHelpLink = function () {
            
            self.viewModelHelper.apiGet('api/GetHelpLink', null, function (result) {
                if (result != null) {
                    $('#infoLink').removeClass('hidden');
                    self.UserManualModelLink(result.Url);
                }
            }, null, null, true);

        }

      
        
        self.clickMe = function (data)
        {
        	$("#chat_div1").text('');
        	$('#inputtextBox').val('')
        	self.viewModelHelper.apiGet('api/GetConversationReply/' + data.ConversationId() + '/' + self.contextModel().UserId,
            null,
            function (result) {
            	ko.mapping.fromJS(result, {}, self.getConversations);
            	self.getMessages();
            }, null, null, null, application.viewbag.appSettings.chatAPIUrl, 'CHAT');


        	
        

        	var box = null;
        	if (box != null) {
        		box.chatbox("option", "boxManager").toggleBox();
        	}

        	$("#chat_div1").chatbox(
                {
                	id: "FirstUser",
                	user:
                    {
                    	key: "value"
                    },
                	title: data.UserName(),
                	offset: 0,
                	messageSent: function (id, user, msg) {
                		self.sendtext(msg, data.ConversationId(), self.contextModel().UserId, data.UserName(), data.ConversationId());
                	},
                	boxClosed: function () {

                		self.GetNewMessages();
                		$("#chat_div1").text('');
                	}
                });

        	$("#newtitle").text(data.UserName().toLowerCase());
        	self.GetNewMessages();


        }


        self.GetNewMessages = function () {
        	self.viewModelHelper.apiGet('api/GetMessages/' + self.contextModel().UserId,
            null,
              function (result) {
              	ko.mapping.fromJS(result, {}, self.getMessages);
              }, null, null, null, application.viewbag.appSettings.hostingurl, 'CHAT');
        }

        function htmlEncode(value) {
        	var encodedValue = $('<div />').text(value).html();
        	return encodedValue;
        }
        self.sendtext = function (msg, conversationID, userID, userName) {
        	var ConversationReply = new eGateRoot.ConversationReply();
        	ConversationReply.ConversationID(conversationID);
        	ConversationReply.Message(msg);
        	ConversationReply.UserId(userID);


        	self.viewModelHelper.apiPost('api/AddConversationReply',
            ko.mapping.toJSON(ConversationReply),
            function (result) {
            	$('#users').val('');
            	$('#spid1').text('');
            	$(".close").trigger("click");
            }, null, null, application.viewbag.appSettings.chatAPIUrl, null, 'CHAT');
        	
        	
        	var chat = $.connection.chatHub;
        	

        	chat.client.broadcastMessage = function (UserName, Message, userId, conversationId) {
        	
        	
        		
        		$("#chat_div1").text('');
        		self.viewModelHelper.apiGet('api/GetConversationBroadCastReply/' + conversationId + '/' + userId,
            null,
            function (result) {
            	ko.mapping.fromJS(result, {}, self.getConversations);
            
            }, null, null, null, application.viewbag.appSettings.chatAPIUrl, 'CHAT');
        		$("#newtitle").text(UserName.toLowerCase());
        		$("#chat_div1").chatbox("option", "boxManager").addMsg(UserName.toLowerCase(), Message);
        	};

        	$.connection.hub.start().done(function () {
        		chat.server.send(userID, userName.toLowerCase(), msg, conversationID);
        		$("#chat_div1").chatbox("option", "boxManager").addMsg($('#loginname').text(), msg);
        	});
        	function htmlEncode(value) {
        		var encodedValue = $('<div />').text(value).html();
        		return encodedValue;
        	}
        	}
        self.readAllNotifications = function (model)
        {
        	self.viewModelHelper.apiPost('api/Account/UpdateAllSystemNotification',null,
            function (result) {
                self.GetNotificationCount();
            }, null, true, application.viewbag.appSettings.uamapiUrl, null, 'UAM');
        	
        }

        self.clearUserName = function ()
        {
        	self.getUsers();
        	$('#users').val('');
        	$('#spid1').text('');

        }

        self.UserSelect = function (e) {
        	
        	var selecteddataItem = this.dataItem(e.item.index());
        	self.conversationModel().UserName(selecteddataItem.UserName);
        	self.conversationModel().UsersId(selecteddataItem.UsersId);
        	self.RefUserName(selecteddataItem.UserName);
        }

        self.userSelectChange = function (model)
        {
        	
        	if (self.RefUserName() !== model.UserName())
        	{
        		
        		self.conversationModel().UserName('');
        		self.conversationModel().UsersId('');
        	

        	}

        }
        self.getUsers = function ()
        {
        	self.viewModelHelper.apiGet('api/GetUsers',
		   null,
			 function (result) {

			 	self.userslist(ko.utils.arrayMap(result, function (item) {
			 		return new eGateRoot.ConversationModel(item);
			 	}));

			 }, null, null, null, application.viewbag.appSettings.uamapiUrl, 'UAM');


        }


        self.getContext = function () {
            self.viewModelHelper.apiGet('api/GetContext',
		   null,
		     function (result) {

		     	if (result.PartnerLogo === '' || result.PartnerLogo === null || result.PartnerLogo === undefined) {
		     		self.IsLogoDispaly(true);

		     		result.PartnerLogo = application.viewbag.appSettings.defaultLogo;
		     	}
		     	else {
		     		self.IsLogoDispaly(false);
		     		result.PartnerLogo = application.viewbag.appSettings.logoPathPartner + result.PartnerLogo;
			 		
		     	}


		     	return self.contextModel(result);
			 

		     }, null, null, true, application.viewbag.appSettings.uamapiUrl, 'UAM');


        }


        self.addUser = function (model)
        {
        	if (model.UsersId() == undefined || model.UsersId() == "") {
        		$('#spid1').text('Please Select User');
        		return;
        	}


        	model.ToUserId(model.UsersId());
        	model.ApplicationId(clientId.split("-")[1]);
        	model.SubscriberId(clientId.split("-")[0]);
        	model.IsDeleted("N");
        	model.RecordStatus("A");
        	model.FromUserId(self.contextModel().UserId);
        	self.viewModelHelper.apiPost('api/AddConversation',
            ko.mapping.toJSON(model),
            function (result) {

            	toastr.options.closeButton = true;
            	toastr.options.positionClass = "toast-top-right";
            	toastr.success("User Added Successfully", "User");
            
            	$('#users').val('');
            	$('#spid1').text('');
            	$(".close").trigger("click");
            	self.GetConversationUsers();
            	$("#chat_div2").chatbox1(
            {
            	/*
                    unique id for chat box
                */
            	id: "UserList",
            	user:
                {
                	key: "value"
                },
            	/*
                    Title for the chat box
                */
            	title: "User List",
            	offset: 350,
            	/*
                    messageSend as name suggest,
                    this will called when message sent.
                    and for demo we have appended sent message to our log div.
                */
            	messageSent: function (id, user, msg) {
            		$("#log").append(id + " said: " + msg + "<br/>");
            		$("#chat_div2").chatbox1("option", "boxManager").addMsg(id, msg);
            	}
            });
            	self.getUsers();
            	
            }, null, false, application.viewbag.appSettings.chatAPIUrl, null, 'CHAT');
        	
        }


        self.GetConversationUsers = function ()
        {
        	self.viewModelHelper.apiGet('api/GetConversationUsers/'+self.contextModel().UserId,
            null,
            function (result) {
            	ko.mapping.fromJS(result, {}, self.getConversationUserDetails);
            }, null, null, null, application.viewbag.appSettings.chatAPIUrl, 'CHAT');


        }
        self.cancelUser = function () {

        	$('#users').val('');
        	$('#spid1').text('');
        	$(".close").trigger("click");
        }

        self.Initialize = function () {
        	self.contextModel = ko.observable(new eGateRoot.ContextModel());

        	self.UserManualModelLink('');
        	self.LoadMyTaskCount();
        	self.LoadEventsCount();
            self.GetNotificationCount();
        	self.getContext();
         //	self.GetNewMessages();
        	self.GetHelpLink();

            self.ContainerManageModel(new eGateRoot.ContainerManageModel());
            self.viewMode("Form");
            setTimeout(function () {
                $("#ContainerNumber").focus();
            }, 100);
        }
       
        self.SelectContainer = function (serachContainerNumber) {
            self.RefContainerNumber(this.dataItem(serachContainerNumber.item.index()));
            if (self.RefContainerNumber() !== undefined && self.RefContainerNumber() !== "" && self.RefContainerNumber() !== null) {
                self.viewModelHelper.apiGet('api/GetContainerSteps', { containerNumber: self.RefContainerNumber() },
                  function (result) {
                      if (result != null) {
                          self.ContainerManageModel().ContainerModel(ko.utils.arrayMap(result, function (item) {
                              return new eGateRoot.ContainerModel(item);
                          }));

                          $("#ContainerNumber").val(self.RefContainerNumber());
                          var index = 0;
                          if (self.ContainerManageModel().ContainerModel()[1] != null)
                              index = 1;

                          if (!isEmpty(self.ContainerManageModel().ContainerModel()[index].Data())) {
                              var containerArr = self.ContainerManageModel().ContainerModel()[index].Data().split(";");
                              self.ContainerManageModel().ContainerModelList([]);
                              for (var i = 0; i < containerArr.length; i++) {
                                  var obj = new eGateRoot.ContainerDetailsModel();
                                  if (!isEmpty(containerArr[i])) {
                                      obj.LabelText(containerArr[i].split(":")[0]);
                                      obj.ValueText(containerArr[i].split(":")[1]);
                                      if (isEmpty(obj.ValueText().trim()))
                                          obj.ValueText("N/A");
                                      self.ContainerManageModel().ContainerModelList.push(obj);
                                  }
                              }

                              self.ContainerManageModel().VesselName(self.ContainerManageModel().ContainerModelList()[0].ValueText());
                              self.ContainerManageModel().VoyageNumber(self.ContainerManageModel().ContainerModelList()[1].ValueText());
                              self.DisplayVesselVoyageDetails(true);
                          }
                      }
                  }
                  //, null, null, false, null, 'CSA'
                  );
            }
            $('#showPopup').trigger('click');
        }

        self.ChangeContainer = function (data) {
            if (self.RefContainerNumber() !== self.ContainerManageModel().ContainerNumber()) {
                data.ContainerNumber("");
                self.DisplayVesselVoyageDetails(false);
                self.ContainerManageModel(new eGateRoot.ContainerManageModel());
                return false;
            }
           
        }

        self.closeRejectPopup = function () {
            $('#reject').modal('hide');
        }
        self.closeContainerkPopup = function () {
            $('#containerPopup').modal('hide');
        }

        self.Initialize();
    }

    eGateRoot.NotificationsViewModel = NotificationsViewModel;
}(window.eGateRoot));