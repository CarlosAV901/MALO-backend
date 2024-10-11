


using MALO.Microservice.Empleos.Domain.Interfaces.Infraestructure;
using Org.BouncyCastle.Tsp;

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

        public async Task<UsuarioConDetallesDTO> ObtenerUsuarioPorId(Guid usuarioId)
        {
            try
            {
                var resultadoDB = new SqlParameter
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
                var usuarioIdParam = new SqlParameter
                {
                    ParameterName = "UsuarioId",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = usuarioId
                };
                SqlParameter[] parameters =
                {
                    usuarioIdParam,
                    resultadoDB,
                    NumError
                };
                string sqlQuery = "EXEC dbo.ObtenerUsuarioConDetalles @UsuarioId, @Resultado OUTPUT, @NumError OUTPUT";
                var dataSP = await _context.usuarioDtoDetalles.FromSqlRaw(sqlQuery, parameters).ToListAsync();

                return dataSP.FirstOrDefault();
            }
            catch(SqlException ex)
            {
                throw;
            }
        }

        public async Task<List<UsuarioConDetallesDTO>> ObtenerUsuarios()
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
                string sqlQuery = "EXEC dbo.ObtenerUsuarios @Resultado OUTPUT, @NumError OUTPUT";
                var dataSP = await _context.usuarioDtoDetalles.FromSqlRaw(sqlQuery, parameters).ToListAsync();

                return dataSP;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<UsuarioConDetallesDTO> InsertarUsuario(UsuarioInsertarDto usuarioInsertarDto)
        {
            try
            {
                var resultadoDb = new SqlParameter { ParameterName = "Resultado", SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Output };
                var NumError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                var nombre = new SqlParameter { ParameterName = "nombre", SqlDbType = SqlDbType.NVarChar, Value = usuarioInsertarDto.nombre };
                var apellido = new SqlParameter { ParameterName = "apellido", SqlDbType = SqlDbType.NVarChar, Value = usuarioInsertarDto.apellido };
                var email = new SqlParameter { ParameterName = "email" ,SqlDbType = SqlDbType.NVarChar, Value = usuarioInsertarDto.email };
                var contrasena = new SqlParameter { ParameterName = "contrasena", SqlDbType= SqlDbType.NVarChar, Value = usuarioInsertarDto.contrasena };
                var fecha_nacimiento = new SqlParameter { ParameterName = "fecha_nacimiento" ,SqlDbType = SqlDbType.Date, Value = usuarioInsertarDto.fecha_nacimiento};
                var telefono = new SqlParameter { ParameterName = "telefono", SqlDbType = SqlDbType.NVarChar, Value = usuarioInsertarDto.telefono };
                var rol_id = new SqlParameter {ParameterName = "rol_id" ,SqlDbType = SqlDbType.Int, Value = usuarioInsertarDto.rol_id };
                var estado_id = new SqlParameter { ParameterName = "estado_id" , SqlDbType = SqlDbType.Int, Value = usuarioInsertarDto.estado_id };
                var municipio_id = new SqlParameter { ParameterName = "municipio_id", SqlDbType = SqlDbType.Int, Value = usuarioInsertarDto.municipio_id };
                var localidad_id = new SqlParameter { ParameterName = "localidad_id", SqlDbType = SqlDbType.Int, Value = usuarioInsertarDto.localidad_id };
                var Usuario_id = new SqlParameter { ParameterName = "Usuario_id", SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Output };
                var habilidad = new SqlParameter { ParameterName = "habilidad", SqlDbType = SqlDbType.NVarChar, Value = usuarioInsertarDto.habilidades };
                var descripcion = new SqlParameter { ParameterName = "descripcion", SqlDbType = SqlDbType.NVarChar, Value = usuarioInsertarDto.descripcion };
                var imagen_perfil = new SqlParameter { ParameterName = "imagen_perfil", SqlDbType = SqlDbType.NVarChar, Value = usuarioInsertarDto.imagen_perfil };

                SqlParameter[] parameters =
                {
                    nombre,
                    apellido,
                    email,
                    contrasena,
                    fecha_nacimiento,
                    telefono,
                    rol_id,
                    estado_id,
                    municipio_id,
                    localidad_id,
                    Usuario_id,
                    habilidad,
                    descripcion,
                    imagen_perfil
                };

                string sqlQuery = "EXEC dbo.sp_InsertarUsuario @nombre," +
                    "@apellido, " +
                    "@email, " +
                    "@contrasena, " +
                    "@fecha_nacimiento," +
                    "@telefono, " +
                    "@rol_id, " +
                    "@estado_id," +
                    "@municipio_id," +
                    "@localidad_id," +
                    "@Usuario_id OUTPUT," +
                    "@habilidad," +
                    "@descripcion," +
                    "@imagen_perfil";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                // Recuperar el ID generado desde el parámetro de salida
                var idGenerado = (Guid)Usuario_id.Value;

                return await ObtenerUsuarioPorId(idGenerado);

            }
            catch(SqlException ex){
                throw;
            }
        }
    }
}
