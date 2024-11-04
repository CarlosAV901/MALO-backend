

namespace MALO.Microservice.Empleos.Domain.DTOs.Habilidad
{
    public class ActualizarHabilidadDTO
    {
        [Key]
        public int HabilidadID { get; set; }
        public string descripcion { get; set; }
    }
}
