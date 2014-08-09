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
        //[OperationContract]
        //void SaveGig(LinkItem item);

        //[OperationContract]
        //LinkItem GetGig();

        [OperationContract]
        SaveGigResponse SaveGig(SaveGigRequest requestMessage);

        [OperationContract]
        GetGigResponse GetGig(GetGigRequest requestMessage);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class GigManagerService : IGigManagerService
    {

        private LinkItem m_linkItem;

        #region IGigManager Members

        //public void SaveGig(LinkItem item)
        //{
        //    m_linkItem = item;
        //}

        //public LinkItem GetGig()
        //{
        //    return m_linkItem;
        //}

        #endregion

        public SaveGigResponse SaveGig(SaveGigRequest request) 
        {
            m_linkItem = request.Item;
            return new SaveGigResponse();
        }

        public GetGigResponse GetGig(GetGigRequest request) 
        {
            if (request.LicenseKey != "cacotopia")
                throw new FaultException("Invalid license key.");
            return new GetGigResponse(m_linkItem);
        }
    }
}
