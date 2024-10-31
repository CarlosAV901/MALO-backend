using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.RegularExpressions;

namespace MALO.Microservice.Empresas.API.Swagger.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class OperationFilter : IOperationFilter
    {
        const string captureName = "routeParameter";
        const string regex = $"{{(?<{captureName}>\\w+)\\?}}";

        /// <summary>24
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var metaData = context.ApiDescription.ActionDescriptor.EndpointMetadata;
            var isAuthorize = metaData.Any(item => item is AuthorizeAttribute);

            if (isAuthorize)
            {
                var jwtbearerScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                };

                operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    [ jwtbearerScheme ] = Array.Empty<string>()
                }
            };

                operation.Parameters ??= new List<OpenApiParameter>();

                operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });
            }

            #region Optional_Route_Parameter

            var httpMethodAttr = context.MethodInfo
                .GetCustomAttributes(true)
                .OfType<HttpMethodAttribute>();

            var httpMethodWithOptional = httpMethodAttr?.FirstOrDefault(m => m.Template?.Contains('?') ?? false);
            if (httpMethodWithOptional == null)
                return;

            foreach (Match match in Regex.Matches(httpMethodWithOptional.Template, regex))
            {
                var name = match.Groups[captureName].Value;

                var parameter = operation
                                .Parameters
                                .FirstOrDefault(p => p.In == ParameterLocation.Path &&
                                                     p.Name == name);

                if (parameter != null)
                {
                    parameter.Description = "Must check \"Send empty value\" or Swagger passes a comma for empty values otherwise";
                    parameter.Required = false;
                    parameter.Schema.Default = new Microsoft.OpenApi.Any.OpenApiString(null);
                    parameter.AllowEmptyValue = true;
                    parameter.Schema.Nullable = true;
                }
            }

            #endregion
        }
    }
}
