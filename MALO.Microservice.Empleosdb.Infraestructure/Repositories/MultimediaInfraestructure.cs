

namespace MALO.Microservice.Empleosdb.Infraestructure.Repositories
{
    public class MultimediaInfraestructure : IMultimediaInfraestructure
    {
        private readonly ManosALaObraContext _context;

        public MultimediaInfraestructure(ManosALaObraContext context)
        {
            _context = context;
        }

        public async Task<List<MultimediaDto>> GetMultimedia()
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
                SqlParameter[] parameters = { resultadoBD, NumError };
                string sqlQuery = "EXEC dbo.SP_ConsultarMultimedia @Resultado OUTPUT, @NumError OUTPUT";
                var dataSP = await _context.multimediaDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<MultimediaDto> GetMultimediaById([FromBody] MultimediaIdDto request)
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
                var MultimediaId = new SqlParameter
                {
                    ParameterName = "Multimedia_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.Multimedia_id
                };
                SqlParameter[] parameters = { MultimediaId, resultadoBD, NumError };

                string sqlQuery = "EXEC dbo.SP_ConsultarMultimediaId @Multimedia_id, @Resultado OUTPUT, @NumError OUTPUT";
                var dataSP = await _context.multimediaDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<string> PostMultimedia([FromBody] MultimediaPostDto request)
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
                    Value = request.empleo_id
                };
                var Nombre = new SqlParameter
                {
                    ParameterName = "Nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 255,
                    Value = request.nombre
                };
                var Tipo = new SqlParameter
                {
                    ParameterName = "Tipo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = request.tipo
                };
                var Contenido = new SqlParameter
                {
                    ParameterName = "Contenido",
                    SqlDbType = SqlDbType.VarBinary,
                    Value = request.contenido
                };
                var FechaSubida = new SqlParameter
                {
                    ParameterName = "Fecha_subida",
                    SqlDbType = SqlDbType.DateTime,
                    Value = request.fecha_subida
                };

                SqlParameter[] parameters = { EmpleoId, Nombre, Tipo, Contenido, FechaSubida, resultadoBD, NumError };

                string sqlQuery = "EXEC dbo.SP_AgregarMultimedia @Empleo_id, @Nombre, @Tipo, @Contenido, @Fecha_subida, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return resultadoBD.Value.ToString();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        

        public async Task<string> UpdateMultimediaById([FromBody] MultimediaUpdateDto request)
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
                var MultimediaId = new SqlParameter
                {
                    ParameterName = "Multimedia_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.Multimedia_id
                };
                var EmpleoId = new SqlParameter
                {
                    ParameterName = "Empleo_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.empleo_id
                };
                var Nombre = new SqlParameter
                {
                    ParameterName = "Nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 255,
                    Value = request.nombre
                };
                var Tipo = new SqlParameter
                {
                    ParameterName = "Tipo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 255,
                    Value = request.tipo
                };
                var Contenido = new SqlParameter
                {
                    ParameterName = "Contenido",
                    SqlDbType = SqlDbType.VarBinary,
                    Value = request.contenido
                };
                var FechaSubida = new SqlParameter
                {
                    ParameterName = "Fecha_subida",
                    SqlDbType = SqlDbType.DateTime,
                    Value = request.fecha_subida
                };

                SqlParameter[] parameters = { MultimediaId, EmpleoId, Nombre, Tipo, Contenido, FechaSubida, resultadoBD, NumError };

                string sqlQuery = "EXEC dbo.SP_ActualizarMultimedia @Multimedia_id, @Empleo_id, @Nombre, @Tipo, @Contenido, @Fecha_subida, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return resultadoBD.Value.ToString();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<string> DeleteMultimediaById([FromBody] MultimediaIdDto request)
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
                var MultimediaId = new SqlParameter
                {
                    ParameterName = "Multimedia_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.Multimedia_id
                };

                SqlParameter[] parameters = { MultimediaId, resultadoBD, NumError };

                string sqlQuery = "EXEC dbo.SP_EliminarMultimediaId @Multimedia_id, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return resultadoBD.Value.ToString();
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
