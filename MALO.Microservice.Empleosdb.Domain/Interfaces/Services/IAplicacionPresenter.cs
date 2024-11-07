﻿

namespace MALO.Microservice.Empleosdb.Domain.Interfaces.Services
{
    public interface IAplicacionPresenter
    {
        Task<List<ObtenerUsuariosPorEmpleosDTO>> ObtenerUsuariosPorEmpleos(Guid id);
        Task<int> ContarAplicacionesPorEmpleo(Guid id);
        Task<List<ObtenerEmpleosPorUsuarioDTO>> ObtenerEmpleosPorUsuario(Guid id);
        Task<string> AplicarAEmpleo([FromBody] AplicarEmpleoDTO request);
        Task<string> ElimarAplicacion([FromBody] AplicarEmpleoDTO request);

    }
}