
namespace MALO.Microservice.Empresas.Aplication.Interfaces.Controllers
{
    public interface IApiControllerEmpresas
    {
        IEmpresaPresenter EmpresaPresenter { get; }

        IRecuperacionPresenter RecuperacionPresenter { get; }
        string GetJwtConfigValue(string key);
    }
}
