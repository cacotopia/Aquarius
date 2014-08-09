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
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Messaging
{
    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IMessagingService
    {
        [OperationContract(IsOneWay=true)]
        void SendMessage1(string message);

        [OperationContract(IsOneWay=true)]
        void SendMessage2(string message);
    
        [OperationContract(IsOneWay=true)]
        void SendMessage3(string message);

    }

    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single, ConcurrencyMode=ConcurrencyMode.Multiple, UseSynchronizationContext=false)]
    public class MessagingService : IMessagingService
    {
        int m_messageCounter;
        Dictionary<int, string> m_messages = new Dictionary<int, string>();
        Mutex m_mutex = new Mutex(false);

        int m_messageCounter2;
        Dictionary<int, string> m_messages2 = new Dictionary<int, string>();
        Mutex m_mutex2 = new Mutex(false);

        #region IMessagingService Members

        public void SendMessage1(string message)
        {
            try
            {
                m_mutex.WaitOne();

                m_messages.Add(m_messageCounter, message);
                Trace.WriteLine(string.Format("Message {0}: {1}", m_messageCounter, message));
                m_messageCounter++;
            }
            finally
            {
                m_mutex.ReleaseMutex();
            }

        }

        public void SendMessage2(string message)
        {

                try
                {
                    m_mutex.WaitOne();

                    m_messages.Add(m_messageCounter, message);
                    Trace.WriteLine(string.Format("Message {0}: {1}", m_messageCounter, message));
                    m_messageCounter++;
                }
                finally
                {
                    m_mutex.ReleaseMutex();
                }
            }

        public void SendMessage3(string message)
        {
            try
            {
                m_mutex2.WaitOne();

                m_messages2.Add(m_messageCounter2, message);
                Trace.WriteLine(string.Format("Message {0}: {1}", m_messageCounter2, message));
                m_messageCounter2++;
            }
            finally
            {
                m_mutex2.ReleaseMutex();
            }
        }
        #endregion
    }
}
