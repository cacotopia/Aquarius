// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Counters.Dalc
{
    public class CountersDataAccess: IDisposable
    {

        CountersDataSetTableAdapters.CountersTableAdapter m_adapter = new Counters.Dalc.CountersDataSetTableAdapters.CountersTableAdapter();

        public CountersDataAccess()
            : this(null)
        {
        }

        public CountersDataAccess(string connectionString)
        {
            
            if (connectionString == null)
                connectionString = ConfigurationManager.ConnectionStrings["CountersDemoConnectionString"].ConnectionString;
            m_adapter.Connection.ConnectionString = connectionString;
            m_adapter.Connection.Open();

        }

        public void ResetCounters()
        {

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    m_adapter.UpdateQuery(0, 1);
                    m_adapter.UpdateQuery(0, 2);
                }
                finally
                {
                    m_adapter.Connection.Close();
                }

                scope.Complete();
            }
        }

        public void SetCounter1(int counterValue)
        {
            if (counterValue > 20)
                throw new InvalidOperationException("Counter 1 cannot exceed 20");

            m_adapter.UpdateQuery(counterValue, 1);    
        }

        public void SetCounter2(int counterValue)
        {
            if (counterValue > 10)
                throw new InvalidOperationException("Counter 2 cannot exceed 10");

            m_adapter.UpdateQuery(counterValue, 2);
        }

        public int GetCounter1()
        {

            CountersDataSet.CountersDataTable table = m_adapter.GetDataById(1);
            CountersDataSet.CountersRow r = table.Rows[0] as CountersDataSet.CountersRow;
            
            return r.value;

        }

        public int GetCounter2()
        {
            CountersDataSet.CountersDataTable table = m_adapter.GetDataById(2);
            CountersDataSet.CountersRow r = table.Rows[0] as CountersDataSet.CountersRow;

            return r.value;

        }

        public CountersDataSet.CountersDataTable GetCounters()
        {
            return m_adapter.GetData();
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.Close();
        }

        private void Close()
        {
            this.m_adapter.Connection.Close();
        }

        #endregion
    }
}
