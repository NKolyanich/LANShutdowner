﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LANShutdownerServerDLL {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class SettingsServer : global::System.Configuration.ApplicationSettingsBase {
        
        private static SettingsServer defaultInstance = ((SettingsServer)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new SettingsServer())));
        
        public static SettingsServer Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4478")]
        public int Setting_port {
            get {
                return ((int)(this["Setting_port"]));
            }
            set {
                this["Setting_port"] = value;
            }
        }
    }
}
