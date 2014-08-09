// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace ContentTypes
{
    
   [DataContract(Namespace="http://schemas.thatindigogirl.com/samples/2006/06")]
    public class LinkItem
    {

        [DataMember(Name = "Id", IsRequired = false, Order = 0)]
        private long m_id;
        [DataMember(Name = "Title", IsRequired = true, Order = 1)]
        private string m_title;
        [DataMember(Name = "Description", IsRequired = true, Order = 2)]
        private string m_description;
        [DataMember(Name = "DateStart", IsRequired = true, Order = 3)]
        private DateTime m_dateStart;
        [DataMember(Name = "DateEnd", IsRequired = false, Order = 4)]
        private DateTime m_dateEnd;
        [DataMember(Name = "Url", IsRequired = false, Order = 5)]
        private string m_url;

        public DateTime DateStart
        {
            get { return m_dateStart; }
            set { m_dateStart = value; }
        } 

        public DateTime DateEnd
        {
            get { return m_dateEnd; }
            set { m_dateEnd = value; }
        }
       
        public string Url
        {
            get { return m_url; }
            set { m_url = value; }
        }
        
        public long Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public string Title
        {
            get { return m_title; }
            set { m_title = value; }
        }

        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }
    }
}
