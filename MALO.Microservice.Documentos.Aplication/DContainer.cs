

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
