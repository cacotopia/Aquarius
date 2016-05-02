#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using DeepIn.DataModel;
using System.Web.Http.Routing;
using System.Net.Http;

#endregion

namespace DeepIn.Controller
{
    /// <summary>
    /// 
    /// </summary>
    public class DemosController :ApiController
    {
        public IEnumerable<UriResolutionResult> Get() 
        {
            string routeTemplate = "movies/{genre}/{title}/{id}";
            IHttpRoute route = new HttpRoute(routeTemplate);

            var constraints = new HttpMethodConstraint(HttpMethod.Post);
            route.Constraints.Add("httpMethod",constraints);

            string requestUrl = "http://localhost:3513/api/movies/romance/titanic/001";

            var request1 = new HttpRequestMessage(HttpMethod.Get, requestUrl);

            var request2 = new HttpRequestMessage(HttpMethod.Post, requestUrl);

            string root1 = "/";
            string root2 = "/api/";

            IHttpRouteData routeData1 = route.GetRouteData(root1,request1);
            IHttpRouteData routeData2 = route.GetRouteData(root1,request2);

            IHttpRouteData routeData3 = route.GetRouteData(root2,request1);
            IHttpRouteData routeData4 = route.GetRouteData(root2,request2);

            yield return new UriResolutionResult(root1,"GET",routeData1!=null);
            yield return new UriResolutionResult(root1,"POST",routeData2!=null);
            yield return new UriResolutionResult(root2,"GET",routeData3!=null);
            yield return new UriResolutionResult(root2,"POST",routeData4!=null);

        }
        
        public IEnumerable<string> Get(int id) 
        {
            string routeTemplate = "weather/{areacode}/{days}";
            IHttpRoute route = new HttpRoute(routeTemplate);
            route.Defaults.Add("days",2);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,"/");
            IHttpVirtualPathData pathData;

            //1.不能提供路由变量areacode
            Dictionary<string, object> values = new Dictionary<string, object>();
            pathData = route.GetVirtualPath(request,values);
            yield return pathData == null ? "N/A" : pathData.VirtualPath;

            //2.values无Key为httproute的元素
            values.Add("areacode","028");
            pathData = route.GetVirtualPath(request,values);
            yield return pathData ==null? "N/A":pathData.VirtualPath;

            //3.所有的路由变量值通过values提供
            values.Add("httproute",true);
            values.Add("days",3);
            IHttpRouteData routeData = new HttpRouteData(route);
            routeData.Values.Add("areacode","0512");
            routeData.Values.Add("days",4);
            request.SetRouteData(routeData);
            pathData = route.GetVirtualPath(request,values);
            yield return pathData == null ? "N/A" : pathData.VirtualPath;

            //4.所有的路由变量值通过request提供
            values.Clear();
            values.Add("httproute",true);
            pathData = route.GetVirtualPath(request,values);
            yield return pathData == null ? "N/A" : pathData.VirtualPath;

            //5.采用定义在HttpRoute上的默认值(days=2)
            routeData.Values.Remove("days");
            pathData = route.GetVirtualPath(request, values);
            yield return pathData == null ? "N/A" : pathData.VirtualPath;

        }

        public class UriResolutionResult 
        {
            public string VirtualPathRoot { get; set; }

            public string Method { get; set; }

            public bool Matched { get; set; }

            public UriResolutionResult()
            {
            }
            public UriResolutionResult(string virtualPathData, string method, bool matched) 
            {
                VirtualPathRoot = virtualPathData;
                Method = method;
                Matched = matched;
            }
        }
    }
}
