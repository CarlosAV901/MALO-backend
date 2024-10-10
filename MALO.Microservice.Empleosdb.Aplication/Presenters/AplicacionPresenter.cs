using AutoMapper;
using MALO.Microservice.Empleosdb.Aplication.Interfaces.Persistance;
using MALO.Microservice.Empleosdb.Domain.DTOs.Aplicacion;

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

        public async Task<List<AplicacionDto>> GetAplicaciones()
        {
            return await _unitRepository.aplicacionInfraestructure.GetAplicaciones();
        }
        public async Task<AplicacionDto> GetAplicacionById(Guid aplicacionId)
        {
            return await _unitRepository.aplicacionInfraestructure.GetAplicacionById(aplicacionId);
        }
        public async Task<string> PostAplicacion(
            Guid usuarioId, Guid empleoId, DateTime fechaAplicacion
        )
        {
            return await _unitRepository.aplicacionInfraestructure.PostAplicacion(
                usuarioId, empleoId, fechaAplicacion
            );
        }
        public async Task<string> UpdateAplicacionById(
            Guid aplicacionId, Guid usuarioId, Guid empleoId, DateTime fechaAplicacion
        )
        {
            return await _unitRepository.aplicacionInfraestructure.UpdateAplicacionById(
                aplicacionId, usuarioId, empleoId, fechaAplicacion
            );
        }
        public async Task<string> DeleteAplicacionById(Guid aplicacionId)
        {
            return await _unitRepository.aplicacionInfraestructure.DeleteAplicacionById(aplicacionId);
        }
    }
}
