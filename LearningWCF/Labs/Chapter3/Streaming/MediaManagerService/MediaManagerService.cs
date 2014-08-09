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

        public string[] GetMediaList()
        {
            string[] mediaList = new string[3];
            mediaList[0] = "moviestar.wav";
            mediaList[1] = "amsterdam.wav";
            mediaList[2] = "thejimihendrixtheory.wav";
            return mediaList;
        }


    }
}
