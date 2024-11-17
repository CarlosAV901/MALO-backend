

namespace MALO.Microservice.Empleosdb.Domain.Interfaces.Infraestructure
{
    public interface IAplicacionInfraestructure
    {
        Task<List<ObtenerUsuariosPorEmpleosDTO>> ObtenerUsuariosPorEmpleos(Guid id);
        Task<int> ContarAplicacionesPorEmpleo(Guid id);
        Task<List<ObtenerEmpleosPorUsuarioDTO>> ObtenerEmpleosPorUsuario(Guid id);
        Task<string> AplicarAEmpleo([FromBody] AplicarEmpleoDTO request);
        Task<string> ElimarAplicacion([FromBody] AplicarEmpleoDTO request);
        Task<List<AplicacionesPorFechaDTO>> ObtenerConteoAplicacionesFecha([FromBody] EmpleoIdDto request);


    }
}
