// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
   
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ContentTypes;

public partial class Admin_UploadPhotos : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void cmdUploadPhoto_Click(object sender, EventArgs e)
    {
        // anything to do?
		if (this.fileUpload.PostedFile.FileName == "") return;

        string filename = System.IO.Path.GetFileName(this.fileUpload.PostedFile.FileName);
        byte[] fileData = this.fileUpload.FileBytes;

        PhotoLink fileInfo = new PhotoLink();
        fileInfo.Title = this.txtTitle.Text;
        fileInfo.Url = filename;
        fileInfo.Description = this.txtDescription.Text;
		fileInfo.DateStart= this.dateSelector.SelectedDate;
        fileInfo.DateEnd = null;
		fileInfo.LinkItemType = LinkItemTypes.Image;
        fileInfo.Category=txtCategory.Text;
        
        PhotoManager.PhotoUploadUtil photoUploadUtil = new PhotoManager.PhotoUploadUtil();
        photoUploadUtil.SavePhoto(fileInfo, fileData);
    }
   
    protected void lstCategories_DataBound(object sender, EventArgs e)
    {
        this.lstCategories.Items.Insert(0, new ListItem("[New Category]"));
    }
}
