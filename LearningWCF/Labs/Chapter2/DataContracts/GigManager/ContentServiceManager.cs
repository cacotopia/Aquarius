using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using ContentTypes;

namespace GigManager
{
    
    public  class ContentServiceManager
    {

    }

    [ServiceContract(Name="ContentServiceManagerContract",Namespace="http://schemas.thatindigogirl.com/samples/2006/06",SecurityMode= SessionMode.Required)]
    [ServiceKnownType(typeof(ContentTypes.GigInfo))]
    [ServiceKnownType(typeof(ContentTypes.MP3Link))]
    [ServiceKnownType(typeof(ContentTypes.PhotoLink))]
    public interface IContentServiceManager 
    {
        [OperationContract]
        void SaveGig(LinkItem item);
        [OperationContract]
        LinkItem GetGig();
    }
}
