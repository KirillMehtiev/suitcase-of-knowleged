using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.Facebook;

namespace FacebookIntegration.Providers
{
    public class FacebookAuthProvider : FacebookAuthenticationProvider
    {
        public override Task Authenticated(FacebookAuthenticatedContext context)
        {
            context.Identity.AddClaim(new Claim("ExternalAccessToken", context.AccessToken));
            //new Claim(ClaimTypes.Authentication, context.AccessToken, ClaimValueTypes.String)
            //context.Identity.AddClaim(new Claim(ClaimTypes.Authentication, context.AccessToken, ClaimValueTypes.String));
            return Task.FromResult(0);
        }
    }
}