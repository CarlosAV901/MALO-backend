namespace MALO.Microservice.Empleos.Domain.DTOs.Usuario
{
    public class UsuarioConDetallesDTO
    {
        [Key]
        public Guid UsuarioId { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public DateTime fecha_registro { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string Rol { get; set; }
        public string RolDescripcion { get; set; }
        public int estado_id { get; set; }
        public int municipio_id { get; set; }
        public int localidad_id { get; set; }
        public string? Habilidades { get; set; }
        public string? Experiencias { get; set; }
        public string? ImagenPerfil { get; set; }
    }
}
