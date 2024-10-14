

namespace MALO.Microservice.Empleos.Infraestructure.Repositories
{
    public class RolesInfraestructure : IRoleInfraestructure
    {
        private readonly ManosALaObraContext _context;

        public RolesInfraestructure(ManosALaObraContext context)
        {
            _context = context;
        }

        public async Task<List<ObtenerRolesDTO>> ObtenerRoles()
        {
            try
            {
                var resultadoDb = new SqlParameter
                {
                    ParameterName = "Resultado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };
                var NumError = new SqlParameter
                {
                    ParameterName = "NumError",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlParameter[] parameters =
                {
                    resultadoDb,
                    NumError
                };
                string sqlQuery = "EXEC [dbo].[ObtenerRoles] @Resultado OUTPUT, @NumError OUTPUT";
                var dataSP = await _context.obtenerRolesDTO.FromSqlRaw(sqlQuery, parameters).ToListAsync();

                return dataSP;

            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<ObtenerRolesDTO> ObtenerRolPorId(int rolId)
        {
            try
            {
                var resultadoDb = new SqlParameter { ParameterName = "Resultado", SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Output };
                var NumError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                var id = new SqlParameter { ParameterName = "id", SqlDbType = SqlDbType.Int, Value = rolId };

                SqlParameter[] parameters =
                {
                    resultadoDb,
                    NumError,
                    id
                };

                string sqlQuery = "EXEC ObtenerRolPorId @id, @Resultado OUTPUT, @NumError OUTPUT";
                var dataSp = await _context.obtenerRolesDTO.FromSqlRaw(sqlQuery, parameters).ToListAsync();

                return dataSp.FirstOrDefault();

            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<ActualizarRolDTO> ActualizarRol(int id, ActualizarRolDTO actualizarRolDTO)
        {
            try
            {
                //var usuarioExistene = await ObtenerUsuarioPorId(usuarioId);

                //if (usuarioExistene == null)
                //{
                //    throw new Exception("El usuario no existe en la base de datos");
                //}


                var resultadoDb = new SqlParameter { ParameterName = "Resultado", SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Output };
                var NumError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                var rolId = new SqlParameter { ParameterName = "id", SqlDbType = SqlDbType.Int, Value = id };
                var nombre = new SqlParameter { ParameterName = "nombre", SqlDbType = SqlDbType.NVarChar, Value = actualizarRolDTO.nombre };
                var descripcion = new SqlParameter { ParameterName = "descripcion", SqlDbType = SqlDbType.NVarChar, Value = actualizarRolDTO.descripcion };
                var nivel_acceso = new SqlParameter { ParameterName = "nivel_acceso", SqlDbType = SqlDbType.Int, Value = actualizarRolDTO.nivel_acceso };

                SqlParameter[] parameters =
                {
                    rolId,
                    nombre,
                    descripcion,
                    nivel_acceso,
                    resultadoDb,
                    NumError
                };
                string sqlQuery = "EXEC sp_ActualizarRol @id, @nombre, @descripcion, @nivel_acceso, @Resultado OUTPUT, @NumError OUTPUT";
                var dataSp = await _context.actualizarRolDTO.FromSqlRaw(sqlQuery, parameters).ToListAsync();

                return dataSp.FirstOrDefault();

            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}
