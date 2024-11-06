
namespace MALO.Microservice.Empleosdb.Domain.DTOs.Aplicacion
{
    public class AplicacionPostDto
    {
        public Guid usuario_id { get; set; }
        public Guid empleo_id { get; set; }
        public DateTime fecha_aplicacion { get; set; }
    }
}
