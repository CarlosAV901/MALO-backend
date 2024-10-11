using AutoMapper;
using MALO.Microservice.Empleosdb.Aplication.Interfaces.Persistance;
using MALO.Microservice.Empleosdb.Domain.DTOs.Aplicacion;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<AplicacionDto> GetAplicacionById([FromBody] AplicacionIdDto request)
        {
            return await _unitRepository.aplicacionInfraestructure.GetAplicacionById(request);
        }
        public async Task<AplicacionDto> GetAplicacionByEmpleo([FromBody] AplicacionEmpleoId request)
        {
            return await _unitRepository.aplicacionInfraestructure.GetAplicacionByEmpleo(request);
        }
        public async Task<AplicacionDto> GetAplicacionByUsuario([FromBody] AplicacionUsuarioIdDto request)
        {
            return await _unitRepository.aplicacionInfraestructure.GetAplicacionByUsuario(request);
        }
        public async Task<string> PostAplicacion([FromBody] AplicacionPostDto request)
        {
            return await _unitRepository.aplicacionInfraestructure.PostAplicacion(request);
        }
        public async Task<string> UpdateAplicacionById([FromBody] AplicacionUpdateDto request)
        {
            return await _unitRepository.aplicacionInfraestructure.UpdateAplicacionById(request);
        }
        public async Task<string> DeleteAplicacionById([FromBody] AplicacionIdDto request)
        {
            return await _unitRepository.aplicacionInfraestructure.DeleteAplicacionById(request);
        }
    }
}
