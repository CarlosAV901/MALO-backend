using MALO.Microservice.Documentos.Domain.DTOs.Documentos;
using System.Net.Mime;

namespace MALO.Microservice.Documentos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentoController : ApiController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appController"></param>
        public DocumentoController(IApiController appController) : base(appController)
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
        [HttpGet("GetDocumentos")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetDocumentos()
        {
            return Ok(await _appController.DocumentoPresenter.GetDocumentos());
        }

        [HttpPost("PostAgregarDoc")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> PostAgregarDoc([FromBody] PostDocumentoDto request) 
        {
            return Ok(await _appController.DocumentoPresenter.PostAgregarDoc(request));
        }

        [HttpPost("GetDocumentoId")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetDocumentoId([FromBody] DocumentoIdDto request)
        {
            return Ok(await _appController.DocumentoPresenter.GetDocumentoId(request));
        }

    }
}
