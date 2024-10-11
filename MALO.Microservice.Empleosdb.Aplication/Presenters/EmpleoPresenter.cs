using AutoMapper;
using MALO.Microservice.Empleosdb.Aplication.Interfaces.Persistance;
using MALO.Microservice.Empleosdb.Domain.DTOs.Empleos;
using MALO.Microservice.Empleosdb.Domain.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<EmpleosDto> GetEmpleoId([FromBody] EmpleoRequestDto request)
        {
            return await _unitRepository.empleoInfraestructure.GetEmpleoId(request);
        }
        public async Task<string> PostEmpleo([FromBody] EmpleoPostDto request)
        {
            return await _unitRepository.empleoInfraestructure.PostEmpleo(request);
        }
        public async Task<string> UpdateEmpleoId([FromBody] EmpleoUpdateDto request)
        {
            return await _unitRepository.empleoInfraestructure.UpdateEmpleoId(request);
        }
        public async Task<string> DeleteEmpleoId([FromBody] EmpleoRequestDto request)
        {
            return await _unitRepository.empleoInfraestructure.DeleteEmpleoId(request);
        }
    }
}
