// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using Client.localhost;
using System.Threading;
using System.ServiceModel;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Client running on thread {0}", Thread.CurrentThread.GetHashCode());
            Console.WriteLine();
            
            CallbackType cb = new CallbackType();
            InstanceContext context = new InstanceContext(cb);

            using (HelloIndigoContractClient proxy = new HelloIndigoContractClient(context))
            {

                Console.WriteLine("Calling HelloIndigo()");
                proxy.HelloIndigo("Hello from Client.");
                Console.WriteLine("Returned from HelloIndigo()");

                Console.ReadLine();
            }
        }
    }
}
