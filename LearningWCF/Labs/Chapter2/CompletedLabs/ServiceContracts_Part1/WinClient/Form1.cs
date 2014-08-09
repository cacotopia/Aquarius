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

namespace WinClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        localhost.ServiceAClient m_proxy = new WinClient.localhost.ServiceAClient();

        private void button1_Click(object sender, EventArgs e)
        {
            string s = m_proxy.Operation1();
            MessageBox.Show(s);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = m_proxy.Operation2();
            MessageBox.Show(s);


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_proxy != null)
                m_proxy.Close();
        }
    }
}