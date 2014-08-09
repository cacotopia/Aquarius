using System;
using System.Collections.Generic;
using System.ServiceModel;

/*
 * 服务契约定义，采用服务接口和服务类型定义
 */ 

namespace Server.Indigo
{
    [ServiceContract(Namespace ="http://www.cacotopia.com/sample/2014/07")]
    public interface IHelloIndigoService 
    {
        [OperationContract]
        string HelloIndigo();
    }

    public class HelloIndigoService : IHelloIndigoService
    {
        public string HelloIndigo() 
        {
            return "Hello,Indigo!";
        }
    }

    /*
     *采用服务类型定义服务契约
     */
    [ServiceContract(Namespace = "http://www.cacotopia.com/sample/2014/07")]
    public class GoodbyeIndigoService 
    {
        [OperationContract]
        public string GoodbyeIndigo() 
        {
            return "Goodbye,Indigo!";
        }
    }

}