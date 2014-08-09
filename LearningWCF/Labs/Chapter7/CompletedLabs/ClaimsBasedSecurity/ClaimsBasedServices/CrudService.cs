// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
   
using System;
using System.ServiceModel;
using System.Security.Permissions;
using System.Security.Principal;
using System.IdentityModel.Claims;
using System.Collections.Generic;
using System.Security;
using System.Threading;
using System.IdentityModel.Policy;
using ClaimsBasedSecurityComponents;

namespace ClaimsBasedServices
{


    [ServiceContract(Namespace="http://www.thatindigogirl.com/samples/2006/06")]
    public interface ICrudService
    {
        
        [OperationContract]
        string CreateSomething();

        [OperationContract]
        string ReadSomething();

        [OperationContract]
        string UpdateSomething();

        [OperationContract]
        string DeleteSomething();
    }

    public class CrudService: ICrudService
    {

       string ICrudService.CreateSomething()
        {

           ClaimsPrincipalPermission perm = new ClaimsPrincipalPermission(true, ClaimsAuthorizationPolicy.IssuerName, ClaimsAuthorizationPolicy.ClaimTypes.Create);
           perm.Demand();

            return String.Format("CreateSomething() called by user {0}", System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

        string ICrudService.ReadSomething()
        {

            ClaimsPrincipalPermission perm = new ClaimsPrincipalPermission(true, ClaimsAuthorizationPolicy.IssuerName, ClaimsAuthorizationPolicy.ClaimTypes.Read);
            perm.Demand();
            
            return String.Format("ReadSomething() called by user {0}", System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

        string ICrudService.UpdateSomething()
        {
            ClaimsPrincipalPermission perm = new ClaimsPrincipalPermission(true, ClaimsAuthorizationPolicy.IssuerName, ClaimsAuthorizationPolicy.ClaimTypes.Update);
            perm.Demand();

            return String.Format("UpdateSomething() called by user {0}", System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

        [ClaimsPrincipalPermission(SecurityAction.Demand, IssuerName=ClaimsAuthorizationPolicy.IssuerName, RequiredClaim=ClaimsAuthorizationPolicy.ClaimTypes.Delete)]
        string ICrudService.DeleteSomething()
        {
//            ClaimsPrincipalPermission perm = new ClaimsPrincipalPermission(true, ClaimsAuthorizationPolicy.IssuerName, ClaimsAuthorizationPolicy.ClaimTypes.Delete);
  //          perm.Demand();

            return String.Format("DeleteSomething() called by user {0}", System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

    }

}

