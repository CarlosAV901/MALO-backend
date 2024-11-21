
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NPOI.SS.Util;

namespace MALO.Microservice.Documentos.Infraestructure.Repositories
{
    public class DocumentoInfraestructure : IDocumentoInfraestructure
    {
        private readonly ManosALaObraContext _context;

        public DocumentoInfraestructure(ManosALaObraContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Consulta un registro de la tabla GI_Persona
        /// </summary>
        /// <returns></returns>
        public async Task<List<DocumentosDto>> GetDocumentos()
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
                string sqlQuery = "EXEC dbo.SP_ConsultarDocumentos @Resultado OUTPUT, @NumError OUTPUT";
                var dataSP = await _context.documentoDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP;
            }
            catch (SqlException ex)
            {
                throw;
            }

        }
        public async Task<string> PostAgregarDoc([FromBody] PostDocumentoDto request)
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
                    ParameterName = "usuario_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.usuario_id
                };
                var Nombre = new SqlParameter
                {
                    ParameterName = "nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 255,
                    Value = request.nombre
                };
                var Tipo = new SqlParameter
                {
                    ParameterName = "tipo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = request.tipo
                };
                var Contenido = new SqlParameter
                {
                    ParameterName = "contenido",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = request.contenido
                };

                SqlParameter[] parameters = { UsuarioId, Nombre, Tipo, Contenido, resultadoBD, NumError };

                string sqlQuery = "EXEC dbo.SP_AgregarDocumento @usuario_id, @nombre, @tipo, @contenido, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return resultadoBD.Value.ToString();
            }
            catch (SqlException)
            {
                throw;
            }

        }

        public async Task<DocumentosDto> GetDocumentoId(Guid id)
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

                var idParam = new SqlParameter
                {
                    ParameterName = "Documento_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = id

                };

                SqlParameter[] parameters = { idParam, resultadoBD, NumError };
                string sqlQuery = "EXEC dbo.SP_ConsultarDocumentoId @Documento_id, @Resultado OUTPUT, @NumError OUTPUT";
                var dataSP = await _context.documentoDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();

                

                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<bool> ConsultarUsuarioId(Guid id)
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

                var idParam = new SqlParameter
                {
                    ParameterName = "Usuario_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = id

                };

                SqlParameter[] parameter =
                {
                    resultadoBD,
                    NumError,
                    idParam
                };

                string sqlQuery = "EXEC SP_ConsultarDocumentoPorUsuarioId @Usuario_id, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameter);

                var error = (int)NumError.Value;

                if(error == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            } catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<string> ObtenerContenido([FromBody] UsuarioIdDTO request)
        {
            try
            {
                var idUsuario = new SqlParameter { ParameterName = "UsuarioId", SqlDbType = SqlDbType.UniqueIdentifier, Value = request.UsuarioId };
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

                return (string)contenidoActual.Value;

            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<ActualizarDocumentoDTO> ActualizarDocumento([FromBody] ActualizarDocumentoDTO request)
        {
            try
            {
                var usuarioIdParam = new SqlParameter { ParameterName = "UsuarioId", SqlDbType = SqlDbType.UniqueIdentifier, Value = request.usuario_id };
                var contenidoParam = new SqlParameter { ParameterName = "Contenido", SqlDbType = SqlDbType.NVarChar, Value = request.contenido };
                var contenidoAnterior = new SqlParameter { ParameterName = "ContenidoActual", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Output };
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
                    usuarioIdParam,
                    contenidoParam,
                    resultadoBD,
                    NumError
                };

                string sqlQuery = "EXEC SP_ActualizarDocumento @UsuarioId, @Contenido, @Resultado OUTPUT, @NumError OUTPUT";
                var dataSP = await _context.actualizarDocumentoDTO.FromSqlRaw(sqlQuery, parameters).ToListAsync();

                return dataSP.FirstOrDefault();

        }
            catch (SqlException ex) { throw; }
        }

    }
}