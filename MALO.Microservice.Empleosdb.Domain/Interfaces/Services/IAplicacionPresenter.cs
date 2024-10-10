using MALO.Microservice.Empleosdb.Domain.DTOs.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALO.Microservice.Empleosdb.Domain.Interfaces.Services
{
    public interface IAplicacionPresenter
    {
        Task<List<AplicacionDto>> GetAplicaciones();
        Task<AplicacionDto> GetAplicacionById(Guid aplicacionId);
        Task<string> PostAplicacion(Guid usuarioId, Guid empleoId, DateTime fechaAplicacion);
        Task<string> UpdateAplicacionById(Guid aplicacionId, Guid usuarioId, Guid empleoId, DateTime fechaAplicacion);
        Task<string> DeleteAplicacionById(Guid aplicacionId);
    }
}