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
using System.ComponentModel;
using System.Web.Http.Metadata;
using System.Reflection;

namespace DeepIn.Common
{
    public class YunMutableObjectModelBinder :IModelBinder
    {
        internal static bool CanBindType(Type modelType) 
        {
            if (TypeDescriptor.GetConverter(modelType).CanConvertFrom(typeof(string))) 
            {
                return false;
            }
            if (modelType == typeof(ComplexModelDto)) 
            {
                return false;
            }
            return true;
        }

        public bool BindModel(HttpActionContext actionContext,ModelBindingContext bindingContext)
        {
            if(!CanBindType(bindingContext.ModelType))
            {
                return false;
            }
            if(!bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName))
            {
                return false;
            }
            //创建针对目标类型的空对象
            bindingContext.Model = Activator.CreateInstance(bindingContext.ModelType);
            //创建针对目标类型的ComplexModelDto
            //创建ModelBindingContext，并将ComplexModelDto作为Model驱动新一轮的Model绑定
            ComplexModelDto dto = new ComplexModelDto(bindingContext.ModelMetadata,bindingContext.PropertyMetadata.Values);

            ModelBindingContext subContext = new ModelBindingContext(bindingContext)
            {
                ModelMetadata = actionContext.GetMetadataProvider()
                                             .GetMetadataForType(()=> dto,typeof(ComplexModelDto)),ModelName = bindingContext.ModelName
            };
            actionContext.Bind(subContext);

            //从ComplexModelDto获取相应的值并为相应的的属性赋值
            foreach(KeyValuePair<ModelMetadata,ComplexModelDtoResult> item in dto.Results)
            {
                ModelMetadata propertyMetadata = item.Key;
                ComplexModelDtoResult dtoResult = item.Value;
                if(null!= dtoResult)
                {
                    PropertyInfo  propertyInfo = bindingContext.ModelType.GetProperty(propertyMetadata.PropertyName);

                    if(propertyInfo.CanWrite)
                    {
                        propertyInfo.SetValue(bindingContext.Model,dtoResult.Model);
                    }
                }
            }
            return true;          
         }
    }
}
