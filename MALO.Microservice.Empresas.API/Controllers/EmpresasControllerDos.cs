
namespace MALO.Microservice.Empresas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ApiController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appController"></param>
        public EmpresaController(IApiControllerEmpresas appController) : base(appController)
        {
        }
        //Consultar empresas
        /// <summary>
        /// Consulta un registro de la tabla Empresas
        /// </summary>
        /// <remarks>
        /// Sample request: 
        /// 
        ///     GET 
        ///       {
        ///         // No params needed
        ///       }
        /// </remarks>   
        /// <response code="200">Detalles de la empresa</response>  
        /// <response code="400">Solicitud incorrecta</response> 
        /// <response code="500">Error interno del servidor</response> 
        [HttpGet("GetEmpresa")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EmpresaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetEmpresa()
        {
            var empresa = await _appController.EmpresaPresenter.GetEmpresa();

            if (empresa == null)
            {
                return NotFound("No se encontró la empresa.");
            }

            return Ok(empresa);
        }

        //Consultar empresa 
        [HttpPost("GetEmpresaPorId")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EmpresaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetEmpresaPorId([FromBody] Guid empresaId)
        {
            if (empresaId == Guid.Empty)
            {
                return BadRequest("El ID de la empresa es requerido.");
            }

            var empresa = await _appController.EmpresaPresenter.GetEmpresaPorId(empresaId);

            if (empresa == null)
            {
                return NotFound("No se encontró la empresa.");
            }

            return Ok(empresa);
        }

        //Agregar empresa empresas
        [HttpPost("agregar-empresa")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AgregarEmpresa([FromBody] InsertarEmpresaDto insertarEmpresaDto)
        {
            if (insertarEmpresaDto == null || string.IsNullOrEmpty(insertarEmpresaDto.nombre))
            {
                return BadRequest("El nombre de la empresa es requerido.");
            }

            try
            {
                var resultado = await _appController.EmpresaPresenter.AddEmpresa(insertarEmpresaDto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al agregar la empresa: {ex.Message}");
            }
        }


        //actualizar empresa
        [HttpPost("actualizar-empresa")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ActualizarEmpresa([FromBody] ActualizarEmpresaDto empresaDto)
        {
            if (empresaDto == null || string.IsNullOrEmpty(empresaDto.Id))
            {
                return BadRequest("El ID y los detalles de la empresa son requeridos.");
            }

            try
            {
                var resultado = await _appController.EmpresaPresenter.UpdateEmpresa(empresaDto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar la empresa: {ex.Message}");
            }
        }

        //eliminar empresa
        /// <summary>
        /// Elimina un registro de la tabla Empresas
        /// </summary>
        /// <param name="empresaDto">DTO con los datos de la empresa a eliminar</param>
        /// <returns>Resultado de la eliminación</returns>
        [HttpPost("eliminar-empresa")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EliminarEmpresa([FromBody] EliminarEmpresaDto empresaDto)
        {
            if (empresaDto == null || string.IsNullOrEmpty(empresaDto.Id) || !Guid.TryParse(empresaDto.Id, out var empresaId))
            {
                return BadRequest("El ID de la empresa es requerido o no es válido.");
            }

            try
            {
                var resultado = await _appController.EmpresaPresenter.DeleteEmpresa(empresaDto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar la empresa: {ex.Message}");
            }
        }
    }
}