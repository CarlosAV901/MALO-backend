

namespace MALO.Microservice.Empleosdb.Domain.Interfaces.Infraestructure
{
    public interface IAplicacionInfraestructure
    {
        Task<List<AplicacionDto>> GetAplicaciones();
        Task<AplicacionDto> GetAplicacionById([FromBody] AplicacionIdDto request);
        Task<AplicacionDto> GetAplicacionByEmpleo([FromBody] AplicacionEmpleoId request);
        Task<AplicacionDto> GetAplicacionByUsuario([FromBody] AplicacionUsuarioIdDto request);
        Task<string> PostAplicacion([FromBody] AplicacionPostDto request);
        Task<string> UpdateAplicacionById([FromBody] AplicacionUpdateDto request);
        Task<string> DeleteAplicacionById([FromBody] AplicacionIdDto request);
    }
}
