
namespace MALO.Microservice.Empleosdb.Domain.Interfaces.Services
{
    public interface IEmpleoPresenter
    {
        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<List<EmpleosDto>> GetEmpleos();
    }
}
