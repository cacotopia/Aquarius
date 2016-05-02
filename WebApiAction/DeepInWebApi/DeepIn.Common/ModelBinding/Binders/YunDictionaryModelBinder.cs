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
    public class YunDictionaryModelBinder<TKey,TValue> :YunCollectionModelBinder<KeyValuePair<TKey,TValue>>
    {

        protected override bool CreateOrReplaceCollection(HttpActionContext actionContext, ModelBindingContext bindingContext, IList<KeyValuePair<TKey, TValue>> lstElement)
        {
            //return base.CreateOrReplaceCollection(actionContext, bindingContext, lstElement);
            IDictionary<TKey, TValue> model = bindingContext.Model as IDictionary<TKey, TValue>;
            if (model == null || model.IsReadOnly) 
            {
                model = new Dictionary<TKey, TValue>();
                bindingContext.Model = model;
            }
            model.Clear();
            foreach (KeyValuePair<TKey, TValue> pair in lstElement) 
            {
                model[pair.Key] = pair.Value;
            }
            return true;
        }
    }
}
