// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Security.Principal;
using System.Security.Permissions;
using System.Threading;

namespace ClaimsBasedServices
{
    [ServiceContract(Name = "SecureServiceContract", Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    internal interface ISecureService
    {
        [OperationContract]
        string SendMessage(string message);
    }

    public class SecureService : ISecureService
    {
        #region ISecureService Members

        string ISecureService.SendMessage(string message)
        {

         string s = String.Format("Message '{0}' received. \r\n\r\nHost identity is {1}\r\n Security context PrimaryIdentity is {2}\r\n Security context WindowsIdentity is {3}\r\n Thread identity is {4}", message, WindowsIdentity.GetCurrent().Name, ServiceSecurityContext.Current.PrimaryIdentity.Name, ServiceSecurityContext.Current.WindowsIdentity.Name, Thread.CurrentPrincipal.Identity.Name);

            return s;
        }


        #endregion
    }
}
