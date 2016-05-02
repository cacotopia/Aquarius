using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using System.Web.Http.ValueProviders;

namespace DeepIn.Common
{
    public class YunTypeConvertModelBinder :IModelBinder
    {

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext) 
        {
            ValueProviderResult result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (null == result) 
            {
                return false;
            }
            try
            {
                bindingContext.Model = result.ConvertTo(bindingContext.ModelType);
                if (bindingContext.Model is string &&
                    string.IsNullOrWhiteSpace((string)bindingContext.Model) && bindingContext.ModelMetadata.ConvertEmptyStringToNull) 
                {
                    bindingContext.Model = null;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }
    }
}
