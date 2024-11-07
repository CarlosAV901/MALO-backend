﻿

using Org.BouncyCastle.Crypto.Operators;

namespace MALO.Microservice.Empleosdb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AplicacionController : ApiController
    {
        public AplicacionController(IApiController appController) : base(appController)
        {
        }

        [HttpPost("obtener-usuarios-por-empleo")]
        public async Task<IActionResult> ObtenerUsuariosPorEmpleo([FromBody] EmpleoIdDto request)
        {
            var usuario = await _appController.AplicacionPresenter.ObtenerUsuariosPorEmpleos(request.EmpleoID);

            return Ok(usuario);
        }

        [HttpPost("contar-aplicaciones-por-empleo")]
        public async Task<IActionResult> ContarAplicionesPorEmpleo([FromBody] EmpleoIdDto request)
        {
            var aplicaciones = await _appController.AplicacionPresenter.ContarAplicacionesPorEmpleo(request.EmpleoID);

            return Ok(aplicaciones);
        }

        [HttpPost("obtener-empleos-por-usuario")]
        public async Task<IActionResult> ObtenerEmpleosPorUsuario([FromBody] EmpleoIdDto request)
        {
            var empleos = await _appController.AplicacionPresenter.ObtenerEmpleosPorUsuario(request.EmpleoID);

            return Ok(empleos);
        }

        [HttpPost("aplicar-empleo")]
        public async Task<IActionResult> AplicarAEmpleo([FromBody] AplicarEmpleoDTO request)
        {
            var aplicacion = await _appController.AplicacionPresenter.AplicarAEmpleo(request);

            return Ok(aplicacion);
        }

        [HttpPost("eliminar-postulacion")]
        public async Task<IActionResult> EliminarPostulacion([FromBody] AplicarEmpleoDTO request)
        {
            var aplicacion = await _appController.AplicacionPresenter.ElimarAplicacion(request);

            return Ok(new
            {
                message = "Postulacion eliminada correctamente",
                result = true
            });
        }

    }
}
