﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PatternPass.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PatternPass.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap MenuIcon {
            get {
                object obj = ResourceManager.GetObject("MenuIcon", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duplicate node values in input string &apos;{0}&apos;..
        /// </summary>
        internal static string Pattern_Ctor_Decode_Duplicate_Node_Values {
            get {
                return ResourceManager.GetString("Pattern_Ctor_Decode_Duplicate_Node_Values", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid pattern dimensions in input encoded string &apos;{0}&apos;..
        /// </summary>
        internal static string Pattern_Ctor_Decode_Invalid_Dimensions {
            get {
                return ResourceManager.GetString("Pattern_Ctor_Decode_Invalid_Dimensions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Input string &apos;{0}&apos; does not match the format of an encoded pattern..
        /// </summary>
        internal static string Pattern_Ctor_Decode_Invalid_Format {
            get {
                return ResourceManager.GetString("Pattern_Ctor_Decode_Invalid_Format", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid node value &apos;{0}&apos; in input string &apos;{1}&apos;..
        /// </summary>
        internal static string Pattern_Ctor_Decode_Invalid_Node_Value {
            get {
                return ResourceManager.GetString("Pattern_Ctor_Decode_Invalid_Node_Value", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid node list size in input string &apos;{0}&apos; - does not match the provided dimensions {1}x{2}..
        /// </summary>
        internal static string Pattern_Ctor_Decode_Length_Mismatch {
            get {
                return ResourceManager.GetString("Pattern_Ctor_Decode_Length_Mismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type of {0} ({1}) does not match the type of {2} ({3})..
        /// </summary>
        internal static string Pattern_Ctor_Generic_Type_Mismatch {
            get {
                return ResourceManager.GetString("Pattern_Ctor_Generic_Type_Mismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Input node array is filled with only null values..
        /// </summary>
        internal static string Pattern_EnsureNodeOrder_All_Null_Nodes {
            get {
                return ResourceManager.GetString("Pattern_EnsureNodeOrder_All_Null_Nodes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Input node array has duplicate values..
        /// </summary>
        internal static string Pattern_EnsureNodeOrder_Duplicate_Node_Values {
            get {
                return ResourceManager.GetString("Pattern_EnsureNodeOrder_Duplicate_Node_Values", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Input node array has no rows..
        /// </summary>
        internal static string Pattern_EnsureNodeOrder_Empty_Node_Array {
            get {
                return ResourceManager.GetString("Pattern_EnsureNodeOrder_Empty_Node_Array", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Input node array has no columns..
        /// </summary>
        internal static string Pattern_EnsureNodeOrder_No_Columns {
            get {
                return ResourceManager.GetString("Pattern_EnsureNodeOrder_No_Columns", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; Display.
        /// </summary>
        internal static string PatternDisplayForm_Title {
            get {
                return ResourceManager.GetString("PatternDisplayForm_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PatternPass Plugin.
        /// </summary>
        internal static string PatternPassExt_GetMenuItem_PatternPass_Plugin {
            get {
                return ResourceManager.GetString("PatternPassExt_GetMenuItem_PatternPass_Plugin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Setup Pattern.
        /// </summary>
        internal static string PatternPassExt_GetMenuItem_Setup_Pattern {
            get {
                return ResourceManager.GetString("PatternPassExt_GetMenuItem_Setup_Pattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Show Pattern.
        /// </summary>
        internal static string PatternPassExt_GetMenuItem_Show_Pattern {
            get {
                return ResourceManager.GetString("PatternPassExt_GetMenuItem_Show_Pattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; Setup.
        /// </summary>
        internal static string PatternSetupForm_Title {
            get {
                return ResourceManager.GetString("PatternSetupForm_Title", resourceCulture);
            }
        }
    }
}
