using Microsoft.AspNetCore.Mvc.Filters;

namespace MALO.Microservice.Empresas.API.Swagger.Filters
{
    public class AuthenticationLogFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["AuthToken"];
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }
        }
    }
}
