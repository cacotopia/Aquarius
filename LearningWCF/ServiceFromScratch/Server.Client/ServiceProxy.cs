using System;
using System.Collections.Generic;
using System.ServiceModel;

/*
 * ���ڿͻ��˵ķ�����ԼԪ����
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