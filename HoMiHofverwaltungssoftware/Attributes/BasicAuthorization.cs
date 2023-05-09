using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace HoMiHofverwaltungssoftware.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)] 
    public class BasicAuthorization : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();

            if (allowAnonymous)
            {
                return;
            }

            bool user = context.HttpContext.Request.Headers.ContainsKey("1111");
            AuthenticationHeaderValue? authHeader = AuthenticationHeaderValue.Parse(context.HttpContext.Request.Headers["Authorization"]);
            byte[] credentialBytes = Convert.FromBase64String(authHeader.Parameter == null ? "" : authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);

            var username = credentials[0];
            var password = credentials[1];


            if (username != "Test" || password != "test")
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                context.HttpContext.Response.Headers["WWW-Authenticate"] = "Basic realm=\"\", charset = \"UTF-8\"";
            }
        }
    }
}
