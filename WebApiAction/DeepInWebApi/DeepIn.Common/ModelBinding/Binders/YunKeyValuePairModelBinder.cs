using System;
using System.Collections;
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
    public class YunKeyValuePairModelBinder<TKey,TValue> :IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext) 
        {
            ModelBindingContext context4Key = new ModelBindingContext() 
            {
                ModelMetadata = actionContext.GetMetadataProvider().GetMetadataForType(null,typeof(TKey)),
                ModelName = ModelNameBuilder.CreatePropertyModelName(bindingContext.ModelName,"key")
            };

            if (actionContext.Bind(context4Key)) 
            {
                TKey key = (TKey)context4Key.Model;
                ModelBindingContext context4Value = new ModelBindingContext(bindingContext)
                {
                    ModelMetadata = actionContext.GetMetadataProvider().GetMetadataForType(null,typeof(TValue)),
                    ModelName = ModelNameBuilder.CreatePropertyModelName(bindingContext.ModelName,"value")
                };
                if(actionContext.Bind(context4Value))
                {
                    TValue value = (TValue)context4Value.Model;
                    bindingContext.Model = new KeyValuePair<TKey, TValue>(key,value);
                    return true;
                }
            }
            return false;
        }
    }
}
