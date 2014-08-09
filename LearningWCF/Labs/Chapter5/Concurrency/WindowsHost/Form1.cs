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
using System.Threading;

namespace WindowsHost
{
    public partial class Form1 : Form
    {
        ServiceHost m_serviceHost;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close the service?", "Service Host", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                if (m_serviceHost != null)
                {
                    m_serviceHost.Close();
                    m_serviceHost = null;
                }
            }
            else
                e.Cancel=true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += ": UI Thread " + Thread.CurrentThread.GetHashCode();
            m_serviceHost = new ServiceHost(typeof(Messaging.MessagingService));
            m_serviceHost.Open();
        }


    }
}