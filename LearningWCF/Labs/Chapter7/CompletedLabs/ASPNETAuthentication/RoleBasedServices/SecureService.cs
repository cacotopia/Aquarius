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

namespace RoleBasedServices
{
    [ServiceContract(Name="SecureServiceContract", Namespace = "http://www.thatindigogirl.com/2006/06/Samples")]
    internal interface ISecureService
    {
        [OperationContract]
        string AdminOperation();

        [OperationContract]
        string UserOperation();

        [OperationContract]
        string GuestOperation();
    }

    public class SecureService: ISecureService
    {
        #region ISecureService Members

        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        string ISecureService.AdminOperation()
        {
            string s = "";
            if (ServiceSecurityContext.Current!=null)
                s = String.Format("AdminOperation requested at {0}\r\n Host identity is {1}\r\n Security context PrincipalIdentity is {2}\r\n Security context WindowsIdentity is {3}\r\n Thread identity is {4}", DateTime.Now, WindowsIdentity.GetCurrent().Name, ServiceSecurityContext.Current.PrimaryIdentity.Name, ServiceSecurityContext.Current.WindowsIdentity.Name, Thread.CurrentPrincipal.Identity.Name);
            else
                s = String.Format("AdminOperation requested at {0}\r\n Host identity is {1}\r\n Security context identity is null.", DateTime.Now, WindowsIdentity.GetCurrent().Name);

            Console.WriteLine(s);
            Console.WriteLine();

            return s;
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Users")]
        string ISecureService.UserOperation()
        {

            string s = "";
            if (ServiceSecurityContext.Current != null)
                s = String.Format("UserOperation requested at {0}\r\n Host identity is {1}\r\n Security context PrincipalIdentity is {2}\r\n Security context WindowsIdentity is {3}\r\n Thread identity is {4}", DateTime.Now, WindowsIdentity.GetCurrent().Name, ServiceSecurityContext.Current.PrimaryIdentity.Name, ServiceSecurityContext.Current.WindowsIdentity.Name, Thread.CurrentPrincipal.Identity.Name);
            else
                s = String.Format("UserOperation requested at {0}\r\n Host identity is {1}\r\n Security context identity is null.", DateTime.Now, WindowsIdentity.GetCurrent().Name);
               
            Console.WriteLine(s);
            Console.WriteLine();

            return s;
        }


        [PrincipalPermission(SecurityAction.Demand, Role = "Guests")]
        string ISecureService.GuestOperation()
        {
            string s = "";
            if (ServiceSecurityContext.Current!=null)
                s = String.Format("GuestOperation requested at {0}\r\n Host identity is {1}\r\n Security context PrincipalIdentity is {2}\r\n Security context WindowsIdentity is {3}\r\n Thread identity is {4}", DateTime.Now, WindowsIdentity.GetCurrent().Name, ServiceSecurityContext.Current.PrimaryIdentity.Name, ServiceSecurityContext.Current.WindowsIdentity.Name, Thread.CurrentPrincipal.Identity.Name);
            else
                s = String.Format("GuestOperation requested at {0}\r\n Host identity is {1}\r\n Security context identity null.", DateTime.Now, WindowsIdentity.GetCurrent().Name);

            Console.WriteLine(s);
            Console.WriteLine();

            return s;
        }

        #endregion
    }
}
