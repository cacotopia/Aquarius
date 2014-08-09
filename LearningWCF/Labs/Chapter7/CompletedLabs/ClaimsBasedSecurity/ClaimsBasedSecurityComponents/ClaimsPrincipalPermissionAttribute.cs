// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;
using System.IdentityModel.Claims;

namespace ClaimsBasedSecurityComponents
{

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class ClaimsPrincipalPermissionAttribute : CodeAccessSecurityAttribute
    {

        private bool m_isAuthenticated;
        private ClaimSet m_issuer;
        private string m_requiredClaim;

        public ClaimsPrincipalPermissionAttribute(SecurityAction action)
            : base(action)
        {
            this.m_isAuthenticated = true;
        }

        public string IssuerName
        {
            get
            {
                string name = "";
                if (m_issuer != null)
                {
                    name = m_issuer[0].Resource as string;
                }
                return name;
            }
            set
            {
                Claim c = Claim.CreateNameClaim(value);
                Claim[] claims = new Claim[1];
                claims[0] = c;
                m_issuer = new DefaultClaimSet(claims);
            }
        }

        public string RequiredClaim
        {
            get
            {
                return this.m_requiredClaim;
            }
            set
            {
                this.m_requiredClaim = value;
            }
        }

        public bool Authenticated
        {
            get { return m_isAuthenticated; }
            set { m_isAuthenticated = value; }
        }

        public override System.Security.IPermission CreatePermission()
        {
            return new ClaimsPrincipalPermission(this.m_isAuthenticated, this.IssuerName, this.m_requiredClaim);
        }
        
    }
}
