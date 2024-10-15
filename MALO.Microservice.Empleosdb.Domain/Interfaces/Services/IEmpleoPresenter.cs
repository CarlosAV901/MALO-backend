
using MALO.Microservice.Empleosdb.Domain.DTOs.Empleos;
using Microsoft.AspNetCore.Mvc;

namespace MALO.Microservice.Empleosdb.Domain.Interfaces.Services
{
    public interface IEmpleoPresenter
    {
        Task<List<EmpleosDto>> GetEmpleos();
        Task<EmpleosDto> GetEmpleoId([FromBody] EmpleoRequestDto request);
        Task<string> PostEmpleo([FromBody] EmpleoPostDto request);
        Task<string> UpdateEmpleoId([FromBody] EmpleoUpdateDto request);
        Task<string> DeleteEmpleoId([FromBody] EmpleoRequestDto request);
    }
}
