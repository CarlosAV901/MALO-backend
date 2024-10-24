

namespace MALO.Microservice.Empleos.Aplication.Interfaces.Controllers
{
    public interface IApiController
    {
        IUserPresenter UserPresenter { get; }
        
        string GetJwtConfigValue(string key);

    }
}
