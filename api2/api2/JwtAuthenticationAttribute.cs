using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace api2
{
    public class JwtAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var request = actionContext.Request;
            var authorization = request.Headers.Authorization;
            
            if (authorization == null || authorization.Scheme != "Bearer")
                return;
            
            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                throw new HttpException(403, "Forbidden");
            }
            string username;
            var token = authorization.Parameter;

            if (ValidateToken(token, out username))
            {
                //----------
            }
            else
            {
                throw new HttpException(403, "Forbidden");
            }
            
      
        }
        
        private static bool ValidateToken(string token, out string username)
        {
            username = null;

			token = token.Replace("\"", string.Empty);

            var simplePrinciple = new JwtManager().GetPrincipal(token);
            var identity = simplePrinciple.Identity as ClaimsIdentity;

            if (identity == null)
                return false;

            if (!identity.IsAuthenticated)
                return false;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim?.Value;

            if (string.IsNullOrEmpty(username))
                return false;

            // More validate to check whether username exists in system

            return true;
        }
    }
}