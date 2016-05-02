#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

#endregion

namespace DeepIn.WebApp
{
    public partial class Weather : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //根据路由规则生成URL
            RouteData routeData = new RouteData();
            routeData.Values.Add("areacode","0512");
            routeData.Values.Add("days","1");

            RequestContext requestContext = new RequestContext();
            requestContext.HttpContext = new HttpContextWrapper(HttpContext.Current);
            requestContext.RouteData = routeData;

            RouteValueDictionary values = new RouteValueDictionary();
            values.Add("areacode","028");
            values.Add("days","3");

            Response.Write(RouteTable.Routes.GetVirtualPath(null,null).VirtualPath + "<br />");

            Response.Write(RouteTable.Routes.GetVirtualPath(requestContext,null).VirtualPath +"<br />");

            Response.Write(RouteTable.Routes.GetVirtualPath(requestContext,values).VirtualPath + "<br />");
        }
    }
}