

namespace MALO.Microservice.Empleos.Aplication.Interfaces.Controllers
{
    public interface IApiController
    {
        IUserPresenter UserPresenter { get; }
        
        IRolPresenter RolPresenter { get; }
        string GetJwtConfigValue(string key);

    }
}
