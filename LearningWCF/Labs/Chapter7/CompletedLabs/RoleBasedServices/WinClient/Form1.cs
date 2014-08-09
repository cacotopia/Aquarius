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
using System.ServiceModel;
using System.Net;
using System.Security.Principal;
using System.Threading;
using System.Security;

namespace WinClient
{
    public partial class Form1 : Form
    {
        localhost.SecureServiceContractClient m_proxy;

        public Form1()
        {
            Thread.GetDomain().SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

            InitializeComponent();

            m_proxy = new WinClient.localhost.SecureServiceContractClient();
            UpdateIdentities();
        }

        private void cmdAdminOp_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(m_proxy.AdminOperation());
            }
            catch (CommunicationException comEx)
            {

                MessageBox.Show(comEx.Message);
                m_proxy = new WinClient.localhost.SecureServiceContractClient();
                
            }
        }

        private void cmdUserOp_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(m_proxy.UserOperation());
            }
            catch (CommunicationException comEx)
            {
                MessageBox.Show(comEx.Message);
                m_proxy = new WinClient.localhost.SecureServiceContractClient();
            }

        }

        private void cmdGuestOp_Click(object sender, EventArgs e)
        {

            try
            {
                MessageBox.Show(m_proxy.GuestOperation());
            }
            catch (CommunicationException comEx)
            {

                MessageBox.Show(comEx.Message);
                m_proxy = new WinClient.localhost.SecureServiceContractClient();
            }

        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {

            SecurityUtility.LoginForm f = new SecurityUtility.LoginForm();

			DialogResult res = f.ShowDialog();
			if (res == DialogResult.OK)
			{

                try
                {
                    ImpersonateUser(f.Username, f.Password, f.Domain);

                    m_proxy = new WinClient.localhost.SecureServiceContractClient();
                    UpdateIdentities();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

			}

        }

        WindowsImpersonationContext m_impersonationContext;

        private void ImpersonateUser(string username, string password, string domain)
        {

            if (m_impersonationContext != null)
            {
                m_impersonationContext.Undo();
                m_impersonationContext.Dispose();
                m_impersonationContext = null;
            }

            WindowsPrincipal p = SecurityUtility.LogonUtil.GetLogonUser(domain, username, password);
            if (p == null)
                throw new SecurityException("Invalid credentials provided.");

            Thread.CurrentPrincipal = p;

            m_impersonationContext = SecurityUtility.LogonUtil.ImpersonateWindowsIdentity(p.Identity as WindowsIdentity);

        }

        private void UpdateIdentities()
        {
            IIdentity winIdentity = WindowsIdentity.GetCurrent();
            this.lblWindowsIdentity.Text = String.Format("Name: {0}\r\nIsAuthenticated: {1}\r\nAuthenticationType: {2}", winIdentity.Name, winIdentity.IsAuthenticated, winIdentity.AuthenticationType);

            IPrincipal secPrincipal = Thread.CurrentPrincipal;
            this.lblLoggedInUser.Text = String.Format("Name: {0}\r\nIsAuthenticated: {1}\r\nAuthenticationType: {2}", secPrincipal.Identity.Name, secPrincipal.Identity.IsAuthenticated, secPrincipal.Identity.AuthenticationType); ;

        }

        
    }
}