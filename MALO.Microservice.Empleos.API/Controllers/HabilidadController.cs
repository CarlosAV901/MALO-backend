
using MALO.Microservice.Empleos.Domain.DTOs.Habilidad;

namespace MALO.Microservice.Empleos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabilidadController : ApiController
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appController"></param>
        public HabilidadController(IApiController appController) : base(appController)
        {
        }

        [HttpPost("Obtener-habilidades")]
        public async ValueTask<IActionResult> ObtenerHabilidades()
        {
            var habilidades = await _appController.HabilidadPresenter.ObtenerHabilidades();

            return Ok(habilidades);
        }

        [HttpPost("obtener-habilidades-id")]
        public async ValueTask<IActionResult> ObtenerHabilidadPorId([FromBody] ObtenerHabilidadPorId request)
        {
            var habilidad = await _appController.HabilidadPresenter.ObtenerHabilidadPorId(request.id);

            return Ok(habilidad);
        }

        [HttpPost("insertar-habilidad")]
        public async ValueTask<IActionResult> InsertarHabilidad([FromBody] InsertarHabilidadDTO request)
        {
            var habilidad = await _appController.HabilidadPresenter.InsertarHabilidad(request.descripcion);

            return Ok(habilidad);
        }

        [HttpPost("actualizar-habilidad")]
        public async Task<IActionResult> ActualizarHabilidad([FromBody] ActualizarHabilidadDTO request)
        {
            var habilidad = await _appController.HabilidadPresenter.ActualizarHabilidad(request);

            return Ok(habilidad);
        }



    }
}
