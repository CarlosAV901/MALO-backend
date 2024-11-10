


using MALO.Microservice.Documentos.Aplication.Services;
using Microsoft.AspNetCore.Http;

namespace MALO.Microservice.Documentos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentoController : ApiController
    {

        private readonly FileService _fileService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appController"></param>
        public DocumentoController(IApiController appController, FileService fileService) : base(appController)
        {
            _fileService = fileService;
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
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> PostAgregarDoc([FromForm] PostDocumentoDto request, [FromForm] IFormFile archivo) 
        {
            string urlImagen = null;

            if (archivo != null)
            {
                try
                {
                    urlImagen = await _fileService.SubirArchivo(archivo);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error al subir el archivo: {ex.Message}");
                }
            }

            request.contenido = urlImagen;
            request.tipo = archivo?.ContentType;

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
            return Ok(await _appController.DocumentoPresenter.GetDocumentoId(request.DocId));
        }

        [HttpPost("ActualizarDocumento")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ActualizarDocumento([FromForm] ActualizarDocumentoDTO request, [FromForm] IFormFile archivo)
        {
            string urlImagen = null;

            var usuarioDto = new UsuarioIdDTO { UsuarioId = request.usuario_id };

            var documento = await _appController.DocumentoPresenter.ObtenerContenido(usuarioDto);
            string archivoAnteriorUrl = documento;

            if (!string.IsNullOrEmpty(archivoAnteriorUrl))
            {
                var nombreArchivoAnterior = Path.GetFileName(archivoAnteriorUrl);
                await _fileService.EliminarArchivo(nombreArchivoAnterior);
            }

            if (archivo != null)
            {
                try
                {
                    urlImagen = await _fileService.SubirArchivo(archivo);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error al subir el archivo: {ex.Message}");
                }
            }

            request.contenido = urlImagen;

            return Ok(await _appController.DocumentoPresenter.ActualizarDocumento(request));
        }

    }
}
