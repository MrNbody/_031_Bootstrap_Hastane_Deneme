﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfString", Namespace="http://tempuri.org/", ItemName="string")]
    [System.SerializableAttribute()]
    public class ArrayOfString : System.Collections.Generic.List<string> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceDoktorAra.WebServiceDoktorAraSoap")]
    public interface WebServiceDoktorAraSoap {
        
        // CODEGEN: Generating message contract since element name prefix from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DoktorGetir", ReplyAction="*")]
        _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirResponse DoktorGetir(_031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DoktorGetir", ReplyAction="*")]
        System.Threading.Tasks.Task<_031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirResponse> DoktorGetirAsync(_031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DoktorGetirRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="DoktorGetir", Namespace="http://tempuri.org/", Order=0)]
        public _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirRequestBody Body;
        
        public DoktorGetirRequest() {
        }
        
        public DoktorGetirRequest(_031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class DoktorGetirRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string prefix;
        
        public DoktorGetirRequestBody() {
        }
        
        public DoktorGetirRequestBody(string prefix) {
            this.prefix = prefix;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DoktorGetirResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="DoktorGetirResponse", Namespace="http://tempuri.org/", Order=0)]
        public _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirResponseBody Body;
        
        public DoktorGetirResponse() {
        }
        
        public DoktorGetirResponse(_031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class DoktorGetirResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.ArrayOfString DoktorGetirResult;
        
        public DoktorGetirResponseBody() {
        }
        
        public DoktorGetirResponseBody(_031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.ArrayOfString DoktorGetirResult) {
            this.DoktorGetirResult = DoktorGetirResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebServiceDoktorAraSoapChannel : _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.WebServiceDoktorAraSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServiceDoktorAraSoapClient : System.ServiceModel.ClientBase<_031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.WebServiceDoktorAraSoap>, _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.WebServiceDoktorAraSoap {
        
        public WebServiceDoktorAraSoapClient() {
        }
        
        public WebServiceDoktorAraSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServiceDoktorAraSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceDoktorAraSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceDoktorAraSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirResponse _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.WebServiceDoktorAraSoap.DoktorGetir(_031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirRequest request) {
            return base.Channel.DoktorGetir(request);
        }
        
        public _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.ArrayOfString DoktorGetir(string prefix) {
            _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirRequest inValue = new _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirRequest();
            inValue.Body = new _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirRequestBody();
            inValue.Body.prefix = prefix;
            _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirResponse retVal = ((_031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.WebServiceDoktorAraSoap)(this)).DoktorGetir(inValue);
            return retVal.Body.DoktorGetirResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<_031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirResponse> _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.WebServiceDoktorAraSoap.DoktorGetirAsync(_031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirRequest request) {
            return base.Channel.DoktorGetirAsync(request);
        }
        
        public System.Threading.Tasks.Task<_031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirResponse> DoktorGetirAsync(string prefix) {
            _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirRequest inValue = new _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirRequest();
            inValue.Body = new _031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.DoktorGetirRequestBody();
            inValue.Body.prefix = prefix;
            return ((_031_Bootstrap_Hastane_Deneme.ServiceReferenceDoktorAra.WebServiceDoktorAraSoap)(this)).DoktorGetirAsync(inValue);
        }
    }
}
