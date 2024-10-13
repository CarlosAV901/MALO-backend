using MALO.Microservice.Empleos.Domain.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;

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


    }
}
