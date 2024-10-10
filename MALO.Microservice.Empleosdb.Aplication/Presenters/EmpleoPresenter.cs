using AutoMapper;
using MALO.Microservice.Empleosdb.Aplication.Interfaces.Persistance;
using MALO.Microservice.Empleosdb.Domain.DTOs.Usuario;

namespace MALO.Microservice.Empleosdb.Aplication.Presenters
{
    public class EmpleoPresenter : IEmpleoPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public EmpleoPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Consulta un registro de la tabla CE_Users
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmpleosDto>> GetEmpleos()
        {
            return await _unitRepository.empleoInfraestructure.GetEmpleos();
        }
        public async Task<EmpleosDto> GetEmpleoId(Guid empleoId)
        {
            return await _unitRepository.empleoInfraestructure.GetEmpleoId(empleoId);
        }
        public async Task<string> PostEmpleo(
            string titulo, string descripcion, Guid empresaId,
            DateTime fechaPublicacion, string ubicacion, decimal salarioMinimo, decimal salarioMaximo
        )
        {
            return await _unitRepository.empleoInfraestructure.PostEmpleo(
                titulo, descripcion, empresaId, fechaPublicacion, ubicacion, salarioMinimo, salarioMaximo
            );
        }
        public async Task<string> UpdateEmpleoId(
            Guid empleoId, string titulo, string descripcion, Guid empresaId,
            DateTime fechaPublicacion, string ubicacion, decimal salarioMinimo, decimal salarioMaximo
        )
        {
            return await _unitRepository.empleoInfraestructure.UpdateEmpleoId(
                empleoId, titulo, descripcion, empresaId, fechaPublicacion, ubicacion,
                salarioMinimo, salarioMaximo
            );
        }
        public async Task<string> DeleteEmpleoId(Guid empleoId)
        {
            return await _unitRepository.empleoInfraestructure.DeleteEmpleoId(empleoId);
        }
    }
}
