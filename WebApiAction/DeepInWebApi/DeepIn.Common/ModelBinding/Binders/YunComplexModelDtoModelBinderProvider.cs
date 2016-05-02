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

namespace DeepIn.Common
{
    public class YunComplexModelDtoModelBinderProvider :ModelBinderProvider
    {
        public override IModelBinder GetBinder(HttpConfiguration configuration, Type modelType)
        {
            //throw new NotImplementedException();
            return new YunComplexModelDtoModelBinder();
        }
    }
}
