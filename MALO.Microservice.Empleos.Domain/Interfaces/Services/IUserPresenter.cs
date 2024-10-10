
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
        Task<UsuarioDto> ObtenerUsuarioPorId(Guid id);
    }
}
