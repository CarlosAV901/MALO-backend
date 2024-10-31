using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALO.Microservice.Empresas.Domain.DTOs.Empresa
{
    public class InsertarEmpresaDto
    {
        public string nombre { get; set; }
        public string industria { get; set; }
        public string ubicacion { get; set; }
        public string contrasena { get; set; }
        public string email { get; set; }
    }
}
