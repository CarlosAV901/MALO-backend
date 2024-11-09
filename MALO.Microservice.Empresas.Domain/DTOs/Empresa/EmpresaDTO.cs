namespace MALO.Microservice.Empresas.Domain.DTOs.Empresa
{
    public class EmpresaDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Industria { get; set; }
        public string Ubicacion { get; set; }
        public string Rol { get; set; }
        public bool correo_confirmado { get; set; }

        public string Email { get; set; }
        
        
    }
}