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

namespace ExternalClient
{
    public partial class Form1 : Form
    {
        ServiceA.ServiceAClient m_proxyA;
        ServiceB.ServiceBClient m_proxyB;

        public Form1()
        {
            InitializeComponent();
            m_proxyA = new ExternalClient.ServiceA.ServiceAClient("BasicHttpBinding_IServiceA");
            m_proxyB = new ExternalClient.ServiceB.ServiceBClient("BasicHttpBinding_IServiceB");

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.m_proxyA.Close();
            this.m_proxyB.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = m_proxyA.Operation1();
            MessageBox.Show(s);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string s = m_proxyA.Operation2();
            MessageBox.Show(s);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string s = m_proxyB.Operation3();
            MessageBox.Show(s);
        }



    }
}