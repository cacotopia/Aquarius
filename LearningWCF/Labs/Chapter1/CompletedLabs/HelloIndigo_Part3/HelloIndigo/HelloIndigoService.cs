// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace HelloIndigo
{
    [ServiceContract(Namespace="http://www.thatindigogirl.com/samples/2006/06")]
    public interface IHelloIndigoService
    {
        [OperationContract]
        string HelloIndigo();
    }
   
    public class HelloIndigoService: IHelloIndigoService
    {
        #region IHelloIndigoService Members

        public string HelloIndigo()
        {
            return "Hello Indigo";
        }

        #endregion
    }


}
