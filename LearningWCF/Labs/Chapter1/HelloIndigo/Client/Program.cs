// ?2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;


namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HelloIndigoServiceClient proxy = new HelloIndigoServiceClient()) 
            {
                string hello = proxy.HelloIndigo();
                Console.WriteLine(hello);
                Console.WriteLine("Press <ENTER> to terminate Client.");
                Console.ReadLine();
            }
            //HelloIndigoService.HelloIndigoServiceClient proxy = new Client.HelloIndigoService.HelloIndigoServiceClient();
           
           
        }
    }
}
