

namespace MALO.Microservice.Documentos.Domain.Interfaces.Infraestructure
{
    public interface IDocumentoInfraestructure
    {
        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<List<DocumentosDto>> GetDocumentos();
        Task<string> PostAgregarDoc([FromBody] PostDocumentoDto request);

        Task<DocumentosDto> GetDocumentoId(Guid id);
        Task<string> ObtenerContenido([FromBody] UsuarioIdDTO request);
        Task<ActualizarDocumentoDTO> ActualizarDocumento([FromBody] ActualizarDocumentoDTO request);
        Task<bool> ConsultarUsuarioId(Guid id);
    }
}
