﻿namespace MALO.Microservice.Empleos.Domain.Interfaces.Infraestructure
{
    public interface IUsuarioInfraestructure
    {
        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<UsuarioDto> GetUser();
    }
}
