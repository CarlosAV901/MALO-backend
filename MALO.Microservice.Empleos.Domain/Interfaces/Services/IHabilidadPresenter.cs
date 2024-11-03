
using MALO.Microservice.Empleos.Domain.DTOs.Habilidad;

namespace MALO.Microservice.Empleos.Domain.Interfaces.Services
{
    public interface IHabilidadPresenter
    {
        Task<List<ObtenerHabilidadesDTO>> ObtenerHabilidades();
        Task<ObtenerHabilidadesDTO> ObtenerHabilidadPorId(int id);
        Task<string> InsertarHabilidad(string descripcion);
    }
}
