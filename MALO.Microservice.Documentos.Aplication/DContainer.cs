using MALO.Microservice.Documentos.Aplication.Controllers;
using MALO.Microservice.Documentos.Aplication.Interfaces.Controllers;
using MALO.Microservice.Documentos.Aplication.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace MALO.Microservice.Documentos.Aplication
{
    public static class DContainer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IApiController, ApiController>();
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            //Add new aggregates


            return services;
        }
    }
}
