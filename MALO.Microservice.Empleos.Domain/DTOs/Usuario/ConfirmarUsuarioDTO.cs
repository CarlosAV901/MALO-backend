namespace MALO.Microservice.Empleos.Domain.DTOs.Usuario
{
    public class ConfirmarUsusarioDTO
    {
        public Guid token {  get; set; }
        public Guid usuarioId { get; set; }
    }
}
