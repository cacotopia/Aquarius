#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

#endregion

namespace DeepInWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
            //Enable Attribute Route
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v10/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //Routing by Action Name
            //config.Routes.MapHttpRoute(
            //    name: "ActionMap",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id= RouteParameter.Optional}
            //    );
            //
            //config.Routes.MapHttpRoute(
            //    name:"",
            //    routeTemplate:"",
            //    defaults:"",
            //    constraints:""
            //    );

            //config.DependencyResolver
            //config.Filters
            //config.Formatters
            //config.IncludeErrorDetailPolicy
            //config.Initializer
            //config.MessageHandlers
            //config.ParameterBindingRules
            //config.Properties
            //config.Routes
            //config.Services
            //config.VirtualPathRoot
            //config.BindParameter
        }
    }
}
