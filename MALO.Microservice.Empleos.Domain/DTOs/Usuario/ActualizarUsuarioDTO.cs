namespace MALO.Microservice.Empleos.Domain.DTOs.Usuario
{
    public class ActualizarUsuarioDTO
    {
        [Key]
        public Guid UsuarioId { get; set; }
        public string? nombre { get; set; }
        public string? email { get; set; }
        public string? apellido { get; set; }
        public string? telefono { get; set; }
        public int? rol_id { get; set; }
        public int? estado_id { get; set; }
        public int? municipio_id { get; set; }
        public int? localidad_id { get; set; }
        public string? Habilidades { get; set; }
        public string? Experiencias { get; set; }
        public string? ImagenPerfil { get; set; }
    }
}
