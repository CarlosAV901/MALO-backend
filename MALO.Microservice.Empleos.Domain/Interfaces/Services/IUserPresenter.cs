
namespace MALO.Microservice.Empleos.Domain.Interfaces.Services
{
    public interface IUserPresenter
    {
        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<UsuarioDto> GetUser();

        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<UsuarioConDetallesDTO> ObtenerUsuarioPorId(Guid id);

        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<List<UsuarioConDetallesDTO>> ObtenerUsuarios();

        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<UsuarioConDetallesDTO> InsertarUsuario(UsuarioInsertarDto usuarioInsertarDto);

        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<string> EliminarUsuario(Guid id);

        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<UsuarioConDetallesDTO> ActualizarUsuario(Guid id, ActualizarUsuarioDTO actualizarUsuarioDTO);
    }
}
