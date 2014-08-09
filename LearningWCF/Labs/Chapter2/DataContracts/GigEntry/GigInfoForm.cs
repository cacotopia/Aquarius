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
            //生成客户端服务代理
             m_proxy = new GigEntry.localhost.GigManagerServiceContractClient();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            LinkItem item = new LinkItem();

            item.Id = int.Parse(txtId.Text.Trim());
            item.Title = txtTitle.Text.Trim();
            item.Description = txtDescription.Text.Trim();
            item.DateStart = dtpStart.Value;
            item.DateEnd = dtpEnd.Value;
            item.URI = txtUrl.Text.Trim();

            m_proxy.SaveGig(item);
        }

        private void cmdGet_Click(object sender, EventArgs e)
        {


        }
    }
}