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


        private Guid m_id;
        private ClaimSet m_issuer;
        public const string IssuerName = "http://www.thatindigogirl.com/samples/2006/06/issuer";


        public ClaimsAuthorizationPolicy()
        {
            m_id = Guid.NewGuid();

            Claim c = Claim.CreateNameClaim(ClaimsAuthorizationPolicy.IssuerName);
            Claim[] claims = new Claim[1];
            claims[0] = c;
            m_issuer = new DefaultClaimSet(claims);
        }

        #region IAuthorizationPolicy Members

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            if (evaluationContext.Properties.ContainsKey("Identities"))
            {
                List<IIdentity> identities = evaluationContext.Properties["Identities"] as List<IIdentity>;
                IIdentity identity = identities[0];

                ClaimSet claims = MapClaims(identity);

//                GenericPrincipal newPrincipal = new GenericPrincipal(identity, null);
                ClaimsPrincipal newPrincipal = new ClaimsPrincipal(identity, claims);
                evaluationContext.Properties["Principal"] = newPrincipal;
                evaluationContext.AddClaimSet(this, claims);
                return true;
            }
            else
                return false;

        }

        private ClaimSet MapClaims(IIdentity identity)
        {

            List<Claim> listClaims = new List<Claim>();

            if (!identity.IsAuthenticated)
                throw new NotSupportedException("User not authenticated.");

            if (Roles.IsUserInRole(identity.Name, "Administrators"))
            {
                listClaims.Add(new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Create, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty));
                listClaims.Add(new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Delete, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty));
                listClaims.Add(new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Read, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty));
                listClaims.Add(new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Update, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty));
            }
            else if (Roles.IsUserInRole(identity.Name, "Users"))
            {
                listClaims.Add(new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Read, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty));
                listClaims.Add(new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Update, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty));
            }
            else
            {
                listClaims.Add(new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Read, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty));
            }

            return new DefaultClaimSet(this.m_issuer, listClaims);
        }

        public ClaimSet Issuer
        {
            get { return m_issuer; }
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
