﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
using System.Web.Http.ValueProviders.Providers;

namespace DeepIn.Common
{
   public  class YunArrayModelBinderProvider :ModelBinderProvider
   {
       public override IModelBinder GetBinder(HttpConfiguration configuration, Type modelType)
       {
           //throw new NotImplementedException();
           if (!modelType.IsArray) 
           {
               return null;
           }
           Type elementType = modelType.GetElementType();
           return (IModelBinder)Activator.CreateInstance(typeof(YunArrayModelBinder<>).MakeGenericType(new Type[] { elementType }));
       }
    }
}
