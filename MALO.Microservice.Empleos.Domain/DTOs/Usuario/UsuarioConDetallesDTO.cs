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
        public string rol { get; set; }
        public bool correo_confirmado { get; set; }
        public string estado { get; set; }
        public string municipio { get; set; }
        public string localidad { get; set; }
        public string? HabilidadesIds { get; set; }
        public string? HabilidadesDescripciones { get; set; }
        public string? Experiencias { get; set; }
        public string? ImagenPerfil { get; set; }
    }
}
