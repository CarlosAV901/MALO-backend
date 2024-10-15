using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALO.Microservice.Empleosdb.Domain.DTOs.Aplicacion
{
    public class AplicacionUpdateDto
    {
        public Guid Aplicacion_id { get; set; }
        public Guid usuario_id { get; set; }
        public Guid empleo_id { get; set; }
        public DateTime fecha_aplicacion { get; set; }
    }
}
