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
using System.Transactions;

namespace CountersClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetCounters();

        }

        localhost.CountersServiceClient m_proxy = new CountersClient.localhost.CountersServiceClient();


        private void GetCounters()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                this.bindingSource1.DataSource = m_proxy.GetCounters();

                scope.Complete();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                using (TransactionScope scope = new TransactionScope())
                {
                    m_proxy.SetCounter1(int.Parse(this.txtCounter.Text));
                    m_proxy.SetCounter2(int.Parse(this.txtCounter.Text));

                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                m_proxy = new CountersClient.localhost.CountersServiceClient();
            }

            GetCounters();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    m_proxy.ResetCounters();

                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                m_proxy = new CountersClient.localhost.CountersServiceClient();
            }

            GetCounters();


        }
    }
}