
namespace MALO.Microservice.Documentos.Aplication.Presenters
{
    public class DocumentoPresenter : IDocumentoPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public DocumentoPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Consulta un registro de la tabla CE_Users
        /// </summary>
        /// <returns></returns>
        public async Task<List<DocumentosDto>> GetDocumentos()
        {
            return await _unitRepository.documentoInfraestructure.GetDocumentos();
        }

        public async Task<string> PostAgregarDoc([FromBody] PostDocumentoDto request)
        {
            return await _unitRepository.documentoInfraestructure.PostAgregarDoc(request);
        }

        public async Task<DocumentosDto> GetDocumentoId(Guid id)
        {
            return await _unitRepository.documentoInfraestructure.GetDocumentoId(id);
        }

        public async Task<string> ObtenerContenido([FromBody] UsuarioIdDTO request)
        {
            return await _unitRepository.documentoInfraestructure.ObtenerContenido(request);
        }
        public async Task<ActualizarDocumentoDTO> ActualizarDocumento([FromBody] ActualizarDocumentoDTO request)
        {
            return await _unitRepository.documentoInfraestructure.ActualizarDocumento(request);
        }

        public async Task<bool> ConsultarUsuarioId(Guid id)
        {
            return await _unitRepository.documentoInfraestructure.ConsultarUsuarioId(id);
        }

    }
}
