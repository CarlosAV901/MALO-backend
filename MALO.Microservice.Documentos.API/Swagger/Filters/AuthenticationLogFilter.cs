using Microsoft.AspNetCore.Mvc.Filters;

namespace MALO.Microservice.Documentos.API.Swagger.Filters
{
    public class AuthenticationLogFilter: Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["AuthToken"];
            if (String.IsNullOrEmpty(token))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }
        }
    }
}
