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
using System.ServiceModel.Channels;
using System.Xml;

namespace GigManager
{

    [ServiceContract(Name = "GigManagerServiceContract", Namespace = "http://www.thatindigogirl.com/samples/2006/06", SessionMode = SessionMode.Required)]
    public interface IGigManagerService
    {
        [OperationContract]
        void SaveGig(Message requestMessage);

        [OperationContract]
        Message GetGig(Message requestMessage);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class GigManagerService : IGigManagerService
    {

        private LinkItem m_linkItem;

        #region IGigManager Members

        public void SaveGig(Message requestMessage)
        {
            XmlDictionaryReader xmlReader = requestMessage.GetReaderAtBodyContents();
            xmlReader.MoveToContent();
            xmlReader.Read();
            xmlReader.MoveToContent();
            xmlReader.Read();

            this.m_linkItem = LinkItemHelper.ReadLinkItem(xmlReader);

            xmlReader.Close();
        }

        public Message GetGig(Message requestMessage)
        {
            string licenseKey = requestMessage.Headers.GetHeader<string>("LicenseKey", "http://www.thatindigogirl.com/samples/2006/06");

            if (licenseKey != "XXX") 
                throw new FaultException("Invalid license key.");

            return new GetGigResponse(this.m_linkItem, requestMessage.Version);
        }

        #endregion
    }
}
