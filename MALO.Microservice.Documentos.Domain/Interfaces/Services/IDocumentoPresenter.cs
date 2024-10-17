
using MALO.Microservice.Documentos.Domain.DTOs.Documentos;
using Microsoft.AspNetCore.Mvc;

namespace MALO.Microservice.Documentos.Domain.Interfaces.Services
{
    public interface IDocumentoPresenter
    {
        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<List<DocumentosDto>> GetDocumentos();
        Task<string> PostAgregarDoc([FromBody] PostDocumentoDto request);
        Task<DocumentosDto> GetDocumentoId([FromBody] DocumentoIdDto request);

    }
}
