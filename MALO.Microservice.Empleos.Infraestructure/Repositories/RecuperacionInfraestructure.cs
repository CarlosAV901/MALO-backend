

using MALO.Microservice.Empleos.Domain.DTOs.Recuperacion;

namespace MALO.Microservice.Empleos.Infraestructure.Repositories
{

    public class RecuperacionInfraestructure : IRecuperacionInfraestructure
    {
        private readonly ManosALaObraContext _context;

        public RecuperacionInfraestructure(ManosALaObraContext context)
        {
            _context = context;
        }

        public async Task<Guid> GenerarTokenRecuperacion(string email)
        {
            try
            {
                var emailParam = new SqlParameter { ParameterName = "email", SqlDbType = SqlDbType.NVarChar, Value = email};
                var tokenParam = new SqlParameter { ParameterName = "token", SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Output };
                var resultadoDb = new SqlParameter { ParameterName = "Resultado", SqlDbType = SqlDbType.NVarChar, Size = 100, Direction = ParameterDirection.Output };
                var NumError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

                SqlParameter[] parameters =
                {
                    emailParam,
                    tokenParam,
                    resultadoDb,
                    NumError
                };

                string sqlQuery = "EXEC dbo.SP_GenerarTokenRecuperacion @email, @Resultado OUTPUT, @NumError OUTPUT, @token OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                if((int)NumError.Value != 0)
                {
                    throw new Exception((string)resultadoDb.Value);
                }

                // Verifica si el token es DBNull antes de hacer la conversión
                if (tokenParam.Value == DBNull.Value)
                {
                    throw new Exception("Error al generar el token de recuperación.");
                }



                return (Guid)tokenParam.Value;

            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<bool> VerificarToken(Guid token)
        {
            try
            {
                var tokenParam = new SqlParameter { ParameterName = "token", SqlDbType = SqlDbType.UniqueIdentifier, Value = token };
                var resultadoDb = new SqlParameter { ParameterName = "Resultado", SqlDbType = SqlDbType.NVarChar, Size = 100, Direction= ParameterDirection.Output };   
                var numError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                var tokenValido = new SqlParameter { ParameterName = "tokenValido", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                SqlParameter[] parameters =
                {
                    tokenParam,
                    resultadoDb,
                    numError,
                    tokenValido
                };

                string sqlQuery = "EXEC dbo.SP_VerificarTokenRecuperacion @token, @tokenValido OUTPUT, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery,parameters);

                if (!(bool)tokenValido.Value)
                {
                    throw new Exception((string)resultadoDb.Value);
                }

                return (bool)tokenValido.Value;

            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<(string mensaje, int numError)> ActualizarContrasena(Guid token, string nuevaContrasena)
        {
            try
            {
                var tokenParam = new SqlParameter { ParameterName = "token", SqlDbType = SqlDbType.UniqueIdentifier, Value = token };
                var nuevaContrasenaParam = new SqlParameter { ParameterName = "nuevaContrasena", SqlDbType = SqlDbType.NVarChar, Value = nuevaContrasena };
                var resultadoDb = new SqlParameter { ParameterName = "Resultado", SqlDbType = SqlDbType.NVarChar, Size = 100, Direction = ParameterDirection.Output };
                var numError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

                SqlParameter[] parameters =
                {
                    tokenParam,
                    nuevaContrasenaParam,
                    resultadoDb,
                    numError
                };

                string sqlQuery = "EXEC dbo.SP_CambiarContrasena @token, @nuevaContrasena, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                string mensajeResultado = resultadoDb.Value.ToString();
                int codigoError = (int)numError.Value;

                return (mensajeResultado, codigoError);

            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}
