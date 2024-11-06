
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



        public async Task<List<AplicacionDto>> GetAplicaciones()
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
                SqlParameter[] parameters =
                {
            resultadoBD,
            NumError
        };

                string sqlQuery = "EXEC dbo.SP_ConsultarAplicaciones @Resultado OUTPUT, @NumError OUTPUT";
                var dataSP = await _context.aplicacionDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<AplicacionDto> GetAplicacionById([FromBody] AplicacionIdDto request)
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

                var AplicacionId = new SqlParameter
                {
                    ParameterName = "Aplicacion_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.Aplicacion_id
                };

                SqlParameter[] parameters =
                {
            AplicacionId,
            resultadoBD,
            NumError
        };

                string sqlQuery = "EXEC dbo.SP_ConsultarAplicacionId @Aplicacion_id, @Resultado = @Resultado OUTPUT, @NumError = @NumError OUTPUT";
                var dataSP = await _context.aplicacionDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<AplicacionDto> GetAplicacionByEmpleo([FromBody] AplicacionEmpleoId request)
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

                SqlParameter[] parameters =
                {
            EmpleoId,
            resultadoBD,
            NumError
        };

                string sqlQuery = "EXEC dbo.SP_ConsultarAplicacionByEmpleo @Empleo_id, @Resultado = @Resultado OUTPUT, @NumError = @NumError OUTPUT";
                var dataSP = await _context.aplicacionDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<AplicacionDto> GetAplicacionByUsuario([FromBody] AplicacionUsuarioIdDto request)
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

                var UsuarioId = new SqlParameter
                {
                    ParameterName = "Usuario_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.Usuario_id
                };

                SqlParameter[] parameters =
                {
            UsuarioId,
            resultadoBD,
            NumError
        };

                string sqlQuery = "EXEC dbo.SP_ConsultarAplicacionByUsuario @Usuario_id, @Resultado = @Resultado OUTPUT, @NumError = @NumError OUTPUT";
                var dataSP = await _context.aplicacionDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<string> PostAplicacion([FromBody] AplicacionPostDto request)
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

                var UsuarioId = new SqlParameter
                {
                    ParameterName = "Usuario_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.usuario_id
                };

                var EmpleoId = new SqlParameter
                {
                    ParameterName = "Empleo_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.empleo_id
                };

                var FechaAplicacion = new SqlParameter
                {
                    ParameterName = "Fecha_aplicacion",
                    SqlDbType = SqlDbType.Date,
                    Value = request.fecha_aplicacion
                };

                SqlParameter[] parameters =
                {
            UsuarioId,
            EmpleoId,
            FechaAplicacion,
            resultadoBD,
            NumError
        };

                string sqlQuery = "EXEC dbo.SP_AgregarAplicacion @Usuario_id, @Empleo_id, @Fecha_aplicacion, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return resultadoBD.Value.ToString();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<string> UpdateAplicacionById([FromBody] AplicacionUpdateDto request)
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

                var AplicacionId = new SqlParameter
                {
                    ParameterName = "Aplicacion_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.Aplicacion_id
                };

                var UsuarioId = new SqlParameter
                {
                    ParameterName = "Usuario_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.usuario_id
                };

                var EmpleoId = new SqlParameter
                {
                    ParameterName = "Empleo_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.empleo_id
                };

                var FechaAplicacion = new SqlParameter
                {
                    ParameterName = "Fecha_aplicacion",
                    SqlDbType = SqlDbType.Date,
                    Value = request.fecha_aplicacion
                };

                SqlParameter[] parameters =
                {
            AplicacionId,
            UsuarioId,
            EmpleoId,
            FechaAplicacion,
            resultadoBD,
            NumError
        };

                string sqlQuery = "EXEC dbo.SP_ActualizarAplicacion @Aplicacion_id, @Usuario_id, @Empleo_id, @Fecha_aplicacion, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return resultadoBD.Value.ToString();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<string> DeleteAplicacionById([FromBody] AplicacionIdDto request)
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

                var AplicacionId = new SqlParameter
                {
                    ParameterName = "Aplicacion_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.Aplicacion_id
                };

                SqlParameter[] parameters =
                {
            AplicacionId,
            resultadoBD,
            NumError
        };

                string sqlQuery = "EXEC dbo.SP_EliminarAplicacionId @Aplicacion_id, @Resultado OUTPUT, @NumError OUTPUT";
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
