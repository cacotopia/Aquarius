// � 2007 Michele Leroux Bustamante. All rights reserved 
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
using System.IO;

namespace PhotoUploadClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;
            dlg.Multiselect = false;
            dlg.Filter = "JPEG(*.jpg)|*.jpg|BITMAP(*.bmp)|*.bmp";

            DialogResult res = dlg.ShowDialog();
            if (res == DialogResult.OK)
            {
                int pos = dlg.FileName.LastIndexOf("\\");
                string filename = dlg.FileName.Substring(pos + 1, dlg.FileName.Length - (pos + 1));
                FileInfo fi = new FileInfo(dlg.FileName);
                this.txtUrl.Text = fi.Name;
                this.pic.Image = Image.FromFile(dlg.FileName);
            }

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
                        
            try
            {

                MemoryStream stm = new MemoryStream();
                this.pic.Image.Save(stm, this.pic.Image.RawFormat);
                byte[] fileData = new byte[stm.Length];
                fileData = stm.ToArray();


            }
            catch (Exception ex)
            {
                string s = String.Format("{0}\r\nERROR:{1}", ex.GetType(), ex.Message);
                MessageBox.Show(s);
            }

        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dlg_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pic_Click(object sender, EventArgs e)
        {

        }

        private void lblDateStart_Click(object sender, EventArgs e)
        {

        }

        private void lblUrl_Click(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}