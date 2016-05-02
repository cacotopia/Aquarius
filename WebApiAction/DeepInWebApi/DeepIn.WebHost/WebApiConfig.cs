using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using System.Web.Http.ValueProviders;
using System.Web.Http.ValueProviders.Providers;
using DeepIn.Common;

namespace DeepIn.WebHost
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
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));        
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v10/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnsureInitialized();

            //自定义简单类型的模型绑定S801
            config.Services.ReplaceRange(typeof(ModelBinderProvider), new ModelBinderProvider[] 
            {
                new  YunTypeConvertModelBinderProvider()
            });

            //自定义复杂类型的模型绑定S802
            config.Services.ReplaceRange(typeof(ModelBinderProvider), new ModelBinderProvider[] 
            {
                new YunTypeConvertModelBinderProvider(),
                new YunKeyValuePairModelBinderProvider(),
                new YunComplexModelDtoModelBinderProvider(),
                new YunCollectionModelBinderProvider(),
                new YunDictionaryModelBinderProvider(),
                new YunMutableObjectModelBinderProvider()
            });

            config.Services.ReplaceRange(typeof(ValueProviderFactory),new ValueProviderFactory[]
            {
                new StaticValueProviderFactory()
            });
        }
    }
}