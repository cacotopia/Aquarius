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
    [ServiceContract(Name="SecureServiceContract", Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
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

        string ISecureService.AdminOperation()
        {

            string s = String.Format("AdminOperation requested at {0}\r\n Host identity is {1}\r\n Security context identity is {2}", DateTime.Now,WindowsIdentity.GetCurrent().Name, ServiceSecurityContext.Current.PrimaryIdentity.Name);

            Console.WriteLine(s);
            Console.WriteLine();

            return s;
        }

        string ISecureService.UserOperation()
        {
            string s = String.Format("UserOperation requested at {0}\r\n Host identity is {1}\r\n Security context identity is {2}", DateTime.Now, WindowsIdentity.GetCurrent().Name, ServiceSecurityContext.Current.PrimaryIdentity.Name);

             Console.WriteLine(s);
            Console.WriteLine();

            
            return s;
        }


        string ISecureService.GuestOperation()
        {
            string s = String.Format("GuestOperation requested at {0}\r\n Host identity is {1}\r\n Security context identity is {2}", DateTime.Now, WindowsIdentity.GetCurrent().Name, ServiceSecurityContext.Current.PrimaryIdentity.Name);

            Console.WriteLine(s);
            Console.WriteLine();

            return s;
        }

        #endregion
    }
}
