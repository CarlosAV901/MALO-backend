

namespace MALO.Microservice.Empleos.Aplication.Interfaces.Controllers
{
    public interface IApiController
    {
        IUserPresenter UserPresenter { get; }

        IRecuperacionPresenter RecuperacionPresenter { get; }
        
        string GetJwtConfigValue(string key);

    }
}
