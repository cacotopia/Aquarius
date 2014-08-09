// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using ContentTypes;

namespace GigManager
{
    //[MessageContract]
    //[MessageContract(IsWrapped=true, WrapperName="SaveGig")]
    [MessageContract(IsWrapped = false)]
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

    //[MessageContract]
    [MessageContract(IsWrapped = false)]
    public class SaveGigResponse
    {
    }

    //[MessageContract]
    //[MessageContract(IsWrapped=true, WrapperName="GetGig")]
    [MessageContract(IsWrapped = false)]
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

    //[MessageContract]
    [MessageContract(IsWrapped = false)]
    public class GetGigResponse
    {
        private LinkItem m_linkItem;

        public GetGigResponse()
        {
        }

        public GetGigResponse(LinkItem item)
        {
            this.m_linkItem = item;
        }

        [MessageBodyMember]
        public LinkItem Item
        {
            get { return m_linkItem; }
            set { m_linkItem = value; }
        }
    }
}
