using MALO.Microservice.Empleos.Aplication.Controllers;
using MALO.Microservice.Empleos.Aplication.Interfaces.Controllers;
using MALO.Microservice.Empleos.Aplication.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace MALO.Microservice.Empleo.Aplication
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
