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
using System.Net;
using System.Security.Principal;
using System.Threading;
using System.Security;

namespace WinClient
{
    public partial class Form1 : Form
    {
        string m_username;
        string m_password;

        localhost.SecureServiceContractClient m_proxySoap11;
        localhost.SecureServiceContractClient m_proxySoap12;

        public Form1()
        {
            Thread.GetDomain().SetPrincipalPolicy(PrincipalPolicy.UnauthenticatedPrincipal);
            
            InitializeComponent();
            InitializeProxy();
            UpdateIdentities();
        }

        private void InitializeProxy()
        {
            m_proxySoap11 = new WinClient.localhost.SecureServiceContractClient("BasicHttpBinding_SecureServiceContract");
            m_proxySoap12 = new WinClient.localhost.SecureServiceContractClient("WSHttpBinding_SecureServiceContract");

            if (!(String.IsNullOrEmpty(m_username) || String.IsNullOrEmpty(this.m_password)))
            {
                m_proxySoap11.ClientCredentials.UserName.UserName = this.m_username;
                m_proxySoap11.ClientCredentials.UserName.Password = this.m_password;

                m_proxySoap12.ClientCredentials.UserName.UserName = this.m_username;
                m_proxySoap12.ClientCredentials.UserName.Password = this.m_password;
            }

        }

        private void cmdAdminOp_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(GetProxy().AdminOperation());
            }
            catch (FaultException faultEx)
            {
                MessageBox.Show(faultEx.Message);
                InitializeProxy();
            }
            catch (CommunicationException comEx)
            {
                MessageBox.Show(comEx.Message);
                InitializeProxy();
            }
        }

        private localhost.SecureServiceContractClient GetProxy()
        {
            if (radSoap11.Checked)
                return this.m_proxySoap11;
            else
                return this.m_proxySoap12;
        }

        private void cmdUserOp_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(GetProxy().UserOperation());
            }
            catch (CommunicationException comEx)
            {
                MessageBox.Show(comEx.Message);
                InitializeProxy();
            }

        }

        private void cmdGuestOp_Click(object sender, EventArgs e)
        {

            try
            {
                MessageBox.Show(GetProxy().GuestOperation());
            }
            catch (CommunicationException comEx)
            {

                MessageBox.Show(comEx.Message);
                InitializeProxy();

            }

        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {

            SecurityUtility.LoginForm f = new SecurityUtility.LoginForm();
            f.ShowDomain = false;

			DialogResult res = f.ShowDialog();
			if (res == DialogResult.OK)
			{

                try
                {
                    this.m_username = f.Username;
                    this.m_password = f.Password;

                    InitializeProxy();
                    UpdateIdentities();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

			}

        }

        private void UpdateIdentities()
        {
            IIdentity winIdentity = WindowsIdentity.GetCurrent();
            this.lblWindowsIdentity.Text = String.Format("Name: {0}\r\nIsAuthenticated: {1}\r\nAuthenticationType: {2}", winIdentity.Name, winIdentity.IsAuthenticated, winIdentity.AuthenticationType);

            IPrincipal secPrincipal = Thread.CurrentPrincipal;
            this.lblLoggedInUser.Text = String.Format("Name: {0}\r\nIsAuthenticated: {1}\r\nAuthenticationType: {2}", secPrincipal.Identity.Name, secPrincipal.Identity.IsAuthenticated, secPrincipal.Identity.AuthenticationType); ;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}