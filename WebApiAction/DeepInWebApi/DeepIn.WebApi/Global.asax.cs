#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

#endregion

namespace DeepInWebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //GlobalConfiguration.DefaultServer;
            //GlobalConfiguration.DefaultHandler;
            AreaRegistration.RegisterAllAreas();
        }
    }
}
