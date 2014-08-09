// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using PhotoManager;

namespace PhotoManagerService
{

    public class PhotoManagerService: IPhotoUpload
    {

        public void UploadPhoto(ContentTypes.PhotoLink fileInfo, byte[] fileData)
        {
            PhotoUploadUtil photoUploadUtil = new PhotoUploadUtil();
            photoUploadUtil.SavePhoto(fileInfo, fileData);

        }


    }
}
