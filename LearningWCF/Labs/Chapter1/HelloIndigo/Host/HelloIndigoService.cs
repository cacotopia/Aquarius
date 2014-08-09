using System;
using System.ServiceModel;

namespace Host
{

    // The following settings must be added to your configuration file in order for 
    // the new WCF service item added to your project to work correctly.

    // <system.serviceModel>
    //    <services>
    //      <!-- Before deployment, you should remove the returnFaults behavior configuration to avoid disclosing information in exception messages -->
    //      <service type="Host.HelloIndigoService" behaviorConfiguration="returnFaults">
    //        <endpoint contract="Host.IHelloIndigoService" binding="wsHttpBinding"/>
    //      </service>
    //    </services>
    //    <behaviors>
    //      <serviceBehaviors>
    //        <behavior name="returnFaults" >
    //          <serviceDebug includeExceptionDetailInFaults="true" />
    //        </behavior>
    //       </serviceBehaviors>
    //    </behaviors>
    // </system.serviceModel>


    // A WCF service consists of a contract (defined below), 
    // a class which implements that interface, and configuration 
    // entries that specify behaviors and endpoints associated with 
    // that implementation (see <system.serviceModel> in your application
    // configuration file).

    //[ServiceContract(Namespace="http://www.cacotopia.com/sample/2014/07")]
    //public interface IHelloIndigoService
    //{
    //    [OperationContract]
    //    string HelloIndigo();
    //}

    //public class HelloIndigoService : IHelloIndigoService
    //{
    //    public string HelloIndigo()
    //    {
    //        return "Hello Indigo!";
    //    }
    //}

    internal class MyServiceHost
    {
        internal static ServiceHost myServiceHost = null;

        internal static void StartService()
        {
            // Consider putting the baseAddress in the configuration system
            // and getting it here with AppSettings
            //Uri baseAddress = new Uri("http://127.0.0.1:8080/Host/HelloIndigoService");

            // Instantiate new ServiceHost 
            //myServiceHost = new ServiceHost(typeof(HelloIndigoService), baseAddress);
            // myServiceHost = new ServiceHost(typeof(Host.HelloIndigoService));
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

