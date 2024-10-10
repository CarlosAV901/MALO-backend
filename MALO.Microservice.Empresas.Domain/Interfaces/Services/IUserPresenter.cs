using MALO.Microservice.Empresas.Domain.DTOs.Usuario;

namespace MALO.Microservice.Empresas.Domain.Interfaces.Services
{
    public interface IUserPresenter
    {
        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<UsuarioDto> GetUser();
    }
}
