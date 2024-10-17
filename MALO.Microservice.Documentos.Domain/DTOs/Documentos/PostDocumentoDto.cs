using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALO.Microservice.Documentos.Domain.DTOs.Documentos
{
    public class PostDocumentoDto
    {
        public Guid usuario_id { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public byte[] contenido { get; set; }
        public DateTime fecha_Subida { get; set; }
    }
}
