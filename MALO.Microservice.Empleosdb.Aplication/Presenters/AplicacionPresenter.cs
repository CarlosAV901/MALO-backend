
using System.Security.AccessControl;

namespace MALO.Microservice.Empleosdb.Aplication.Presenters
{
    internal class AplicacionPresenter: IAplicacionPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

         
        public AplicacionPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<List<ObtenerUsuariosPorEmpleosDTO>> ObtenerUsuariosPorEmpleos(Guid id)
        {
            return await _unitRepository.aplicacionInfraestructure.ObtenerUsuariosPorEmpleos(id);
        }

        public async Task<int> ContarAplicacionesPorEmpleo(Guid id)
        {
            return await _unitRepository.aplicacionInfraestructure.ContarAplicacionesPorEmpleo(id);
        }

        public async Task<List<ObtenerEmpleosPorUsuarioDTO>> ObtenerEmpleosPorUsuario(Guid id)
        {
            return await _unitRepository.aplicacionInfraestructure.ObtenerEmpleosPorUsuario(id);
        }

        public async Task<string> AplicarAEmpleo([FromBody] AplicarEmpleoDTO request)
        {
            return await _unitRepository.aplicacionInfraestructure.AplicarAEmpleo(request);
        }

        public async Task<string> ElimarAplicacion([FromBody] AplicarEmpleoDTO request)
        {
            return await _unitRepository.aplicacionInfraestructure.ElimarAplicacion(request);
        }

        public async Task<List<AplicacionesPorFechaDTO>> ObtenerConteoAplicacionesFecha([FromBody] EmpleoIdDto request)
        {
            return await _unitRepository.aplicacionInfraestructure.ObtenerConteoAplicacionesFecha(request);
        }
    }
}
