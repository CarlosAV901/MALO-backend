

namespace MALO.Microservice.Empresas.Domain.DTOs.Recuperacion
{
    public class CambioContrasenaDTO
    {
        public Guid token { get; set; }
        public string nuevaContrasena { get; set; }
    }
}
