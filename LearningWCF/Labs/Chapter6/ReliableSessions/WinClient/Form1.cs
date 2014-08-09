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
          try
          {
              using (localhost.MessagingServiceClient proxy = new WinClient.localhost.MessagingServiceClient())
              {
                  MessageBox.Show(string.Format("About to send message {0}.", m_counter));
                  proxy.SendMessage(string.Format("Message {0}", m_counter++));
                  MessageBox.Show(string.Format("About to send message {0}.", m_counter));
                 
                  proxy.SendMessage(string.Format("Message {0}", m_counter++));

                  MessageBox.Show("About to close the proxy.");

              }
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.ToString());
          }
           
      }

      
   }
}