


namespace MALO.Microservice.Empleosdb.Aplication.Interfaces.Persistance
{
    public interface IUnitRepository
    {
        ValueTask<bool> Complete();
        bool HasChanges();

        IEmpleoInfraestructure empleoInfraestructure { get; }
        IMultimediaInfraestructure multimediaInfraestructure { get; }
        IAplicacionInfraestructure aplicacionInfraestructure { get; }
    }
}
