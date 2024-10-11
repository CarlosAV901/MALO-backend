using MALO.Microservice.Empleosdb.Domain.DTOs.Aplicacion;
using MALO.Microservice.Empleosdb.Domain.DTOs.Empleos;
using MALO.Microservice.Empleosdb.Domain.DTOs.Multimedia;
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
        public async ValueTask<IActionResult> PostEmpleo([FromBody] EmpleoPostDto request)
        {
            return Ok(await _appController.EmpleoPresenter.PostEmpleo(request));
        }

        [HttpPost("UpdateEmpleoById")]
        public async ValueTask<IActionResult> UpdateEmpleoId([FromBody] EmpleoUpdateDto request)
        {
            return Ok(await _appController.EmpleoPresenter.UpdateEmpleoId(request));
        }

        [HttpPost("DeleteEmpleoById")]
        public async ValueTask<IActionResult> DeleteEmpleoId([FromBody] EmpleoRequestDto request)
        {
            return Ok(await _appController.EmpleoPresenter.DeleteEmpleoId(request));
        }

        /// 
        /// -------------- CONSULTAS MULTIMEDIA
        /// 
        [HttpGet("GetMultimedia")]
        public async ValueTask<IActionResult> GetMultimedia()
        {
            return Ok(await _appController.MultimediaPresenter.GetMultimedia());
        }

        [HttpPost("GetMultimediaById")]
        public async ValueTask<IActionResult> GetMultimediaById([FromBody] MultimediaIdDto request)
        {
            return Ok(await _appController.MultimediaPresenter.GetMultimediaById(request));
        }

        [HttpPost("PostMultimedia")]
        public async ValueTask<IActionResult> PostMultimedia([FromBody] MultimediaPostDto request)
        {
            return Ok(await _appController.MultimediaPresenter.PostMultimedia(request));
        }

        [HttpPost("UpdateMultimediaById")]
        public async ValueTask<IActionResult> UpdateMultimediaById([FromBody] MultimediaUpdateDto request)
        {
            return Ok(await _appController.MultimediaPresenter.UpdateMultimediaById(request));
        }

        [HttpPost("DeleteMultimediaById")]
        public async ValueTask<IActionResult> DeleteMultimediaById([FromBody] MultimediaIdDto request)
        {
            return Ok(await _appController.MultimediaPresenter.DeleteMultimediaById(request));
        }


        /// 
        /// -------------- CONSULTAS APLICACION
        /// 
        [HttpGet("GetAplicaciones")]
        public async ValueTask<IActionResult> GetAplicaciones()
        {
            return Ok(await _appController.AplicacionPresenter.GetAplicaciones());
        }

        [HttpPost("GetAplicacionById")]
        public async ValueTask<IActionResult> GetAplicacionById([FromBody] AplicacionIdDto request)
        {
            return Ok(await _appController.AplicacionPresenter.GetAplicacionById(request));
        }

        [HttpPost("GetAplicacionByEmpleoId")]
        public async ValueTask<IActionResult> GetAplicacionByEmpleo([FromBody] AplicacionEmpleoId request)
        {
            return Ok(await _appController.AplicacionPresenter.GetAplicacionByEmpleo(request));
        }

        [HttpPost("GetAplicacionByUsuarioId")]
        public async ValueTask<IActionResult> GetAplicacionByUsuario([FromBody] AplicacionUsuarioIdDto request)
        {
            return Ok(await _appController.AplicacionPresenter.GetAplicacionByUsuario(request));
        }

        [HttpPost("PostAplicacion")]
        public async ValueTask<IActionResult> PostAplicacion([FromBody] AplicacionPostDto request)
        {
            return Ok(await _appController.AplicacionPresenter.PostAplicacion(request));
        }

        [HttpPost("UpdateAplicacionById")]
        public async ValueTask<IActionResult> UpdateAplicacionById([FromBody] AplicacionUpdateDto request)
        {
            return Ok(await _appController.AplicacionPresenter.UpdateAplicacionById(request));
        }

        [HttpPost("DeleteAplicacionById")]
        public async ValueTask<IActionResult> DeleteAplicacionById([FromBody] AplicacionIdDto request)
        {
            return Ok(await _appController.AplicacionPresenter.DeleteAplicacionById(request));
        }
    }
}
