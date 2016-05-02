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

namespace DeepIn.Common
{
    public class YunMutableObjectModelBinderProvider :ModelBinderProvider
    {
        public override IModelBinder GetBinder(HttpConfiguration configuration, Type modelType)
        {
            //throw new NotImplementedException();
            if (YunMutableObjectModelBinder.CanBindType(modelType)) 
            {
                return new YunMutableObjectModelBinder();
            }
            return null;
        }
    }
}
