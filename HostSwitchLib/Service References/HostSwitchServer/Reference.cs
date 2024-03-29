﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18034
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HostSwitchLib.HostSwitchServer {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="HostItem", Namespace="http://schemas.datacontract.org/2004/07/HostSwitchLib")]
    [System.SerializableAttribute()]
    public partial class HostItem : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KeyField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Key {
            get {
                return this.KeyField;
            }
            set {
                if ((object.ReferenceEquals(this.KeyField, value) != true)) {
                    this.KeyField = value;
                    this.RaisePropertyChanged("Key");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HostSwitchServer.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/BackDefaultHost", ReplyAction="http://tempuri.org/IService1/BackDefaultHostResponse")]
        bool BackDefaultHost(string content);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/WriteHostContent", ReplyAction="http://tempuri.org/IService1/WriteHostContentResponse")]
        bool WriteHostContent(string key, string content);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReadHostContent", ReplyAction="http://tempuri.org/IService1/ReadHostContentResponse")]
        string ReadHostContent(string key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateHostContent", ReplyAction="http://tempuri.org/IService1/CreateHostContentResponse")]
        bool CreateHostContent(string key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetHostList", ReplyAction="http://tempuri.org/IService1/GetHostListResponse")]
        HostSwitchLib.HostSwitchServer.HostItem[] GetHostList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/FileExists", ReplyAction="http://tempuri.org/IService1/FileExistsResponse")]
        bool FileExists(string key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RenameHostContent", ReplyAction="http://tempuri.org/IService1/RenameHostContentResponse")]
        bool RenameHostContent(string p, string p_2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteHostContent", ReplyAction="http://tempuri.org/IService1/DeleteHostContentResponse")]
        void DeleteHostContent(string p);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : HostSwitchLib.HostSwitchServer.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<HostSwitchLib.HostSwitchServer.IService1>, HostSwitchLib.HostSwitchServer.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool BackDefaultHost(string content) {
            return base.Channel.BackDefaultHost(content);
        }
        
        public bool WriteHostContent(string key, string content) {
            return base.Channel.WriteHostContent(key, content);
        }
        
        public string ReadHostContent(string key) {
            return base.Channel.ReadHostContent(key);
        }
        
        public bool CreateHostContent(string key) {
            return base.Channel.CreateHostContent(key);
        }
        
        public HostSwitchLib.HostSwitchServer.HostItem[] GetHostList() {
            return base.Channel.GetHostList();
        }
        
        public bool FileExists(string key) {
            return base.Channel.FileExists(key);
        }
        
        public bool RenameHostContent(string p, string p_2) {
            return base.Channel.RenameHostContent(p, p_2);
        }
        
        public void DeleteHostContent(string p) {
            base.Channel.DeleteHostContent(p);
        }
    }
}
