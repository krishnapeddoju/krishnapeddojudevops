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
    
    #line 1 "..\..\Views\Account\Login.cshtml"
    using PortKonnect.UserAccessManagement.UI;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Account/Login.cshtml")]
    public partial class _Views_Account_Login_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Account_Login_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Account\Login.cshtml"
  
    Layout = "~/Views/Shared/_LoginLayout.cshtml";    

            
            #line default
            #line hidden
WriteLiteral("\r\n \r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n\r\n   <script");

WriteAttribute("src", Tuple.Create(" src=\"", 144), Tuple.Create("\"", 194)
, Tuple.Create(Tuple.Create("", 150), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Application/UAM/Model/UserModel.js")
, 150), false)
);

WriteLiteral("></script>\r\n   <script");

WriteAttribute("src", Tuple.Create(" src=\"", 217), Tuple.Create("\"", 275)
, Tuple.Create(Tuple.Create("", 223), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Application/UAM/ViewModel/UserViewModel.js")
, 223), false)
);

WriteLiteral("></script> \r\n\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 302), Tuple.Create("\"", 351)
, Tuple.Create(Tuple.Create("", 308), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Application/CustomisedControls.js")
, 308), false)
);

WriteLiteral("></script>      \r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 381), Tuple.Create("\"", 429)
, Tuple.Create(Tuple.Create("", 387), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Application/Model/ModuleModel.js")
, 387), false)
);

WriteLiteral("></script>  \r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 455), Tuple.Create("\"", 511)
, Tuple.Create(Tuple.Create("", 461), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Application/ViewModel/ModuleViewModel.js")
, 461), false)
);

WriteLiteral("></script>    \r\n      \r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 547), Tuple.Create("\"", 602)
, Tuple.Create(Tuple.Create("", 553), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Application/Model/NotificationsModel.js")
, 553), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 626), Tuple.Create("\"", 689)
, Tuple.Create(Tuple.Create("", 632), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/Application/ViewModel/NotificationsViewModel.js")
, 632), false)
);

WriteLiteral("></script>  \r\n\r\n\r\n\r\n");

});

WriteLiteral("\r\n");

DefineSection("ko_apply", () => {

WriteLiteral(" \r\n   var viewModel = new eGateRoot.UserViewModel(application);\r\n  ko.applyBindin" +
"gsWithValidation(viewModel, $(\"#accountlogin\")[0], { insertMessages: false, mess" +
"agesOnModified: false, grouping: { deep: true }});\r\n");

});

WriteLiteral("   \r\n<script> var ParentUrl = \'\' </script>\r\n\r\n<body>\r\n    <div");

WriteLiteral(" style=\"background: #FFF; display: block\"");

WriteLiteral("></div>\r\n\r\n    <header");

WriteLiteral(" class=\"header navbar navbar-inverse navbar-fixed-top\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" style=\"padding: 0px\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"header-inner\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" class=\"name\"");

WriteLiteral(" style=\"padding-left: 0px; margin-top: -5px;\"");

WriteLiteral("><img");

WriteAttribute("src", Tuple.Create(" src=\"", 1293), Tuple.Create("\"", 1336)
, Tuple.Create(Tuple.Create("", 1299), Tuple.Create<System.Object, System.Int32>(Href("~/Content/Images/eGate-HeaderLogo.png")
, 1299), false)
);

WriteLiteral(" style=\"vertical-align: bottom;\"");

WriteLiteral("></span>\r\n                <ul");

WriteLiteral(" class=\"nav navbar-nav pull-right\"");

WriteLiteral(">\r\n\r\n                    ");

WriteLiteral("\r\n                    <li");

WriteLiteral(" class=\"dropdown\"");

WriteLiteral(" id=\"profileDropDown\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" data-hover=\"dropdown\"");

WriteLiteral(" data-close-others=\"true\"");

WriteLiteral(" onclick=\"onclickDropDown()\"");

WriteLiteral(">\r\n                            <i");

WriteLiteral(" class=\"fa fa-compass\"");

WriteLiteral(" ></i>About Us</a>\r\n                        <ul");

WriteLiteral(" class=\"dropdown-menu extended inbox\"");

WriteLiteral(">\r\n                            <li>\r\n                                <p><b>About " +
"KPCT</b></p>\r\n                            </li>\r\n                            <li" +
">\r\n                                <ul");

WriteLiteral(" class=\"dropdown-menu-list scroller\"");

WriteLiteral(" style=\"height: 250px; padding: 10px; \"");

WriteLiteral(">\r\n                                    <li><b>Krishnapatnam Port Container Termin" +
"al</b></li>\r\n                                    <li>Considering India’s growing" +
" maritime trade in the world market with unprecedented growth in containerized t" +
"rade and bulk commodities, Krishnapatnam Port is building a world-class containe" +
"r terminal with outstanding services, facilities and state-of-art infrastructure" +
". It will connect demand with supply, industry with port, rail and road with por" +
"t and capital with business making Indian exporters and importers globally compe" +
"titive.</li>\r\n<li>&nbsp;</li>\r\n<li>One of India’s largest and fastest growing se" +
"aports, Krishnapatnam Port has emerged as a world-class port with outstanding se" +
"rvices and facilities. It is fast becoming a port of choice for all internationa" +
"l cargo originating from and destined to the Southern and Central India.</li>\r\n<" +
"li>&nbsp;</li>\r\n<li>Krishnapatnam Port Company has won the mandate from the Govt" +
". of Andhra Pradesh to develop the existing minor port into a modern, deep water" +
" & high productivity port, on BOST basis for 50 years. The port is being built i" +
"n three phases and currently the second phase of development is underway. Port h" +
"as numerous strengths like its area, location, weather and new generation world " +
"class port facilities; it will soon be poised to become one of the biggest ports" +
" in the world and the Largest port in India.</li>\r\n  <li>&nbsp;</li>            " +
"                      \r\n\r\n                                </ul>\r\n               " +
"             </li>\r\n                            <li>&nbsp;</li>\r\n               " +
"         </ul>\r\n                    </li>\r\n                    <li");

WriteLiteral(" class=\"dropdown\"");

WriteLiteral(" id=\"profileDropDown\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" data-hover=\"dropdown\"");

WriteLiteral(" data-close-others=\"true\"");

WriteLiteral(" onclick=\"onclickDropDown()\"");

WriteLiteral(">\r\n                            <i");

WriteLiteral(" class=\"fa fa-phone\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i>Contact Us &nbsp; &nbsp;</a>\r\n                        <ul");

WriteLiteral(" class=\"dropdown-menu extended inbox\"");

WriteLiteral(" style=\"width:300px !important;\"");

WriteLiteral(">\r\n                            <li>\r\n                                <p");

WriteLiteral(" style=\"background-color:#032f52;\"");

WriteLiteral("><b>KPCT Customer Service</b></p>\r\n                            </li>\r\n           " +
"                 <li>\r\n                                <ul");

WriteLiteral(" class=\"dropdown-menu-list scroller\"");

WriteLiteral(" style=\"height: 160px; padding: 10px; \"");

WriteLiteral(">\r\n                                    <li");

WriteLiteral(" style=\"color:#2FA1DB;\"");

WriteLiteral("><b>Krishnapatnam Port Container Terminal</b></li>\r\n                             " +
"       <li></li>\r\n<span");

WriteLiteral(" style=\"font-size:11px;\"");

WriteLiteral("><li>P.O Bag No.1, Muthukur Mandal,</li>\r\n<li>SPSR Nellore District,</li>\r\n<li>An" +
"dhra Pradesh – 524 344, INDIA</li></span>\r\n<li><b>Customer Service – 24 x 7:</b>" +
"</li>\r\n<span");

WriteLiteral(" style=\"font-size:11px;\"");

WriteLiteral("><li>Tel: +91 80086 12345, Fax: +91-0861-237 7046</li>\r\n<li>E Mail: <a");

WriteLiteral(" href=\"mailto:cs.kpct@krishnapatnam.com\"");

WriteLiteral("  >cs.kpct@krishnapatnamport.com</a></li>\r\n\r\n\r\n<li>URL: <a");

WriteLiteral(" href=\"http://www.krishnapatnam.com\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(@" >www.krishnapatnamport.com</a></li>
</span>
                                </ul>
                            </li>
                            
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </header>
    <script");

WriteLiteral(" id=\"customMessageTemplate\"");

WriteLiteral(" type=\"text/html\"");

WriteLiteral(">\r\n        <span class=\"validationError\" data-bind=\'validationMessage: field\'></s" +
"pan>\r\n    </script>\r\n   ");

WriteLiteral("\r\n\r\n    <section");

WriteLiteral(" class=\"login\"");

WriteLiteral(" id=\"accountlogin\"");

WriteLiteral(">\r\n        <article");

WriteLiteral(" class=\"content\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"form-wizard\"");

WriteLiteral(" data-bind=\'validationOptions: { messageTemplate: \"customMessageTemplate\" }\'");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"login-form\"");

WriteLiteral(">\r\n                    <form");

WriteLiteral(" data-bind=\"with: accountModel\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" style=\"margin-top: 25px; margin-bottom: 25px;\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n                                <img");

WriteAttribute("src", Tuple.Create(" src=\"", 7186), Tuple.Create("\"", 7223)
, Tuple.Create(Tuple.Create("", 7192), Tuple.Create<System.Object, System.Int32>(Href("~/Content/Images/eGate-Logo.png")
, 7192), false)
);

WriteLiteral(">\r\n                            </div>\r\n                        </div>\r\n          " +
"              ");

WriteLiteral("\r\n                        <p>Please enter username &amp; password to login</p>\r\n " +
"                       <div");

WriteLiteral(" class=\"alert alert-danger display-hide\"");

WriteLiteral(">\r\n                            <button");

WriteLiteral(" class=\"close\"");

WriteLiteral(" data-close=\"alert\"");

WriteLiteral("></button>\r\n                            <span>Enter any username and password.\r\n " +
"                           </span>\r\n                        </div>\r\n\r\n          " +
"              <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(" id=\"MyForm\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"control-label visible-ie8 visible-ie9\"");

WriteLiteral(">Username</label><span");

WriteLiteral(" id=\"cusername\"");

WriteLiteral(" hidden=\"hidden\"");

WriteLiteral(">");

            
            #line 141 "..\..\Views\Account\Login.cshtml"
                                                                                                                                 Write(ViewBag.UserName);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                            <div");

WriteLiteral(" class=\"input-icon\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"fa fa-user\"");

WriteLiteral("></i>\r\n                                <input");

WriteLiteral(" id=\"txtusername\"");

WriteLiteral(" class=\"form-control placeholder-no-fix\"");

WriteLiteral(" style=\"height: 30px;\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" autocomplete=\"off\"");

WriteLiteral(" placeholder=\"Username\"");

WriteLiteral(" name=\"username\"");

WriteLiteral(" data-bind=\"value: userName\"");

WriteLiteral("/>\r\n                            </div>\r\n                        </div>\r\n         " +
"               <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"control-label visible-ie8 visible-ie9\"");

WriteLiteral(">Password</label><span");

WriteLiteral(" id=\"cpwd\"");

WriteLiteral(" hidden=\"hidden\"");

WriteLiteral(">");

            
            #line 148 "..\..\Views\Account\Login.cshtml"
                                                                                                                            Write(ViewBag.Password);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                            <div");

WriteLiteral(" class=\"input-icon\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"fa fa-lock\"");

WriteLiteral("></i>\r\n                                <input");

WriteLiteral(" id=\"txtpwd\"");

WriteLiteral(" class=\"form-control placeholder-no-fix\"");

WriteLiteral(" type=\"password\"");

WriteLiteral(" autocomplete=\"off\"");

WriteLiteral(" placeholder=\"Password\"");

WriteLiteral(" name=\"password\"");

WriteLiteral(" data-bind=\"value: password, enterkey: checkLogindet\"");

WriteLiteral("/>\r\n                            </div>\r\n                        </div>\r\n         " +
"               <div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n                            <br>\r\n                        </div>\r\n            " +
"            <div");

WriteLiteral(" class=\"form-actions rem\"");

WriteLiteral(">\r\n                           <label");

WriteLiteral(" class=\"checkbox\"");

WriteLiteral(">\r\n                                <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" id=\"chkRemember\"");

WriteLiteral(" data-bind=\"checked: RememberMe\"");

WriteLiteral("/>\r\n                                Remember me\r\n                            </la" +
"bel>\r\n\r\n                            <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn green pull-right\"");

WriteLiteral(" id=\"btnLogin\"");

WriteLiteral(" data-bind=\"click: checkLogindet\"");

WriteLiteral(" style=\"margin-right: 0;\"");

WriteLiteral(" >\r\n                                Login <i");

WriteLiteral(" class=\"m-icon-swapright m-icon-white\"");

WriteLiteral("></i>\r\n                            </button>\r\n                            <span");

WriteLiteral(" id=\"spanReturnUrl\"");

WriteLiteral(" hidden=\"hidden\"");

WriteLiteral(">");

            
            #line 166 "..\..\Views\Account\Login.cshtml"
                                                                Write(ViewBag.ReturnUrl);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                        </div>\r\n                    </form>\r\n           " +
"         <div");

WriteLiteral(" id=\"loader\"");

WriteLiteral(" class=\"loading-loader\"");

WriteLiteral(" style=\"position: relative; display: none; margin-left: 90px; margin-top: -80px;\"" +
"");

WriteLiteral("></div>\r\n                    <div");

WriteLiteral(" class=\"forget-password\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" href=\"javascript:;\"");

WriteLiteral(" id=\"forget-password\"");

WriteLiteral("><span");

WriteLiteral(" class=\"fa fa-arrow-circle-right\"");

WriteLiteral(">&nbsp; </span>Forgot password?</a>\r\n                    </div>\r\n                " +
"    <div");

WriteLiteral(" class=\"login-pen-reg\"");

WriteLiteral(" data-bind=\"visible:$root.LinkVisible\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"login-heading\"");

WriteLiteral(" data-bind=\"visible:$root.LinkVisible\"");

WriteLiteral(">Partner Registation</div>\r\n                    <ul>\r\n                        <li" +
"");

WriteLiteral("  data-bind=\"visible:$root.LinkVisible\"");

WriteLiteral("><a");

WriteLiteral(" href=\"/PartnerRegistration\"");

WriteLiteral("><span");

WriteLiteral(" class=\"fa fa-arrow-circle-right\"");

WriteLiteral(">&nbsp; </span>New Registration  ");

WriteLiteral("</a></li>\r\n                        <li");

WriteLiteral("  data-bind=\"visible:$root.LinkVisible\"");

WriteLiteral("><a");

WriteLiteral(" href=\"/PartnerRegistrationEdit\"");

WriteLiteral("><span");

WriteLiteral(" class=\"fa fa-arrow-circle-right\"");

WriteLiteral(">&nbsp; </span>Update Registration  ");

WriteLiteral("</a></li>\r\n                    </ul>\r\n                    </div>\r\n               " +
"     \r\n\r\n                    <div");

WriteLiteral(" class=\"row newsCss\"");

WriteLiteral(" style=\"width: 100%; text-align: center;\"");

WriteLiteral("><a");

WriteLiteral(" href=\"http://www.krishnapatnam.com/container-terminal.html\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">\r\n                        <img");

WriteAttribute("src", Tuple.Create(" src=\"", 11210), Tuple.Create("\"", 11259)
, Tuple.Create(Tuple.Create("", 11216), Tuple.Create<System.Object, System.Int32>(Href("~/Content/Images/kpct-print-logo-medium.png")
, 11216), false)
);

WriteLiteral("></a></div>\r\n                    <div");

WriteLiteral(" style=\"font-size: 11px; text-align: center;\"");

WriteLiteral("><a");

WriteLiteral(" href=\"http://www.krishnapatnam.com/container-terminal.html\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(" style=\"color: #fff; text-decoration: none; display: none;\"");

WriteLiteral(">India\'s Largest Container Terminal on the Horizon</a></div>\r\n                   " +
" <div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n                        <br>\r\n                    </div>\r\n\r\n\r\n                " +
"    <div");

WriteLiteral(" id=\"newsData\"");

WriteLiteral(" class=\"row newsCss\"");

WriteLiteral("></div>\r\n                    <div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral(">\r\n                        <br>\r\n                    </div>\r\n                </di" +
"v>\r\n\r\n                <form");

WriteLiteral(" class=\"forget-form\"");

WriteAttribute("action", Tuple.Create(" action=\"", 11884), Tuple.Create("\"", 11908)
, Tuple.Create(Tuple.Create("", 11893), Tuple.Create<System.Object, System.Int32>(Href("~/Account/Login")
, 11893), false)
);

WriteLiteral(" method=\"post\"");

WriteLiteral(" data-bind=\"with: forgotPasswordModel\"");

WriteLiteral(">\r\n                    <h3>Forgot password ?</h3>\r\n                    <p>\r\n     " +
"                   Enter your username below to reset your password.\r\n          " +
"          </p>\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <div>\r\n                            <input");

WriteLiteral(" id=\"txtusername1\"");

WriteLiteral(" class=\"form-control placeholder-no-fix\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" autocomplete=\"off\"");

WriteLiteral(" placeholder=\"Username\"");

WriteLiteral(" name=\"username\"");

WriteLiteral(" data-bind=\"value: userName\"");

WriteLiteral(" />\r\n                        </div>\r\n                    </div>\r\n                " +
"    <div");

WriteLiteral(" class=\"form-actions\"");

WriteLiteral(">\r\n                        <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"back-btn\"");

WriteLiteral(" class=\"btn\"");

WriteLiteral(" data-bind=\"click: Back\"");

WriteLiteral(">\r\n                            <i");

WriteLiteral(" class=\"m-icon-swapleft\"");

WriteLiteral("></i> Back\r\n                        </button>\r\n                        <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" id=\"btnFgtPwd\"");

WriteLiteral(" class=\"btn green pull-right\"");

WriteLiteral(" data-bind=\"click: ResetUserPwd\"");

WriteLiteral(">\r\n                            Submit <i");

WriteLiteral(" class=\"m-icon-swapright m-icon-white\"");

WriteLiteral("></i>\r\n                        </button>\r\n                    </div>\r\n           " +
"     </form>\r\n\r\n            </div>\r\n        </article>\r\n    </section>\r\n    <scr" +
"ipt>\r\n    \teGateRoot.rootPath = \'");

            
            #line 220 "..\..\Views\Account\Login.cshtml"
                         Write(Url.Content("~"));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n    \tvar application = {viewbag : ");

            
            #line 221 "..\..\Views\Account\Login.cshtml"
                                Write(Helpers.ToJson(Html, ViewBag));

            
            #line default
            #line hidden
WriteLiteral(@"};

    	$('.register-form input').keypress(function (e) {
    		if (e.which == 13) {
    			if ($('.register-form').validate().form()) {
    				$('.register-form').submit();
    			}
    			return false;
    		}
    	});

    	$('.forget-form input').keypress(function (e) {
    		if (e.which == 13) {
    			if ($('.forget-form').validate().form()) {
    				$('.forget-form').submit();
    			}
    			return false;
    		}
    	});

    	jQuery('#forget-password').click(function () {
    		jQuery('.login-form').hide();
    		jQuery('.forget-form').show();
    	});

    	jQuery('#back-btn').click(function () {
    		jQuery('.login-form').show();
    		jQuery('.forget-form').hide();
    	});


    	jQuery(document).ready(function () { 
    		Login.init();
    	});

    	
      


    </script>
    


</body>
</html>

");

        }
    }
}
#pragma warning restore 1591