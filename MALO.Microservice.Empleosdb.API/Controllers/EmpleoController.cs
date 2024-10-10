using System.Net.Mime;

namespace MALO.Microservice.Empleosdb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleoController : ApiController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appController"></param>
        public EmpleoController(IApiController appController) : base(appController)
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
        [HttpGet("GetEmpleos")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetEmpleos()
        {
            return Ok(await _appController.EmpleoPresenter.GetEmpleos());
        }

        [HttpGet("GetEmpleoId")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetEmpleoId(Guid empleoId)
        {
            return Ok(await _appController.EmpleoPresenter.GetEmpleoId(empleoId));
        }

        [HttpGet("PostEmpleo")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> PostEmpleo(
            string titulo, string descripcion, Guid empresaId,
            DateTime fechaPublicacion, string ubicacion, decimal salarioMinimo, decimal salarioMaximo
        )
        {
            return Ok(await _appController.EmpleoPresenter.PostEmpleo(
                titulo, descripcion, empresaId, fechaPublicacion, ubicacion, salarioMinimo, salarioMaximo
            ));
        }

        [HttpGet("UpdateEmpleoId")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> UpdateEmpleoId(
            Guid empleoId, string titulo, string descripcion, Guid empresaId,
            DateTime fechaPublicacion, string ubicacion, decimal salarioMinimo, decimal salarioMaximo
        )
        {
            return Ok(await _appController.EmpleoPresenter.UpdateEmpleoId(
                    empleoId, titulo, descripcion, empresaId, fechaPublicacion, ubicacion,
                    salarioMinimo, salarioMaximo
            ));
        }

        [HttpGet("DeleteEmpleoId")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> DeleteEmpleoId(Guid empleoId)
        {
            return Ok(await _appController.EmpleoPresenter.DeleteEmpleoId(empleoId));
        }
    }
}
