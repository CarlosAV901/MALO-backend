﻿using System;

namespace MALO.Microservice.Empresas.Domain.DTOs.Empresa
{
    public class ActualizarEmpresaDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Industria { get; set; }
        public string Ubicacion { get; set; }
    }
}

