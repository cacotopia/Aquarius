// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using WinClient.localhost;
using System.Threading;

namespace WinClient
{
    //[CallbackBehavior(UseSynchronizationContext=false)]
    public partial class Form1 : Form, HelloIndigoContractCallback
    {
        private HelloIndigoContractClient m_proxy = null;

        public Form1()
        {
            InitializeComponent();

            this.Text = string.Format("Callback Client - Thread {0}", Thread.CurrentThread.GetHashCode());

            InstanceContext context = new InstanceContext(this);
            m_proxy = new HelloIndigoContractClient(context);

            WSDualHttpBinding binding = m_proxy.Endpoint.Binding as WSDualHttpBinding;
            if (binding!=null)
              binding.ClientBaseAddress=new Uri("http://localhost:8101");
        }


 
        private void cmdInvoke_Click(object sender, EventArgs e)
        {
            m_proxy.HelloIndigo("Hello from WinClient");
        }

        #region HelloIndigoContractCallback Members

        public void HelloIndigoCallback(string message)
        {
            MessageBox.Show(string.Format("Received callback on thread {0}. {1}", System.Threading.Thread.CurrentThread.GetHashCode(), message));

        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}