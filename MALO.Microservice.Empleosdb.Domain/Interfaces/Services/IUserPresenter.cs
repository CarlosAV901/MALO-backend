
namespace MALO.Microservice.Empleosdb.Domain.Interfaces.Services
{
    public interface IEmpleoPresenter
    {
        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<List<EmpleosDto>> GetEmpleos();
        Task<EmpleosDto> GetEmpleoId(Guid empleoId);
        Task<string> PostEmpleo(
            string titulo, string descripcion, Guid empresaId,
            DateTime fechaPublicacion, string ubicacion, decimal salarioMinimo, decimal salarioMaximo
        );
        Task<string> UpdateEmpleoId(
            Guid empleoId, string titulo, string descripcion, Guid empresaId,
            DateTime fechaPublicacion, string ubicacion, decimal salarioMinimo, decimal salarioMaximo
        );
        Task<string> DeleteEmpleoId(Guid empleoId);
    }
}
