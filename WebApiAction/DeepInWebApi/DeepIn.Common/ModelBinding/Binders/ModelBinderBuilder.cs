using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
using System.Web.Http.ValueProviders.Providers;

namespace DeepIn.Common
{
    internal static class ModelBinderBuilder
    {
        public static IModelBinder CreateGenericModelBinder(Type modelType, Type modelTypeDefinition, Type modelBinderTypeDefinition) 
        {
            if (!modelType.IsGenericType || modelType.IsGenericTypeDefinition) 
            {
                return null;
            }
            //确保泛型参数个数一致
            Type[] genericArguments = modelType.GetGenericArguments();
            if (genericArguments.Length != modelBinderTypeDefinition.GetGenericArguments().Length) 
            {
                return null;
            }

            //确保类型兼容性
            Type modelRealType = modelTypeDefinition.MakeGenericType(genericArguments);

            if (modelType.IsAssignableFrom(modelRealType)) 
            {
                Type modelBinderType = modelBinderTypeDefinition.MakeGenericType(genericArguments);

                return Activator.CreateInstance(modelBinderType) as IModelBinder;
            }
            return null;
        }
    }
}
