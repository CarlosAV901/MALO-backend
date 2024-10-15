﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MALO.Microservice.Empleosdb.Domain.DTOs.Usuario
{
    public class EmpleosDto
    {
        [Key]
        public Guid id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public Guid empresa_id { get; set; }
        public DateTime fecha_publicacion { get; set; }
        public string ubicacion { get; set; }
        public decimal salario_minimo { get; set; }
        public decimal salario_maximo { get; set; }
    }
}