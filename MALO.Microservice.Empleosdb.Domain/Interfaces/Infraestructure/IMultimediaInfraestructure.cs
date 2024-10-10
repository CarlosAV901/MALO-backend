using MALO.Microservice.Empleosdb.Domain.DTOs.Multimedia;
using Microsoft.AspNetCore.Http;

namespace MALO.Microservice.Empleosdb.Domain.Interfaces.Infraestructure
{
    public interface IMultimediaInfraestructure
    {
        Task<List<MultimediaDto>> GetMultimedia();
        Task<MultimediaDto> GetMultimediaById(Guid multimediaId);
        Task<string> PostMultimedia(
            Guid empleoId, string nombre, string tipo, IFormFile archivo, DateTime fechaSubida
        );
        Task<string> UpdateMultimediaById(
            Guid multimediaId, Guid empleoId, string nombre, string tipo, IFormFile archivo, DateTime fechaSubida
        );
        Task<string> DeleteMultimediaById(Guid multimediaId);
    }
}
