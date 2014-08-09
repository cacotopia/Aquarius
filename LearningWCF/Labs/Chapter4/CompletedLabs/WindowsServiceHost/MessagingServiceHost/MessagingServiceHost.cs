// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;

namespace MessagingServiceHost
{
    public partial class MessagingServiceHost : ServiceBase
    {
        ServiceHost m_serviceHost;

        public MessagingServiceHost()
        {
            InitializeComponent();
            this.ServiceName = "MessagingServiceHost";
        }
         
        protected override void OnStart(string[] args)
        {
            m_serviceHost = new ServiceHost(typeof(Messaging.MessagingService));
            m_serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (m_serviceHost != null)
                m_serviceHost.Close();
            m_serviceHost = null;
        }
    }
}
