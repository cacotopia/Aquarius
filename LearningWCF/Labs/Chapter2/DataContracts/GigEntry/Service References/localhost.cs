﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.5477
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GigEntry.localhost
{
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LinkItem", Namespace="http://schemas.thatindigogirl.com/sample/2006/06")]
    [System.SerializableAttribute()]
    public partial class LinkItem : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private long IdField;
        
        private string TitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateStartField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateEndField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string URIField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Title
        {
            get
            {
                return this.TitleField;
            }
            set
            {
                this.TitleField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public System.DateTime DateStart
        {
            get
            {
                return this.DateStartField;
            }
            set
            {
                this.DateStartField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public System.DateTime DateEnd
        {
            get
            {
                return this.DateEndField;
            }
            set
            {
                this.DateEndField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public string URI
        {
            get
            {
                return this.URIField;
            }
            set
            {
                this.URIField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.thatindigogirl.com/samples/2006/06", ConfigurationName="GigEntry.localhost.GigManagerServiceContract", SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface GigManagerServiceContract
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.thatindigogirl.com/samples/2006/06/GigManagerServiceContract/SaveGig", ReplyAction="http://www.thatindigogirl.com/samples/2006/06/GigManagerServiceContract/SaveGigRe" +
            "sponse")]
        void SaveGig(GigEntry.localhost.LinkItem item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.thatindigogirl.com/samples/2006/06/GigManagerServiceContract/GetGig", ReplyAction="http://www.thatindigogirl.com/samples/2006/06/GigManagerServiceContract/GetGigRes" +
            "ponse")]
        GigEntry.localhost.LinkItem GetGig();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface GigManagerServiceContractChannel : GigEntry.localhost.GigManagerServiceContract, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class GigManagerServiceContractClient : System.ServiceModel.ClientBase<GigEntry.localhost.GigManagerServiceContract>, GigEntry.localhost.GigManagerServiceContract
    {
        
        public GigManagerServiceContractClient()
        {
        }
        
        public GigManagerServiceContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public GigManagerServiceContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public GigManagerServiceContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public GigManagerServiceContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public void SaveGig(GigEntry.localhost.LinkItem item)
        {
            base.Channel.SaveGig(item);
        }
        
        public GigEntry.localhost.LinkItem GetGig()
        {
            return base.Channel.GetGig();
        }
    }
}
