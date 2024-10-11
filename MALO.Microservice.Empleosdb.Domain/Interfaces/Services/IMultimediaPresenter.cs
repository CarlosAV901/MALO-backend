using MALO.Microservice.Empleosdb.Domain.DTOs.Multimedia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MALO.Microservice.Empleosdb.Domain.Interfaces.Services
{
    public interface IMultimediaPresenter
    {
        Task<List<MultimediaDto>> GetMultimedia();
        Task<MultimediaDto> GetMultimediaById([FromBody] MultimediaIdDto request);
        Task<string> PostMultimedia(
            Guid empleoId, string nombre, string tipo, IFormFile archivo, DateTime fechaSubida
        );
        Task<string> UpdateMultimediaById(
            Guid multimediaId, Guid empleoId, string nombre, string tipo, IFormFile archivo, DateTime fechaSubida
        );
        Task<string> DeleteMultimediaById([FromBody] MultimediaIdDto request);
    }
}
