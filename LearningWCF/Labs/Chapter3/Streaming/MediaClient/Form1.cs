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
        
        private void cmdGetMedia_Click(object sender, EventArgs e)
        {
            
            
        }

        private void cmdPlay_Click(object sender, EventArgs e)
        {

        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            this.m_mediaPlayer.Stop();

        }
    }
}