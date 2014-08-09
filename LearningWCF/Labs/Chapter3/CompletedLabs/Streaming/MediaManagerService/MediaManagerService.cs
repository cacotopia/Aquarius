// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ServiceModel;
using System.Reflection;

namespace MediaManagerService
{
    public class MediaManagerService: IMediaManagerService, IMediaStreaming
    {

        #region IMediaManagerService Members

        string[] IMediaManagerService.GetMediaList()
        {
            string[] mediaList = new string[3];
            mediaList[0] = "moviestar.wav";
            mediaList[1] = "amsterdam.wav";
            mediaList[2] = "thejimihendrixtheory.wav";
            return mediaList;
        }

        #endregion

        #region IMediaStreaming Members

        Stream IMediaStreaming.GetMediaStream(string media)
        {
            string mediaFile = String.Format("{0}\\{1}", System.Configuration.ConfigurationManager.AppSettings["mediaPath"], media);

            FileInfo fi = new FileInfo(mediaFile);

            if (!fi.Exists)
                throw new FileNotFoundException("File does not exist: {0}. Check host configuration for 'mediaPath' setting.", media);

            FileStream fs = null;
            try
            {
                fs = new FileStream(mediaFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch
            {
                if (fs != null)
                    fs.Close();
            }

            return fs;        
        }

        #endregion
    }
}
