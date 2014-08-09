// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace ContentTypes
{
    [DataContract(Namespace = "http://schemas.thatindigogirl.com/samples/2006/06")]
    public class GigInfo: LinkItem
    {
        public GigInfo()
        {
            this.Category = LinkItemCategories.Gig;
        }
    }
}
