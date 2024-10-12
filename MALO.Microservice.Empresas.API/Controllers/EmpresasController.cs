
namespace MALO.Microservice.Empresas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresasController : ControllerBase
    {
        private readonly EmpresasService _empresasService;

        public EmpresasController(EmpresasService empresasService)
        {
            _empresasService = empresasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaDto>>> Get()
        {
            var empresas = await _empresasService.ObtenerEmpresas();
            return Ok(empresas);
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> AgregarEmpresa([FromBody] EmpresaDto nuevaEmpresa)
        {
            try
            {
                await _empresasService.AgregarEmpresa(nuevaEmpresa);
                return Ok(new { message = "Empresa agregada correctamente" });
            }
            catch (InvalidOperationException ex)  // Empresa ya existente
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)  // Otros errores
            {
                return StatusCode(500, new { message = "Error en el servidor", details = ex.Message });
            }
        }

        // Consultar empresa por ID desde el cuerpo de la solicitud (POST)
        [HttpPost("consultar-empresa")]
        public async Task<IActionResult> ConsultarEmpresa([FromBody] ConsultaEmpresaPorIdDto consultaDto)
        {
            if (string.IsNullOrEmpty(consultaDto?.Id))
            {
                return BadRequest("El ID de la empresa no puede estar vacío.");
            }

            try
            {
                var empresa = await _empresasService.ConsultarEmpresaPorId(consultaDto.Id);
                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al consultar la empresa: {ex.Message}");
            }
        }

        // Consultar empresa por ID desde la ruta (GET)
        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarEmpresaPorId(string id)
        {
            try
            {
                var empresa = await _empresasService.ConsultarEmpresaPorId2(id);
                return Ok(empresa);
            }
            catch (KeyNotFoundException ex) // Empresa no encontrada
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex) // ID no válido
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex) // Otros errores
            {
                return StatusCode(500, new { message = "Error en el servidor", details = ex.Message });
            }

        }


        [HttpDelete("eliminar-empresa")]
        public async Task<IActionResult> EliminarEmpresa([FromBody] EliminarEmpresaDto eliminarDto)
        {
            try
            {
                await _empresasService.EliminarEmpresaPorId(eliminarDto.Id);
                return Ok(new { message = "Empresa eliminada correctamente." });
            }
            catch (KeyNotFoundException ex) // Empresa no encontrada
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex) // Otros errores
            {
                return StatusCode(500, new { message = "Error en el servidor", details = ex.Message });
            }
        }

        [HttpDelete("eliminarEmpresa/{id}")]
        public async Task<IActionResult> EliminarEmpresa(string id)
        {
            try
            {
                await _empresasService.EliminarEmpresaPorId(id);
                return Ok(new { message = "Empresa eliminada correctamente." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error en el servidor", details = ex.Message });
            }
        }

        //actualizar empresa
        [HttpPut("actualizar-empresa")]
        public async Task<IActionResult> ActualizarEmpresa([FromBody] ActualizarEmpresaDto empresaDto)
        {
            if (string.IsNullOrEmpty(empresaDto?.Id))
            {
                return BadRequest("El ID de la empresa no puede estar vacío.");
            }

            try
            {
                await _empresasService.ActualizarEmpresa(empresaDto);
                return Ok(new { message = "Empresa actualizada correctamente." });
            }
            catch (ArgumentException ex)  // GUID no válido
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)  // Empresa no encontrada
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)  // Otros errores
            {
                return StatusCode(500, new { message = "Error en el servidor", details = ex.Message });
            }
        }

    }
}

