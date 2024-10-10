using MALO.Microservice.Empleo.Aplication;
using MALO.Microservice.Documentos.API.Swagger.Filters;
using MALO.Microservice.Documentos.Infraestructure;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MALO.Microservice.Documentos.API.Extensions
{
    /// <summary>
    /// Application services
    /// </summary>
    public static class ApplicationServices
    {
        /// <summary>
        /// Inversión de Control (IoC)
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddApplication().AddInfrastructure(configuration);
            return services;
        }

        /// <summary>
        /// Service Swagger configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="builder"></param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services, WebApplicationBuilder builder)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                //Following code to avoid swagger generation error 
                //due to same method name in different versions.
                options.ResolveConflictingActions(descriptions =>
                {
                    return descriptions.First();
                });
                options.CustomSchemaIds(type => type.ToString());

                var groupName = "v1";
                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"CE.Chepeat.API",
                    Version = groupName
                    //Description = " API "

                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: '12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.OperationFilter<OperationFilter>();
                options.DocumentFilter<DocumentFilter>();
            });

            return services;
        }
    }
}
