using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using System.Web.Http.ValueProviders;
using System.Web.Http.ValueProviders.Providers;

namespace DeepIn.Common
{
    public class StaticValueProviderFactory :ValueProviderFactory
    {
        private static List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();

        public override IValueProvider GetValueProvider(HttpActionContext actionContext)
        {
            //throw new NotImplementedException();
            return new NameValuePairsValueProvider(values,CultureInfo.InvariantCulture);
        }

        public static void Clear() 
        {
            values.Clear();
        }

        public static void Add(string name, string value) 
        {
            values.Add(new KeyValuePair<string,string>(name,value));
        }
    }
}
