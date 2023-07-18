using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace WebStoreAPI.Authorization
{
    public class ClaimAuthorizationFilter : IAuthorizationFilter
    {
        readonly Claim _claim;

        public ClaimAuthorizationFilter(Claim claim)
        {
            _claim = claim;
        
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);
            if (!hasClaim)
            {
                context.Result = new ForbidResult();
            }
        }
    }
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(string claimType, string claimValue) : base(typeof(ClaimAuthorizationFilter))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }
    }
}
