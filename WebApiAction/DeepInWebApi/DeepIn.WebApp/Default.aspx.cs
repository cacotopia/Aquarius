#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using System.IO;

#endregion

namespace DeepIn.WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        public enum RouteOrRouteCollection 
        {
            Route,
            RouteCollection
        }

        public RouteData GetRouteData(RouteOrRouteCollection routeOrRouteCollection, bool routeExistingFile4Collection, bool routeExistingFile4Route) 
        {
            RouteValueDictionary defaults = new RouteValueDictionary() 
            {
                {"areacode","010"},
                {"days",2},
            };
            Route route = new Route("{areacode}/{days}",defaults,null);
            route.RouteExistingFiles = routeExistingFile4Route;
            HttpContextBase context = CreateHttpContext();

            if (routeOrRouteCollection == RouteOrRouteCollection.Route) 
            {
                return route.GetRouteData(context);
            }

            RouteCollection routes = new RouteCollection();
            routes.Add(route);
            routes.RouteExistingFiles = routeExistingFile4Collection;
            return routes.GetRouteData(context);
        }

        private static HttpContextBase CreateHttpContext() 
        {
            HttpRequest request = new HttpRequest("~/Weather.aspx", "http://localhost:40022/Weather.aspx", null);
            HttpResponse response = new HttpResponse(new StringWriter());

            HttpContext context = new HttpContext(request,response);

            HttpContextBase contextWrapper = new HttpContextWrapper(context);

            return contextWrapper;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}