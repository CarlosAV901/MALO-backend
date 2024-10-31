


namespace MALO.Microservice.Documentos.Infraestructure
{
    public static class DContainer
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionSettingsSection = configuration.GetSection(ConnectionsSettings.SectionName);
            var connectionSettings = connectionSettingsSection.Get<ConnectionsSettings>();

            services
            .Configure<ConnectionsSettings>(connectionSettingsSection)
            .AddDbContext<ManosALaObraContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(3600),
                    errorNumbersToAdd: null);
                    sqlOptions.CommandTimeout(3600);
                });
            });
            //Add config cors
            //add config JWT

            services.AddScoped<IUnitRepository, UnitRepository>();
            return services;
        }
    }
}
