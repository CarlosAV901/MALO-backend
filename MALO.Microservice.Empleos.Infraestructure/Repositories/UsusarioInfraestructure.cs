


using MALO.Microservice.Empleos.Domain.Interfaces.Infraestructure;

namespace MALO.Microservice.Empleos.Infraestructure.Repositories
{
    public class UsusarioInfraestructure: IUsuarioInfraestructure
    {
        private readonly ManosALaObraContext _context;

        public UsusarioInfraestructure(ManosALaObraContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Consulta un registro de la tabla GI_Persona
        /// </summary>
        /// <returns></returns>
        public async Task<UsuarioDto> GetUser()
        {
            try
            {
                var resultadoBD = new SqlParameter
                {
                    ParameterName = "Resultado", // Cambiado de "TipoError" a "Resultado"
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };
                var NumError = new SqlParameter
                {
                    ParameterName = "NumError", // Cambiado de "Mensaje" a "NumError"
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlParameter[] parameters =
                {
                resultadoBD,
                NumError
            };
                string sqlQuery = "EXEC dbo.SP_ConsultarUsuarios @Resultado OUTPUT, @NumError OUTPUT";
                var dataSP = await _context.usuarioDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}
