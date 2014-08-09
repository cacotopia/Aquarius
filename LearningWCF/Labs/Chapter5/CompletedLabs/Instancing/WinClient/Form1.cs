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
using System.Diagnostics;

namespace WinClient
{


   public partial class Form1 : Form
   {

      public Form1()
      {
         InitializeComponent();
      }

       private localhost.CounterServiceClient GetProxy()
       {
           if (radBasicHttp.Checked)
               return new WinClient.localhost.CounterServiceClient("basicHttp");
           else if (radWSHttpNoSession.Checked)
               return new WinClient.localhost.CounterServiceClient("wsHttpNoSession");
           else if (radWSHttpSecureSession.Checked)
               return new WinClient.localhost.CounterServiceClient("wsHttpSecureSession");
           else if (radWSHttpReliableSession.Checked)
               return new WinClient.localhost.CounterServiceClient("wsHttpReliableSession");
           else if (radNetPipe.Checked)
               return new WinClient.localhost.CounterServiceClient("netPipe");
           else
               return new WinClient.localhost.CounterServiceClient("netTcp");
       }

       private void button1_Click(object sender, EventArgs e)
       {
           localhost.CounterServiceClient proxy = GetProxy();
           proxy.IncrementCounter();
           proxy.IncrementCounter();
       }

       private void button2_Click(object sender, EventArgs e)
       {
           localhost.CounterServiceClient proxy = GetProxy();
           try
           {
               proxy.IncrementCounter();
               proxy.ThrowException();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }

           try
           {
               proxy.IncrementCounter();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }

       }

       private void button3_Click(object sender, EventArgs e)
       {
           localhost.CounterServiceClient proxy = GetProxy();
           try
           {
               proxy.IncrementCounter();
               proxy.ThrowFault();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }

           try
           {
               proxy.IncrementCounter();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }


       }


   }
}