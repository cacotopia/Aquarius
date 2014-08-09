// ?2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Runtime.Serialization;

[assembly:ContractNamespace("http://schemas.thatindigogirl.com/samples/2006/06",ClrNamespace="ContentTypes")] //(映射CLR命名空间到模式命名空间)
namespace ContentTypes
{
    [DataContract(Namespace="http://schemas.thatindigogirl.com/sample/2006/06")]
    [KnownType(typeof(GigInfo))]
    [KnownType(typeof(PhotoLink))]
    [KnownType(typeof(MP3Link))]
    public class LinkItem :IExtensibleDataObject
    {
        [DataMember(Name="Id",IsRequired=true,Order = 0)]
        private long m_id;
        [DataMember(Name="Title",IsRequired = true,Order=1)]
        private string m_title;
        [DataMember(Name="Description",IsRequired = false,Order = 2)]
        private string m_description;
        [DataMember(Name= "DateStart",IsRequired = false,Order=3)]
        private DateTime m_dateStart;
        [DataMember(Name="DateEnd",IsRequired = false,Order= 4)]
        private DateTime m_dateEnd;
        [DataMember(Name="URI",IsRequired = false,Order = 5)]
        private string m_url;
        [DataMember(Name = "Category", IsRequired = false, Order = 6)]
        private LinkItemCategories m_linkItemCategory;

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

        public LinkItemCategories Category 
        {
            get { return m_linkItemCategory; }
            set { m_linkItemCategory = value; }
        }
        #region "IExtensibleDataObject Members"

        private ExtensionDataObject m_extensionDataObject;

        public ExtensionDataObject ExtensionData 
        {
            get {return m_extensionDataObject;}
            set {m_extensionDataObject = ValueType;}
        }
        #endregion 
    }

    [CollectionDataContract(Namespace ="http://schemas.thatindigogirl.com/samples/2006/06")]
    public class ListItemCollection : List<LinkItem> 
    {

    }
}
