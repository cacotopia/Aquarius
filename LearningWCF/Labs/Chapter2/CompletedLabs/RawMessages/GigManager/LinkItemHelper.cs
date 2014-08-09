// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using ContentTypes;
using System.Xml;

namespace GigManager
{
    static class LinkItemHelper
    {

        private const string ns = "http://schemas.thatindigogirl.com/samples/2006/06";

        public static void WriteLinkItem(LinkItem linkItem, XmlDictionaryWriter xmlWriter)
        {
/* What the contents of the link item look like...
             
    <b:Id>xs:int</b:Id>
    <b:Title>xs:string</b:Title>
    <b:Description>xs:string</b:Description>
    <b:DateStart>xs:dateTime</b:DateStart>
    <b:DateEnd>xs:dateTime</b:DateEnd>
    <b:Url>xs:string</b:Url>
*/
            xmlWriter.WriteStartElement("Id", ns);
            xmlWriter.WriteValue(linkItem.Id);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteElementString("Title",ns, linkItem.Title);
            xmlWriter.WriteElementString("Description",ns, linkItem.Description);

            xmlWriter.WriteStartElement("DateStart",ns);
            xmlWriter.WriteValue(linkItem.DateStart);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("DateEnd", ns);
            xmlWriter.WriteValue(linkItem.DateEnd);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteElementString("Url", ns, linkItem.Url);

        }

        public static LinkItem ReadLinkItem(XmlDictionaryReader reader)
        {
            LinkItem linkItem = new LinkItem();

            if (reader.IsStartElement("Id", ns))
            {
                reader.MoveToContent();
                linkItem.Id = int.Parse(reader.ReadString());
                reader.MoveToContent();
                reader.ReadEndElement();
            }
            else
                throw new XmlException("ExpectedElementMissing: Id element was expected.");

            if (reader.IsStartElement("Title", ns))
            {
                reader.MoveToContent();
                linkItem.Title = reader.ReadString();
                reader.MoveToContent();
                reader.ReadEndElement();
            }
            else
                throw new XmlException("ExpectedElementMissing: Title element was expected.");

            if (reader.IsStartElement("Description", ns ))
            {
                reader.MoveToContent();
                linkItem.Description = reader.ReadString();
                reader.MoveToContent();
                reader.ReadEndElement();
            }
            else
                throw new XmlException("ExpectedElementMissing: Description element was expected.");

            if (reader.IsStartElement("DateStart", ns))
            {
                reader.MoveToContent();
                reader.Read();
                linkItem.DateStart = reader.ReadContentAsDateTime();
                reader.MoveToContent();
                reader.ReadEndElement();
            }
            else
                throw new XmlException("ExpectedElementMissing: DateStart element was expected.");

            if (reader.IsStartElement("DateEnd", ns))
            {
                reader.MoveToContent();
                reader.Read();
                linkItem.DateEnd = reader.ReadContentAsDateTime();
                reader.MoveToContent();
                reader.ReadEndElement();
            }
            // optional

            if (reader.IsStartElement("Url", ns))
            {
                reader.MoveToContent();
                linkItem.Url = reader.ReadString();

                reader.MoveToContent();
                reader.ReadEndElement();
            }
            else
                throw new XmlException("ExpectedElementMissing: Url element was expected.");

            return linkItem;

        }
    }
}
