﻿//------------------------------------------------------------------------------
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
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Constants {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Constants() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ToDo.App_LocalResources.Constants", typeof(Constants).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to amtodoapp.mongo.cosmos.azure.com.
        /// </summary>
        public static string DBHost {
            get {
                return ResourceManager.GetString("DBHost", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ************.
        /// </summary>
        public static string DBPaswd {
            get {
                return ResourceManager.GetString("DBPaswd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 10255.
        /// </summary>
        public static string DBPort {
            get {
                return ResourceManager.GetString("DBPort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to amtodoapp.
        /// </summary>
        public static string DBUser {
            get {
                return ResourceManager.GetString("DBUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ToDo.
        /// </summary>
        public static string ToDoDBName {
            get {
                return ResourceManager.GetString("ToDoDBName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tasks.
        /// </summary>
        public static string ToDoTaskTableName {
            get {
                return ResourceManager.GetString("ToDoTaskTableName", resourceCulture);
            }
        }
    }
}
