


namespace MALO.Microservice.Empleosdb.Infraestructure.Repositories
{
    public class EmpleoInfraestructure : IEmpleoInfraestructure
    {
        private readonly ManosALaObraContext _context;

        public EmpleoInfraestructure(ManosALaObraContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Consulta un registro de la tabla GI_Persona
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmpleosDto>> GetEmpleos()
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
                string sqlQuery = "EXEC dbo.SP_ConsultarEmpleoConMultimedia @Resultado OUTPUT, @NumError OUTPUT";
                var dataSP = await _context.empleoDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<EmpleosDto> GetEmpleoId([FromBody] EmpleoRequestDto request)
        {
            try
            {
                var resultadoBD = new SqlParameter
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

                var EmpleoId = new SqlParameter
                {
                    ParameterName = "Empleo_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.EmpleoId
                };
                SqlParameter[] parameters =
                {
                    EmpleoId,
                    resultadoBD,
                    NumError
                };

                string sqlQuery = "EXEC SP_ConsultarEmpleoConMultimediaPorId @Empleo_id, @Resultado = @Resultado OUTPUT, @NumError = @NumError OUTPUT";
                var dataSP = await _context.empleoDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<string> PostEmpleo([FromBody] EmpleoPostDto request)
        {
            try
            {
                var resultadoBD = new SqlParameter
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
                var Titulo = new SqlParameter
                {
                    ParameterName = "Titulo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 255,
                    Value = request.titulo
                };
                var Descripcion = new SqlParameter
                {
                    ParameterName = "Descripcion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 255,
                    Value = request.descripcion
                };
                var EmpresaId = new SqlParameter
                {
                    ParameterName = "Empresa_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.empresa_id
                };
                var Ubicacion = new SqlParameter
                {
                    ParameterName = "Ubicacion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 255,
                    Value = request.ubicacion
                };
                var SalarioMinimo = new SqlParameter
                {
                    ParameterName = "Salario_minimo",
                    SqlDbType = SqlDbType.Money,
                    Value = request.salario_minimo
                };
                var SalarioMaximo = new SqlParameter
                {
                    ParameterName = "Salario_maximo",
                    SqlDbType = SqlDbType.Money,
                    Value = request.salario_maximo
                };
                var horaraio = new SqlParameter
                {
                    ParameterName = "horario",
                    SqlDbType = SqlDbType.VarChar,
                    Value = request.horario
                };
                var multimediaNombre = new SqlParameter
                {
                    ParameterName = "multimediaNombre",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = request.multimediaNombre
                };
                var multimediaTipo = new SqlParameter
                {
                    ParameterName = "multimediaTipo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = request.multimediaTipo
                };
                var multimediaContenido = new SqlParameter
                {
                    ParameterName = "multimediaContenido",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = request.multimediaContenido
                };


                SqlParameter[] parameters =
                {
                    Titulo,
                    Descripcion,
                    EmpresaId,
                    Ubicacion,
                    SalarioMinimo,
                    SalarioMaximo,
                    horaraio,
                    multimediaNombre,
                    multimediaTipo,
                    multimediaContenido,
                    resultadoBD,
                    NumError
                };

                string sqlQuery = "EXEC dbo.SP_InsertarEmpleoConMultimedia @Titulo, @Descripcion, @Empresa_id, " +
                                  "@Ubicacion, @Salario_minimo, @Salario_maximo, @horario, @multimediaNombre, @multimediaTipo, @multimediaContenido ,@Resultado OUTPUT, @NumError OUTPUT";

                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return resultadoBD.Value.ToString();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<(string mensaje, int numError)> ResgistrarVisualizacion([FromBody] RegistrarVisualizacionDTO request)
        {
            try
            {
                var usuarioId = new SqlParameter { ParameterName = "usuario_id", SqlDbType = SqlDbType.UniqueIdentifier, Value = request.usuario_id };
                var empleoId = new SqlParameter { ParameterName = "empleo_id", SqlDbType = SqlDbType.UniqueIdentifier, Value = request.empleo_id };
                var resultadoBD = new SqlParameter
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
                    usuarioId,
                    empleoId,
                    resultadoBD,
                    NumError
                };

                string sqlQuery = "EXEC sp_RegistrarVisualizacion @usuario_id, @empleo_id, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery,parameters);

                string mensajeResultado = resultadoBD.Value.ToString();
                int codigoError = (int)NumError.Value;

                return (mensajeResultado, codigoError);

            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<int> ObtenerVisualizacionesPorEmpleo([FromBody] EmpleoIdDto request)
        {
            try
            {
                var empleoId = new SqlParameter { ParameterName = "empleo_id", SqlDbType = SqlDbType.UniqueIdentifier, Value = request.EmpleoID };
                var totalVisualizaciones = new SqlParameter { ParameterName = "totalVisualizaciones", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

                SqlParameter[] parameters =
                {
                    empleoId,
                    totalVisualizaciones
                };

                string sqlQuery = "EXEC sp_ObtenerVisualizacionesPorEmpleo @empleo_id, @totalVisualizaciones OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return (int)totalVisualizaciones.Value;

            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<string> ObtenerContenido([FromBody] EmpleoRequestDto request)
        {
            try
            {
                var idUsuario = new SqlParameter { ParameterName = "EmpleoId", SqlDbType = SqlDbType.UniqueIdentifier, Value = request.EmpleoId };
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

                string sqlQuery = "EXEC SP_ContenidoActual @EmpleoId, @ContenidoActual OUTPUT, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return (string)contenidoActual.Value;

            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<ActualizarMultimediaDTO> ActualizarMultimedia([FromBody] ActualizarMultimediaDTO request)
        {
            try
            {
                var empleoId = new SqlParameter { ParameterName = "EmpleoId", SqlDbType = SqlDbType.UniqueIdentifier, Value = request.EmpleoId };
                var contenido = new SqlParameter { ParameterName = "contenido", SqlDbType = SqlDbType.NVarChar, Value = request.contenido };
                var resultadoDb = new SqlParameter { ParameterName = "Resultado", SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Output };
                var NumError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

                SqlParameter[] parameters =
                {
                    empleoId,
                    contenido,
                    resultadoDb,
                    NumError
                };

                string sqlQuery = "EXEC sp_ActualizarMultimedia @EmpleoId, @contenido, @Resultado OUTPUT, @NumError OUTPUT";
                var dataSp = await _context.actualizarMultimediaDTO.FromSqlRaw(sqlQuery, parameters).ToListAsync();

                return dataSp.FirstOrDefault();

            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<string> UpdateEmpleoId([FromBody] EmpleoUpdateDto request)
        {
            try
            {

                var resultadoBD = new SqlParameter
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
                var EmpleoId = new SqlParameter
                {
                    ParameterName = "Empleo_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.Empleo_id
                };
                var Titulo = new SqlParameter
                {
                    ParameterName = "Titulo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 255,
                    Value = request.titulo
                };
                var Descripcion = new SqlParameter
                {
                    ParameterName = "Descripcion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 255,
                    Value = request.descripcion
                };
                var Ubicacion = new SqlParameter
                {
                    ParameterName = "Ubicacion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 255,
                    Value = request.ubicacion
                };
                var SalarioMinimo = new SqlParameter
                {
                    ParameterName = "Salario_minimo",
                    SqlDbType = SqlDbType.Money,
                    Value = request.salario_minimo
                };
                var SalarioMaximo = new SqlParameter
                {
                    ParameterName = "Salario_maximo",
                    SqlDbType = SqlDbType.Money,
                    Value = request.salario_maximo
                };
                var horario = new SqlParameter
                {
                    ParameterName = "horario",
                    SqlDbType = SqlDbType.VarChar,
                    Value = request.horario
                };
                SqlParameter[] parameters =
                {
                    EmpleoId,
                    Titulo,
                    Descripcion,
                    Ubicacion,
                    SalarioMinimo,
                    SalarioMaximo,
                    horario,
                    resultadoBD,
                    NumError
                };

                string sqlQuery = "EXEC SP_ActualizarEmpleoConMultimedia @Empleo_id, @Titulo, @Descripcion, " +
                                  "@Ubicacion, @Salario_minimo, @Salario_maximo, @horario, @Resultado OUTPUT, @NumError OUTPUT";

                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return resultadoBD.Value.ToString();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<string> DeleteEmpleoId([FromBody] EmpleoRequestDto request)
        {
            try
            {
                var resultadoBD = new SqlParameter
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

                var EmpleoId = new SqlParameter
                {
                    ParameterName = "Empleo_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.EmpleoId
                };

                SqlParameter[] parameters =
                {
                    EmpleoId,
                    resultadoBD,
                    NumError
                };

                string sqlQuery = "EXEC SP_EliminarEmpleoConMultimedia @Empleo_id, @Resultado = @Resultado OUTPUT, @NumError = @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return resultadoBD.Value.ToString();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}
