

namespace MALO.Microservice.Empleosdb.Domain.DTOs.Empleos
{
    public class ActualizarMultimediaDTO
    {
        [Key]
        public Guid EmpleoId { get; set; }
        public string? contenido { get; set; }
    }
}
