// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using ContentTypes;
using System.Collections.Generic;
using System.ServiceModel;

public class PhotoManagerFacade
{
    public List<PhotoLink> GetPhotos()
    {
        List<PhotoLink> photos = null;
        using (PhotoManagerContractClient proxy = new PhotoManagerContractClient())
        {
            photos = proxy.GetPhotos();
        }
        return photos;
    }

    public PhotoLink GetPhoto(int id)
    {
        PhotoLink photo = null;

        using (PhotoManagerContractClient proxy = new PhotoManagerContractClient())
        {
            photo = proxy.GetPhoto(id);
        }
        return photo;

    }

    public void UploadPhoto(PhotoLink fileInfo, byte[] fileData)
    {
        using (PhotoUploadContractClient proxy = new PhotoUploadContractClient())
        {
            proxy.UploadPhoto(fileInfo, fileData);
        }
    }


    public List<string> GetCategories()
    {
        List<string> categories = null;

        using (PhotoManagerContractClient proxy = new PhotoManagerContractClient())
        {
            categories = proxy.GetCategories();
        }
        return categories;
    }

}
