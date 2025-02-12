﻿

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

        Task<DocumentosDto> GetDocumentoId([FromBody] DocumentoIdDto request);
    }
}
