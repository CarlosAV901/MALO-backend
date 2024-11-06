

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

    }
}
