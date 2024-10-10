using AutoMapper;
using MALO.Microservice.Empleosdb.Aplication.Interfaces.Persistance;
using MALO.Microservice.Empleosdb.Domain.DTOs.Multimedia;
using Microsoft.AspNetCore.Http;


namespace MALO.Microservice.Empleosdb.Aplication.Presenters
{
    public class MultimediaPresenter : IMultimediaPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public MultimediaPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<List<MultimediaDto>> GetMultimedia()
        {
            return await _unitRepository.multimediaInfraestructure.GetMultimedia();
        }
        public async Task<MultimediaDto> GetMultimediaById(Guid multimediaId)
        {
            return await _unitRepository.multimediaInfraestructure.GetMultimediaById(multimediaId);
        }
        public async Task<string> PostMultimedia(
            Guid empleoId, string nombre, string tipo, IFormFile archivo, DateTime fechaSubida
        )
        {
            return await _unitRepository.multimediaInfraestructure.PostMultimedia(
                empleoId, nombre, tipo, archivo, fechaSubida
            );
        }
        public async Task<string> UpdateMultimediaById(
            Guid multimediaId, Guid empleoId, string nombre, string tipo, IFormFile archivo, DateTime fechaSubida
        )
        {
            return await _unitRepository.multimediaInfraestructure.UpdateMultimediaById(
                multimediaId, empleoId, nombre, tipo, archivo, fechaSubida
            );
        }
        public async Task<string> DeleteMultimediaById(Guid multimediaId)
        {
            return await _unitRepository.multimediaInfraestructure.DeleteMultimediaById(multimediaId);
        }
    }
}
