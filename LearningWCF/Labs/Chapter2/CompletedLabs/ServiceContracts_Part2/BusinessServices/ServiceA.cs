// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.ServiceModel;
using BusinessServiceContracts;

namespace BusinessServices
{

    public class ServiceA : IServiceA
    {

        #region IServiceA Members

        string IServiceA.Operation1(DateTime dt)
        {
            return string.Format("IServiceA.Operation1() invoked at {0}.", dt);
        }

        string IServiceA.Operation2()
        {
            return "IServiceA.Operation2() invoked.";
        }

        string IServiceA.NewOperation(string s)
        {
            return string.Format("IServiceA.NewOperation() invoked with {0}", s);

        }

        #endregion



    }

}

