#region "Imports"

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using System.Web.Http.ValueProviders;

#endregion

namespace DeepIn.Common
{

    public class YunComplexModelDtoModelBinder :IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext) 
        {
            ComplexModelDto dto = bindingContext.Model as ComplexModelDto;
            if (null == dto)
            {
                return false;
            }
            foreach (ModelMetadata property in dto.PropertyMetadata) 
            {
                ModelBindingContext subContext = new ModelBindingContext()
                {
                    ModelMetadata = property,
                    ModelName = ModelNameBuilder.CreatePropertyModelName(bindingContext.ModelName,property.PropertyName)                    
                };
                if (actionContext.Bind(subContext)) 
                {
                    dto.Results[property] = new ComplexModelDtoResult(subContext.Model,subContext.ValidationNode);
                }
            }
            return true;
        }
    }
}
