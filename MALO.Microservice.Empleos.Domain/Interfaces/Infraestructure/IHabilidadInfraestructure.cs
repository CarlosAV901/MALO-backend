

using MALO.Microservice.Empleos.Domain.DTOs.Habilidad;

namespace MALO.Microservice.Empleos.Domain.Interfaces.Infraestructure
{
    public interface IHabilidadInfraestructure
    {
        Task<List<ObtenerHabilidadesDTO>> ObtenerHabilidades();
        Task<ObtenerHabilidadesDTO> ObtenerHabilidadPorId(int id);
        Task<string> InsertarHabilidad(string descripcion);
        Task<ActualizarHabilidadDTO> ActualizarHabilidad(ActualizarHabilidadDTO actualizarHabilidadDTO);
    }
}
