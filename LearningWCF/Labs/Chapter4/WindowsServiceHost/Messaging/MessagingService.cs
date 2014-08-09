// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Threading;

namespace Messaging
{
    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IMessagingService
    {
        [OperationContract]
        string SendMessage(string message);
    }

    [ServiceBehavior(UseSynchronizationContext=false)]
    public class MessagingService : IMessagingService
    {
        #region IMessagingService Members

        public string SendMessage(string message)
        {
            return String.Format("Message '{0}' received on thread {1}", message, Thread.CurrentThread.GetHashCode());
        }

        #endregion
    }


}
