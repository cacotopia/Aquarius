// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using BusinessServiceContracts;

namespace BusinessServices
{

    public class ServiceA: IServiceA, IAdmin
    {
        string IServiceA.Operation1()
        {
            return "IServiceA.Operation1() invoked.";
        }
        string IServiceA.Operation2()
        {
            return "IServiceA.Operation2() invoked.";
        }
        string IAdmin.AdminOperation1()
        {
            return "IAdmin.AdminOperation1 invoked.";
        }
        string IAdmin.AdminOperation2()
        {
            return "IAdmin.AdminOperation2 invoked.";
        }

     
    }

}

