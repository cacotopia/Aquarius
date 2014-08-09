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
        public Form1()
        {
            InitializeComponent();
       }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close the service?", "Service Controller", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                e.Cancel=true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += ": UI Thread " + Thread.CurrentThread.GetHashCode();
        }
    }
}