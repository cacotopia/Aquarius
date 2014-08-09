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
using System.IO;
using System.Reflection;
using System.Media;

namespace MediaClient
{
    public partial class Form1 : Form
    {
        SoundPlayer m_mediaPlayer = new SoundPlayer();

        public Form1()
        {
            InitializeComponent();
            
        }

        localhost.MediaManagerContractClient m_mediaManagerProxy = new MediaClient.localhost.MediaManagerContractClient();
        localhost.MediaStreamingContractClient m_mediaStreamingProxy = new localhost.MediaStreamingContractClient("NetTcpBinding_MediaStreamingContract");
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            this.listBox1.DataSource=m_mediaManagerProxy.GetMediaList();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
                        
            string media = this.listBox1.SelectedItem as string;
            if (!String.IsNullOrEmpty(media))
            {
                Stream serverStream = m_mediaStreamingProxy.GetMediaStream(media);
                this.m_mediaPlayer.Stream=serverStream;
                this.m_mediaPlayer.Play();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.m_mediaPlayer.Stop();

        }
    }
}