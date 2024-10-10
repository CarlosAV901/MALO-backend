using System.Net.Mime;

namespace MALO.Microservice.Documentos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ApiController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appController"></param>
        public UsuarioController(IApiController appController) : base(appController)
        {

        }

        /// <summary>
        /// Consulta un regsitro de la tabla GI_Persona
        /// </summary>
        /// <param name="">Params de entrada</param> 
        /// <remarks>
        /// Sample request: 
        /// 
        ///     POST 
        ///       {
        ///         "User":"SysAdmin"
        ///       }
        /// </remarks>   
        /// <response code="200">string</response>  
        /// <response code="400">string</response> 
        /// <response code="500">string</response> 
        [HttpGet("GetUser")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetPersona()
        {
            return Ok(await _appController.UserPresenter.GetUser());
        }
    }
}
