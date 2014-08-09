using System;
using System.Collections.Generic;
using System.Text;
using ContentTypes;
using System.ServiceModel;

namespace PhotoManagerService
{
    [ServiceContract(Name="PhotoManagerContract", Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IPhotoManagerService
    {
        [OperationContract]
        List<PhotoLink> GetPhotos(); 
        
        [OperationContract]
        PhotoLink GetPhoto(int id); 

        [OperationContract]
        List<string> GetCategories(); 

    }
}
