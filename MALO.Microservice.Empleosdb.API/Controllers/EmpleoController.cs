

using MALO.Microservice.Empleosdb.Aplication.Services;

namespace MALO.Microservice.Empleosdb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleoController : ApiController
    {
        private readonly FileService _fileService;

        /// <param name="appController"></param>
        public EmpleoController(IApiController appController, FileService fileService) : base(appController)
        {
            _fileService = fileService;
        }

        ///
        ///------- CONSULTAS EMPLEOS
        ///
        [HttpGet("GetEmpleos")]
        public async ValueTask<IActionResult> GetEmpleos()
        {
            return Ok(await _appController.EmpleoPresenter.GetEmpleos());
        }

        [HttpPost("GetEmpleoById")]
        public async ValueTask<IActionResult> GetEmpleoId([FromBody] EmpleoRequestDto request)
        {
            return Ok(await _appController.EmpleoPresenter.GetEmpleoId(request));
        }

        [HttpPost("PostEmpleo")]
        public async ValueTask<IActionResult> PostEmpleo([FromForm] EmpleoPostDto request, [FromForm] IFormFile archivo)
        {
            string urlImagen = null;

            if(archivo != null)
            {
                try
                {
                    urlImagen = await _fileService.SubirArchivo(archivo);
                }catch (Exception ex)
                {
                    return BadRequest($"Error al subir el archivo: {ex.Message}");
                }
            }

            request.multimediaContenido = urlImagen;
            request.multimediaTipo = archivo?.ContentType;

            var empleo = await _appController.EmpleoPresenter.PostEmpleo(request);

            return Ok(empleo);
        }

        [HttpPost("UpdateEmpleoById")]
        public async ValueTask<IActionResult> UpdateEmpleoId([FromBody] EmpleoUpdateDto request)
        {
            return Ok(await _appController.EmpleoPresenter.UpdateEmpleoId(request));
        }

        [HttpPost("ActualizarMultimedia")]
        public async Task<IActionResult> ActualizarMultimedia([FromForm] ActualizarMultimediaDTO request, [FromForm] IFormFile archivo)
        {
            string urlImagen = null;

            var usuarioDto = new EmpleoRequestDto { EmpleoId = request.EmpleoId };

            var documento = await _appController.EmpleoPresenter.ObtenerContenido(usuarioDto);


            if (!string.IsNullOrEmpty(documento))
            {
                var nombreArchivoAnterior = Path.GetFileName(documento);
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


            var empleo = await _appController.EmpleoPresenter.ActualizarMultimedia(request);

            return Ok(empleo);
        }

        [HttpPost("DeleteEmpleoById")]
        public async ValueTask<IActionResult> DeleteEmpleoId([FromBody] EmpleoRequestDto request)
        {
            return Ok(await _appController.EmpleoPresenter.DeleteEmpleoId(request));
        }
    }
}
