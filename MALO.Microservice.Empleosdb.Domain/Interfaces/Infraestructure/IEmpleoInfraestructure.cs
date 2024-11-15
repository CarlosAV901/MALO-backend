

namespace MALO.Microservice.Empleosdb.Domain.Interfaces.Infraestructure
{
    public interface IEmpleoInfraestructure
    {
        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<List<EmpleosDto>> GetEmpleos();
        Task<EmpleosDto> GetEmpleoId([FromBody] EmpleoRequestDto request);
        Task<string> PostEmpleo([FromBody] EmpleoPostDto request);
        Task<string> UpdateEmpleoId([FromBody] EmpleoUpdateDto request);
        Task<string> DeleteEmpleoId([FromBody] EmpleoRequestDto request);
        Task<string> ObtenerContenido([FromBody] EmpleoRequestDto request);
        Task<ActualizarMultimediaDTO> ActualizarMultimedia([FromBody] ActualizarMultimediaDTO request);
        Task<(string mensaje, int numError)> ResgistrarVisualizacion([FromBody] RegistrarVisualizacionDTO request);
        Task<int> ObtenerVisualizacionesPorEmpleo([FromBody] EmpleoIdDto request);
    }
}
