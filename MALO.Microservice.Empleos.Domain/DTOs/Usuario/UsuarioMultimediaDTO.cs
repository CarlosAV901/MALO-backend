

namespace MALO.Microservice.Empleos.Domain.DTOs.Usuario
{
    public class UsuarioMultimediaDTO
    {
        [Key]
        public Guid UsuarioId { get; set; }
        public string? contenido { get; set; }
    }
}
