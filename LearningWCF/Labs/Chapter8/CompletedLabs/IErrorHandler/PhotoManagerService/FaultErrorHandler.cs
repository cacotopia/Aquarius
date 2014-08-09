// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Configuration;
using System.ServiceModel.Description;

namespace PhotoManagerService
{
    class ErrorHandlerAttribute : Attribute, IServiceBehavior
    {

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
            {
                dispatcher.ErrorHandlers.Add(new FaultErrorHandler());
            }

        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {

        }
    }

    public class FaultErrorHandler:IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            Console.WriteLine("Uncaught exception of type {0} was thrown. Message: '{1}'", error.GetType(), error.Message);
            return true;

        }

        public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            if (fault == null)
            {
                if (error is ConfigurationErrorsException)
                {
                    FaultException<ReceiverFaultDetail> fe = new FaultException<ReceiverFaultDetail>(new ReceiverFaultDetail(error.Message, true), error.Message, FaultCode.CreateReceiverFaultCode(new FaultCode("Configuration")));
                    MessageFault mf = fe.CreateMessageFault();

                    fault = Message.CreateMessage(version, mf, fe.Action);
                }
            }
        }

    }
}
