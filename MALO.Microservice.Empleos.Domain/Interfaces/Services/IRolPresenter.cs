﻿namespace MALO.Microservice.Empleos.Domain.Interfaces.Services
{
    public interface IRolPresenter
    {
        /// <summary>
        /// Consulta los registro de la tabla de roles
        /// </summary>
        /// <returns></returns>
        Task<List<ObtenerRolesDTO>> ObtenerRoles();

        /// <summary>
        /// Consulta registro por id de la tabla rol 
        /// </summary>
        /// <returns></returns>
        Task<ObtenerRolesDTO> ObtenerRolPorId(int id);

        /// <summary>
        /// Actualizar Rol
        /// </summary>
        /// <returns></returns>
        Task<ActualizarRolDTO> ActualizarRol(int id, ActualizarRolDTO actualizarRolDTO);
    }
}
