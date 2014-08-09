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
using System.Threading;
using System.Diagnostics;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text += ": Process " + Process.GetCurrentProcess().Id.ToString();

        }

        MessagingServiceClient proxy = new MessagingServiceClient();

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 200; i++)
            {
                proxy.BeginSendMessage1("SendMessage1()", null, null);
                Application.DoEvents();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 200; i++)
            {
                proxy.BeginSendMessage2("SendMessage2()", null, null);
                Application.DoEvents();

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 200; i++)
            {
                proxy.BeginSendMessage3("SendMessage3()", null, null);
                Application.DoEvents();

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            proxy.Close();
        }

    }
}