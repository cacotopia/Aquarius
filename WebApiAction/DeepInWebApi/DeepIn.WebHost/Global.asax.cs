#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Net.Http.Headers;
using System.Web.Http.ModelBinding;
using DeepIn.Common;

#endregion

namespace DeepIn.WebHost
{

    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            
            //支持特性路由
            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();

            //添加Json消息支持
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                name : "DefaultApi",
                //Version 1.0
                routeTemplate : "api/v10/{controller}/{id}",
                defaults: new { id= RouteParameter.Optional}
                );
            GlobalConfiguration.Configuration.EnsureInitialized();

            //自定义简单类型的模型绑定S801
            GlobalConfiguration.Configuration.Services.ReplaceRange(typeof(ModelBinderProvider), new ModelBinderProvider[] 
            {
                new  YunTypeConvertModelBinderProvider()
            });

            /*
            foreach (var item in GlobalConfiguration.Configuration.Formatters)
            {
                Console.WriteLine(item.GetType().ToString());

                foreach (var subitem in item.MediaTypeMappings) 
                {
                    Console.WriteLine(subitem.MediaType.MediaType);
                }

                foreach (var subitem in item.SupportedEncodings) 
                {
                    Console.WriteLine(subitem.EncodingName);
                }

                foreach (var subitem in item.SupportedMediaTypes) 
                {
                    Console.WriteLine(subitem.MediaType);
                }
            }
             */

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}