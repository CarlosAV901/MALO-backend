using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALO.Microservice.Empleosdb.Domain.DTOs.Empleos
{
    public class EmpleoUpdateDto
    {
        public Guid Empleo_id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public Guid empresa_id { get; set; }
        public DateTime fecha_publicacion { get; set; }
        public string ubicacion { get; set; }
        public decimal salario_minimo { get; set; }
        public decimal salario_maximo { get; set; }
    }
}
