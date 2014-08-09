using System;
using System.Collections.Generic;
using System.ServiceModel;

/*
 * 用于客户端的服务契约元数据
 */

namespace Server.Client
{
    [ServiceContract(Namespace = "http://www.cacotopia.com/sample/2014/07")]
    public interface IHelloIndigoService
    {
        [OperationContract]
        string HelloIndigo();
    }

    [ServiceContract(Name = "GoodbyeIndigoService", Namespace = "http://www.cacotopia.com/sample/2014/07")]
    public interface IGoodbyeIndigoService
    {
        [OperationContract]
        string GoodbyeIndigo();
    }
}