
namespace MALO.Microservice.Empresas.Aplication.Interfaces.Persistance
{
    public interface IUnitRepositoryEmpresas
    {
        ValueTask<bool> Complete();
        bool HasChanges();

        IEmpresaInfraestructure EmpresaInfraestructure { get; }
    }
}
