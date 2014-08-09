using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace ContentTypes
{
    [DataContract(Namespace = "http://schemas.thatindigogirl.com/samples/2006/06")]
    public class MP3Link :LinkItem
    {
        public MP3Link() 
        {
            Category = LinkItemCategories.MP3;
        }
    }
}
