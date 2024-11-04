
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

        public async Task<DocumentosDto> GetDocumentoId([FromBody] DocumentoIdDto request)
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

                var id = new SqlParameter
                {
                    ParameterName = "Documento_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = request.DocId

                };

                SqlParameter[] parameters = { id, resultadoBD, NumError };
                string sqlQuery = "EXEC dbo.SP_ConsultarDocumentoId @Documento_id, @Resultado OUTPUT, @NumError OUTPUT";
                var dataSP = await _context.documentoDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}