using System.Web.Optimization;
using PortKonnect.UserAccessManagement.WebApp;

namespace PortKonnect.eGate.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region globalMandatoryCss

            Bundle globalMandatoryCss = new Bundle("~/globalMandatoryCss", new IBundleTransform[] { new CssMinify() });

            globalMandatoryCss.Include("~/Content/Styles/font-awesome.min.css",
                "~/Content/Styles/bootstrap.min.css",
                "~/Content/Styles/uniform.default.css",
                "~/Content/Styles/datepicker.css",
                "~/Content/Styles/style-metronic.css",
                "~/Content/Styles/style.css",
                "~/Content/Styles/style-responsive.css",
                "~/Content/Styles/grid-style.css",
                "~/Content/Styles/plugins.css",
                "~/Content/Styles/custom.css",
                "~/Content/Styles/kendo.common.min.css",
                "~/Content/Styles/kendo.default.min.css",
                "~/Content/Styles/default.css",
                "~/Content/Styles/toastr.css",
                "~/Content/Styles/jquery-ui.css",
                "~/Content/Styles/jquery.ui.chatbox.css",
                "~/Content/Styles/jquery.confirm.css",
                "~/Content/Styles/jquery.fileupload-ui.css",
                "~/Content/Styles/byrei-dyndiv_0.5.css");

            bundles.Add(globalMandatoryCss);

            #endregion globalMandatoryCss

            #region loginJs
            Bundle loginJs = new Bundle("~/loginJs", new IBundleTransform[] { new JsMinify() });

            loginJs.Include("~/Scripts/Lib/jquery-2.0.3.min.js",
                "~/Scripts/Lib/jquery-migrate-1.4.1.min.js",
                "~/Scripts/Lib/bootstrap.min.js",
                "~/Scripts/Lib/twitter-bootstrap-hover-dropdown.min.js",
                "~/Scripts/Lib/jquery.slimscroll.min.js",
                "~/Scripts/Lib/jquery.blockui.min.js",
                "~/Scripts/Lib/jquery.cokie.min.js",
                "~/Scripts/Lib/jquery.uniform.min.js",
                "~/Scripts/Lib/jquery.validate.min.js",
                "~/Scripts/Lib/jquery.backstretch.min.js",
                "~/Scripts/Lib/jquery.bootstrap.wizard.min.js",
                "~/Scripts/Lib/spinner.min.js",
                "~/Scripts/Lib/bootstrap-datepicker.js",
                "~/Scripts/Lib/jquery.dataTables.js",
                "~/Scripts/Lib/DT_bootstrap.js",
                "~/Scripts/Lib/bootstrap-maxlength.min.js",
                "~/Scripts/Lib/bootstrap.touchspin.js",
                "~/Scripts/Lib/select2.min.js",
                "~/Scripts/Lib/app.js",
                "~/Scripts/Lib/form-validation.js",
                "~/Scripts/Lib/form-wizard.js",
                "~/Scripts/Lib/form-components.js",
                "~/Scripts/Lib/login-soft.js",
                "~/Scripts/Lib/newsTicker.js",
                "~/Scripts/Lib/toastr.js");

            bundles.Add(loginJs);
            #endregion loginJs

            #region loginCss
            Bundle loginCss = new Bundle("~/loginCss", new IBundleTransform[] { new CssMinify() });

            loginCss.Include("~/Content/Styles/font-awesome.min.css",
                "~/Content/Styles/bootstrap.min.css",
                "~/Content/Styles/uniform.default.css",
                "~/Content/Styles/select2_metro.css",
                "~/Content/Styles/style-metronic.css",
                "~/Content/Styles/style.css",
                "~/Content/Styles/style-responsive.css",
                "~/Content/Styles/plugins.css",
                "~/Content/Styles/default.css",
                "~/Content/Styles/login-soft.css",
                "~/Content/Styles/custom.css",
                "~/Content/Styles/default.css",
                "~/Content/Styles/toastr.css");

            bundles.Add(loginCss);
            #endregion loginCss

            #region eGateLayoutCss
            Bundle eGateLayoutCss = new Bundle("~/eGateLayoutCss", new IBundleTransform[] { new CssMinify() });
            eGateLayoutCss.Include("~/Content/Styles/jquery.ui.chatbox.css");
            bundles.Add(eGateLayoutCss);
            #endregion eGateLayoutCss


            #region eGateLayoutForPwdCss
            Bundle eGateLayoutForPwdCss = new Bundle("~/eGateLayoutForPwdCss", new IBundleTransform[] { new CssMinify() });

            eGateLayoutForPwdCss.Include("~/Content/Styles/bootstrap.min.css",
            "~/Content/Styles/kendo.common.min.css",
            "~/Content/Styles/kendo.default.min.css",
            "~/Content/Styles/font-awesome.min.css",
            "~/Content/Styles/datepicker.css",
            "~/Content/Styles/uniform.default.css",
            "~/Content/Styles/style-metronic.css",
            "~/Content/Styles/style.css",
            "~/Content/Styles/style-responsive.css",
            "~/Content/Styles/grid-style.css",
            "~/Content/Styles/plugins.css",
            "~/Content/Styles/custom.css",
            "~/Content/Styles/plugins.css",
            "~/Content/Styles/default.css",
            "~/Content/Styles/toastr.css",
            "~/Content/Styles/jquery-ui.css",
            "~/Content/Styles/jquery.ui.chatbox.css",
            "~/Content/Styles/jquery.confirm.css",
            "~/Content/Styles/jquery.fileupload-ui.css",
            "~/Content/Styles/byrei-dyndiv_0.5.css");
            bundles.Add(eGateLayoutForPwdCss);
            #endregion eGateLayoutForPwdCss

            #region CorePluginsJs
            Bundle corePluginsJs = new Bundle("~/corePluginsJs", new IBundleTransform[] { new JsMinify() });

            corePluginsJs.Include("~/Scripts/Lib/jquery-2.0.3.min.js",
                "~/Scripts/Lib/jquery-ui.js",
                "~/Scripts/Lib/jquery-migrate-1.4.1.min.js",
                "~/Scripts/Lib/bootstrap.min.js",
                "~/Scripts/Lib/jquery.slimscroll.min.js",
                "~/Scripts/Lib/jquery.cokie.min.js",
                "~/Scripts/Lib/jquery.validate.min.js",
                "~/Scripts/Lib/jquery.bootstrap.wizard.min.js",
                "~/Scripts/Lib/spinner.min.js",
                "~/Scripts/Lib/bootstrap-datepicker.js",
                "~/Scripts/Lib/jquery.dataTables.js",
                "~/Scripts/Lib/DT_bootstrap.js",
                "~/Scripts/Lib/bootstrap-maxlength.min.js",
                "~/Scripts/Lib/bootstrap.touchspin.js",
                "~/Scripts/Lib/select2.min.js",
                "~/Scripts/Lib/app.js",
                "~/Scripts/Lib/form-validation.js",
                "~/Scripts/Lib/form-wizard.js",
                "~/Scripts/Lib/form-components.js",
                "~/Scripts/Lib/grid-script.js",
                //"~/Scripts/Lib/newsTicker.js",
                "~/Scripts/Lib/kendo.web.min.js",
                "~/Scripts/Lib/kendo.all.min.js",
                "~/Scripts/Lib/kendo.sortable.min.js",
                "~/Scripts/Lib/toastr.js",
                //"~/Scripts/Lib/jquery.confirm.js",
                "~/Scripts/Lib/moment.js",
                "~/Scripts/Lib/moment-range.min.js",
                "~/Scripts/Lib/moment-range.js",
                "~/Scripts/Lib/moment-range.bare.min.js",
                "~/Scripts/Lib/moment-range.bare.js"

                );

            bundles.Add(corePluginsJs);
            #endregion CorePluginsJs

            #region knockoutJs
            Bundle knockout = new Bundle("~/knockout", new IBundleTransform[] { new JsMinify() });
            knockout.Include(
                "~/Scripts/Lib/knockout-3.0.0.debug.js",
                "~/Scripts/Lib/knockout-sortable.min.js"
                , "~/Scripts/Lib/knockout.validation.js"
                , "~/Scripts/Lib/knockout.mapping-latest.js"
                , "~/Scripts/Lib/knockout-kendo.min.js");

            bundles.Add(knockout);
            #endregion knockoutJs


            #region eGateLayoutJs
            Bundle eGateLayoutJs = new Bundle("~/eGateLayoutJs", new IBundleTransform[] { new JsMinify() });


            //TODO: Need to add eGateRoot.js in eGateLayoutJs for debugging purpose it is removed and remove the eGateRoot.js explicit add in _eGateLayout.cshtml to be removed
            eGateLayoutJs.Include(
                    "~/Scripts/Application/CustomisedControls.js",
                    "~/Scripts/Application/ViewModel/ExportRailForm/ExportRailFormConstant.js"

                    );

            bundles.Add(eGateLayoutJs);
            #endregion eGateLayoutJs


            #region eGateLayoutAllJs
            var eGateLayoutAllJs = new ScriptBundle("~/eGateLayoutAllJs").Include("~/Scripts/Lib/jquery-2.0.3.min.js",
                "~/Scripts/Lib/jquery-ui.js",
                "~/Scripts/Lib/jquery-migrate-1.4.1.min.js",
                "~/Scripts/Lib/bootstrap.min.js",
                "~/Scripts/Lib/jquery.slimscroll.min.js",
                "~/Scripts/Lib/jquery.cokie.min.js",
                "~/Scripts/Lib/jquery.validate.min.js",
                "~/Scripts/Lib/jquery.bootstrap.wizard.min.js",
                "~/Scripts/Lib/spinner.min.js",
                "~/Scripts/Lib/bootstrap-datepicker.js",
                "~/Scripts/Lib/jquery.dataTables.js",
                "~/Scripts/Lib/DT_bootstrap.js",
                "~/Scripts/Lib/bootstrap-maxlength.min.js",
                "~/Scripts/Lib/bootstrap.touchspin.js",
                "~/Scripts/Lib/select2.min.js",
                "~/Scripts/Lib/app.js",
                "~/Scripts/Lib/form-validation.js",
                "~/Scripts/Lib/form-wizard.js",
                "~/Scripts/Lib/form-components.js",
                "~/Scripts/Lib/grid-script.js",
                //"~/Scripts/Lib/newsTicker.js", 
                "~/Scripts/Lib/kendo.web.min.js",
                "~/Scripts/Lib/kendo.all.min.js",
                "~/Scripts/Lib/kendo.sortable.min.js",
                "~/Scripts/Lib/toastr.js",
                "~/Scripts/Lib/jquery.confirm.js",
                "~/Scripts/Lib/moment.js",
                "~/Scripts/Lib/moment-range.min.js",
                "~/Scripts/Lib/moment-range.js",
                "~/Scripts/Lib/moment-range.bare.min.js",
                "~/Scripts/Lib/moment-range.bare.js",

                "~/Scripts/Lib/knockout-3.0.0.debug.js",
                "~/Scripts/Lib/knockout-sortable.min.js",
                "~/Scripts/Lib/knockout.validation.js",
                "~/Scripts/Lib/knockout.mapping-latest.js",
                "~/Scripts/Lib/knockout-kendo.min.js",
                "~/Scripts/Application/eGateRoot.js",
                "~/Scripts/Application/CustomisedControls.js",
                "~/Scripts/Application/Model/ModuleModel.js",
               "~/Scripts/Application/ViewModel/ModuleViewModel.js",
               "~/Scripts/Application/Model/NotificationsModel.js",
               "~/Scripts/Application/ViewModel/NotificationsViewModel.js",

               "~/Scripts/Application/Model/UserManualModel.js",

                "~/Scripts/jquery.signalR-1.0.0.min.js",
                "~/Scripts/Lib/twitter-bootstrap-hover-dropdown.min.js",
                //"~/signalr/hubs",
                "~/Scripts/Lib/jquery.ui.chatbox.js",
                "~/Scripts/Lib/jquery.ui.chatbox1.js",
                "~/Scripts/Lib/chat-window.js");
            eGateLayoutAllJs.Orderer = new AsIsBundleOrderer();
            bundles.Add(eGateLayoutAllJs);

            //eGateLayoutAllJs.Include("~/Scripts/Lib/jquery-2.0.3.min.js",
            //    "~/Scripts/Lib/jquery-ui.js",
            //    "~/Scripts/Lib/jquery-migrate-1.4.1.min.js",
            //    "~/Scripts/Lib/bootstrap.min.js",
            //    "~/Scripts/Lib/jquery.slimscroll.min.js",
            //    "~/Scripts/Lib/jquery.cokie.min.js",
            //    "~/Scripts/Lib/jquery.validate.min.js",
            //    "~/Scripts/Lib/jquery.bootstrap.wizard.min.js",
            //    "~/Scripts/Lib/spinner.min.js",
            //    "~/Scripts/Lib/bootstrap-datepicker.js",
            //    "~/Scripts/Lib/jquery.dataTables.js",
            //    "~/Scripts/Lib/DT_bootstrap.js",
            //    "~/Scripts/Lib/bootstrap-maxlength.min.js",
            //    "~/Scripts/Lib/bootstrap.touchspin.js",
            //    "~/Scripts/Lib/select2.min.js",
            //    "~/Scripts/Lib/app.js",
            //    "~/Scripts/Lib/form-validation.js",
            //    "~/Scripts/Lib/form-wizard.js",
            //    "~/Scripts/Lib/form-components.js",
            //    "~/Scripts/Lib/grid-script.js",
            //    //"~/Scripts/Lib/newsTicker.js", 
            //    "~/Scripts/Lib/kendo.web.min.js",
            //    "~/Scripts/Lib/kendo.all.min.js",
            //    "~/Scripts/Lib/kendo.sortable.min.js",
            //    "~/Scripts/Lib/toastr.js",
            //    "~/Scripts/Lib/jquery.confirm.js",
            //    "~/Scripts/Lib/moment.js",
            //    "~/Scripts/Lib/moment-range.min.js",
            //    "~/Scripts/Lib/moment-range.js",
            //    "~/Scripts/Lib/moment-range.bare.min.js",
            //    "~/Scripts/Lib/moment-range.bare.js",

            //    "~/Scripts/Lib/knockout-3.0.0.debug.js",
            //    "~/Scripts/Lib/knockout-sortable.min.js",
            //    "~/Scripts/Lib/knockout.validation.js",
            //    "~/Scripts/Lib/knockout.mapping-latest.js",
            //    "~/Scripts/Lib/knockout-kendo.min.js",
            //    "~/Scripts/Application/eGateRoot.js",
            //    "~/Scripts/Application/CustomisedControls.js",
            //    "~/Scripts/Application/Model/ModuleModel.js",
            //   "~/Scripts/Application/ViewModel/ModuleViewModel.js",
            //   "~/Scripts/Application/Model/NotificationsModel.js",
            //   "~/Scripts/Application/ViewModel/NotificationsViewModel.js",
            //   "~/Scripts/Application/Model/UserManualModel.js",

            //    "~/Scripts/jquery.signalR-1.0.0.min.js",
            //    "~/Scripts/Lib/twitter-bootstrap-hover-dropdown.min.js",
            //    //"~/signalr/hubs",
            //    "~/Scripts/Lib/jquery.ui.chatbox.js",
            //    "~/Scripts/Lib/jquery.ui.chatbox1.js",
            //    "~/Scripts/Lib/chat-window.js");

            // bundles.Add(eGateLayoutAllJs);
            #endregion eGateLayoutAllJs

            #region tasksJs
            //Bundle tasksJs = new Bundle("~/tasksJs", new IBundleTransform[] { new JsMinify() });
            //tasksJs.Orderer = new AsIsBundleOrderer();
            bundles.Add(new ScriptBundle("~/tasksJs").Include(
              "~/Scripts/Application/Model/Tasks/TasksModel.js",
               "~/Scripts/Application/ViewModel/Tasks/TasksViewModel.js"));

            //   bundles.Add(tasksJs);
            #endregion tasksJs


            bundles.Add(new StyleBundle("~/Content/css").Include(
              "~/Content/Styles/font-awesome.min.css",
              "~/Content/Styles/jquery-ui.css",
              "~/Content/Styles/jquery.ui.chatbox.css",
              "~/Content/Styles/jquery.confirm.css",
              "~/Content/Styles/jquery.fileupload-ui.css",
              "~/Content/Styles/bootstrap.min.css",
              "~/Content/Styles/uniform.default.css",
              "~/Content/Styles/datepicker.css",
              "~/Content/Styles/style-metronic.css",
              "~/Content/Styles/style.css",
              "~/Content/Styles/style-responsive.css",
              "~/Content/Styles/grid-style.css",
              "~/Content/Styles/plugins.css",
              "~/Content/Styles/custom.css",
              "~/Content/Styles/default.css",
              "~/Content/Styles/toastr.css",
              "~/Content/Styles/byrei-dyndiv_0.5.css",
              "~/Content/Styles/kendo.common.min.css",
              "~/Content/Styles/kendo.default.min.css",
              "~/Content/Styles/kendo.common-material.min.css",
                "~/Content/Styles/kendo.default.mobile.min.css",
                "~/Content/Styles/kendo.material.min.css",
              "~/Content/FormBuilder/formBuilder.css",
              "~/Content/Styles/menu.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Lib/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/Lib/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Lib/jquery.unobtrusive*",
                        "~/Scripts/Lib/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/Lib/modernizr-*"));


            bundles.Add(new ScriptBundle("~/bundles/layoutScriptsJs").Include(

    "~/Scripts/Lib/knockout.mapping-latest.js",
    "~/Scripts/Lib/kendo.all.min.js",
    "~/Scripts/Lib/knockout-kendo.min.js",
    "~/Scripts/Lib/kendo.web.min.js",
    "~/Scripts/Lib/kendo.sortable.min.js",
    "~/Scripts/Lib/kendo.mobile.min.js",
    "~/Scripts/Lib/bootstrap.min.js",
    "~/Scripts/Lib/bootstrap-datepicker.js",
    "~/Scripts/Lib/DT_bootstrap.js",
    "~/Scripts/Lib/bootstrap-maxlength.min.js",
    "~/Scripts/Lib/bootstrap.touchspin.js",
    "~/Scripts/Lib/twitter-bootstrap-hover-dropdown.min.js",
    "~/Scripts/Lib/moment.js",
    "~/Scripts/Lib/spinner.min.js",
    "~/Scripts/Lib/select2.min.js",
    "~/Scripts/Lib/form-validation.js",
    "~/Scripts/Lib/form-wizard.js",
    "~/Scripts/Lib/form-components.js",
    "~/Scripts/Lib/grid-script.js",
    "~/Scripts/Lib/newsTicker.js",
    "~/Scripts/Lib/toastr.js",
    "~/Scripts/Lib/byrei-dyndiv_1.0rc1-src.js",
    "~/Scripts/Lib/login-soft.js",
    "~/Scripts/Lib/Globalize.min.js",
    "~/Scripts/Lib/app.js",
    "~/Scripts/Application/FormBuilder/knockout-functions.js",
    "~/Scripts/menu.js"
     ));
            //BundleTable.EnableOptimizations = false;
            //bundles.Add(loginCss);


        

            #region EntityFormBundle
            Bundle EntityFormBundle = new Bundle("~/EntityFormBundle", new IBundleTransform[] { new JsMinify() });
            EntityFormBundle.Include(
            "~/Scripts/Application/FormBuilder/EntityForm.js"
                                  );
            bundles.Add(EntityFormBundle);
            #endregion EntityFormBundle

            #region FormDataBundle
            Bundle FormDataBundle = new Bundle("~/FormDataBundle", new IBundleTransform[] { new JsMinify() });
            FormDataBundle.Include(
            "~/Scripts/Application/FormBuilder/FormData.js"
                        );
            bundles.Add(FormDataBundle);
            #endregion FormDataBundle

           

            #region eGateHeaderBundle
            Bundle eGateHeaderBundle = new Bundle("~/eGateHeaderBundle", new IBundleTransform[] { new JsMinify() });
            eGateHeaderBundle.Include(
           "~/Scripts/Lib/twitter-bootstrap-hover-dropdown.min.js"
                                  );
            bundles.Add(eGateHeaderBundle);
            #endregion eGateHeaderBundle

            #region eGateHeaderCss
            Bundle eGateHeaderCss = new Bundle("~/eGateHeaderCss", new IBundleTransform[] { new CssMinify() });
            eGateHeaderCss.Include("~/Content/Styles/font-awesome-animation.min.css"
               );
            bundles.Add(eGateHeaderCss);
            #endregion eGateHeaderCss

            #region MyTasksCHACss
            Bundle MyTasksCHACss = new Bundle("~/MyTasksCHACss", new IBundleTransform[] { new CssMinify() });
            MyTasksCHACss.Include("~/Content/Styles/MyTaskCHA.css"
               );
            bundles.Add(MyTasksCHACss);
            #endregion MyTasksCHACss

            #region CHAUsabilityCss
            Bundle CHAUsabilityCss = new Bundle("~/CHAUsabilityCss", new IBundleTransform[] { new CssMinify() });
            CHAUsabilityCss.Include(
            "~/Content/Styles/MyTaskCHA.css",
            "~/Content/Styles/bootstrap-table-expandable.css"
               );
            bundles.Add(CHAUsabilityCss);
            #endregion CHAUsabilityCss

            #region FormBuilderCss
            Bundle FormBuilderCss = new Bundle("~/FormBuilderCss", new IBundleTransform[] { new CssMinify() });
            FormBuilderCss.Include(
           "~/Content/FormBuilder/formBuilder.css"
               );
            bundles.Add(FormBuilderCss);
            #endregion FormBuilderCss


            #region MyTasksCHABundle
            Bundle MyTasksCHABundle = new Bundle("~/MyTasksCHABundle", new IBundleTransform[] { new JsMinify() });
            MyTasksCHABundle.Include(
            "~/Scripts/Application/Model/MyTasks/MyTasksModel.js",
            "~/Scripts/Application/Model/Import/ImportRoadFormEmpty/ImportRoadFormEmptyGenerationCHAModel.js",
            "~/Scripts/Application/Model/ExportRoadForm/ExportRoadFormsModel.js",
            "~/Scripts/Application/ViewModel/MyTasksCHA/MyTasksCHAViewModel.js",
            "~/Scripts/Application/Model/Import/ImportRoadForm/ImportRoadFormModel.js"
                                  );
            bundles.Add(MyTasksCHABundle);
            #endregion MyTasksCHABundle

            #region CHAUsabilityBundle
            Bundle CHAUsabilityBundle = new Bundle("~/CHAUsabilityBundle", new IBundleTransform[] { new JsMinify() });
            CHAUsabilityBundle.Include(
            "~/Scripts/Application/Model/ExportRoadForm/ExportRoadFormsModel.js",
            "~/Scripts/Application/ViewModel/MyTasksCHA/CHAUsabilityViewModel.js",
            "~/Scripts/Lib/bootstrap-table-expandable.js"
                                  );
            bundles.Add(CHAUsabilityBundle);
            #endregion CHAUsabilityBundle

            #region FormBuilderBundle
            Bundle FormBuilderBundle = new Bundle("~/FormBuilderBundle", new IBundleTransform[] { new JsMinify() });
            FormBuilderBundle.Include(
            "~/Scripts/Application/FormBuilder/FormBuilder.js",
            "~/Scripts/Application/eGateRoot.js"
                                  );
            bundles.Add(FormBuilderBundle);
            #endregion FormBuilderBundle

            #region FormBundle
            Bundle FormBundle = new Bundle("~/FormBundle", new IBundleTransform[] { new JsMinify() });
            FormBundle.Include(
                "~/Scripts/Application/FormBuilder/Form.js"
                                  );
            bundles.Add(FormBundle);
            #endregion FormBundle

            #region FormFieldBundle
            Bundle FormFieldBundle = new Bundle("~/FormFieldBundle", new IBundleTransform[] { new JsMinify() });
            FormFieldBundle.Include(
            "~/Scripts/Application/FormBuilder/FormField.js"
            );
            bundles.Add(FormFieldBundle);
            #endregion FormFieldBundle

            #region FormFieldsRelationBundle
            Bundle FormFieldsRelationBundle = new Bundle("~/FormFieldsRelationBundle", new IBundleTransform[] { new JsMinify() });
            FormFieldsRelationBundle.Include(
            "~/Scripts/Application/FormBuilder/FormFieldsRelation.js"
                                  );
            bundles.Add(FormFieldsRelationBundle);
            #endregion FormFieldsRelationBundle

            #region LookupBundle
            Bundle LookupBundle = new Bundle("~/LookupBundle", new IBundleTransform[] { new JsMinify() });
            LookupBundle.Include(
           "~/Scripts/Application/FormBuilder/Lookup.js"
                                  );
            bundles.Add(LookupBundle);
            #endregion LookupBundle

            #region eGateLayoutForPwdBundle
            Bundle eGateLayoutForPwdBundle = new Bundle("~/eGateLayoutForPwdBundle", new IBundleTransform[] { new JsMinify() });
            eGateLayoutForPwdBundle.Include(
            "~/Scripts/Lib/knockout-3.4.0.js",
            "~/Scripts/Lib/knockout.validation.js",
            "~/Scripts/Lib/angular.min.js",
            "~/Scripts/Lib/jquery-2.0.3.min.js",
            "~/Scripts/Lib/jquery-ui.js",
            "~/Scripts/Lib/jquery-migrate-1.4.1.min.js",
            "~/Scripts/Lib/jquery.slimscroll.min.js",
            "~/Scripts/Lib/jquery.cokie.min.js",
            "~/Scripts/Lib/jquery.validate.min.js",
            "~/Scripts/Lib/jquery.bootstrap.wizard.min.js",
            "~/Scripts/Lib/jquery.dataTables.js",
            "~/Scripts/Lib/jquery.confirm.js",
            "~/Scripts/Lib/jquery.min.js",
            "~/Scripts/Lib/jquery.blockui.min.js",
            "~/Scripts/Lib/jquery.uniform.min.js",
            "~/Scripts/Lib/jquery.backstretch.min.js",
            "~/Scripts/Lib/kendo.all.min.js",
            "~/Scripts/Lib/knockout-kendo.min.js",
            "~/Scripts/Lib/kendo.web.min.js",
            "~/Scripts/Lib/kendo.sortable.min.js",
            "~/Scripts/Lib/kendo.mobile.min.js",
            "~/Scripts/Lib/knockout-3.4.0.debug.js",
            "~/Scripts/Lib/knockout-sortable.min.js",
            "~/Scripts/Lib/knockout.mapping-latest.js",
            "~/Scripts/Lib/bootstrap.min.js",
            "~/Scripts/Lib/bootstrap-datepicker.js",
            "~/Scripts/Lib/bootstrap-maxlength.min.js",
            "~/Scripts/Lib/bootstrap.touchspin.js",
            "~/Scripts/Lib/twitter-bootstrap-hover-dropdown.min.js",
            "~/Scripts/Lib/moment.js",
            "~/Scripts/Lib/spinner.min.js",
            "~/Scripts/Lib/select2.min.js",
            "~/Scripts/Lib/form-validation.js",
            "~/Scripts/Lib/form-wizard.js",
            "~/Scripts/Lib/form-components.js",
            "~/Scripts/Lib/grid-script.js",
            "~/Scripts/Lib/newsTicker.js",
            "~/Scripts/Lib/toastr.js",
            "~/Scripts/Lib/byrei-dyndiv_1.0rc1-src.js",
            "~/Scripts/Lib/login-soft.js",
            "~/Scripts/Lib/Globalize.min.js",
            "~/Scripts/Lib/app.js",
            "~/Scripts/menu.js",
            "~/Scripts/Application/CustomisedControls.js",
            "~/Scripts/Application/eGateRoot.js"
                                  );
            bundles.Add(eGateLayoutForPwdBundle);
            #endregion eGateLayoutForPwdBundle

            #region eGateLayoutBundle
            Bundle eGateLayoutBundle = new Bundle("~/eGateLayoutBundle", new IBundleTransform[] { new JsMinify() });
            eGateLayoutBundle.Include(
            "~/Scripts/Application/eGateRoot.js",
            "~/Scripts/Lib/app.js",
            "~/Scripts/menu.js",
            "~/Scripts/Application/Model/ModuleModel.js",
            "~/Scripts/Application/ViewModel/ModuleViewModel.js",
            "~/Scripts/Application/Model/NotificationsModel.js",
            "~/Scripts/Application/ViewModel/NotificationsViewModel.js",
            "~/Scripts/Application/Model/UserManualModel.js",
            "~/Scripts/jquery.signalR-1.0.0.min.js",
            "~/Scripts/Lib/jquery.ui.chatbox.js",
           "~/Scripts/Lib/jquery.ui.chatbox1.js",
            "~/Scripts/Lib/chat-window.js"
                                  );
            bundles.Add(eGateLayoutBundle);
            #endregion eGateLayoutBundle

            #region eGateLayoutBundle1
            Bundle eGateLayoutBundle1 = new Bundle("~/eGateLayoutBundle1", new IBundleTransform[] { new JsMinify() });
            eGateLayoutBundle1.Include(
            "~/Scripts/Lib/jquery.confirm.js"
            );
            bundles.Add(eGateLayoutBundle1);
            #endregion eGateLayoutBundle1

        }

    }

}