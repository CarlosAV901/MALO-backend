

namespace MALO.Microservice.Empleosdb.Aplication.Interfaces.Controllers
{
    public interface IApiController
    {
        IEmpleoPresenter EmpleoPresenter { get; }
        IMultimediaPresenter MultimediaPresenter { get; }
        IAplicacionPresenter AplicacionPresenter { get; }
    }
}
