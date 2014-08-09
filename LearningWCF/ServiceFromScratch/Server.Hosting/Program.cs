using System;
using System.Collections.Generic;
using System.Text;
using Server.Indigo;
using System.ServiceModel;


namespace Server.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            using (ServiceHost host = new ServiceHost(typeof(Server.Indigo.HelloIndigoService),new Uri("http://127.0.0.1:4502/HelloIndigo"))) 
            {
                host.AddServiceEndpoint(typeof(Server.Indigo.IHelloIndigoService),new BasicHttpBinding(),"HelloIndigoService");               
                host.Open();
                Console.WriteLine("Press <Enter> to terminate the service host.");
                Console.ReadKey();
            }
            */          
            using (ServiceHost hostA = new ServiceHost(typeof(Server.Indigo.HelloIndigoService), new Uri("http://127.0.0.1:4502/HelloIndigo")),
                               hostB = new ServiceHost(typeof(Server.Indigo.GoodbyeIndigoService), new Uri("http://127.0.0.1:4502/GoodbyeIndigo")))
                            
            {
                hostA.AddServiceEndpoint(typeof(Server.Indigo.IHelloIndigoService),new BasicHttpBinding(),"HelloIndigoService");
                hostB.AddServiceEndpoint(typeof(Server.Indigo.GoodbyeIndigoService),new BasicHttpBinding(),"GoodbyeIndigoService");
                hostA.Open();
                hostB.Open();
                Console.WriteLine("Press <Enter> to terminate the service host.");
                Console.ReadKey();
            }
        }
    }
}
