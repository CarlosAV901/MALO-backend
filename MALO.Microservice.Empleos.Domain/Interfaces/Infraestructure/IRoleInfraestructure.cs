

using MALO.Microservice.Empleos.Domain.DTOs.Rol;

namespace MALO.Microservice.Empleos.Domain.Interfaces.Infraestructure
{
    public interface IRoleInfraestructure
    {
        /// <summary>
        /// Consulta los registro de la tabla de roles
        /// </summary>
        /// <returns></returns>
        Task<List<ObtenerRolesDTO>> ObtenerRoles();
    }
}
