
namespace MALO.Microservice.Empleos.Domain.DTOs.Habilidad
{
    public class ObtenerHabilidadesDTO
    {
        [Key]
        public int id { get; set; }
        public string descripcion { get; set; }
    }
}
