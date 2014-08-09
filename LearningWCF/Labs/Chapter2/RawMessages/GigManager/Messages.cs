// ?2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using ContentTypes;
using System.Xml;
using System.ServiceModel.Channels;

namespace GigManager
{
    //[MessageContract]
    //public class SaveGigRequest
    //{
    
    //    private LinkItem m_linkItem;

    //    [MessageBodyMember]
    //    public LinkItem Item
    //    {
    //        get { return m_linkItem; }
    //        set { m_linkItem = value; }
    //    }

    //}

    //[MessageContract]
    //public class SaveGigResponse
    //{
    //}

    //[MessageContract]
    //public class GetGigRequest
    //{
    //    private string m_licenseKey;

    //    [MessageHeader]
    //    public string LicenseKey
    //    {
    //        get { return m_licenseKey; }
    //        set { m_licenseKey = value; }
    //    }

    //}

    //[MessageContract]
    //public class GetGigResponse
    //{
    //    private LinkItem m_linkItem;

    //    public GetGigResponse()
    //    {
    //    }

    //    public GetGigResponse(LinkItem item)
    //    {
    //        this.m_linkItem = item;
    //    }

    //    [MessageBodyMember]
    //    public LinkItem Item
    //    {
    //        get { return m_linkItem; }
    //        set { m_linkItem = value; }
    //    }
    //}

    public class GetGigResponse:Message
    {
        private const string ACTION = "http://www.thatindigogirl.com/samples/2006/06/GigManagerServiceContract/GitGigResponse";

        private const string NAMESPACE = "http://www.thatindigogirl.com/samples/2006/06";

        private Message m_innerMessage;

        private LinkItem m_linkItem = new LinkItem();

        public LinkItem Item 
        {
            get { return m_linkItem; }
            set { m_linkItem = value; }
        }

        public GetGigResponse() { }

        public GetGigResponse(Message message) 
        {
            m_innerMessage = message;

            XmlDictionaryReader xmlReader = message.GetReaderAtBodyContents();

            m_linkItem = LinkItemHelper.ReadLinkItem(xmlReader);
        }

        public GetGigResponse(LinkItem linkItem,MessageVersion version)
        {
            m_innerMessage = Message.CreateMessage(version,ACTION);

            m_linkItem = linkItem;
        }

        public GetGigResponse(XmlReader xmlReader,MessageVersion version) 
        {
            m_innerMessage = Message.CreateMessage(version,ACTION);

            XmlDictionaryReader xmlReader = XmlDictionaryReader.CreateDictionaryReader(xmlReader);

            m_linkItem = LinkItemHelper.ReadLinkItem(xmlReader);

        }

        public override MessageHeaders Headers
        {
            get {
                if (m_innerMessage == null)
                {
                    throw new Exception("Invalid operation,Inner Message has not been set.");
                }
                else 
                {
                    return m_innerMessage.Headers;
                }
 
                //throw new Exception("The method or operation is not implemented.");
               }
        }

        protected override void OnBodyToString(XmlDictionaryWriter xmlWriter)
        {
            //base.OnBodyToString(writer);
            xmlWriter.WriteStartElement("GetGitResponse",NAMESPACE);
            xmlWriter.WriteStartElement("Item",NAMESPACE);
            LinkItemHelper.WriteLinkItem(m_linkItem,NAMESPACE);
            xmlWriter.WriteEndElement();//Item
            xmlWriter.WriteEndElement();//GetGigResponse
        }

        public override MessageProperties Properties
        {
            get {
                if (m_innerMessage == null)
                {
                    throw new FaultException("Invalid Operation.Inner message has not been set.");
                }
                else
                {
                    return m_innerMessage.Properties;
                }
                //throw new Exception("The method or operation is not implemented."); 
               }
        }

        public override MessageVersion Version
        {
            get {
                if (m_innerMessage == null)
                {
                    throw new FaultException("Invalid Operation.Inner message has not been set.");
                }
                else 
                {
                    return m_innerMessage.Version;
                }
                //throw new Exception("The method or operation is not implemented.");
               }
        }
    }   
}
