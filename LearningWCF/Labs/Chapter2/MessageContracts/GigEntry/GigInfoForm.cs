// ?2007 Michele Leroux Bustamante. All rights reserved 
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

using GigEntry.localhost;



namespace GigEntry
{
    public partial class GigInfoForm : Form
    {
        private GigManagerServiceContractClient m_proxy;

        public GigInfoForm()
        {
            InitializeComponent();
            m_proxy = new GigManagerServiceContractClient();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            LinkItem item = new LinkItem();

            item.Id = int.Parse(txtId.Text.Trim());
            item.Title = txtTitle.Text.Trim();
            item.Description = txtDescription.Text.Trim();
            item.DateStart = dtpStart.Value;
            item.DateEnd = dtpStart.Value;
            item.Url = txtUrl.Text.Trim();

            m_proxy.SaveGig(item);
            ClearInfo();
        }


        private void cmdGet_Click(object sender, EventArgs e)
        {
            LinkItem item = m_proxy.GetGig("cacotopia");

            if (item != null) 
            {
                txtId.Text = item.Id.ToString();
                txtTitle.Text = item.Title;
                txtDescription.Text = item.Description;
                if (item.DateStart != DateTime.MinValue) 
                {
                    dtpStart.Value = item.DateStart;
                }
                if (item.DateEnd != DateTime.MinValue) 
                {
                    dtpEnd.Value = item.DateEnd;
                }
                txtUrl.Text = item.Url;
            }
        }

        private void ClearInfo() 
        {
            txtId.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtUrl.Text = string.Empty;
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
        }
    }
}

