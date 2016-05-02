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
    public class YunCollectionModelBinder <TElement> :IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext) 
        {
            if (!bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName)) 
            {
                return false;
            }
            ValueProviderResult result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            List<TElement> list= null!=result?this.BindSimpleCollection(actionContext,bindingContext,result.RawValue,CultureInfo.InvariantCulture)
                :this.BindComplexCollection(actionContext,bindingContext);

            return this.CreateOrReplaceCollection(actionContext,bindingContext,list);

        }


        /// <summary>
        /// 绑定元素为简单类型的集合
        /// </summary>
        /// <param name="actionContext"></param>
        /// <param name="bindingContext"></param>
        /// <param name="rawValue"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        private List<TElement> BindSimpleCollection(HttpActionContext actionContext, ModelBindingContext bindingContext,
                                                    object rawValue,CultureInfo  culture) 
        {
            List<object> list1 = new List<object>();
            if (rawValue is string)
            {
                IEnumerable enumerable = rawValue as IEnumerable;
                if (null != enumerable)
                {
                    list1 = enumerable.Cast<object>().ToList();
                }
            }
            else 
            {
                list1 = new List<object>() { rawValue };
            }

            List<TElement> list2 = new List<TElement>();
            foreach (object obj in list1) 
            {
                ModelBindingContext subContext = new ModelBindingContext(bindingContext)
                {
                    ModelMetadata = actionContext.GetMetadataProvider().GetMetadataForType(null, typeof(TElement)),
                    ModelName = bindingContext.ModelName,
                    ValueProvider = new CompositeValueProvider() 
                    {
                        new ElementalValueProvider(bindingContext.ModelName,obj,culture),
                        bindingContext.ValueProvider
                    }
                };
                if (actionContext.Bind(subContext))
                {
                    list2.Add((TElement)subContext.Model);
                }
                else 
                {
                    list1.Add(null);
                }
            }
            return list2;
        }

        /// <summary>
        /// 绑定元素为复杂类型的集合
        /// </summary>
        /// <param name="actionContext"></param>
        /// <param name="bindingContext"></param>
        /// <returns></returns>
        public List<TElement> BindComplexCollection(HttpActionContext actionContext, ModelBindingContext bindingContext) 
        {
            
            //得到所有基于字符串的索引
            string key = ModelNameBuilder.CreateIndexModelName(bindingContext.ModelName,"index");
            ValueProviderResult result = bindingContext.ValueProvider.GetValue(key);

            IEnumerable<string> indexes;
            bool useZeroBaseIndexes = false;
            if (null == result)
            {
                indexes = this.GetZeroBasedIndexes();
                useZeroBaseIndexes = true;
            }
            else 
            {
                indexes = (IEnumerable<string>)result.ConvertTo(typeof(IEnumerable<string>));
            }

            //为每个索引创建ModelBindingContext,并实施Model绑定得到集合元素的值
            List<TElement> list = new List<TElement>();
            foreach (string index in indexes) 
            {
                ModelBindingContext subContext = new ModelBindingContext()
                {
                    ModelMetadata = actionContext.GetMetadataProvider().GetMetadataForType(null, typeof(TElement)),
                    ModelName = ModelNameBuilder.CreateIndexModelName(bindingContext.ModelName, index)
                };

                bool failed = true;
                if (actionContext.Bind(subContext)) 
                {
                    list.Add((TElement)subContext.Model);
                    failed = false;
                }

                //如果采用零基索引，并且绑定失败，直接返回已经成功绑定的列表
                if (failed && useZeroBaseIndexes) 
                {
                    return list;
                }
            }
            return list;
        }


        private IEnumerable<string> GetZeroBasedIndexes() 
        {
            int index = 0;
            while (true) 
            {
                yield return index.ToString(CultureInfo.InvariantCulture);
                index++;
            }
        }
        protected virtual bool CreateOrReplaceCollection(HttpActionContext actionContext, ModelBindingContext bindingContext,IList<TElement> lstElement) 
        {
            ICollection<TElement> model = bindingContext.Model as ICollection<TElement>;
            if (model == null || model.IsReadOnly) 
            {
                model = new List<TElement>();
                bindingContext.Model = model;
            }

            model.Clear();

            foreach (TElement local in lstElement) 
            {
                model.Add(local);
            }
            return true;
        }
    }
}
