
namespace MALO.Microservice.Empleosdb.Domain.DTOs.Aplicacion
{
    public class ObtenerEmpleosPorUsuarioDTO
    {
        public Guid EmpleoID { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_aplicacion { get; set; }
    }
}
