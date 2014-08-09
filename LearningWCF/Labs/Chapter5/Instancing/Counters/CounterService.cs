// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Windows.Forms;
using System.Threading;
using System.ServiceModel.Channels;

namespace Counters
{
   [ServiceContract(Namespace="http://www.thatindigogirl.com/samples/2006/06")]
   public interface ICounterService
   {
      [OperationContract]
      int IncrementCounter();

      [OperationContract]
      void ThrowException();

       [OperationContract]
       void ThrowFault();
  }

   [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
   public class CounterService:ICounterService, IDisposable
   {
      private int m_counter;

      #region ICounterService Members

      int ICounterService.IncrementCounter()
      {
         m_counter++;
         MessageBox.Show(String.Format("Incrementing counter to {0}.\r\nSession Id: {1}", m_counter, OperationContext.Current.SessionId));

         return m_counter;
      }

    public void ThrowException()
      {
          throw new NotImplementedException("This is an Exception.");
      }

      public void ThrowFault()
      {
          throw new FaultException("This is a FaultException.");
      }

      #endregion

       #region IDisposable Members

       void IDisposable.Dispose()
       {
           //MessageBox.Show(String.Format("Disposing on thread {0}.", Thread.CurrentThread.GetHashCode()));
       }

       #endregion

  }
}
