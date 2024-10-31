namespace MALO.Microservice.Empresas.Infraestructure
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
            .AddDbContext<ManosALaObraContextEmpresasDos>(options =>
            {
                options.UseSqlServer( Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? configuration.GetConnectionString("DbConnection"),
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

            services.AddScoped<IUnitRepositoryEmpresas, UnitRepositoryEmpresas>();
            return services;
        }
    }
}
