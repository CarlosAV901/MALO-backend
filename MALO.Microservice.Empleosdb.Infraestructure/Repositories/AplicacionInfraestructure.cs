
using Microsoft.Identity.Client;
using Org.BouncyCastle.Crypto.Operators;

namespace MALO.Microservice.Empleosdb.Infraestructure.Repositories
{
    internal class AplicacionInfraestructure: IAplicacionInfraestructure
    {
        private readonly ManosALaObraContext _context;

        public AplicacionInfraestructure(ManosALaObraContext context)
        {
            _context = context;
        }


        public async Task<List<ObtenerUsuariosPorEmpleosDTO>> ObtenerUsuariosPorEmpleos(Guid id)
        {
            try
            {
                var resultadoBD = new SqlParameter { ParameterName = "Resultado", SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Output };
                var NumError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                var empleoId = new SqlParameter { ParameterName = "EmpleoID", SqlDbType = SqlDbType.UniqueIdentifier, Value = id };

                SqlParameter[] parameters =
                {
                    resultadoBD,
                    NumError,
                    empleoId
                };

                string sqlQuery = "EXEC SP_ObtenerUsuariosPorEmpleo @EmpleoId, @Resultado OUTPUT, @NumError OUTPUT";
                var dataSP = await _context.obtenerUsuariosPorEmpleosDTO.FromSqlRaw(sqlQuery,parameters).ToListAsync();

                return dataSP;

            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<int> ContarAplicacionesPorEmpleo(Guid id)
        {
            try
            {
                var resultadoBD = new SqlParameter { ParameterName = "Resultado", SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Output };
                var NumError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                var empleoId = new SqlParameter { ParameterName = "EmpleoID", SqlDbType = SqlDbType.UniqueIdentifier, Value = id };
                var total = new SqlParameter { ParameterName = "TotalAplicantes", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

                SqlParameter[] parameters =
                {
                    resultadoBD,
                    total,
                    NumError,
                    empleoId
                };

                string sqlQuery = "EXEC SP_ContarAplicacionesPorEmpleo @EmpleoID, @TotalAplicantes OUTPUT, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return (int)total.Value;

            }
            catch (SqlException ex) { throw; }
        }


        public async Task<List<ObtenerEmpleosPorUsuarioDTO>> ObtenerEmpleosPorUsuario(Guid id)
        {
            try
            {
                var usuarioId = new SqlParameter { ParameterName = "UsuarioID", SqlDbType = SqlDbType.UniqueIdentifier,Value = id};
                var resultadoBD = new SqlParameter { ParameterName = "Resultado", SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Output };
                var NumError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

                SqlParameter[] parameters =
                {
                    usuarioId,
                    resultadoBD,
                    NumError
                };

                string sqlQuery = "EXEC SP_ObtenerEmpleosPorUsuario @UsuarioID, @Resultado OUTPUT, @NumError OUTPUT";
                var dataSP = await _context.obtenerEmpleosPorUsuarioDTO.FromSqlRaw(sqlQuery, parameters).ToListAsync();

                return dataSP;

            }
            catch (SqlException ex) { throw; }
        }

        public async Task<string> AplicarAEmpleo([FromBody] AplicarEmpleoDTO request)
        {
            try
            {
                var usuarioId = new SqlParameter { ParameterName = "UsuarioID", SqlDbType = SqlDbType.UniqueIdentifier, Value = request.UsuarioID };
                var empleoId = new SqlParameter { ParameterName = "EmpleoID", SqlDbType= SqlDbType.UniqueIdentifier, Value = request.EmpleoID };
                var resultadoBD = new SqlParameter { ParameterName = "Resultado", SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Output };
                var NumError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

                SqlParameter[] parameters =
                {
                    usuarioId,
                    empleoId,
                    resultadoBD,
                    NumError
                };

                string sqlQuery = "EXEC SP_AplicarAEmpleo @UsuarioID, @EmpleoID, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                

                return resultadoBD.Value.ToString();

            }
            catch (SqlException ex) { throw; }
        }

        public async Task<string> ElimarAplicacion([FromBody] AplicarEmpleoDTO request)
        {
            try
            {
                var usuarioId = new SqlParameter { ParameterName = "UsuarioID", SqlDbType = SqlDbType.UniqueIdentifier, Value = request.UsuarioID };
                var empleoId = new SqlParameter { ParameterName = "EmpleoID", SqlDbType = SqlDbType.UniqueIdentifier, Value = request.EmpleoID };
                var resultadoBD = new SqlParameter { ParameterName = "Resultado", SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Output };
                var NumError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

                SqlParameter[] parameters =
                {
                    usuarioId,
                    empleoId,
                    resultadoBD,
                    NumError
                };

                string sqlQuery = "EXEC SP_EliminarAplicacion @UsuarioID, @EmpleoID, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return resultadoBD.Value.ToString();


            }
            catch (SqlException ex) { throw; }
        }

    }
}
