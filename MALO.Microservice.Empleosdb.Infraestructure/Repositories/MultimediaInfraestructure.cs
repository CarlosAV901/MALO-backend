using MALO.Microservice.Empleosdb.Domain.DTOs.Multimedia;
using MALO.Microservice.Empleosdb.Domain.Interfaces.Infraestructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<string> PostMultimedia(Guid empleoId, string nombre, string tipo, IFormFile archivo, DateTime fechaSubida)
        {
            try
            {
                // Convertir el archivo a byte[]
                byte[] contenido;
                using (var memoryStream = new MemoryStream())
                {
                    await archivo.CopyToAsync(memoryStream);
                    contenido = memoryStream.ToArray(); // Contenido del archivo en formato byte[]
                }

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
                    Value = empleoId
                };
                var Nombre = new SqlParameter
                {
                    ParameterName = "Nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 255,
                    Value = nombre
                };
                var Tipo = new SqlParameter
                {
                    ParameterName = "Tipo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = tipo
                };
                var Contenido = new SqlParameter
                {
                    ParameterName = "Contenido",
                    SqlDbType = SqlDbType.VarBinary,
                    Value = contenido
                };
                var FechaSubida = new SqlParameter
                {
                    ParameterName = "Fecha_subida",
                    SqlDbType = SqlDbType.DateTime,
                    Value = fechaSubida
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


        public async Task<string> UpdateMultimediaById(Guid multimediaId, Guid empleoId, string nombre, string tipo, IFormFile archivo, DateTime fechaSubida)
        {
            try
            {
                // Convertir el archivo a byte[]
                byte[] contenido;
                using (var memoryStream = new MemoryStream())
                {
                    await archivo.CopyToAsync(memoryStream);
                    contenido = memoryStream.ToArray(); // Contenido del archivo en formato byte[]
                }

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
                    Value = multimediaId
                };
                var EmpleoId = new SqlParameter
                {
                    ParameterName = "Empleo_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = empleoId
                };
                var Nombre = new SqlParameter
                {
                    ParameterName = "Nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 255,
                    Value = nombre
                };
                var Tipo = new SqlParameter
                {
                    ParameterName = "Tipo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = tipo
                };
                var Contenido = new SqlParameter
                {
                    ParameterName = "Contenido",
                    SqlDbType = SqlDbType.VarBinary,
                    Value = contenido
                };
                var FechaSubida = new SqlParameter
                {
                    ParameterName = "Fecha_subida",
                    SqlDbType = SqlDbType.DateTime,
                    Value = fechaSubida
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
