// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(HelloIndigo.HelloIndigoService), new Uri("http://localhost:8000/HelloIndigo")))
            {
                host.AddServiceEndpoint(typeof(HelloIndigo.IHelloIndigoService), new BasicHttpBinding(), "HelloIndigoService");
                host.Open();

                Console.WriteLine("Press <ENTER> to terminate the service host");
                Console.ReadLine();

            }
        }
    }
}
