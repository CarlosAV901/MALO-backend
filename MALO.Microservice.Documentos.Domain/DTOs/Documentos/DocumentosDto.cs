

namespace MALO.Microservice.Documentos.Domain.DTOs.Usuario
{
    public class DocumentosDto
    {
        [Key]
        public Guid id { get; set; }

        public Guid usuario_id { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string contenido { get; set; }
        public DateTime Fecha_Subida { get; set; }

    }
}
