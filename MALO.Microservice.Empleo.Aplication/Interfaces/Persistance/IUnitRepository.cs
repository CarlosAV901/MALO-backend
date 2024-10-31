


namespace MALO.Microservice.Empleos.Aplication.Interfaces.Persistance
{
    public interface IUnitRepository
    {
        ValueTask<bool> Complete();
        bool HasChanges();

        IUsuarioInfraestructure usuarioInfraestructure { get; }

        IRecuperacionInfraestructure recuperacionInfraestructure {  get; }

    }
}
