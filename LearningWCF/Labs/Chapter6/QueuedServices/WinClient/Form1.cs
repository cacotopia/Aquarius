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

       int m_counter = 1;
       private void button1_Click(object sender, EventArgs e)
      {
          using (localhost.MessagingServiceClient proxy = new WinClient.localhost.MessagingServiceClient())
          {
            proxy.SendMessage(string.Format("Message {0} from client", m_counter++));
          }
          
      }

      
   }
}