

using MALO.Microservice.Empleos.Infraestructure.Services;

namespace MALO.Microservice.Empleos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ApiController
    {
        private readonly IMessage _emailService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appController"></param>
        public UsuarioController(IApiController appController, IMessage emailService) : base(appController)
        {
            _emailService = emailService;
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
        [HttpPost("ObtenerUsuarioPorId")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async ValueTask<IActionResult> ObtenerUsuarioPorId([FromBody] ObtenerUsuarioPorId request)
        {
            var usuario = await _appController.UserPresenter.ObtenerUsuarioPorId(request.Id);

            return Ok(usuario);
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
        [HttpGet("ObtenerUsuarios")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> ObtenerUsuarios()
        {
            var usuario = await _appController.UserPresenter.ObtenerUsuarios();

            return Ok(usuario);
        }

        /// <summary>
        /// Inserta un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="usuarioInsertarDto">Datos del usuario a insertar</param> 
        /// <remarks>
        /// Sample request: 
        /// 
        ///     POST 
        ///     {
        ///         "Nombre": "Carlos",
        ///         "Apellido": "Aguilar",
        ///         "Email": "charly@example.com",
        ///         "Contrasena": "secreta123",
        ///         "FechaNacimiento": "1990-05-15",
        ///         "Telefono": "555-1234",
        ///         "RolId": 1,
        ///         "EstadoId": 1,
        ///         "MunicipioId": 1,
        ///         "LocalidadId": 1,
        ///         "Habilidades": "1,2",
        ///         "Descripcion": "Trabaje 5 años en una empresa de software",
        ///         "ImagenPerfil": null
        ///     }
        /// </remarks>   
        /// <response code="200">Usuario insertado con éxito</response>  
        /// <response code="400">Error en la solicitud (datos inválidos)</response> 
        /// <response code="500">Error interno del servidor</response>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("InsertarUsuario")]
        public async ValueTask<IActionResult> InsertarUsuario([FromBody] UsuarioInsertarDto usuarioInsertarDto)
        {

            var usuario = await _appController.UserPresenter.InsertarUsuario(usuarioInsertarDto);
            

            if (usuario == null)
            {
                return BadRequest("No se pudo registrar al usuario");
            }


            await _emailService.SendEmail(usuarioInsertarDto.email, usuarioInsertarDto.token);


            return Ok("Usuario registrado. Revisa tu correo para confirmar la cuenta.");

        }


        [HttpGet("confirmar")]
        public async Task<IActionResult> ConfirmarCorreo([FromQuery] Guid token)
        {
            var resultado = _appController.UserPresenter.ConfirmarUsuario(token);


            if(resultado == null)
            {
                return BadRequest("Enlace de confirmación inválido o ya utilizado.");
            }


            if(await resultado == "Correo confirmado correctamente")
            {
                
                return Ok("Correo confirmado correctamente.");
            }

            
            
      
            return BadRequest("Token inválido o expirado.");
            
            
        }


        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("EliminarUsuario")]
        public async ValueTask<IActionResult> EliminarUsuario([FromBody] ObtenerUsuarioPorId request)
        {
            var usuario = await _appController.UserPresenter.EliminarUsuario(request.Id);

            return Ok(usuario);
        }


        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("ActualizarUsuario")]
        [Authorize]
        public async ValueTask<IActionResult> ActualizarUsuario([FromBody] ActualizarUsuarioDTO request)
        {
            var usuario = await _appController.UserPresenter.ActualizarUsuario(request.UsuarioId, request);

            return Ok(usuario);
        }


    }
}
