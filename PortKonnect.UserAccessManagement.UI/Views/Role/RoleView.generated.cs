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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Role/RoleView.cshtml")]
    public partial class _Views_Role_RoleView_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Role_RoleView_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Views\Role\RoleView.cshtml"
  
    ViewBag.Title = "Role";
    Layout = "~/Views/Shared/_eGateLayout.cshtml";
    

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 126), Tuple.Create("\"", 174)
, Tuple.Create(Tuple.Create("", 132), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Lib/kendo.all-v2016.2.607.min.js")
, 132), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 194), Tuple.Create("\"", 243)
, Tuple.Create(Tuple.Create("", 200), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Application/CustomisedControls.js")
, 200), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 263), Tuple.Create("\"", 313)
, Tuple.Create(Tuple.Create("", 269), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Application/UAM/Model/RoleModel.js")
, 269), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 333), Tuple.Create("\"", 395)
, Tuple.Create(Tuple.Create("", 339), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Application/UAM/ViewModel/RoleViewViewModel.js")
, 339), false)
);

WriteLiteral("></script>\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 413), Tuple.Create("\"", 466)
, Tuple.Create(Tuple.Create("", 420), Tuple.Create<System.Object, System.Int32>(Href("~/Content/Styles/kendo.common-material.min.css")
, 420), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 494), Tuple.Create("\"", 540)
, Tuple.Create(Tuple.Create("", 501), Tuple.Create<System.Object, System.Int32>(Href("~/Content/Styles/kendo.material.min.css")
, 501), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 568), Tuple.Create("\"", 620)
, Tuple.Create(Tuple.Create("", 575), Tuple.Create<System.Object, System.Int32>(Href("~/Content/Styles/kendo.default.mobile.min.css")
, 575), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n");

});

WriteLiteral("\r\n");

DefineSection("ko_apply", () => {

WriteLiteral("\r\n    var viewModel = new eGateRoot.RoleViewViewModel(\"");

            
            #line 19 "..\..\Views\Role\RoleView.cshtml"
                                                Write(ViewBag.roleId);

            
            #line default
            #line hidden
WriteLiteral("\");  \r\n  ko.applyBindingsWithValidation(viewModel, $(\"#Role\")[0], { insertMessage" +
"s: false, messagesOnModified: false, grouping: { deep: true }});\r\n");

});

WriteLiteral(@"
<style>
	.demo-section .k-checkbox:checked + .k-checkbox-label:before {
		background-color: #032F52 !important;
		border-color: #032F52 !important;
		color: #fff !important;
	}

	.demo-section .k-state-hover:hover {
		color: #444;
		background-color: #F1F6FA !important;
		border-color: #F1F6FA !important;
		font-weight: bold;
	}

	.demo-section .k-state-focused {
		color: #444;
		background-color: #F1F6FA !important;
		border-color: #F1F6FA !important;
		font-weight: bold;
	}

	.demo-section .k-checkbox:indeterminate + .k-checkbox-label:before {
		border-color: #ccc !important;
	}

	.demo-section .k-checkbox:indeterminate + .k-checkbox-label:before {
		border-width: 3px !important;
	}

	.demo-section .k-checkbox:indeterminate + .k-checkbox-label:after {
		background-color: #3687C8 !important;
		background-image: none;
		border-color: #3687C8 !important;
		border-radius: 0;
	}

	.demo-section .k-state-selected {
		color: #f00 !important;
		font-weight: bold;
	}

	.demo-section input.k-checkbox + label {
		margin-top: -9px;
	}

	.k-button {
		text-transform: none !important;
	}
</style>
<div");

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

WriteLiteral(" id=\"Role\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" data-bind=\"visible: viewMode() == \'Form\', template: { name: \'Role-template\' }\"");

WriteLiteral("></div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral("></div>\r\n\r\n<div");

WriteLiteral(" class=\"portlet-body\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" class=\"table-toolbar\"");

WriteLiteral(">\r\n\t\t<script");

WriteLiteral(" type=\"text/html\"");

WriteLiteral(" id=\"Role-template\"");

WriteLiteral(@">
			<div class=""portlet-body"">
				<div class=""table-toolbar"">
					<div class=""portlet portlet-body form"" data-bind=""loadingWhen: $root.viewModelHelper.isLoading"">
						<div class=""form-wizard"">
							<div class=""form-body form-horizontal"" data-bind=""with: RoleModel"">
								");

WriteLiteral("\r\n\t\t\t\t\t\t\t\t<div class=\"tab-pane active\" id=\"tab1\">\r\n\t\t\t\t\t\t\t\t\t<div class=\"form-grou" +
"p\">\r\n\t\t\t\t\t\t\t\t\t\t<div class=\"row\">\r\n\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-11\"></div>\r\n\t\t\t\t" +
"\t\t\t\t\t\t\t<div class=\"col-md-1\" style=\"display:none;\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t<input type=\"bu" +
"tton\" value=\"Edit\" class=\"btn blue\" data-bind=\"click: $root.EditRole\" />\r\n\t\t\t\t\t\t" +
"\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t<fieldset>\r\n\t\t\t\t\t\t\t\t\t\t\t<legend>Role</le" +
"gend>\r\n\t\t\t\t\t\t\t\t\t\t\t<div class=\"row\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-6\">\r\n\t\t\t\t\t\t\t" +
"\t\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"control-label col-md" +
"-6\">Role Code :</label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-md-5 control-label\">\r\n\t\t\t" +
"\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"displaytxt col-md-12\" data-bind=\"text: RoleCode\"></lab" +
"el>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t" +
"<div class=\"col-md-6\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<la" +
"bel class=\"control-label col-md-4\">Role Name:</label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=" +
"\"col-md-4 control-label\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"displaytxt col-md-12\" da" +
"ta-bind=\"text: RoleName\"></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t" +
"\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t<div class=\"row\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t<" +
"div class=\"col-md-12\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<la" +
"bel class=\"control-label col-md-3\">Partner Types :</label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div c" +
"lass=\"col-md-8 control-label\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<label class=\"displaytxt col-md-1" +
"2\" data-bind=\"text: PartnerTypeNameArray\"></label>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t" +
"\t\t\t\t\t\t\t\t");

WriteLiteral(@"
													</div>
												</div>
											</div>

											<div>
												<fieldset>
													<legend>Modules & Sub Modules</legend>
													<div class=""row demo-section "">
														<div class=""col-md-12"">
															<div class=""form-group"">
																<label class=""control-label col-md-1""></label>
																<div class=""col-md-9"">
																	<div id=""Role1"" style=""overflow: hidden"">
																		<div class=""demo-section "" style=""overflow: hidden"">
																			<div>
																				<div id=""treeview"" style=""overflow: hidden""></div>
																			</div>
																		</div>
																	</div>
																</div>

															</div>
														</div>
													</div>
												</fieldset>
											</div>
										</fieldset>
										<div class=""btns-group form-actions fluid"">
											<button type=""submit"" class=""btn default button-previous"" data-bind=""click: $root.ExitScreen""><i class=""m-icon-swapleft""></i>Back</button>

										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</script>
	</div>
</div>

");

        }
    }
}
#pragma warning restore 1591