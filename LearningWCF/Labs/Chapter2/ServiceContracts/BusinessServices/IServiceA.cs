// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.ServiceModel;

namespace BusinessServiceContracts
{

    [ServiceContract]
    public interface IServiceA
    {
        [OperationContract]
        string Operation1();
        [OperationContract]
        string Operation2();
    }


}

