using MALO.Microservice.Empresas.Domain.Interfaces.Infraestructure;

namespace MALO.Microservice.Empresas.Aplication.Interfaces.Persistance
{
    public interface IUnitRepository
    {
        ValueTask<bool> Complete();
        bool HasChanges();

        IUsuarioInfraestructure usuarioInfraestructure { get; }
    }
}
