using Swashbuckle.AspNetCore.SwaggerGen;

namespace MALO.Microservice.Empleosdb.API.Swagger.Filters
{
    public class SwaggerFileUploadFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fileParams = context.ApiDescription.ParameterDescriptions
                .Where(p => p.Type == typeof(IFormFile));

            foreach (var param in fileParams)
            {
                var fileParam = new OpenApiParameter
                {
                    Name = param.Name,
                    In = ParameterLocation.Path,
                    Required = false,
                    Schema = new OpenApiSchema { Type = "string", Format = "binary" }
                };

                operation.Parameters.Add(fileParam);
            }
        }
    }
}
