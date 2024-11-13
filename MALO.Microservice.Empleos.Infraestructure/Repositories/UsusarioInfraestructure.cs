using MALO.Microservice.Empleos.Domain.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<string> InsertarUsuario(UsuarioInsertarDto usuarioInsertarDto)
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
                var estado = new SqlParameter { ParameterName = "estado" , SqlDbType = SqlDbType.NVarChar, Value = usuarioInsertarDto.estado };
                var municipio = new SqlParameter { ParameterName = "municipio", SqlDbType = SqlDbType.NVarChar, Value = usuarioInsertarDto.municipio };
                var localidad = new SqlParameter { ParameterName = "localidad", SqlDbType = SqlDbType.NVarChar, Value = usuarioInsertarDto.localidad };
                var Usuario_id = new SqlParameter { ParameterName = "Usuario_id", SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Output };
                var habilidad = new SqlParameter { ParameterName = "habilidad", SqlDbType = SqlDbType.NVarChar, Value = usuarioInsertarDto.habilidades };
                var descripcion = new SqlParameter { ParameterName = "descripcion", SqlDbType = SqlDbType.NVarChar, Value = usuarioInsertarDto.descripcion };
                var imagen_perfil = new SqlParameter { ParameterName = "imagen_perfil", SqlDbType = SqlDbType.NVarChar, Value = usuarioInsertarDto.imagen_perfil };
                var token = new SqlParameter { ParameterName = "token", SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Output };

                SqlParameter[] parameters =
                {
                    nombre,
                    apellido,
                    email,
                    contrasena,
                    fecha_nacimiento,
                    telefono,
                    estado,
                    municipio,
                    localidad,
                    Usuario_id,
                    habilidad,
                    descripcion,
                    imagen_perfil,
                    token
                };

                string sqlQuery = "EXEC dbo.sp_InsertarUsuario @nombre," +
                    "@apellido, " +
                    "@email, " +
                    "@contrasena, " +
                    "@fecha_nacimiento," +
                    "@telefono, " +
                    "@estado," +
                    "@municipio," +
                    "@localidad," +
                    "@Usuario_id OUTPUT," +
                    "@habilidad," +
                    "@descripcion," +
                    "@imagen_perfil," +
                    "@token OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                usuarioInsertarDto.token = (Guid)token.Value;


                return "Usuario Insertado correctamente";



            }
            catch(SqlException ex){
                throw;
            }
        }

        public async Task<(string mensaje, int numError)> ConfirmarUsuario(Guid token)
        {
            try
            {
                var tokenParam = new SqlParameter { ParameterName = "token", SqlDbType = SqlDbType.UniqueIdentifier, Value = token };
                var resultadoDb = new SqlParameter { ParameterName = "Resultado", SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Output };
                var NumError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

                SqlParameter[] parameters =
                {
                    tokenParam,
                    resultadoDb,
                    NumError
                };

                string sqlQuery = "EXEC SP_ConfirmarUsuario @token, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                string mensajeResultado = resultadoDb.Value.ToString();
                int codigoError = (int)NumError.Value;

                return (mensajeResultado, codigoError);

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Guid> GenerarNuevoToken(string email)
        {
            try
            {
                var emailParam = new SqlParameter { ParameterName = "email", SqlDbType = SqlDbType.NVarChar, Value = email };
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

                string sqlQuery = "EXEC dbo.SP_GenerarNuevoToken @email, @Resultado OUTPUT, @NumError OUTPUT, @token OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                if ((int)NumError.Value != 0)
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


        public async Task<string> EliminarUsuario(Guid usuarioId)
        {
            try
            {
                var usuarioIdParam = new SqlParameter
                {
                    ParameterName = "UsuarioId",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = usuarioId
                };
                SqlParameter[] parameters =
                {
                    usuarioIdParam
                };
                string sqlQuery = "EXEC dbo.sp_EliminarUsuario @UsuarioId";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return "Usuario Eliminado Correctamente";

            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<string> ObtenerContenido([FromBody] ObtenerUsuarioPorId request)
        {
            try
            {
                var idUsuario = new SqlParameter { ParameterName = "UsuarioId", SqlDbType = SqlDbType.UniqueIdentifier, Value = request.Id };
                var contenidoActual = new SqlParameter { ParameterName = "ContenidoActual", SqlDbType = SqlDbType.NVarChar, Size = 4000, Direction = ParameterDirection.Output };
                var resultadoBD = new SqlParameter
                {
                    ParameterName = "Resultado",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };
                var NumError = new SqlParameter
                {
                    ParameterName = "NumError",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                SqlParameter[] parameters = {
                    idUsuario,
                    contenidoActual,
                    resultadoBD,
                    NumError
                };

                string sqlQuery = "EXEC SP_ContenidoActual @UsuarioId, @ContenidoActual OUTPUT, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return contenidoActual.Value != DBNull.Value ? (string)contenidoActual.Value : null;

            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<ActualizarUsuarioDTO> ActualizarUsuario(Guid UsuarioId, ActualizarUsuarioDTO actualizarUsuarioDTO)
        {
            try
            {
                var usuarioExistente = await ObtenerUsuarioPorId(UsuarioId);
                if (usuarioExistente == null)
                {
                    throw new Exception("El usuario no existe en la base de datos");
                }

                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@Usuario_Id", SqlDbType.UniqueIdentifier) { Value = UsuarioId }
        };
                if (!string.IsNullOrEmpty(actualizarUsuarioDTO.nombre))
                    parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar) { Value = actualizarUsuarioDTO.nombre });

                if (!string.IsNullOrEmpty(actualizarUsuarioDTO.apellido))
                    parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar) { Value = actualizarUsuarioDTO.apellido });

                if (!string.IsNullOrEmpty(actualizarUsuarioDTO.email))
                    parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar) { Value = actualizarUsuarioDTO.email });

                if (!string.IsNullOrEmpty(actualizarUsuarioDTO.telefono))
                    parameters.Add(new SqlParameter("@telefono", SqlDbType.NVarChar) { Value = actualizarUsuarioDTO.telefono });

                if (!string.IsNullOrEmpty(actualizarUsuarioDTO.estado))
                    parameters.Add(new SqlParameter("@estado", SqlDbType.NVarChar) { Value = actualizarUsuarioDTO.estado });

                if (!string.IsNullOrEmpty(actualizarUsuarioDTO.municipio))
                    parameters.Add(new SqlParameter("@municipio", SqlDbType.NVarChar) { Value = actualizarUsuarioDTO.municipio });

                if (!string.IsNullOrEmpty(actualizarUsuarioDTO.localidad))
                    parameters.Add(new SqlParameter("@localidad", SqlDbType.NVarChar) { Value = actualizarUsuarioDTO.localidad });

                if (!string.IsNullOrEmpty(actualizarUsuarioDTO.habilidades))
                    parameters.Add(new SqlParameter("@habilidades", SqlDbType.NVarChar) { Value = actualizarUsuarioDTO.habilidades });

                if (!string.IsNullOrEmpty(actualizarUsuarioDTO.descripcion))
                    parameters.Add(new SqlParameter("@descripcion", SqlDbType.NVarChar) { Value = actualizarUsuarioDTO.descripcion });

                if (!string.IsNullOrEmpty(actualizarUsuarioDTO.imagen_perfil))
                    parameters.Add(new SqlParameter("@imagen_perfil", SqlDbType.NVarChar) { Value = actualizarUsuarioDTO.imagen_perfil });

                string sqlQuery = "EXEC sp_ActualizarUsuario @Usuario_Id, @nombre, @apellido, @email, @telefono, @estado, @municipio, @localidad, @habilidades, @descripcion, @imagen_perfil";
                var dataSp = await _context.actualizarUsuarioDto.FromSqlRaw(sqlQuery, parameters.ToArray()).ToListAsync();

                return dataSp.FirstOrDefault();

            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<UsuarioConDetallesDTO> ValidarUsuario(string email, string contrasena)
        {
            try
            {
                var resultadoDb = new SqlParameter {ParameterName = "Resultado", SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Output};
                var NumError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                var contrasenaUS = new SqlParameter { ParameterName = "contrasena", SqlDbType = SqlDbType.NVarChar, Value = contrasena };
                var emailUS = new SqlParameter { ParameterName = "email", SqlDbType = SqlDbType.NVarChar, Value= email };

                SqlParameter[] parameters =
                {
                    emailUS, 
                    contrasenaUS,
                    resultadoDb,
                    NumError
                };
                string sqlQuery = "EXEC dbo.SP_ValidarUsuario @email, @contrasena, @Resultado OUTPUT, @NumError OUTPUT";
                var dataSP = await _context.usuarioDtoDetalles.FromSqlRaw(sqlQuery, parameters).ToListAsync();

                if((int)NumError.Value != 1)
                {
                    throw new Exception((string)resultadoDb.Value);
                }

                return dataSP.FirstOrDefault();

            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}
