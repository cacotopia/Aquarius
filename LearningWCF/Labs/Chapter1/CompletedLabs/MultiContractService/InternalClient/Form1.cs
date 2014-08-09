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
using BusinessServiceContracts;
using System.ServiceModel;

namespace InternalClient
{
    public partial class Form1 : Form
    {
        IServiceA m_proxyA;
        IAdmin m_adminProxyA;
        
        IServiceB m_proxyB;
        IAdmin m_adminProxyB;

        public Form1()
        {
            InitializeComponent();

            ChannelFactory<IServiceA> factoryA = new
ChannelFactory<IServiceA>("");
            m_proxyA = factoryA.CreateChannel();

            ChannelFactory<IAdmin> adminFactoryA = new
          ChannelFactory<IAdmin>("TCP_IAdmin");
            m_adminProxyA = adminFactoryA.CreateChannel();

            ChannelFactory<IServiceB> factoryB = new
          ChannelFactory<IServiceB>("");
            m_proxyB = factoryB.CreateChannel();

            ChannelFactory<IAdmin> adminFactoryB = new
          ChannelFactory<IAdmin>("IPC_IAdmin");
            m_adminProxyB = adminFactoryB.CreateChannel();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = m_adminProxyA.AdminOperation1();
            MessageBox.Show(s);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string s = m_adminProxyA.AdminOperation2();
            MessageBox.Show(s);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string s = m_adminProxyB.AdminOperation1();
            MessageBox.Show(s);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string s = m_adminProxyB.AdminOperation2();
            MessageBox.Show(s);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string s = m_proxyA.Operation1();
            MessageBox.Show(s);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            string s = m_proxyA.Operation2();
            MessageBox.Show(s);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            string s = m_proxyB.Operation3();
            MessageBox.Show(s);
        }

        private void CloseProxy(ICommunicationObject proxy)
        {
            try
            {
                if (proxy != null)
                    proxy.Close();
            }
            catch { }
        }

        private void Form1_FormClosing(object sender    , FormClosingEventArgs e)
        {
            CloseProxy(m_proxyA as ICommunicationObject);
            CloseProxy(m_proxyB as ICommunicationObject);
            CloseProxy(m_adminProxyA as ICommunicationObject);
            CloseProxy(m_adminProxyB as ICommunicationObject);
        }
    }
}