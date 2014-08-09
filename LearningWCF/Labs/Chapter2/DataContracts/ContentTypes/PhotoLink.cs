using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace ContentTypes
{
    [DataContract(Namespace = "http://schemas.thatindigogirl.com/samples/2006/06")]
    public class PhotoLink :LinkItem
    {
        public PhotoLink() 
        {
            Category = LinkItemCategories.Photos;
        }
    }
}
