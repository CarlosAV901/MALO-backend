namespace MALO.Microservice.Empleos.Domain.Interfaces.Infraestructure
{
    public interface IRoleInfraestructure
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

        /// <summary>
        /// Inserta en la tabla de roles
        /// </summary>
        /// <returns></returns>
        Task<InsertarRolDTO> InsertarRol(InsertarRolDTO insertarRolDTO);

        /// <summary>
        /// Eliminar un rol
        /// </summary>
        /// <returns></returns>
        Task<string> EliminarRol(int id);
    }
}
