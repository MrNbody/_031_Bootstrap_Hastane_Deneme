﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _031_Bootstrap_Hastane_Deneme.ServiceReferenceHastane {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceHastane.WebServiceHastaneSoap")]
    public interface WebServiceHastaneSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ekle", ReplyAction="*")]
        bool Ekle();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ekle", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> EkleAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Kontrol", ReplyAction="*")]
        bool Kontrol();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Kontrol", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> KontrolAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebServiceHastaneSoapChannel : _031_Bootstrap_Hastane_Deneme.ServiceReferenceHastane.WebServiceHastaneSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServiceHastaneSoapClient : System.ServiceModel.ClientBase<_031_Bootstrap_Hastane_Deneme.ServiceReferenceHastane.WebServiceHastaneSoap>, _031_Bootstrap_Hastane_Deneme.ServiceReferenceHastane.WebServiceHastaneSoap {
        
        public WebServiceHastaneSoapClient() {
        }
        
        public WebServiceHastaneSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServiceHastaneSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceHastaneSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceHastaneSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Ekle() {
            return base.Channel.Ekle();
        }
        
        public System.Threading.Tasks.Task<bool> EkleAsync() {
            return base.Channel.EkleAsync();
        }
        
        public bool Kontrol() {
            return base.Channel.Kontrol();
        }
        
        public System.Threading.Tasks.Task<bool> KontrolAsync() {
            return base.Channel.KontrolAsync();
        }
    }
}
