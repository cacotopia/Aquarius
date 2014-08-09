// © 2007 Michele Leroux Bustamante. All rights reserved 
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
            using (localhost.CrudServiceClient proxy = new Client.localhost.CrudServiceClient())
            {

                Console.WriteLine("Using Admin credentials...<Enter> to continue");
                Console.ReadLine();

                proxy.ClientCredentials.UserName.UserName = "Admin";
                proxy.ClientCredentials.UserName.Password = "p@ssw0rd";

                Console.WriteLine();
                string s = proxy.CreateSomething();
                Console.WriteLine(s); 
                
                s = proxy.ReadSomething();
                Console.WriteLine(s);

                s = proxy.DeleteSomething();
                Console.WriteLine(s);

                s = proxy.UpdateSomething();
                Console.WriteLine(s);

            }

            Console.WriteLine();

            using (localhost.CrudServiceClient proxy = new Client.localhost.CrudServiceClient())
            {
                Console.WriteLine("Using User credentials...<Enter> to continue");
                Console.ReadLine();
            
                proxy.ClientCredentials.UserName.UserName = "User";
                proxy.ClientCredentials.UserName.Password = "p@ssw0rd";

                Console.WriteLine();
                string s = proxy.ReadSomething();
                Console.WriteLine(s);

                s = proxy.DeleteSomething(); // access denied
                Console.WriteLine(s);

                Console.ReadLine();
            }


        }
    }
}
