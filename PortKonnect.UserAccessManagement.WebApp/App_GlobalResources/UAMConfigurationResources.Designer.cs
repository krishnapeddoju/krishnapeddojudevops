//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option or rebuild the Visual Studio project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class UAMConfigurationResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal UAMConfigurationResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.UAMConfigurationResources", global::System.Reflection.Assembly.Load("App_GlobalResources"));
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 90.
        /// </summary>
        internal static string DormantUserDays {
            get {
                return ResourceManager.GetString("DormantUserDays", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 3.
        /// </summary>
        internal static string IncorrectPWDCount {
            get {
                return ResourceManager.GetString("IncorrectPWDCount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 45.
        /// </summary>
        internal static string PasswordExpiryDays {
            get {
                return ResourceManager.GetString("PasswordExpiryDays", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 100.
        /// </summary>
        internal static string SessionTimeOut {
            get {
                return ResourceManager.GetString("SessionTimeOut", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 120.
        /// </summary>
        internal static string UserCreationLifeSpan {
            get {
                return ResourceManager.GetString("UserCreationLifeSpan", resourceCulture);
            }
        }
    }
}