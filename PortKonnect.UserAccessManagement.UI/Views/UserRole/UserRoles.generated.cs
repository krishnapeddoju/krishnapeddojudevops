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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/UserRole/UserRoles.cshtml")]
    public partial class _Views_UserRole_UserRoles_cshtml : System.Web.Mvc.WebViewPage<PortKonnect.UserAccessManagement.Domain.DTOS.PrivilegeDTO>
    {
        public _Views_UserRole_UserRoles_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\UserRole\UserRoles.cshtml"
      
    ViewBag.Title = "UserRoles";
    Layout = "~/Views/Shared/_eGateLayout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 193), Tuple.Create("\"", 225)
, Tuple.Create(Tuple.Create("", 199), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Lib/jquery-ui.js")
, 199), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 245), Tuple.Create("\"", 289)
, Tuple.Create(Tuple.Create("", 251), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Lib/jquery.slimscroll.min.js")
, 251), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 309), Tuple.Create("\"", 347)
, Tuple.Create(Tuple.Create("", 315), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Lib/form-components.js")
, 315), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 367), Tuple.Create("\"", 393)
, Tuple.Create(Tuple.Create("", 373), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Lib/app.js")
, 373), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 413), Tuple.Create("\"", 468)
, Tuple.Create(Tuple.Create("", 419), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Application/UAM/Model/UserRolesModel.js")
, 419), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 488), Tuple.Create("\"", 551)
, Tuple.Create(Tuple.Create("", 494), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Application/UAM/ViewModel/UserRolesViewModel.js")
, 494), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 571), Tuple.Create("\"", 601)
, Tuple.Create(Tuple.Create("", 577), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/CustomPopup.js")
, 577), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 621), Tuple.Create("\"", 670)
, Tuple.Create(Tuple.Create("", 627), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Application/CustomisedControls.js")
, 627), false)
);

WriteLiteral("></script>\r\n");

});

WriteLiteral("\r\n");

DefineSection("ko_apply", () => {

WriteLiteral("\r\nvar viewModel = new eGateRoot.UserRolesViewModel();\r\nko.applyBindingsWithValida" +
"tion(viewModel, $(\"#UserRoles\")[0], { insertMessages: false, messagesOnModified:" +
" false, grouping: { deep: true }});\r\n");

});

WriteLiteral("\r\n<style");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n\t#blanket {\r\n\t\tbackground-color: #111;\r\n\t\t-ms-opacity: 0.65;\r\n\t\topacity: 0.65;" +
"\r\n\t\t*background: none;\r\n\t\tposition: absolute;\r\n\t\tz-index: 9001;\r\n\t\ttop: 0px;\r\n\t\t" +
"left: 0px;\r\n\t\twidth: 100%;\r\n\t}\r\n\r\n\t\r\n</style>\r\n<!-- BEGIN CONTENT -->\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n\t\t<h3");

WriteLiteral(" class=\"page-title\"");

WriteLiteral("><span");

WriteLiteral(" id=\"spnTitle\"");

WriteLiteral("></span></h3>\r\n\t\t<ul");

WriteLiteral(" class=\"page-breadcrumb breadcrumb\"");

WriteLiteral("></ul>\r\n\t</div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n</div>\r\n\r\n<div");

WriteLiteral(" id=\"UserRoles\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" data-bind=\"visible: viewMode() == \'List\', template: { name: \'UserRoles-template\'" +
" }\"");

WriteLiteral("></div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\"portlet-body\"");

WriteLiteral(">\r\n\r\n\t\t<script");

WriteLiteral(" type=\"text/html\"");

WriteLiteral(" id=\"UserRoles-template\"");

WriteLiteral(">\r\n\r\n\t\t\t<div class=\"table-toolbar\">\r\n\r\n\t\t\t\t<div class=\"portlet box advbg\">\r\n\t\t\t\t\t" +
"<div class=\"portlet-title\">\r\n\t\t\t\t\t\t<div class=\"caption\">\r\n\t\t\t\t\t\t\t<i class=\"fa fa" +
"-search\" aria-hidden=\"true\"></i>Advance Search\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t<div class=\"" +
"tools\">\r\n\t\t\t\t\t\t\t<a href=\"javascript:;\" class=\"expand\"></a>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t<" +
"/div>\r\n\t\t\t\t\t<div class=\"portlet-body\" style=\"display:none;\" >\r\n\t\t\t\t\t\t<div class=" +
"\"form-wizard form-horizontal\" data-bind=\"with: UserRolesModel\">\r\n\t\t\t\t\t\t\t<div cla" +
"ss=\"form-body\">\r\n\t\t\t\t\t\t\t\t<div class=\"row\">\r\n\t\t\t\t\t\t\t\t\t<div class=\"col-md-4\">\r\n\t\t\t" +
"\t\t\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-label col-md-4" +
"\">User Name:</label>\r\n\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-6\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t<input type" +
"=\"text\" id=\"SearchUserName\" class=\"form-control\" data-bind=\"value: UserName, eve" +
"nt: { keypress: $root.validationHelper.ValidateAlphaNumeric }\" maxlength=\"50\">\r\n" +
"\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t<div class=\"col-m" +
"d-4\">\r\n\t\t\t\t\t\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-labe" +
"l col-md-4\">Name:</label>\r\n\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-6\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t<input" +
" type=\"text\" id=\"SearchFirstName\" class=\"form-control\" data-bind=\"value: Name, e" +
"vent: { keypress: $root.validationHelper.ValidateAlphabetsWithSpaces_keypressEve" +
"nt }\" maxlength=\"50\">\r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t" +
"\t\t\t\t\t\t<div class=\"col-md-4\">\r\n\t\t\t\t\t\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t<la" +
"bel class=\"control-label col-md-4\">Email Id:</label>\r\n\t\t\t\t\t\t\t\t\t\t\t<div class=\"col" +
"-md-6\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t<input type=\"text\" id=\"SearchEmailId\" class=\"form-control\" " +
"data-bind=\"value: EmailId, event: { keypress: $root.validationHelper.ValidateAlp" +
"hanumericEmail }\" maxlength=\"50\">\r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t" +
"\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t<div class=\"row\">\r\n\r\n\t\t\t\t\t\t\t\t\t<div class=\"c" +
"ol-md-4\">\r\n\t\t\t\t\t\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-" +
"label col-md-4\">Contact Number:</label>\r\n\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-6\">\r\n\t\t\t\t" +
"\t\t\t\t\t\t\t\t<input type=\"text\" id=\"SearchContactNumber\" class=\"form-control\" data-bi" +
"nd=\"value: ContactNumber\" maxlength=\"50\">\r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t</div>" +
"\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t<div class=\"col-md-4\">\r\n\t\t\t\t\t\t\t\t\t\t<div class=\"form-g" +
"roup\">\r\n\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-label col-md-4\"></label>\r\n\t\t\t\t\t\t\t\t\t\t\t<d" +
"iv class=\"col-md-6\">\r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t" +
"\t\t\t\t\t<div class=\"col-md-4\">\r\n\t\t\t\t\t\t\t\t\t\t<div class=\"form-group \">\r\n\t\t\t\t\t\t\t\t\t\t\t<la" +
"bel class=\"control-label col-md-4\"></label>\r\n\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-6\">\r\n" +
"\r\n\t\t\t\t\t\t\t\t\t\t\t\t<button type=\"submit\" class=\"btn btn-xs green\" data-bind=\"click: $" +
"root.GetUsers\">Search</button>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<button type=\"submit\" class=\"btn btn" +
"-xs blue\" data-bind=\"click: $root.ResetFilters\">Reset</button>\r\n\t\t\t\t\t\t\t\t\t\t\t</div" +
">\r\n\r\n\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t</d" +
"iv>\r\n\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\r\n\t\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n                    \r\n\t\t\t\t</di" +
"v>\r\n                    <div id=\"blanket\" style=\"display: none\"></div>\r\n        " +
"            <div id=\"popUpDiv\" style=\"display: none; margin-left:0; top:75px;\">\r" +
"\n\t\t\t\t\t\t\t<div class=\"modal-body\">\r\n\t\t\t\t\t\t\t\t<div class=\"form-horizontal\" data-bind" +
"=\"with: UserRolesGridModel\">\r\n\t\t\t\t\t\t\t\t\t<div>\r\n\t\t\t\t\t\t\t\t\t\t<div class=\"row\">&nbsp</" +
"div>\r\n\t\t\t\t\t\t\t\t\t\t<fieldset>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t<legend>User Roles</legend>\r\n\t\t\t\t\t\t\t\t\t\t" +
"\t<div class=\"row\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-12\">\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<div cla" +
"ss=\"row\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-4\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"form" +
"-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-label col-md-6\">User Name:</labe" +
"l>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-6 control-label\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<labe" +
"l class=\"displaytxt col-md-12\" data-bind=\"text: UserName\"></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t" +
"\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div clas" +
"s=\"col-md-8\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label c" +
"lass=\"control-label col-md-3\">Name:</label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-" +
"9 control-label\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"displaytxt col-md-12\" data-bin" +
"d=\"text: Name\"></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t" +
"\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"row\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t" +
"\t<div class=\"col-md-4\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t" +
"\t\t<label class=\"control-label col-md-6\">Contact No.:</label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<d" +
"iv class=\"col-md-6 control-label\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"displaytxt co" +
"l-md-12\" data-bind=\"text: ContactNumber\"></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t" +
"\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-8\">\r\n\t\t" +
"\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-lab" +
"el col-md-3\">Email Id:</label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-9 control-lab" +
"el\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"displaytxt col-md-12\" data-bind=\"text: Emai" +
"lId\"></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</di" +
"v>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"row\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div clas" +
"s=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-label col-md-2\">Roles:<spa" +
"n class=\"required\">*</span></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-9 control" +
"-label\">\r\n\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<input class=\"displaytxt col-md-12\" id=\"userPort\" " +
"data-bind=\"kendoMultiSelect: { dataTextField: \'RoleName\', dataValueField: \'RoleI" +
"d\', data: $parent.Roles, value: UserRoleArray }\" />\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<span id=" +
"\"spnrole\" class=\"validationError\" data-bind=\"validationMessage: UserRoleArray\"><" +
"/span>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\r\n\r\n" +
"\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t</fieldset>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t<div class=" +
"\"btns-group form-actions fluid\" data-bind=\"loadingWhen: $root.viewModelHelper.is" +
"Loading\">\r\n\t\t\t\t\t\t\t\t\t\t<input type=\"button\" class=\"btn green\" value=\"Save\" data-bi" +
"nd=\"click: $root.SaveRoles\" />\r\n\t\t\t\t\t\t\t\t\t\t<input type=\"button\" class=\"btn blue\" " +
"value=\"Reset\" data-bind=\"click: $root.ResetRoles\" />\r\n\t\t\t\t\t\t\t\t\t\t<input type=\"but" +
"ton\" class=\"btn red\" value=\"Cancel\" onclick=\" popup(\'popUpDiv\')\" data-bind=\"    " +
"click: $root.CancelRoles\" />\r\n\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</div>\r\n" +
"\r\n\t\t\t\t\t\t</div>\r\n\r\n\r\n\t\t\t\t<div id=\"Grid\" data-bind=\"kendoGrid: {\r\n\tdata: UsersList" +
",\r\n\tgroupable: false,\r\n\tsortable: true,\r\n\tscrollable: true,\r\n\tfilterable: {\r\n\t\te" +
"xtra: false, operators: {\r\n\t\t\tstring: {\r\n\t\t\t\tstartswith: \'Starts with\',\r\n\t\t\t\teq:" +
" \'Is equal to\',\r\n\t\t\t\tneq: \'Is not equal to\',\r\n\t\t\t\tcontains: \'Contains\',\r\n\t\t\t\tdoe" +
"snotcontain: \'Does not Contain\'\r\n\t\t\t},\r\n\t\t\tnumber: { eq: \'Is equal to\' }\r\n\t\t}\r\n\t" +
"},\r\n\trowTemplate: \'rowTmpl\',\r\n\tuseKOTemplates: true,\r\n\tcolumns: [{ title: \'Actio" +
"ns\', width: 110, filterable: false },\r\n        { field: \'UserNameSort\', title: \'" +
"User Name\', width: 70, filterable: true },\r\n        { field: \'NameSort\', title: " +
"\'Name\', width: 70, filterable: true },\r\n  { field: \'RoleNameSort\', title: \'Roles" +
"\', width: 70, filterable: true },\r\n        { field: \'ContactNumberSort\', title: " +
"\'Contact Number\', width: 140, filterable: true },\r\n  { field: \'EmailIdSort\', tit" +
"le: \'Email\', width: 70, filterable: true },\r\n\r\n\t]\r\n}\">\r\n\t\t\t\t</div>\r\n\t\t\t\t<script " +
"id=\"rowTmpl\" type=\"text/html\">\r\n\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t<div class=\"nowrap" +
"\">\r\n");

            
            #line 254 "..\..\Views\UserRole\UserRoles.cshtml"
								
            
            #line default
            #line hidden
            
            #line 254 "..\..\Views\UserRole\UserRoles.cshtml"
                                 if (Model.HasPrivilege("eGateAssignUserRole")) //TODO: Need to implment Entity Functions as Enums
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn green\"");

WriteLiteral(" value=\"Assign Roles\"");

WriteLiteral(" data-bind=\"click: $root.AddRoles\"");

WriteLiteral(" />\r\n");

            
            #line 257 "..\..\Views\UserRole\UserRoles.cshtml"
								}

            
            #line default
            #line hidden
WriteLiteral(@"							</div>
						</td>
						<td>
							<div class=""nowrap""><span data-bind=""text: UserName""></span></div>
						</td>
						<td>
							<div class=""nowrap""><span data-bind=""text: Name""></span></div>
						</td>

						<td>
							<div class=""nowrap""><span data-bind=""text: UserRoleNameArray""></span></div>
						</td>
						<td>
							<div class=""nowrap""><span data-bind=""text: ContactNumber""></span></div>
						</td>
						<td>
							<div class=""nowrap"" style=""word-wrap:break-word; text-align:left;""><span data-bind=""text: EmailId""></span></div>
						</td>




					</tr>
				</script>


			</div>







		</script>

	</div>

</div>

</div>
");

        }
    }
}
#pragma warning restore 1591
