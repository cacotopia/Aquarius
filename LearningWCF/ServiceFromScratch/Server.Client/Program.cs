using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace Server.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            EndpointAddress ea = new EndpointAddress("http://127.0.0.1:4502/HelloIndigo/HelloIndigoService");
            EndpointAddress eb = new EndpointAddress("http://127.0.0.1:4502/GoodbyeIndigo/GoodbyeIndigoService");

            IHelloIndigoService proxyHello = ChannelFactory<IHelloIndigoService>.CreateChannel(new BasicHttpBinding(),ea);
            IGoodbyeIndigoService proxyGoodbye = ChannelFactory<IGoodbyeIndigoService>.CreateChannel(new BasicHttpBinding(),eb);

            string hello = proxyHello.HelloIndigo();
            string goodbye = proxyGoodbye.GoodbyeIndigo();
            Console.WriteLine(hello);
            Console.WriteLine(goodbye);
            Console.WriteLine("Press <Enter> to terminate Client!");
            Console.ReadLine();
        }
    }
}
