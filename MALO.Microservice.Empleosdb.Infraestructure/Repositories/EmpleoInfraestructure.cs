﻿


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

                string sqlQuery = "EXEC dbo.SP_ConsultarEmpleoId @Empleo_id, @Resultado = @Resultado OUTPUT, @NumError = @NumError OUTPUT";
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
                var FechaPublicacion = new SqlParameter
                {
                    ParameterName = "Fecha_publicacion",
                    SqlDbType = SqlDbType.Date,
                    Value = request.fecha_publicacion
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

                SqlParameter[] parameters =
                {
                    Titulo,
                    Descripcion,
                    EmpresaId,
                    FechaPublicacion,
                    Ubicacion,
                    SalarioMinimo,
                    SalarioMaximo,
                    resultadoBD,
                    NumError
                };

                string sqlQuery = "EXEC dbo.SP_AgregarEmpleo @Titulo, @Descripcion, @Empresa_id, @Fecha_publicacion, " +
                                  "@Ubicacion, @Salario_minimo, @Salario_maximo, @Resultado OUTPUT, @NumError OUTPUT";

                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return resultadoBD.Value.ToString();
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
                var EmpresaId = new SqlParameter
                {
                    ParameterName = "Empresa_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.empresa_id
                };
                var FechaPublicacion = new SqlParameter
                {
                    ParameterName = "Fecha_publicacion",
                    SqlDbType = SqlDbType.Date,
                    Value = request.fecha_publicacion
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

                SqlParameter[] parameters =
                {
                    EmpleoId,
                    Titulo,
                    Descripcion,
                    EmpresaId,
                    FechaPublicacion,
                    Ubicacion,
                    SalarioMinimo,
                    SalarioMaximo,
                    resultadoBD,
                    NumError
                };

                string sqlQuery = "EXEC dbo.SP_ActualizarEmpleo @Empleo_id, @Titulo, @Descripcion, @Empresa_id, @Fecha_publicacion, " +
                                  "@Ubicacion, @Salario_minimo, @Salario_maximo, @Resultado OUTPUT, @NumError OUTPUT";

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

                string sqlQuery = "EXEC dbo.SP_EliminarEmpleoId @Empleo_id, @Resultado = @Resultado OUTPUT, @NumError = @NumError OUTPUT";
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
