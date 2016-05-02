using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace DeepIn.DataModel
{
    [ModelBinder]
    [DataContract(Namespace="http://www.sinotopia.net")]
    public class DemoModel
    {
        [DataMember]
        public int X { get; set; }

        [DataMember]
        public int Y { get; set; }

        [DataMember]
        public int Z { get; set; }
    }
}
