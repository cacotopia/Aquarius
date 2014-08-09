// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Threading;
using System.IdentityModel.Claims;
using System.Security.Permissions;
using System.Security.Principal;

namespace ClaimsBasedSecurityComponents
{
    public class ClaimsPrincipalPermission : IPermission
    {
        List<string> m_requiredClaims = new List<string>();
        private bool m_isAuthenticated;

        public bool IsAuthenticated
        {
            get { return m_isAuthenticated; }
        }
        private string m_issuer;

        public string Issuer
        {
            get { return m_issuer; }
            set { m_issuer = value; }
        }

        public List<string> RequiredClaims
        {
            get { return m_requiredClaims; }
            set { m_requiredClaims = value; }
        }

        public ClaimsPrincipalPermission(PermissionState state)
        {
            this.m_isAuthenticated = true;
        }

        public ClaimsPrincipalPermission(bool isAuthenticated, string issuer)
            : this(isAuthenticated, issuer, null)
        {
        }


        public ClaimsPrincipalPermission(bool isAuthenticated, string issuer, params string[] requiredClaims)
        {
            this.m_isAuthenticated = isAuthenticated;

            m_issuer = issuer;
            
            if (requiredClaims != null)
                this.m_requiredClaims.AddRange(requiredClaims);
        }

        #region IPermission Members

        public IPermission Copy()
        {
            if (this.m_requiredClaims == null)
                return new ClaimsPrincipalPermission(this.m_isAuthenticated, this.m_issuer, null);
            else
                return new ClaimsPrincipalPermission(this.m_isAuthenticated, this.m_issuer, this.m_requiredClaims.ToArray());

        }

        public void CheckClaims(IClaimsPrincipal principal)
        {
            IPrincipal p = principal as IPrincipal;
            if (this.m_isAuthenticated && !p.Identity.IsAuthenticated)
            {
                throw new SecurityException("Access is denied. Security principal is not authenticated.");
            }


            if (m_issuer!=null)
            {
                Claim c = Claim.CreateNameClaim(m_issuer);
                if (!principal.Issuer.ContainsClaim(c))
                {
                    throw new SecurityException("Access is denied. Invalid claims issuer.");
                }
            }

            if (this.m_requiredClaims.Count == 0)
            {
                return;

            }

            List<Claim> claims = new List<Claim>();
            foreach (string s in this.m_requiredClaims)
            {
                claims.Add(new Claim(s, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty));
            }

            DefaultClaimSet claimSet = new DefaultClaimSet(claims);
            if (!principal.HasRequiredClaims(claimSet))
                throw new SecurityException("Access is denied. Security principal does not satisfy required claims.");

        }

        public void Demand()
        {
            IClaimsPrincipal p = Thread.CurrentPrincipal as IClaimsPrincipal;

            if (p == null)
                throw new SecurityException("Access is denied. Security principal should be a IClaimSetPrincipal type.");

            this.CheckClaims(p);

        }

        public IPermission Intersect(IPermission target)
        {
            if (target == null)
                return null;

            ClaimsPrincipalPermission perm = target as ClaimsPrincipalPermission;
            if (perm == null)
                return null;

            if (this.m_isAuthenticated != perm.IsAuthenticated)
                return null;

            if (this.m_issuer != perm.Issuer)
                return null;


            List<string> claims = new List<string>();
            foreach (string s in this.m_requiredClaims)
            {

                Predicate<string> predicate = delegate(string sMatch) { if (sMatch == s) return true; else return false; };
                if (perm.RequiredClaims.Exists(predicate))
                {
                    claims.Add(s);
                }
            }

            ClaimsPrincipalPermission newPerm = new ClaimsPrincipalPermission(this.m_isAuthenticated, this.m_issuer, claims.ToArray());
            return newPerm;

        }

        public bool IsSubsetOf(IPermission target)
        {

            bool isSubsetOf = false;

            if (target == null)
                return false;

            ClaimsPrincipalPermission perm = target as ClaimsPrincipalPermission;
            if (perm == null)
                return false;

            if (this.m_isAuthenticated != perm.IsAuthenticated)
                return false;

            if (this.m_issuer != perm.Issuer)
                return false;

            int count = 0;
            foreach (string s in this.m_requiredClaims)
            {
                
                if (perm.m_requiredClaims.Contains(s))
                    count++;
            }

            if (count == this.m_requiredClaims.Count)
                isSubsetOf = true;
            return isSubsetOf;

        }

        public IPermission Union(IPermission target)
        {
            if (target == null)
                return null;

            ClaimsPrincipalPermission perm = target as ClaimsPrincipalPermission;
            if (perm == null)
                return null;

            if (this.m_isAuthenticated != perm.IsAuthenticated)
                return null;

            if (this.m_issuer != perm.Issuer)
                return null;

            string[] claimsArray = perm.RequiredClaims.ToArray();
            List<string> claims = new List<string>();
            claims.AddRange(claimsArray);

            foreach (string s in this.m_requiredClaims)
            {
                if (!claims.Contains(s))
                    claims.Add(s);
            }

            ClaimsPrincipalPermission newPerm = new ClaimsPrincipalPermission(this.m_isAuthenticated, this.m_issuer, claims.ToArray());
            return newPerm;
        }

        #endregion

        #region ISecurityEncodable Members

        public void FromXml(SecurityElement e)
        {
            throw new NotSupportedException("ClaimsPrincipalPermission cannot be loaded from XML.");
        }

        public SecurityElement ToXml()
        {
            throw new NotSupportedException("ClaimsPrincipalPermission cannot be saved to XML.");
        }

        #endregion
    }
}
