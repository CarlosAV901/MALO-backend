namespace MALO.Microservice.Empleosdb.Domain.Interfaces.Infraestructure
{
    public interface IEmpleoInfraestructure
    {
        /// <summary>
        /// Consulta un registro de la tabla CE_User
        /// </summary>
        /// <returns></returns>
        Task<List<EmpleosDto>> GetEmpleos();
    }
}
