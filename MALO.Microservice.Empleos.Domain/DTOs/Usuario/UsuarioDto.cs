﻿
namespace MALO.Microservice.Empleos.Domain.DTOs.Usuario
{
    public class UsuarioDto
    {
        [Key]
        public Guid id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string contrasena { get; set; }
        public DateTime fecha_registro { get; set; }
        public string rol { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public bool correo_confirmado { get; set; }
        public int estado_id { get; set; }
        public int municipio_id { get; set; }
        public int localidad_id { get; set; }
    }
}
