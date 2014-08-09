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
    [ServiceContract(Name = "GigManagerServiceContract", Namespace = "http://www.thatindigogirl.com/samples/2006/06", SessionMode = SessionMode.Required)]
    public interface IGigManagerService
    {
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

        public SaveGigResponse SaveGig(SaveGigRequest requestMessage)
        {
            m_linkItem = requestMessage.Item;
            return new SaveGigResponse();
        }

        public GetGigResponse GetGig(GetGigRequest requestMessage)
        {
            if (requestMessage.LicenseKey != "XXX") 
                throw new FaultException("Invalid license key.");

            return new GetGigResponse(m_linkItem);
        }

        #endregion
    }
}
