// ?2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using BusinessServiceContracts;


namespace BusinessServices
{

    public class ServiceA :IAdmin,IServiceA
    {
        public string AdminOperation1() 
        {
            return "IAdmin.AdminOperation1() invoked.";
        }

        public string AdminOperation2() 
        {
            return "IAdmin.AdminOperation2() invoked.";
        }

        public string Operation1() 
        {
            return "IServiceA.Operation1() invoked.";
        }

        public string Operation2() 
        {
            return "IServiceA.Operation2() invoked.";
        }     
    }
}

