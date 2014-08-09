// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using PhotoManager;
using System.Configuration;
using System.IO;
using System.ServiceModel;

namespace PhotoManagerService
{

    public class PhotoManagerService: IPhotoUpload, IPhotoManagerService
    {

        public void UploadPhoto(ContentTypes.PhotoLink fileInfo, byte[] fileData)
        {

            try
            {
                PhotoUploadUtil photoUploadUtil = new PhotoUploadUtil();
                photoUploadUtil.SavePhoto(fileInfo, fileData);

            }
            catch (ConfigurationErrorsException exConfig)
            {
                //throw new FaultException(exConfig.Message);
                throw new FaultException<ConfigurationErrorsException>(new ConfigurationErrorsException(exConfig.Message), new FaultReason(exConfig.Message), FaultCode.CreateReceiverFaultCode(new FaultCode("ConfigurationErrorsException")));
            }
     
        }

        
        #region IPhotoManagerService Members

        public List<ContentTypes.PhotoLink> GetPhotos()
        {
            PhotoUploadUtil photoUploadUtil = new PhotoUploadUtil();
            return photoUploadUtil.GetPhotos();
        }

        public ContentTypes.PhotoLink GetPhoto(int id)
        {
            PhotoUploadUtil photoUploadUtil = new PhotoUploadUtil();
            return photoUploadUtil.GetPhoto(id);

        }


        public List<string> GetCategories()
        {
            PhotoUploadUtil photoUploadUtil = new PhotoUploadUtil();
            return photoUploadUtil.GetCategories();

        }

        #endregion
    }
}
