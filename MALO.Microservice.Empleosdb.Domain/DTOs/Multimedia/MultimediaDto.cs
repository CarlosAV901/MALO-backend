
namespace MALO.Microservice.Empleosdb.Domain.DTOs.Multimedia
{
    public class MultimediaDto
    {
        [Key]
        public Guid id { get; set; }
        public Guid empleo_id { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public byte[] contenido { get; set; }
        public DateTime fecha_subida { get; set; }
    }
}
