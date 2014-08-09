// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using System.IdentityModel.Claims;

namespace ClaimsBasedSecurityComponents
{

    public interface IClaimsPrincipal
    {
        ClaimSet Claims { get;}
        ClaimSet Issuer { get;}

        bool HasRequiredClaims(ClaimSet requiredClaims);
    }

    public class ClaimsPrincipal : IClaimsPrincipal, IPrincipal
    {
        private ClaimSet m_claims;
        private IIdentity m_identity;

        public ClaimsPrincipal(IIdentity identity, ClaimSet claims)
        {

            this.m_identity = identity;
            this.m_claims = claims;
        }

        #region IClaimSetPrincipal Members

        ClaimSet IClaimsPrincipal.Issuer
        {
            get { return this.m_claims.Issuer; }
        }

        bool IClaimsPrincipal.HasRequiredClaims(ClaimSet requiredClaims)
        {
            bool hasClaims = true;
            foreach (Claim c in requiredClaims)
            {
                if (!this.m_claims.ContainsClaim(c))
                {
                    hasClaims = false;
                    break;
                }
            }

            return hasClaims;
        }

        ClaimSet IClaimsPrincipal.Claims
        {
            get { return this.m_claims; }
        }

        #endregion

        #region IPrincipal Members

        IIdentity IPrincipal.Identity
        {
            get
            {
                return this.m_identity;
            }
        }

        bool IPrincipal.IsInRole(string role)
        {
            throw new NotSupportedException("ClaimsPrincipal does not implement role-based security checks.");
        }

        #endregion
    }

}
