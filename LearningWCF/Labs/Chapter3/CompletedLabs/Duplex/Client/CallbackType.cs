using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Client
{
    class CallbackType: localhost.HelloIndigoContractCallback
    {
        #region HelloIndigoContractCallback Members

        public void HelloIndigoCallback(string message)
        {
            Console.WriteLine("HelloIndigoCallback on thread {0}", Thread.CurrentThread.GetHashCode());
        }

        #endregion
    }
}
