// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.IO;

namespace MediaManagerService
{
    [ServiceContract(Name="MediaStreamingContract", Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IMediaStreaming
    {
        [OperationContract]
        Stream GetMediaStream(string media);
    }

    
    
}
