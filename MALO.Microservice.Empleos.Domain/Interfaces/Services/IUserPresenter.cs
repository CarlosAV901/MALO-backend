
using Microsoft.AspNetCore.Mvc;

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
        Task<string> InsertarUsuario(UsuarioInsertarDto usuarioInsertarDto);

        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<(string mensaje, int numError)> ConfirmarUsuario(Guid token);
        Task<Guid> GenerarNuevoToken(string email);

        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<string> EliminarUsuario(Guid id);

        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<ActualizarUsuarioDTO> ActualizarUsuario(Guid id, ActualizarUsuarioDTO actualizarUsuarioDTO);

        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<UsuarioConDetallesDTO> ValidarUsuario(string email, string contrasena);

        Task<string> ObtenerContenido([FromBody] ObtenerUsuarioPorId request);

        Task<UsuarioMultimediaDTO> ActualizarMultimedia([FromBody] UsuarioMultimediaDTO request);
    }
}
