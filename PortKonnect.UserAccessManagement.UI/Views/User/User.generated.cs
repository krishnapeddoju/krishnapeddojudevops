﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/User/User.cshtml")]
    public partial class _Views_User_User_cshtml : System.Web.Mvc.WebViewPage<PortKonnect.UserAccessManagement.Domain.DTOS.PrivilegeDTO>
    {
        public _Views_User_User_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\User\User.cshtml"
  
	ViewBag.Title = "User";
	Layout = "~/Views/Shared/_eGateLayout.cshtml";
    

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("scripts", () => {

WriteLiteral("<script");

WriteAttribute("src", Tuple.Create(" src=\"", 180), Tuple.Create("\"", 229)
, Tuple.Create(Tuple.Create("", 186), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Application/CustomisedControls.js")
, 186), false)
);

WriteLiteral("></script>\r\n\t<script");

WriteAttribute("src", Tuple.Create(" src=\"", 250), Tuple.Create("\"", 312)
, Tuple.Create(Tuple.Create("", 256), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Application/UAM/Model/UserRegistrationModel.js")
, 256), false)
);

WriteLiteral("></script>\r\n\t<script");

WriteAttribute("src", Tuple.Create(" src=\"", 333), Tuple.Create("\"", 403)
, Tuple.Create(Tuple.Create("", 339), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Application/UAM/ViewModel/UserRegistrationViewModel.js")
, 339), false)
);

WriteLiteral("></script>\r\n");

});

WriteLiteral("\r\n");

DefineSection("ko_apply", () => {

WriteLiteral("\r\n\tvar viewModel = new eGateRoot.UserRegistrationViewModel(\"");

            
            #line 15 "..\..\Views\User\User.cshtml"
                                                        Write(ViewBag.userId);

            
            #line default
            #line hidden
WriteLiteral("\",\"");

            
            #line 15 "..\..\Views\User\User.cshtml"
                                                                          Write(ViewBag.Path);

            
            #line default
            #line hidden
WriteLiteral("\");  \r\n  ko.applyBindingsWithValidation(viewModel, $(\"#User\")[0], { insertMessage" +
"s: false, messagesOnModified: false, grouping: { deep: true }});\r\n");

});

WriteLiteral("\r\n\r\n");

WriteLiteral("\r\n\r\n<div");

WriteLiteral(" id=\"User\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" data-bind=\"visible: viewMode() == \'Form\', template: { name: \'User-template\' }\"");

WriteLiteral("></div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral("></div>\r\n\r\n<div");

WriteLiteral(" class=\"portlet-body\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\"table-toolbar\"");

WriteLiteral(">\r\n\r\n\t\t<script");

WriteLiteral(" type=\"text/html\"");

WriteLiteral(" id=\"User-template\"");

WriteLiteral(@">

			<div class=""portlet-body"">
				<div class=""table-toolbar"">
					<div class=""portlet portlet-body form"" data-bind=""loadingWhen: $root.viewModelHelper.isLoading"">
						<div class=""form-wizard"">
							<div class=""form-body form-horizontal"" data-bind=""with: UserRegistrationModel"">
								<div class=""row"">
									<div class=""col-md-12"">
										<h3 class=""page-title""><span id=""spnTitle""></span></h3>
										<ul class=""page-breadcrumb breadcrumb""></ul>
									</div>
								</div>


								");

WriteLiteral("\r\n\t\t\t\t\t\t\t\t<div class=\"tab-pane active\" id=\"tab1\">\r\n\t\t\t\t\t\t\t\t\t<div class=\"form-grou" +
"p\">\r\n\r\n\r\n\t\t\t\t\t\t\t\t\t\t<fieldset>\r\n\t\t\t\t\t\t\t\t\t\t\t<legend>Users</legend>\r\n\t\t\t\t\t\t\t\t\t\t\t<di" +
"v class=\"row\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-6 ie-validation moz-margin1\">\r\n\t\t" +
"\t\t\t\t\t\t\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-label c" +
"ol-md-5\">Partner Type :<span class=\"required\">*</span></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<d" +
"iv class=\"col-md-7\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div data-bind=\"visible: $root.IsPartnerTyp" +
"elabel\" class=\"control-label\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"displaytxt col-md-" +
"12\" data-bind=\"text: PartnerTypeCode\"></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t" +
"\t\t\t\t\t\t<div data-bind=\"visible: $root.IsPartnerTypeVisible\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<di" +
"v class=\"form-control\" style=\"line-height: 20px;\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<select id=" +
"\"ddlPartnerType\" name=\"\" data-bind=\"kendoDropDownList: { data: $root.PartnerType" +
"s, dataTextField: \'PartnerTypeName\', optionLabel: \'Select...\', dataValueField: \'" +
"PartnerTypeId\', value: PartnerType, enable: $root.PartnerTypeenable }, event: { " +
"change: $parent.selectPartnerName }\"></select>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<span class=\"va" +
"lidationError\" data-bind=\"validationMessage: PartnerType\"></span>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t" +
"\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t" +
"\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-6 ie-validation moz-margin1\">\r" +
"\n\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-labe" +
"l col-md-5\">Partner :<span class=\"required\">*</span></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div" +
" class=\"col-md-7\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"form-control\" style=\"line-height:" +
" 20px;\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<select id=\"ddlPartner\" name=\"\" data-bind=\"enable: $ro" +
"ot.PartnerNameenable,kendoDropDownList: { data: $root.Partners, dataTextField: \'" +
"PartnerName\', optionLabel: \'Select...\', dataValueField: \'PartnerCode\', value: Pa" +
"rtnerId }\"></select>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<span class=\"validationError \" data-bind=\"" +
"validationMessage: PartnerId\"></span>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</di" +
"v>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t" +
"\t<div class=\"row\">\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-6\" data-bind=\"visible: $roo" +
"t.displayForSpecialRoles\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t" +
"\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-label col-md-5\">User Name :<span class=\"r" +
"equired\">*</span></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-7\">\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t" +
"\t\t<input type=\"text\" id=\"userName1\" name=\"\" class=\"form-control\" data-bind=\"valu" +
"e: UserName, event: { keypress: $root.validationHelper.ValidateAlphaNumeric, cha" +
"nge: $root.validateUserName }, enable: $root.IsUserNameEnable\" maxlength=\"30\">\r\n" +
"\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<span class=\"validationError\" data-bind=\"validationMessage: UserN" +
"ame\"></span>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t" +
"\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-6\" data-bind=\"visible: $root.displayUsername\">\r\n\t\t" +
"\t\t\t\t\t\t\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div data-bind=\"\" class=\"cont" +
"rol-label\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class" +
"=\"control-label col-md-5\">User Name :<span class=\"required\">*</span></label>\r\n\t\t" +
"\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-7\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"displaytxt cont" +
"rol-label col-md-4\" data-bind=\"text: PartnerTypeId() + $root.UserNameSeperator()" +
" + MemberTypeCode() + $root.UserNameSeperator(), visible: $root.showLabels\"></la" +
"bel>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-8\"><input type=\"text\" i" +
"d=\"userName\" name=\"\" class=\"form-control\" data-bind=\"value: UserName, event: { k" +
"eypress: $root.validationHelper.ValidateAlphaNumeric, change: $root.validateUser" +
"Name }, enable: $root.IsUserNameEnable\" maxlength=\"24\"></div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<s" +
"pan class=\"validationError\" data-bind=\"validationMessage: UserName\" style=\"displ" +
"ay: none;\"></span>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</d" +
"iv>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-6\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"form-group\">\r\n" +
"\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-label col-md-5\">First Name:<span class=\"requ" +
"ired\">*</span></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-7\">\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<" +
"input type=\"text\" id=\"firstName\" name=\"\" class=\"form-control\" data-bind=\"value: " +
"FirstName, event: { keypress: $root.validationHelper.ValidateAlphabetsWithSpaces" +
"_keypressEvent }, enable: $root.IsEnable\" maxlength=\"50\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<span " +
"class=\"validationError\" data-bind=\"validationMessage: FirstName\"></span>\r\n\t\t\t\t\t\t" +
"\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t" +
"\t\t\t\t\t\t\t\t\t<div class=\"row\">\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-6\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<" +
"div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-label col-md-5\">Las" +
"t Name:<span class=\"required\">*</span></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md" +
"-7\">\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<input type=\"text\" id=\"lastName\" name=\"\" class=\"form-cont" +
"rol\" data-bind=\"value: LastName, event: { keypress: $root.validationHelper.Valid" +
"ateAlphabetsWithSpaces_keypressEvent }, enable: $root.IsEnable\" maxlength=\"50\">\r" +
"\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<span class=\"validationError\" data-bind=\"validationMessage: Last" +
"Name\"></span>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n" +
"\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-6\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t" +
"\t\t\t\t\t\t\t\t\t<label class=\"control-label col-md-5\">User Ports :<span class=\"required" +
"\">*</span></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-7\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<input " +
"id=\"userPort\" data-bind=\"kendoMultiSelect: { data: $root.Ports, dataTextField: \'" +
"PortName\', dataValueField: \'PortCode\', value: UserPortArray, enable: $root.IsEna" +
"ble }\" />\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<span class=\"validationError\" data-bind=\"validationM" +
"essage: UserPortArray\"></span>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t" +
"\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t<div class=\"row\">\r\n\r\n\t\t\t\t\t\t\t\t" +
"\t\t\t\t<div class=\"col-md-6\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t" +
"\t<label class=\"control-label col-md-5\">Email Id :<span class=\"required\">*</span>" +
"</label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-7\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<input type=\"text" +
"\" id=\"emailId\" name=\"\" onchange=\"validateEmailId()\" class=\"form-control\" data-bi" +
"nd=\"value: EmailId, event: { keypress: $root.validationHelper.ValidateAlphanumer" +
"icEmail }, enable: $root.IsEnable\" maxlength=\"50\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<span class=\"" +
"validationError\" id=\"validationEmailId\"></span>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t" +
"\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-6\">\r\n\t\t\t\t\t\t\t\t" +
"\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-label col-md-" +
"5 \">Contact Number :<span class=\"required\">*</span></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div " +
"class=\"col-md-7 ie-validation moz-margin1\">\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<input type=\"text\"" +
" id=\"contactNumber\" name=\"\" class=\"form-control\" data-bind=\"value: ContactNumber" +
", event: { keypress: $root.validationHelper.ValidateNumeric }, enable: $root.IsE" +
"nable\" maxlength=\"13\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<span class=\"validationError \" id=\"contac" +
"tNum\" data-bind=\"validationMessage: ContactNumber\"></span>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>" +
"\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t<" +
"div class=\"row\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-6\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"f" +
"orm-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label id=\"lblheading4\" class=\"col-md-5 control-label" +
"\">Roles:<span class=\"required\" style=\"color: red\">*</span></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t" +
"\t\t<div class=\"col-md-7\">\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<input id=\"userRole\"  onchange=\"valid" +
"ateRole(this);\" data-bind=\"kendoMultiSelect: { data: $root.RolesList, dataTextFi" +
"eld: \'RoleName\', dataValueField: \'RoleId\', value: UserRoleArray, enable: $root.I" +
"sEnable }\" />\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<span id=\"spnrole\" class=\"validationError\"></spa" +
"n>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t" +
"</div>\r\n\t\t\t\t\t\t\t\t\t\t\t<div class=\"row\" data-bind=\"visible: $root.isDormantVisible\">" +
"\r\n\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-5\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"form-group\">\r" +
"\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-label col-md-6\">Is Dormant User? :<span cla" +
"ss=\"required\">&nbsp;&nbsp;</span></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-5\">\r" +
"\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<input type=\"Checkbox\" id=\"IsDormantUser\" name=\"IsDormantUser\" d" +
"ata-bind=\"checked: $parent.isDormantUser, enable: $root.isDormantEnable\" disable" +
"d=\"\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\r\n\r\n\t\t" +
"\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t<div class=\"row\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-" +
"6\" data-bind=\"visible: $root.IsRecordStatus\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"form-gro" +
"up\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-label col-md-5\">Status :<span class=\"r" +
"equired\">&nbsp;&nbsp;</span></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-7 control" +
"-label\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"displaytxt col-md-12\" data-bind=\"text: Re" +
"cordStatus\"></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</d" +
"iv>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t<fieldset>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<l" +
"egend>Notification Required</legend>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"row\">\r\n\t\t\t\t\t\t\t\t\t\t\t" +
"\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-4\" data-bind=\"with:" +
" UserPreference\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-label col-md-6\">Is Email" +
" Required :</label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-6\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<inp" +
"ut type=\"checkbox\" name=\"\" id=\"isEmail\" class=\"form-control\" data-bind=\"    chec" +
"ked: SendNotificationEmail, enable: $root.IsEnable\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t" +
"\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-4\" data-bind=\"with: UserPref" +
"erence\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-label col-md-6\">Is SMS Required :" +
"</label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-6\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<input type=\"ch" +
"eckbox\" name=\"\" id=\"isSms\" class=\"form-control\" data-bind=\"    checked: SendNoti" +
"ficationSms, enable: $root.IsEnable\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</di" +
"v>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-4\" data-bind=\"with: UserPreference\">\r\n\t\t\t\t\t" +
"\t\t\t\t\t\t\t\t\t\t<label class=\"control-label col-md-8\">Is System Notification Required " +
":</label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-4\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<input type=\"c" +
"heckbox\" name=\"\" id=\"isNotification\" class=\"form-control\" data-bind=\"    checked" +
": SendSystemNotification, enable: $root.IsEnable\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t" +
"\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t</fieldse" +
"t>\r\n\r\n\r\n\r\n\r\n\r\n\t\t\t\t\t\t\t\t\t\t</fieldset>\r\n\r\n\r\n\r\n\r\n\t\t\t\t\t\t\t\t\t\t<div class=\"btns-group fo" +
"rm-actions fluid\">\r\n\t\t\t\t\t\t\t\t\t\t\t<input type=\"button\" value=\"Save\" class=\"btn gree" +
"n\" data-bind=\"click: $root.SaveScreen, visible: $root.IsSave\" class=\"btn green\" " +
"/>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t<input type=\"button\" value=\"Update\" class=\"btn green\" data-bind" +
"=\"click: $root.UpdateScreen, visible: $root.IsUpdate\" />\r\n\t\t\t\t\t\t\t\t\t\t\t<button typ" +
"e=\"submit\" class=\"btn blue\" data-bind=\"click: $root.ResetScreen, visible: $root." +
"IsReset\">Reset</button>\r\n\t\t\t\t\t\t\t\t\t\t\t<button type=\"submit\" class=\"btn default but" +
"ton-previous\" data-bind=\"click: $root.ExitScreen\"><i class=\"m-icon-swapleft\"></i" +
">Back</button>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t<button type=\"submit\" class=\"btn blue\" data-bind=\"c" +
"lick: $root.Activate, visible: $root.IsActive\">Activate</button>\r\n\t\t\t\t\t\t\t\t\t\t\t<bu" +
"tton type=\"submit\" class=\"btn red\" data-bind=\"click: $root.DeActivate, visible: " +
"$root.IsInActive\">Deactivate</button>\r\n\r\n\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t" +
"\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t</div>\r\n\r\n\r\n\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t</div>\r\n\r\n\r\n\t\t\t\t</div>\r\n\t\t" +
"\t</div>\r\n\r\n\t\t</script>\r\n\t</div>\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
