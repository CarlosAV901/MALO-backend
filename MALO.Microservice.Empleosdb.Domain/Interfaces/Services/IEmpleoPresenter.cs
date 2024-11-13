
namespace MALO.Microservice.Empleosdb.Domain.Interfaces.Services
{
    public interface IEmpleoPresenter
    {
        Task<List<EmpleosDto>> GetEmpleos();
        Task<EmpleosDto> GetEmpleoId([FromBody] EmpleoRequestDto request);
        Task<string> PostEmpleo([FromBody] EmpleoPostDto request);
        Task<string> UpdateEmpleoId([FromBody] EmpleoUpdateDto request);
        Task<string> DeleteEmpleoId([FromBody] EmpleoRequestDto request);
        Task<string> ObtenerContenido([FromBody] EmpleoRequestDto request);
        Task<ActualizarMultimediaDTO> ActualizarMultimedia([FromBody] ActualizarMultimediaDTO request);
    }
}
