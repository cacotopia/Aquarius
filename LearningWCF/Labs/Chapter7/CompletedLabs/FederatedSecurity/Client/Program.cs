// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
   
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {


            using (localhost.SecureServiceContractClient proxy = new Client.localhost.SecureServiceContractClient())
            {
                string s = proxy.SendMessage("Hello from Client.");
                Console.WriteLine(s);
            }
          
            Console.ReadLine();

        }
    }
}
