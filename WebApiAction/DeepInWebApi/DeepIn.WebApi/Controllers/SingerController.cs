#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeepInWebApi.Models;

#endregion

namespace DeepInWebApi.Controllers
{
    public class SingerController : ApiController
    {
        Singer[] singers = new Singer[]
        {
        };

        [HttpGet]
        //[AcceptVerbs("GET","HEAD")]
        public Singer FindSinger(int singerId) 
        {
            Singer singer = singers.FirstOrDefault<Singer>(p => p.Id == singerId);
            if (singerId == null)
                return null;
            return singer;
        }

        //WebDAV Method
        [AcceptVerbs("MKCOL")]
        public void MakeCollection() 
        {

        }

        [HttpGet]
        [ActionName("Thumbnail")]
        public HttpResponseMessage GetThumbnailImage(int singerId) 
        {
            return null;
        }

        [HttpPost]
        [ActionName("Thumbail")]
        public void AddThumbnailImage(int singerid) 
        {

        }

        [NonAction]
        public string GetPrivateData() 
        {
            return "";
        }
    }
}
