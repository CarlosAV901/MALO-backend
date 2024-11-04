

using MALO.Microservice.Empleos.Domain.DTOs.Habilidad;

namespace MALO.Microservice.Empleos.Aplication.Presenters
{
    public class HabilidadPresenter : IHabilidadPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public HabilidadPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<List<ObtenerHabilidadesDTO>> ObtenerHabilidades()
        {
            return await _unitRepository.habilidadInfraestructure.ObtenerHabilidades();
        }

        public async Task<ObtenerHabilidadesDTO> ObtenerHabilidadPorId(int id)
        {
            return await _unitRepository.habilidadInfraestructure.ObtenerHabilidadPorId(id);
        }

        public async Task<string> InsertarHabilidad(string descripcion)
        {
            return await _unitRepository.habilidadInfraestructure.InsertarHabilidad(descripcion);
        }

        public async Task<ActualizarHabilidadDTO> ActualizarHabilidad(ActualizarHabilidadDTO actualizarHabilidadDTO)
        {
            return await _unitRepository.habilidadInfraestructure.ActualizarHabilidad(actualizarHabilidadDTO);
        }

        public async Task<string> EliminarHabilidad(int id)
        {
            return await _unitRepository.habilidadInfraestructure.EliminarHabilidad(id);
        }
    }
}
