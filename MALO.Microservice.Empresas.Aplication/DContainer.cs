using MALO.Microservice.Empresas.Aplication.Controllers;
using MALO.Microservice.Empresas.Aplication.Interfaces.Controllers;
using MALO.Microservice.Empresas.Aplication.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace MALO.Microservice.Empresas.Aplication
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
