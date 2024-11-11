

using MALO.Microservice.Empleos.Aplication.Services;
using MALO.Microservice.Empleos.Domain.DTOs.Usuario;
using MALO.Microservice.Empleos.Infraestructure.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace MALO.Microservice.Empleos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ApiController
    {
        private readonly IMessage _emailService;
        private readonly FileService _fileService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appController"></param>
        public UsuarioController(IApiController appController, IMessage emailService, FileService fileService) : base(appController)
        {
            _emailService = emailService;
            _fileService = fileService;
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

            var verificationLink = $"https://malo-backend.onrender.com/api/usuario/confirmar?token={usuarioInsertarDto.token}";
            //var verificationLink = $"https://localhost:7181/api/usuario/confirmar?token={usuarioInsertarDto.token}";
            var subject = "Confirma tu cuenta";
            var body = $@"
                    <!DOCTYPE html>
                    <html lang='es'>
                    <head>
                        <meta charset='UTF-8'>
                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                        <title>Confirmación de Correo</title>
                        <style>
                            body {{
                                font-family: Arial, sans-serif;
                                background-color: #f4f4f4;
                                margin: 0;
                                padding: 20px;
                            }}
                            .container {{
                                max-width: 600px;
                                margin: auto;
                                background: white;
                                padding: 20px;
                                border-radius: 5px;
                                box-shadow: 0 2px 5px rgba(0,0,0,0.1);
                            }}
                            .header {{
                                text-align: center;
                                margin-bottom: 20px;
                            }}
                            .header img {{
                                max-width: 100%;
                                height: auto;
                            }}
                            .content {{
                                margin: 20px 0;
                                text-align: center;
                            }}
                            .button {{
                                display: inline-block;
                                padding: 10px 20px;
                                background-color: #007BFF;
                                color: white;
                                text-decoration: none;
                                border-radius: 5px;
                                margin-top: 20px;
                            }}
                            .footer {{
                                text-align: center;
                                font-size: 12px;
                                color: #666;
                                margin-top: 30px;
                            }}
                        </style>
                    </head>
                    <body>
                        <div class='container'>
                            <div class='header'>
                                <img src='https://malo-zeta.vercel.app/malo_logo_azul.png' alt='Logo' />
                            </div>
                            <div class='content'>
                                <h2>¡Gracias por registrarte!</h2>
                                <p>Haz clic en el siguiente enlace para confirmar tu cuenta:</p>
                                <a href='{verificationLink}' class='button'>Confirmar mi cuenta</a>
                            </div>
                            <div class='footer'>
                                <p>Si no te registraste en nuestro sitio, ignora este mensaje.</p>
                            </div>
                        </div>
                    </body>
                    </html>
                    ";


            await _emailService.SendEmail(usuarioInsertarDto.email, subject, body);


            return Ok(new
            {
                message = "Usuario registrado. Revisa tu correo para confirmar la cuenta."
            });

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
                
                return Ok(new
                {
                    message = "Correo confirmado correctamente.",
                    result = true
                });
            }
      
            return BadRequest("Token inválido o expirado.");
            
            
        }


        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("EliminarUsuario")]
        [Authorize]
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
        public async ValueTask<IActionResult> ActualizarUsuario([FromForm] ActualizarUsuarioDTO request, [FromForm] IFormFile archivo)
        {
            string urlImagen = null;

            var usuarioDto = new ObtenerUsuarioPorId { Id = request.UsuarioId };

            var documento = await _appController.UserPresenter.ObtenerContenido(usuarioDto);
            string archivoAnteriorUrl = documento;

            if (!string.IsNullOrEmpty(archivoAnteriorUrl))
            {
                var nombreArchivoAnterior = Path.GetFileName(archivoAnteriorUrl);
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

            request.imagen_perfil = urlImagen;

            var usuario = await _appController.UserPresenter.ActualizarUsuario(request.UsuarioId, request);

            return Ok(usuario);
        }


    }
}
