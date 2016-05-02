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
    public class YunArrayModelBinder<TElement> :YunCollectionModelBinder<TElement>
    {
        protected override bool CreateOrReplaceCollection(HttpActionContext actionContext, ModelBindingContext bindingContext, IList<TElement> lstElement)
        {
            //return base.CreateOrReplaceCollection(actionContext, bindingContext, lstElement);
            bindingContext.Model = lstElement.ToArray();
            return true;
        }
    }
}
