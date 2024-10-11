namespace MALO.Microservice.Empresas.Infrastructure.DataContexts
{
    public class ManosALaObraContextEmpresas
    {
        private readonly string _connectionString;

        public ManosALaObraContextEmpresas(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new System.Data.SqlClient.SqlConnection(_connectionString);
        }
    }
}
