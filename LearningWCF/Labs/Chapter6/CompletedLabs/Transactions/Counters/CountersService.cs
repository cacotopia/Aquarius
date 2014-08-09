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
using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Counters.Dalc;
using System.Transactions;

namespace Counters
{
    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface ICountersService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void ResetCounters();

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        void SetCounter1(int counterValue);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        void SetCounter2(int counterValue);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.NotAllowed)]
        List<CounterInfo> GetCounters();
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CountersService : ICountersService
    {

        #region ICountersService Members

        [OperationBehavior(TransactionScopeRequired=true)]
        public void ResetCounters()
        {
            //using (TransactionScope scope = new TransactionScope())
            //{
                TraceTransactionIds("ResetCounters()");

                using (Counters.Dalc.CountersDataAccess countersDataAccess = new Counters.Dalc.CountersDataAccess())
                {
                    countersDataAccess.SetCounter1(0);
                    countersDataAccess.SetCounter2(0);
                }

            //    scope.Complete();
            //}

        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void SetCounter1(int counterValue)
        {
            TraceTransactionIds("SetCounter1()");

            using (Counters.Dalc.CountersDataAccess countersDataAccess = new Counters.Dalc.CountersDataAccess())
            {
                countersDataAccess.SetCounter1(counterValue);
            }
        }

        private void TraceTransactionIds(string method)
        {
            if (Transaction.Current != null)
                Console.WriteLine("{0}\r\n\tlocal transaction = {1}\r\n\tdistributed transaction = {2}", method, Transaction.Current.TransactionInformation.LocalIdentifier, Transaction.Current.TransactionInformation.DistributedIdentifier);
            else
                Console.WriteLine("{0} - transaction is null", method);

        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void SetCounter2(int counterValue)
        {
            TraceTransactionIds("SetCounter2()");

            using (Counters.Dalc.CountersDataAccess countersDataAccess = new Counters.Dalc.CountersDataAccess())
            {
                countersDataAccess.SetCounter2(counterValue);
            }
        }

        public List<CounterInfo> GetCounters()
        {

            List<CounterInfo> counters = new List<CounterInfo>();

            using (Counters.Dalc.CountersDataAccess countersDataAccess = new Counters.Dalc.CountersDataAccess())
            {
                CountersDataSet.CountersDataTable table = countersDataAccess.GetCounters();
                foreach (CountersDataSet.CountersRow r in table)
                {

                    CounterInfo counter = new CounterInfo();
                    counter.Id = r.id;
                    counter.CounterValue = r.value;
                    counters.Add(counter);
                }
            }

            return counters;

        }

        #endregion
    }
}
