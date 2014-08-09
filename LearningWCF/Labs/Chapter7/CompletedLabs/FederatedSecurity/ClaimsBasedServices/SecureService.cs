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
using System.IdentityModel.Policy;
using System.IdentityModel.Claims;
using System.Security;

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

            AuthorizationContext authContext = ServiceSecurityContext.Current.AuthorizationContext;

            DateTime? birthDate = null;
            foreach (ClaimSet cs in authContext.ClaimSets)
            {
                // check for self-issued claims 
                ClaimSet csIssuer = cs.Issuer;
                if (csIssuer == csIssuer.Issuer)
                {
                    IEnumerable<Claim> claims = cs.FindClaims(ClaimTypes.DateOfBirth, Rights.PossessProperty);
                    foreach (Claim c in claims)
                    {
                        birthDate = Convert.ToDateTime(c.Resource);
                    }
                }
            }

            if (birthDate == null)
                throw new SecurityException("Missing date of birth claim.");
            if (birthDate.Value.AddYears(13) > DateTime.Now)
                throw new SecurityException("User is too young to access this operation.");

            string s = String.Format("Message '{0}' received. \r\n\r\nHost identity is {1}\r\n Security context PrimaryIdentity is {2}\r\n Security context WindowsIdentity is {3}\r\n Thread identity is {4}", message, WindowsIdentity.GetCurrent().Name, ServiceSecurityContext.Current.PrimaryIdentity.Name, ServiceSecurityContext.Current.WindowsIdentity.Name, Thread.CurrentPrincipal.Identity.Name);

            return s;
        }


        #endregion
    }
}
