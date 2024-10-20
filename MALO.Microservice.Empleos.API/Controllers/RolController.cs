

namespace MALO.Microservice.Empleos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ApiController
    {
        public RolController(IApiController appController) : base(appController)
        {

        }

        /// <summary>
        /// Consulta registros de la tabla roles
        /// </summary> 
        /// <response code="200">string</response>  
        /// <response code="400">string</response> 
        /// <response code="500">string</response> 
        [HttpPost("ObtenerRoles")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> OtenerRoles()
        {
            var rol = await _appController.RolPresenter.ObtenerRoles();

            return Ok(rol);
        }

        /// <summary>
        /// Consulta un rol mediante id
        /// </summary> 
        /// <response code="200">string</response>  
        /// <response code="400">string</response> 
        /// <response code="500">string</response> 
        [HttpPost("ObtenerRolPorId")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerRolPorId([FromBody] ObtenerRolPorIdDTO request)
        {
            var rol = await _appController.RolPresenter.ObtenerRolPorId(request.id);

            return Ok(rol);
        }

        /// <summary>
        /// Actualizar un rol
        /// </summary> 
        /// <response code="200">string</response>  
        /// <response code="400">string</response> 
        /// <response code="500">string</response> 
        [HttpPost("ActualizarRol")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ActualizarRol([FromBody] ActualizarRolDTO request)
        {
            var rol = await _appController.RolPresenter.ActualizarRol(request.id, request);

            return Ok(rol);
        }

        /// <summary>
        /// Insertar en la tabla de roles
        /// </summary> 
        /// <response code="200">string</response>  
        /// <response code="400">string</response> 
        /// <response code="500">string</response> 
        [HttpPost("InsertarRol")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarRol([FromBody] InsertarRolDTO request)
        {
            var rol = await _appController.RolPresenter.InsertarRol(request);

            return Ok(rol);
        }

        /// <summary>
        /// Eliminar rol
        /// </summary> 
        /// <response code="200">string</response>  
        /// <response code="400">string</response> 
        /// <response code="500">string</response> 
        [HttpPost("EliminarRol")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EliminarRol([FromBody] ObtenerRolPorIdDTO request)
        {
            var rol = await _appController.RolPresenter.EliminarRol(request.id);

            return Ok(rol);
        }
    }
}
