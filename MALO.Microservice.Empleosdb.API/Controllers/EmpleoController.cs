using System.Net.Mime;

namespace MALO.Microservice.Empleosdb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleoController : ApiController
    {
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
        /// 

        ///
        ///------- CONSULTAS EMPLEOS
        ///
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

        [HttpGet("GetEmpleoById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetEmpleoId(Guid empleoId)
        {
            return Ok(await _appController.EmpleoPresenter.GetEmpleoId(empleoId));
        }

        [HttpPost("PostEmpleo")]
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

        [HttpPost("UpdateEmpleoById")]
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

        [HttpGet("DeleteEmpleoById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> DeleteEmpleoId(Guid empleoId)
        {
            return Ok(await _appController.EmpleoPresenter.DeleteEmpleoId(empleoId));
        }

        /// 
        /// -------------- CONSULTAS MULTIMEDIA
        /// 
        [HttpGet("GetMultimedia")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetMultimedia()
        {
            return Ok(await _appController.MultimediaPresenter.GetMultimedia());
        }

        [HttpGet("GetMultimediaById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetMultimediaById(Guid multimediaId)
        {
            return Ok(await _appController.MultimediaPresenter.GetMultimediaById(multimediaId));
        }

        [HttpPost("PostMultimedia")]
        [Consumes("multipart/form-data")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> PostMultimedia(
            Guid empleoId, string nombre, string tipo, IFormFile file, DateTime fechaSubida
        )
        {
            return Ok(await _appController.MultimediaPresenter.PostMultimedia(
                empleoId, nombre, tipo, file, fechaSubida
            ));
        }

        [HttpPost("UpdateMultimediaById")]
        [Consumes("multipart/form-data")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> UpdateMultimediaById(
            Guid multimediaId, Guid empleoId, string nombre, string tipo, IFormFile file, DateTime fechaSubida
        )
        {
            return Ok(await _appController.MultimediaPresenter.UpdateMultimediaById(
                    multimediaId, empleoId, nombre, tipo, file, fechaSubida
            ));
        }

        [HttpGet("DeleteMultimediaById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> DeleteMultimediaById(Guid multimediaId)
        {
            return Ok(await _appController.MultimediaPresenter.DeleteMultimediaById(multimediaId));
        }

    }
}
