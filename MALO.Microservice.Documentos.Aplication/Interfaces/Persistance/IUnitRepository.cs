

using MALO.Microservice.Documentos.Domain.Interfaces.Infraestructure;

namespace MALO.Microservice.Documentos.Aplication.Interfaces.Persistance
{
    public interface IUnitRepository
    {
        ValueTask<bool> Complete();
        bool HasChanges();

        IDocumentoInfraestructure documentoInfraestructure { get; }
    }
}
