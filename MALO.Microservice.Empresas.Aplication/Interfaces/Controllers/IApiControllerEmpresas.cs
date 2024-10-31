
namespace MALO.Microservice.Empresas.Aplication.Interfaces.Controllers
{
    public interface IApiControllerEmpresas
    {
        IEmpresaPresenter EmpresaPresenter { get; }
        string GetJwtConfigValue(string key);
    }
}
