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
            try
            {
                MyServiceHost.StartService();
                Console.WriteLine("Press <ENTER> to terminate the host application");
                Console.ReadLine();
            }
            finally
            {
                MyServiceHost.StopService();
            }
        }
    }
}
