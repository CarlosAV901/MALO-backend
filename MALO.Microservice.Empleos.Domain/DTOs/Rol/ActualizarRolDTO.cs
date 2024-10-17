namespace MALO.Microservice.Empleos.Domain.DTOs.Rol
{
    public class ActualizarRolDTO
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int nivel_acceso { get; set; }
    }
}
