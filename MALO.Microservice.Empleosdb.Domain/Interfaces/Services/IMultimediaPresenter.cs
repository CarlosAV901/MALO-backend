using MALO.Microservice.Empleosdb.Domain.DTOs.Multimedia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MALO.Microservice.Empleosdb.Domain.Interfaces.Services
{
    public interface IMultimediaPresenter
    {
        Task<List<MultimediaDto>> GetMultimedia();
        Task<MultimediaDto> GetMultimediaById([FromBody] MultimediaIdDto request);
        Task<string> PostMultimedia([FromBody] MultimediaPostDto request);
        Task<string> UpdateMultimediaById([FromBody] MultimediaUpdateDto request);
        Task<string> DeleteMultimediaById([FromBody] MultimediaIdDto request);
    }
}
