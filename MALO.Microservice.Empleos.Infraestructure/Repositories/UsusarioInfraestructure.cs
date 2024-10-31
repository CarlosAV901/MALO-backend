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

        public async Task<string> ConfirmarUsuario(Guid token)
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

                return "Correo confirmado correctamente";


            }catch (SqlException ex)
            {
                throw new Exception(ex.Message);
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

        public async Task<ActualizarUsuarioDTO> ActualizarUsuario(Guid UsuarioId, ActualizarUsuarioDTO actualizarUsuarioDTO)
        {
            try
            {
                var usuarioExistene = await ObtenerUsuarioPorId(UsuarioId);

                if (usuarioExistene == null)
                {
                    throw new Exception("El usuario no existe en la base de datos");
                }

                var resultadoDb = new SqlParameter { ParameterName = "Resultado", SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Output };
                var NumError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

                var usuarioIdParam = new SqlParameter { ParameterName = "UsuarioId", SqlDbType = SqlDbType.UniqueIdentifier, Value = UsuarioId };
                var nombre = new SqlParameter { ParameterName = "nombre", SqlDbType = SqlDbType.NVarChar, Value = actualizarUsuarioDTO.nombre ?? usuarioExistene.nombre };
                var apellido = new SqlParameter { ParameterName = "apellido", SqlDbType = SqlDbType.NVarChar, Value = actualizarUsuarioDTO.apellido ?? usuarioExistene.apellido };
                var email = new SqlParameter { ParameterName = "email", SqlDbType = SqlDbType.NVarChar, Value = actualizarUsuarioDTO.email ?? usuarioExistene.email };
                var telefono = new SqlParameter { ParameterName = "telefono", SqlDbType = SqlDbType.NVarChar, Value = actualizarUsuarioDTO.telefono ?? usuarioExistene.email };
                var estado = new SqlParameter { ParameterName = "estado", SqlDbType = SqlDbType.NVarChar, Value = actualizarUsuarioDTO.estado};
                var municipio = new SqlParameter { ParameterName = "municipio", SqlDbType = SqlDbType.NVarChar, Value = actualizarUsuarioDTO.municipio };
                var localidad = new SqlParameter { ParameterName = "localidad", SqlDbType = SqlDbType.NVarChar, Value = actualizarUsuarioDTO.localidad};
                var habilidad = new SqlParameter { ParameterName = "habilidad", SqlDbType = SqlDbType.NVarChar, Value = actualizarUsuarioDTO.habilidades ?? usuarioExistene.Habilidades};
                var descripcion = new SqlParameter { ParameterName = "descripcion", SqlDbType = SqlDbType.NVarChar, Value = actualizarUsuarioDTO.descripcion ?? usuarioExistene.Experiencias };
                var imagen_perfil = new SqlParameter { ParameterName = "imagen_perfil", SqlDbType = SqlDbType.NVarChar, Value = actualizarUsuarioDTO.imagen_perfil ?? usuarioExistene.ImagenPerfil};

                SqlParameter[] parameters =
                {
                    usuarioIdParam,
                    nombre,
                    apellido,
                    email,
                    telefono,
                    estado,
                    municipio,
                    localidad,
                    habilidad,
                    descripcion,
                    imagen_perfil
                };

                string sqlQuery = "EXEC sp_ActualizarUsuario @UsuarioId, @nombre, @apellido, @email, @telefono, @estado, @municipio, @localidad, @habilidad, @descripcion, @imagen_perfil";

                var dataSp = await _context.actualizarUsuarioDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();

                return dataSp.FirstOrDefault();


            }
            catch(SqlException ex)
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
