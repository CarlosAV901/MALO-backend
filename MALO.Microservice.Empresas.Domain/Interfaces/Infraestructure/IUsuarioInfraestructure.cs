using MALO.Microservice.Empresas.Domain.DTOs.Usuario;

namespace MALO.Microservice.Empresas.Domain.Interfaces.Infraestructure
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
