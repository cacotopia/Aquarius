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

namespace GigManager
{
    [ServiceContract(Name = "GigManagerServiceContract", Namespace = "http://www.thatindigogirl.com/samples/2006/06", SessionMode = SessionMode.Required)]
    public interface IGigManagerService
    {
        [OperationContract]
        [ServiceKnownType(typeof(ContentTypes.GigInfo))]
        void SaveGig(LinkItem item);

        [OperationContract]
        LinkItem GetGig();

        /*在单个操作上应用ServiceKnownTypeAttributes*/
        [OperationContract]
        [ServiceKnownType(typeof(ContentTypes.PhotoLink))]
        void SavePhoto(LinkItem item);

        [OperationContract]
        [ServiceKnownType(typeof(ContentTypes.MP3Link))]
        void SaveMP3(LinkItem item);
        /**/
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class GigManagerService : IGigManagerService
    {

        private LinkItem m_linkItem;

        #region IGigManager Members

        public void SaveGig(LinkItem item)
        {
            m_linkItem = item;
        }

        public LinkItem GetGig()
        {
            return m_linkItem;
        }

        #endregion
    }
}
