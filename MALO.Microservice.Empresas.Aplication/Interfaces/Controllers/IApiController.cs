using MALO.Microservice.Empresas.Domain.Interfaces.Services;

namespace MALO.Microservice.Empresas.Aplication.Interfaces.Controllers
{
    public interface IApiController
    {
        IUserPresenter UserPresenter { get; }
    }
}
