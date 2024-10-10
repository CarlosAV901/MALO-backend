using MALO.Microservice.Empleosdb.Aplication.Controllers;
using MALO.Microservice.Empleosdb.Aplication.Interfaces.Controllers;
using MALO.Microservice.Empleosdb.Aplication.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace MALO.Microservice.Empleosdb.Aplication
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
