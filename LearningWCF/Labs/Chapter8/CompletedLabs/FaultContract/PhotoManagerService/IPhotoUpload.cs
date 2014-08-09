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
using ContentTypes;
using System.Configuration;

namespace PhotoManagerService
{
    [ServiceContract(Name="PhotoUploadContract", Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IPhotoUpload
    {
        [OperationContract]
        [FaultContract(typeof(ConfigurationErrorsException))]
        void UploadPhoto(PhotoLink fileInfo, byte[] fileData); 
    }


}
