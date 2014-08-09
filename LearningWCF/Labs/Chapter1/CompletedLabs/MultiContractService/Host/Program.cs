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
            ServiceHost hostA = null;
            ServiceHost hostB = null;

            try
            {
                hostA = new ServiceHost(typeof(BusinessServices.ServiceA));
                hostB = new ServiceHost(typeof(BusinessServices.ServiceB));

                hostA.Open();
                hostB.Open();

                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to terminate Host");
                Console.ReadLine();
            }
            finally
            {
                hostA.Close();
                hostB.Close();
            }

     	}
	}
}
