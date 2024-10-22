namespace MALO.Microservice.Empresas.Domain.DTOs.Empresa
{
    public class EmpresaDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Industria { get; set; }
        public string Ubicacion { get; set; }
    }
}