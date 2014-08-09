using System;
using System.ServiceModel;

namespace Host
{

    //[ServiceContract(Namespace="http://www.thatindigogirl.com/samples/2006/06")]
    //public interface IHelloIndigoService
    //{
    //    [OperationContract]
    //    string HelloIndigo();
    //}

    //public class HelloIndigoService : IHelloIndigoService
    //{
    //    #region IHelloIndigoService Members

    //    public string HelloIndigo()
    //    {
    //        return "Hello Indigo";
    //    }

    //    #endregion
    //}

    internal class MyServiceHost
    {
        internal static ServiceHost myServiceHost = null;

        internal static void StartService()
        {
            // Instantiate new ServiceHost 
            //myServiceHost = new ServiceHost(typeof(HelloIndigoService));
            myServiceHost = new ServiceHost(typeof(HelloIndigo.HelloIndigoService));
            myServiceHost.Open();
        }

        internal static void StopService()
        {
            // Call StopService from your shutdown logic (i.e. dispose method)
            if (myServiceHost.State != CommunicationState.Closed)
                myServiceHost.Close();
        }
    }
}

