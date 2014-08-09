
using System;
using System.ServiceModel;
using ContentTypes;

namespace GigManager
{
    [MessageContract]
    public class SaveGigRequest
    {
        private LinkItem m_linkItem;

        [MessageBodyMember]
        public LinkItem Item
        {
            get { return m_linkItem; }
            set { m_linkItem = value; }
        }
    }
    [MessageContract]
    public class SaveGigResponse 
    {
       
    }

    [MessageContract]
    public class GetGigRequest 
    {
        private string m_licenseKey;

        [MessageHeader]
        public string LicenseKey
        {
            get { return m_licenseKey; }
            set { m_licenseKey = value; }
        }
    }

    [MessageContract]
    public class GetGigResponse 
    {

        public GetGigResponse() 
        {

        }

        public GetGigResponse(LinkItem item) 
        {
            m_linkItem = item;
        }
        private LinkItem m_linkItem;
        
        [MessageBodyMember]
        public LinkItem Item 
        {
            get { return m_linkItem; }
            set { m_linkItem = value; }
        }
    }
}