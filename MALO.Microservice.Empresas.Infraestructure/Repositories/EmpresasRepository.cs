using Dapper;
using MALO.Microservice.Empresas.Domain.Interfaces.Infraestructure;

namespace MALO.Microservice.Empresas.Infrastructure.Repositories
{
    public class EmpresasRepository : IEmpresasRepository
    {
        private readonly ManosALaObraContextEmpresas _context;

        public EmpresasRepository(ManosALaObraContextEmpresas context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmpresaDto>> ConsultarEmpresas()
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("Resultado", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);
                parameters.Add("NumError", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var empresas = await connection.QueryAsync<EmpresaDto>(
                    "dbo.SP_ConsultarEmpresas",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                var resultado = parameters.Get<string>("Resultado");
                var numError = parameters.Get<int>("NumError");

                if (numError != 1)
                {
                    throw new Exception($"Error en la consulta: {resultado}");
                }

                return empresas;
            }
        }

        public async Task AgregarEmpresa(EmpresaDto nuevaEmpresa)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("Nombre", nuevaEmpresa.Nombre, DbType.String);
                parameters.Add("Industria", nuevaEmpresa.Industria, DbType.String);
                parameters.Add("Ubicacion", nuevaEmpresa.Ubicacion, DbType.String);
                parameters.Add("Resultado", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);
                parameters.Add("NumError", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await connection.ExecuteAsync(
                    "dbo.SP_AgregarEmpresa",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                var resultado = parameters.Get<string>("Resultado");
                var numError = parameters.Get<int>("NumError");

                if (numError != 1)  // Si no es exitoso, manejar el error
                {
                    if (numError == 2)
                    {
                        // Empresa ya existe, lanzar excepción personalizada
                        throw new InvalidOperationException($"La empresa '{nuevaEmpresa.Nombre}' ya está registrada.");
                    }

                    throw new Exception($"Error al agregar la empresa: {resultado}");
                }
            }
        }

        public async Task<EmpresaDto> ConsultarEmpresaPorId(string empresaId)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("EmpresaId", empresaId);
                parameters.Add("Resultado", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);
                parameters.Add("NumError", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var empresa = await connection.QuerySingleOrDefaultAsync<EmpresaDto>(
                    "dbo.SP_ConsultarEmpresaPorId",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                var resultado = parameters.Get<string>("Resultado");
                var numError = parameters.Get<int>("NumError");

                if (numError != 1)
                {
                    throw new Exception($"Error en la consulta: {resultado}");
                }

                return empresa;
            }
        }

        // Nuevo método para consultar una empresa por ID
        public async Task<EmpresaDto> ConsultarEmpresaPorId2(string empresaId)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("EmpresaId", empresaId, DbType.String);
                parameters.Add("Resultado", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);
                parameters.Add("NumError", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var empresa = await connection.QuerySingleOrDefaultAsync<EmpresaDto>(
                    "dbo.SP_ConsultarEmpresaPorId",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                var resultado = parameters.Get<string>("Resultado");
                var numError = parameters.Get<int>("NumError");

                if (numError != 1) // Si no es exitoso, manejar el error
                {
                    if (numError == 2)
                    {
                        throw new InvalidOperationException($"ID de empresa no válido.");
                    }
                    else if (numError == 3)
                    {
                        throw new KeyNotFoundException($"Empresa no encontrada.");
                    }

                    throw new Exception($"Error en la consulta: {resultado}");
                }

                return empresa;
            }
        }

        public async Task EliminarEmpresaPorId(string id)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("EmpresaId", Guid.Parse(id), dbType: DbType.Guid);
                parameters.Add("Resultado", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);
                parameters.Add("NumError", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await connection.ExecuteAsync("dbo.SP_EliminarEmpresaPorId", parameters, commandType: CommandType.StoredProcedure);

                var resultado = parameters.Get<string>("Resultado");
                var numError = parameters.Get<int>("NumError");

                if (numError != 1)
                {
                    throw new Exception($"Error al eliminar la empresa: {resultado}");
                }
            }
        }
    }
}