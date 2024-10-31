

namespace MALO.Microservice.Documentos.API.Controllers
{
    public class ApiController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IApiController _appController;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appController"></param>
        public ApiController(IApiController appController)
        {
            _appController = appController;
        }
    }
}
