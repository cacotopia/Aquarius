#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

#endregion

namespace DeepIn.WebApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //S202注册路由映射
            RouteValueDictionary defaults = new RouteValueDictionary()
            {
                {"areacode","010"},
                {"days",2}
            };
            RouteValueDictionary dataTokens = new RouteValueDictionary()
            {
                {"defaultCity","Hangzhou"},
                {"defaultDays",2}
            };

            RouteValueDictionary constraints = new RouteValueDictionary() 
            {
                {"areacode",@"0\d{2,3}"},
                {"days",@"[1-3]"},
                //{"httpMethos",new HttpMethodConstraint("POST")}
            };

            /* 
            
            
            //路由注册方式1
            RouteTable.Routes.MapPageRoute("default", "{areacode}/{days}", "~/Weather.aspx", false, defaults, constraints, dataTokens);
            
            //路由注册方式2
            Route route = new Route("{areacode}/{days}",defaults,constraints,dataTokens,new PageRouteHandler("~/Weather.aspx"),false);
            RouteTable.Routes.Add("default",route);            
            */

            //S203对现有物理文件的路由
            //RouteTable.Routes.RouteExistingFiles = true; //对现有文件实施路由
            //RouteTable.Routes.MapPageRoute("default","{areacode}/{days}","~/Weather.aspx",false,defaults,null,dataTokens);

            //S208 注册路由忽略地址
            RouteTable.Routes.RouteExistingFiles = true;
            RouteTable.Routes.Ignore("Css/{filename}.css/{*pathInfo}");

            RouteTable.Routes.MapPageRoute("default", "{areacode}/{days}", "~/Weather.aspx", false, defaults, constraints, dataTokens);
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