// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.IdentityModel.Policy;
using System.IdentityModel.Claims;
using System.Security.Principal;
using System.ServiceModel;
using System.Threading;
using System.Web.Security;


namespace ClaimsBasedSecurityComponents
{
    public class ClaimsAuthorizationPolicy : IAuthorizationPolicy
    {

        public static class Resources
        {
            public const string Application = "http://schemas.thatindigogirl.com/samples/2006/06/identity/resources/application";
        }

        public static class ClaimTypes
        {
            public const string Create = "http://schemas.thatindigogirl.com/samples/2006/06/identity/claims/create";
            public const string Read = "http://schemas.thatindigogirl.com/samples/2006/06/identity/claims/read";
            public const string Update = "http://schemas.thatindigogirl.com/samples/2006/06/identity/claims/update";
            public const string Delete = "http://schemas.thatindigogirl.com/samples/2006/06/identity/claims/delete";
        }

        public const string IssuerName = "http://www.thatindigogirl.com/samples/2006/06/issuer";

        private Guid m_id;


        public ClaimsAuthorizationPolicy()
        {
            m_id = Guid.NewGuid();
        }

        #region IAuthorizationPolicy Members

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            return true;

        }


        public ClaimSet Issuer
        {
            get { return null;
            }
        }

        #endregion

        #region IAuthorizationComponent Members

        public string Id
        {
            get
            {
                return m_id.ToString();
            }
        }

        #endregion

    }
}
