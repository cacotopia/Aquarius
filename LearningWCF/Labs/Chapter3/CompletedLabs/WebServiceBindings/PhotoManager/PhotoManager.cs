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
using LinkItems.Dalc;
using ContentTypes;
using System.Transactions;
using FileManager;

namespace PhotoManager
{
    public class PhotoUploadUtil
    {
         public void SavePhoto(PhotoLink fileInfo, byte[] fileData)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                FileUploadUtil uploadUtil = new FileUploadUtil();
                uploadUtil.SaveFile(fileInfo.Url, fileData);

                LinkItems.Dalc.LinkItemsDataAccess dalc = new LinkItemsDataAccess();
                dalc.InsertLinkItem(fileInfo.Title, fileInfo.Description, fileInfo.Url, LinkItemTypes.Image, DateTime.Now, null, fileInfo.Category);

                scope.Complete();
            }
        }
    }
}

