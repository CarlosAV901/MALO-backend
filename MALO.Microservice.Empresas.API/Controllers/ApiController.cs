namespace MALO.Microservice.Empresas.API.Controllers
{
    public class ApiController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
       // protected readonly IApiController _appController;
        protected readonly IApiControllerEmpresas _appController;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appController"></param>
        // public ApiController(IApiController appController)
        //{
        //  _appController = appController;
        //}
        public ApiController(IApiControllerEmpresas appController)
        {
            _appController = appController;
        }
    }
}
