﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyWcfConsumer.MyService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Question", Namespace="http://schemas.datacontract.org/2004/07/MySoapService")]
    [System.SerializableAttribute()]
    public partial class Question : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QuestionIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RatingField;
        
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
        public string Category {
            get {
                return this.CategoryField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoryField, value) != true)) {
                    this.CategoryField = value;
                    this.RaisePropertyChanged("Category");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int QuestionId {
            get {
                return this.QuestionIdField;
            }
            set {
                if ((this.QuestionIdField.Equals(value) != true)) {
                    this.QuestionIdField = value;
                    this.RaisePropertyChanged("QuestionId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Rating {
            get {
                return this.RatingField;
            }
            set {
                if ((this.RatingField.Equals(value) != true)) {
                    this.RatingField = value;
                    this.RaisePropertyChanged("Rating");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetServiceVersion", ReplyAction="http://tempuri.org/IService1/GetServiceVersionResponse")]
        string GetServiceVersion();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetServiceVersion", ReplyAction="http://tempuri.org/IService1/GetServiceVersionResponse")]
        System.Threading.Tasks.Task<string> GetServiceVersionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DoubleNumber", ReplyAction="http://tempuri.org/IService1/DoubleNumberResponse")]
        int DoubleNumber(int num);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DoubleNumber", ReplyAction="http://tempuri.org/IService1/DoubleNumberResponse")]
        System.Threading.Tasks.Task<int> DoubleNumberAsync(int num);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetQuestion", ReplyAction="http://tempuri.org/IService1/GetQuestionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.InvalidOperationException), Action="http://tempuri.org/IService1/GetQuestionInvalidOperationExceptionFault", Name="InvalidOperationException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        MyWcfConsumer.MyService.Question GetQuestion(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetQuestion", ReplyAction="http://tempuri.org/IService1/GetQuestionResponse")]
        System.Threading.Tasks.Task<MyWcfConsumer.MyService.Question> GetQuestionAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : MyWcfConsumer.MyService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<MyWcfConsumer.MyService.IService1>, MyWcfConsumer.MyService.IService1 {
        
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
        
        public string GetServiceVersion() {
            return base.Channel.GetServiceVersion();
        }
        
        public System.Threading.Tasks.Task<string> GetServiceVersionAsync() {
            return base.Channel.GetServiceVersionAsync();
        }
        
        public int DoubleNumber(int num) {
            return base.Channel.DoubleNumber(num);
        }
        
        public System.Threading.Tasks.Task<int> DoubleNumberAsync(int num) {
            return base.Channel.DoubleNumberAsync(num);
        }
        
        public MyWcfConsumer.MyService.Question GetQuestion(int id) {
            return base.Channel.GetQuestion(id);
        }
        
        public System.Threading.Tasks.Task<MyWcfConsumer.MyService.Question> GetQuestionAsync(int id) {
            return base.Channel.GetQuestionAsync(id);
        }
    }
}
