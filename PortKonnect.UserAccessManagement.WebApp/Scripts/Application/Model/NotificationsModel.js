(function (eGateRoot) {

    var NotificationsModel = function (data) {
         
        var self = this;
        self.NotificationId = ko.observable();
        self.ApplicationId = ko.observable();
        self.MemberId = ko.observable();
        self.TemplateId = ko.observable();
        self.ReferenceId = ko.observable();
        self.NotificationText = ko.observable();
        self.CreatedOn = ko.observable();
        self.FromDate = ko.observable();
        self.ToDate = ko.observable();
        self.TotalCount = ko.observable();
        self.cache = function () { };
        self.set(data);

    }


    var ConversationModel = function (data)
    {

    	var self = this;
    	self.UsersId = ko.observable();
    	self.UserName = ko.observable();
    	self.ToUserId = ko.observable();
    	self.ToUserId = ko.observable();
    	self.FromUserId = ko.observable();
    	self.ApplicationId = ko.observable();
    	self.SubscriberId = ko.observable();
    	self.IsDeleted = ko.observable();
    	self.RecordStatus = ko.observable();
    	self.LoginUserId = ko.observable();
    	self.cache = function () { };
    	self.set(data);

    }

    var ContextModel = function (data)
    {
    	var self = this;


    	self.SubscriberId = ko.observable();
    	self.PortCode = ko.observable();
    	self.UserId = ko.observable();
    	self.UserName = ko.observable();
    	self.MemberId = ko.observable();
    	self.MemberType = ko.observable();
    	self.PartnerLogo = ko.observable();
    	
    	self.cache = function () { };
    	self.set(data);

    }

    var ConversationReply = function (data) {
    	var self = this;
    	self.ConversationID = ko.observable(data ? data.ConversationID : "");
    	self.Message = ko.observable(data ? data.Message : "");
    	self.UserId = ko.observable(data ? data.userID : "");
    	self.ConversationReplyID = ko.observable(data ? data.ConversationReplyID : "");
    	self.IsRead = ko.observable(data ? data.IsRead : "");
    	self.ToUserId = ko.observable(data ? data.ToUserId : "");
    	self.FromUserId = ko.observable(data ? data.FromUserId : "");
    }


    var ContainerModel = function (data) {
        var self = this;
        self.ContainerFlowId = ko.observable();
        self.ContainerNumber = ko.observable();
        self.WorkflowId = ko.observable();
        self.PreviousStep = ko.observable();
        self.StepToBePerformed = ko.observable();
        self.ActionsList = ko.observable();
        self.Entity = ko.observable();
        self.SubEntity = ko.observable();
        self.EntityReferenceId = ko.observable();
        self.WorkflowVersion = ko.observable();
        self.ActionNavigation = ko.observable();
        self.ActionLink = ko.observable();
        self.Data = ko.observable();
        self.DataObject = ko.observable();
        self.Status = ko.observable();
        self.StepFieldsToShow = ko.observable();
        self.DoneByUserName = ko.observable();
        self.DoneByUserId = ko.observable();
        self.DoneByPartnerName = ko.observable();
        self.DoneByPartnerId = ko.observable();
        self.ToBeDoneByPartnerName = ko.observable();
        self.ToBeDoneByPartnerId = ko.observable();
        self.IsoCode = ko.observable();
        self.LoadedorEmpty = ko.observable();
        self.VesselVoyageId = ko.observable();
        self.DoneOn = ko.observable();
        self.UpdatedOn = ko.observable();
        self.DateTimeToDisplay = ko.observable();
        self.WorkFlowStepNameToDisplay = ko.observable();

        self.cache = function () { };
        self.set(data);
    }

    var ContainerManageModel = function (data) {
        var self = this;
        self.ContainerNumber = ko.observable("");
        self.VesselName = ko.observable("");
        self.VoyageNumber = ko.observable("");
        self.ContainerModelList = ko.observableArray();
        self.ContainerModel = ko.observableArray(data ? ko.utils.arrayMap(data, function (task) { return new eGateRoot.ContainerModel(task); }) : []);
    }

    var ContainerDetailsModel = function (data) {
        var self = this;
        self.LabelText = ko.observable("");
        self.ValueText = ko.observable("");
    }

    eGateRoot.ContainerManageModel = ContainerManageModel;
    eGateRoot.ContainerDetailsModel = ContainerDetailsModel;
    eGateRoot.ContainerModel = ContainerModel;






    eGateRoot.NotificationsModel = NotificationsModel;
    eGateRoot.ConversationModel = ConversationModel;
    eGateRoot.ContextModel = ContextModel;
    eGateRoot.ConversationReply = ConversationReply;

}(window.eGateRoot));

eGateRoot.ContainerModel.prototype.set = function (data) {
    var self = this;
    self.ContainerFlowId(data ? data.TaskId || "" : "");
    self.ContainerNumber(data ? data.ContainerNumber || "" : "");
    self.WorkflowId(data ? data.WorkflowId || "" : "");
    self.PreviousStep(data ? data.PreviousStep || "" : "");
    self.StepToBePerformed(data ? data.StepToBePerformed || "" : "");
    self.ActionsList(data ? data.ActionsList || "" : "");
    self.Entity(data ? data.Entity || "" : "");
    self.SubEntity(data ? data.SubEntity || "" : "");
    self.EntityReferenceId(data ? data.EntityReferenceId || "" : "");
    self.WorkflowVersion(data ? data.WorkflowVersion || "" : "");
    self.ActionNavigation(data ? data.ActionNavigation || "" : "");
    self.ActionLink(data ? data.ActionLink || "" : "");
    self.Data(data ? data.Data || "" : "");
    self.DataObject(data ? data.DataObject || "" : "");
    self.Status(data ? data.Status || "" : "");
    self.StepFieldsToShow(data ? data.StepFieldsToShow || "" : "");
    self.DoneByUserName(data ? data.DoneByUserName || "" : "");
    self.DoneByUserId(data ? data.DoneByUserId || "" : "");
    self.DoneByPartnerName(data ? data.DoneByPartnerName || "" : "");
    self.DoneByPartnerId(data ? data.DoneByPartnerId || "" : "");
    self.ToBeDoneByPartnerName(data ? data.ToBeDoneByPartnerName || "" : "");
    self.ToBeDoneByPartnerId(data ? data.ToBeDoneByPartnerId || "" : "");
    self.IsoCode(data ? data.IsoCode || "" : "");
    self.LoadedorEmpty(data ? data.LoadedorEmpty || "" : "");
    self.VesselVoyageId(data ? data.VesselVoyageId || "" : "");
    self.DoneOn(data ? kendo.toString(kendo.parseDate(data.DoneOn, ["dd-MM-yyyy HH:mm", "yyyy-MM-ddTHH:mm:ss"]), "dd-MM-yyyy HH:mm") : '');
    self.UpdatedOn(data ? data.UpdatedOn || "" : "");
    self.WorkFlowStepNameToDisplay(data ? data.WorkFlowStepNameToDisplay || "" : "");
    self.DateTimeToDisplay(data ? kendo.toString(kendo.parseDate(data.DateTimeToDisplay, ["dd-MM-yyyy HH:mm", "yyyy-MM-ddTHH:mm:ss"]), "dd-MM-yyyy HH:mm") : '');

    self.cache.latestData = data;
}

eGateRoot.ContainerModel.prototype.reset = function () {
    this.set(this.cache.latestData);
}
eGateRoot.NotificationsModel.prototype.set = function (data) {
    var self = this;
    self.NotificationId(data ? (data.NotificationId || "") : "");
    self.ApplicationId(data ? (data.ApplicationId || "") : "");
    self.MemberId(data ? (data.MemberId || "") : "");
    self.TemplateId(data ? (data.TemplateId || "") : "");
    self.ReferenceId(data ? (data.ReferenceId || "") : "");
    self.NotificationText(data ? (data.NotificationText || "") : "");
    self.CreatedOn(data ? (data.CreatedOn || "") : "");
    self.FromDate(data ? kendo.toString(kendo.parseDate(data.Createdby, ["dd-MM-yyyy HH:mm", "yyyy-MM-ddTHH:mm:ss"]), "dd-MM-yyyy HH:mm") : '');
    self.ToDate(data ? kendo.toString(kendo.parseDate(data.Createdby, ["dd-MM-yyyy HH:mm", "yyyy-MM-ddTHH:mm:ss"]), "dd-MM-yyyy HH:mm") : '');
    self.TotalCount(data ? (data.TotalCount || 0) : 0);
    self.cache.latestData = data;
}


eGateRoot.ConversationModel.prototype.set = function (data) {
	var self = this;
	self.UsersId(data ? (data.UserId || "") : "");
	self.UserName(data ? (data.UserName || "") : "");
	self.FromUserId(data ? (data.FromUserId || "") : "");



	self.cache.latestData = data;
}


eGateRoot.ContextModel.prototype.set = function (data) {
	var self = this;
	self.SubscriberId(data ? (data.SubscriberId || "") : "");
	self.PortCode(data ? (data.PortCode || "") : "");
	self.UserId(data ? (data.UserId || "") : "");
	self.UserName(data ? (data.UserName || "") : "");
	self.MemberId(data ? (data.MemberId || "") : "");
	self.MemberType(data ? (data.MemberType || "") : "");
	self.PartnerLogo(data ? (data.PartnerLogo || "") : "");



	self.cache.latestData = data;
}


eGateRoot.ContextModel.prototype.reset = function () {
	this.set(this.cache.latestData);
}
eGateRoot.ConversationModel.prototype.reset = function () {
	this.set(this.cache.latestData);
}

eGateRoot.NotificationsModel.prototype.reset = function () {
    this.set(this.cache.latestData);
}